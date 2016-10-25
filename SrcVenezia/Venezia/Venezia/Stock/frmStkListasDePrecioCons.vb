Imports VzAdmin
Imports vzStock

Public Class frmStkListasDePrecioCons
    Private Sub frmStkListasDePrecioCons_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            SubCargarGrilla()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkListasDePrecioCons.frmStkListasDePrecioCons_Load")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkListasDePrecioCons.frmStkListasDePrecioCons_Load:" & ex.Message)
        End Try
    End Sub
    Private Sub SubSetCabecera()
        Try

            ' Add columns using the ColHeader class. The fourth    
            ' parameter specifies true for an ascending sort order.
            lvwConsulta.Columns.Add(New ColHeader("Codigo", 60, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("Descripcion", 300, HorizontalAlignment.Left, True))
            lvwConsulta.Columns.Add(New ColHeader("FVig", 80, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("FVto", 80, HorizontalAlignment.Center, True))

            ' Connect the ListView.ColumnClick event to the ColumnClick event handler.
            AddHandler Me.lvwConsulta.ColumnClick, AddressOf lvwConsulta_ColumnClick

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkListasDePrecioCons.SubSetCabecera")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkListasDePrecioCons.SubSetCabecera:" & ex.Message)
        End Try
    End Sub

    Private Sub SubCargarGrilla()
        Dim lItem As ListViewItem
        Dim lLista As cListaPrecios = Nothing
        Dim lArray As ArrayList

        Try
            If txtCriterioBusq.Text = "" Then
                lArray = cListaPrecios.GetAllListasDePrecios(gAdmin)
            Else
                lArray = cListaPrecios.GetListasDePreciosxConsulta(gAdmin, txtCriterioBusq.Text.Trim)
            End If

            lvwConsulta.BeginUpdate()
            lvwConsulta.Clear()
            SubSetCabecera()
            For Each lLista In lArray
                lItem = New ListViewItem
                lItem.Text = lLista.CodLista
                lItem.SubItems.Add(lLista.Descripcion)
                lItem.SubItems.Add(cFunciones.gFncConvertDateToString(lLista.FVig, "DD/MM/YYYY"))
                lItem.SubItems.Add(cFunciones.gFncConvertDateToString(lLista.FVto, "DD/MM/YYYY"))
                lItem.Tag = lLista
                lvwConsulta.Items.Add(lItem)
            Next

            lvwConsulta.EndUpdate()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkListasDePrecioCons.SubCargarGrilla")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkListasDePrecioCons.SubCargarGrilla:" & ex.Message)
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


