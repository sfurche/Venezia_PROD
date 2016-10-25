Imports MySql.Data.MySqlClient
Imports VzAdmin

Public Class cSitIB

#Region "Propiedades"

    Private _Id_SitIB As Integer
    Private _Cod_Sit_IB As String
    Private _Descripcion As String
    Private _Formato_Nro_IB As String
    Private _Tasa_Percep As Decimal

    Private gAdmin As VzAdmin.cAdmin

    Public Property Id_SitIB As Integer
        Get
            Return _Id_SitIB
        End Get
        Set(value As Integer)
            _Id_SitIB = value
        End Set
    End Property

    Public Property Cod_Sit_IB As String
        Get
            Return _Cod_Sit_IB
        End Get
        Set(value As String)
            _Cod_Sit_IB = value
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

    Public Property Formato_Nro_IB As String
        Get
            Return _Formato_Nro_IB
        End Get
        Set(value As String)
            _Formato_Nro_IB = value
        End Set
    End Property

    Public Property Tasa_Percep As Decimal
        Get
            Return _Tasa_Percep
        End Get
        Set(value As Decimal)
            _Tasa_Percep = value
        End Set
    End Property



#End Region

#Region "Funciones"
    Public Sub New()

    End Sub


    Public Sub New(ByRef pAdmin As cAdmin)
        gAdmin = pAdmin
    End Sub

    Public Shared Function GetSitIBxCod(ByRef pAdmin As VzAdmin.cAdmin, ByVal pCod_Sit_IB As String) As cSitIB
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lSitIB As cSitIB = Nothing

        Try
            lDt = Dat_GetSitIBxCod(pAdmin, pCod_Sit_IB)

            If lDt.Rows.Count > 0 Then

                For Each lDr In lDt.Rows
                    lSitIB = New cSitIB(pAdmin)
                    lSitIB.Id_SitIB = lDr("Id_SitIB")
                    lSitIB.Cod_Sit_IB = lDr("Cod_Sit_IB")
                    lSitIB.Descripcion = lDr("Descripcion")
                    lSitIB.Formato_Nro_IB = lDr("Formato_Nro_IB")
                    lSitIB.Tasa_Percep = lDr("Tasa_Percep")
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cSitIB.GetSitIBxCod")
            pAdmin.Log.fncGrabarLogERR("Error en cSitIB.GetSitIBxCod:" & ex.Message)
        End Try

        Return lSitIB

    End Function

#End Region

#Region "Base de Datos"
    Private Shared Function Dat_GetSitIBxCod(ByRef pAdmin As VzAdmin.cAdmin, ByVal pCod_Sit_IB As String) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "SELECT * FROM sis_sitib where Cod_Sit_IB= '#pCod_Sit_IB#' "
            Sql = Sql.Replace("#pCod_Sit_IB#", pCod_Sit_IB)


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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cSitIB.Dat_GetSitIBxCod")
            pAdmin.Log.fncGrabarLogERR("Error en cSitIB.Dat_GetSitIBxCod:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Shared Function Dat_GetSitIBGetAll(ByRef pAdmin As VzAdmin.cAdmin) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "SELECT * FROM sis_sitib"

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cSitIB.Dat_GetSitIBGetAll")
            pAdmin.Log.fncGrabarLogERR("Error en cSitIB.Dat_GetSitIBGetAll:" & ex.Message)
            Return Nothing
        End Try
    End Function

#End Region
End Class
