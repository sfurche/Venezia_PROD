Imports VzAdmin

Public Class frmCfgPermisosConsulta
    Dim mModif As Boolean = False 'Define si hubo modificaciones en los permisos del usuario seleccionado.
    Dim mPermiso As cPermiso = Nothing
    Dim mUser As cUser = Nothing

    Private Sub frmCfgPermisosConsulta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            '----------------------------------P-E-R-M-I-S-O-S---------------------------------------------------
            SetPermisos()
            '---------------------------------------------------------------------------------------------------

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            subCargarCombo()
            SubSetCabecera()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmCfgPermisosConsulta.frmCfgPermisosConsulta_Load")
            gAdmin.Log.fncGrabarLogERR("Error en frmCfgPermisosConsulta.frmCfgPermisosConsulta_Load:" & ex.Message)
        End Try
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub SetPermisos()
        Try

            mPermiso = gAdmin.User.GetPermiso("HERR_SEG: Consulta de Permisos")


            If mPermiso.Admin = cPermiso.enuBinario.Si Then
                Exit Sub
            End If


            If Not (mPermiso.Admin = cPermiso.enuBinario.Si Or mPermiso.Consulta = cPermiso.enuBinario.Si) Then
                MsgBox("No tiene permisos para acceder a esta opcion.", vbExclamation, "Acceso denegado")
                Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
            End If

            If Not mPermiso.Admin = cPermiso.enuBinario.Si Then
                btnUpdPWD.Enabled = False
            End If

            If Not mPermiso.Modificacion = cPermiso.enuBinario.Si Then
                lvwConsulta.Enabled = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmCfgPermisosConsulta.SetPermisos")
            gAdmin.Log.fncGrabarLogERR("Error en frmCfgPermisosConsulta.SetPermisos:" & ex.Message)
        End Try
    End Sub

    Private Sub SubSetCabecera()
        Try

            ' Add columns using the ColHeader class. The fourth    
            ' parameter specifies true for an ascending sort order.
            lvwConsulta.BeginUpdate()
            lvwConsulta.Clear()

            lvwConsulta.Columns.Add(New ColHeader("Id", 40, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("Permiso", 250, HorizontalAlignment.Left, True))
            lvwConsulta.Columns.Add(New ColHeader("Alta", 65, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("Baja", 65, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("Modif", 65, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("Ejecuta", 65, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("Consulta", 65, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("Supervisa", 65, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("Admin", 65, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("Observaciones", 200, HorizontalAlignment.Left, True))

            lvwConsulta.EndUpdate()

            ' Connect the ListView.ColumnClick event to the ColumnClick event handler.
            AddHandler Me.lvwConsulta.ColumnClick, AddressOf lvwConsulta_ColumnClick

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmCfgPermisosConsulta.SubSetCabecera")
            gAdmin.Log.fncGrabarLogERR("Error en frmCfgPermisosConsulta.SubSetCabecera:" & ex.Message)
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

    Private Sub subCargarCombo()
        Dim lArray As ArrayList
        Dim lUser As VzAdmin.cUser = Nothing
        Try
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            cmbUsuarios.Items.Clear()

            lArray = cUser.GetUsuarioAll(gAdmin)

            cmbUsuarios.Items.Add(" ")
            For Each lUser In lArray
                cmbUsuarios.Items.Add(lUser)
            Next
            cmbUsuarios.DisplayMember = "Usuario"
            cmbUsuarios.SelectedText = " "

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmCfgPermisosConsulta.subCargarCombo")
            gAdmin.Log.fncGrabarLogERR("Error en frmCfgPermisosConsulta.subCargarCombo:" & ex.Message)
        End Try
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub CargarDatosGrilla(ByVal lUser As cUser)
        Dim lItem As ListViewItem = Nothing
        Dim lPermiso As cPermiso = Nothing

        Dim myCheckFont As New System.Drawing.Font("Wingdings", 12, FontStyle.Regular)


        Try
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            SubSetCabecera()

            For Each lPermiso In lUser.Permisos
                lItem = New ListViewItem()
                lItem.Tag = lPermiso
                lItem.Text = lPermiso.Id_Permiso
                lItem.UseItemStyleForSubItems = False
                lItem.SubItems.Add(lPermiso.Nombre)
                lItem.SubItems.Add(IIf(lPermiso.Alta = cPermiso.enuBinario.Si, Chr(252), Chr(251)), IIf(lPermiso.Alta = cPermiso.enuBinario.Si, Color.Green, Color.Red), Color.White, myCheckFont)
                lItem.SubItems.Add(IIf(lPermiso.Baja = cPermiso.enuBinario.Si, Chr(252), Chr(251)), IIf(lPermiso.Baja = cPermiso.enuBinario.Si, Color.Green, Color.Red), Color.White, myCheckFont)
                lItem.SubItems.Add(IIf(lPermiso.Modificacion = cPermiso.enuBinario.Si, Chr(252), Chr(251)), IIf(lPermiso.Modificacion = cPermiso.enuBinario.Si, Color.Green, Color.Red), Color.White, myCheckFont)
                lItem.SubItems.Add(IIf(lPermiso.Ejecuta = cPermiso.enuBinario.Si, Chr(252), Chr(251)), IIf(lPermiso.Ejecuta = cPermiso.enuBinario.Si, Color.Green, Color.Red), Color.White, myCheckFont)
                lItem.SubItems.Add(IIf(lPermiso.Consulta = cPermiso.enuBinario.Si, Chr(252), Chr(251)), IIf(lPermiso.Consulta = cPermiso.enuBinario.Si, Color.Green, Color.Red), Color.White, myCheckFont)
                lItem.SubItems.Add(IIf(lPermiso.Supervisa = cPermiso.enuBinario.Si, Chr(252), Chr(251)), IIf(lPermiso.Supervisa = cPermiso.enuBinario.Si, Color.Green, Color.Red), Color.White, myCheckFont)
                lItem.SubItems.Add(IIf(lPermiso.Admin = cPermiso.enuBinario.Si, Chr(252), Chr(251)), IIf(lPermiso.Admin = cPermiso.enuBinario.Si, Color.Green, Color.Red), Color.White, myCheckFont)
                lItem.SubItems.Add(lPermiso.Observaciones)
                lvwConsulta.Items.Add(lItem)
            Next

            mModif = False

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmPermisosConsulta.CargarDatosGrilla")
            gAdmin.Log.fncGrabarLogERR("Error en frmPermisosConsulta.CargarDatosGrilla:" & ex.Message)
        End Try
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub cmbUsuarios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUsuarios.SelectedIndexChanged
        Try
            'If mModif = True Then
            '    If MsgBox("Hay cambios que no se han guardado. Desea continuar y perder las modificaciones realizadas ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "No guardar") = MsgBoxResult.No Then
            '        If Not IsNothing(mUser) Then
            '            cmbUsuarios.SelectedText = mUser.Usuario
            '            Exit Sub
            '        End If
            '    End If
            'End If

            If cmbUsuarios.SelectedText = " " Then
                SubSetCabecera()
            Else
                mUser = DirectCast(cmbUsuarios.SelectedItem, cUser)
                CargarDatosGrilla(mUser)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmCfgPermisosConsulta.cmbUsuarios_SelectedIndexChanged")
            gAdmin.Log.fncGrabarLogERR("Error en frmCfgPermisosConsulta.cmbUsuarios_SelectedIndexChanged:" & ex.Message)
        End Try
    End Sub

    Private Sub btnUpdPWD_Click(sender As Object, e As EventArgs) Handles btnUpdPWD.Click
        Try

            MsgBox("La password del usuario es: '" & DirectCast(cmbUsuarios.SelectedItem, cUser).Pwd & "'", vbInformation, "Visor de clave")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmCfgPermisosConsulta.btnUpdPWD_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmCfgPermisosConsulta.btnUpdPWD_Click:" & ex.Message)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub lvwConsulta_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lvwConsulta.MouseDoubleClick
        Try
            Dim lPermiso As cPermiso = Nothing
            Dim info As ListViewHitTestInfo = lvwConsulta.HitTest(e.X, e.Y)

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            If Not IsNothing(info.SubItem) Then
                'MsgBox(info.SubItem.Text)

                If info.SubItem.Text = Chr(251) Then
                    info.SubItem.Text = Chr(252)
                    info.SubItem.ForeColor = Color.Green
                    mModif = True
                    lvwConsulta.Select()
                ElseIf info.SubItem.Text = Chr(252) Then
                    info.SubItem.Text = Chr(251)
                    info.SubItem.ForeColor = Color.Red
                    mModif = True
                    lvwConsulta.HideSelection = True
                End If

                'Actualizo la modificacion en el objeto Permiso
                lPermiso = info.Item.Tag
                lPermiso.Alta = IIf(info.Item.SubItems(2).Text = Chr(252), cPermiso.enuBinario.Si, cPermiso.enuBinario.No)
                lPermiso.Baja = IIf(info.Item.SubItems(3).Text = Chr(252), cPermiso.enuBinario.Si, cPermiso.enuBinario.No)
                lPermiso.Modificacion = IIf(info.Item.SubItems(4).Text = Chr(252), cPermiso.enuBinario.Si, cPermiso.enuBinario.No)
                lPermiso.Ejecuta = IIf(info.Item.SubItems(5).Text = Chr(252), cPermiso.enuBinario.Si, cPermiso.enuBinario.No)
                lPermiso.Consulta = IIf(info.Item.SubItems(6).Text = Chr(252), cPermiso.enuBinario.Si, cPermiso.enuBinario.No)
                lPermiso.Supervisa = IIf(info.Item.SubItems(7).Text = Chr(252), cPermiso.enuBinario.Si, cPermiso.enuBinario.No)
                lPermiso.Admin = IIf(info.Item.SubItems(8).Text = Chr(252), cPermiso.enuBinario.Si, cPermiso.enuBinario.No)

                subGuardarCambios()

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmCfgPermisosConsulta.lvwConsulta_MouseDoubleClick")
            gAdmin.Log.fncGrabarLogERR("Error en frmCfgPermisosConsulta.lvwConsulta_MouseDoubleClick:" & ex.Message)
        End Try
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub subGuardarCambios()
        Dim lItem As ListViewItem = Nothing
        Dim lPermiso As cPermiso = Nothing

        Try

            'aca deberia recoorrere la grilla y guardar los cambios.
            For Each lItem In lvwConsulta.Items
                lPermiso = DirectCast(lItem.Tag, cPermiso)
                lPermiso.Guardar()
            Next

            'Actualizo los permisos del usuario actual.
            gAdmin.User.Actualizar_Permisos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmCfgPermisosConsulta.subGuardarCambios")
            gAdmin.Log.fncGrabarLogERR("Error en frmCfgPermisosConsulta.subGuardarCambios:" & ex.Message)
        End Try
    End Sub

End Class