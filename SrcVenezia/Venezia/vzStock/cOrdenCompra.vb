Imports System.IO
Imports System.Xml.Serialization
Imports MySql.Data.MySqlClient
Imports VzAdmin
Imports VzComercial

Public Class cOrdenCompra

    Private gAdmin As VzAdmin.cAdmin

    Private _Id_OrdenDeCompra As Integer
    Private _Fecha As Date
    Private _Proveedor As cProveedor
    Private _Detalle As ArrayList
    Private _Importe As Double
    Private _FechaEntrega As Date
    Private _Estado As cEstado
    Private _Observaciones As String
    Private _EsNuevo As Boolean = True

    Private ObjetoInicial As String = ""   'Esta es la serializacion del objeto ni bien se instancia, antes de que sea modificado por el usuario.

#Region "Declaraciones"

    Public Property Id_OrdenDeCompra As Integer
        Get
            Return _Id_OrdenDeCompra
        End Get
        Set(value As Integer)
            _Id_OrdenDeCompra = value
        End Set
    End Property

    Public Property Fecha As Date
        Get
            Return _Fecha
        End Get
        Set(value As Date)
            _Fecha = value
        End Set
    End Property

    Public Property Proveedor As cProveedor
        Get
            Return _Proveedor
        End Get
        Set(value As cProveedor)
            _Proveedor = value
        End Set
    End Property

    Public Property FechaEntrega As Date
        Get
            Return _FechaEntrega
        End Get
        Set(value As Date)
            _FechaEntrega = value
        End Set
    End Property

    Public Property Importe As Double
        Get
            ActualizarImporteCabFromArr()
            Return _Importe
        End Get
        Set(value As Double)
            _Importe = value
        End Set
    End Property

    Public Property Detalle As ArrayList
        Get
            Return _Detalle
        End Get
        Set(value As ArrayList)
            _Detalle = value
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

    Public Property Observaciones As String
        Get
            Return _Observaciones
        End Get
        Set(value As String)
            _Observaciones = value
        End Set
    End Property

#End Region

#Region "Funciones"

    Public Sub New()

    End Sub

    Public Sub New(ByVal lDr As DataRow)
        Load(lDr)
    End Sub

    Public Sub New(ByRef pAdmin As cAdmin)
        gAdmin = pAdmin
        _Detalle = New ArrayList
    End Sub

    Public Sub Load(ByVal lDr As DataRow)
        Try
            If Not IsNothing(lDr) Then
                Me.Id_OrdenDeCompra = lDr("id_ordencompra")
                Me.Fecha = lDr("fecha")
                Me.Proveedor = cProveedor.GetProveedorxNro(gAdmin, lDr("CodProve"))
                Me.Detalle = cOrdenCompraDet.GetOrdenCompraDetxIdOrden(Me.gAdmin, lDr("id_ordencompra"))
                Me.Importe = lDr("importe")
                Me.FechaEntrega = lDr("fecha_entrega")
                Me.FechaEntrega = lDr("observaciones")
                Me.Estado = cEstado.GetEstadoxIdTipoEstado(gAdmin, lDr("id_estado"), cEstado.enuTipoEstado.OrdenCompra)
                Me.EsNuevo = False
                Me.ObjetoInicial = Me.ToString
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cOrdenCompra.Load")
            gAdmin.Log.fncGrabarLogERR("Error en cOrdenCompra.Load:" & ex.Message)
        End Try
    End Sub

    Public Function Guardar() As Boolean
        Guardar = False
        Dim Cmd As New MySqlCommand
        Dim Sql As String = ""
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection = Nothing
        Dim lOCDet As cOrdenCompraDet = Nothing
        Try

            If EsNuevo = True Then 'INSERT

                ''-- Primero guardo la cabecera y luego voy por cada detalle.
                Sql = "CALL vz_ordencompra_ins('#Fecha#', #CodProve#, #Importe#, '#FechaEntrega#', '#Observac#', #idusr#);"
                Sql = Sql.Replace("#Fecha#", cFunciones.gFncConvertDateToString(Me.Fecha, "YYYY/MM/DD"))
                Sql = Sql.Replace("#CodProve#", Me.Proveedor.Id_Proveedor)
                Sql = Sql.Replace("#Importe#", Me.Importe.ToString().Replace(",", "."))
                Sql = Sql.Replace("#FechaEntrega#", cFunciones.gFncConvertDateToString(Me.Fecha, "YYYY/MM/DD"))
                Sql = Sql.Replace("#Observac#", Me.Observaciones.Trim)
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

                Me.Id_OrdenDeCompra = lDt(0)(0)

                'Seteo la orden en el detalle
                For Each lOCDet In Me.Detalle
                    lOCDet.Id_OrdenDeCompra = Me.Id_OrdenDeCompra
                    lOCDet.Guardar()
                Next

                Me.EsNuevo = False

            Else  'ACA VA EL UPDATE 

                Sql = "CALL vz_ordencompra_upd( #IdOrdenCompra#, '#Fecha#', #CodProve#, #Importe#, '#FechaEntrega#', '#Observac#', #idusr#);"
                Sql = Sql.Replace("#IdOrdenCompra#", Me.Proveedor.Id_Proveedor)
                Sql = Sql.Replace("#Fecha#", cFunciones.gFncConvertDateToString(Me.Fecha, "YYYY/MM/DD"))
                Sql = Sql.Replace("#CodProve#", Me.Proveedor.Id_Proveedor)
                Sql = Sql.Replace("#Importe#", Me.Importe.ToString().Replace(",", "."))
                Sql = Sql.Replace("#FechaEntrega#", cFunciones.gFncConvertDateToString(Me.Fecha, "YYYY/MM/DD"))
                Sql = Sql.Replace("#Observac#", Me.Observaciones.Trim)
                Sql = Sql.Replace("#idusr#", gAdmin.User.Id)

                Cmd.Connection = lCnn
                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = Sql
                If lCnn.State = ConnectionState.Closed Then
                    lCnn.Open()
                End If


                'FALTA AJUSTAR EL DETALLE DE ABM

                Cmd.ExecuteNonQuery()
                lCnn.Close()

                'Grabo el log de auditoria.
                gAdmin.Log.fncGrabarLogAuditoria("UPD", "vz_ordencompra", Me.Id_OrdenDeCompra, gAdmin.User.Id, Sql, Me.ToString, Me.ObjetoInicial)

            End If

            Guardar = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cOrdenCompra.Guardar")
            gAdmin.Log.fncGrabarLogERR("Error en cOrdenCompra.Guardar:" & ex.Message & vbCrLf & Sql)
        End Try
    End Function

    Private Sub ActualizarImporteCabFromArr()
        Dim lOcDet As cOrdenCompraDet = Nothing
        Dim lTotal As Double = 0
        Try
            For Each lOcDet In _Detalle
                lTotal = lTotal + lOcDet.Cantidad * lOcDet.PrecioUnitario
            Next
            _Importe = lTotal

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cOrdenCompra.ActualizarImporteCabFromArr")
            gAdmin.Log.fncGrabarLogERR("Error en cOrdenCompra.ActualizarImporteCabFromArr:" & ex.Message)
        End Try
    End Sub

    Private Sub ActualizarImporteCabFromBD()
        Dim Cmd As New MySqlCommand
        Dim Sql As String = ""
        Dim lCnn As MySqlConnection = Nothing
        Try
            Sql = "UPDATE vz_ordencompra set importe = (SELECT SUM(cantidad * preciounitario) FROM vz_ordencompra_det where id_ordencompra = #IdOrdenCompra#) where id_ordencompra = #IdOrdenCompra#;"
            Sql = Sql.Replace("#IdOrdenCompra#", Me.Id_OrdenDeCompra)

            Cmd.Connection = lCnn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = Sql
            If lCnn.State = ConnectionState.Closed Then
                lCnn.Open()
            End If
            Cmd.ExecuteNonQuery()
            lCnn.Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cOrdenCompra.ActualizarImporteCabFromBD")
            gAdmin.Log.fncGrabarLogERR("Error en cOrdenCompra.ActualizarImporteCabFromBD:" & ex.Message & vbCrLf & Sql)
        End Try
    End Sub

    Public Overrides Function ToString() As String
        ToString = ""
        Dim lOCdet As cOrdenCompraDet = Nothing

        Try
            ToString = Me.GetType.ToString & " Id_OrdenDeCompra = " & Me.Id_OrdenDeCompra.ToString & vbCrLf
            ToString = Me.GetType.ToString & " Fecha = " & Me.Fecha.ToShortDateString & vbCrLf
            If IsNothing(Me.Proveedor) Then
                ToString = Me.GetType.ToString & " Proveedor = null" & vbCrLf
            Else
                ToString = Me.GetType.ToString & " Proveedor = " & Me.Proveedor.ToString & vbCrLf
            End If
            ToString = Me.GetType.ToString & " Importe = " & Me.Importe.ToString("C") & vbCrLf
            ToString = Me.GetType.ToString & " FechaEntrega = " & Me.FechaEntrega.ToShortDateString & vbCrLf
            ToString = Me.GetType.ToString & " Estado = " & Me.Estado.ToString & vbCrLf
            ToString = Me.GetType.ToString & " Observaciones = " & Me.Observaciones & vbCrLf

            ToString = Me.GetType.ToString & " Detalle : " & vbCrLf
            For Each lOCdet In Me.Detalle
                ToString = vbTab & lOCdet.GetType.ToString & lOCdet.ToString
            Next

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cOrdenCompra.ToString")
            gAdmin.Log.fncGrabarLogERR("Error en cOrdenCompra.ToString" & ex.Message)
        End Try

    End Function

#End Region

#Region "Shared Funciones"

    Public Shared Function GetOrdenCompraxId(ByRef pAdmin As VzAdmin.cAdmin, ByVal pIdOrdenCompra As Integer) As cOrdenCompra
        Dim lDt As DataTable = Nothing
        Dim lDr As DataRow = Nothing
        Dim lOC As cOrdenCompra = Nothing

        Try
            lDt = Dat_GetOrdenCompraxId(pAdmin, pIdOrdenCompra)

            If lDt.Rows.Count > 0 Then
                lOC = New cOrdenCompra(pAdmin)
                lOC.Load(lDt.Rows(0))
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cOrdenCompra.GetOrdenCompraxId")
            pAdmin.Log.fncGrabarLogERR("Error en cOrdenCompra.GetOrdenCompraxId:" & ex.Message)
        End Try

        Return lOC

    End Function

    Public Shared Function GetOrdenCompraxProvFecEntregaDH(ByRef pAdmin As VzAdmin.cAdmin, ByVal pFEntregaD As Date, ByVal pFentregaH As Date, pProveedor As cProveedor) As ArrayList
        Dim lDt As DataTable = Nothing
        Dim lDr As DataRow = Nothing
        Dim lOC As cOrdenCompra = Nothing
        Dim lArray As New ArrayList

        Try
            lDt = Dat_GetOrdenCompraxProvFecEntregaDH(pAdmin, pFEntregaD, pFentregaH, pProveedor)

            For Each lDr In lDt.Rows
                lOC = New cOrdenCompra(pAdmin)
                lOC.Load(lDr)
                lArray.Add(lOC)
            Next

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cOrdenCompra.GetOrdenCompraxProvFecEntregaDH")
            pAdmin.Log.fncGrabarLogERR("Error en cOrdenCompra.GetOrdenCompraxProvFecEntregaDH:" & ex.Message)
        End Try

        Return lArray

    End Function

#End Region

#Region "Base de Datos"

    Private Shared Function Dat_GetOrdenCompraxId(ByRef pAdmin As VzAdmin.cAdmin, ByVal pIdOrdenCompra As Integer) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "select * from vz_ordencompra where id_ordencompra = #pIdOrdenCompra# ;"
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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cOrdenCompra.Dat_GetOrdenCompraxId")
            pAdmin.Log.fncGrabarLogERR("Error en cOrdenCompr.Dat_GetOrdenCompraxId:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Shared Function Dat_GetOrdenCompraxProvFecEntregaDH(ByRef pAdmin As VzAdmin.cAdmin, ByVal pFEntregaD As Date, ByVal pFentregaH As Date, pProveedor As cProveedor) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection
        Dim lArray As New ArrayList

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "SELECT * FROM vz_ordencompra WHERE fecha_entrega >= '#pfecha_entregaD#'  AND fecha_entrega <= '#pfecha_entregaH#' "
            If Not IsNothing(pProveedor) Then
                Sql = Sql & " And CodProve = #pIdCodProve# ;"
                Sql = Sql.Replace("#pIdCodProve#", pProveedor.Id_Proveedor)
            End If
            Sql = Sql.Replace("#pfecha_entregaD#", cFunciones.gFncConvertDateToString(pFEntregaD, "YYYY/MM/DD"))
            Sql = Sql.Replace("#pfecha_entregaH#", cFunciones.gFncConvertDateToString(pFentregaH, "YYYY/MM/DD"))

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cOrdenCompra.Dat_GetOrdenCompraxProvFecEntregaDH")
            pAdmin.Log.fncGrabarLogERR("Error en cOrdenCompr.Dat_GetOrdenCompraxProvFecEntregaDH:" & ex.Message)
            Return Nothing
        End Try
    End Function

#End Region

End Class
