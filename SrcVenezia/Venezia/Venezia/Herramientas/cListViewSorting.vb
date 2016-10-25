Imports System.Globalization

Public Class cListViewSorting

End Class

' An instance of the SortWrapper class is created for 
' each item and added to the ArrayList for sorting.
Public Class SortWrapper
    Friend sortItem As ListViewItem
    Friend sortColumn As Integer

    ' A SortWrapper requires the item and the index of the clicked column.
    Public Sub New(ByVal Item As ListViewItem, ByVal iColumn As Integer)
        sortItem = Item
        sortColumn = iColumn
    End Sub

    ' Text property for getting the text of an item.
    Public ReadOnly Property [Text]() As String
        Get
            Return sortItem.SubItems(sortColumn).Text
        End Get
    End Property

    ' Implementation of the IComparer 
    ' interface for sorting ArrayList items.
    Public Class SortComparer
        Implements IComparer
        Private ascending As Boolean

        ' Constructor requires the sort order;
        ' true if ascending, otherwise descending.
        Public Sub New(ByVal asc As Boolean)
            Me.ascending = asc
        End Sub


        ' Implemnentation of the IComparer:Compare 
        ' method for comparing two objects.
        Public Function [Compare](ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
            Dim xItem As SortWrapper = CType(x, SortWrapper)
            Dim yItem As SortWrapper = CType(y, SortWrapper)

            Dim xText As String = xItem.sortItem.SubItems(xItem.sortColumn).Text
            Dim yText As String = yItem.sortItem.SubItems(yItem.sortColumn).Text

            Dim xNum As Double
            Dim yNum As Double
            Dim xDate As Date
            Dim yDate As Date

            If IsNumeric(xText) And IsNumeric(yText) Then
                'Saco los signos para que pueda comparar
                xText = xText.Replace("$", "")
                xText = xText.Replace("%", "")
                yText = yText.Replace("$", "")
                yText = yText.Replace("%", "")

                xNum = Double.Parse(xText)
                yNum = Double.Parse(yText)
                Return xNum.CompareTo(yNum) * IIf(Me.ascending, 1, -1)


            ElseIf Date.TryParseExact(xText, "dd/MM/yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, xDate) _
                And Date.TryParseExact(yText, "dd/MM/yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, yDate) Then
                '   ElseIf Date.TryParse(xText, xDate) And Date.TryParse(yText, yDate) Then
                Return xDate.CompareTo(yDate) * IIf(Me.ascending, 1, -1)

            Else ' Si no comparo como texto
                Return xText.CompareTo(yText) * IIf(Me.ascending, 1, -1)
            End If

        End Function
    End Class
End Class

' The ColHeader class is a ColumnHeader object with an 
' added property for determining an ascending or descending sort.
' True specifies an ascending order, false specifies a descending order.
Public Class ColHeader
    Inherits ColumnHeader
    Public ascending As Boolean

    Public Sub New(ByVal [text] As String, ByVal width As Integer, ByVal align As HorizontalAlignment, ByVal asc As Boolean)
        Me.Text = [text]
        Me.Width = width
        Me.TextAlign = align
        Me.ascending = asc
    End Sub
End Class