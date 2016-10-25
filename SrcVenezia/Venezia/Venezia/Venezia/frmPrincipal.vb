Imports Microsoft.Win32
Imports VzTesoreria

Public Class frmPrincipal
    'Inherits System.Windows.Forms.Form
#Region "FUNCIONES ABRIR"

    Public Sub SubArirLiquidacion(ByRef pLiquidacion As cLiquidacion, ByRef pFrmLlamador As FrmBase, ByVal pModo As FrmBase.EnuOPERACION)
        Dim Ventana As New frmTesoLiquidacionesAlta
        Dim F As Form
        Dim i As Integer
        Try
            Ventana.Text = "Liquidacion " & pLiquidacion.Id_Liquidacion.ToString
            For i = 0 To Me.MdiChildren.Length - 1
                F = Me.MdiChildren.GetValue(i)
                If F.GetType Is Ventana.GetType Then
                    If F.Text = Ventana.Text Then
                        F.WindowState = FormWindowState.Normal
                        F.Focus()
                        Exit Sub
                    End If
                End If
            Next
            Ventana.MdiParent = Me
            Ventana.FrmLlamador = pFrmLlamador
            Ventana.TipoDeOperacion = pModo
            Ventana.mLiq = pLiquidacion
            Ventana.Show()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "FrmPrincipal.SubArirLiquidacion")
            gAdmin.Log.fncGrabarLogERR("Error en frmPrincipal.SubArirLiquidacion:" & ex.Message)
        End Try
    End Sub

    Public Sub SubArirOrdenDePago(ByRef pOrdenDePago As cOrdenDePago, ByRef pFrmLlamador As TemplateForm, ByVal pModo As FrmBase.EnuOPERACION)
        Dim Ventana As New frmTesoOrdenDePagoAlta
        Dim F As Form
        Dim i As Integer
        Try
            Ventana.Text = "Orden de Pago " & pOrdenDePago.Id_Orden.ToString
            For i = 0 To Me.MdiChildren.Length - 1
                F = Me.MdiChildren.GetValue(i)
                If F.GetType Is Ventana.GetType Then
                    If F.Text = Ventana.Text Then
                        F.WindowState = FormWindowState.Normal
                        F.Focus()
                        Exit Sub
                    End If
                End If
            Next
            Ventana.MdiParent = Me
            Ventana.FrmLlamador = pFrmLlamador
            Ventana.TipoDeOperacion = pModo
            Ventana.mOrdenDePago = pOrdenDePago
            Ventana.Show()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "FrmPrincipal.SubArirOrdenDePago")
            gAdmin.Log.fncGrabarLogERR("Error en frmPrincipal.SubArirOrdenDePago:" & ex.Message)
        End Try
    End Sub

    Public Sub SubArirReporteBase(ByVal pArrDataSources As ArrayList, ByVal pArrParameters As ArrayList, ByVal pRDLCPath As String, ByVal pPageSettings As System.Drawing.Printing.PageSettings, ByVal pNombreVentana As String, ByVal pRptName As String)
        Dim Ventana As New frmReporteBase
        Dim F As Form
        Dim i As Integer
        Try
            Ventana.Text = pNombreVentana.Trim
            For i = 0 To Me.MdiChildren.Length - 1
                F = Me.MdiChildren.GetValue(i)
                If F.GetType Is Ventana.GetType Then
                    If F.Text = Ventana.Text Then
                        F.WindowState = FormWindowState.Normal
                        F.Focus()
                        Exit Sub
                    End If
                End If
            Next
            Ventana.MdiParent = Me
            Ventana.FrmLlamador = Me
            Ventana.TipoDeOperacion = FrmBase.EnuOPERACION.CONS

            Ventana.mArrDataSources = pArrDataSources
            Ventana.mArrParameters = pArrParameters
            Ventana.mRDLCPath = pRDLCPath
            Ventana.mPageSettings = pPageSettings
            Ventana.mRptName = pRptName.Trim

            Ventana.Show()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "FrmPrincipal.SubArirReporteBase")
            gAdmin.Log.fncGrabarLogERR("Error en frmPrincipal.SubArirReporteBase:" & ex.Message)
        End Try

    End Sub

#End Region

    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Ventana As New frmLogin
        Dim lSetting As VzAdmin.cSetting
        Dim lPath As String = ""
        Try
            SetFondoPantalla()
            If Not StartUp() Then
                MsgBox("No se puede iniciar la aplicacion por un error conexion a la BD.", MsgBoxStyle.Critical, "Error de conxion DB")
                End
            End If
            Me.Hide()
            Ventana.FrmPpal = Me
            Ventana.ShowDialog()
            Me.StTxtVersion.Text = My.Application.Info.Version.ToString

            'Valido la version del la app y de la bd
            lSetting = VzAdmin.cSetting.GetSettingxCodigo(gAdmin, "AppVersion")
            If Not My.Application.Info.Version.ToString.Trim = lSetting.Valor.Trim Then
                MsgBox("Hay una nueva version disponible(" & lSetting.Valor.Trim & "). Actualice el aplicativo y vuelva a ingresar.", MsgBoxStyle.Information, "Version " & My.Application.Info.Version.ToString.Trim & " desactualizada.")

                If MsgBox("Desea actualizar la version ahora?", vbYesNo + MsgBoxStyle.Question, "Actualizar") = MsgBoxResult.Yes Then
                    lPath = My.Settings.AutoUpdatePath
                    System.Diagnostics.Process.Start(lPath)
                    End
                End If
                End
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "FrmPrincipal_Load")
            'gLog.fncGrabarLorERR("Error en FrmPrincipal_Load: " & ex.Message)
        End Try
    End Sub

    Public Function StartUp() As Boolean
        StartUp = False
        Try

            gAdmin = New VzAdmin.cAdmin(My.Settings.DBCnn_Srv, My.Settings.DBCnn_DBName, My.Settings.DBCnn_DBPort)
            StartUp = gAdmin.DbCnn.TestConnection

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "FrmPrincipal_SetDBConnection")
            gAdmin.Log.fncGrabarLogERR("Error en FrmPrincipal_SetDBConnection:" & ex.Message)
        End Try
    End Function

    Public Sub SetFondoPantalla()
        Dim vPath As String
        Dim vSizeMode As Integer

        Try
            Dim regKey As RegistryKey
            regKey = Application.UserAppDataRegistry
            vPath = CType(regKey.GetValue("Background", ""), String)

            If Not vPath = "" Then
                vSizeMode = Integer.Parse(gFncGetValorFondo_Registry("BackGrSizeMode"))

                Dim ima As New System.Drawing.Bitmap(vPath)
                Dim imasized As New System.Drawing.Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height)

                Dim gr As Graphics = Graphics.FromImage(imasized)

                gr.DrawImage(ima, 0, 0, imasized.Width + 1, imasized.Height + 1)
                Me.BackgroundImage = imasized
            Else
                Me.BackgroundImage = Nothing
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error cargando el fondo de pantalla")
        End Try
    End Sub

    Public Sub subStatusUpdate(ByVal pTipo As String, ByVal pValor As String)
        If pTipo = "User" Then
            StTxtUser.Text = pValor
        End If
    End Sub

    Private Sub CalculadoraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalculadoraToolStripMenuItem.Click
        Try
            Dim lProceso As New System.Diagnostics.Process
            lProceso.StartInfo.FileName = "calc.exe"
            lProceso.StartInfo.Arguments = ""

            lProceso.Start()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "MnuCalculadora_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmPrincipal.MnuCalculadora_Click:" & ex.Message)
        End Try
    End Sub

    Private Sub FondosDePantallaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FondosDePantallaToolStripMenuItem.Click
        Dim Ventana As New frmFondoPantalla
        Dim F As Form
        Dim i As Integer
        Dim Cant As Integer = 0
        Try
            For i = 0 To Me.MdiChildren.Length - 1
                F = Me.MdiChildren.GetValue(i)
                If F.GetType Is Ventana.GetType Then
                    If F.Text = Ventana.Text Then
                        F.WindowState = FormWindowState.Normal
                        F.Focus()
                        Exit Sub
                    End If
                End If
            Next
            Ventana.MdiParent = Me
            If Cant > 0 Then
                Ventana.Text = Ventana.Text & " " & Cant
            End If
            Ventana.TipoDeOperacion = FrmBase.EnuOPERACION.MODIF
            Ventana.Show()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmPrincipal.MnuFondoPantalla_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmPrincipal.MnuFondoPantalla_Click:" & ex.Message)
        End Try
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        End
    End Sub

    Private Sub tbtnSalir_Click(sender As Object, e As EventArgs) Handles tbtnSalir.Click
        End
    End Sub

    Public Sub SubAbrirConsulta(ByVal pTipo As VzAdmin.cAdmin.EnuOBJETOS, ByRef pFrmLlamador As TemplateForm)
        Dim Ventana As New frmConsultas
        Dim F As Form
        Dim i As Integer
        Try
            Ventana.Text = "Consulta - " & CStr(pFrmLlamador.Text)
            For i = 0 To Me.MdiChildren.Length - 1
                F = Me.MdiChildren.GetValue(i)
                If F.GetType Is Ventana.GetType Then
                    If F.Text = Ventana.Text Then
                        F.WindowState = FormWindowState.Normal
                        F.Focus()
                        Exit Sub
                    End If
                End If
            Next
            Ventana.MdiParent = Me
            Ventana.FrmLlamador = pFrmLlamador
            Ventana.TipoDeOperacion = FrmBase.EnuOPERACION.CONS
            Ventana.pTipoObjeto = pTipo
            Ventana.Show()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmPrincipal.SubAbrirConsulta")
            gAdmin.Log.fncGrabarLogERR("Error en frmPrincipal.SubAbrirConsulta:" & ex.Message)
        End Try

    End Sub

    Private Sub AcercaDeVeneziaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AcercaDeVeneziaToolStripMenuItem.Click
        Dim Ventana As New frmSplashScreen
        Dim F As Form
        Dim i As Integer
        Dim Cant As Integer = 0
        Try
            For i = 0 To Me.MdiChildren.Length - 1
                F = Me.MdiChildren.GetValue(i)
                If F.GetType Is Ventana.GetType Then
                    If F.Text = Ventana.Text Then
                        F.WindowState = FormWindowState.Normal
                        F.Focus()
                        Exit Sub
                    End If
                End If
            Next
            Ventana.MdiParent = Me
            If Cant > 0 Then
                Ventana.Text = Ventana.Text & " " & Cant
            End If
            Ventana.Show()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmPrincipal.MnuFondoPantalla_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmPrincipal.MnuFondoPantalla_Click:" & ex.Message)
        End Try
    End Sub

    Private Sub NuevaLiquidacionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevaLiquidacionToolStripMenuItem.Click
        Dim Ventana As New frmTesoLiquidacionesAlta

        Dim F As Form
        Dim i As Integer
        Dim Cant As Integer = 0
        Try
            For i = 0 To Me.MdiChildren.Length - 1
                F = Me.MdiChildren.GetValue(i)
                If F.GetType Is Ventana.GetType Then
                    If F.Text = Ventana.Text Then
                        F.WindowState = FormWindowState.Normal
                        F.Focus()
                        Exit Sub
                    End If
                End If
            Next
            Ventana.MdiParent = Me
            If Cant > 0 Then
                Ventana.Text = Ventana.Text & " " & Cant
            End If
            Ventana.TipoDeOperacion = EnuOPERACION.ALTA

            Ventana.Show()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmPrincipal.NuevaLiquidacionToolStripMenuItem_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmPrincipal.NuevaLiquidacionToolStripMenuItem_Click:" & ex.Message)
        End Try
    End Sub

    Private Sub ConsultaDeLiquidacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaDeLiquidacionesToolStripMenuItem.Click
        Dim Ventana As New frmTesoLiquidacionesCons

        Dim F As Form
        Dim i As Integer
        Dim Cant As Integer = 0
        Try
            For i = 0 To Me.MdiChildren.Length - 1
                F = Me.MdiChildren.GetValue(i)
                If F.GetType Is Ventana.GetType Then
                    If F.Text = Ventana.Text Then
                        F.WindowState = FormWindowState.Normal
                        F.Focus()
                        Exit Sub
                    End If
                End If
            Next
            Ventana.MdiParent = Me
            If Cant > 0 Then
                Ventana.Text = Ventana.Text & " " & Cant
            End If
            Ventana.TipoDeOperacion = EnuOPERACION.CONS
            Ventana.Show()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmPrincipal.ConsultaDeLiquidacionesToolStripMenuItem_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmPrincipal.ConsultaDeLiquidacionesToolStripMenuItem_Click:" & ex.Message)
        End Try
    End Sub

    Private Sub ConsultaDeVendedoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaDeVendedoresToolStripMenuItem.Click
        Dim Ventana As New frmComVendedoresCons

        Dim F As Form
        Dim i As Integer
        Dim Cant As Integer = 0
        Try
            For i = 0 To Me.MdiChildren.Length - 1
                F = Me.MdiChildren.GetValue(i)
                If F.GetType Is Ventana.GetType Then
                    If F.Text = Ventana.Text Then
                        F.WindowState = FormWindowState.Normal
                        F.Focus()
                        Exit Sub
                    End If
                End If
            Next
            Ventana.MdiParent = Me
            If Cant > 0 Then
                Ventana.Text = Ventana.Text & " " & Cant
            End If
            Ventana.TipoDeOperacion = EnuOPERACION.CONS
            Ventana.Show()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmPrincipal.ConsultaDeVendedoresToolStripMenuItem_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmPrincipal.ConsultaDeVendedoresToolStripMenuItem_Click:" & ex.Message)
        End Try
    End Sub

    Private Sub LiquidacionDiariaDeValoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LiquidacionDiariaDeValoresToolStripMenuItem.Click
        Dim Ventana As New frmTesoLiqRptRendicionDiariaValores

        Dim F As Form
        Dim i As Integer
        Dim Cant As Integer = 0
        Try
            For i = 0 To Me.MdiChildren.Length - 1
                F = Me.MdiChildren.GetValue(i)
                If F.GetType Is Ventana.GetType Then
                    If F.Text = Ventana.Text Then
                        F.WindowState = FormWindowState.Normal
                        F.Focus()
                        Exit Sub
                    End If
                End If
            Next
            Ventana.MdiParent = Me
            If Cant > 0 Then
                Ventana.Text = Ventana.Text & "" & Cant
            End If
            Ventana.TipoDeOperacion = EnuOPERACION.CONS
            Ventana.Show()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmPrincipal.LiquidacionDiariaDeValoresToolStripMenuItem_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmPrincipal.LiquidacionDiariaDeValoresToolStripMenuItem_Click:" & ex.Message)
        End Try
    End Sub

    Private Sub NuevaLiquidacionAtlaRapdiaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevaLiquidacionAtlaRapdiaToolStripMenuItem.Click
        Dim Ventana As New frmTesoLiquidacionesAltaRapida

        Dim F As Form
        Dim i As Integer
        Dim Cant As Integer = 0
        Try
            For i = 0 To Me.MdiChildren.Length - 1
                F = Me.MdiChildren.GetValue(i)
                If F.GetType Is Ventana.GetType Then
                    If F.Text = Ventana.Text Then
                        F.WindowState = FormWindowState.Normal
                        F.Focus()
                        Exit Sub
                    End If
                End If
            Next
            Ventana.MdiParent = Me
            If Cant > 0 Then
                Ventana.Text = Ventana.Text & " " & Cant
            End If
            Ventana.TipoDeOperacion = EnuOPERACION.ALTA

            Ventana.Show()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmPrincipal.NuevaLiquidacionAtlaRapdiaToolStripMenuItem_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmPrincipal.NuevaLiquidacionAtlaRapdiaToolStripMenuItem_Click:" & ex.Message)
        End Try
    End Sub

    Private Sub EnviarMailASoporteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnviarMailASoporteToolStripMenuItem.Click
        Dim Ventana As New frmMailSoporte

        Dim F As Form
        Dim i As Integer
        Dim Cant As Integer = 0
        Try
            For i = 0 To Me.MdiChildren.Length - 1
                F = Me.MdiChildren.GetValue(i)
                If F.GetType Is Ventana.GetType Then
                    If F.Text = Ventana.Text Then
                        F.WindowState = FormWindowState.Normal
                        F.Focus()
                        Exit Sub
                    End If
                End If
            Next
            Ventana.MdiParent = Me
            If Cant > 0 Then
                Ventana.Text = Ventana.Text & " " & Cant
            End If
            Ventana.TipoDeOperacion = EnuOPERACION.ALTA

            Ventana.Show()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmPrincipal.EnviarMailASoporteToolStripMenuItem_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmPrincipal.EnviarMailASoporteToolStripMenuItem_Click:" & ex.Message)
        End Try
    End Sub

    Private Sub ChequesEnCarteraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChequesEnCarteraToolStripMenuItem.Click

        Dim Ventana As New frmTesoChkRptEnCartera

        Dim F As Form
        Dim i As Integer
        Dim Cant As Integer = 0
        Try
            For i = 0 To Me.MdiChildren.Length - 1
                F = Me.MdiChildren.GetValue(i)
                If F.GetType Is Ventana.GetType Then
                    If F.Text = Ventana.Text Then
                        F.WindowState = FormWindowState.Normal
                        F.Focus()
                        Exit Sub
                    End If
                End If
            Next
            Ventana.MdiParent = Me
            If Cant > 0 Then
                Ventana.Text = Ventana.Text & "" & Cant
            End If
            Ventana.TipoDeOperacion = EnuOPERACION.CONS
            Ventana.Show()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmPrincipal.ChequesEnCarteraToolStripMenuItem_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmPrincipal.ChequesEnCarteraToolStripMenuItem_Click:" & ex.Message)
        End Try

    End Sub

    Private Sub ChequesXFechaDeEmisionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChequesXFechaDeEmisionToolStripMenuItem.Click
        MsgBox("No tiene permisos para ingresar a esta opcion.", MsgBoxStyle.Exclamation)
    End Sub

    Private Sub ConciliacionDeLiquidacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConciliacionDeLiquidacionesToolStripMenuItem.Click
        Dim Ventana As New frmTesoLiqConciliacion

        Dim F As Form
        Dim i As Integer
        Dim Cant As Integer = 0

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Try
            For i = 0 To Me.MdiChildren.Length - 1
                F = Me.MdiChildren.GetValue(i)
                If F.GetType Is Ventana.GetType Then
                    If F.Text = Ventana.Text Then
                        F.WindowState = FormWindowState.Normal
                        F.Focus()
                        Exit Sub
                    End If
                End If
            Next
            Ventana.MdiParent = Me
            If Cant > 0 Then
                Ventana.Text = Ventana.Text & "" & Cant
            End If
            Ventana.TipoDeOperacion = EnuOPERACION.CONS
            Ventana.Show()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmPrincipal.ConciliacionDeLiquidacionesToolStripMenuItem_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmPrincipal.ConciliacionDeLiquidacionesToolStripMenuItem_Click:" & ex.Message)
        End Try
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub LiquidacionesHisotiricasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LiquidacionesHisotiricasToolStripMenuItem.Click
        Dim Ventana As New frmTesoLiqRptFDHVen

        Dim F As Form
        Dim i As Integer
        Dim Cant As Integer = 0
        Try
            For i = 0 To Me.MdiChildren.Length - 1
                F = Me.MdiChildren.GetValue(i)
                If F.GetType Is Ventana.GetType Then
                    If F.Text = Ventana.Text Then
                        F.WindowState = FormWindowState.Normal
                        F.Focus()
                        Exit Sub
                    End If
                End If
            Next
            Ventana.MdiParent = Me
            If Cant > 0 Then
                Ventana.Text = Ventana.Text & "" & Cant
            End If
            Ventana.TipoDeOperacion = EnuOPERACION.CONS
            Ventana.Show()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmPrincipal.LiquidacionesHisotiricasToolStripMenuItem_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmPrincipal.LiquidacionesHisotiricasToolStripMenuItem_Click:" & ex.Message)
        End Try

    End Sub

    Private Sub AnularConciliacionDeLiquidacionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularConciliacionDeLiquidacionToolStripMenuItem.Click
        Dim Ventana As New frmTesoLiqConciliacionAnular
        Dim F As Form
        Dim i As Integer
        Dim Cant As Integer = 0
        Try
            For i = 0 To Me.MdiChildren.Length - 1
                F = Me.MdiChildren.GetValue(i)
                If F.GetType Is Ventana.GetType Then
                    If F.Text = Ventana.Text Then
                        F.WindowState = FormWindowState.Normal
                        F.Focus()
                        Exit Sub
                    End If
                End If
            Next
            Ventana.MdiParent = Me
            If Cant > 0 Then
                Ventana.Text = Ventana.Text & "" & Cant
            End If
            Ventana.TipoDeOperacion = EnuOPERACION.ALTA
            Ventana.Show()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmPrincipal.AnularConciliacionDeLiquidacionToolStripMenuItem_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmPrincipal.AnularConciliacionDeLiquidacionToolStripMenuItem_Click:" & ex.Message)
        End Try
    End Sub

    Private Sub VariablesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VariablesToolStripMenuItem.Click
        Dim Ventana As New frmConfiguracion
        Dim F As Form
        Dim i As Integer
        Dim Cant As Integer = 0
        Try
            For i = 0 To Me.MdiChildren.Length - 1
                F = Me.MdiChildren.GetValue(i)
                If F.GetType Is Ventana.GetType Then
                    If F.Text = Ventana.Text Then
                        F.WindowState = FormWindowState.Normal
                        F.Focus()
                        Exit Sub
                    End If
                End If
            Next
            Ventana.MdiParent = Me
            If Cant > 0 Then
                Ventana.Text = Ventana.Text & "" & Cant
            End If
            Ventana.TipoDeOperacion = EnuOPERACION.ALTA
            Ventana.Show()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmPrincipal.VariablesToolStripMenuItem_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmPrincipal.VariablesToolStripMenuItem_Click:" & ex.Message)
        End Try
    End Sub

    Private Sub ConsultaDeChequesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaDeChequesToolStripMenuItem.Click
        Dim Ventana As New frmTesoChkConsulta
        Dim F As Form
        Dim i As Integer
        Dim Cant As Integer = 0
        Try
            For i = 0 To Me.MdiChildren.Length - 1
                F = Me.MdiChildren.GetValue(i)
                If F.GetType Is Ventana.GetType Then
                    If F.Text = Ventana.Text Then
                        F.WindowState = FormWindowState.Normal
                        F.Focus()
                        Exit Sub
                    End If
                End If
            Next
            Ventana.MdiParent = Me
            If Cant > 0 Then
                Ventana.Text = Ventana.Text & "" & Cant
            End If
            Ventana.TipoDeOperacion = EnuOPERACION.CONS
            Ventana.Show()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmPrincipal.ConsultaDeChequesToolStripMenuItem_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmPrincipal.ConsultaDeChequesToolStripMenuItem_Click:" & ex.Message)
        End Try
    End Sub

    Private Sub GestionarChequeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GestionarChequeToolStripMenuItem.Click
        MsgBox("No tiene permisos para ingresar a esta opcion.", MsgBoxStyle.Exclamation)
    End Sub

    Private Sub SeguridadToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SeguridadToolStripMenuItem1.Click
        MsgBox("No tiene permisos para ingresar a esta opcion.", MsgBoxStyle.Exclamation)
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        EnviarMailASoporteToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub ConsultaDeProveedoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaDeProveedoresToolStripMenuItem.Click
        Dim Ventana As New frmComProveedoresConsulta
        Dim F As Form
        Dim i As Integer
        Dim Cant As Integer = 0
        Try
            For i = 0 To Me.MdiChildren.Length - 1
                F = Me.MdiChildren.GetValue(i)
                If F.GetType Is Ventana.GetType Then
                    If F.Text = Ventana.Text Then
                        F.WindowState = FormWindowState.Normal
                        F.Focus()
                        Exit Sub
                    End If
                End If
            Next
            Ventana.MdiParent = Me
            If Cant > 0 Then
                Ventana.Text = Ventana.Text & "" & Cant
            End If
            Ventana.TipoDeOperacion = EnuOPERACION.CONS
            Ventana.Show()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmPrincipal.ConsultaDeProveedoresToolStripMenuItem_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmPrincipal.ConsultaDeProveedoresToolStripMenuItem_Click:" & ex.Message)
        End Try
    End Sub

    Private Sub AltaOrdenDePagoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AltaOrdenDePagoToolStripMenuItem.Click
        Dim Ventana As New frmTesoOrdenDePagoAlta
        Dim F As Form
        Dim i As Integer
        Dim Cant As Integer = 0
        Try
            For i = 0 To Me.MdiChildren.Length - 1
                F = Me.MdiChildren.GetValue(i)
                If F.GetType Is Ventana.GetType Then
                    If F.Text = Ventana.Text Then
                        F.WindowState = FormWindowState.Normal
                        F.Focus()
                        Exit Sub
                    End If
                End If
            Next
            Ventana.MdiParent = Me
            If Cant > 0 Then
                Ventana.Text = Ventana.Text & "" & Cant
            End If
            Ventana.TipoDeOperacion = EnuOPERACION.ALTA
            Ventana.Show()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmPrincipal.AltaOrdenDePagoToolStripMenuItem_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmPrincipal.AltaOrdenDePagoToolStripMenuItem_Click:" & ex.Message)
        End Try
    End Sub

    Private Sub ConsultaOrdenesDePagoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaOrdenesDePagoToolStripMenuItem.Click
        Dim Ventana As New frmTesoOrdenDePagoConsulta
        Dim F As Form
        Dim i As Integer
        Dim Cant As Integer = 0
        Try
            For i = 0 To Me.MdiChildren.Length - 1
                F = Me.MdiChildren.GetValue(i)
                If F.GetType Is Ventana.GetType Then
                    If F.Text = Ventana.Text Then
                        F.WindowState = FormWindowState.Normal
                        F.Focus()
                        Exit Sub
                    End If
                End If
            Next
            Ventana.MdiParent = Me
            If Cant > 0 Then
                Ventana.Text = Ventana.Text & "" & Cant
            End If
            Ventana.TipoDeOperacion = EnuOPERACION.CONS
            Ventana.Show()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmPrincipal.ConsultaOrdenesDePagoToolStripMenuItem_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmPrincipal.ConsultaOrdenesDePagoToolStripMenuItem_Click:" & ex.Message)
        End Try
    End Sub

    Private Sub ComprobanteDeOrdenDePagoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComprobanteDeOrdenDePagoToolStripMenuItem.Click
        MsgBox("No tiene permisos para ingresar a esta opcion.", MsgBoxStyle.Exclamation)
    End Sub

    Private Sub OrdenesDePagoXFechaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrdenesDePagoXFechaToolStripMenuItem.Click
        MsgBox("No tiene permisos para ingresar a esta opcion.", MsgBoxStyle.Exclamation)
    End Sub

    Private Sub ChequesXProveedorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChequesXProveedorToolStripMenuItem.Click
        Dim Ventana As New frmTesoChkRptxProv
        Dim F As Form
        Dim i As Integer
        Dim Cant As Integer = 0
        Try
            For i = 0 To Me.MdiChildren.Length - 1
                F = Me.MdiChildren.GetValue(i)
                If F.GetType Is Ventana.GetType Then
                    If F.Text = Ventana.Text Then
                        F.WindowState = FormWindowState.Normal
                        F.Focus()
                        Exit Sub
                    End If
                End If
            Next
            Ventana.MdiParent = Me
            If Cant > 0 Then
                Ventana.Text = Ventana.Text & "" & Cant
            End If
            Ventana.TipoDeOperacion = EnuOPERACION.CONS
            Ventana.Show()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmPrincipal.ChequesXProveedorToolStripMenuItem_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmPrincipal.ChequesXProveedorToolStripMenuItem_Click:" & ex.Message)
        End Try
    End Sub

    Private Sub ActualizarVeneziaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualizarVeneziaToolStripMenuItem.Click
        Dim lPath As String = ""
        Try
            If MsgBox("Esta seguro que desea actualizar la version?", vbYesNo + MsgBoxStyle.Question, "Actualizar") = MsgBoxResult.Yes Then
                lPath = My.Settings.AutoUpdatePath
                System.Diagnostics.Process.Start(lPath)
                End
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmPrincipal.ActualizarVeneziaToolStripMenuItem_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmPrincipal.ActualizarVeneziaToolStripMenuItem_Click:" & ex.Message)
        End Try
    End Sub

    Private Sub ConsultaDeArticulosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaDeArticulosToolStripMenuItem.Click
        Dim Ventana As New frmStkArticulosCons
        Dim F As Form
        Dim i As Integer
        Dim Cant As Integer = 0
        Try
            For i = 0 To Me.MdiChildren.Length - 1
                F = Me.MdiChildren.GetValue(i)
                If F.GetType Is Ventana.GetType Then
                    If F.Text = Ventana.Text Then
                        F.WindowState = FormWindowState.Normal
                        F.Focus()
                        Exit Sub
                    End If
                End If
            Next
            Ventana.MdiParent = Me
            If Cant > 0 Then
                Ventana.Text = Ventana.Text & "" & Cant
            End If
            Ventana.TipoDeOperacion = EnuOPERACION.CONS
            Ventana.Show()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmPrincipal.ConsultaDeArticulosToolStripMenuItem_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmPrincipal.ConsultaDeArticulosToolStripMenuItem_Click:" & ex.Message)
        End Try
    End Sub

    Private Sub ConsultaDePreciosXListaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaDePreciosXListaToolStripMenuItem.Click
        Dim Ventana As New frmStkPreciosConsxLista
        Dim F As Form
        Dim i As Integer
        Dim Cant As Integer = 0
        Try
            For i = 0 To Me.MdiChildren.Length - 1
                F = Me.MdiChildren.GetValue(i)
                If F.GetType Is Ventana.GetType Then
                    If F.Text = Ventana.Text Then
                        F.WindowState = FormWindowState.Normal
                        F.Focus()
                        Exit Sub
                    End If
                End If
            Next
            Ventana.MdiParent = Me
            If Cant > 0 Then
                Ventana.Text = Ventana.Text & "" & Cant
            End If
            Ventana.TipoDeOperacion = EnuOPERACION.CONS
            Ventana.Show()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmPrincipal.ConsultaDePreciosXListaToolStripMenuItem_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmPrincipal.ConsultaDePreciosXListaToolStripMenuItem_Click:" & ex.Message)
        End Try
    End Sub

    Private Sub ConsultaDeListasDePrecioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaDeListasDePrecioToolStripMenuItem.Click
        Dim Ventana As New frmStkListasDePrecioCons
        Dim F As Form
        Dim i As Integer
        Dim Cant As Integer = 0
        Try
            For i = 0 To Me.MdiChildren.Length - 1
                F = Me.MdiChildren.GetValue(i)
                If F.GetType Is Ventana.GetType Then
                    If F.Text = Ventana.Text Then
                        F.WindowState = FormWindowState.Normal
                        F.Focus()
                        Exit Sub
                    End If
                End If
            Next
            Ventana.MdiParent = Me
            If Cant > 0 Then
                Ventana.Text = Ventana.Text & "" & Cant
            End If
            Ventana.TipoDeOperacion = EnuOPERACION.CONS
            Ventana.Show()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmPrincipal.ConsultaDeListasDePrecioToolStripMenuItem_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmPrincipal.ConsultaDeListasDePrecioToolStripMenuItem_Click:" & ex.Message)
        End Try
    End Sub

End Class