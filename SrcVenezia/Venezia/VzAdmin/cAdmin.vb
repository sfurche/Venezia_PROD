Imports MySql.Data.MySqlClient
Imports VzAdmin

Public Class cAdmin

#Region "Declaraciones"
    Private _DbCnn As cDBCnn
    Private _Log As cLog
    Private _User As cUser

    Public ReadOnly Property DbCnn As cDBCnn
        Get
            Return _DbCnn
        End Get

    End Property

    Public ReadOnly Property Log As cLog
        Get
            Return _Log
        End Get
    End Property

    Public ReadOnly Property User As cUser
        Get
            Return _User
        End Get

    End Property

    Public Enum EnuOBJETOS
        Liquidacion = 0
        Liquidaicon_Detalle = 1
        Articulo = 2
        Cliente = 3
        Cheque = 4
        Proveedores = 5
    End Enum

#End Region

#Region "Funciones"
    Public Sub New()

    End Sub

    Public Sub New(ByVal pBdServer As String, ByVal pBdName As String, ByVal pBdPort As String)
        'Me._DbCnn = New cDBCnn(pBdServer, pBdName, "venezia", "metallica", pBdPort)
        'Me._Log = New cLog()
        'Me._User = New cUser()

        'gDbCnn = New cDBCnn(pBdServer, pBdName, "sebastian", "furche.1", pBdPort)
        gDbCnn = New cDBCnn(pBdServer, pBdName, "venezia", "metallica.1979", pBdPort)
        gLog = New cLog()
        gUser = New cUser(Me)

        _DbCnn = gDbCnn
        _Log = gLog
        _User = gUser

    End Sub

    Public Function GetDate() As Date
        GetDate = Date.MinValue
        Try
            Dim Cmd As New MySqlCommand
            Dim Sql As String
            Dim lDt As DataTable
            Dim lCnn As MySqlConnection


            lCnn = Me.DbCnn.GetInstanceCon

            Sql = "Select CurDate()"

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

            GetDate = lDt(0)(0)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cAdmin.GetDate")
            Me.Log.fncGrabarLogERR("Error en cAdmin.GetDate:  " & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Sub Dispose()
        _DbCnn.Dispose()
        _Log.Dispose()
        _User.Dispose()
        Me.Dispose()
    End Sub

#End Region

End Class


