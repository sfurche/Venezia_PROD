Imports VzTesoreria
Imports VzAdmin

Public Class frmTesoLiquidacionesCons
    Inherits FrmBase

    Private Sub frmTesoLiquidacionesCons_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            dtpFechaD.Value = Date.Today
            dtpFechaH.Value = Date.Today

            SubCargarGrilla()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesCons.frmTesoLiquidacionesCons_Load")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesCons.frmTesoLiquidacionesCons_Load:" & ex.Message)
        End Try
    End Sub

    Private Sub SubSetCabecera()
        Try

            lvwConsulta.BeginUpdate()
            lvwConsulta.Clear()

            ' Add columns using the ColHeader class. The fourth    
            ' parameter specifies true for an ascending sort order.
            lvwConsulta.Columns.Add(New ColHeader("Id_Liq", 70, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("Fecha", 80, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("Vendedor", 130, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("Total", 80, HorizontalAlignment.Right, True))
            lvwConsulta.Columns.Add(New ColHeader("Cash", 80, HorizontalAlignment.Right, True))
            lvwConsulta.Columns.Add(New ColHeader("Cheques", 80, HorizontalAlignment.Right, True))
            lvwConsulta.Columns.Add(New ColHeader("Retenciones", 80, HorizontalAlignment.Right, True))
            lvwConsulta.Columns.Add(New ColHeader("Transf", 80, HorizontalAlignment.Right, True))
            lvwConsulta.Columns.Add(New ColHeader("NC", 80, HorizontalAlignment.Right, True))
            lvwConsulta.Columns.Add(New ColHeader("Estado", 80, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("Observaciones", 200, HorizontalAlignment.Center, True))

            ' Connect the ListView.ColumnClick event to the ColumnClick event handler.
            AddHandler Me.lvwConsulta.ColumnClick, AddressOf lvwConsulta_ColumnClick

            lvwConsulta.EndUpdate()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesCons.SubSetCabecera")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesCons.SubSetCabecera:" & ex.Message)
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

    Private Sub SubCargarGrilla()
        Dim lItem As ListViewItem
        Dim lLiq As cLiquidacion
        Dim lArrayLiq As ArrayList

        Try
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            lArrayLiq = cLiquidacion.GetLiquidacionesxFecDH(gAdmin, dtpFechaD.Value, dtpFechaH.Value)

            lvwConsulta.BeginUpdate()
            lvwConsulta.Clear()
            SubSetCabecera()
            For Each lLiq In lArrayLiq
                lItem = New ListViewItem
                lItem.Text = lLiq.Id_Liquidacion
                lItem.SubItems.Add(cFunciones.gFncConvertDateToString(lLiq.Fecha, "DD/MM/YYYY"))
                lItem.SubItems.Add(lLiq.Vendedor.Nombre.Trim)
                lItem.SubItems.Add("$" & lLiq.TotalLiq)
                lItem.SubItems.Add("$" & lLiq.Importe_Cash)
                lItem.SubItems.Add("$" & lLiq.Importe_Cheques)
                lItem.SubItems.Add("$" & lLiq.Importe_Retenciones)
                lItem.SubItems.Add("$" & lLiq.Importe_Transferencias)
                lItem.SubItems.Add("$" & lLiq.Importe_NCredito)
                lItem.SubItems.Add(lLiq.Estado.Estado)
                lItem.Tag = lLiq
                If lLiq.Estado.Id_Estado = 0 Then  'ESTADO INCOMPLETA
                    lItem.ForeColor = Color.Red
                ElseIf lLiq.Estado.Id_Estado = 1 Then 'ESTADO COMPLETA
                    lItem.ForeColor = Color.Blue
                ElseIf lLiq.Estado.Id_Estado = 2 Then     'ESTADO CONCILIADA
                    lItem.ForeColor = Color.Green
                End If
                lvwConsulta.Items.Add(lItem)
            Next

            lvwConsulta.EndUpdate()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesCons.SubCargarGrilla")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesCons.SubCargarGrilla:" & ex.Message)
        End Try
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try

            SubCargarGrilla()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesCons.btnBuscar_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesCons.btnBuscar_Click:" & ex.Message)
        End Try
    End Sub

    Private Sub dtpFechaD_KeyUp(sender As Object, e As KeyEventArgs) Handles dtpFechaD.KeyUp
        Select Case e.KeyCode
            Case Keys.Enter
                btnBuscar_Click(sender, e)
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub dtpFechaH_KeyUp(sender As Object, e As KeyEventArgs) Handles dtpFechaH.KeyUp
        Select Case e.KeyCode
            Case Keys.Enter
                btnBuscar_Click(sender, e)
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub lvwConsulta_DoubleClick(sender As Object, e As EventArgs) Handles lvwConsulta.DoubleClick
        Dim lModo As FrmBase.EnuOPERACION = EnuOPERACION.MODIF
        Try
            If lvwConsulta.SelectedItems.Count = 0 Then
                Exit Sub
            End If
            Dim lLiq As cLiquidacion = cLiquidacion.GetLiquidacionesxId(gAdmin, (DirectCast(lvwConsulta.SelectedItems(0).Tag, cLiquidacion).Id_Liquidacion))
            lvwConsulta.SelectedItems(0).Tag = lLiq
            If lLiq.Estado.Id_Estado = cLiquidacion.enuEstadoLiq.Conciliada Then
                lModo = EnuOPERACION.CONS
            End If
            If lLiq.Fecha < Date.Today Then 'Es una liquidacion historica
                lModo = EnuOPERACION.CONS
            End If
            DirectCast(MdiParent, frmPrincipal).SubArirLiquidacion(DirectCast(lvwConsulta.SelectedItems(0).Tag, cLiquidacion), Me, lModo)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error en frmTesoLiquidacionesCons.btnAbrir_Click")
        End Try
    End Sub

    Private Sub lvwConsulta_KeyUp(sender As Object, e As KeyEventArgs) Handles lvwConsulta.KeyUp
        Select Case e.KeyCode
            Case Keys.Enter
                lvwConsulta_DoubleClick(sender, e)
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub frmTesoLiquidacionesCons_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        Try

            SubCargarGrilla()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesCons.frmTesoLiquidacionesCons_GotFocus")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesCons.frmTesoLiquidacionesCons_GotFocus:" & ex.Message)
        End Try
    End Sub

End Class