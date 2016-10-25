Imports System.IO
Imports System.Xml.Serialization
Imports MySql.Data.MySqlClient
Imports VzAdmin
Imports VzComercial
Imports VzTesoreria

Public Class cOrdenDePago

#Region "Propiedades"

    Private _Id_Orden As Integer
    Private _Fecha As Date
    Private _Importe_cash As Double
    Private _Importe_transferencia As Double
    Private _Importe_cheques As Double
    Private _Tipo_Destino As enuTipoDestinoOrdenPago '(Deposito, Cobro, Proveedores, Retiro, Otro)
    Private _Destino As String
    Private _Proveedor As cProveedor
    Private _Estado As cEstado
    Private _Observaciones As String
    Private _EsNuevo As Boolean = True
    Private _Cheques As ArrayList = Nothing

    Private ObjetoInicial As String = ""   'Esta es la serializacion del objeto ni bien se instancia, antes de que sea modificado por el usuario.
    'Private _Cliente As cCliente

    Private gAdmin As VzAdmin.cAdmin

    Public Property Id_Orden As Integer
        Get
            Return _Id_Orden
        End Get
        Set(value As Integer)
            _Id_Orden = value
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

    Public Property Importe_cash As Double
        Get
            Return _Importe_cash
        End Get
        Set(value As Double)
            _Importe_cash = value
        End Set
    End Property

    Public Property Importe_transferencia As Double
        Get
            Return _Importe_transferencia
        End Get
        Set(value As Double)
            _Importe_transferencia = value
        End Set
    End Property

    Public Property Importe_cheques As Double
        Get
            Return _Importe_cheques
        End Get
        Set(value As Double)
            _Importe_cheques = value
        End Set
    End Property

    Public Property Tipo_Destino As enuTipoDestinoOrdenPago
        Get
            Return _Tipo_Destino
        End Get
        Set(value As enuTipoDestinoOrdenPago)
            _Tipo_Destino = value
        End Set
    End Property

    Public Property Destino As String
        Get
            Return _Destino
        End Get
        Set(value As String)
            _Destino = value
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

    Public Property Estado As cEstado
        Get
            Return _Estado
        End Get
        Set(value As cEstado)
            _Estado = value
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

    Public Property EsNuevo As Boolean
        Get
            Return _EsNuevo
        End Get
        Set(value As Boolean)
            _EsNuevo = value
        End Set
    End Property

    Public Property Cheques As ArrayList
        Get
            Return _Cheques
        End Get
        Set(value As ArrayList)
            _Cheques = value
        End Set
    End Property


#Region "enuTipoLiqCheque"

    Public Enum enuTipoDestinoOrdenPago
        Deposito = 0
        Cobro = 1
        Proveedores = 2
        Retiro = 3
        Otro = 4
        Null = 99

    End Enum

    Public Shared Function enuTipoDestinoOrdenPagoGetCod(ByVal pTipoValor As enuTipoDestinoOrdenPago) As String
        Select Case pTipoValor
            Case enuTipoDestinoOrdenPago.Deposito
                Return "D"
            Case enuTipoDestinoOrdenPago.Cobro
                Return "C"
            Case enuTipoDestinoOrdenPago.Retiro
                Return "R"
            Case enuTipoDestinoOrdenPago.Proveedores
                Return "P"
            Case enuTipoDestinoOrdenPago.Otro
                Return "O"
            Case Else
                Return "99"
        End Select
    End Function

    Public Shared Function enuTipoDestinoOrdenPagoGetEnu(ByVal pTipoValor As String) As enuTipoDestinoOrdenPago
        Select Case pTipoValor
            Case "D"
                Return enuTipoDestinoOrdenPago.Deposito
            Case "R"
                Return enuTipoDestinoOrdenPago.Retiro
            Case "P"
                Return enuTipoDestinoOrdenPago.Proveedores
            Case "O"
                Return enuTipoDestinoOrdenPago.Otro
            Case "C"
                Return enuTipoDestinoOrdenPago.Cobro
            Case Else
                Return enuTipoDestinoOrdenPago.Null
        End Select
    End Function

    Public Shared Function enuTipoDestinoOrdenPagoGetEnuxStr(ByVal pTipoValor As String) As enuTipoDestinoOrdenPago
        Select Case pTipoValor
            Case "Deposito"
                Return enuTipoDestinoOrdenPago.Deposito
            Case "Retiro"
                Return enuTipoDestinoOrdenPago.Retiro
            Case "Proveedores"
                Return enuTipoDestinoOrdenPago.Proveedores
            Case "Otro"
                Return enuTipoDestinoOrdenPago.Otro
            Case "Cobro"
                Return enuTipoDestinoOrdenPago.Cobro
            Case Else
                Return enuTipoDestinoOrdenPago.Null
        End Select
    End Function

    Public Shared Function enuTipoDestinoOrdenPagoGetStrxEnu(ByVal pTipoValor As enuTipoDestinoOrdenPago) As String
        Select Case pTipoValor
            Case enuTipoDestinoOrdenPago.Deposito
                Return "Deposito"
            Case enuTipoDestinoOrdenPago.Retiro
                Return "Retiro"
            Case enuTipoDestinoOrdenPago.Proveedores
                Return "Proveedores"
            Case enuTipoDestinoOrdenPago.Otro
                Return "Otro"
            Case enuTipoDestinoOrdenPago.Cobro
                Return "Cobro"
            Case Else
                Return " "
        End Select
    End Function

    Public Shared Function enuTipoDestinoOrdenPagoGetCodxStr(ByVal pTipoValor As String) As String
        Select Case pTipoValor
            Case "Deposito"
                Return "D"
            Case "Retiro"
                Return "R"
            Case "Proveedores"
                Return "P"
            Case "Otro"
                Return "O"
            Case "Cobro"
                Return "C"
            Case Else
                Return enuTipoDestinoOrdenPago.Null
        End Select
    End Function

    Public Shared Function enuTipoDestinoOrdenPagoGetStrxCod(ByVal pTipoValor As String) As String
        Select Case pTipoValor
            Case "D"
                Return "Deposito"
            Case "R"
                Return "Retiro"
            Case "P"
                Return "Proveedores"
            Case "O"
                Return "Otro"
            Case "C"
                Return "Cobro"
            Case Else
                Return " "
        End Select
    End Function

#End Region

#End Region

#Region "Funciones"

    Public Sub New()

    End Sub

    Public Sub New(ByRef pAdmin As VzAdmin.cAdmin)

        gAdmin = pAdmin

    End Sub

    Public Function ToXML() As String
        'ToXML = ""
        'Try
        '    Using sw As New StringWriter()
        '        Dim serialitzador As New XmlSerializer(GetType(cOrdenDePago), New Type() {GetType(cCheque), GetType(cProveedor), GetType(cEstado), GetType(cAdmin), GetType(cUser)})
        '        serialitzador.Serialize(sw, Me)
        '        ToXML = sw.ToString()
        '    End Using

        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, "cOrdenDePago.ToXML")
        '    gAdmin.Log.fncGrabarLogERR("Error en cOrdenDePago.ToXML" & ex.Message)
        'End Try

    End Function

    Private Sub Load(ByVal lDr As DataRow)

        Try
            _Id_Orden = lDr("id_orden")
            _Fecha = lDr("fecha")
            _Importe_cash = lDr("importe_cash")
            _Importe_transferencia = lDr("importe_transferencia")
            _Importe_cheques = lDr("importe_cheques")
            _Tipo_Destino = enuTipoDestinoOrdenPagoGetEnu(lDr("tipo_destino"))
            _Destino = lDr("destino")
            _Proveedor = VzComercial.cProveedor.GetProveedorxNro(gAdmin, cFunciones.gFncgetDbValue(lDr("CodProve"), cFunciones.TipoDato.NUMERO))
            _Observaciones = lDr("observaciones")
            _Estado = cEstado.GetEstadoxIdTipoEstado(gAdmin, lDr("id_estado"), cEstado.enuTipoEstado.Orden_De_Pago)
            _EsNuevo = False
            _Cheques = cCheque.GetChequesxOrdenDePago(gAdmin, Me.Id_Orden)
            ObjetoInicial = Me.ToXML()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cOrdenDePago.Load")
            gAdmin.Log.fncGrabarLogERR("Error en cOrdenDePago.Load:" & ex.Message)
        End Try
    End Sub

    Public Function Guardar() As Boolean
        Guardar = False
        Dim Cmd As New MySqlCommand
        Dim Sql As String = ""
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection = Nothing
        Dim lCheque As cCheque = Nothing

        Try
            'Validaciones

            'Valido que los cheques seleccionados esten en el estado valido para gestionar.
            If Me.Importe_cheques > 0 Then
                For Each lCheque In Me.Cheques
                    If Not lCheque.Estado.Id_Estado = 0 Then 'Si no esta en cartera
                        MsgBox("El cheque id=" & lCheque.Id_Cheque & " no se puede vincular a una orden de pago en este estado'" & lCheque.Estado.Estado & "'", MsgBoxStyle.Exclamation, "Error de Validacion")
                        Exit Function
                    End If
                Next
            End If
            If _EsNuevo = True Then 'INSERT

                ''-- Primero guardo la cabecera y luego voy por cada detalle.
                Sql = "Call vz_ordendepago_ins('#Fecha#', #Importe_cash#, #Importe_transferencia#, #Importe_cheques#,'#Tipo_Destino#','#Destino#', #CodProve#, #Estado# , '#Observac#', #idusr#)"
                Sql = Sql.Replace("#Fecha#", cFunciones.gFncConvertDateToString(Me.Fecha, "YYYY/MM/DD"))
                Sql = Sql.Replace("#Importe_cash#", Me.Importe_cash)
                Sql = Sql.Replace("#Importe_transferencia#", Me.Importe_transferencia)
                Sql = Sql.Replace("#Importe_cheques#", Me.Importe_cheques)
                Sql = Sql.Replace("#Tipo_Destino#", enuTipoDestinoOrdenPagoGetCod(Me.Tipo_Destino))
                Sql = Sql.Replace("#Destino#", Me.Observaciones)
                If Not IsNothing(Me.Proveedor) Then
                    Sql = Sql.Replace("#CodProve#", Me.Proveedor.Id_Proveedor)
                Else
                    Sql = Sql.Replace("#CodProve#", "null")
                End If
                Sql = Sql.Replace("#Observac#", Me.Observaciones)
                Sql = Sql.Replace("#Estado#", "1")
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

                Me.Id_Orden = lDt(0)(0)

                'Seteo la orden de pago en los cheques vinculados
                If Me.Importe_cheques > 0 Then
                    cCheque.SetOrdenDePago(gAdmin, Me.Cheques, Me.Id_Orden)
                End If

                EsNuevo = False

            Else  'ACA VA EL UPDATE 

                Sql = "Call vz_ordendepago_upd(#IdOrden#, '#Fecha#', #Importe_cash#, #Importe_transferencia#, #Importe_cheques#,'#Tipo_Destino#','#Destino#', #CodProve#, #Estado# , '#Observac#', #idusr#)"
                Sql = Sql.Replace("#IdOrden#", Me.Id_orden)
                Sql = Sql.Replace("#Fecha#", cFunciones.gFncConvertDateToString(Me.Fecha, "YYYY/MM/DD"))
                Sql = Sql.Replace("#Importe_cash#", Me.Importe_cash)
                Sql = Sql.Replace("#Importe_transferencia#", Me.Importe_transferencia)
                Sql = Sql.Replace("#Importe_cheques#", Me.Importe_cheques)
                Sql = Sql.Replace("#Tipo_Destino#", enuTipoDestinoOrdenPagoGetCod(Me.Tipo_Destino))
                Sql = Sql.Replace("#Destino#", Me.Observaciones)
                If Not IsNothing(Me.Proveedor) Then
                    Sql = Sql.Replace("#CodProve#", Me.Proveedor.Id_Proveedor)
                Else
                    Sql = Sql.Replace("#CodProve#", "null")
                End If
                Sql = Sql.Replace("#Observac#", Me.Observaciones)
                Sql = Sql.Replace("#Estado#", Me.Estado.Id_Estado)
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
                gAdmin.Log.fncGrabarLogAuditoria("UPD", "vz_ordenes_de_pago", Me.Id_Orden, gAdmin.User.Id, Me.ToXML, ObjetoInicial)
            End If

            Guardar = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cOrdenDePago.Guardar")
            gAdmin.Log.fncGrabarLogERR("Error en cOrdenDePago.Guardar:" & ex.Message & vbCrLf & Sql)
        End Try
    End Function

    Public Function Total() As Double
        Total = (_Importe_cash + _Importe_cheques + _Importe_transferencia)
    End Function

#End Region

#Region "Shared Functions"

    Public Shared Function GetOrdenDePagoxId(ByRef pAdmin As VzAdmin.cAdmin, ByVal pId As Integer) As cOrdenDePago
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lOrden As cOrdenDePago = Nothing

        Try
            lDt = Dat_OrdenDePagoxID(pAdmin, pId)

            If lDt.Rows.Count > 0 Then

                For Each lDr In lDt.Rows
                    lOrden = New cOrdenDePago(pAdmin)
                    lOrden.Load(lDr)
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cOrdenDePago.GetOrdenDePagoxId")
            pAdmin.Log.fncGrabarLogERR("Error en cOrdenDePago.GetOrdenDePagoxId:" & ex.Message)
        End Try

        Return lOrden

    End Function

    Public Shared Function GetOrdenDePagoConsulta(ByRef pAdmin As VzAdmin.cAdmin, ByVal pIdOrden As Integer, ByVal pFechaD As Date, ByVal pFechaH As Date, ByVal pTipoDest As String, ByVal pCodProve As Integer, ByVal pEstado As Integer, pObserv As String) As ArrayList

        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lOrden As cOrdenDePago = Nothing
        Dim lArray As ArrayList = Nothing

        Try
            lDt = Dat_OrdenDePagoConsulta(pAdmin, pIdOrden, pFechaD, pFechaH, pTipoDest, pCodProve, pEstado, pObserv)

            If lDt.Rows.Count > 0 Then
                lArray = New ArrayList
                For Each lDr In lDt.Rows
                    lOrden = New cOrdenDePago(pAdmin)
                    lOrden.Load(lDr)
                    lArray.Add(lOrden)
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cOrdenDePago.GetOrdenDePagoxId")
            pAdmin.Log.fncGrabarLogERR("Error en cOrdenDePago.GetOrdenDePagoxId:" & ex.Message)
        End Try

        Return lArray

    End Function

#End Region

#Region "Base de Datos"

    Private Shared Function Dat_OrdenDePagoxID(ByRef pAdmin As VzAdmin.cAdmin, ByVal pId As String) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "Select * from vz_ordenes_de_pago where id_orden=#Id#"
            Sql = Sql.Replace("#Id#", pId)

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cOrdenDePago.Dat_OrdenDePagoxID")
            pAdmin.Log.fncGrabarLogERR("Error en cOrdenDePago.Dat_OrdenDePagoxID:" & ex.Message)
            Return Nothing
        End Try

    End Function

    Private Shared Function Dat_OrdenDePagoConsulta(ByRef pAdmin As VzAdmin.cAdmin, ByVal pIdOrden As Integer, ByVal pFechaD As Date, ByVal pFechaH As Date, ByVal pTipoDest As String, ByVal pCodProve As Integer, ByVal pEstado As Integer, pObserv As String) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "CALL vz_ordendepago_consulta (#IdOrden#,'#FechaD#','#FechaH#','#TipoDest#',#CodProve#,#IdEstado#,'%#Observ#%')"
            Sql = Sql.Replace("#IdOrden#", pIdOrden)
            Sql = Sql.Replace("#FechaD#", cFunciones.gFncConvertDateToString(pFechaD, "YYYY/MM/DD"))
            Sql = Sql.Replace("#FechaH#", cFunciones.gFncConvertDateToString(pFechaH, "YYYY/MM/DD"))
            Sql = Sql.Replace("#TipoDest#", pTipoDest)
            Sql = Sql.Replace("#CodProve#", pCodProve)
            Sql = Sql.Replace("#IdEstado#", pEstado)
            Sql = Sql.Replace("#Observ#", Trim(pObserv))

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cOrdenDePago.Dat_OrdenDePagoxID")
            pAdmin.Log.fncGrabarLogERR("Error en cOrdenDePago.Dat_OrdenDePagoxID:" & ex.Message)
            Return Nothing
        End Try
    End Function

#End Region

End Class
