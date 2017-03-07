Imports VzAdmin
Imports MySql.Data.MySqlClient
Imports VzTesoreria

Public Class cMailingTesoFinDia

    Public Sub New(ByRef pAdmmin As cAdmin)

    End Sub

    Public Shared Function Ejecutar(ByRef pAdmin As cAdmin) As Boolean
        Ejecutar = False
        Dim lMail As New cEmail(pAdmin)
        Dim lHtml As String = ""
        Dim lSetting As cSetting = Nothing
        Dim lDt As DataTable = Nothing

        Try
            lSetting = cSetting.GetSettingxCodigo(pAdmin, "Mailing_TesoFinDia")
            lMail.Tipo_Mailing = "TesoFinDia"
            lMail.Fecha = Date.Today
            lMail.Html = True
            lMail.Para = lSetting.Valor.ToString.Trim
            lMail.Asunto = "Tesoreria - Resumen Fin de Dia"


            'Armo el HTML con los valores para reemplazar:
            '--------------------------------------------
            lHtml = "<HTML><H1> Notificacion Automatica de Inicio de Día <HR> </H1>"
            lHtml = lHtml & "<BODY> Buenos días, <BR>"
            lHtml = lHtml & "A continuación se adjunta un breve resúmen de fin de día. <BR> <P>"
            lHtml = lHtml & "<B>TESORERIA:  <BR> <P>"
            lHtml = lHtml & "Hoy se cargaron #CantLiquidacionesDelDia# liquidaciones por un total de<B> $#SumaLiquidacionesDelDia#</B> pesos. <BR>"
            lHtml = lHtml & "En la conciliacion se registro una diferencia de caja de $#DiferenciaDeCaja# pesos. <BR> <P>"
            lHtml = lHtml & "#TotalLiquidacionesdelDia# <BR>"
            lHtml = lHtml & "#TotalLiquidacionesXVendedor# <BR>"
            lHtml = lHtml & " <BR> "
            lHtml = lHtml & " <B> VENTAS:  <BR> <P>"
            lHtml = lHtml & "Hoy se ingesaron Cheques rechazados pendientes de levantar: <BR><BR>"
            lHtml = lHtml & "#TablaDeChequesRechazados#"
            lHtml = lHtml & "<BR><BR> Muchas gracias. <BR> Sldos."
            lHtml = lHtml & "</BODY></HTML>"


            'Ahora solo reemplazo los valores en el HTML
            '-------------------------------------------
            lHtml = lHtml.Replace("#CantLiquidacionesDelDia#", cLiquidacion.Dat_GetCantLiquidacionesdelDiaxEstado(pAdmin, 2).ToString)
            lHtml = lHtml.Replace("#SumaLiquidacionesDelDia#", Strings.FormatNumber(cLiquidacion.Dat_GetTotalLiquidacionesdelDiaxEstado(pAdmin, 2).ToString))

            lDt = cLiquidacion.Dat_GetTotalLiquidacionesdelDiaxFecha(pAdmin, Date.Today)
            lHtml = lHtml.Replace("#TablaDeCaidaDeCheques#", cFunciones.DataTableToHTMLTable(lDt))

            lDt = cLiquidacion.Dat_GetTotLiqGroupVendedorxFechaEstado(pAdmin, Date.Today, 2)
            lHtml = lHtml.Replace("#TotalLiquidacionesXVendedor#", cFunciones.DataTableToHTMLTable(lDt))

            lHtml = lHtml.Replace("#DiferenciaDeCaja#", Strings.FormatNumber(cConciliacionLiq.Dat_GetTotalAjustesxFechaEstado(pAdmin, Date.Today, 0).ToString))



            ''Traigo los cheques que estan rechazados y no levantados aun.
            'lDt = cCheque.Dat_GetDetalleChequesxEstado(pAdmin, 2)

            'If lDt.Rows.Count > 0 Then
            '    lHtml = lHtml.Replace("#TablaDeChequesRechazados#", cFunciones.DataTableToHTMLTable(lDt))
            'Else
            '    lHtml = lHtml.Replace("#TablaDeChequesRechazados#", "No hay cheques rechazados pendientes de levantar. <BR>")
            'End If

            lMail.Body = lHtml
            lMail.Guardar()

            Ejecutar = True
        Catch ex As Exception
            pAdmin.Log.fncGrabarLogERR("Error en cMailingTesoFinDia.Ejecutar:" & ex.Message)
        End Try
    End Function

End Class
