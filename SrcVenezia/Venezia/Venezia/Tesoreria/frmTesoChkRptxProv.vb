Imports Microsoft.Reporting.WinForms
Imports VzTesoreria
Imports VzAdmin
Imports VzComercial

Public Class frmTesoChkRptxProv
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
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
        Dim lProv As cProveedor = Nothing
        Dim lFiltros As String = ""

        Try
            lRDLC = "rptTesoChkxProvFOPDH.rdlc"

            If IsNothing(txtProove.Tag) Then
                MsgBox("Debe seleccionar el Proveedor.", MsgBoxStyle.Exclamation, "Error de validacion")
                Exit Sub
            End If

            lProv = DirectCast(txtProove.Tag, cProveedor)

            lDt = cCheque.Dat_RptChequesxDestProvFOrP(gAdmin, dtpFechaOpD.Value, dtpFechaOpH.Value, lProv.Id_Proveedor)

            lBs = New BindingSource
            lBs.DataSource = lDt
            lRds = New ReportDataSource("DataSet1", lBs)
            lArrDS.Add(lRds)

            lRPar = New ReportParameter("pTitulo", "CHEQUES POR PROVEEDOR")
            lArrayParameters.Add(lRPar)

            lFiltros = "Filtros: (Fecha O.Pago desde " & cFunciones.gFncConvertDateToString(dtpFechaOpD.Value, "DD/MM/YYYY")
            lFiltros = lFiltros & " hasta " & cFunciones.gFncConvertDateToString(dtpFechaOpH.Value, "DD/MM/YYYY")
            lFiltros = lFiltros & " y Proveedor = " & lProv.Nombre
            lFiltros = lFiltros & ")"

            lRPar = New ReportParameter("pFiltros",lfiltros)
            lArrayParameters.Add(lRPar)

            lNombreRpt = "ChequesxProveed_" & cFunciones.gFncConvertDateToString(Date.Today, "YYYY/MM/DD")

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

            DirectCast(Me.MdiParent, frmPrincipal).SubArirReporteBase(lArrDS, lArrayParameters, lRDLC, lPrintSettings, "Reporte Cheques por Proveedor", lNombreRpt)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoChkRptxProv.btnGenerar_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoChkRptxProv.btnGenerar_Click" & ex.Message)
        End Try
    End Sub

    Private Sub txtProove_LostFocus(sender As Object, e As EventArgs) Handles txtProove.LostFocus
        Dim pProove As cProveedor = Nothing
        Try
            If Not txtProove.Text.Trim = "" Then
                pProove = cProveedor.GetProveedorxNro(gAdmin, txtProove.Text.Trim)
                If Not IsNothing(pProove) Then
                    SetProveedor(pProove)
                Else
                    txtProove.Text = ""
                    lblNomProove.Text = "_____________"
                    txtProove.Tag = Nothing
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoChkRptxProv.txtProove_LostFocus")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoChkRptxProv.txtProove_LostFocus:" & ex.Message)
        End Try
    End Sub

    Public Sub SetProveedor(ByVal pProove As cProveedor)
        Try
            lblNomProove.Text = pProove.Nombre
            txtProove.Text = pProove.Id_Proveedor
            txtProove.Tag = pProove
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoChkRptxProv.SetCliente")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoChkRptxProv.SetCliente:" & ex.Message)
        End Try
    End Sub

    Private Sub btnBusq_Click(sender As Object, e As EventArgs) Handles btnBusq.Click
        Try
            DirectCast(Me.MdiParent, frmPrincipal).SubAbrirConsulta(cAdmin.EnuOBJETOS.Proveedores, Me)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoChkRptxProv.btnBusq_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoChkRptxProv.btnBusq_Click:" & ex.Message)
        End Try
    End Sub

    Private Sub frmTesoChkRptxProv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Me.Tag = "TESOCHKRPTXPROV"

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoChkRptxProv.frmTesoChkRptxProv_Load")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoChkRptxProv.frmTesoChkRptxProv_Load:" & ex.Message)
        End Try

    End Sub
End Class
