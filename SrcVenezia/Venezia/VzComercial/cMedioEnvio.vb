Imports VzAdmin
Imports MySql.Data.MySqlClient

Public Class cMedioEnvio

#Region "Propiedades"

    Private _Id_ME As Integer
    Private _Cod_ME As Integer
    Private _Descripcion As String

    Private gAdmin As VzAdmin.cAdmin

    Public Property Id_ME As Integer
        Get
            Return _Id_ME
        End Get
        Set(value As Integer)
            _Id_ME = value
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

    Public Property Cod_ME As Integer
        Get
            Return _Cod_ME
        End Get
        Set(value As Integer)
            _Cod_ME = value
        End Set
    End Property

#End Region

#Region "Funciones"

    Public Sub New(ByRef pAdmin As cAdmin)
        gAdmin = pAdmin
    End Sub

    Public Shared Function GetMedioEnvioxCod(ByRef pAdmin As VzAdmin.cAdmin, ByVal pIdME As Integer) As cMedioEnvio
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lME As cMedioEnvio = Nothing

        Try
            lDt = Dat_GetMedioEnvioxCod(pAdmin, pIdME)

            If lDt.Rows.Count > 0 Then

                For Each lDr In lDt.Rows
                    lME = New cMedioEnvio(pAdmin)
                    lME.Id_ME = lDr("Id_ME")
                    lME.Id_ME = lDr("Cod_ME")
                    lME.Descripcion = lDr("Descripcion")
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cMedioEnvio.GetMedioEnvioxCod")
            pAdmin.Log.fncGrabarLogERR("Error en cMedioEnvio.GetMedioEnvioxCod:" & ex.Message)
        End Try

        Return lME

    End Function

#End Region

#Region "Base de Datos"

    Private Shared Function Dat_GetMedioEnvioxCod(ByRef pAdmin As VzAdmin.cAdmin, ByVal pIdME As Integer) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "SELECT * FROM sis_medios_env where Id_ME=#IdME#"
            Sql = Sql.Replace("#IdME#", pIdME)


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

            Return lDt

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cMedioEnvio.Dat_GetGrupoArtxCod")
            pAdmin.Log.fncGrabarLogERR("Error en cMedioEnvio.Dat_GetGrupoArtxCod:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Shared Function Dat_GetMedioEnvioGetAll(ByRef pAdmin As VzAdmin.cAdmin) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "SELECT * FROM sis_medios_env"

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

            Return lDt

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cMedioEnvio.Dat_GetMedioEnvioGetAll")
            pAdmin.Log.fncGrabarLogERR("Error en cMedioEnvio.Dat_GetMedioEnvioGetAll:" & ex.Message)
            Return Nothing
        End Try
    End Function

#End Region

End Class
