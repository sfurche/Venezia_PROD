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

#End Region


#Region "Funciones"

    Public Sub New()

    End Sub

    Public Sub New(ByRef pAdmin As cAdmin)
        gAdmin = pAdmin
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
                Me.Estado = cEstado.GetEstadoxIdTipoEstado(gAdmin, lDr("id_estado"), cEstado.enuTipoEstado.OrdenCompra)
                Me._EsNuevo = False
                Me.ObjetoInicial = Me.ToXML
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

            If _EsNuevo = True Then 'INSERT

                ''-- Primero guardo la cabecera y luego voy por cada detalle.
                Sql = "CALL vz_ordencompra_ins('#Fecha#', #CodProve#, #Importe#, '#FechaEntrega#', #idusr#);"
                Sql = Sql.Replace("#Fecha#", cFunciones.gFncConvertDateToString(Me.Fecha, "YYYY/MM/DD"))
                Sql = Sql.Replace("#CodProve#", Me.Proveedor.Id_Proveedor)
                Sql = Sql.Replace("#Importe#", Me.Importe.ToString().Replace(",", "."))
                Sql = Sql.Replace("#FechaEntrega#", cFunciones.gFncConvertDateToString(Me.Fecha, "YYYY/MM/DD"))
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

                'Seteo la orden de pago en los cheques vinculados
                For Each lOCDet In Me.Detalle
                    lOCDet.Id_OrdenDeCompra = Me.Id_OrdenDeCompra
                    lOCDet.Guardar()
                Next

                Me._EsNuevo = False

            Else  'ACA VA EL UPDATE 

                'Sql = "CALL vz_ordencompra_upd(1, '2017/03/27', 16, 2000, '2017/03/31', 19);"
                Sql = "CALL vz_ordencompra_ins( #IdOrdenCompra#, '#Fecha#', #CodProve#, #Importe#, '#FechaEntrega#', #idusr#);"
                Sql = Sql.Replace("#IdOrdenCompra#", Me.Proveedor.Id_Proveedor)
                Sql = Sql.Replace("#Fecha#", cFunciones.gFncConvertDateToString(Me.Fecha, "YYYY/MM/DD"))
                Sql = Sql.Replace("#CodProve#", Me.Proveedor.Id_Proveedor)
                Sql = Sql.Replace("#Importe#", Me.Importe.ToString().Replace(",", "."))
                Sql = Sql.Replace("#FechaEntrega#", cFunciones.gFncConvertDateToString(Me.Fecha, "YYYY/MM/DD"))
                Sql = Sql.Replace("#idusr#", gAdmin.User.Id)

                Cmd.Connection = lCnn
                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = Sql
                If lCnn.State = ConnectionState.Closed Then
                    lCnn.Open()
                End If

                Cmd.ExecuteNonQuery()
                lCnn.Close()

                'Seteo la orden de pago en los cheques vinculados y elimino los desvinculados.
                If Me.Importe_cheques > 0 Then
                    cCheque.SetOrdenDePago(gAdmin, Me.Cheques, Me.Id_Orden)
                End If

                'Grabo el log de auditoria.
                gAdmin.Log.fncGrabarLogAuditoria("UPD", "vz_ordencompra", Me.Id_OrdenDeCompra, gAdmin.User.Id, Me.ToXML, ObjetoInicial)
            End If

            Guardar = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cOrdenCompra.Guardar")
            gAdmin.Log.fncGrabarLogERR("Error en cOrdenCompra.Guardar:" & ex.Message & vbCrLf & Sql)
        End Try
    End Function

    Private Sub ActualizarImporteCab()
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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cOrdenCompra.ActualizarImporteCab")
            gAdmin.Log.fncGrabarLogERR("Error en cOrdenCompra.ActualizarImporteCab:" & ex.Message & vbCrLf & Sql)
        End Try
    End Sub

    Public Function ToXML() As String
        ToXML = ""
        Try
            Using sw As New StringWriter()
                'Dim serialitzador As New XmlSerializer(GetType(cOrdenDePago), New Type() {GetType(cCheque), GetType(cProveedor), New Type() {GetType(cCondicionIVA), GetType(cSitIB)}, GetType(cEstado), GetType(cAdmin), GetType(cUser)})
                Dim serialitzador As New XmlSerializer(GetType(cOrdenCompra), New Type() {GetType(cOrdenCompraDet), GetType(cProveedor), GetType(cEstado), GetType(cAdmin), GetType(cUser)})
                serialitzador.Serialize(sw, Me)
                ToXML = sw.ToString()
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cOrdenCompra.ToXML")
            gAdmin.Log.fncGrabarLogERR("Error en cOrdenCompra.ToXML" & ex.Message)
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

#End Region

End Class
