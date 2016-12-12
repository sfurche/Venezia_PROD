Imports System.Globalization
Imports System.IO
Imports VzAdmin
Imports vzStock

Public Class frmStkCargaPrecios
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub subCargarCombo()
        Dim lArray As ArrayList
        Dim lLista As cListaPrecios = Nothing
        Try
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            cmbListaPrecios.Items.Clear()

            lArray = cListaPrecios.GetAllListasDePrecios(gAdmin)

            cmbListaPrecios.Items.Add(" ")
            cmbListaPrecios.Items.Add("COSTO")
            For Each lLista In lArray
                cmbListaPrecios.Items.Add(lLista)
            Next
            cmbListaPrecios.DisplayMember = "Descripcion"
            cmbListaPrecios.SelectedItem = " "

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkCargaPrecios.subCargarCombo")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkCargaPrecios.subCargarCombo:" & ex.Message)
        End Try
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub frmStkCargaPrecios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            subCargarCombo()
            SubSetCabecera()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkCargaPrecios.frmStkCargaPrecios_Load")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkCargaPrecios.frmStkCargaPrecios_Load:" & ex.Message)
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
                lblPath.Text = lPath
                LoadArchivoPrecios(lPath)
            Else
                lblPath.Text = "___________________________________________________"
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkCargaPrecios.imgAbrir_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkCargaPrecios.imgAbrir_Click:" & ex.Message)
        End Try
    End Sub

    Private Sub LoadArchivoPrecios(ByVal pFilePath As String)
        Dim objReader As New StreamReader(pFilePath)
        Dim sLine As String = ""
        Dim ArrText As New ArrayList()
        Dim lItem As ListViewItem = Nothing
        Dim lTxtRow As String() = Nothing
        Dim lCant As Integer = 0
        Dim lSepDec As String = ""
        Dim lSepMiles As String = ""
        Dim lNuevoValor As Double = 0
        'Cargo el separador decimal que necesita el sistema.
        Dim lSysSepDec As String = CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator
        Try
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
                    lItem.Text = lTxtRow(0).ToString.Trim
                    Double.TryParse(lTxtRow(1).ToString().Replace(lSepMiles, "").Replace(lSepDec, lSysSepDec).Trim, lNuevoValor)
                    lItem.SubItems.Add(lNuevoValor.ToString("C"))
                    lItem.SubItems.Add("")
                    lItem.SubItems.Add("")
                        lItem.SubItems.Add("")
                        lItem.SubItems.Add("")
                        lItem.SubItems.Add("")
                    lItem.SubItems.Add("")
                    lItem.SubItems.Add("")
                    lvwConsulta.Items.Add(lItem)
                        lCant = lCant + 1
                    End If
            Next

            lblTotalImp.Text = "Total Importados: " & lCant.ToString

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkCargaPrecios.LoadArchivoPrecios")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkCargaPrecios.LoadArchivoPrecios:" & ex.Message)
            SubSetCabecera() ' Si falla borro la grilla.
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

    Private Sub SubSetCabecera()
        Try

            ' Add columns using the ColHeader class. The fourth    
            ' parameter specifies true for an ascending sort order.
            lvwConsulta.BeginUpdate()
            lvwConsulta.Clear()

            lvwConsulta.Columns.Add(New ColHeader("CodArt", 60, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("NuevoValor", 70, HorizontalAlignment.Right, True))
            'lvwConsulta.Columns.Add(New ColHeader("CodProd", 80, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("Articulo", 250, HorizontalAlignment.Left, True))
            lvwConsulta.Columns.Add(New ColHeader("Costo", 65, HorizontalAlignment.Right, True))
            lvwConsulta.Columns.Add(New ColHeader("PcioHoy", 70, HorizontalAlignment.Right, True))
            lvwConsulta.Columns.Add(New ColHeader("%Var", 65, HorizontalAlignment.Right, True))
            lvwConsulta.Columns.Add(New ColHeader("%Utilidad", 70, HorizontalAlignment.Right, True))
            lvwConsulta.Columns.Add(New ColHeader("Procesado", 80, HorizontalAlignment.Center, True))

            lvwConsulta.EndUpdate()

            'Ajusto contadores
            lblTotalImp.Text = "Total Importados: 0"
            lblProcOK.Text = "Procesados OK: 0"
            lblProcErr.Text = "Procesados con ERROR: 0"

            ' Connect the ListView.ColumnClick event to the ColumnClick event handler.
            AddHandler Me.lvwConsulta.ColumnClick, AddressOf lvwConsulta_ColumnClick

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkCargaPrecios.SubSetCabecera")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkCargaPrecios.SubSetCabecera:" & ex.Message)
        End Try
    End Sub

    Private Sub btnSimular_Click(sender As Object, e As EventArgs) Handles btnSimular.Click
        Dim lOK As Integer = 0
        Dim lErr As Integer = 0
        Dim lItem As ListViewItem = Nothing
        Dim lArt As cArticulo = Nothing
        Dim lPrecio As cListaPreciosDet = Nothing
        Dim lCodArt As Integer = 0
        Dim lPrecioNuevo As Double = 0
        Dim lUtil As Double = 0
        Dim lVar As Double = 0

        Try
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            '------------------------------------------------------------------------------------------------
            If btnSimular.Text = "Simular" Then
                If cmbListaPrecios.SelectedItem.ToString.Trim = "" Then
                    MsgBox("Debe seleccionar la lista de precios que desea procesar.", MsgBoxStyle.Exclamation, "Falta lista de precios")
                    Exit Sub
                End If

                For Each lItem In lvwConsulta.Items

                    If Not IsNumeric(lItem.Text.Trim) Or (Not lItem.Text.Trim.Length = 5) Then 'Si el codigo de articulo no es numerico genero error
                        lItem.SubItems(2).Text = "Codigo de articulo no valido."
                        lItem.ForeColor = Color.Red
                        lItem.Tag = "Error"
                        lErr = lErr + 1
                    ElseIf Not IsNumeric(lItem.SubItems(1).Text.Trim) Then 'Si el precio nuevo no es numerico genero error
                        lItem.SubItems(2).Text = "Codigo de articulo no valido."
                        lItem.Tag = "Error"
                        lItem.ForeColor = Color.Red
                        lErr = lErr + 1
                    Else
                        lCodArt = Integer.Parse(lItem.Text.Substring(1, 4))

                        'Si pasa todas las validaciones voy a buscar el articulo.
                        lArt = cArticulo.GetArticuloxCod(gAdmin, lCodArt)

                        If IsNothing(lArt) Then
                            lItem.SubItems(2).Text = "Codigo de articulo no valido."
                            lItem.Tag = "Error"
                            lItem.ForeColor = Color.Red
                            lErr = lErr + 1
                        Else
                            If cmbListaPrecios.SelectedItem.ToString = "COSTO" Then
                                lPrecio = Nothing
                            Else
                                lPrecio = cListaPreciosDet.GetListaPreciosDetxListaxArt(gAdmin, DirectCast(cmbListaPrecios.SelectedItem, cListaPrecios).IdLista, lArt.CodArt)
                            End If
                            lItem.Tag = "OK"
                            lItem.SubItems(2).Text = lArt.Descripcion
                            lItem.SubItems(3).Text = lArt.PcioCosto.ToString("C")  ' COSTO

                            If IsNothing(lPrecio) Then 'Valido si tiene precio en la lista.
                                lItem.SubItems(4).Text = "0" 'PRECIO HOY
                                lItem.SubItems(4).Tag = Nothing
                            Else
                                lItem.SubItems(4).Text = lPrecio.PcioUnitario.ToString("C")   'PRECIO HOY
                                lItem.SubItems(4).Tag = lPrecio
                            End If

                            lPrecioNuevo = Double.Parse(lItem.SubItems(1).Text.Replace("$", "").Trim)

                            lVar = Math.Round((lPrecioNuevo - Double.Parse(lItem.SubItems(4).Text.Replace("$", ""))) / Double.Parse(lItem.SubItems(4).Text.Replace("$", "")), 2)
                            lItem.SubItems(5).Text = lVar.ToString("P")
                            lItem.SubItems(5).Tag = lVar

                            lUtil = Math.Round((lPrecioNuevo - lArt.PcioCosto) / lArt.PcioCosto, 2)
                            lItem.SubItems(6).Text = lUtil.ToString("P")
                            lItem.SubItems(5).Tag = lUtil

                            If lVar > 0 Then
                                lItem.SubItems(4).ForeColor = Color.DarkOliveGreen
                                lItem.SubItems(5).ForeColor = Color.DarkOliveGreen
                            ElseIf lVar < 0 Then
                                lItem.SubItems(4).ForeColor = Color.Red
                                lItem.SubItems(5).ForeColor = Color.Red
                            End If

                            lOK = lOK + 1
                        End If
                    End If
                Next

                lblProcOK.Text = "Procesados OK: " & lOK.ToString
                lblProcErr.Text = "Procesados con ERROR: " & lErr.ToString

                'Cambio el boton a Procesar.
                btnSimular.Text = "Procesar"

                '------------------------------------------------------------------------------------------------
                'ACA PROCESO EL CAMBIO DE PRECIOS.
            ElseIf btnSimular.Text = "Procesar" Then
                If MsgBox("Esta seguro que desea aplicar los precios simulados?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                    Exit Sub
                End If

                For Each lItem In lvwConsulta.Items
                    lVar = lItem.SubItems(5).Tag
                    If Not lItem.Tag = "Error" Then
                        If Not lVar = 0 Then
                            If IsNothing(lItem.SubItems(4).Tag) Then
                                lPrecio = New cListaPreciosDet(gAdmin)
                                lPrecio.PcioUnitario = Double.Parse(lItem.SubItems(1).Text.Replace("$", ""))
                                lPrecio.CodLista = DirectCast(cmbListaPrecios.SelectedItem, cListaPrecios).CodLista
                                lPrecio.IdLista = DirectCast(cmbListaPrecios.SelectedItem, cListaPrecios).IdLista
                                lPrecio.PcioCaja = 0
                                lPrecio.CodProd = lItem.Text.Trim.PadLeft(4, "0")
                                lPrecio.Articulo = cArticulo.GetArticuloxCod(gAdmin, lItem.Text.Trim)
                                lPrecio.PorComision = lPrecio.Articulo.PorComis
                                lPrecio.Nuevo = True
                            Else
                                lPrecio = DirectCast(lItem.SubItems(4).Tag, cListaPreciosDet)
                                lPrecio.PcioUnitario = Double.Parse(lItem.SubItems(1).Text.Replace("$", ""))
                            End If

                            'GUARDO
                            If lPrecio.Guardar() = True Then
                                lItem.SubItems(6).Text = "OK"
                                lItem.SubItems(6).ForeColor = Color.Blue
                            Else
                                lItem.SubItems(6).Text = "NOK"
                                lItem.SubItems(6).ForeColor = Color.Red
                            End If
                        End If
                    End If
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkCargaPrecios.btnSimular_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkCargaPrecios.btnSimular_Click:" & ex.Message)
        End Try
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub
End Class


