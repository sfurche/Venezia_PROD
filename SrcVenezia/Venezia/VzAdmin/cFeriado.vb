Imports MySql.Data.MySqlClient

Public Class cFeriado


#Region "Propiedades"
    Private _Fecha As Date
    Private _Descripcion As String

    Private gAdmin As VzAdmin.cAdmin

    Public Property Fecha As Date
        Get
            Return _Fecha
        End Get
        Set(value As Date)
            _Fecha = value
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return _Descripcion
        End Get
        Set(value As String)
            _Descripcion = value
        End Set
    End Property


#End Region

    Public Sub New()

    End Sub

    Public Sub New(ByRef pAdmin As cAdmin)
        gAdmin = pAdmin

    End Sub

    Public Shared Function EsFeriado(ByRef pAdmin As VzAdmin.cAdmin, ByVal pFecha As Date) As Boolean
        EsFeriado = False

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try

            'Primero evaluo si es sabado o domingo. Si es un dia de semana, valido contra la tabla de feriados. 
            If pFecha.DayOfWeek = DayOfWeek.Saturday Or pFecha.DayOfWeek = DayOfWeek.Sunday Then
                EsFeriado = True
                Exit Function
            End If

            'Valido si la fecha esta cargada como feriado en la tabla de FERIADOS. 

            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "Select * from vz_feriados where fecha='#pfecha#'"
            Sql = Sql.Replace("#pfecha#", cFunciones.gFncConvertDateToString(pFecha, "YYYY/MM/DD"))

            With Cmd
                .Connection = lCnn
                .CommandType = CommandType.Text
                .CommandText = Sql

                If lCnn.State = ConnectionState.Closed Then
                    lCnn.Open()
                End If
                Dim lAdap As New MySqlDataAdapter(Cmd)
                lDt = New DataTable
                lAdap.Fill(lDt)
                lCnn.Close()
            End With

            If lDt.Rows.Count > 0 Then
                EsFeriado = True
            Else
                EsFeriado = False
            End If

        Catch ex As Exception
            pAdmin.Log.fncGrabarLogERR("Error en cFeriado.EsFeriado:" & ex.Message)
        End Try

    End Function

End Class
