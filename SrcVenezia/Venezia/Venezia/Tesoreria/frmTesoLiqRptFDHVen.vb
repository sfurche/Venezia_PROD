Imports Microsoft.Reporting.WinForms
Imports VzAdmin
Imports VzComercial
Imports VzTesoreria

Public Class frmTesoLiqRptFDHVen
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
        Dim lVen As cVendedor = Nothing
        Dim lEstado As cEstado = Nothing
        Dim lIDVendedor As Integer = 0
        Dim lIdEstado As Integer = 98

        Try
            'lRDLC = "rptTesoLiqRendDiariaVal.rdlc"
            lRDLC = "rptTesoLiqHistFDHVenEst.rdlc"

            If cmbVendedores.SelectedItem.GetType().ToString() = "VzComercial.cVendedor" Then
                lVen = cmbVendedores.SelectedItem()
                lIDVendedor = lVen.IdVendedor
            Else
                lIDVendedor = 0
            End If

            If cmbEstados.SelectedItem.GetType().ToString() = "VzAdmin.cEstado" Then
                lEstado = cmbEstados.SelectedItem()
                lIdEstado = lEstado.Id_Estado
            Else
                lIdEstado = 98
            End If

            lDt = cLiquidacion.Dat_RptLiqFDFHVen(gAdmin, dtpFechaLiqD.Value, dtpFechaLiqH.Value, lIDVendedor, lIdEstado)

            lBs = New BindingSource
            lBs.DataSource = lDt
            lRds = New ReportDataSource("DataSet1", lBs)
            lArrDS.Add(lRds)

            lRPar = New ReportParameter("pTitulo", "Reporte de Liquidaciones Historicas")
            lArrayParameters.Add(lRPar)

            lRPar = New ReportParameter("pFiltros", "Filtros: (Fecha Desde " & cFunciones.gFncConvertDateToString(dtpFechaLiqD.Value, "DD/MM/YYYY") & " hasta " & cFunciones.gFncConvertDateToString(dtpFechaLiqH.Value, "DD/MM/YYYY") & ")")
            lArrayParameters.Add(lRPar)

            lNombreRpt = "Liquidaciones_" & cFunciones.gFncConvertDateToString(dtpFechaLiqD.Value, "YYYY/MM/DD") & "-" & cFunciones.gFncConvertDateToString(dtpFechaLiqH.Value, "YYYY/MM/DD")

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
            lSize.Width = 550
            lSize.Height = 800
            lPrintSettings.PaperSize = lSize

            DirectCast(Me.MdiParent, frmPrincipal).SubArirReporteBase(lArrDS, lArrayParameters, lRDLC, lPrintSettings, "Reporte de Rendicion Diaria de Valores - " & gFncConvertDateToString(dtpFechaLiqD.Value, "DD/MM/YYYY"), lNombreRpt)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiqRptFDHVen.btnGenerar_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiqRptFDHVen.btnGenerar_Click" & ex.Message)
        End Try
    End Sub

    Private Sub frmTesoLiqRptFDHVen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dtpFechaLiqD.Value = Date.Today
            dtpFechaLiqH.Value = Date.Today

            subCargarVendedores()
            subCargarEstados()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiqRptFDHVen.frmTesoLiqRptFDHVen_Load")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiqRptFDHVen.frmTesoLiqRptFDHVen_Load" & ex.Message)
        End Try

    End Sub

    Private Sub subCargarVendedores()
        Dim lArrayVend As ArrayList
        Dim lVendedor As cVendedor = Nothing
        Try
            cmbVendedores.Items.Clear()

            lArrayVend = cVendedor.GetVendedoresAll(gAdmin)

            For Each lVendedor In lArrayVend
                cmbVendedores.Items.Add(lVendedor)
            Next

            cmbVendedores.DisplayMember = "Nombre"

            cmbVendedores.Items.Add("TODOS")
            cmbVendedores.SelectedItem = "TODOS"

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiqRptFDHVen.subCargarVendedores")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiqRptFDHVen.subCargarVendedores:" & ex.Message)
        End Try

    End Sub

    Private Sub subCargarEstados()
        Dim lArray As ArrayList
        Dim lEstado As cEstado = Nothing
        Try
            cmbEstados.Items.Clear()

            lArray = cEstado.GetEstadoAllxTipoEstado(gAdmin, cEstado.enuTipoEstado.Liquidacion)

            For Each lEstado In lArray
                cmbEstados.Items.Add(lEstado)
            Next
            cmbEstados.DisplayMember = "Estado"

            cmbEstados.Items.Add("TODOS")
            cmbEstados.SelectedItem = "TODOS"

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiqRptFDHVen.subCargarEstados")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiqRptFDHVen.subCargarEstados:" & ex.Message)
        End Try
    End Sub

End Class