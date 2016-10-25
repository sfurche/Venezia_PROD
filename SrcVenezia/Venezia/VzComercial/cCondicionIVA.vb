Imports MySql.Data.MySqlClient
Imports VzAdmin

Public Class cCondicionIVA

#Region "Propiedades"

    Private _Id_CatIva As Integer
    Private _Descripcion As String
    Private _TasaIva As Decimal
    Private _SobreTasaIva As Decimal

    Private gAdmin As VzAdmin.cAdmin

    Public Property Id_CatIva As Integer
        Get
            Return _Id_CatIva
        End Get
        Set(value As Integer)
            _Id_CatIva = value
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

    Public Property TasaIva As Decimal
        Get
            Return _TasaIva
        End Get
        Set(value As Decimal)
            _TasaIva = value
        End Set
    End Property

    Public Property SobreTasaIva As Decimal
        Get
            Return _SobreTasaIva
        End Get
        Set(value As Decimal)
            _SobreTasaIva = value
        End Set
    End Property

#End Region

#Region "Funciones"

    Public Sub New()

    End Sub

    Public Sub New(ByRef pAdmin As cAdmin)
        gAdmin = pAdmin
    End Sub

    Public Shared Function GetCatIvaxCod(ByRef pAdmin As VzAdmin.cAdmin, ByVal pId_CatIva As Integer) As cCondicionIVA
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lCondIVA As cCondicionIVA = Nothing

        Try
            lDt = Dat_GetCatIvaCod(pAdmin, pId_CatIva)

            If lDt.Rows.Count > 0 Then

                For Each lDr In lDt.Rows
                    lCondIVA = New cCondicionIVA(pAdmin)
                    lCondIVA.Id_CatIva = lDr("Id_CatIva")
                    lCondIVA.Descripcion = lDr("Descripcion")
                    lCondIVA.TasaIva = lDr("TasaIva")
                    lCondIVA.SobreTasaIva = lDr("SobreTasaIva")
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCondicionIVA.GetCatIvaxCod")
            pAdmin.Log.fncGrabarLogERR("Error en cCondicionIVA.GetCatIvaxCod:" & ex.Message)
        End Try

        Return lCondIVA

    End Function

#End Region

#Region "Base de Datos"

    Private Shared Function Dat_GetCatIvaCod(ByRef pAdmin As VzAdmin.cAdmin, ByVal pId_CatIva As Integer) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "SELECT * FROM sis_cativa where Id_CatIva=#pId_CatIva#"
            Sql = Sql.Replace("#pId_CatIva#", pId_CatIva)


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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCondicionIVA.Dat_GetCatIvaCod")
            pAdmin.Log.fncGrabarLogERR("Error en cCondicionIVA.Dat_GetCatIvaCod:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Shared Function Dat_GetCatIvaGetAll(ByRef pAdmin As VzAdmin.cAdmin) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "SELECT * FROM sis_cativa"

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCondicionIVA.Dat_GetCatIvaGetAll")
            pAdmin.Log.fncGrabarLogERR("Error en cCondicionIVA.Dat_GetCatIvaGetAll:" & ex.Message)
            Return Nothing
        End Try
    End Function

#End Region
End Class
