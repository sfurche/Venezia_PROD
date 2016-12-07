﻿Imports System.IO
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
            End If


            LoadArchivoPrecios(lPath)

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

            For Each lTxtRow In ArrText
                lItem = New ListViewItem
                If Not lTxtRow(0).ToString.Trim = "" Then
                    lItem.Text = lTxtRow(0).ToString.Trim
                    lItem.SubItems.Add(lTxtRow(1).ToString.Replace(",", "").Replace(".", ",").Trim)
                    lItem.SubItems.Add("")
                    lItem.SubItems.Add("")
                    lItem.SubItems.Add("")
                    lItem.SubItems.Add("")
                    lItem.SubItems.Add("")
                    lItem.SubItems.Add("")
                    lvwConsulta.Items.Add(lItem)
                End If
            Next


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkCargaPrecios.LoadArchivoPrecios")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkCargaPrecios.LoadArchivoPrecios:" & ex.Message)
            'SubSetCabecera() ' Si falla borro la grilla.
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
            lvwConsulta.Columns.Add(New ColHeader("CodProd", 80, HorizontalAlignment.Center, True))
            lvwConsulta.Columns.Add(New ColHeader("Articulo", 250, HorizontalAlignment.Left, True))
            lvwConsulta.Columns.Add(New ColHeader("Costo", 70, HorizontalAlignment.Right, True))
            lvwConsulta.Columns.Add(New ColHeader("PcioHoy", 70, HorizontalAlignment.Right, True))
            lvwConsulta.Columns.Add(New ColHeader("PcioNuevo", 70, HorizontalAlignment.Right, True))
            lvwConsulta.Columns.Add(New ColHeader("%Var", 70, HorizontalAlignment.Right, True))

            lvwConsulta.EndUpdate()

            ' Connect the ListView.ColumnClick event to the ColumnClick event handler.
            AddHandler Me.lvwConsulta.ColumnClick, AddressOf lvwConsulta_ColumnClick

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkCargaPrecios.SubSetCabecera")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkCargaPrecios.SubSetCabecera:" & ex.Message)
        End Try
    End Sub

End Class


