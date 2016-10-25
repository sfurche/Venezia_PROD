Imports MySql.Data.MySqlClient
Imports VzAdmin

Public Class cCondicionPago

#Region "Propiedades"
    Private _Id_CondPago As Integer
    Private _Descripcion As String
    Private _CantDias As Integer
    Private _Descuento As Decimal
    Private _Recargo As Decimal

    Private gAdmin As VzAdmin.cAdmin

    Public Property Id_CondPago As Integer
        Get
            Return _Id_CondPago
        End Get
        Set(value As Integer)
            _Id_CondPago = value
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

    Public Property CantDias As Integer
        Get
            Return _CantDias
        End Get
        Set(value As Integer)
            _CantDias = value
        End Set
    End Property

    Public Property Descuento As Decimal
        Get
            Return _Descuento
        End Get
        Set(value As Decimal)
            _Descuento = value
        End Set
    End Property

    Public Property Recargo As Decimal
        Get
            Return _Recargo
        End Get
        Set(value As Decimal)
            _Recargo = value
        End Set
    End Property


#End Region

#Region "Funciones"

    Public Sub New(ByRef pAdmin As cAdmin)
        gAdmin = pAdmin
    End Sub

    Public Shared Function GetCondPagoxCod(ByRef pAdmin As VzAdmin.cAdmin, ByVal pCod_Sit_IB As Integer) As cCondicionPago
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lCondPago As cCondicionPago = Nothing

        Try
            lDt = Dat_GetCondPagoxCod(pAdmin, pCod_Sit_IB)

            If lDt.Rows.Count > 0 Then

                For Each lDr In lDt.Rows
                    lCondPago = New cCondicionPago(pAdmin)
                    lCondPago.Id_CondPago = lDr("Id_CondPago")
                    lCondPago.Descripcion = lDr("Descripcion")
                    lCondPago.CantDias = lDr("CantDias")
                    lCondPago.Descuento = lDr("Descuento")
                    lCondPago.Recargo = lDr("Recargo")
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCondicionPago.GetCondPagoxCod")
            pAdmin.Log.fncGrabarLogERR("Error en cCondicionPago.GetCondPagoxCod:" & ex.Message)
        End Try

        Return lCondPago

    End Function

#End Region

#Region "Base de Datos"

    Private Shared Function Dat_GetCondPagoxCod(ByRef pAdmin As VzAdmin.cAdmin, ByVal pId_CondPago As Integer) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "SELECT * FROM sis_condpago where Id_CondPago=#pId_CondPago#"
            Sql = Sql.Replace("#pId_CondPago#", pId_CondPago)


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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCondicionPago.Dat_GetCondPagoxCod")
            pAdmin.Log.fncGrabarLogERR("Error en cCondicionPago.Dat_GetCondPagoxCod:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Shared Function Dat_GetCondPagoGetAll(ByRef pAdmin As VzAdmin.cAdmin) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "SELECT * FROM sis_condpago"

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCondicionPago.Dat_GetCondPagoGetAll")
            pAdmin.Log.fncGrabarLogERR("Error en cCondicionPago.Dat_GetCondPagoGetAll:" & ex.Message)
            Return Nothing
        End Try
    End Function

#End Region
End Class
