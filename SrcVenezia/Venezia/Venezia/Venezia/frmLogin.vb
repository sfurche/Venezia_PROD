Public Class frmLogin
    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

#Region "Declaraciones"
    Dim _FrmPpal As frmPrincipal
    Public WriteOnly Property FrmPpal() As frmPrincipal
        Set(ByVal Value As frmPrincipal)
            _FrmPpal = Value
        End Set
    End Property
#End Region

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If fncValidarLogin(UsernameTextBox.Text.Trim, PasswordTextBox.Text.Trim) = True Then
            _FrmPpal.subStatusUpdate("User", gAdmin.User.Usuario.Trim())
            _FrmPpal.Show()
            Me.Close()
        Else
            MsgBox("Usuario o password incorrecto", MsgBoxStyle.Critical, "Login Incorrecto")
            PasswordTextBox.Text = ""
        End If

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        _FrmPpal.Close()
    End Sub


    Private Sub UsernameTextBox_KeyUp(sender As Object, e As KeyEventArgs) Handles UsernameTextBox.KeyUp
        Select Case e.KeyCode
            Case Keys.Enter
                OK_Click(sender, e)
            Case Keys.Escape
                _FrmPpal.Close()
        End Select
    End Sub

    Private Sub PasswordTextBox_KeyUp(sender As Object, e As KeyEventArgs) Handles PasswordTextBox.KeyUp
        Select Case e.KeyCode
            Case Keys.Enter
                OK_Click(sender, e)
            Case Keys.Escape
                _FrmPpal.Close()
        End Select
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _FrmPpal.Hide()

        If Not Debugger.IsAttached Then
            UsernameTextBox.Text = ""
            PasswordTextBox.Text = ""
        Else
            UsernameTextBox.Text = "sebastian"
            PasswordTextBox.Text = "furche.1"
        End If
    End Sub

    Private Function fncValidarLogin(ByVal pUser As String, ByVal pPwd As String) As Boolean
        fncValidarLogin = False
        Try
            fncValidarLogin = gAdmin.User.Validar(pUser, pPwd)
            'MsgBox(gAdmin.User.Pwd.Trim())

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmLogin.fncValidarLogin")
            'gLog.fncGrabarLorERR("Error en frmLogin.fncValidarLogin:" & ex.Message)
        End Try

    End Function
End Class
