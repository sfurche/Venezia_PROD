Imports VzAdmin
Imports VzComercial
Imports VzTesoreria

Public Class frmTesoOrdenDePagoConsulta

    Private Sub frmTesoOrdenDePagoConsulta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Tag = "CONSULTAORDENESDEPAGO"

            SubSetCabecera()
            SubCargarCombos()

            subCargarGrilla()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoOrdenDePagoConsulta.frmTesoOrdenDePagoConsulta_Load")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoOrdenDePagoConsulta.frmTesoOrdenDePagoConsulta_Load:" & ex.Message)
        End Try
    End Sub

    Private Sub SubCargarCombos()
        Try

            cmbDestino.Items.Add("Cobro")
            cmbDestino.Items.Add("Deposito")
            cmbDestino.Items.Add("Proveedores")
            cmbDestino.Items.Add("Retiro")
            cmbDestino.Items.Add("Otro")
            cmbDestino.Items.Add(" ")
            cmbDestino.SelectedItem = " "

            subCargarEstados()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoOrdenDePagoConsulta.CargarCombos")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoOrdenDePagoConsulta.CargarCombos:" & ex.Message)
        End Try
    End Sub

    Private Sub SubSetCabecera()
        Try
            lvwConsulta.BeginUpdate()
            lvwConsulta.Clear()

            lvwConsulta.Columns.Add(New ColHeader("Id_Orden", 70, HorizontalAlignment.Right, True))
            lvwConsulta.Columns.Add(New ColHeader("Fecha", 80, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("Destino", 100, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("Total", 80, HorizontalAlignment.Right, True))
            lvwConsulta.Columns.Add(New ColHeader("Efectivo", 80, HorizontalAlignment.Right, True))
            lvwConsulta.Columns.Add(New ColHeader("Cheques", 80, HorizontalAlignment.Right, True))
            lvwConsulta.Columns.Add(New ColHeader("Transf.", 80, HorizontalAlignment.Right, True))
            lvwConsulta.Columns.Add(New ColHeader("Estado", 80, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("Proveedor", 200, HorizontalAlignment.Left, True))
            lvwConsulta.Columns.Add(New ColHeader("Observaciones", 400, HorizontalAlignment.Left, True))

            ' Connect the ListView.ColumnClick event to the ColumnClick event handler.
            AddHandler Me.lvwConsulta.ColumnClick, AddressOf lvwConsulta_ColumnClick

            lvwConsulta.EndUpdate()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoOrdenDePagoConsulta.SubSetCabecera")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoOrdenDePagoConsulta.SubSetCabecera:" & ex.Message)
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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoOrdenDePagoConsulta.lvwConsulta_ColumnClick")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoOrdenDePagoConsulta.lvwConsulta_ColumnClick:" & ex.Message)
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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoOrdenDePagoConsulta.txtCliente_LostFocus")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoOrdenDePagoConsulta.txtCliente_LostFocus:" & ex.Message)
        End Try
    End Sub

    Public Sub SetProveedor(ByVal pProove As cProveedor)
        Try
            lblNomProove.Text = pProove.Nombre
            txtProove.Text = pProove.Id_Proveedor
            txtProove.Tag = pProove
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoOrdenDePagoConsulta.SetCliente")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoOrdenDePagoConsulta.SetCliente:" & ex.Message)
        End Try
    End Sub

    Private Sub subCargarGrilla()
        Dim lItem As ListViewItem
        Dim lArray As ArrayList = Nothing
        Dim lSum As Decimal = 0
        Dim lIdEstado As Integer = 99
        Dim lIdBanco As Integer = 0
        Dim lOrden As cOrdenDePago = Nothing
        Try
            'VALIDACIONES
            If Not txtIdOrden.Text.Trim = "" Then
                If Not IsNumeric(txtIdOrden.Text.Trim) Then
                    MsgBox("El Id Orden debe ser numerico", MsgBoxStyle.Exclamation, "Error de validacion")
                    Exit Sub
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

            lArray = cOrdenDePago.GetOrdenDePagoConsulta(gAdmin _
           , IIf(txtIdOrden.Text.Trim = "", 0, txtIdOrden.Text.Trim) _
            , IIf(txtIdOrden.Text.Trim = "", dtpFechaD.Value, Date.MinValue) _
            , IIf(txtIdOrden.Text.Trim = "", dtpFechaD.Value, Date.MaxValue) _
            , IIf(cmbDestino.SelectedItem = " ", " ", cOrdenDePago.enuTipoDestinoOrdenPagoGetCodxStr(cmbDestino.Text)) _
            , IIf(txtProove.Text = "", 0, txtProove.Text) _
            , lIdEstado _
            , " ")

            If Not IsNothing(lArray) Then

                For Each lOrden In lArray
                    lItem = New ListViewItem()
                    lItem.Text = lOrden.Id_Orden
                    lItem.SubItems.Add(cFunciones.gFncConvertDateToString(lOrden.Fecha, "DD/MM/YYYY"))
                    lItem.SubItems.Add(cOrdenDePago.enuTipoDestinoOrdenPagoGetStrxEnu(lOrden.Tipo_Destino))
                    lItem.SubItems.Add("$" & lOrden.Total)
                    lItem.SubItems.Add("$" & lOrden.Importe_cash)
                    lItem.SubItems.Add("$" & lOrden.Importe_cheques)
                    lItem.SubItems.Add("$" & lOrden.Importe_transferencia)
                    lItem.SubItems.Add(lOrden.Estado.Estado)
                    If Not IsNothing(lOrden.Proveedor) Then
                        lItem.SubItems.Add(lOrden.Proveedor.Nombre)
                    Else
                        lItem.SubItems.Add(" ")
                    End If
                    lItem.SubItems.Add(lOrden.Observaciones)
                    lItem.Tag = lOrden
                    lvwConsulta.Items.Add(lItem)
                    lSum = lSum + lOrden.Total
                Next

                lblTotal.Text = "$ " & lSum

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoChkConsulta.subCargarGrilla")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoChkConsulta.subCargarGrilla:" & ex.Message)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnBusq_Click(sender As Object, e As EventArgs) Handles btnBusq.Click
        Try
            DirectCast(Me.MdiParent, frmPrincipal).SubAbrirConsulta(cAdmin.EnuOBJETOS.Proveedores, Me)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoOrdenDePagoAlta.btnBusq_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoOrdenDePagoAlta.btnBusq_Click:" & ex.Message)
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

    Private Sub btnAplicar_Click(sender As Object, e As EventArgs) Handles btnAplicar.Click
        Try
            subCargarGrilla()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoChkConsulta.subCargarEstados")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoChkConsulta.subCargarEstados:" & ex.Message)
        End Try
    End Sub

    Private Sub lvwConsulta_DoubleClick(sender As Object, e As EventArgs) Handles lvwConsulta.DoubleClick
        Dim lModo As FrmBase.EnuOPERACION = EnuOPERACION.MODIF
        Try
            If lvwConsulta.SelectedItems.Count = 0 Then
                Exit Sub
            End If
            Dim lOP As cOrdenDePago = DirectCast(lvwConsulta.SelectedItems(0).Tag, cOrdenDePago)

            If lOP.Estado.Id_Estado = 0 Then
                lModo = EnuOPERACION.MODIF
            End If
            If lOP.Fecha < Date.Today Then 'Es una orden de pago historica
                lModo = EnuOPERACION.CONS
            End If
            DirectCast(MdiParent, frmPrincipal).SubArirOrdenDePago(DirectCast(lvwConsulta.SelectedItems(0).Tag, cOrdenDePago), Me, lModo)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error en frmTesoLiquidacionesCons.btnAbrir_Click")
        End Try
    End Sub

End Class