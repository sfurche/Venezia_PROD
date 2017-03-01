Imports VzAdmin
Imports MySql.Data.MySqlClient
Public Class cMailingTesoInicioDia

    Public Sub New(ByRef pAdmmin As cAdmin)

    End Sub

    Public Shared Function Ejecutar(ByRef pAdmmin As cAdmin) As Boolean
        Ejecutar = False
        Dim lMail As New cEmail(pAdmmin)
        Dim lHtml As String = ""
            Dim lCliente As cCliente = Nothing
            Dim lSetting As cSetting = Nothing

        Try
            lSetting = cSetting.GetSettingxCodigo(pAdmmin, "Mailing_TesoInicioDia")
            lMail.Tipo_Mailing = "TesoInicioDia"
            lMail.Fecha = Date.Today
                lMail.Html = True
                lMail.Para = lSetting.Valor.ToString.Trim
            lMail.Asunto = "Tesoreria - Inicio de Dia"


            'Armo el HTML con los valores para reemplazar:
            '--------------------------------------------
            lHtml = "<HTML><H1>Notificacion Automatica de Cheque Rechazado <HR> </H1>"
                lHtml = lHtml & "<BODY> <BIG>Se acaba de registrar un nuevo cheque rechazado. A continuacion los datos del mismo: </BIG> <P>"
                lHtml = lHtml & "<B> Banco: </B> #Banco_Nombre# <BR>"
                lHtml = lHtml & "<B> Numero: </B> #Cheque_Numero# <BR>"
                lHtml = lHtml & "<B> Importe: </B> #Cheque_Importe# <BR>"
                lHtml = lHtml & "<B> Origen del Cheque:</B>  #Cheque_Origen# #Cheque_Cliente_Nombre# <BR>"
                lHtml = lHtml & "<B> Orden de Pago Nro:</B>  #OrdenPago_Numero# <BR>"
                lHtml = lHtml & "<B> Destino del Cheque: </B> #OrdenPago_Destino# #OrdenPago_Proveedor_Nombre# <BR>"
                lHtml = lHtml & "</BODY></HTML>"


                'Ahora solo reemplazo los valores en el HTML
                '-------------------------------------------

                lHtml = lHtml.Replace("#Banco_Nombre#", Me.Banco.NombreRed.Trim)
                lHtml = lHtml.Replace("#Cheque_Numero#", Me.Numero)
                lHtml = lHtml.Replace("#Cheque_Importe#", Me.Importe.ToString)


                If Me.Propio = enuBinario.No Then
                    lCliente = cCliente.GetClientexNroCliente(gAdmin, Me.NroCli)
                    lHtml = lHtml.Replace("#Cheque_Origen#", "Terceros ")
                    lHtml = lHtml.Replace("#Cheque_Cliente_Nombre#", "(" & lCliente.Nombre & ")")
                Else
                    lHtml = lHtml.Replace("#Cheque_Origen#", " Propio")
                    lHtml = lHtml.Replace("#Cheque_Cliente_Nombre#", "")
                End If


                lOp = cOrdenDePago.GetOrdenDePagoxId(gAdmin, Me.Id_Orden)
                lHtml = lHtml.Replace("#OrdenPago_Numero#", lOp.Id_Orden.ToString)
                If lOp.Tipo_Destino = cOrdenDePago.enuTipoDestinoOrdenPago.Proveedores Then
                    lHtml = lHtml.Replace("#OrdenPago_Destino#", "Proveedor ")
                    lHtml = lHtml.Replace("#OrdenPago_Proveedor_Nombre#", "(" & lOp.Proveedor.Nombre & ")")
                Else
                    lHtml = lHtml.Replace("#OrdenPago_Destino#", "Cobro/Deposito ")
                    lHtml = lHtml.Replace("#OrdenPago_Proveedor_Nombre#", "")
                End If

                lMail.Body = lHtml
                lMail.Guardar()



                Ejecutar = True
        Catch ex As Exception

        End Try
    End Function

    Private Shared Function Dat_GetCantChequesEnCartera(ByRef pAdmin As VzAdmin.cAdmin, ByVal pIdChq As String) As Integer

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "select count(*) from vz_cheques where id_estado = 0;"
            'Sql = Sql.Replace("#Id#", pIdChq)

            With Cmd
                .Connection = lCnn
                .CommandType = CommandType.Text
                .CommandText = Sql

                If lCnn.State = ConnectionState.Closed Then
                    lCnn.Open()
                End If
                Dim lAdap As New MySqlDataAdapter(Cmd)
                lDt = New DataTable
                lAdap.Fill(lDt)
                lCnn.Close()
            End With

            Return Integer.Parse(lDt.Rows(0)(0))

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cMailingTesoInicioDia.Dat_GetCantChequesEnCartera")
            pAdmin.Log.fncGrabarLogERR("Error en cMailingTesoInicioDia.Dat_GetCantChequesEnCartera:" & ex.Message)
            Return Nothing
        End Try
    End Function


    Private Shared Function Dat_GetTotalChequesEnCartera(ByRef pAdmin As VzAdmin.cAdmin, ByVal pIdChq As String) As Double

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "select round(sum(importe),2)  from vz_cheques  where id_estado = 0;"
            'Sql = Sql.Replace("#Id#", pIdChq)

            With Cmd
                .Connection = lCnn
                .CommandType = CommandType.Text
                .CommandText = Sql

                If lCnn.State = ConnectionState.Closed Then
                    lCnn.Open()
                End If
                Dim lAdap As New MySqlDataAdapter(Cmd)
                lDt = New DataTable
                lAdap.Fill(lDt)
                lCnn.Close()
            End With

            Return Double.Parse(lDt.Rows(0)(0))

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cMailingTesoInicioDia.Dat_GetCantChequesEnCartera")
            pAdmin.Log.fncGrabarLogERR("Error en cMailingTesoInicioDia.Dat_GetCantChequesEnCartera:" & ex.Message)
            Return Nothing
        End Try
    End Function

End Class
