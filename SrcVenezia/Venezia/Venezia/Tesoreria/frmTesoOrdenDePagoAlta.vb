Imports VzAdmin
Imports VzComercial
Imports VzTesoreria

Public Class frmTesoOrdenDePagoAlta
    Public mOrdenDePago As cOrdenDePago = Nothing

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub frmTesoOrdenDePagoAlta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Me.Tag = "ALTAORDENDEPAGO"
            SubCargarCombos()
            SubSetCabecera()

            If Me.TipoDeOperacion = EnuOPERACION.ALTA Then
                dtpFecha.Value = Date.Today
            ElseIf Me.TipoDeOperacion = EnuOPERACION.MODIF Then
                subCargarDatos()
            ElseIf Me.TipoDeOperacion = EnuOPERACION.CONS Then
                subCargarDatos()
                SubSetReadOnly()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoOrdenDePagoAlta.frmTesoOrdenDePagoAlta_Load")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoOrdenDePagoAlta.frmTesoOrdenDePagoAlta_Load:" & ex.Message)
        End Try
    End Sub

    Private Sub SubSetReadOnly()
        Try
            dtpFecha.Enabled = False
            txtObservac.ReadOnly = True
            txtProove.ReadOnly = True
            txtTotalEfectivo.ReadOnly = True
            txtTotalTransf.ReadOnly = True
            btnAddChk.Enabled = False
            btnEliminarChk.Enabled = False
            btnGuardar.Enabled = False
            cmbDestino.Enabled = False
            btnBusq.Enabled = False

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoOrdenDePagoAlta.SubSetReadOnly")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoOrdenDePagoAlta.SubSetReadOnly:" & ex.Message)
        End Try
    End Sub

    Private Sub SubCargarCombos()
        Try

            cmbDestino.Items.Add("Cobro")
            cmbDestino.Items.Add("Deposito")
            cmbDestino.Items.Add("Proveedores")
            cmbDestino.Items.Add("Retiro")
            cmbDestino.Items.Add("Otro")
            cmbDestino.SelectedItem = "Deposito"

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoOrdenDePagoAlta.CargarCombos")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoOrdenDePagoAlta.CargarCombos:" & ex.Message)
        End Try
    End Sub

    Private Sub subCargarDatos()
        Try
            dtpFecha.Value = mOrdenDePago.Fecha
            txtTotalEfectivo.Text = mOrdenDePago.Importe_cash
            txtTotalTransf.Text = mOrdenDePago.Importe_transferencia
            lblEstado.Text = mOrdenDePago.Estado.Estado

            If mOrdenDePago.Importe_cheques > 0 Then
                AgregarCheques(mOrdenDePago.Cheques)
            End If
            subActualizarSumCheques()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoOrdenDePagoAlta.subCargarDatos")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoOrdenDePagoAlta.subCargarDatos:" & ex.Message)
        End Try
    End Sub

    Public Sub AgregarCheques(ByVal lArrayChk As ArrayList)
        Dim lChk As cCheque = Nothing
        Dim lItem As ListViewItem = Nothing

        Try
            If Not IsNothing(lArrayChk) Then
                lvwConsulta.BeginUpdate()
                For Each lChk In lArrayChk
                    If lvwConsulta.Items.Count > 0 Then
                        lItem = lvwConsulta.FindItemWithText(lChk.Numero, True, 0)
                    End If
                    If IsNothing(lItem) Then
                        lItem = New ListViewItem()
                        lItem.Text = ""
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
                        lItem.Tag = lChk
                        lvwConsulta.Items.Add(lItem)
                        lItem = Nothing
                    End If
                Next
                lvwConsulta.EndUpdate()
            End If

            subActualizarSumCheques()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoOrdenDePagoAlta.AgregarCheques")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoOrdenDePagoAlta.AgregarCheques:" & ex.Message)
        End Try
    End Sub

    Private Function subActualizarSumCheques() As Double
        subActualizarSumCheques = 0
        Dim lChk As cCheque = Nothing
        Dim lItem As ListViewItem = Nothing
        Try
            For Each lItem In lvwConsulta.Items
                lChk = lItem.Tag
                subActualizarSumCheques = subActualizarSumCheques + lChk.Importe
            Next

            lblTotal.Text = "$ " & subActualizarSumCheques.ToString

            lblTotalOrden.Text = "$ " & (subActualizarSumCheques + Double.Parse(txtTotalTransf.Text) + Double.Parse(txtTotalEfectivo.Text))

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoOrdenDePagoAlta.subActualizarSumCheques")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoOrdenDePagoAlta.subActualizarSumCheques:" & ex.Message)
        End Try
    End Function

    Private Sub SubSetCabecera()
        Try
            lvwConsulta.BeginUpdate()
            lvwConsulta.Clear()

            lvwConsulta.Columns.Add(New ColHeader("X", 35, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("NroCheque", 80, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("Importe", 80, HorizontalAlignment.Right, True))
            lvwConsulta.Columns.Add(New ColHeader("Fec_Pago", 100, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("Banco", 250, HorizontalAlignment.Left, True))
            lvwConsulta.Columns.Add(New ColHeader("Cruzado", 70, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("Directo", 70, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("Orden", 70, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("Vto", 80, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("Estado", 80, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("Cliente", 250, HorizontalAlignment.Left, True))

            ' Connect the ListView.ColumnClick event to the ColumnClick event handler.
            AddHandler Me.lvwConsulta.ColumnClick, AddressOf lvwConsulta_ColumnClick

            lvwConsulta.EndUpdate()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoOrdenDePagoAlta.SubSetCabecera")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoOrdenDePagoAlta.SubSetCabecera:" & ex.Message)
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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoOrdenDePagoAlta.lvwConsulta_ColumnClick")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoOrdenDePagoAlta.lvwConsulta_ColumnClick:" & ex.Message)
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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoOrdenDePagoAlta.txtCliente_LostFocus")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoOrdenDePagoAlta.txtCliente_LostFocus:" & ex.Message)
        End Try
    End Sub

    Public Sub SetProveedor(ByVal pProove As cProveedor)
        Try
            lblNomProove.Text = pProove.Nombre
            txtProove.Text = pProove.Id_Proveedor
            txtProove.Tag = pProove
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoOrdenDePagoAlta.SetCliente")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoOrdenDePagoAlta.SetCliente:" & ex.Message)
        End Try
    End Sub

    Private Sub btnEliminarChk_Click(sender As Object, e As EventArgs) Handles btnEliminarChk.Click
        Dim lItem As ListViewItem = Nothing
        Try
            If lvwConsulta.CheckedItems.Count = 0 Then
                MsgBox("Debe tildar los cheques que desea quitar de la orden de pago.", MsgBoxStyle.Exclamation, "Sin seleccion")
                Exit Sub
            End If

            For Each lItem In lvwConsulta.CheckedItems
                lItem.Remove()
            Next

            subActualizarSumCheques()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoOrdenDePagoAlta.SetCliente")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoOrdenDePagoAlta.SetCliente:" & ex.Message)
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim lItem As ListViewItem = Nothing
        Try

            'VALIDACIONES
            If Double.Parse(lblTotalOrden.Text.Replace("$", "")) = 0 Then
                MsgBox("El monto de la orden de pago no puede ser cero.", MsgBoxStyle.Exclamation, "Error de validacion")
                Exit Sub
            End If

            If Not IsNumeric(txtTotalTransf.Text.Trim) Then
                MsgBox("El importe ingresado no es valido", MsgBoxStyle.Exclamation, "Error de validacion")
                Exit Sub
            End If

            If Not IsNumeric(txtTotalEfectivo.Text.Trim) Then
                MsgBox("El importe ingresado no es valido", MsgBoxStyle.Exclamation, "Error de validacion")
                Exit Sub
            End If

            If IsNothing(cmbDestino.SelectedItem) Then
                MsgBox("Debe seleccionar el Banco emisor del cheque", MsgBoxStyle.Exclamation, "Error de validacion")
                Exit Sub
            End If

            If cmbDestino.Text = "Proveedor" Then
                If IsNothing(txtProove.Tag) Then
                    MsgBox("Debe seleccionar el Proveedor destino", MsgBoxStyle.Exclamation, "Error de validacion")
                    Exit Sub
                End If
            End If
            '----------------------------------------------------

            If Me.TipoDeOperacion = EnuOPERACION.ALTA Or Me.TipoDeOperacion = EnuOPERACION.MODIF Then
                If Me.TipoDeOperacion = EnuOPERACION.ALTA Then
                    mOrdenDePago = New cOrdenDePago(gAdmin)
                    mOrdenDePago.EsNuevo = True
                End If

                'GUARDO LA INFORMACION
                mOrdenDePago.Importe_cash = txtTotalEfectivo.Text.Trim
                mOrdenDePago.Importe_cheques = subActualizarSumCheques()
                mOrdenDePago.Importe_transferencia = txtTotalTransf.Text.Trim
                mOrdenDePago.Fecha = dtpFecha.Value
                mOrdenDePago.Observaciones = txtObservac.Text.Trim
                mOrdenDePago.Tipo_Destino = cOrdenDePago.enuTipoDestinoOrdenPagoGetEnuxStr(cmbDestino.Text)
                If mOrdenDePago.Tipo_Destino = cOrdenDePago.enuTipoDestinoOrdenPago.Proveedores Then
                    mOrdenDePago.Proveedor = DirectCast(txtProove.Tag, cProveedor)
                End If
                If mOrdenDePago.Importe_cheques > 0 Then
                    mOrdenDePago.Cheques = New ArrayList
                    For Each lItem In lvwConsulta.Items
                        mOrdenDePago.Cheques.Add(lItem.Tag)
                    Next
                End If

                If mOrdenDePago.Guardar() = False Then
                    MsgBox("Error al intentar guardar la orden.", MsgBoxStyle.Exclamation, "Error")
                    Exit Sub
                End If
            End If

            MsgBox("La orden se guardo con exito !!", MsgBoxStyle.Information, "Ok")

            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoOrdenDePagoAlta.btnGuardar_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoOrdenDePagoAlta.btnGuardar_Click:" & ex.Message)
        End Try
    End Sub

    Private Sub btnBusq_Click(sender As Object, e As EventArgs) Handles btnBusq.Click
        Try
            DirectCast(Me.MdiParent, frmPrincipal).SubAbrirConsulta(cAdmin.EnuOBJETOS.Proveedores, Me)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoOrdenDePagoAlta.btnBusq_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoOrdenDePagoAlta.btnBusq_Click:" & ex.Message)
        End Try
    End Sub

    Private Sub btnAddChk_Click(sender As Object, e As EventArgs) Handles btnAddChk.Click

        Try
            'Abro la consulta de cheques para la busqueda.
            Dim lPpal As frmPrincipal = Me.MdiParent
            Dim Ventana As New frmTesoChkConsulta
            Dim F As Form
            Dim i As Integer

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
            Ventana.FrmLlamador = Me
            Ventana.TipoDeOperacion = FrmBase.EnuOPERACION.CONS
            Ventana.gLlamaDesdeOrdenDePago = True
            Ventana.Show()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoOrdenDePagoAlta.btnAddChk_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoOrdenDePagoAlta.btnAddChk_Click:" & ex.Message)
        End Try
    End Sub

    Private Sub cmbDestino_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDestino.SelectedIndexChanged
        Try
            If Not cmbDestino.Text = "Proveedores" Then
                txtProove.Text = ""
                txtProove.Tag = Nothing
                btnBusq.Enabled = False
                txtProove.Enabled = False
            Else
                btnBusq.Enabled = True
                txtProove.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoOrdenDePagoAlta.cmbDestino_SelectedIndexChanged")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoOrdenDePagoAlta.cmbDestino_SelectedIndexChanged:" & ex.Message)
        End Try
    End Sub

    Private Sub txtTotalEfectivo_LostFocus(sender As Object, e As EventArgs) Handles txtTotalEfectivo.LostFocus
        If Not IsNumeric(txtTotalEfectivo.Text) Then
            txtTotalEfectivo.Text = "0"
        End If
        subActualizarSumCheques()
    End Sub

    Private Sub txtTotalTransf_LostFocus(sender As Object, e As EventArgs) Handles txtTotalTransf.LostFocus
        If Not IsNumeric(txtTotalTransf.Text) Then
            txtTotalTransf.Text = "0"
        End If
        subActualizarSumCheques()
    End Sub

    Private Sub txtTotalEfectivo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTotalEfectivo.KeyPress
        ' Lista con los caracteres que deseo permitir.
        Dim caracteresPermitidos As String = "1234567890.-+" & Convert.ToChar(8)
        ' Carácter presionado.
        Dim c As Char = e.KeyChar
        ' Si la tecla presionada no se encuentra en la matriz 
        ' de caracteres permitidos, anulamos la tecla pulsada.
        If (Not (caracteresPermitidos.Contains(c))) Then
            ' Deshechamos el carácter
            e.Handled = True
        End If
    End Sub

    Private Sub txtTotalTransf_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTotalTransf.KeyPress
        ' Lista con los caracteres que deseo permitir.
        Dim caracteresPermitidos As String = "1234567890.-+" & Convert.ToChar(8)
        ' Carácter presionado.
        Dim c As Char = e.KeyChar
        ' Si la tecla presionada no se encuentra en la matriz 
        ' de caracteres permitidos, anulamos la tecla pulsada.
        If (Not (caracteresPermitidos.Contains(c))) Then
            ' Deshechamos el carácter
            e.Handled = True
        End If
    End Sub

End Class