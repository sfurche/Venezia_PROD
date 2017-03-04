Imports Microsoft.Reporting.WinForms
Imports VzAdmin
Imports VzTesoreria

Public Class frmTesoChkRankingxCliente

    Private Sub frmTesoChkRankingxCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            '----------------------------------P-E-R-M-I-S-O-S---------------------------------------------------
            SetPermisos()
            '---------------------------------------------------------------------------------------------------

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoChkRankingxCliente.frmTesoChkRankingxCliente_Load")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoChkRankingxCliente.frmTesoChkRankingxCliente_Load:" & ex.Message)
        End Try
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub SetPermisos()
        Dim lPermiso As cPermiso = Nothing
        Try

            lPermiso = gAdmin.User.GetPermiso("TESO_CHQ_RPT: Ranking de Cheques x Cliente")

            If lPermiso.Admin = cPermiso.enuBinario.Si Then
                Exit Sub
            End If

            If Not (lPermiso.Consulta = cPermiso.enuBinario.Si Or lPermiso.Ejecuta = cPermiso.enuBinario.Si) Then
                MsgBox("No tiene permisos para acceder a esta opcion.", vbExclamation, "Acceso denegado")
                Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoChkRankingxCliente.SetPermisos")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoChkRankingxCliente.SetPermisos:" & ex.Message)
        End Try
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click

        Dim lDt As DataTable
        Dim lBs As BindingSource = Nothing
        Dim lArrDS As New ArrayList
        Dim lArrayParameters As New ArrayList
        Dim lRds As ReportDataSource = Nothing
        Dim lRPar As ReportParameter = Nothing
        Dim lPrintSettings As New System.Drawing.Printing.PageSettings
        Dim lRDLC As String
        Dim lNombreRpt As String = ""

        Try
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            lRDLC = "rptTesoChkRankingxCliente.rdlc"

            lDt = cCheque.Dat_RptChequesRankingxCliente(gAdmin)

            lBs = New BindingSource
            lBs.DataSource = lDt
            lRds = New ReportDataSource("DataSet1", lBs)
            lArrDS.Add(lRds)

            lRPar = New ReportParameter("pTitulo", "Ranking de Cheques en Cartera x Cliente")
            lArrayParameters.Add(lRPar)

            lRPar = New ReportParameter("pFiltros", "")
            lArrayParameters.Add(lRPar)

            lNombreRpt = "Ranking_Cheques_CarteraxCli_al_" & cFunciones.gFncConvertDateToString(Date.Today, "YYYY/MM/DD")

            'A4  	 8.3in x 11.7in 210 × 297mm
            'Letter  8.5in x 11in	216 x 279mm
            'Legal   8.5in x 14in	216 x 356mm

            'Seteo la configuracion de impresion.
            lPrintSettings.Margins.Top = 10
            lPrintSettings.Margins.Bottom = 10
            lPrintSettings.Margins.Right = 10
            lPrintSettings.Margins.Left = 10
            lPrintSettings.Landscape = False
            Dim lSize As New System.Drawing.Printing.PaperSize
            lSize.RawKind = System.Drawing.Printing.PaperKind.Letter
            lSize.Width = 850
            lSize.Height = 1100
            lPrintSettings.PaperSize = lSize

            DirectCast(Me.MdiParent, frmPrincipal).SubArirReporteBase(lArrDS, lArrayParameters, lRDLC, lPrintSettings, "Ranking de Cheques en Cartera x Cliente- al " & gFncConvertDateToString(Date.Today, "DD/MM/YYYY"), lNombreRpt)

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoChkRankingxCliente.btnGenerar_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoChkRankingxCliente.btnGenerar_Click" & ex.Message)
        End Try
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub
End Class