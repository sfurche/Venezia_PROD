Imports System
Imports System.Collections
Imports System.Net
Imports System.Net.Mail
Imports System.Net.Mime
Imports MySql.Data.MySqlClient
Imports VzAdmin

Public Class cEmail

#Region "Declaraciones"

    Private _Id_Mailing As Integer
    Private _Fecha As Date
    Private _Asunto As String
    Private _Para As String
    Private _CC As String
    Private _BCC As String
    Private _Body As String
    Private _Html As Boolean
    Private _Tipo_Mailing As String
    Private _Estado As cEstado

    Private gAdmin As cAdmin

    Public Property Id_Mailing As Integer
        Get
            Return _Id_Mailing
        End Get
        Set(value As Integer)
            _Id_Mailing = value
        End Set
    End Property

    Public Property Fecha As Date
        Get
            Return _Fecha
        End Get
        Set(value As Date)
            _Fecha = value
        End Set
    End Property

    Public Property Para As String
        Get
            Return _Para
        End Get
        Set(value As String)
            _Para = value
        End Set
    End Property

    Public Property CC As String
        Get
            Return _CC
        End Get
        Set(value As String)
            _CC = value
        End Set
    End Property

    Public Property BCC As String
        Get
            Return _BCC
        End Get
        Set(value As String)
            _BCC = value
        End Set
    End Property

    Public Property Body As String
        Get
            Return _Body
        End Get
        Set(value As String)
            _Body = value
        End Set
    End Property

    Public Property Html As Boolean
        Get
            Return _Html
        End Get
        Set(value As Boolean)
            _Html = value
        End Set
    End Property

    Public Property Tipo_Mailing As String
        Get
            Return _Tipo_Mailing
        End Get
        Set(value As String)
            _Tipo_Mailing = value
        End Set
    End Property

    Public Property Estado As cEstado
        Get
            Return _Estado
        End Get
        Set(value As cEstado)
            _Estado = value
        End Set
    End Property

    Public Property Asunto As String
        Get
            Return _Asunto
        End Get
        Set(value As String)
            _Asunto = value
        End Set
    End Property

#End Region

#Region "Functions"

    Public Sub New()

    End Sub

    Public Sub New(ByRef pAdmin As cAdmin)
        gAdmin = pAdmin
    End Sub

    Public Sub Dispose()
        Me.Dispose()
    End Sub

    Public Sub Load(ByVal pDr As DataRow)
        Try
            Me.Id_Mailing = pDr("id_mailing")
            Me.Fecha = pDr("fecha")
            Me.Asunto = pDr("asunto")
            Me.Para = pDr("para")
            Me.CC = pDr("cc")
            Me.BCC = pDr("bcc")
            Me.Body = pDr("body")
            Me.Html = pDr("html")
            Me.Tipo_Mailing = pDr("tipo_mailing")
            Me.Estado = cEstado.GetEstadoxIdTipoEstado(gAdmin, pDr("id_estado"), cEstado.enuTipoEstado.Mailing)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cEmail.Load")
            gLog.fncGrabarLogERR("Error en cEmail.Load:" & ex.Message)
        End Try
    End Sub

    Public Function Guardar() As Boolean

        Guardar = False
        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lCnn As MySqlConnection

        Try
            lCnn = gAdmin.DbCnn.GetInstanceCon

            Sql = "CALL vz_mailing_ins ('#fecha#','#asunto#', '#para#','#cc#','#bcc#', '#body#', #html#,  '#tipo_mailing#',#idusr#)"
            Sql = Sql.Replace("#fecha#", VzAdmin.cFunciones.gFncConvertDateToString(Me.Fecha, "YYYY/MM/DD"))
            Sql = Sql.Replace("#asunto#", Me.Asunto)
            Sql = Sql.Replace("#para#", Me.Para)
            Sql = Sql.Replace("#cc#", Me.CC)
            Sql = Sql.Replace("#bcc#", Me.BCC)
            Sql = Sql.Replace("#body#", Me.Body)
            Sql = Sql.Replace("#html#", Convert.ToInt32(Me.Html))
            Sql = Sql.Replace("#tipo_mailing#", Me.Tipo_Mailing)
            Sql = Sql.Replace("#idusr#", gAdmin.User.Id)

            Cmd.Connection = lCnn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = Sql

            If lCnn.State = ConnectionState.Closed Then
                lCnn.Open()
            End If

            Cmd.ExecuteNonQuery()

            lCnn.Close()

            Guardar = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cEmail.Guardar")
            gAdmin.Log.fncGrabarLogERR("Error en cEmail.Guardar:" & ex.Message)
        End Try
    End Function

    Public Function Enviar() As Boolean
        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lCnn As MySqlConnection
        Dim lStr As String
        Dim lPara As String() = Nothing

        Try

            Dim MMessage As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
            MMessage.SubjectEncoding = System.Text.Encoding.UTF8
            MMessage.From = New MailAddress("veneziasystemsmf@gmail.com", "Venezia System SMF", System.Text.Encoding.UTF8)
            MMessage.Subject = Me.Asunto.Trim

            If Me.Para.Trim.Length > 0 Then
                lPara = Me.Para.Split(";")
                For Each lStr In lPara
                    MMessage.To.Add(lStr)
                Next
            End If

            If Me.CC.Trim.Length > 0 Then
                lPara = Me.CC.Split(";")
                For Each lStr In lPara
                    MMessage.To.Add(lStr)
                Next
            End If

            If Me.BCC.Trim.Length > 0 Then
                lPara = Me.BCC.Split(";")
                For Each lStr In lPara
                    MMessage.To.Add(lStr)
                Next
            End If

            MMessage.IsBodyHtml = Me.Html
            MMessage.Body = Me.Body

            '-----Armo la clase para el envio con los datos del mail sin Proxy
            Dim SClient As New SmtpClient()
            SClient.Credentials = New System.Net.NetworkCredential("veneziasystemsmf@gmail.com", "trabajo.1979")
            SClient.Host = "smtp.gmail.com" 'Servidor SMTP de Gmail
            SClient.Port = 587 'Puerto del SMTP de Gmail
            SClient.EnableSsl = True 'Habilita el SSL, necesio en Gmail

            SClient.Send(MMessage)
            SClient.Dispose()
            MMessage.Dispose()

            '-----------------------------------------------------------------------------------------------
            'Si funciono el envio lo marco como procesado.
            lCnn = gAdmin.DbCnn.GetInstanceCon
            Sql = "CALL vz_mailing_cambest ('#id_mailing#',#id_estado#, #idusr#)"
            Sql = Sql.Replace("#id_mailing#", Me.Id_Mailing)
            Sql = Sql.Replace("#id_estado#", "1")
            Sql = Sql.Replace("#idusr#", gAdmin.User.Id)
            With Cmd
                .Connection = lCnn
                .CommandType = CommandType.Text
                .CommandText = Sql

                If lCnn.State = ConnectionState.Closed Then
                    lCnn.Open()
                End If
                Cmd.ExecuteNonQuery()

                lCnn.Close()
            End With
            '-----------------------------------------------------------------------------------------------

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cEmail.Enviar")
            gAdmin.Log.fncGrabarLogERR("Error en cEmail.Enviar:" & ex.Message)
        End Try

    End Function

#End Region

#Region "Shared Functions"

    Public Shared Function GetMailingxId(ByRef pAdmin As cAdmin, ByVal pId As Integer) As cEmail
        Dim lDt As DataTable
        Dim lDr As DataRow = Nothing
        Dim lMail As cEmail = Nothing
        Try

            lDt = Dat_GetMailingxId(pAdmin, pId)

            For Each lDr In lDt.Rows
                lMail = New cEmail(pAdmin)
                lMail.Load(lDr)
            Next

            Return lMail

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cEmail.GetMailingxId")
            pAdmin.Log.fncGrabarLogERR("Error en cEmail.GetMailingxId:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Function GetMailingxEstado(ByRef pAdmin As cAdmin, ByVal pIdEstado As Integer) As ArrayList
        Dim lDt As DataTable
        Dim lDr As DataRow = Nothing
        Dim lArray As New ArrayList
        Dim lMail As cEmail = Nothing
        Try

            lDt = Dat_GetMailingxEstado(pAdmin, pIdEstado)

            For Each lDr In lDt.Rows
                lMail = New cEmail(pAdmin)
                lMail.Load(lDr)
                lArray.Add(lMail)
            Next

            Return lArray

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cEmail.GetMailingxEstado")
            pAdmin.Log.fncGrabarLogERR("Error en cEmail.GetMailingxEstado:" & ex.Message)
            Return Nothing
        End Try
    End Function

#End Region

#Region "Base de Datos"

    Private Shared Function Dat_GetMailingxId(ByRef pAdmin As VzAdmin.cAdmin, ByVal pId As Integer) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "Select * from vz_mailing where id_mailing=#Id# "
            Sql = Sql.Replace("#Id#", pId)

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

            Return lDt

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cEmail.Dat_GetMailingxId")
            pAdmin.Log.fncGrabarLogERR("Error en cEmail.Dat_GetMailingxId:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Shared Function Dat_GetMailingxEstado(ByRef pAdmin As VzAdmin.cAdmin, ByVal pIdEstado As Integer) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "Select * from vz_mailing where id_estado=#Id# "
            Sql = Sql.Replace("#Id#", pIdEstado)

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

            Return lDt

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cEmail.Dat_GetMailingxEstado")
            pAdmin.Log.fncGrabarLogERR("Error en cEmail.Dat_GetMailingxEstado:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Function Dat_Mailing_Ins() As Boolean

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lCnn As MySqlConnection

        Try
            Dat_Mailing_Ins = False

            lCnn = gAdmin.DbCnn.GetInstanceCon
            Sql = "CALL vz_mailing_ins(#pFec#,'#pAsunto#','#pPara#','#pCC#', '#pBCC#','#pBody#',#pHtml#,'#pTipo#',#idusr#) "

            Sql = Sql.Replace("#pFec#", cFunciones.gFncConvertDateToString(Me.Fecha, "YYYY/MM/DD"))
            Sql = Sql.Replace("#pAsunto#", Me.Asunto)
            Sql = Sql.Replace("#pPara#", Me.Para)
            Sql = Sql.Replace("#pCC#", Me.CC)
            Sql = Sql.Replace("#pBCC#", Me.BCC)
            Sql = Sql.Replace("#pBody#", Me.Body)
            Sql = Sql.Replace("#pHtml#", Me.Html)
            Sql = Sql.Replace("#pTipo#", Me.Tipo_Mailing)
            Sql = Sql.Replace("#idusr#", gAdmin.User.Id)

            With Cmd
                .Connection = lCnn
                .CommandType = CommandType.Text
                .CommandText = Sql

                If lCnn.State = ConnectionState.Closed Then
                    lCnn.Open()
                End If
                Cmd.ExecuteNonQuery()

                lCnn.Close()
            End With

            Dat_Mailing_Ins = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cEmail.Dat_Mailing_Ins")
            gAdmin.Log.fncGrabarLogERR("Error en cEmail.Dat_Mailing_Ins:" & ex.Message)
        End Try
    End Function


#End Region

#Region "Shared Email Functions"

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

#End Region

End Class
