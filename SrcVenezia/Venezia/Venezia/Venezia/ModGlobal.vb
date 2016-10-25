Imports Microsoft.Win32
Imports System.IO
Imports System.Xml
Imports VzAdmin


Module ModGlobal
    '--Seteos
    Public Const gSeteosLICENCIA As String = "LICENCIA"
    Public Const gSeteosHABILITACION As String = "SYSENABLE"
    Public Const gSeteosVERSION As String = "VERSION"
    Public Const gSeteosRMAT_LEGACY As String = "RMAT_LEGACY"
    Public Const gSeparadorCodPostal As String = "-"
    'Public gUser As VzSecurity.cUser
    'Public gLog As VzLog.cLog
    'Public gCnn As VzDBCnn.cDBCnn
    Public gAdmin As VzAdmin.cAdmin


    Public Enum TipoDato
        TEXTO = 1
        NUMERO = 2
        FECHA = 3
    End Enum


    'Public Function GetgLogInstance() As .cLog
    '    Return gLog
    'End Function

    'Public Function GetgCnnInstance() As VzDBCnn.cDBCnn
    '    Return gCnn
    'End Function

    Public Function gFncgetDbValue(ByVal pValor As Object, ByVal pTipo As TipoDato) As String
        gFncgetDbValue = ""
        If pValor Is DBNull.Value Then
            Select Case pTipo
                Case TipoDato.FECHA
                    Return Date.MinValue
                Case TipoDato.NUMERO
                    Return 0
                Case TipoDato.TEXTO
                    gFncgetDbValue = ""
            End Select
        Else
            gFncgetDbValue = CStr(pValor)
        End If

    End Function

    Public Function gFncgetObjValue(ByVal pValor As Object, ByVal pTipo As TipoDato) As Object
        gFncgetObjValue = Nothing
        Select Case pTipo
            Case TipoDato.FECHA
                If pValor = Date.MinValue Then
                    gFncgetObjValue = DBNull.Value
                Else
                    gFncgetObjValue = pValor
                End If
            Case TipoDato.NUMERO
                If pValor = 0 Then
                    gFncgetObjValue = DBNull.Value
                Else
                    gFncgetObjValue = pValor
                End If
            Case TipoDato.TEXTO
                If pValor = "" Then
                    gFncgetObjValue = DBNull.Value
                Else
                    gFncgetObjValue = pValor
                End If
        End Select

    End Function

    Public Function gFncGetXMLvalue(ByVal pNodo As String, ByVal pKey As String, ByVal pItem As Integer) As String

        Dim m_xmld As XmlDocument
        Dim m_nodelist As XmlNodeList
        Dim m_node As XmlNode
        'Dim hola As RegistryKey
        'Dim lPath As String
        Dim lValor As String = ""

        'Creamos el "XML Document"
        m_xmld = New XmlDocument

        'Cargamos el archivo (Esta funcion devuelve la carpeta del exe)
        m_xmld.Load(System.Windows.Forms.Application.StartupPath() & "\AppConfig.xml")

        m_nodelist = m_xmld.SelectNodes(pNodo)

        'Iniciamos el ciclo de lectura
        For Each m_node In m_nodelist
            lValor = m_node.ChildNodes.Item(pItem).InnerText
        Next

        Return lValor

    End Function

    Public Sub gSubGuardarFondo_registry(ByVal p_Image_Path As String, ByVal p_ImgSizeMode As Integer)

        Dim regKey As RegistryKey
        regKey = Application.UserAppDataRegistry
        regKey.SetValue("Background", p_Image_Path)
        regKey.SetValue("BackGrSizeMode", p_ImgSizeMode)
        regKey.Close()

    End Sub

    Public Function gFncGetValorFondo_Registry(ByVal p_Nombre As String) As String
        gFncGetValorFondo_Registry = ""
        Try

            Dim regKey As RegistryKey
            regKey = Application.UserAppDataRegistry

            gFncGetValorFondo_Registry = CType(regKey.GetValue(p_Nombre, ""), String)


        Catch ex As Exception
            MsgBox("Error al ingresar en la Registry", MsgBoxStyle.Critical, "Error Valor_Registry")
        End Try

    End Function

    Public Function gFncConvertStringToDate(ByVal pCadena As String, ByVal pFormato As String) As Date
        Dim Rta As String = ""
        gFncConvertStringToDate = Date.Today
        Try
            Select Case pFormato.ToUpper
                Case "YYYY/MM/DD"
                    Rta = pCadena.Substring(8, 2) & "/"
                    Rta = Rta & pCadena.Substring(5, 2) & "/"
                    Rta = Rta & pCadena.Substring(0, 4)
                Case "MM/DD/YYYY"
                    Rta = pCadena.Substring(3, 2) & "/"
                    Rta = Rta & pCadena.Substring(0, 2) & "/"
                    Rta = Rta & pCadena.Substring(6, 4)
                Case "DD/MM/YYYY"
                    Rta = Date.Parse(pCadena)
                Case "YYYYMMDD"
                    Rta = pCadena.Substring(6, 2) & "/"
                    Rta = Rta & pCadena.Substring(4, 2) & "/"
                    Rta = Rta & pCadena.Substring(0, 4)
                Case "DDMMYYYY"
                    Rta = pCadena.Substring(0, 2) & "/"
                    Rta = Rta & pCadena.Substring(2, 2) & "/"
                    Rta = Rta & pCadena.Substring(4, 4)
                Case Else
                    MsgBox("El formato que pretende compartir no es soportado por esta funcion", MsgBoxStyle.Exclamation, "Formato no soportado")
            End Select

            gFncConvertStringToDate = CDate(Rta)

        Catch ex As Exception
            MsgBox("Error al convertir fecha", MsgBoxStyle.Critical, "Error en gConvertStringToDate")

        End Try


    End Function

    Public Function gFncConvertDateToString(ByVal pFecha As Date, ByVal pFormato As String) As String
        Dim Rta As String = ""
        gFncConvertDateToString = ""
        Try
            Select Case pFormato.ToUpper
                Case "YYYY/MM/DD"
                    Rta = pFecha.Year.ToString("0000") & "/"
                    Rta = Rta & pFecha.Month.ToString("00") & "/"
                    Rta = Rta & pFecha.Day.ToString("00")
                Case "MM/DD/YYYY"
                    Rta = pFecha.Month.ToString("00") & "/"
                    Rta = Rta & pFecha.Day.ToString("00") & "/"
                    Rta = Rta & pFecha.Year.ToString("0000")
                Case "DD/MM/YYYY"
                    Rta = pFecha.Day.ToString("00") & "/"
                    Rta = Rta & pFecha.Month.ToString("00") & "/"
                    Rta = Rta & pFecha.Year.ToString("0000")
                Case "DD/MM/YY"
                    Rta = pFecha.Day.ToString("00") & "/"
                    Rta = Rta & pFecha.Month.ToString("00") & "/"
                    Rta = Rta & Right(pFecha.Year.ToString(), 2)
                Case "YY/MM/DD"
                    Rta = Right(pFecha.Year.ToString(), 2) & "/"
                    Rta = Rta & pFecha.Month.ToString("00") & "/"
                    Rta = Rta & pFecha.Day.ToString("00")
                Case "MM/DD/YY"
                    Rta = pFecha.Month.ToString("00") & "/"
                    Rta = Rta & pFecha.Day.ToString("00") & "/"
                    Rta = Rta & Right(pFecha.Year.ToString(), 2)
                Case "YYYYMMDD"
                    Rta = pFecha.Year.ToString("0000")
                    Rta = Rta & pFecha.Month.ToString("00")
                    Rta = Rta & pFecha.Day.ToString("00")
                Case "DDMMYYYY"
                    Rta = pFecha.Day.ToString("00")
                    Rta = Rta & pFecha.Month.ToString("00")
                    Rta = Rta & pFecha.Year.ToString("0000")
                Case "MMYYYY"
                    Rta = pFecha.Month.ToString("00")
                    Rta = Rta & pFecha.Year.ToString("0000")
                Case "DDMMYY"
                    Rta = pFecha.Day.ToString("00")
                    Rta = Rta & pFecha.Month.ToString("00")
                    Rta = Rta & Right(pFecha.Year.ToString(), 2)
                Case "YYMMDD"
                    Rta = Right(pFecha.Year.ToString(), 2)
                    Rta = Rta & pFecha.Month.ToString("00")
                    Rta = Rta & pFecha.Day.ToString("00")
                Case "MMDDYY"
                    Rta = pFecha.Month.ToString("00")
                    Rta = Rta & pFecha.Day.ToString("00")
                    Rta = Rta & Right(pFecha.Year.ToString(), 2)
                Case "MMYY"
                    Rta = pFecha.Month.ToString("00")
                    Rta = Rta & Right(pFecha.Year.ToString(), 2)
                Case Else
                    MsgBox("El formato que pretende compartir no es soportado por esta funcion", MsgBoxStyle.Exclamation, "Formato no soportado")
            End Select

            gFncConvertDateToString = Rta

        Catch ex As Exception
            MsgBox("Error al convertir fecha", MsgBoxStyle.Critical, "Error en gConvertStringToDate")
        End Try


    End Function

    Public Function gFncNumToText(ByVal p As Decimal) As String

        Dim value As Double
        'Dim Decimales As String
        value = Decimal.Round(p, 0)

        Select Case value
            Case 0 : gFncNumToText = "CERO"
            Case 1 : gFncNumToText = "UN"
            Case 2 : gFncNumToText = "DOS"
            Case 3 : gFncNumToText = "TRES"
            Case 4 : gFncNumToText = "CUATRO"
            Case 5 : gFncNumToText = "CINCO"
            Case 6 : gFncNumToText = "SEIS"
            Case 7 : gFncNumToText = "SIETE"
            Case 8 : gFncNumToText = "OCHO"
            Case 9 : gFncNumToText = "NUEVE"
            Case 10 : gFncNumToText = "DIEZ"
            Case 11 : gFncNumToText = "ONCE"
            Case 12 : gFncNumToText = "DOCE"
            Case 13 : gFncNumToText = "TRECE"
            Case 14 : gFncNumToText = "CATORCE"
            Case 15 : gFncNumToText = "QUINCE"
            Case Is < 20 : gFncNumToText = "DIECI" & gFncNumToText(value - 10)
            Case 20 : gFncNumToText = "VEINTE"
            Case Is < 30 : gFncNumToText = "VEINTI" & gFncNumToText(value - 20)
            Case 30 : gFncNumToText = "TREINTA"
            Case 40 : gFncNumToText = "CUARENTA"
            Case 50 : gFncNumToText = "CINCUENTA"
            Case 60 : gFncNumToText = "SESENTA"
            Case 70 : gFncNumToText = "SETENTA"
            Case 80 : gFncNumToText = "OCHENTA"
            Case 90 : gFncNumToText = "NOVENTA"
            Case Is < 100 : gFncNumToText = gFncNumToText(Int(value \ 10) * 10) & " Y " & gFncNumToText(value Mod 10)
            Case 100 : gFncNumToText = "CIEN"
            Case Is < 200 : gFncNumToText = "CIENTO " & gFncNumToText(value - 100)
            Case 200, 300, 400, 600, 800 : gFncNumToText = gFncNumToText(Int(value \ 100)) & "CIENTOS"
            Case 500 : gFncNumToText = "QUINIENTOS"
            Case 700 : gFncNumToText = "SETECIENTOS"
            Case 900 : gFncNumToText = "NOVECIENTOS"
            Case Is < 1000 : gFncNumToText = gFncNumToText(Int(value \ 100) * 100) & " " & gFncNumToText(value Mod 100)
            Case 1000 : gFncNumToText = "MIL"
            Case Is < 2000 : gFncNumToText = "MIL " & gFncNumToText(value Mod 1000)
            Case Is < 1000000 : gFncNumToText = gFncNumToText(Int(value \ 1000)) & " MIL"
                If value Mod 1000 Then gFncNumToText = gFncNumToText & " " & gFncNumToText(value Mod 1000)
            Case 1000000 : gFncNumToText = "UN MILLON"
            Case Is < 2000000 : gFncNumToText = "UN MILLON " & gFncNumToText(value Mod 1000000)
            Case Is < 1000000000000.0# : gFncNumToText = gFncNumToText(Int(value / 1000000)) & " MILLONES """
                If (value - Int(value / 1000000) * 1000000) Then gFncNumToText = gFncNumToText & " " & gFncNumToText(value - Int(value / 1000000) * 1000000)
            Case 1000000000000.0# : gFncNumToText = "UN BILLON"
            Case Is < 2000000000000.0# : gFncNumToText = "UN BILLON " & gFncNumToText(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
            Case Else : gFncNumToText = gFncNumToText(Int(value / 1000000000000.0#)) & " BILLONES"
                If (value - Int(value / 1000000000000.0#) * 1000000000000.0#) Then gFncNumToText = gFncNumToText & " " & gFncNumToText(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
        End Select


    End Function
    Public Function gFncDecimalToText(ByVal p As Decimal) As String

        Dim value As Integer
        'Dim Decimales As String
        value = p
        gFncDecimalToText = gFncNumToText(Decimal.Truncate(p))
        Select Case (p - value)
            Case 0 : gFncDecimalToText = gFncDecimalToText & ""
            Case Is > 0 : gFncDecimalToText = gFncDecimalToText & " CON " & Int((p - value) * 100) & "/100"
            Case Is < 0 : gFncDecimalToText = gFncDecimalToText & " CON " & Int((1 + p - value) * 100) & "/100"
        End Select

    End Function


    Public Class ListViewColumnSort
        Implements IComparer

        Public Enum TipoCompare
            Cadena
            Numero
            Fecha
        End Enum
        Public CompararPor As TipoCompare
        Public ColumnIndex As Integer = 0
        Public Sorting As SortOrder = SortOrder.Ascending
        '
        ' Constructores
        Sub New()
            ' no es necesario indicar nada,
            ' ya que implícitamente se llama a MyBase.New
        End Sub
        Sub New(ByVal columna As Integer)
            ColumnIndex = columna
        End Sub
        '
        Public Overridable Function Compare(ByVal a As Object,
                                            ByVal b As Object) As Integer _
                                            Implements IComparer.Compare
            '
            ' Esta función devolverá:
            '   -1 si el primer elemento es menor que el segundo
            '    0 si los dos son iguales
            '    1 si el primero es mayor que el segundo
            '
            Dim menor As Integer = -1, mayor As Integer = 1
            Dim s1, s2 As String
            '
            If Sorting = SortOrder.None Then
                Return 0
            End If
            '
            ' Convertir el texto en el formato adecuado
            ' y tomar el texto de la columna en la que se ha pulsado
            s1 = DirectCast(a, ListViewItem).SubItems(ColumnIndex).Text
            s2 = DirectCast(b, ListViewItem).SubItems(ColumnIndex).Text
            '
            ' Asignar cuando es menor o mayor,
            ' dependiendo del orden de clasificación
            If Sorting = SortOrder.Descending Then
                menor = 1
                mayor = -1
            End If
            '
            Select Case CompararPor
                Case TipoCompare.Fecha
                    ' Si da error, se comparan como cadenas
                    Try
                        Dim f1 As Date = DateTime.Parse(s1)
                        Dim f2 As Date = DateTime.Parse(s2)
                        If f1 < f2 Then
                            Return menor
                        ElseIf f1 = f2 Then
                            Return 0
                        Else
                            Return mayor
                        End If
                    Catch
                        'Return s1.CompareTo(s2) * mayor
                        Return System.String.Compare(s1, s2, True) * mayor
                    End Try
                Case TipoCompare.Numero
                    ' Si da error, se comparan como cadenas
                    Try
                        Dim n1 As Decimal = Decimal.Parse(s1)
                        Dim n2 As Decimal = Decimal.Parse(s2)
                        If n1 < n2 Then
                            Return menor
                        ElseIf n1 = n2 Then
                            Return 0
                        Else
                            Return mayor
                        End If
                    Catch
                        Return System.String.Compare(s1, s2, True) * mayor
                    End Try
                Case Else
                    'Case TipoCompare.Cadena
                    Return System.String.Compare(s1, s2, True) * mayor
            End Select
        End Function

        Function App_Path() As String
            Return System.AppDomain.CurrentDomain.BaseDirectory
        End Function
    End Class

End Module
