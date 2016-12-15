Imports Microsoft.Reporting.WinForms
Imports VzAdmin
Imports VzComercial
Imports VzTesoreria

Public Class frmTesoOrdenDePagoPorFecha

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
        Dim lProv_Nombre As String
        Dim lOrdenDePago_Estado As String
        Dim lOrden As cOrdenDePago = Nothing
        Dim lFiltros As String = ""


        Try
            lRDLC = "rptTesoOrdenDePagoPorFecha.rdlc"

            If IsNothing(txtProove.Tag) Then
                lProv_Nombre = ""
            Else
                lProv_Nombre = DirectCast(txtProove.Tag, cProveedor).Nombre
            End If


            lOrdenDePago_Estado = cmbEstados.Text

            'If IsNothing(cmbEstados.Text) Then
            '    lOrdenDePago_Estado = ""
            'Else
            '    lOrdenDePago_Estado = DirectCast(, cOrdenDePago).Estado
            'End If

            lDt = cOrdenDePago.Dat_OrdenesDePagoPorFecha(gAdmin, lOrdenDePago_Estado, lProv_Nombre, dtpFechaD.Value, dtpFechaH.Value)

            lBs = New BindingSource
            lBs.DataSource = lDt
            lRds = New ReportDataSource("DataSet1", lBs)
            lArrDS.Add(lRds)

            lRPar = New ReportParameter("pTitulo", "Ordenes de Pago por Fecha")
            lArrayParameters.Add(lRPar)

            lFiltros = "Filtros: (Fecha O.Pago desde " & cFunciones.gFncConvertDateToString(dtpFechaD.Value, "DD/MM/YYYY")
            lFiltros = lFiltros & " hasta " & cFunciones.gFncConvertDateToString(dtpFechaH.Value, "DD/MM/YYYY")
            lFiltros = lFiltros & " y Proveedor = " & lProv_Nombre
            lFiltros = lFiltros & " y Estado = " & lOrdenDePago_Estado
            lFiltros = lFiltros & ")"

            lRPar = New ReportParameter("pFiltros", lFiltros)
            lArrayParameters.Add(lRPar)

            lNombreRpt = "OrdenesPagoPorFecha_" & cFunciones.gFncConvertDateToString(Date.Today, "YYYY/MM/DD")

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

            DirectCast(Me.MdiParent, frmPrincipal).SubArirReporteBase(lArrDS, lArrayParameters, lRDLC, lPrintSettings, "Reporte Ordenes de Pago por Fecha", lNombreRpt)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoOrdenDePagoPorFecha.btnGenerar_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoOrdenDePagoPorFecha.btnGenerar_Click" & ex.Message)
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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoOrdenDePagoPorFecha.txtProove_LostFocus")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoOrdenDePagoPorFecha.txtProove_LostFocus:" & ex.Message)
        End Try
    End Sub

    Public Sub SetProveedor(ByVal pProove As cProveedor)
        Try
            lblNomProove.Text = pProove.Nombre
            txtProove.Text = pProove.Id_Proveedor
            txtProove.Tag = pProove
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoOrdenDePagoPorFecha.SetCliente")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoOrdenDePagoPorFecha.SetCliente:" & ex.Message)
        End Try
    End Sub

    Private Sub btnBusq_Click(sender As Object, e As EventArgs) Handles btnBusq.Click
        Try
            DirectCast(Me.MdiParent, frmPrincipal).SubAbrirConsulta(cAdmin.EnuOBJETOS.Proveedores, Me)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoOrdenDePagoPorFecha.btnBusq_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoOrdenDePagoPorFecha.btnBusq_Click:" & ex.Message)
        End Try
    End Sub

    Private Sub frmTesoChkRptxProv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Me.Tag = "CONSULTAORDENESDEPAGOPORFECHA"
            subCargarEstados()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoOrdenDePagoPorFecha.frmTesoChkRptxProv_Load")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoOrdenDePagoPorFecha.frmTesoOrdenDePagoPorFecha_Load:" & ex.Message)
        End Try

    End Sub

    Private Sub subCargarEstados()
        Dim lArray As ArrayList
        Dim lEstado As cEstado = Nothing
        Try
            cmbEstados.Items.Clear()

            lArray = cEstado.GetEstadoAllxTipoEstado(gAdmin, cEstado.enuTipoEstado.Orden_De_Pago)

            cmbEstados.Items.Add(" ")
            For Each lEstado In lArray
                cmbEstados.Items.Add(lEstado)
            Next
            cmbEstados.DisplayMember = "Estado"
            cmbEstados.SelectedItem = " "

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoChkConsulta.subCargarEstados")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoChkConsulta.subCargarEstados:" & ex.Message)
        End Try
    End Sub

End Class
