Imports VzAdmin
Imports MySql.Data.MySqlClient

Public Class cGrupoArticulo

#Region "Propiedades"


    Private _CodGrupo As Integer
    Private _Descripcion As String

    Private gAdmin As VzAdmin.cAdmin

    Public Property CodGrupo As Integer
        Get
            Return _CodGrupo
        End Get
        Set(value As Integer)
            _CodGrupo = value
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

#Region "Funciones"


    Public Sub New(ByRef pAdmin As cAdmin)
        gAdmin = pAdmin
    End Sub

    Public Shared Function GetGrupoArticulosxCod(ByRef pAdmin As VzAdmin.cAdmin, ByVal pCodGrupoArt As Integer) As cGrupoArticulo
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lGrupoArt As cGrupoArticulo = Nothing

        Try
            lDt = Dat_GetGrupoArtxCod(pAdmin, pCodGrupoArt)

            If lDt.Rows.Count > 0 Then

                For Each lDr In lDt.Rows
                    lGrupoArt = New cGrupoArticulo(pAdmin)
                    lGrupoArt.CodGrupo = lDr("CodGrupo")
                    lGrupoArt.Descripcion = lDr("Descripcion")

                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cGrupoArticulo.GetGrupoArticulosxCod")
            pAdmin.Log.fncGrabarLogERR("Error en cGrupoArticulo.GetGrupoArticulosxCod:" & ex.Message)
        End Try

        Return lGrupoArt

    End Function

#End Region

#Region "Base de Datos"
    Private Shared Function Dat_GetGrupoArtxCod(ByRef pAdmin As VzAdmin.cAdmin, ByVal pCodigo As Integer) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "SELECT * FROM pro_grupoart where CodGrupo=#CodGrupo#"
            Sql = Sql.Replace("#CodGrupo#", pCodigo)


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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cGrupoArticulo.Dat_GetGrupoArtxCod")
            pAdmin.Log.fncGrabarLogERR("Error en cGrupoArticulo.Dat_GetGrupoArtxCod:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Shared Function Dat_GetGrupoArtGetAll(ByRef pAdmin As VzAdmin.cAdmin) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "SELECT * FROM pro_grupoart"

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cGrupoArticulo.Dat_GetGrupoArtGetAll")
            pAdmin.Log.fncGrabarLogERR("Error en cGrupoArticulo.Dat_GetGrupoArtGetAll:" & ex.Message)
            Return Nothing
        End Try
    End Function

#End Region


End Class
