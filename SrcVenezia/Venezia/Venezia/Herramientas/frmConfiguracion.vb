Imports VzAdmin

Public Class frmConfiguracion

    Dim mPermiso As cPermiso = Nothing

    Private Sub Configuracion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            '----------------------------------P-E-R-M-I-S-O-S---------------------------------------------------
            SetPermisos()
            '---------------------------------------------------------------------------------------------------
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            SubSetCabecera()
            subCargarSettings()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmConfiguracion.Configuracion_Load")
            gAdmin.Log.fncGrabarLogERR("Error en frmConfiguracion.Configuracion_Load:" & ex.Message)
        End Try
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub SetPermisos()
        Try

            mPermiso = gAdmin.User.GetPermiso("HERR_CFG: Variables")

            If mPermiso.Admin = cPermiso.enuBinario.Si Then
                Exit Sub
            End If

            If Not (mPermiso.Consulta = cPermiso.enuBinario.Si) Then
                MsgBox("No tiene permisos para acceder a esta opcion.", vbExclamation, "Acceso denegado")
                Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
            End If

            If Not (mPermiso.Modificacion = cPermiso.enuBinario.Si) Then
                btnModificar.Enabled = False
                tsmCambiarValor.Enabled = False
            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmConfiguracion.SetPermisos")
            gAdmin.Log.fncGrabarLogERR("Error en frmConfiguracion.SetPermisos:" & ex.Message)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub SubSetCabecera()
        Try
            lvwConsulta.BeginUpdate()
            lvwConsulta.Clear()

            ' Add columns using the ColHeader class. The fourth    
            ' parameter specifies true for an ascending sort order.
            lvwConsulta.Columns.Add(New ColHeader("Id", 40, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("Codigo", 120, HorizontalAlignment.Left, True))
            lvwConsulta.Columns.Add(New ColHeader("Tipo", 80, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("Valor", 3000, HorizontalAlignment.Left, True))
            lvwConsulta.Columns.Add(New ColHeader("Observaciones", 350, HorizontalAlignment.Left, True))

            ' Connect the ListView.ColumnClick event to the ColumnClick event handler.
            AddHandler Me.lvwConsulta.ColumnClick, AddressOf lvwConsulta_ColumnClick

            lvwConsulta.EndUpdate()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmConfiguracion.SubSetCabecera")
            gAdmin.Log.fncGrabarLogERR("Error en frmConfiguracion.SubSetCabecera:" & ex.Message)
        End Try
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

    Private Sub subCargarSettings()
        Dim lItem As ListViewItem
        Dim lSetting As cSetting = Nothing
        Dim lArray As ArrayList = Nothing
        Dim lSum As Decimal = 0
        Try

            SubSetCabecera()
            lArray = cSetting.GetAllSettings(gAdmin)

            If Not IsNothing(lArray) Then
                For Each lSetting In lArray
                    lItem = New ListViewItem()
                    lItem.Text = lSetting.Id_Setting
                    lItem.SubItems.Add(lSetting.Cod_Setting)
                    lItem.SubItems.Add(lSetting.Tipo_Dato)
                    lItem.SubItems.Add(lSetting.Valor)
                    lItem.SubItems.Add(lSetting.Observaciones)
                    lItem.Tag = lSetting
                    lvwConsulta.Items.Add(lItem)
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmConfiguracion.subCargarSettings")
            gAdmin.Log.fncGrabarLogERR("Error en frmConfiguracion.subCargarSettings:" & ex.Message)
        End Try
    End Sub

    Private Sub lvwConsulta_MouseClick(sender As Object, e As MouseEventArgs) Handles lvwConsulta.MouseClick
        Try

            If e.Button = MouseButtons.Right Then
                If lvwConsulta.FocusedItem.Bounds.Contains(e.Location) = True Then
                    ContextMenuStrip1.Show(Cursor.Position)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmConfiguracion.lvwConsulta_MouseClick")
            gAdmin.Log.fncGrabarLogERR("Error en frmConfiguracion.lvwConsulta_MouseClick:" & ex.Message)
        End Try
    End Sub

    Private Sub tsmCambiarPrecio_Click(sender As Object, e As EventArgs) Handles tsmCambiarValor.Click
        Dim lValor As String = ""
        Dim lSetting As cSetting = Nothing
        Try

            lSetting = DirectCast(lvwConsulta.SelectedItems(0).Tag, cSetting)
            lValor = InputBox("Ingerse el nuevo precio:", "Modificar precio", lSetting.Valor)

            If Not (lValor = lSetting.Valor Or lValor Is String.Empty) Then
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
                lvwConsulta.SelectedItems(0).SubItems(3).Text = lValor
                lSetting.Valor = lValor
                lSetting.Guardar()
                subCargarSettings()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmConfiguracion.tsmCambiarPrecio_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmConfiguracion.tsmCambiarPrecio_Click:" & ex.Message)
        End Try
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            If lvwConsulta.SelectedItems.Count = 0 Then
                MsgBox("Debe seleccionar el valor que desea modificar.", MsgBoxStyle.Exclamation, "Nada para modificar")
                Exit Sub
            End If

            tsmCambiarPrecio_Click(Me, Nothing)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmConfiguracion.btnModificar_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmConfiguracion.btnModificar_Click:" & ex.Message)
        End Try

    End Sub

End Class