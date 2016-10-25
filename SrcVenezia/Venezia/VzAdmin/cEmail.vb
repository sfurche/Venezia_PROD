Imports System
Imports System.Collections
Imports System.Net
Imports System.Net.Mail
Imports System.Net.Mime

Public Class cEmail

    Public Shared Sub EnviarMailSoporte(ByVal pMensaje As String, ByVal pUsuario As String)
        ''''ATENCION: Para que esto funcion, en el caso de GMAIL, la primera vez que intenta mandar un mail, falla con el siguiente error:
        '{"The SMTP server requires a secure connection or the client was not authenticated. The server response was: 5.5.1 Authentication Required. Learn more at"}	System.Net.Mail.SmtpException
        'Adicionalmente, llega un mail de google a la casilla y ahi te da el link para habilitar que aplicaciones se puedan loguear en la cuenta. Si no se puede
        'ingresar con la siguiente url:  security.google.com/settings/security/activity

        'Definicion e instanciacion de la clase MailMessage
        Dim MMessage As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
        'Rellenamos los parametros usuales para el envio de un email
        MMessage.To.Add("sebastianfurche@gmail.com")
        MMessage.From = New MailAddress("veneziasystemsmf@gmail.com", "Venezia System SMF", System.Text.Encoding.UTF8)

        MMessage.Subject = Now.ToString & "- Mensaje de Soporte de " & pUsuario.Trim
        MMessage.SubjectEncoding = System.Text.Encoding.UTF8

        MMessage.Body = pMensaje
        MMessage.BodyEncoding = System.Text.Encoding.UTF8

        MMessage.IsBodyHtml = False 'Formato texto plano
        'Definimos nuestras credenciales para el unvio de emails a traves de Gmail
        Dim SClient As New SmtpClient()
        SClient.Credentials = New System.Net.NetworkCredential("veneziasystemsmf@gmail.com", "trabajo.1979")
        SClient.Host = "smtp.gmail.com" 'Servidor SMTP de Gmail
        SClient.Port = 587 'Puerto del SMTP de Gmail
        SClient.EnableSsl = True 'Habilita el SSL, necesio en Gmail
        'Capturamos los errores en el envio
        Try
            SClient.Send(MMessage)
            MsgBox("Mensaje enviado correctamente", MsgBoxStyle.Information, "Envio mail OK")
        Catch ex As System.Net.Mail.SmtpException
            MsgBox(ex.Message)
        End Try
        SClient.Dispose()
        MMessage.Dispose()
    End Sub

    Public Shared Sub EnviarMailHTML(ByVal pMensajeHtml As String, ByVal pUsuario As String)
        ''''ATENCION: Para que esto funcion, en el caso de GMAIL, la primera vez que intenta mandar un mail, falla con el siguiente error:
        '{"The SMTP server requires a secure connection or the client was not authenticated. The server response was: 5.5.1 Authentication Required. Learn more at"}	System.Net.Mail.SmtpException
        'Adicionalmente, llega un mail de google a la casilla y ahi te da el link para habilitar que aplicaciones se puedan loguear en la cuenta. Si no se puede
        'ingresar con la siguiente url:  security.google.com/settings/security/activity

        'Definicion e instanciacion de la clase MailMessage
        Dim MMessage As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
        'Rellenamos los parametros usuales para el envio de un email
        MMessage.To.Add("sebastianfurche@gmail.com")
        MMessage.From = New MailAddress("veneziasystemsmf@gmail.com", "Venezia System SMF", System.Text.Encoding.UTF8)

        MMessage.Subject = Now.ToString & "- Mensaje de Soporte de " & pUsuario.Trim
        MMessage.SubjectEncoding = System.Text.Encoding.UTF8

        MMessage.Body = pMensajeHtml
        MMessage.IsBodyHtml = True
        'MMessage.BodyEncoding = System.Text.Encoding.UTF8

        'Definimos nuestras credenciales para el unvio de emails a traves de Gmail
        Dim SClient As New SmtpClient()
        SClient.Credentials = New System.Net.NetworkCredential("veneziasystemsmf@gmail.com", "trabajo.1979")
        SClient.Host = "smtp.gmail.com" 'Servidor SMTP de Gmail
        SClient.Port = 587 'Puerto del SMTP de Gmail
        SClient.EnableSsl = True 'Habilita el SSL, necesio en Gmail
        'Capturamos los errores en el envio
        Try
            SClient.Send(MMessage)
            MsgBox("Mensaje enviado correctamente", MsgBoxStyle.Information, "Envio mail OK")
        Catch ex As System.Net.Mail.SmtpException
            MsgBox(ex.Message)
        End Try
        SClient.Dispose()
        MMessage.Dispose()
    End Sub

End Class
