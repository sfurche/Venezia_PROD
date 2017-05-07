Imports VzAdmin
Imports VzComercial
Imports vzStock

Public Class frmStkOrdenCompraConsulta

    Dim mPermiso As cPermiso = Nothing

    Private Sub frmStkOrdenCompraConsulta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Tag = "STKCONSULTAORDENDECOMPRA"

            '----------------------------------P-E-R-M-I-S-O-S---------------------------------------------------
            SetPermisos()
            '---------------------------------------------------------------------------------------------------

            SubSetCabecera()

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkOrdenCompraConsulta.frmStkOrdenCompraConsulta_Load")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkOrdenCompraConsulta.frmStkOrdenCompraConsulta_Load:" & ex.Message)
        End Try
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub SetPermisos()
        Try

            mPermiso = gAdmin.User.GetPermiso("STK_OC: Consulta de Orden de Compra")

            If mPermiso.Admin = cPermiso.enuBinario.Si Then
                Exit Sub
            End If

            If Not (mPermiso.Admin = cPermiso.enuBinario.Si Or mPermiso.Consulta = cPermiso.enuBinario.Si) Then
                MsgBox("No tiene permisos para acceder a esta opcion.", vbExclamation, "Acceso denegado")
                Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkOrdenCompraConsulta.SetPermisos")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkOrdenCompraConsulta.SetPermisos:" & ex.Message)
        End Try
    End Sub

    Private Sub SubSetCabecera()
        Try

            ' Add columns using the ColHeader class. The fourth    
            ' parameter specifies true for an ascending sort order.
            lvwConsulta.BeginUpdate()
            lvwConsulta.Clear()

            lvwConsulta.Columns.Add(New ColHeader("Id_Orden", 60, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("Fecha", 70, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("Fecha_Entrega", 90, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("Proveedor", 230, HorizontalAlignment.Left, True))
            lvwConsulta.Columns.Add(New ColHeader("Importe", 75, HorizontalAlignment.Right, True))
            lvwConsulta.Columns.Add(New ColHeader("Estado", 70, HorizontalAlignment.Center, True))

            lvwConsulta.EndUpdate()

            ' Connect the ListView.ColumnClick event to the ColumnClick event handler.
            AddHandler Me.lvwConsulta.ColumnClick, AddressOf lvwConsulta_ColumnClick

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkOrdenCompraConsulta.SubSetCabecera")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkOrdenCompraConsulta.SubSetCabecera:" & ex.Message)
        End Try
    End Sub

    Public Sub CargarEnGrilla(ByVal pOrdenC As cOrdenCompra)
        Dim lItem As New ListViewItem
        Try
            lItem.Tag = pOrdenC
            lItem.Text = pOrdenC.Id_OrdenDeCompra
            lItem.SubItems.Add(pOrdenC.Fecha.ToShortDateString)
            lItem.SubItems.Add(pOrdenC.FechaEntrega.ToShortDateString)
            lItem.SubItems.Add(pOrdenC.Proveedor.Nombre.Trim)
            lItem.SubItems.Add(pOrdenC.Importe.ToString("C"))
            lItem.SubItems.Add(pOrdenC.Estado.Estado)

            lvwConsulta.Items.Add(lItem)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkOrdenCompraConsulta.CargarEnGrilla")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkOrdenCompraConsulta.CargarEnGrilla:" & ex.Message)
        End Try

    End Sub

    Private Sub lvwConsulta_DoubleClick(sender As Object, e As EventArgs) Handles lvwConsulta.DoubleClick
        Try

            frmPrincipal.SubArirCOrdenDeCompra(lvwConsulta.SelectedItems(0).Tag, Me.FrmLlamador, EnuOPERACION.CONS)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkOrdenCompraConsulta.lvwConsulta_DoubleClick")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkOrdenCompraConsulta.lvwConsulta_DoubleClick:" & ex.Message)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub lvwConsulta_ColumnClick(ByVal sender As Object, ByVal e As ColumnClickEventArgs)

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
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim lArray As ArrayList = Nothing
        Dim lOrden As cOrdenCompra = Nothing
        Try

            lArray = cOrdenCompra.GetOrdenCompraxProvFecEntregaDH(gAdmin, dtpFechaEntregaD.Value, dtpFechaEntregaH.Value, txtProove.Tag)

            SubSetCabecera()

            For Each lOrden In lArray
                CargarEnGrilla(lOrden)
            Next

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkOrdenCompraConsulta.btnBuscar_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkOrdenCompraConsulta.btnBuscar_Click:" & ex.Message)
        End Try
    End Sub

    Private Sub btnBusqProv_Click(sender As Object, e As EventArgs) Handles btnBusqProv.Click
        Try
            DirectCast(Me.MdiParent, frmPrincipal).SubAbrirConsulta(cAdmin.EnuOBJETOS.Proveedores, Me)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkOrdenCompraConsulta.btnBusqProv_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkOrdenCompraConsulta.btnBusqProv_Click:" & ex.Message)
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
            Else
                txtProove.Text = ""
                lblNomProove.Text = "_____________"
                txtProove.Tag = Nothing
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkOrdenCompraABM.txtProove_LostFocus")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkOrdenCompraABM.txtProove_LostFocus:" & ex.Message)
        End Try
    End Sub

    Public Sub SetProveedor(ByVal pProove As cProveedor)
        Try
            lblNomProove.Text = pProove.Nombre
            txtProove.Text = pProove.Id_Proveedor
            txtProove.Tag = pProove
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkOrdenCompraConsulta.SetCliente")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkOrdenCompraConsulta.SetCliente:" & ex.Message)
        End Try
    End Sub

End Class