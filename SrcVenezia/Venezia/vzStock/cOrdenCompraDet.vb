
Imports MySql.Data.MySqlClient
Imports VzAdmin
Imports vzStock

Public Class cOrdenCompraDet

    Private gAdmin As VzAdmin.cAdmin

    Private _Id_OC_Detalle As Integer
    Private _Id_OrdenDeCompra As Integer
    Private _Articulo As cArticulo
    Private _Cantidad As Integer
    Private _PrecioUnitario As Double
    Private _Estado As cEstado
    Private _EsNuevo As Boolean = True

#Region "Declaraciones"

    Public Property Id_OC_Detalle As Integer
        Get
            Return _Id_OC_Detalle
        End Get
        Set(value As Integer)
            _Id_OC_Detalle = value
        End Set
    End Property

    Public Property Id_OrdenDeCompra As Integer
        Get
            Return _Id_OrdenDeCompra
        End Get
        Set(value As Integer)
            _Id_OrdenDeCompra = value
        End Set
    End Property

    Public Property Articulo As cArticulo
        Get
            Return _Articulo
        End Get
        Set(value As cArticulo)
            _Articulo = value
        End Set
    End Property

    Public Property Cantidad As Integer
        Get
            Return _Cantidad
        End Get
        Set(value As Integer)
            _Cantidad = value
        End Set
    End Property

    Public Property PrecioUnitario As Double
        Get
            Return _PrecioUnitario
        End Get
        Set(value As Double)
            _PrecioUnitario = value
        End Set
    End Property

    Public Property Estado As cEstado
        Get
            Return _Estado
        End Get
        Set(value As cEstado)
            _Estado = value
        End Set
    End Property

#End Region

#Region "Funciones"

    Public Sub New(ByRef pAdmin As cAdmin)
        gAdmin = pAdmin
    End Sub

    Public Sub Load()

    End Sub

    Public Function Guardar() As Boolean


    End Function

#End Region

#Region "Shared Funciones"

    Public Shared Function GetOrdenCompraDetxIdOrden(ByRef pAdmin As VzAdmin.cAdmin, ByVal pIdOrdenCompra As Integer) As ArrayList
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lArticulo As cArticulo = Nothing
        Dim lArray As New ArrayList

        Try
            lDt = Dat_GetOrdenCompraDetxIdOrden(pAdmin, pIdOrdenCompra)

            If lDt.Rows.Count > 0 Then
                For Each lDr In lDt.Rows
                    lArticulo = New cArticulo(pAdmin)
                    lArticulo.CargarDatos(lDr)
                    lArray.Add(lArticulo)
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cOrdenCompraDet.GetOrdenCompraDetxNroOrden")
            pAdmin.Log.fncGrabarLogERR("Error en cOrdenCompraDet.GetOrdenCompraDetxNroOrden:" & ex.Message)
        End Try

        Return lArray

    End Function
#End Region


#Region "Base de Datos"

    Private Shared Function Dat_GetOrdenCompraDetxIdOrden(ByRef pAdmin As VzAdmin.cAdmin, ByVal pIdOrdenCompra As Integer) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "select * from vz_ordencompra_det where id_ordencompra = #pIdOrdenCompra# ;"
            Sql = Sql.Replace("#pIdOrdenCompra#", pIdOrdenCompra)

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cOrdenCompraDet.Dat_GetOrdenCompraDetxIdOrden")
            pAdmin.Log.fncGrabarLogERR("Error en cOrdenCompraDet.Dat_GetOrdenCompraDetxIdOrden:" & ex.Message)
            Return Nothing
        End Try
    End Function



#End Region

End Class
