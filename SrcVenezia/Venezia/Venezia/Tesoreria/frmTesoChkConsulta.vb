Imports Microsoft.Reporting.WinForms
Imports VzAdmin
Imports VzComercial
Imports VzTesoreria

Public Class frmTesoChkConsulta
    Public gLlamaDesdeOrdenDePago As Boolean = False

    Private Sub frmTesoChkConsulta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Tag = "CONSULTADECHQUES"

            SubCargarCombos()
            If gLlamaDesdeOrdenDePago = True Then
                cmbEstados.Text = "Cartera"
                cmbEstados.Enabled = False
            End If

            subCargarGrilla()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoChkConsulta.frmTesoLiqConciliacion_Load")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoChkConsulta.frmTesoLiqConciliacion_Load:" & ex.Message)
        End Try
    End Sub

    Private Sub SubSetCabecera()
        Try
            lvwConsulta.BeginUpdate()
            lvwConsulta.Clear()

            lvwConsulta.Columns.Add(New ColHeader("X", 50, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("NroCheque", 80, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("Importe", 80, HorizontalAlignment.Right, True))
            lvwConsulta.Columns.Add(New ColHeader("Fec_Pago", 100, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("Banco", 250, HorizontalAlignment.Left, True))
            lvwConsulta.Columns.Add(New ColHeader("Cruzado", 70, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("Directo", 70, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("Orden", 70, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("Vto", 80, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("Estado", 80, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("Cliente", 100, HorizontalAlignment.Left, True))
            lvwConsulta.Columns.Add(New ColHeader("OrdenP", 100, HorizontalAlignment.Left, True))

            ' Connect the ListView.ColumnClick event to the ColumnClick event handler.
            AddHandler Me.lvwConsulta.ColumnClick, AddressOf lvwConsulta_ColumnClick

            lvwConsulta.EndUpdate()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoChkConsulta.SubSetCabecera")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoChkConsulta.SubSetCabecera:" & ex.Message)
        End Try
    End Sub

    Private Sub subCargarGrilla()
        Dim lItem As ListViewItem
        Dim lChk As cCheque
        Dim lArray As ArrayList = Nothing
        Dim lSumChk As Decimal = 0
        Dim lIdEstado As Integer = 99
        Dim lIdBanco As Integer = 0
        Try
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            'VALIDACIONES
            If Not txtNroCheque.Text.Trim = "" Then
                If Not IsNumeric(txtNroCheque.Text.Trim) Then
                    MsgBox("El nro de cheque debe ser numerico", MsgBoxStyle.Exclamation, "Error de validacion")
                    Exit Sub
                End If
            End If

            If Not IsNothing(cmbBanco.SelectedItem) Then
                If cmbBanco.SelectedItem.ToString = " " Then
                    lIdBanco = 0
                Else
                    lIdBanco = DirectCast(cmbBanco.SelectedItem, cBanco).Id_Banco
                End If
            End If

            If Not IsNothing(cmbEstados.SelectedItem) Then
                If cmbEstados.SelectedItem.ToString = " " Then
                    lIdEstado = 99
                Else
                    lIdEstado = DirectCast(cmbEstados.SelectedItem, cEstado).Id_Estado
                End If

            End If

            lblTotal.Text = "$ 0"

            SubSetCabecera()

            lArray = cCheque.GetChequesConsulta(gAdmin _
            , IIf(txtNroCheque.Text.Trim = "", " ", txtNroCheque.Text.Trim) _
            , "N" _
            , IIf(txtNroCheque.Text.Trim = "", dtpFPagoD.Value, Date.MinValue) _
            , IIf(txtNroCheque.Text.Trim = "", dtpFPagoH.Value, Date.MaxValue) _
            , lIdEstado _
            , lIdBanco _
            , IIf(cmbDirecto.SelectedItem = " ", " ", cmbDirecto.SelectedItem) _
            , IIf(cmbOrden.SelectedItem = " ", " ", cmbOrden.SelectedItem) _
            , IIf(cmbCruzado.SelectedItem = "", " ", cmbCruzado.SelectedItem) _
            , IIf(txtCliente.Text.Trim = "", " ", txtCliente.Text.Trim))

            If Not IsNothing(lArray) Then

                For Each lChk In lArray
                    lItem = New ListViewItem()
                    lItem.Text = lChk.Id_Cheque
                    lItem.SubItems.Add(lChk.Numero)
                    lItem.SubItems.Add("$" & lChk.Importe.ToString)
                    lItem.SubItems.Add(cFunciones.gFncConvertDateToString(lChk.Fecha_Pago, "DD/MM/YYYY"))
                    lItem.SubItems.Add(lChk.Banco.Nombre)
                    lItem.SubItems.Add(lChk.Cruzado.ToString)
                    lItem.SubItems.Add(lChk.Directo.ToString)
                    lItem.SubItems.Add(lChk.Orden.ToString)
                    lItem.SubItems.Add(cFunciones.gFncConvertDateToString(lChk.Fecha_Vencimiento.ToShortDateString, "DD/MM/YYYY"))
                    lItem.SubItems.Add(lChk.Estado.Estado)
                    lItem.SubItems.Add(lChk.NroCli)
                    lItem.SubItems.Add(IIf(lChk.Id_Orden = 0, " ", lChk.Id_Orden))
                    lItem.Tag = lChk
                    lvwConsulta.Items.Add(lItem)
                    lSumChk = lSumChk + lChk.Importe
                Next

                lblTotal.Text = "$ " & lSumChk

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoChkConsulta.subCargarGrilla")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoChkConsulta.subCargarGrilla:" & ex.Message)
        End Try
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub


    Public Sub SubCargarCombos()
        Try
            cmbCruzado.Items.Add(" ")
            cmbCruzado.Items.Add("S")
            cmbCruzado.Items.Add("N")
            cmbCruzado.SelectedItem = " "

            cmbDirecto.Items.Add(" ")
            cmbDirecto.Items.Add("S")
            cmbDirecto.Items.Add("N")
            cmbDirecto.SelectedItem = " "

            cmbOrden.Items.Add(" ")
            cmbOrden.Items.Add("S")
            cmbOrden.Items.Add("N")
            cmbOrden.SelectedItem = " "

            subCargarEstados()
            subCargarBancos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoChkConsulta.CargarCombos")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoChkConsulta.CargarCombos:" & ex.Message)
        End Try
    End Sub

    Private Sub subCargarBancos()
        Dim lArrayBancos As ArrayList
        Dim lBanco As cBanco = Nothing
        Try
            cmbBanco.Items.Clear()

            lArrayBancos = cBanco.Banco_GetAll(gAdmin)

            cmbBanco.Items.Add(" ")
            For Each lBanco In lArrayBancos
                cmbBanco.Items.Add(lBanco)
            Next
            cmbBanco.DisplayMember = "NombreRed"
            cmbBanco.SelectedItem = " "

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoChkConsulta.subCargarBancos")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoChkConsulta.subCargarBancos:" & ex.Message)
        End Try
    End Sub

    Private Sub subCargarEstados()
        Dim lArray As ArrayList
        Dim lEstado As cEstado = Nothing
        Try
            cmbEstados.Items.Clear()

            lArray = cEstado.GetEstadoAllxTipoEstado(gAdmin, cEstado.enuTipoEstado.Cheque)

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

    Private Sub lvwConsulta_ColumnClick(ByVal sender As Object, ByVal e As ColumnClickEventArgs)
        Try

            If e.Column = 0 Then 'Si es la columna X es solo para el check , cancelo el reordenamiento.
                Exit Sub
            End If

            ' Create an instance of the ColHeader class. 
            Dim clickedCol As ColHeader = CType(Me.lvwConsulta.Columns(e.Column), ColHeader)

            ' Set the ascending property to sort in the opposite order.
            clickedCol.ascending = Not clickedCol.ascending

            ' Get the number of items in the list.
            Dim numItems As Integer = Me.lvwConsulta.Items.Count

            ' Turn off display while data is repoplulated.
            Me.lvwConsulta.BeginUpdate()

            ' Populate an ArrayList with a SortWrapper of each list item.
            Dim SortArray As New ArrayList
            Dim i As Integer
            For i = 0 To numItems - 1
                SortArray.Add(New SortWrapper(Me.lvwConsulta.Items(i), e.Column))
            Next i

            ' Sort the elements in the ArrayList using a new instance of the SortComparer
            ' class. The parameters are the starting index, the length of the range to sort,
            ' and the IComparer implementation to use for comparing elements. Note that
            ' the IComparer implementation (SortComparer) requires the sort  
            ' direction for its constructor; true if ascending, othwise false.
            SortArray.Sort(0, SortArray.Count, New SortWrapper.SortComparer(clickedCol.ascending))

            ' Clear the list, and repopulate with the sorted items.
            Me.lvwConsulta.Items.Clear()
            Dim z As Integer
            For z = 0 To numItems - 1
                Me.lvwConsulta.Items.Add(CType(SortArray(z), SortWrapper).sortItem)
            Next z
            ' Turn display back on.
            Me.lvwConsulta.EndUpdate()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoChkConsulta.lvwConsulta_ColumnClick")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoChkConsulta.lvwConsulta_ColumnClick:" & ex.Message)
        End Try

    End Sub

    Private Sub btnAplicar_Click(sender As Object, e As EventArgs) Handles btnAplicar.Click
        Try

            subCargarGrilla()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoChkConsulta.btnAplicar_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoChkConsulta.btnAplicar_Click:" & ex.Message)
        End Try
    End Sub

    Private Sub txtCliente_LostFocus(sender As Object, e As EventArgs) Handles txtCliente.LostFocus
        Dim lCliente As cCliente = Nothing
        Try
            If Not txtCliente.Text.Trim = "" Then
                lCliente = cCliente.GetClientexNroCliente(gAdmin, txtCliente.Text.Trim)
                If Not IsNothing(lCliente) Then
                    SetCliente(lCliente)
                Else
                    txtCliente.Text = ""
                    lblNomCliente.Text = "_____________"
                    txtCliente.Tag = Nothing
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoChkConsulta.txtCliente_LostFocus")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoChkConsulta.txtCliente_LostFocus:" & ex.Message)
        End Try
    End Sub

    Public Sub SetCliente(ByVal pCliente As cCliente)
        Try
            lblNomCliente.Text = pCliente.Nombre
            txtCliente.Text = pCliente.NroCli
            txtCliente.Tag = pCliente
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoChkConsulta.SetCliente")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoChkConsulta.SetCliente:" & ex.Message)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Try
            Dim lDt As DataTable
            Dim lBs As BindingSource = Nothing
            Dim lArrDS As New ArrayList
            Dim lArrayParameters As New ArrayList
            Dim lRds As ReportDataSource = Nothing
            Dim lRPar As ReportParameter = Nothing
            Dim lPrintSettings As New System.Drawing.Printing.PageSettings
            Dim lRDLC As String
            Dim lNombreRpt As String = ""
            Dim lArrayCheques As ArrayList = Nothing
            Dim lItem As ListViewItem = Nothing


            lRDLC = "rptTesoLiqChequesCartera.rdlc"

            If lvwConsulta.Items.Count > 0 Then
                lArrayCheques = New ArrayList
                For Each lItem In lvwConsulta.Items
                    lArrayCheques.Add(DirectCast(lItem.Tag, cCheque))
                Next
            End If

            lDt = cCheque.Dat_RptChequesxArrayCheques(gAdmin, lArrayCheques)

            lBs = New BindingSource
            lBs.DataSource = lDt
            lRds = New ReportDataSource("DataSet1", lBs)
            lArrDS.Add(lRds)

            lRPar = New ReportParameter("pTitulo", "Reporte de Cheques exportados de Consulta")
            lArrayParameters.Add(lRPar)

            lRPar = New ReportParameter("pFiltros", "")
            lArrayParameters.Add(lRPar)

            lNombreRpt = "Cheques_Exportados"

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

            DirectCast(Me.MdiParent, frmPrincipal).SubArirReporteBase(lArrDS, lArrayParameters, lRDLC, lPrintSettings, "Reporte de Cheques x consulta", lNombreRpt)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoChkConsulta.btnExportar_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoChkConsulta.btnExportar_Click:" & ex.Message)
        End Try
    End Sub

    Private Sub btnBusq_Click(sender As Object, e As EventArgs) Handles btnBusq.Click
        Try
            DirectCast(Me.MdiParent, frmPrincipal).SubAbrirConsulta(cAdmin.EnuOBJETOS.Cliente, Me)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesAlta.btnBusq_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesAlta.btnBusq_Click:" & ex.Message)
        End Try
    End Sub

    Private Sub btnGenOrdenPago_Click(sender As Object, e As EventArgs) Handles btnGenOrdenPago.Click
        Dim Ventana As frmTesoOrdenDePagoAlta
        Dim lArray As ArrayList = Nothing
        Dim lItem As ListViewItem = Nothing

        Try
            If lvwConsulta.CheckedItems.Count = 0 Then
                MsgBox("No hay cheques seleccionados.", MsgBoxStyle.Exclamation, "Sin datos")
                Exit Sub
            Else
                lArray = New ArrayList
                For Each lItem In lvwConsulta.CheckedItems
                    If Not DirectCast(lItem.Tag, cCheque).Estado.Id_Estado = 0 Then
                        MsgBox("Solo puede gestanar cheques en estado 'En Cartera'", MsgBoxStyle.Exclamation, "Cheques Invalidos")
                    Else
                        lArray.Add(lItem.Tag)
                    End If
                Next
            End If

            If Me.gLlamaDesdeOrdenDePago = True Then  'Valido si es llamado desde el alta/modificacion de uan orden de pago.
                Ventana = Me.FrmLlamador
                Ventana.AgregarCheques(lArray)
            Else
                'Abro la consulta de cheques para la busqueda.
                Dim lPpal As frmPrincipal = Me.MdiParent

                Dim F As Form
                Dim i As Integer
                Ventana = New frmTesoOrdenDePagoAlta
                Ventana.Text = "Buscar Cheques"
                For i = 0 To lPpal.MdiChildren.Length - 1
                    F = lPpal.MdiChildren.GetValue(i)
                    If F.GetType Is Ventana.GetType Then
                        If F.Text = Ventana.Text Then
                            F.WindowState = FormWindowState.Normal
                            F.Focus()
                            Exit Sub
                        End If
                    End If
                Next
                Ventana.MdiParent = lPpal
                Ventana.FrmLlamador = Me.MdiParent
                Ventana.TipoDeOperacion = FrmBase.EnuOPERACION.ALTA
                Ventana.Show()
                Ventana.AgregarCheques(lArray)

            End If
            Me.Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesAlta.btnGenOrdenPago_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesAlta.btnGenOrdenPago_Click:" & ex.Message)
        End Try

    End Sub

End Class