Imports System.Globalization
Imports System.IO
Imports VzAdmin
Imports VzComercial
Imports vzStock

Public Class frmStkOrdenCompraAlta
    Public mOrdenCompra As cOrdenCompra

    Dim mPermiso As cPermiso = Nothing

    Private Sub frmStkOrdenCompraAlta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Tag = "STKALTAORDENDECOMPRA"

            '----------------------------------P-E-R-M-I-S-O-S---------------------------------------------------
            SetPermisos()
            '---------------------------------------------------------------------------------------------------

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkOrdenCompraAlta.frmStkOrdenCompraAlta_Load")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkOrdenCompraAlta.frmStkOrdenCompraAlta_Load:" & ex.Message)
        End Try
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub SetPermisos()
        Try

            mPermiso = gAdmin.User.GetPermiso("STK_OC: Alta de Orden de Compra")

            If mPermiso.Admin = cPermiso.enuBinario.Si Then
                Exit Sub
            End If

            If Not (mPermiso.Admin = cPermiso.enuBinario.Si Or mPermiso.Consulta = cPermiso.enuBinario.Si) Then
                MsgBox("No tiene permisos para acceder a esta opcion.", vbExclamation, "Acceso denegado")
                Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkOrdenCompraAlta.SetPermisos")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkOrdenCompraAlta.SetPermisos:" & ex.Message)
        End Try
    End Sub

    Private Sub btnBusq_Click(sender As Object, e As EventArgs) Handles btnBusq.Click
        Try
            DirectCast(Me.MdiParent, frmPrincipal).SubAbrirConsulta(cAdmin.EnuOBJETOS.Proveedores, Me)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkOrdenCompraAlta.btnBusq_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkOrdenCompraAlta.btnBusq_Click:" & ex.Message)
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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkOrdenCompraAlta.txtProove_LostFocus")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkOrdenCompraAlta.txtProove_LostFocus:" & ex.Message)
        End Try
    End Sub

    Public Sub SetProveedor(ByVal pProove As cProveedor)
        Try
            lblNomProove.Text = pProove.Nombre
            txtProove.Text = pProove.Id_Proveedor
            txtProove.Tag = pProove
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkOrdenCompraAlta.SetCliente")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkOrdenCompraAlta.SetCliente:" & ex.Message)
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
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


            Else 'update


            End If

            MsgBox("La orden se guardo con exito !!", MsgBoxStyle.Information, "Ok")

            Me.Close()
        Catch ex As Exception

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkOrdenCompraAlta.imgAbrir_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkOrdenCompraAlta.imgAbrir_Click:" & ex.Message)
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
                    lItem.SubItems.Add(lNuevoValor.ToString("C"))



                    Double.TryParse(lTxtRow(1).ToString().Replace(lSepMiles, "").Replace(lSepDec, lSysSepDec).Trim, lCosto)
                    lItem.SubItems.Add(lNuevoValor.ToString("C"))

                    lvwConsulta.Items.Add(lItem)
                    lCant = lCant + 1
                End If
            Next

            lblTotalImp.Text = "Total Importados: " & lCant.ToString

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkOrdenCompraAlta.LoadArchivo")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkOrdenCompraAlta.LoadArchivo:" & ex.Message)
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
            lvwConsulta.Columns.Add(New ColHeader("Articulo", 200, HorizontalAlignment.Left, True))
            lvwConsulta.Columns.Add(New ColHeader("Cantidad", 70, HorizontalAlignment.Right, True))
            lvwConsulta.Columns.Add(New ColHeader("PcioCompra", 70, HorizontalAlignment.Right, True))
            lvwConsulta.Columns.Add(New ColHeader("Costo", 65, HorizontalAlignment.Right, True))
            lvwConsulta.Columns.Add(New ColHeader("%Var", 65, HorizontalAlignment.Right, True))

            lvwConsulta.EndUpdate()

            'Ajusto contadores
            lblTotalImp.Text = "Total Importados: 0"
            lblProcOK.Text = "Procesados OK: 0"
            lblProcErr.Text = "Procesados con ERROR: 0"

            ' Connect the ListView.ColumnClick event to the ColumnClick event handler.
            AddHandler Me.lvwConsulta.ColumnClick, AddressOf lvwConsulta_ColumnClick

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkOrdenCompraAlta.SubSetCabecera")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkOrdenCompraAlta.SubSetCabecera:" & ex.Message)
        End Try
    End Sub

End Class