Imports VzTesoreria
Imports VzComercial
Imports VzAdmin

Public Class frmTesoLiqConciliacion

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim lRecibos As ArrayList = Nothing
        Dim lLiq As cLiquidacion = Nothing
        Dim lItem As ListViewItem = Nothing
        Dim lComment As cComment = Nothing
        Dim lComentario As String = ""

        Try
            '---------------------------VALIDACIONES ---------------------------------

            If lvwConsulta.CheckedItems.Count = 0 Or IsNothing(cmbLiquidacion.SelectedItem) Then
                MsgBox("Debe seleccionar los recibos para conciliar la liquidacion", MsgBoxStyle.Exclamation, "Error de validacion")
                Exit Sub
            End If

            If picConciliaExacta.Visible = False Then
                MsgBox("La liquidacion no se puede conciliar porque la diferencia es mayor a la permitida.", MsgBoxStyle.Exclamation, "Error al conciliar")
                Exit Sub
            End If

            If Not Double.Parse(lblResta.Text) = 0 Then
                If MsgBox("Esta seguro que desea conciliar con una diferenia de $" & lblResta.Text.Trim & " ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Exit Sub
                Else
                    lComentario = InputBox("Ingrese un comentario para justificar la conciliacion con diferencia:", "Comentario")

                    lComment = New cComment(gAdmin)
                    lComment.Text = lComentario.Trim
                    lComment.Tabla = "vz_liquidaciones"
                    lComment.Evento = "Conciliacion con Diferencia"
                    lComment.Id_Objeto = DirectCast(cmbLiquidacion.SelectedItem, cLiquidacion).Id_Liquidacion
                    lComment.User = gAdmin.User
                    lComment.Guardar()
                End If
            End If

            '----------------------------------------------------------

            lRecibos = New ArrayList
            lLiq = cmbLiquidacion.SelectedItem
            For Each lItem In lvwConsulta.CheckedItems
                lRecibos.Add(lItem.Tag) 'Agrego los recibos en el arraylist
            Next

            lLiq.Conciliar(lRecibos)

            MsgBox("Conciliacion exitosa !", vbInformation, "Conciliacion Ok")

            'Recargo los datos.
            subCargarLiquidaciones()
            subCargarRecibos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiqConciliacion.btnAceptar_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiqConciliacion.btnAceptar_Click:" & ex.Message)
        End Try

    End Sub

    Private Sub frmTesoLiqConciliacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Tag = "CONCILIACIONLIQUIDACION"

            subCargarLiquidaciones()
            subCargarRecibos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiqConciliacion.frmTesoLiqConciliacion_Load")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiqConciliacion.frmTesoLiqConciliacion_Load:" & ex.Message)
        End Try
    End Sub

    Private Sub SubSetCabecera()
        Try
            lvwConsulta.BeginUpdate()
            lvwConsulta.Clear()

            lvwConsulta.Columns.Add(New ColHeader("X", 40, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("NroComp", 100, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("TipoComp", 120, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("Cliente", 200, HorizontalAlignment.Left, True))
            lvwConsulta.Columns.Add(New ColHeader("Fec_Emision", 80, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("Importe", 80, HorizontalAlignment.Right, True))
            lvwConsulta.Columns.Add(New ColHeader("Zona", 140, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("Fec_Carga", 80, HorizontalAlignment.Center, True))

            ' Connect the ListView.ColumnClick event to the ColumnClick event handler.
            AddHandler Me.lvwConsulta.ColumnClick, AddressOf lvwConsulta_ColumnClick

            lvwConsulta.EndUpdate()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiqConciliacion.SubSetCabecera")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiqConciliacion.SubSetCabecera:" & ex.Message)
        End Try
    End Sub

    Private Sub subCargarRecibos()
        Dim lItem As ListViewItem
        Dim lRecibo As cDeudor = Nothing
        Dim lArrayRecibos As ArrayList = Nothing
        Dim lSum As Decimal = 0
        Try

            lblTotalLiq.Text = "$ 0"

            SubSetCabecera()
            If IsNothing(cmbLiquidacion.SelectedItem) Then
                lArrayRecibos = cDeudor.GetRecibosxConciliar(gAdmin)
            Else
                lArrayRecibos = cDeudor.GetRecibosxConciliarxVen(gAdmin, DirectCast(cmbLiquidacion.SelectedItem, cLiquidacion).Vendedor.IdVendedor, chkAllVen.Checked, chkRecHist.Checked)
            End If

            If Not IsNothing(lArrayRecibos) Then

                For Each lRecibo In lArrayRecibos
                    lItem = New ListViewItem()
                    lItem.Text = " "
                    lItem.SubItems.Add(lRecibo.CompNro)
                    lItem.SubItems.Add(lRecibo.Descripcion.Trim)
                    lItem.SubItems.Add(lRecibo.Cliente.Nombre)
                    lItem.SubItems.Add(cFunciones.gFncConvertDateToString(lRecibo.FecEmi, "DD/MM/YYYY"))

                    'Si es una nota de credito y el valor es negativo, lo pongo en positivo para que sume a los comprobantes conciliados.
                    If lRecibo.TotalComp < 0 Then
                        lRecibo.TotalComp = lRecibo.TotalComp * -1
                    End If

                    lItem.SubItems.Add(lRecibo.TotalComp)
                    lItem.SubItems.Add(lRecibo.CodZona.Nombre)
                    lItem.SubItems.Add(cFunciones.gFncConvertDateToString(lRecibo.FecOp, "DD/MM/YYYY"))
                    lItem.Tag = lRecibo
                    lvwConsulta.Items.Add(lItem)
                    lSum = lSum + lRecibo.TotalComp
                Next
            End If
            lblTotalLiq.Text = "0"

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiqConciliacion.subCargarRecibos")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiqConciliacion.subCargarRecibos:" & ex.Message)
        End Try
    End Sub

    Private Sub subCargarLiquidaciones()
        Dim lArray As ArrayList
        Dim lLiq As cLiquidacion = Nothing
        Try
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            cmbLiquidacion.Items.Clear()

            lArray = cLiquidacion.GetLiquidacionesxConciliar(gAdmin)

            For Each lLiq In lArray
                cmbLiquidacion.Items.Add(lLiq)
                cmbLiquidacion.DisplayMember = "DisplayName"
            Next

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesAlta.subCargarLiquidaciones")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesAlta.subCargarLiquidaciones:" & ex.Message)
        End Try
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub cmbLiquidacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLiquidacion.SelectedIndexChanged
        Try
            subCargarRecibos()
            subSumarTildados()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesAlta.cmbLiquidacion_SelectedIndexChanged")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesAlta.cmbLiquidacion_SelectedIndexChanged:" & ex.Message)
        End Try
    End Sub

    Public Sub subSumarTildados()
        Dim lItem As ListViewItem = Nothing
        Dim lSum As Double = 0
        Dim lResta As Double = 0
        Dim lMaxDif As Double = 0
        Try
            If IsNothing(cmbLiquidacion.SelectedItem) Then
                lblResta.Text = "0"
                lblTotalLiq.Text = "0"
                picConciliaExacta.Visible = False
                Exit Sub
            End If

            lMaxDif = Double.Parse(cSetting.GetSettingxCodigo(gAdmin, "TesoLiqCons_MaxAjuste").Valor)

            For Each lItem In lvwConsulta.Items
                If lItem.Checked Then
                    lSum = lSum + DirectCast(lItem.Tag, cDeudor).TotalComp
                End If
            Next
            lblTotalLiq.Text = lSum.ToString

            lResta = DirectCast(cmbLiquidacion.SelectedItem, cLiquidacion).TotalLiq - lSum
            lblResta.Text = Math.Round(lResta, 2).ToString

            If lMaxDif >= Math.Abs(lResta) Then
                picConciliaExacta.Visible = True
            Else
                picConciliaExacta.Visible = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesAlta.subSumarTildados")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesAlta.subSumarTildados:" & ex.Message)
        End Try
    End Sub

    Public Sub CheckAll()

        Dim lItem As ListViewItem = Nothing
        Dim lSum As Double = 0
        Try
            For Each lItem In lvwConsulta.Items
                If lItem.Checked = True Then
                    lItem.Checked = False
                Else
                    lItem.Checked = True
                    lSum = lSum + DirectCast(lItem.Tag, cDeudor).TotalComp
                End If
            Next
            lblTotalLiq.Text = lSum.ToString

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesAlta.CheckAll")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesAlta.CheckAll:" & ex.Message)
        End Try
    End Sub

    Private Sub lvwRecibos_ItemChecked(sender As Object, e As ItemCheckedEventArgs) Handles lvwConsulta.ItemChecked
        Try
            subSumarTildados()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesAlta.lvwRecibos_ItemChecked")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesAlta.lvwRecibos_ItemChecked:" & ex.Message)
        End Try
    End Sub

    Private Sub lvwConsulta_ColumnClick(ByVal sender As Object, ByVal e As ColumnClickEventArgs)

        If e.Column = 0 Then 'Si es la columna X es solo para el check all, cancelo el reordenamiento.
            CheckAll()
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

    End Sub

    Private Sub chkRecHist_CheckedChanged(sender As Object, e As EventArgs) Handles chkRecHist.CheckedChanged
        subCargarRecibos()
    End Sub

    Private Sub chkAllVen_CheckedChanged(sender As Object, e As EventArgs) Handles chkAllVen.CheckedChanged
        subCargarRecibos()
    End Sub

    Private Sub btnAplicarParcial_Click(sender As Object, e As EventArgs) Handles btnAplicarParcial.Click
        Dim lItem As ListViewItem = Nothing
        Dim lInputValue As String = ""
        Dim lNewValue As Double = 0
        Try
            If lvwConsulta.SelectedItems.Count = 0 Then
                MsgBox("Debe seleccionar el item que desea aplicar parcialmente.", MsgBoxStyle.Exclamation, "No selecciono item")
                Exit Sub
            Else
                lItem = lvwConsulta.SelectedItems(0)
            End If

            lInputValue = InputBox("Ingrese el importe parcial que desea aplicar sobre el item seleccionado:", "Importe pacial")

            If Not Double.TryParse(lInputValue, lNewValue) Then
                MsgBox("El valor ingresado no es numerico.", MsgBoxStyle.Exclamation, "Error de validacion")
                Exit Sub
            ElseIf DirectCast(lItem.Tag, cDeudor).TotalComp <= lNewValue Then
                MsgBox("El valor ingresado debe ser menor al importe del comprobante.", MsgBoxStyle.Exclamation, "Error de validacion")
                Exit Sub
            Else
                lvwConsulta.BeginUpdate()
                DirectCast(lItem.Tag, cDeudor).Aplicacion = "P"
                DirectCast(lItem.Tag, cDeudor).TotalComp = lNewValue
                lItem.SubItems(5).Text = lNewValue.ToString
                lItem.BackColor = Color.GreenYellow
                lItem.Checked = True
                lvwConsulta.EndUpdate()
            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesAlta.btnAplicarParcial_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesAlta.btnAplicarParcial_Click:" & ex.Message)
        End Try
    End Sub
End Class