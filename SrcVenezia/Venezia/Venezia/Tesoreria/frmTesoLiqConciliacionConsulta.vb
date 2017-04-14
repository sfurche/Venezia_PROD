Imports VzAdmin
Imports VzTesoreria

Public Class frmTesoLiqConciliacionConsulta

    Private Sub frmTesoLiqConciliacionConsulta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            '----------------------------------P-E-R-M-I-S-O-S---------------------------------------------------
            SetPermisos()
            '---------------------------------------------------------------------------------------------------

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            SubCargarGrilla()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiqConciliacionConsulta.frmTesoLiqConciliacionConsulta_Load")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiqConciliacionConsulta.frmTesoLiqConciliacionConsulta_Load:" & ex.Message)
        End Try
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub SetPermisos()
        Dim lPermiso As cPermiso = Nothing
        Try

            lPermiso = gAdmin.User.GetPermiso("TESO_LIQ: Consulta de Conciliacion de Liquidacion")

            'Si es admin hace tiene permiso pleno.
            If lPermiso.Admin = cPermiso.enuBinario.Si Then
                Exit Sub
            End If

            If Not (lPermiso.Admin = cPermiso.enuBinario.Si Or lPermiso.Consulta = cPermiso.enuBinario.Si) Then
                MsgBox("No tiene permisos para acceder a esta opcion.", vbExclamation, "Acceso denegado")
                Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiqConciliacionConsulta.SetPermisos")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiqConciliacionConsulta.SetPermisos:" & ex.Message)
        End Try
    End Sub

    Private Sub SubSetCabecera()
        Try

            ' Add columns using the ColHeader class. The fourth    
            ' parameter specifies true for an ascending sort order.
            lvwConsulta.Columns.Add(New ColHeader("Tipo", 60, HorizontalAlignment.Left, True))
            lvwConsulta.Columns.Add(New ColHeader("CompNro", 100, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("FecEmi", 80, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("Importe", 100, HorizontalAlignment.Right, True))
            lvwConsulta.Columns.Add(New ColHeader("Imputacion", 100, HorizontalAlignment.Right, True))
            lvwConsulta.Columns.Add(New ColHeader("Aplicacion", 80, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("Usuario", 100, HorizontalAlignment.Left, True))

            ' Connect the ListView.ColumnClick event to the ColumnClick event handler.
            AddHandler Me.lvwConsulta.ColumnClick, AddressOf lvwConsulta_ColumnClick

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiqConciliacionConsulta.SubSetCabecera")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiqConciliacionConsulta.SubSetCabecera:" & ex.Message)
        End Try
    End Sub

    Private Sub SubCargarGrilla()
        Dim lItem As ListViewItem
        Dim lDt As DataTable = Nothing
        Dim lDr As DataRow = Nothing

        Try
            If txtCriterioBusq.Text = "" Then
                Exit Sub
            End If

            If Not IsNumeric(txtCriterioBusq.Text.Trim) Then
                MsgBox("El Id de la Liquidacion debe ser numerico.", MsgBoxStyle.Exclamation, "Error de busqueda")
                Exit Sub
            End If

            lDt = cConciliacionLiq.Dat_GetConsultaDeConciliacionLiquidacion(gAdmin, txtCriterioBusq.Text.Trim)

            If IsNothing(lDt) Then
                Exit Sub
            End If

            If lDt.Rows.Count = 0 Then
                MsgBox("No se encontro la conciliacion para ese id de liquidacion. Revise los datos ingrsados.", MsgBoxStyle.Exclamation, "Sin informacion")
            End If

            lvwConsulta.BeginUpdate()
            lvwConsulta.Clear()
            SubSetCabecera()

            For Each lDr In lDt.Rows
                lItem = New ListViewItem
                lItem.Text = lDr("Tipo")
                lItem.SubItems.Add(lDr("CompNro"))
                lItem.SubItems.Add(cFunciones.gFncConvertDateToString(lDr("FecEmi"), "DD/MM/YYYY"))
                lItem.SubItems.Add(Decimal.Parse(lDr("Importe")).ToString("C"))
                lItem.SubItems.Add(Decimal.Parse(lDr("Imputacion")).ToString("C"))
                lItem.SubItems.Add(lDr("Aplicacion"))
                lItem.SubItems.Add(lDr("Usuario"))
                lvwConsulta.Items.Add(lItem)
            Next

            lvwConsulta.EndUpdate()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiqConciliacionConsulta.SubCargarGrilla")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiqConciliacionConsulta.SubCargarGrilla: " & ex.Message)
        End Try

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        SubCargarGrilla()
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

    Private Sub txtCriterioBusq_KeyUp(sender As Object, e As KeyEventArgs) Handles txtCriterioBusq.KeyUp
        Select Case e.KeyCode
            Case Keys.Enter
                btnBuscar_Click(sender, e)
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

End Class
