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

            lHtml = lHtml & "Hoy se cargaron #CantLiquidacionesDelDia# liquidaciones por un total de<B> $#SumaLiquidacionesDelDia#</B> pesos. <BR> <P>"
            lHtml = lHtml & "#TotalLiquidacionesdelDia#"
            lHtml = lHtml & "<BR>"
            lHtml = lHtml & "Cheques rechazados pendientes de levantar: <BR><BR>"
            lHtml = lHtml & "#TablaDeChequesRechazados#"
            lHtml = lHtml & "<BR><BR> Muchas gracias. <BR> Sldos."
            lHtml = lHtml & "</BODY></HTML>"


            'Ahora solo reemplazo los valores en el HTML
            '-------------------------------------------
            lHtml = lHtml.Replace("#CantLiquidacionesDelDia#", cLiquidacion.Dat_GetCantLiquidacionesdelDiaxEstado(pAdmin, 2).ToString)
            lHtml = lHtml.Replace("#SumaLiquidacionesDelDia#", Strings.FormatNumber(cLiquidacion.Dat_GetTotalLiquidacionesdelDiaxEstado(pAdmin, 2).ToString))

            lDt = cLiquidacion.Dat_GetTotalLiquidacionesdelDiaxFecha(pAdmin, Date.Today)
            lHtml = lHtml.Replace("#TablaDeCaidaDeCheques#", cFunciones.DataTableToHTMLTable(lDt))


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

        End Try
    End Function



    'Private Shared Function Dat_GetTotalLiquidacionesdelDiaxEstado(ByRef pAdmin As VzAdmin.cAdmin) As Double

    '    Dim Cmd As New MySqlCommand
    '    Dim Sql As String
    '    Dim lDt As DataTable
    '    Dim lCnn As MySqlConnection

    '    Try
    '        lCnn = pAdmin.DbCnn.GetInstanceCon
    '        Sql = "Select round(sum(importe_cash + importe_cheques + importe_retenciones + importe_transferencias + importe_ncredito),2) Total from vz_liquidaciones where fecha = CURDATE() and id_estado=2;"
    '        'Sql = Sql.Replace("#Id#", pIdChq)

    '        With Cmd
    '            .Connection = lCnn
    '            .CommandType = CommandType.Text
    '            .CommandText = Sql

    '            If lCnn.State = ConnectionState.Closed Then
    '                lCnn.Open()
    '            End If
    '            Dim lAdap As New MySqlDataAdapter(Cmd)
    '            lDt = New DataTable
    '            lAdap.Fill(lDt)
    '            lCnn.Close()
    '        End With

    '        Return Double.Parse(lDt.Rows(0)(0))

    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "cMailingTesoInicioDia.Dat_GetCantChequesEnCartera")
    '        pAdmin.Log.fncGrabarLogERR("Error en cMailingTesoInicioDia.Dat_GetCantChequesEnCartera:" & ex.Message)
    '        Return Nothing
    '    End Try
    'End Function

End Class
