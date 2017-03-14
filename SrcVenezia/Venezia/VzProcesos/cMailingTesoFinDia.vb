Imports VzAdmin
Imports MySql.Data.MySqlClient
Imports VzTesoreria
Imports VzComercial

Public Class cMailingTesoFinDia

    Public Sub New(ByRef pAdmmin As cAdmin)

    End Sub

    Public Shared Function Ejecutar(ByRef pAdmin As cAdmin, ByVal pFecha As Date) As Boolean
        Ejecutar = False
        Dim lMail As New cEmail(pAdmin)
        Dim lHtml As String = ""
        Dim lSetting As cSetting = Nothing
        Dim lDt As DataTable = Nothing
        Dim lPrimeroDeMes As Date = cFunciones.gFncConvertStringToDate(Date.Today.Year & "/" & Date.Today.Month & "/01", "YYYY/MM/DD")

        Try
            lSetting = cSetting.GetSettingxCodigo(pAdmin, "Mailing_TesoFinDia")
            lMail.Tipo_Mailing = "TesoFinDia"
            lMail.Fecha = Date.Today
            lMail.Html = True
            lMail.Para = lSetting.Valor.ToString.Trim
            lMail.BCC = "sebastianfurche@gmail.com"
            lMail.Asunto = "Tesoreria - Resumen Fin de Dia (" & cFunciones.gFncConvertDateToString(Date.Today, "DD/MM/YYYY") & ")"


            'Armo el HTML con los valores para reemplazar:
            '--------------------------------------------
            lHtml = "<HTML><H1> Notificación Automática de Fin de Día <HR> </H1>"
            lHtml = lHtml & "<BODY> Buenos días, <BR>"
            lHtml = lHtml & "A continuación se adjunta un breve resúmen de fin de día. <BR> <P>"
            lHtml = lHtml & "<B>TESORERIA:  <BR> <P>"
            lHtml = lHtml & "Hoy se cargaron #CantLiquidacionesDelDia# liquidaciones por un total de<B> $#SumaLiquidacionesDelDia#</B> pesos. <BR>"
            lHtml = lHtml & "La diferencia de caja en el proceso de conciliacion fue de $#DiferenciaDeCaja# pesos. <BR> <P>"
            lHtml = lHtml & "#TotalLiquidacionesdelDia# <BR>"
            lHtml = lHtml & "#TotalLiquidacionesXVendedor# <BR>"
            lHtml = lHtml & " <BR> "
            lHtml = lHtml & " <B> VENTAS:  <BR> <P>"
            lHtml = lHtml & "Durante este mes se registraron #CantFacturas# facturas por un total de<B> $#TotalFacturacion#</B> pesos (IVA incluido). A continuacion el detalle por vendedor:  <BR><BR>"
            lHtml = lHtml & "#TablaFacturasxVendedor# <BR>"
            lHtml = lHtml & "Total NC: $#NotasDeCredito# / Total ND: $#NotasDeDebito#  <BR>"
            lHtml = lHtml & "Facturas proforma se ingresaron #CantProformas# por un total de $#TotalProformas# (IVA incluido).<BR>"
            lHtml = lHtml & "<BR><BR> Muchas gracias. <BR> Sldos."
            lHtml = lHtml & "</BODY></HTML>"


            'Ahora solo reemplazo los valores en el HTML
            '-------------------------------------------
            'Cantidad de liquidaciones registradas en el dia.
            lHtml = lHtml.Replace("#CantLiquidacionesDelDia#", cLiquidacion.Dat_GetCantLiquidacionesdelDiaxEstado(pAdmin, pFecha, 2).ToString)

            'Suma de las liquidaciones registradas en el dia.
            lHtml = lHtml.Replace("#SumaLiquidacionesDelDia#", Strings.FormatNumber(cLiquidacion.Dat_GetTotalLiquidacionesdelDiaxEstado(pAdmin, pFecha, 2).ToString))

            'Tabla con los totales de las liquidaciones del dia, discriminando total cheques, efectivo, transferencias y retenciones. 
            lDt = cLiquidacion.Dat_GetTotalLiquidacionesdelDiaxFecha(pAdmin, pFecha)
            lHtml = lHtml.Replace("#TotalLiquidacionesdelDia#", cFunciones.DataTableToHTMLTable(lDt))

            'Tabla con los totales de liquidaciones ingresadas en el dia por vendedor.
            lDt = cLiquidacion.Dat_GetTotLiqGroupVendedorxFechaEstado(pAdmin, pFecha, 2)
            lHtml = lHtml.Replace("#TotalLiquidacionesXVendedor#", cFunciones.DataTableToHTMLTable(lDt))

            'Este muestra la suma absoluta de los ajustes ingresados en el proceso de conciliacion de las liquidaciones del dia.
            lHtml = lHtml.Replace("#DiferenciaDeCaja#", Strings.FormatNumber(cConciliacionLiq.Dat_GetTotalAjustesxFechaEstado(pAdmin, pFecha, 0).ToString))


            '------------------------COMERCIAL --------------------------------------
            'Cantidad de facturas registradas en el dia.
            lHtml = lHtml.Replace("#CantFacturas#", cFactura.Dat_GetCantFacturasxFechaDH(pAdmin, lPrimeroDeMes, pFecha).ToString)

            'Monto total de facturas registradas en el dia con iva incluido.
            lHtml = lHtml.Replace("#TotalFacturacion#", Strings.FormatNumber(cFactura.Dat_GetTotalFacturasCIVAxFechaDH(pAdmin, lPrimeroDeMes, pFecha).ToString))

            'Tabla de totales de facturas por vendedor, discriminando con iva, sin iva y comision.
            lDt = cFactura.Dat_GetTotalFactAgrupVendxFechaDH(pAdmin, pFecha, pFecha)
            lHtml = lHtml.Replace("#TablaFacturasxVendedor#", cFunciones.DataTableToHTMLTable(lDt))

            'Monto total de notas de credito registradas en el dia.
            lHtml = lHtml.Replace("#NotasDeCredito#", Strings.FormatNumber(cFactura.Dat_GetTotalNotasCreditoxFechaDH(pAdmin, lPrimeroDeMes, pFecha).ToString))

            'Monto total de notas de debito registradas en el dia.
            lHtml = lHtml.Replace("#NotasDeDebito#", Strings.FormatNumber(cFactura.Dat_GetTotalNotasDebitoxFechaDH(pAdmin, lPrimeroDeMes, pFecha).ToString))

            'Cantidad de facturas proforma registradas en el dia.
            lHtml = lHtml.Replace("#CantProformas#", cFacturaProforma.Dat_GetCantFacturasxFecha(pAdmin, lPrimeroDeMes, pFecha).ToString)

            'Monto total de facturas proforma registradas en el dia con iva incluido.
            lHtml = lHtml.Replace("#TotalProformas#", Strings.FormatNumber(cFacturaProforma.Dat_GetTotalFacturasCIVAxFecha(pAdmin, lPrimeroDeMes, pFecha).ToString))


            lMail.Body = lHtml
            lMail.Guardar()

            Ejecutar = True
        Catch ex As Exception
            pAdmin.Log.fncGrabarLogERR("Error en cMailingTesoFinDia.Ejecutar: " & ex.Message)
        End Try
    End Function

End Class
