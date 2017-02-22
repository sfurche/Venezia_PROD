Imports Microsoft.Reporting.WinForms
Imports VzTesoreria
Imports VzAdmin


Public Class frmTesoChkRptEnCartera

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub frmTesoChkRptEnCartera_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            '----------------------------------P-E-R-M-I-S-O-S---------------------------------------------------
            SetPermisos()
            '---------------------------------------------------------------------------------------------------

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            dtpFvtoD.Value = Date.Today
            dtpFvtoH.Value = DateAdd(DateInterval.Month, 1, Date.Today)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoChkRptEnCartera.btnSalir_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoChkRptEnCartera.btnSalir_Click" & ex.Message)
        End Try
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub SetPermisos()
        Dim lPermiso As cPermiso = Nothing
        Try

            lPermiso = gAdmin.User.GetPermiso("TESO_CHQ_RPT: Cheques en Cartera")

            If lPermiso.Admin = cPermiso.enuBinario.Si Then
                Exit Sub
            End If

            If Not (lPermiso.Admin = cPermiso.enuBinario.Si Or lPermiso.Consulta = cPermiso.enuBinario.Si) Then
                MsgBox("No tiene permisos para acceder a esta opcion.", vbExclamation, "Acceso denegado")
                Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoChkRptEnCartera.SetPermisos")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoChkRptEnCartera.SetPermisos:" & ex.Message)
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

            lRDLC = "rptTesoLiqChequesCartera.rdlc"


            lDt = cCheque.Dat_RptChequesFDFHEstado(gAdmin, "N", dtpFvtoD.Value, dtpFvtoH.Value, Date.MinValue, Date.MaxValue, 0)


            lBs = New BindingSource
            lBs.DataSource = lDt
            lRds = New ReportDataSource("DataSet1", lBs)
            lArrDS.Add(lRds)

            lRPar = New ReportParameter("pTitulo", "Reporte de Cheques en Cartera")
            lArrayParameters.Add(lRPar)

            lRPar = New ReportParameter("pFiltros", "Filtros: (Fecha Vto " & cFunciones.gFncConvertDateToString(dtpFvtoD.Value, "DD/MM/YYYY") & " hasta " & cFunciones.gFncConvertDateToString(dtpFvtoH.Value, "DD/MM/YYYY") & ")")
            lArrayParameters.Add(lRPar)

            lNombreRpt = "Cheques_Cartera_Vto_" & cFunciones.gFncConvertDateToString(dtpFvtoD.Value, "YYYY/MM/DD") & "-" & cFunciones.gFncConvertDateToString(dtpFvtoH.Value, "YYYY/MM/DD")

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

            DirectCast(Me.MdiParent, frmPrincipal).SubArirReporteBase(lArrDS, lArrayParameters, lRDLC, lPrintSettings, "Reporte de Cheques en Cartera - Vto " & gFncConvertDateToString(dtpFvtoD.Value, "DD/MM/YYYY") & " a " & gFncConvertDateToString(dtpFvtoH.Value, "DD/MM/YYYY"), lNombreRpt)


            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Catch ex As Exception
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoChkRptEnCartera.btnGenerar_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoChkRptEnCartera.btnGenerar_Click" & ex.Message)
        End Try
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class