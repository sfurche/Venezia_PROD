Imports MySql.Data
Imports MySql.Data.MySqlClient


Public Class cDBCnn
    Private Cnn As New MySqlConnection
    Private StrConection As String

    Public Sub New(ByVal pSrv As String, ByVal pBD As String, ByVal pUser As String, ByVal pPass As String, ByVal pPort As String)
        Dim strCon As String

        'Ejemplo:
        'String connStr = "server=localhost;user=root;database=world;port=3306;password=******;";

        strCon = "server=" & pSrv.Trim & ";"
        strCon = strCon & "user=" & pUser.Trim & ";"
        strCon = strCon & "database=" & pBD.Trim & ";"
        strCon = strCon & "port=" & pPort.Trim & ";"
        strCon = strCon & "password=" & pPass.Trim & ";"

        Cnn.ConnectionString = strCon

    End Sub

    Public Sub Dispose()
        Cnn.Dispose()
        Me.Dispose()
    End Sub

    ReadOnly Property GetInstanceCon() As MySqlConnection
        Get
            Return Cnn
        End Get
    End Property

    Public Function GetMaximo(ByVal pTabla As String, ByVal pCampo As String) As Integer
        Dim Cmd As New MySqlCommand
        Dim Sql As String

        Try

            Sql = "Select Max(" & pCampo & ") From " & pTabla.Trim
            With Cmd
                .Connection = Cnn
                .CommandType = CommandType.Text
                .CommandText = Sql

                If Cnn.State = ConnectionState.Closed Then
                    Cnn.Open()
                End If
                Dim lAdap As New MySqlDataAdapter(Cmd)
                Dim lTabla As New DataTable
                lAdap.Fill(lTabla)
                GetMaximo = IIf(lTabla.Rows(0)(0) Is System.DBNull.Value, 0, lTabla.Rows(0)(0))
                Cnn.Close()
            End With

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Fallo en GetMaximo")
            GetMaximo = -1
        End Try
    End Function

    Public Function GetUltimoLogIn() As Date
        Dim Cmd As New MySqlCommand
        Dim Sql As String

        Try
            Sql = "Select MAX(fec_log) From tbllog Where Categoria ='LOGIN'"
            With Cmd
                .Connection = Cnn
                .CommandType = CommandType.Text
                .CommandText = Sql

                If Cnn.State = ConnectionState.Closed Then
                    Cnn.Open()
                End If
                Dim lAdap As New MySqlDataAdapter(Cmd)
                Dim lTabla As New DataTable
                lAdap.Fill(lTabla)

                If (lTabla.Rows(0)(0) Is System.DBNull.Value) Then
                    Return Date.MaxValue
                Else
                    Return CDate(lTabla.Rows(0)(0))
                End If
                Cnn.Close()
            End With

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Fallo en GetUltimoLogIn")
            Throw
        End Try
    End Function

    Public Function GetCantReg(ByVal pTabla As String) As Integer
        Dim Cmd As New MySqlCommand
        Dim Sql As String

        Try

            Sql = "Select count(*) From " & pTabla.Trim
            With Cmd
                .Connection = Cnn
                .CommandType = CommandType.Text
                .CommandText = Sql

                If Cnn.State = ConnectionState.Closed Then
                    Cnn.Open()
                End If
                Dim lAdap As New MySqlDataAdapter(Cmd)
                Dim lTabla As New DataTable
                lAdap.Fill(lTabla)
                GetCantReg = IIf(lTabla.Rows(0)(0) Is System.DBNull.Value, 0, lTabla.Rows(0)(0))
                Cnn.Close()
            End With

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Fallo en GetCantReg")
            GetCantReg = -1
        End Try
    End Function

    Public Function GetDate() As Date
        Dim Cmd As New MySqlCommand
        Dim Sql As String

        Try

            Sql = "Select Now()"
            With Cmd
                .Connection = Cnn
                .CommandType = CommandType.Text
                .CommandText = Sql

                If Cnn.State = ConnectionState.Closed Then
                    Cnn.Open()
                End If
                Dim lAdap As New MySqlDataAdapter(Cmd)
                Dim lTabla As New DataTable
                lAdap.Fill(lTabla)
                GetDate = CDate(lTabla.Rows(0)(0))
                Cnn.Close()
            End With

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Fallo en Now")
            GetDate = Date.MinValue
        End Try
    End Function

    Public Function TestConnection() As Boolean
        Try
            If Cnn.State = ConnectionState.Closed Then
                Cnn.Open()
                Cnn.Close()
            End If

            Return True
        Catch ex As Exception
            MsgBox(ex.Message)

            Return False
        End Try
    End Function

End Class
