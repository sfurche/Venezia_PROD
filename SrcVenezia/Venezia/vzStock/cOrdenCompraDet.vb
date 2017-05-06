
Imports System.IO
Imports System.Xml.Serialization
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

    Private ObjetoInicial As String = ""   'Esta es la serializacion del objeto ni bien se instancia, antes de que sea modificado por el usuario.

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

    Public Property EsNuevo As Boolean
        Get
            Return _EsNuevo
        End Get
        Set(value As Boolean)
            _EsNuevo = value
        End Set
    End Property

#End Region

#Region "Funciones"


    Public Sub New()

    End Sub

    Public Sub New(ByRef pAdmin As cAdmin)
        gAdmin = pAdmin
    End Sub

    Public Sub Load(ByVal lDr As DataRow)
        Try
            Me.Id_OC_Detalle = lDr("id_ordencompra_det")
            Me.Id_OrdenDeCompra = lDr("id_ordencompra")
            Me.Articulo = cArticulo.GetArticuloxCod(gAdmin, lDr("CodArt"))
            Me.Cantidad = lDr("cantidad")
            Me.PrecioUnitario = lDr("preciounitario")
            Me.Estado = cEstado.GetEstadoxIdTipoEstado(gAdmin, lDr("id_estado"), cEstado.enuTipoEstado.OrdenCompra_Det)
            Me.EsNuevo = False
            Me.ObjetoInicial = Me.ToString

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cOrdenCompraDet.Guardar")
            gAdmin.Log.fncGrabarLogERR("Error en cOrdenCompraDet.Guardar:" & ex.Message)
        End Try

    End Sub

    Public Function Guardar() As Boolean
        Guardar = False
        Dim Cmd As New MySqlCommand
        Dim Sql As String = ""
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection = Nothing
        Try

            If EsNuevo = True Then 'INSERT

                ''-- Primero guardo la cabecera y luego voy por cada detalle.
                Sql = "CALL vz_ordencompra_det_ins( #id_ordencompra#, #CodArt#, #cantidad#, #preciounitario#, #idusr#);"
                Sql = Sql.Replace("#id_ordencompra#", Me.Id_OrdenDeCompra)
                Sql = Sql.Replace("#CodArt#", Me.Articulo.CodArt)
                Sql = Sql.Replace("#cantidad#", Me.Cantidad)
                Sql = Sql.Replace("#preciounitario#", Me.PrecioUnitario.ToString().Replace(",", "."))
                Sql = Sql.Replace("#idusr#", gAdmin.User.Id)

                lCnn = gAdmin.DbCnn.GetInstanceCon
                Cmd.Connection = lCnn
                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = Sql
                If lCnn.State = ConnectionState.Closed Then
                    lCnn.Open()
                End If
                Dim lAdap As New MySqlDataAdapter(Cmd)
                lDt = New DataTable
                lAdap.Fill(lDt)
                lCnn.Close()

                Me.EsNuevo = False

            Else  'ACA VA EL UPDATE 

                Sql = "CALL vz_ordencompra_det_upd( #id_ordencompra_det#, #id_ordencompra#, #CodArt#, #cantidad#, #preciounitario#, #idusr#);"
                Sql = Sql.Replace("#id_ordencompra#", Me.Id_OC_Detalle)
                Sql = Sql.Replace("#id_ordencompra#", Me.Id_OrdenDeCompra)
                Sql = Sql.Replace("#CodArt#", Me.Articulo.CodArt)
                Sql = Sql.Replace("#cantidad#", Me.Cantidad)
                Sql = Sql.Replace("#preciounitario#", Me.PrecioUnitario.ToString().Replace(",", "."))
                Sql = Sql.Replace("#idusr#", gAdmin.User.Id)

                Cmd.Connection = lCnn
                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = Sql
                If lCnn.State = ConnectionState.Closed Then
                    lCnn.Open()
                End If

                Cmd.ExecuteNonQuery()
                lCnn.Close()

                'Grabo el log de auditoria.
                gAdmin.Log.fncGrabarLogAuditoria("UPD", "vz_ordencompra_det", Me.Id_OrdenDeCompra, gAdmin.User.Id, Me.ToString, ObjetoInicial)
            End If

            Guardar = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cOrdenCompraDet.Guardar")
            gAdmin.Log.fncGrabarLogERR("Error en cOrdenCompraDet.Guardar:" & ex.Message & vbCrLf & Sql)
        End Try

    End Function

    Public Overrides Function ToString() As String
        ToString = ""

        Try

            ToString = Me.GetType.ToString & "Id_OC_Detalle = " & Me.Id_OC_Detalle.ToString & vbCrLf
            ToString = Me.GetType.ToString & "Id_OrdenDeCompra = " & Me.Id_OrdenDeCompra.ToString & vbCrLf

            If IsNothing(Me.Articulo) Then
                ToString = Me.GetType.ToString & "Articulo = NULL " & vbCrLf
            Else
                ToString = Me.GetType.ToString & "Articulo = " & Me.Articulo.ToString & vbCrLf
            End If

            ToString = Me.GetType.ToString & "Cantidad = " & Me.Cantidad.ToString & vbCrLf
            ToString = Me.GetType.ToString & "PrecioUnitario = " & Me.PrecioUnitario.ToString("C") & vbCrLf
            ToString = Me.GetType.ToString & "Estado = " & Me.Estado.ToString & vbCrLf
            ToString = Me.GetType.ToString & "EsNuevo = " & Me.EsNuevo.ToString & vbCrLf

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cOrdenCompraDet.ToString")
            gAdmin.Log.fncGrabarLogERR("Error en cOrdenCompraDet.ToString" & ex.Message)
        End Try

    End Function

#End Region

#Region "Shared Funciones"

    Public Shared Function GetOrdenCompraDetxIdOrden(ByRef pAdmin As VzAdmin.cAdmin, ByVal pIdOrdenCompra As Integer) As ArrayList
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lOrdenCompraDet As cOrdenCompraDet = Nothing
        Dim lArray As New ArrayList

        Try
            lDt = Dat_GetOrdenCompraDetxIdOrden(pAdmin, pIdOrdenCompra)

            If lDt.Rows.Count > 0 Then
                For Each lDr In lDt.Rows
                    lOrdenCompraDet = New cOrdenCompraDet(pAdmin)
                    lOrdenCompraDet.Load(lDr)
                    lArray.Add(lOrdenCompraDet)
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
