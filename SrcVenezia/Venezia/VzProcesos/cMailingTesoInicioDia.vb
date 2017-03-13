Imports VzAdmin
Imports MySql.Data.MySqlClient
Imports VzTesoreria

Public Class cMailingTesoInicioDia

    Public Sub New(ByRef pAdmmin As cAdmin)

    End Sub

    Public Shared Function Ejecutar(ByRef pAdmin As cAdmin) As Boolean
        Ejecutar = False
        Dim lMail As New cEmail(pAdmin)
        Dim lHtml As String = ""
        Dim lSetting As cSetting = Nothing
        Dim lDt As DataTable = Nothing

        Try
            lSetting = cSetting.GetSettingxCodigo(pAdmin, "Mailing_TesoInicioDia")
            lMail.Tipo_Mailing = "TesoInicioDia"
            lMail.Fecha = Date.Today
            lMail.Html = True
            lMail.Para = lSetting.Valor.ToString.Trim
            lMail.BCC = "sebastianfurche@gmail.com"
            lMail.Asunto = "Tesoreria - Inicio de Dia (" & cFunciones.gFncConvertDateToString(Date.Today, "DD/MM/YYYY") & ")"


            'Armo el HTML con los valores para reemplazar:
            '--------------------------------------------
            lHtml = "<HTML><H1> Notificación Automática de Inicio de Día <HR> </H1>"
            lHtml = lHtml & "<BODY> Buenos días, <BR>"
            lHtml = lHtml & "A continuación se adjunta un breve resúmen de la información mas importante para empezar el día. <BR> <P>"
            lHtml = lHtml & "Actualmente hay #CantChequesenCartera# cheques en cartera por un total de<B> $#SumaChequesenCartera#</B> pesos. <BR> <P>"
            lHtml = lHtml & "Esto es la caída de cheques para los próximos 7 días: <BR><BR>"
            lHtml = lHtml & "#TablaDeCaidaDeCheques#"
            lHtml = lHtml & "<BR>"
            lHtml = lHtml & "Cheques rechazados pendientes de levantar: <BR><BR>"
            lHtml = lHtml & "#TablaDeChequesRechazados#"
            lHtml = lHtml & "<BR><BR> Muchas gracias. <BR> Sldos."
            lHtml = lHtml & "</BODY></HTML>"


            'Ahora solo reemplazo los valores en el HTML
            '-------------------------------------------

            lHtml = lHtml.Replace("#SumaChequesenCartera#", Strings.FormatNumber(cCheque.Dat_GetTotalChequesxEstado(pAdmin, 0).ToString))
            lHtml = lHtml.Replace("#CantChequesenCartera#", cCheque.Dat_GetCantChequesxEstado(pAdmin, 0).ToString)

            'Busco los cheques que caen en los proximos 7 dias
            lDt = cCheque.Dat_GetTotalCaidaChequesxDiasFuturo(pAdmin, 7)
            lHtml = lHtml.Replace("#TablaDeCaidaDeCheques#", cFunciones.DataTableToHTMLTable(lDt))


            'Traigo los cheques que estan rechazados y no levantados aun.
            lDt = cCheque.Dat_GetDetalleChequesxEstado(pAdmin, 2)

            If lDt.Rows.Count > 0 Then
                lHtml = lHtml.Replace("#TablaDeChequesRechazados#", cFunciones.DataTableToHTMLTable(lDt))
            Else
                lHtml = lHtml.Replace("#TablaDeChequesRechazados#", "No hay cheques rechazados pendientes de levantar. <BR>")
            End If

            lMail.Body = lHtml
            lMail.Guardar()

            Ejecutar = True
        Catch ex As Exception
            pAdmin.Log.fncGrabarLogERR("Error en cMailingTesoInicioDia.Ejecutar:" & ex.Message)
        End Try
    End Function



End Class
