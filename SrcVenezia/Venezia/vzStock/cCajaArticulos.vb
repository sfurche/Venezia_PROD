Imports VzAdmin
Imports MySql.Data.MySqlClient

Public Class cCajaArticulos

#Region "Propiedades"
    Private gAdmin As VzAdmin.cAdmin

    Private _CodCaja As Integer
    Private _Descripcion As String
    Private _CantUni As Integer

    Public Property CodCaja As Integer
        Get
            Return _CodCaja
        End Get
        Set(value As Integer)
            _CodCaja = value
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

    Public Property CantUni As Integer
        Get
            Return _CantUni
        End Get
        Set(value As Integer)
            _CantUni = value
        End Set
    End Property




#End Region

#Region "Funciones"

    Public Sub New(ByRef pAdmin As cAdmin)
        Me.gAdmin = pAdmin
    End Sub

    Public Shared Function GetCajaArticulosxCod(ByRef pAdmin As VzAdmin.cAdmin, ByVal pCodGrupoArt As Integer) As cCajaArticulos
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lCajaArt As cCajaArticulos = Nothing

        Try
            lDt = Dat_GetCajaArtxCod(pAdmin, pCodGrupoArt)

            If lDt.Rows.Count > 0 Then

                For Each lDr In lDt.Rows
                    lCajaArt = New cCajaArticulos(pAdmin)
                    lCajaArt.CodCaja = lDr("CodCaja")
                    lCajaArt.Descripcion = lDr("Descripcion")
                    lCajaArt.CantUni = lDr("CantUni")

                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCajaArticulos.GetCajaArticulosxCod")
            pAdmin.Log.fncGrabarLogERR("Error en cCajaArticulos.GetCajaArticulosxCod:" & ex.Message)
        End Try

        Return lCajaArt

    End Function

#End Region

#Region "Base de Datos"
    Private Shared Function Dat_GetCajaArtxCod(ByRef pAdmin As VzAdmin.cAdmin, ByVal pCodigo As Integer) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "SELECT * FROM pro_cajas where CodCaja=#pCodigo#"
            Sql = Sql.Replace("#pCodigo#", pCodigo)


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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCajaArticulos.Dat_GetCajaArtxCod")
            pAdmin.Log.fncGrabarLogERR("Error en cCajaArticulos.Dat_GetCajaArtxCod:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Shared Function Dat_GetCajaArtGetAll(ByRef pAdmin As VzAdmin.cAdmin) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "SELECT * FROM pro_cajas"

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCajaArticulos.Dat_GetCajaArtGetAll")
            pAdmin.Log.fncGrabarLogERR("Error en cCajaArticulos.Dat_GetCajaArtGetAll:" & ex.Message)
            Return Nothing
        End Try
    End Function

#End Region

End Class