Imports System.Globalization
Imports System.IO
Imports VzAdmin
Imports VzComercial
Imports vzStock

Public Class frmStkOrdenCompraABM
    Public mOrdenCompra As cOrdenCompra
    Private mObjetoOriginal As String

    Dim mPermiso As cPermiso = Nothing

    Private Sub frmStkOrdenCompraAlta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Tag = "STKALTAORDENDECOMPRA"

            '----------------------------------P-E-R-M-I-S-O-S---------------------------------------------------
            SetPermisos()
            '---------------------------------------------------------------------------------------------------

            SubSetCabecera()

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            Select Case Me.TipoDeOperacion
                Case FrmBase.EnuOPERACION.MODIF
                    mObjetoOriginal = mOrdenCompra.ToString
                    CargarDatos(mOrdenCompra)
                Case FrmBase.EnuOPERACION.CONS
                    CargarDatos(mOrdenCompra)
                Case FrmBase.EnuOPERACION.ALTA
                    mOrdenCompra = New cOrdenCompra(gAdmin)
                Case Else
                    Me.Close()
            End Select

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkOrdenCompraABM.frmStkOrdenCompraAlta_Load")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkOrdenCompraABM.frmStkOrdenCompraAlta_Load:" & ex.Message)
        End Try
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub SetPermisos()
        Try

            mPermiso = gAdmin.User.GetPermiso("STK_OC: Alta de Orden de Compra")

            If mPermiso.Admin = cPermiso.enuBinario.Si Then
                Exit Sub
            End If

            If Not (mPermiso.Alta = cPermiso.enuBinario.Si) Then
                MsgBox("No tiene permisos para acceder a esta opcion.", vbExclamation, "Acceso denegado")
                Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkOrdenCompraABM.SetPermisos")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkOrdenCompraABM.SetPermisos:" & ex.Message)
        End Try
    End Sub

    Private Sub btnBusqProv_Click(sender As Object, e As EventArgs) Handles btnBusqProv.Click
        Try
            DirectCast(Me.MdiParent, frmPrincipal).SubAbrirConsulta(cAdmin.EnuOBJETOS.Proveedores, Me)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkOrdenCompraABM.btnBusqProv_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkOrdenCompraABM.btnBusqProv_Click:" & ex.Message)
        End Try
    End Sub

    Public Sub CargarDatos(ByRef pOrdenC As cOrdenCompra)
        Dim lDet As cOrdenCompraDet = Nothing
        Try
            dtpFechaEntrega.Value = pOrdenC.FechaEntrega
            SetProveedor(pOrdenC.Proveedor)
            txtObservac.Text = pOrdenC.Observaciones

            For Each lDet In pOrdenC.Detalle
                CargarItemGrilla(lDet)
            Next

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkOrdenCompraABM.CargarDatos")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkOrdenCompraABM.CargarDatos:" & ex.Message)
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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkOrdenCompraABM.SetCliente")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkOrdenCompraABM.SetCliente:" & ex.Message)
        End Try
    End Sub

    Private Sub btnBusqArt_Click(sender As Object, e As EventArgs) Handles btnBusqArt.Click
        Try
            DirectCast(Me.MdiParent, frmPrincipal).SubAbrirConsulta(cAdmin.EnuOBJETOS.Articulo, Me)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkOrdenCompraABM.btnBusqProv_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkOrdenCompraABM.btnBusqProv_Click:" & ex.Message)
        End Try
    End Sub

    Private Sub txtCodArt_LostFocus(sender As Object, e As EventArgs) Handles txtCodArt.LostFocus
        Dim pArt As cArticulo = Nothing
        Try
            If Not txtCodArt.Text.Trim = "" Then
                pArt = cArticulo.GetArticuloxCod(gAdmin, txtCodArt.Text.Trim)
                If Not IsNothing(pArt) Then
                    SetArticulo(pArt)
                Else
                    txtCodArt.Text = ""
                    lblNomProove.Text = "_____________"
                    txtCodArt.Tag = Nothing
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkOrdenCompraABM.txtCodArt_LostFocus")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkOrdenCompraABM.txtCodArt_LostFocus:" & ex.Message)
        End Try
    End Sub

    Public Sub SetArticulo(ByVal pArt As cArticulo)
        Try
            lblDescripcionArt.Text = pArt.Descripcion
            txtCodArt.Text = pArt.CodArt
            txtCodArt.Tag = pArt
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkOrdenCompraABM.SetArticulo")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkOrdenCompraABM.SetArticulo:" & ex.Message)
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim lItem As ListViewItem = Nothing

        Try
            'VALIDACIONES

            If IsNothing(txtProove.Tag) Then
                MsgBox("Debe seleccionar el Proveedor.", MsgBoxStyle.Exclamation, "Error de validacion")
                Exit Sub
            End If
            '----------------------------------------------------

            If Me.TipoDeOperacion = EnuOPERACION.ALTA Or Me.TipoDeOperacion = EnuOPERACION.MODIF Then
                'Insert
                If Me.TipoDeOperacion = EnuOPERACION.ALTA Then
                    mOrdenCompra = New cOrdenCompra(gAdmin)
                    mOrdenCompra.EsNuevo = True
                End If

                'GUARDO LA INFORMAION
                mOrdenCompra.Fecha = Date.Today
                mOrdenCompra.FechaEntrega = dtpFechaEntrega.Value
                mOrdenCompra.Proveedor = DirectCast(txtProove.Tag, cProveedor)
                mOrdenCompra.Observaciones = txtObservac.Text.Trim

                For Each lItem In lvwConsulta.Items
                    mOrdenCompra.Detalle.Add(DirectCast(lItem.Tag, cOrdenCompraDet))
                Next

                mOrdenCompra.Guardar()
            Else 'update


            End If

            MsgBox("La orden se guardo con exito !!", MsgBoxStyle.Information, "Ok")

            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkOrdenCompraABM.btnGuardar_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkOrdenCompraABM.btnGuardar_Click:" & ex.Message)
        End Try
    End Sub

    Private Sub imgAbrir_Click(sender As Object, e As EventArgs) Handles imgAbrir.Click

        Dim lPath As String = ""
        Dim openFD As New OpenFileDialog()

        Try

            openFD.Title = "Seleccionar archivos"
            openFD.Filter = "Archivos Excel(*.txt)|*.txt|Todos los archivos(*.*)|*.*"
            openFD.Multiselect = False
            openFD.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop

            If openFD.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                lPath = openFD.FileName
                LoadArchivo(lPath)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkOrdenCompraABM.imgAbrir_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkOrdenCompraABM.imgAbrir_Click:" & ex.Message)
        End Try
    End Sub

    Private Sub LoadArchivo(ByVal pFilePath As String)
        Dim objReader As New StreamReader(pFilePath)
        Dim sLine As String = ""
        Dim ArrText As New ArrayList()
        Dim lItem As ListViewItem = Nothing
        Dim lTxtRow As String() = Nothing
        Dim lCant As Integer = 0
        Dim lSepDec As String = ""
        Dim lSepMiles As String = ""
        Dim lPcioCompra As Double = 0
        Dim lCosto As Double = 0
        'Cargo el separador decimal que necesita el sistema.
        Dim lSysSepDec As String = CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator
        Try

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            Do
                sLine = objReader.ReadLine()
                If Not sLine Is Nothing Then
                    lTxtRow = Split(sLine, vbTab)
                    ArrText.Add(lTxtRow)
                End If
            Loop Until sLine Is Nothing
            objReader.Close()

            SubSetCabecera()

            'Cargo en los settings los separadores de miles y decimales con los que exporta excel a texto.
            lSepMiles = cSetting.GetSettingxCodigo(gAdmin, "StkCargaPreciosSepMiles").Valor.Trim
            lSepDec = cSetting.GetSettingxCodigo(gAdmin, "StkCargaPreciosSepDec").Valor.Trim

            For Each lTxtRow In ArrText
                lItem = New ListViewItem
                lItem.UseItemStyleForSubItems = False 'Cambio la propiedad para que cada subitem tenga propiedades style.

                If Not lTxtRow(0).ToString.Trim = "" Then
                    lItem.Text = lTxtRow(0).ToString.Trim 'CodArticulo

                    lItem.SubItems.Add("") 'Articulo

                    lItem.SubItems.Add("") 'Cantidad

                    Double.TryParse(lTxtRow(1).ToString().Replace(lSepMiles, "").Replace(lSepDec, lSysSepDec).Trim, lPcioCompra)
                    lItem.SubItems.Add(lPcioCompra.ToString("C"))



                    Double.TryParse(lTxtRow(1).ToString().Replace(lSepMiles, "").Replace(lSepDec, lSysSepDec).Trim, lCosto)
                    lItem.SubItems.Add(lCosto.ToString("C"))

                    lvwConsulta.Items.Add(lItem)
                    lCant = lCant + 1
                End If
            Next

            lblTotalImp.Text = "Total Importados: " & lCant.ToString

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkOrdenCompraABM.LoadArchivo")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkOrdenCompraABM.LoadArchivo:" & ex.Message)
            SubSetCabecera() ' Si falla borro la grilla.
        End Try
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
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

    Private Sub SubSetCabecera()
        Try

            ' Add columns using the ColHeader class. The fourth    
            ' parameter specifies true for an ascending sort order.
            lvwConsulta.BeginUpdate()
            lvwConsulta.Clear()

            lvwConsulta.Columns.Add(New ColHeader("CodArt", 60, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("Articulo", 300, HorizontalAlignment.Left, True))
            lvwConsulta.Columns.Add(New ColHeader("Cantidad", 70, HorizontalAlignment.Right, True))
            lvwConsulta.Columns.Add(New ColHeader("PcioCompra", 70, HorizontalAlignment.Right, True))
            lvwConsulta.Columns.Add(New ColHeader("Total", 75, HorizontalAlignment.Right, True))
            lvwConsulta.Columns.Add(New ColHeader("UltCosto", 65, HorizontalAlignment.Right, True))
            lvwConsulta.Columns.Add(New ColHeader("%Var", 65, HorizontalAlignment.Right, True))

            lvwConsulta.EndUpdate()

            'Ajusto contadores
            lblTotalImp.Text = "Total Importados: 0"
            lblProcOK.Text = "Procesados OK: 0"
            lblProcErr.Text = "Procesados con ERROR: 0"

            ' Connect the ListView.ColumnClick event to the ColumnClick event handler.
            AddHandler Me.lvwConsulta.ColumnClick, AddressOf lvwConsulta_ColumnClick

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkOrdenCompraABM.SubSetCabecera")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkOrdenCompraABM.SubSetCabecera:" & ex.Message)
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

        Try
            If lvwConsulta.SelectedItems.Count > 0 Then
                lvwConsulta.Items.Remove(lvwConsulta.SelectedItems(0))
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkOrdenCompraABM.btnEliminar_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkOrdenCompraABM.btnEliminar_Click:" & ex.Message)
        End Try
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim lOrdenDet As cOrdenCompraDet = Nothing
        Dim lPrecio As Double = 0

        Try
            '----------Valido los datos ingresados -----------------------------------------------
            If Not Double.TryParse(txtPrecioU.Text, lPrecio) Then
                MsgBox("El precio unitario no es valido.", MsgBoxStyle.Exclamation, "Error de validacion")
                Exit Sub
            End If

            If Not NumCantidad.Value > 0 Then
                MsgBox("La cantidad de productos debe ser mayor a cero.", MsgBoxStyle.Exclamation, "Error de validacion")
                Exit Sub
            End If

            If IsNothing(txtCodArt.Tag) Then
                MsgBox("Debe seleccionar el articulo que desea agregar a la orden de compra.", MsgBoxStyle.Exclamation, "Error de validacion")
                Exit Sub
            End If

            '----------------fin validaciones---------------------------------------

            lOrdenDet = New cOrdenCompraDet(gAdmin)

            lOrdenDet.Articulo = txtCodArt.Tag
            lOrdenDet.Cantidad = NumCantidad.Value
            lOrdenDet.PrecioUnitario = Double.Parse(txtPrecioU.Text)
            lOrdenDet.EsNuevo = True

            CargarItemGrilla(lOrdenDet)

            'Limpio los datos de carga de articulos
            txtCodArt.Text = ""
            txtCodArt.Tag = Nothing
            NumCantidad.Value = 1
            txtPrecioU.Text = ""
            lblDescripcionArt.Text = "__________________________________"

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkOrdenCompraABM.btnAgregar_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkOrdenCompraABM.btnAgregar_Click:" & ex.Message)
        End Try
    End Sub

    Private Sub CargarItemGrilla(ByVal pOrdenDet As cOrdenCompraDet)
        Dim lItem As ListViewItem = Nothing
        Dim lVar As Double = 0
        Try
            lItem = New ListViewItem
            lItem.UseItemStyleForSubItems = False 'Cambio la propiedad para que cada subitem tenga propiedades style.

            lItem.Tag = pOrdenDet

            lItem.Text = pOrdenDet.Articulo.CodArt
            lItem.SubItems.Add(pOrdenDet.Articulo.Descripcion)
            lItem.SubItems.Add(pOrdenDet.Cantidad)
            lItem.SubItems.Add(pOrdenDet.PrecioUnitario.ToString("C"))
            lItem.SubItems.Add((pOrdenDet.PrecioUnitario * pOrdenDet.Cantidad).ToString("C")) 'Total
            lItem.SubItems.Add(pOrdenDet.Articulo.PcioCosto.ToString("C")) 'Ultimo costo conocido

            'lVar = Math.Round(((pOrdenDet.PrecioUnitario - pOrdenDet.Articulo.PcioCosto) / pOrdenDet.Articulo.PcioCosto), 2)
            lVar = Math.Round(((pOrdenDet.PrecioUnitario - pOrdenDet.Articulo.PcioCosto) / pOrdenDet.Articulo.PcioCosto), 6)
            lItem.SubItems.Add(lVar.ToString("P"))

            If lVar > 0 Then
                lItem.SubItems(5).ForeColor = Color.Red
            ElseIf lVar < 0 Then
                lItem.SubItems(5).ForeColor = Color.Blue
            End If

            lvwConsulta.Items.Add(lItem)


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkOrdenCompraABM.CargarItemGrilla")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkOrdenCompraABM.CargarItemGrilla: " & ex.Message)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class