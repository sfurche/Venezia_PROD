Imports VzAdmin
Imports VzTesoreria


Public Class frmMailSoporte
    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        Try

            If txtMje.Text.Trim = "" Then
                MsgBox("Debe escribir un mensaje para enviar...", MsgBoxStyle.Exclamation, "Mensaje vacio")
                Exit Sub
            End If

            cEmail.EnviarMailSoporte(txtMje.Text, gAdmin.User.Usuario.Trim)

            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmMailSoporte.btnEnviar_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmMailSoporte.btnEnviar_Click:" & ex.Message)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim lDt As New DataTable
        Dim MjeHTML As String = ""
        Try


            lDt = cLiquidacion.Dat_RptLiqFDFH(gAdmin, "2016/08/01", "2016/09/30")

            MjeHTML = MjeHTML & "<html xmlns='http://www.w3.org/1999/xhtml'>"
            MjeHTML = MjeHTML & "<body>"
            MjeHTML = MjeHTML & cFunciones.DataTableToHTMLTable(lDt)
            MjeHTML = MjeHTML & "</body>"
            MjeHTML = MjeHTML & "</html>"


            'MjeHTML = "this is a sample body with html in it. <b>This is bold</b> <font color=#336699>This is blue</font>"
            cEmail.EnviarMailHTML(MjeHTML, gAdmin.User.Usuario.Trim)




        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmMailSoporte.btnEnviar_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmMailSoporte.btnEnviar_Click:" & ex.Message)
        End Try
    End Sub
End Class