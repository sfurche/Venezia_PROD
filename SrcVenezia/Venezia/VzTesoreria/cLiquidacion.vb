﻿Imports System.IO
Imports System.Xml.Serialization
Imports MySql.Data.MySqlClient
Imports VzAdmin
Imports VzComercial

Public Class cLiquidacion

    Private _id_Liquidacion As Integer
    Private _Vendedor As VzComercial.cVendedor
    Private _Fecha As Date
    Private _Importe_Cash As Double
    Private _Importe_Cheques As Double
    Private _Importe_Retenciones As Double
    Private _Importe_Transferencias As Double
    Private _Importe_NCredito As Double
    Private _Observaciones As String
    Private _Estado As cEstado
    Private _Liquidacion_Det As ArrayList
    Private _EsNuevo As Boolean = True
    Private _Completa As Boolean = False
    Private _Conciliada As Boolean = False
    Private _Transferencias As ArrayList


    Private ObjetoInicial As String = ""   'Esta es la serializacion del objeto ni bien se instancia, antes de que sea modificado por el usuario.
    'Private _Cliente As cCliente

    Private gAdmin As VzAdmin.cAdmin

#Region "Propiedades"

    Public Property Id_Liquidacion As Integer
        Get
            Return _id_Liquidacion
        End Get
        Set(value As Integer)
            _id_Liquidacion = value
        End Set
    End Property

    Public Property Vendedor As VzComercial.cVendedor
        Get
            Return _Vendedor
        End Get
        Set(value As VzComercial.cVendedor)
            _Vendedor = value
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

    Public Property Importe_Cash As Double
        Get
            Me.RecalcularTotales()
            Return _Importe_Cash
        End Get
        Set(value As Double)
            _Importe_Cash = value
        End Set
    End Property

    Public Property Importe_Retenciones As Double
        Get
            Me.RecalcularTotales()
            Return _Importe_Retenciones
        End Get
        Set(value As Double)
            _Importe_Retenciones = value
        End Set
    End Property

    Public Property Importe_Transferencias As Double
        Get
            Me.RecalcularTotales()
            Return _Importe_Transferencias
        End Get
        Set(value As Double)
            _Importe_Transferencias = value
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

    Public Property Estado As cEstado
        Get
            Return _Estado
        End Get
        Set(value As cEstado)
            _Estado = value
        End Set
    End Property

    Public Property Importe_NCredito As Double
        Get
            Me.RecalcularTotales()
            Return _Importe_NCredito
        End Get
        Set(value As Double)
            _Importe_NCredito = value
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

    Public Property Liquidacion_Det As ArrayList
        Get
            Return _Liquidacion_Det
        End Get
        Set(value As ArrayList)
            _Liquidacion_Det = value
        End Set
    End Property

    Public Property Importe_Cheques As Double
        Get
            Me.RecalcularTotales()
            Return _Importe_Cheques
        End Get
        Set(value As Double)
            _Importe_Cheques = value
        End Set
    End Property

    Public Property Completa As Boolean
        Get
            Return _Completa
        End Get
        Set(value As Boolean)
            _Completa = value
        End Set
    End Property

    Public Property Conciliada As Boolean
        Get
            Return _Conciliada
        End Get
        Set(value As Boolean)
            _Conciliada = value
        End Set
    End Property

    Public ReadOnly Property DisplayName As String
        Get
            Return Me.Fecha.ToShortDateString() & " - Id Liq: " & Me.Id_Liquidacion.ToString & " (" & Me.Vendedor.Nombre & ") - " & "Total: $" & Me.TotalLiq.ToString
        End Get

    End Property

    Public Property Transferencias As ArrayList
        Get
            Return _Transferencias
        End Get
        Set(value As ArrayList)
            _Transferencias = value
        End Set
    End Property

#End Region

#Region "EnuEstadoLiq"

    Public Enum enuEstadoLiq
        Incompleta = 0
        Completa = 1
        Conciliada = 2
    End Enum

#End Region

#Region "Funciones"

    Public Sub New()

    End Sub

    Public Sub New(ByRef pAdmin As VzAdmin.cAdmin)
        gAdmin = pAdmin
        Me.Liquidacion_Det = New ArrayList
        Me.EsNuevo = True
    End Sub

    'Public Sub New(ByRef pAdmin As VzAdmin.cAdmin, ByVal pid_Liquidacion As Integer)
    '    gAdmin = pAdmin
    '    Me.Liquidacion_Det = New ArrayList
    'End Sub

    Private Sub subCargarDatos(ByVal lDr As DataRow)

        Try
            _id_Liquidacion = lDr("id_liquidacion")
            _Fecha = lDr("fecha")
            _Importe_Cash = lDr("importe_cash")
            _Importe_NCredito = lDr("importe_ncredito")
            _Importe_Transferencias = lDr("importe_transferencias")
            _Importe_Retenciones = lDr("importe_retenciones")
            _Observaciones = lDr("observaciones")
            _Estado = cEstado.GetEstadoxIdTipoEstado(gAdmin, lDr("id_estado"), cEstado.enuTipoEstado.Liquidacion)
            _Vendedor = VzComercial.cVendedor.GetVendedorexId(gAdmin, lDr("id_vendedor"))
            _EsNuevo = False
            _Liquidacion_Det = cLiquidacion_Det.LiqDet_BusqxIdLiquidacion(gAdmin, Me.Id_Liquidacion)
            _Transferencias = cTransferencia.GetTransferenciasxIdLiq(gAdmin, Me.Id_Liquidacion)

            Me.ValidarCompletitudCheques()

            ObjetoInicial = Me.ToXML()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cLiquidacion.subCargarDatos")
            gAdmin.Log.fncGrabarLogERR("Error en cLiquidacion.subCargarDatos:" & ex.Message)
        End Try

    End Sub

    Private Sub ValidarCompletitudCheques()
        Try
            'Valido si el total de cheques cargados se corresponde con el detalle
            Dim lLiqChk As cLiquidacion_Det = Me.GetLiqDetCheques
            Dim lTotChequesCargados As Decimal = 0

            If Not IsNothing(lLiqChk) Then
                Me.Completa = lLiqChk.Completo
            Else
                Me.Completa = True
            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cLiquidacion.ValidarCompletitud")
            gAdmin.Log.fncGrabarLogERR("Error en cLiquidacion.ValidarCompletitud:" & ex.Message)
        End Try
    End Sub

    Private Sub ActualizarEstado()
        Try

            Me.ValidarCompletitudCheques() ' Valido si estan cargados los cheques y si coincide con el total de la liq.

            If Me.Completa = False Then 'Incompleta
                Me.Estado = cEstado.GetEstadoxIdTipoEstado(gAdmin, 0, cEstado.enuTipoEstado.Liquidacion)

            ElseIf Me.Completa = True And Conciliada = False Then 'Completa
                Me.Estado = cEstado.GetEstadoxIdTipoEstado(gAdmin, 1, cEstado.enuTipoEstado.Liquidacion)

            ElseIf Me.Completa = True And Conciliada = True Then 'Conciliada
                Me.Estado = cEstado.GetEstadoxIdTipoEstado(gAdmin, 2, cEstado.enuTipoEstado.Liquidacion)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cLiquidacion.ActualizarEstado")
            gAdmin.Log.fncGrabarLogERR("Error en cLiquidacion.ActualizarEstado:" & ex.Message)
        End Try
    End Sub

    Private Sub CambiarEstado(ByVal pNuevoEstado As cEstado)
        Dim Cmd As New MySqlCommand
        Dim Sql As String = ""
        Dim lCnn As MySqlConnection
        Try

            Me.Estado = pNuevoEstado

            Sql = "call vz_liquidaciones_cambest (#IdLiquidacion#, #Estado#,'#idusr#')"
            Sql = Sql.Replace("#IdLiquidacion#", Me.Id_Liquidacion)
            Sql = Sql.Replace("#Estado#", Me.Estado.Id_Estado)
            Sql = Sql.Replace("#idusr#", gAdmin.User.Id)

            lCnn = gAdmin.DbCnn.GetInstanceCon
            Cmd.Connection = lCnn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = Sql
            If lCnn.State = ConnectionState.Closed Then
                lCnn.Open()
            End If
            Cmd.ExecuteNonQuery()
            lCnn.Close()


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cLiquidacion.CambiarEstado")
            gAdmin.Log.fncGrabarLogERR("Error en cLiquidacion.CambiarEstado:" & ex.Message)
        End Try
    End Sub

    Public Function Guardar(Optional ByVal pLiqBkp As String = "") As Boolean

        Guardar = False
        Dim Cmd As New MySqlCommand
        Dim Sql As String = ""
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection
        Dim lLiqDet As cLiquidacion_Det = Nothing
        Dim lTransf As cTransferencia = Nothing

        Try
            ''-- Primero guardo la cabecera y luego voy por cada detalle.
            lCnn = gAdmin.DbCnn.GetInstanceCon

            Me.ActualizarEstado()

            If Me.EsNuevo = True Then

                ''-- Primero guardo la cabecera y luego voy por cada detalle.

                'CALL vz_liquidaciones_ins(3,'2016/01/05', 0, 305.55, 4654.99, 343.34, 4344.22, 'OBSERVAC',1 ,  9) 
                Sql = "Call vz_liquidaciones_ins(#IdVendedor#, '#Fecha#', #ImporteEfe#, #ImporteCh#, #ImporteRet#,#ImporteTra#,#ImporteNC#, '#Observac#' , #Estado# , #idusr#)"
                Sql = Sql.Replace("#IdVendedor#", Me.Vendedor.IdVendedor)
                Sql = Sql.Replace("#Fecha#", cFunciones.gFncConvertDateToString(Me.Fecha, "YYYY/MM/DD"))
                Sql = Sql.Replace("#ImporteEfe#", Me.Importe_Cash)
                Sql = Sql.Replace("#ImporteCh#", Me.Importe_Cheques)
                Sql = Sql.Replace("#ImporteTra#", Me.Importe_Transferencias)
                Sql = Sql.Replace("#ImporteNC#", Me.Importe_NCredito)
                Sql = Sql.Replace("#ImporteRet#", Me.Importe_Retenciones)
                Sql = Sql.Replace("#Observac#", Me.Observaciones)
                Sql = Sql.Replace("#Estado#", Me.Estado.Id_Estado)
                Sql = Sql.Replace("#idusr#", gAdmin.User.Id)

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
                Me.Id_Liquidacion = lDt(0)(0)

                'Asigno el valor de la liquidacion que acabo de guardar y luego guardo el detalle.
                For Each lLiqDet In Me.Liquidacion_Det
                    lLiqDet.Id_Liquidacion = Me.Id_Liquidacion
                    lLiqDet.Guardar()
                Next

                If Not IsNothing(Me.Transferencias) Then
                    For Each lTransf In Me.Transferencias
                        lTransf.Id_Liquidacion = Me.Id_Liquidacion
                        lTransf.Save()
                    Next
                End If

                EsNuevo = False
            Else  'ACA VA EL UPDATE ------------------------------------------------------------

                ''-- Primero guardo la cabecera y luego voy por cada detalle.

                'CALL vz_liquidaciones_ins(3,'2016/01/05', 0, 305.55, 4654.99, 343.34, 4344.22, 'OBSERVAC',1 ,  9) 
                Sql = "Call vz_liquidaciones_upd(#IdLiquidacion#, #IdVendedor#, '#Fecha#', #ImporteEfe#, #ImporteCh#, #ImporteRet#,#ImporteTra#,#ImporteNC#, '#Observac#' , #Estado# , #idusr#)"
                Sql = Sql.Replace("#IdLiquidacion#", Me.Id_Liquidacion)
                Sql = Sql.Replace("#IdVendedor#", Me.Vendedor.IdVendedor)
                Sql = Sql.Replace("#Fecha#", cFunciones.gFncConvertDateToString(Me.Fecha, "YYYY/MM/DD"))
                Sql = Sql.Replace("#ImporteEfe#", Me.Importe_Cash)
                Sql = Sql.Replace("#ImporteCh#", Me.Importe_Cheques)
                Sql = Sql.Replace("#ImporteTra#", Me.Importe_Transferencias)
                Sql = Sql.Replace("#ImporteNC#", Me.Importe_NCredito)
                Sql = Sql.Replace("#ImporteRet#", Me.Importe_Retenciones)
                Sql = Sql.Replace("#Observac#", Me.Observaciones)
                Sql = Sql.Replace("#Estado#", Me.Estado.Id_Estado)
                Sql = Sql.Replace("#idusr#", gAdmin.User.Id)

                Cmd.Connection = lCnn
                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = Sql
                If lCnn.State = ConnectionState.Closed Then
                    lCnn.Open()
                End If
                'Dim lAdap As New MySqlDataAdapter(Cmd)
                'lDt = New DataTable
                'lAdap.Fill(lDt)
                Cmd.ExecuteNonQuery()
                lCnn.Close()
                'Me.Id_Liquidacion = lDt(0)(0)

                'Asigno el valor de la liquidacion que acabo de guardar y luego guardo el detalle.
                For Each lLiqDet In Me.Liquidacion_Det
                    lLiqDet.Guardar()
                Next

                If Not IsNothing(Me.Transferencias) Then
                    For Each lTransf In Me.Transferencias
                        lTransf.Save()
                    Next
                End If

                'Grabo el log de auditoria.
                gAdmin.Log.fncGrabarLogAuditoria("UPD", "vz_liquidaciones", Me.Id_Liquidacion, gAdmin.User.Id, Me.ToXML, pLiqBkp)

            End If

            Guardar = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cLiquidacion.Guardar")
            gAdmin.Log.fncGrabarLogERR("Error en cLiquidacion.Guardar con Liquidacion id=" & Me.Id_Liquidacion.ToString & " - " & ex.Message)
        End Try
    End Function

    Public Sub AddLiqDetalle(ByRef pLiqDet As cLiquidacion_Det)

        Try

            Me.Liquidacion_Det.Add(pLiqDet)

            Me.RecalcularTotales()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cLiquidacion.GetLiqDetCheques")
            gAdmin.Log.fncGrabarLogERR("Error en cLiquidacion.GetLiqDetCheques" & ex.Message)
        End Try

    End Sub

    Public Function GetLiqDetCheques() As cLiquidacion_Det
        GetLiqDetCheques = Nothing
        Dim lLiqDet As cLiquidacion_Det
        Try

            If Not IsNothing(Me.Liquidacion_Det) Then
                For Each lLiqDet In Me.Liquidacion_Det
                    If lLiqDet.Tipo_Valor = cLiquidacion_Det.enuTipoValor.Cheque Then
                        GetLiqDetCheques = lLiqDet
                    End If
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cLiquidacion.GetLiqDetCheques")
            gAdmin.Log.fncGrabarLogERR("Error en cLiquidacion.GetLiqDetCheques" & ex.Message)
        End Try

    End Function

    Public Function GetLiqDetxTipo(ByVal pTipoValor As cLiquidacion_Det.enuTipoValor) As cLiquidacion_Det
        GetLiqDetxTipo = Nothing
        Dim lLiqDet As cLiquidacion_Det
        Try

            If Not IsNothing(Me.Liquidacion_Det) Then
                For Each lLiqDet In Me.Liquidacion_Det
                    If lLiqDet.Tipo_Valor = pTipoValor Then
                        GetLiqDetxTipo = lLiqDet
                    End If
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cLiquidacion.GetLiqDetxTipo")
            gAdmin.Log.fncGrabarLogERR("Error en cLiquidacion.GetLiqDetxTipo" & ex.Message)
        End Try

    End Function

    Public Function TotalLiq() As Double
        TotalLiq = 0

        Try
            Me.RecalcularTotales()

            TotalLiq = TotalLiq + Me.Importe_Cash
            TotalLiq = TotalLiq + Me.Importe_Cheques
            TotalLiq = TotalLiq + Me.Importe_NCredito
            TotalLiq = TotalLiq + Me.Importe_Retenciones
            TotalLiq = TotalLiq + Me.Importe_Transferencias

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cLiquidacion.TotalLiq")
            gAdmin.Log.fncGrabarLogERR("Error en cLiquidacion.TotalLiq" & ex.Message)
        End Try

    End Function

    Public Sub RecalcularTotales()

        Dim lLiqDet As cLiquidacion_Det
        Try
            If Not IsNothing(Me.Liquidacion_Det) Then
                For Each lLiqDet In Me.Liquidacion_Det
                    Select Case lLiqDet.Tipo_Valor
                        Case cLiquidacion_Det.enuTipoValor.Efectivo
                            Me.Importe_Cash = lLiqDet.Importe
                        Case cLiquidacion_Det.enuTipoValor.Cheque
                            Me.Importe_Cheques = lLiqDet.Importe
                        Case cLiquidacion_Det.enuTipoValor.NCredito
                            Me.Importe_NCredito = lLiqDet.Importe
                        Case cLiquidacion_Det.enuTipoValor.Retencion
                            Me.Importe_Retenciones = lLiqDet.Importe
                        Case cLiquidacion_Det.enuTipoValor.Transferencia
                            Me.Importe_Transferencias = lLiqDet.Importe
                    End Select
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cLiquidacion.RecalcularTotales")
            gAdmin.Log.fncGrabarLogERR("Error en cLiquidacion.RecalcularTotales" & ex.Message)
        End Try

    End Sub

    Public Sub Conciliar(ByVal lRecibos As ArrayList)
        Dim lRec As cDeudor = Nothing
        Dim lCheque As cCheque = Nothing
        Dim lItem As Object = Nothing
        Dim Sql As String = ""
        Dim lAjuste As Double = 0
        Dim lTotalRecibos As Double = 0
        Try

            Dim Cmd As New MySqlCommand
            Dim lCnn As MySqlConnection
            lCnn = gAdmin.DbCnn.GetInstanceCon
            Cmd.Connection = lCnn
            Cmd.CommandType = CommandType.Text
            If lCnn.State = ConnectionState.Closed Then
                lCnn.Open()
            End If

            For Each lItem In lRecibos
                If (TypeOf lItem Is cDeudor) = True Then 'Valido si es un cDeudores 
                    lRec = lItem
                    lTotalRecibos = lTotalRecibos + lRec.TotalComp
                    Sql = "Call vz_liquidaciones_conciliacion_ins(#IdLiq#, #IdDeudor#,  null, #Importe#, '#Aplicacion#', '#Fecha#', '#Hora#', #idusr#)"
                    Sql = Sql.Replace("#IdLiq#", Me.Id_Liquidacion)
                    Sql = Sql.Replace("#IdDeudor#", lRec.Id_Deudores)
                    Sql = Sql.Replace("#Importe#", lRec.TotalComp.ToString().Replace(",", "."))
                    Sql = Sql.Replace("#Aplicacion#", lRec.Aplicacion)
                    Sql = Sql.Replace("#Fecha#", cFunciones.gFncConvertDateToString(lRec.FecOp, "YYYY/MM/DD"))
                    Sql = Sql.Replace("#Hora#", lRec.HoraOP.ToString)
                    Sql = Sql.Replace("#idusr#", gAdmin.User.Id)
                ElseIf (TypeOf lItem Is cCheque) = True Then  'Si es un cheque rechazado
                    lCheque = lItem
                    lTotalRecibos = lTotalRecibos + lCheque.Importe
                    Sql = "Call vz_liquidaciones_conciliacion_ins(#IdLiq#, null, #IdCheque#, #Importe#, '#Aplicacion#', '#Fecha#', '#Hora#', #idusr#)"
                    Sql = Sql.Replace("#IdLiq#", Me.Id_Liquidacion)
                    Sql = Sql.Replace("#IdCheque#", lCheque.Id_Cheque)
                    Sql = Sql.Replace("#Importe#", lCheque.Importe.ToString().Replace(",", "."))
                    Sql = Sql.Replace("#Aplicacion#", "P")
                    Sql = Sql.Replace("#Fecha#", cFunciones.gFncConvertDateToString(lCheque.Fecha_Pago, "YYYY/MM/DD"))
                    Sql = Sql.Replace("#Hora#", "12:00:00")
                    Sql = Sql.Replace("#idusr#", gAdmin.User.Id)
                End If

                Cmd.CommandText = Sql
                Cmd.ExecuteNonQuery()
            Next

            lAjuste = Math.Round(Me.TotalLiq - lTotalRecibos, 2) 'CALCULO EL AJUSTE

            If Not lAjuste = 0 Then '--> INSERTO EL AJUSTE.
                Sql = "Call vz_liquidaciones_conciliacion_ins(#IdLiq#, null, null,  #Importe#, null,  '#Fecha#', '#Hora#', #idusr#)"
                Sql = Sql.Replace("#IdLiq#", Me.Id_Liquidacion)
                'Sql = Sql.Replace("#IdDeudor#", lRec.Id_Deudores)
                Sql = Sql.Replace("#Importe#", lAjuste.ToString().Replace(",", "."))
                'Sql = Sql.Replace("#Aplicacion#", lRec.Aplicacion)
                Sql = Sql.Replace("#Fecha#", cFunciones.gFncConvertDateToString(Date.Today, "YYYY/MM/DD"))
                Sql = Sql.Replace("#Hora#", Now.TimeOfDay.ToString)
                Sql = Sql.Replace("#idusr#", gAdmin.User.Id)
                Cmd.CommandText = Sql
                Cmd.ExecuteNonQuery()
            End If

            lCnn.Close()
            Cmd.Dispose()

            Me.CambiarEstado(cEstado.GetEstadoxIdTipoEstado(gAdmin, 2, cEstado.enuTipoEstado.Liquidacion))   'CAMBIO A ESTADO CONCILIADA.
            Me.Conciliada = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cLiquidacion.Conciliar")
            gAdmin.Log.fncGrabarLogERR("Error en cLiquidacion.Conciliar" & ex.Message)
        End Try

    End Sub

    Public Sub Anular_Conciliacion()
        Dim lRec As cDeudor = Nothing
        Dim Sql As String = ""
        Try

            Dim Cmd As New MySqlCommand
            Dim lCnn As MySqlConnection
            lCnn = gAdmin.DbCnn.GetInstanceCon
            Cmd.Connection = lCnn
            Cmd.CommandType = CommandType.Text
            If lCnn.State = ConnectionState.Closed Then
                lCnn.Open()
            End If

            If Not (Me.Estado.Id_Estado = 2) Then
                MsgBox("Not se puede anular la conciliacion ya que no se encuentra conciliada.", MsgBoxStyle.Critical, "Error de validacion")
                Exit Sub
            End If

            Sql = "Call vz_liquidaciones_conciliacion_Anular(#IdLiq#, #idusr#)"
            Sql = Sql.Replace("#IdLiq#", Me.Id_Liquidacion)
            Sql = Sql.Replace("#idusr#", gAdmin.User.Id)
            Cmd.CommandText = Sql
            Cmd.ExecuteNonQuery()

            lCnn.Close()
            Cmd.Dispose()

            Me.Estado = cEstado.GetEstadoxIdTipoEstado(gAdmin, 1, cEstado.enuTipoEstado.Liquidacion) 'CAMBIO A ESTADO A COMPLETA.
            Me.ActualizarEstado() 'Valido el estado
            Me.CambiarEstado(Me.Estado) ' Guardo el estado.
            Me.Conciliada = False


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cLiquidacion.Anular_Conciliacion")
            gAdmin.Log.fncGrabarLogERR("Error en cLiquidacion.Anular_Conciliacion" & ex.Message)

        End Try

    End Sub

    Public Function ToXML() As String
        ToXML = ""
        Try
            Using sw As New StringWriter()
                Dim serialitzador As New XmlSerializer(GetType(cLiquidacion), New Type() {GetType(cLiquidacion_Det), GetType(cTransferencia), GetType(cCheque), GetType(cEstado), GetType(cBanco), GetType(cAdmin), GetType(cUser)})
                serialitzador.Serialize(sw, Me)
                ToXML = sw.ToString()
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cLiquidacion.ToXML")
            gAdmin.Log.fncGrabarLogERR("Error en cLiquidacion.ToXML" & ex.Message)
        End Try

    End Function

#End Region

#Region "Shared Functions"

    Public Shared Function GetLiquidacionesAll(ByRef pAdmin As VzAdmin.cAdmin) As ArrayList
        Dim lDt As DataTable
        Dim lArray As ArrayList = Nothing
        Dim lDr As DataRow
        Dim lLiq As cLiquidacion

        Try
            lDt = Dat_GetLiquidacionAll(pAdmin)

            If lDt.Rows.Count > 0 Then

                lArray = New ArrayList

                For Each lDr In lDt.Rows
                    lLiq = New cLiquidacion(pAdmin)
                    lLiq.subCargarDatos(lDr)
                    'lLiq.Id_Liquidacion = lDr("id_liquidacion")
                    'lLiq.Fecha = lDr("fecha")
                    'lLiq.Importe_Cash = lDr("importe_cash")
                    'lLiq.Importe_NCredito = lDr("importe_ncredito")
                    'lLiq.Importe_Transferencias = lDr("importe_transferencias")
                    'lLiq.Importe_Retenciones = lDr("importe_retenciones")
                    'lLiq.Observaciones = cFunciones.gFncgetDbValue(lDr("observaciones"), cFunciones.TipoDato.TEXTO)
                    'lLiq.Estado = cEstado.GetEstadoxIdTipoEstado(pAdmin, lDr("id_estado"), cEstado.enuTipoEstado.Liquidacion)
                    'lLiq.Vendedor = VzComercial.cVendedor.GetVendedorexId(pAdmin, lDr("id_vendedor"))
                    'lLiq.EsNuevo = False
                    'lLiq.Liquidacion_Det = cLiquidacion_Det.LiqDet_BusqxIdLiquidacion(pAdmin, lLiq.Id_Liquidacion)
                    lArray.Add(lLiq)
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cLiquidacion.GetLiquidacionesAll")
            pAdmin.Log.fncGrabarLogERR("Error en cLiquidacion.GetLiquidacionesAll:" & ex.Message)
            Return Nothing
        End Try

        Return lArray

    End Function

    Public Shared Function GetLiquidacionesxFecDH(ByRef pAdmin As VzAdmin.cAdmin, ByVal pFecD As Date, ByVal pFecH As Date) As ArrayList
        Dim lDt As DataTable
        Dim lArray As New ArrayList
        Dim lDr As DataRow
        Dim lLiq As cLiquidacion

        Try
            lDt = Dat_GetLiquidacionxFecDH(pAdmin, pFecD, pFecH)

            If lDt.Rows.Count > 0 Then

                For Each lDr In lDt.Rows
                    lLiq = New cLiquidacion(pAdmin)
                    lLiq.subCargarDatos(lDr)
                    lArray.Add(lLiq)
                Next

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cLiquidacion.GetLiquidacionesxFecDH")
            pAdmin.Log.fncGrabarLogERR("Error en cLiquidacion.GetLiquidacionesxFecDH:" & ex.Message)
        End Try

        Return lArray

    End Function

    Public Shared Function GetLiquidacionesxConciliar(ByRef pAdmin As VzAdmin.cAdmin) As ArrayList
        Dim lDt As DataTable
        Dim lArray As New ArrayList
        Dim lDr As DataRow
        Dim lLiq As cLiquidacion

        Try
            lDt = Dat_GetLiquidacionxConciliar(pAdmin)

            If lDt.Rows.Count > 0 Then

                For Each lDr In lDt.Rows
                    lLiq = New cLiquidacion(pAdmin)
                    lLiq.subCargarDatos(lDr)
                    lArray.Add(lLiq)
                Next

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cLiquidacion.GetLiquidacionesxConciliar")
            pAdmin.Log.fncGrabarLogERR("Error en cLiquidacion.GetLiquidacionesxConciliar:" & ex.Message)
        End Try

        Return lArray

    End Function

    Public Shared Function GetLiquidacionesxAnularConciliacion(ByRef pAdmin As VzAdmin.cAdmin) As ArrayList
        Dim lDt As DataTable
        Dim lArray As New ArrayList
        Dim lDr As DataRow
        Dim lLiq As cLiquidacion

        Try
            lDt = Dat_GetLiquidacionxAnularConciliacion(pAdmin)

            If lDt.Rows.Count > 0 Then

                For Each lDr In lDt.Rows
                    lLiq = New cLiquidacion(pAdmin)
                    lLiq.subCargarDatos(lDr)
                    lArray.Add(lLiq)
                Next

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cLiquidacion.GetLiquidacionesxAnularConciliacion")
            pAdmin.Log.fncGrabarLogERR("Error en cLiquidacion.GetLiquidacionesxAnularConciliacion:" & ex.Message)
        End Try

        Return lArray

    End Function

    Public Shared Function GetLiquidacionesxId(ByRef pAdmin As VzAdmin.cAdmin, ByVal pId As Integer) As cLiquidacion
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lLiq As cLiquidacion = Nothing

        Try
            lDt = Dat_GetLiquidacionxID(pAdmin, pId)

            If lDt.Rows.Count > 0 Then

                For Each lDr In lDt.Rows
                    lLiq = New cLiquidacion(pAdmin)
                    lLiq.subCargarDatos(lDr)
                    'lLiq.Id_Liquidacion = lDr("id_liquidacion")
                    'lLiq.Fecha = lDr("fecha")
                    'lLiq.Importe_Cash = lDr("importe_cash")
                    'lLiq.Importe_NCredito = lDr("importe_ncredito")
                    'lLiq.Importe_Transferencias = lDr("importe_transferencias")
                    'lLiq.Importe_Retenciones = lDr("importe_retenciones")
                    'lLiq.Observaciones = lDr("observaciones")
                    'lLiq.Estado = cEstado.GetEstadoxIdTipoEstado(pAdmin, lDr("id_estado"), cEstado.enuTipoEstado.Liquidacion)
                    'lLiq.Vendedor = VzComercial.cVendedor.GetVendedorexId(pAdmin, lDr("id_vendedor"))
                    'lLiq.Liquidacion_Det = cLiquidacion_Det.LiqDet_BusqxIdLiquidacion(pAdmin, lLiq.Id_Liquidacion)
                    lLiq.EsNuevo = False
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cLiquidacion.GetLiquidacionesAll")
            pAdmin.Log.fncGrabarLogERR("Error en cLiquidacion.GetLiquidacionesAll:" & ex.Message)
        End Try

        Return lLiq

    End Function

#End Region

#Region "Base de Datos"

    Private Shared Function Dat_GetLiquidacionxID(ByRef pAdmin As VzAdmin.cAdmin, ByVal pIdLiq As String) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "Select * from vz_liquidaciones where Id_liquidacion=#Id#"
            Sql = Sql.Replace("#Id#", pIdLiq)

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cLiquidacion.Dat_GetLiquidacionxID")
            pAdmin.Log.fncGrabarLogERR("Error en cLiquidacion.Dat_GetLiquidacionxID:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Shared Function Dat_GetLiquidacionAll(ByRef pAdmin As VzAdmin.cAdmin) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "Select * from vz_liquidaciones"

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cLiquidacion.Dat_GetVendedorAll")
            pAdmin.Log.fncGrabarLogERR("Error en cLiquidacion.Dat_GetVendedorAll:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Shared Function Dat_GetLiquidacionxFecDH(ByRef pAdmin As VzAdmin.cAdmin, ByVal pFecD As Date, ByVal pFecH As Date) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon

            Sql = "Select * from vz_liquidaciones where fecha >= '#fecd#' and fecha <= '#fech#'"

            Sql = Sql.Replace("#fecd#", VzAdmin.cFunciones.gFncConvertDateToString(pFecD, "YYYY/MM/DD"))
            Sql = Sql.Replace("#fech#", VzAdmin.cFunciones.gFncConvertDateToString(pFecH, "YYYY/MM/DD"))

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cLiquidacion.Dat_GetLiquidacionxID")
            pAdmin.Log.fncGrabarLogERR("Error en cLiquidacion.Dat_GetLiquidacionxID:  " & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Shared Function Dat_GetLiquidacionxConciliar(ByRef pAdmin As VzAdmin.cAdmin) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon

            ' Sql = "Select * from vz_liquidaciones where fecha = CurDate() and id_estado=1"
            Sql = "Select * from vz_liquidaciones where id_estado=1"

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cLiquidacion.Dat_GetLiquidacionxConciliar")
            pAdmin.Log.fncGrabarLogERR("Error en cLiquidacion.Dat_GetLiquidacionxConciliar:  " & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Shared Function Dat_GetLiquidacionxAnularConciliacion(ByRef pAdmin As VzAdmin.cAdmin) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon

            Sql = "Select * from vz_liquidaciones where fecha = CurDate() and id_estado=2"

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cLiquidacion.Dat_GetLiquidacionxAnularConciliacion")
            pAdmin.Log.fncGrabarLogERR("Error en cLiquidacion.Dat_GetLiquidacionxAnularConciliacion:  " & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Function Dat_RptRendicionDiariaValores(ByRef pAdmin As VzAdmin.cAdmin, ByVal pFechaD As Date, ByVal pFechaH As Date, ByVal pIdEstado As Integer) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "call vz_spTesoLiqRptRendicionDiariaValores ( '#FechaD#', '#FechaH#', #IdEstado#)"
            Sql = Sql.Replace("#FechaD#", cFunciones.gFncConvertDateToString(pFechaD, "YYYY/MM/DD"))
            Sql = Sql.Replace("#FechaH#", cFunciones.gFncConvertDateToString(pFechaH, "YYYY/MM/DD"))
            Sql = Sql.Replace("#IdEstado#", pIdEstado)

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cLiquidacion.Dat_RptRendicionDiariaValores")
            pAdmin.Log.fncGrabarLogERR("Error en cLiquidacion.Dat_RptRendicionDiariaValores:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Function Dat_RptLiqFDFH(ByRef pAdmin As VzAdmin.cAdmin, ByVal pFechaLiqD As Date, ByVal pFechaLiqH As Date) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "call vz_spTesoLiqRptLiqFDFH ( '#FechaLiqD#',  '#FechaLiqH#')"
            Sql = Sql.Replace("#FechaLiqD#", cFunciones.gFncConvertDateToString(pFechaLiqD, "YYYY/MM/DD"))
            Sql = Sql.Replace("#FechaLiqH#", cFunciones.gFncConvertDateToString(pFechaLiqH, "YYYY/MM/DD"))

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cLiquidacion.Dat_RptLiqFDFH")
            pAdmin.Log.fncGrabarLogERR("Error en cLiquidacion.Dat_RptLiqFDFH:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Function Dat_RptLiqFDFHVen(ByRef pAdmin As VzAdmin.cAdmin, ByVal pFechaLiqD As Date, ByVal pFechaLiqH As Date, ByVal pId_Vendedor As Integer, ByVal pId_Estado As Integer) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "call vz_spTesoLiqRptLiqFDFHVen( '#FechaLiqD#',  '#FechaLiqH#',#pIdVendedor#,#pIdEstado# )"
            Sql = Sql.Replace("#FechaLiqD#", cFunciones.gFncConvertDateToString(pFechaLiqD, "YYYY/MM/DD"))
            Sql = Sql.Replace("#FechaLiqH#", cFunciones.gFncConvertDateToString(pFechaLiqH, "YYYY/MM/DD"))
            Sql = Sql.Replace("#pIdVendedor#", pId_Vendedor.ToString)
            Sql = Sql.Replace("#pIdEstado#", pId_Estado.ToString)

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cLiquidacion.Dat_RptLiqFDFHVen")
            pAdmin.Log.fncGrabarLogERR("Error en cLiquidacion.Dat_RptLiqFDFHVen:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Function Dat_GetCantLiquidacionesdelDiaxEstado(ByRef pAdmin As VzAdmin.cAdmin, ByVal pId As Integer) As Integer

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "Select count(*) Total from vz_liquidaciones where fecha = CURDATE() and id_estado= #IdEstado# ;"
            Sql = Sql.Replace("#IdEstado#", pId)

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

            Return Integer.Parse(lDt.Rows(0)(0))

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cLiquidacion.Dat_GetCantLiquidaciones")
            pAdmin.Log.fncGrabarLogERR("Error en cLiquidacion.Dat_GetCantLiquidaciones:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Function Dat_GetTotalLiquidacionesdelDiaxEstado(ByRef pAdmin As VzAdmin.cAdmin, ByVal pId As Integer) As Double

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "Select round(sum(importe_cash + importe_cheques + importe_retenciones + importe_transferencias + importe_ncredito),2) Total from vz_liquidaciones where fecha = CURDATE() and id_estado= #IdEstado# ;"
            Sql = Sql.Replace("#IdEstado#", pId)

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

            Return Double.Parse(lDt.Rows(0)(0))

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cLiquidacion.Dat_GetCantChequesEnCartera")
            pAdmin.Log.fncGrabarLogERR("Error en cLiquidacion.Dat_GetCantChequesEnCartera:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Function Dat_GetTotalLiquidacionesdelDiaxFecha(ByRef pAdmin As VzAdmin.cAdmin, ByVal pFecha As Date) As DataTable

        Dim Cmd As New MySqlCommand
        Dim lSql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            lSql = "SET @TotalLiq = (Select sum(importe_cash + importe_cheques + importe_retenciones + importe_transferencias + importe_ncredito) Total from vz_liquidaciones where fecha = '#Fecha#' and id_estado=2);"
            lSql = lSql & " Select 'Efectivo', ROUND(SUM(importe_cash),2) Total, ROUND((SUM(importe_cash) * 100/ @TotalLiq),2) Porc from vz_liquidaciones where fecha = '#Fecha#' and id_estado=2"
            lSql = lSql & " union"
            lSql = lSql & " Select 'Cheques', ROUND(SUM(importe_cheques),2) Total, ROUND((SUM(importe_cheques) * 100/ @TotalLiq),2) Porc from vz_liquidaciones where fecha = '#Fecha#' and id_estado=2"
            lSql = lSql & " union"
            lSql = lSql & " Select 'Transferencias', ROUND(SUM(importe_transferencias),2) Total, ROUND((SUM(importe_transferencias)* 100/ @TotalLiq),2) Porc from vz_liquidaciones where fecha = '#Fecha#' and id_estado=2"
            lSql = lSql & " union"
            lSql = lSql & " Select 'Retenciones', ROUND(SUM(importe_retenciones),2) Total, ROUND((SUM(importe_retenciones) * 100/ @TotalLiq),2) Porc from vz_liquidaciones where fecha = '#Fecha#' and id_estado=2"
            lSql = lSql & " union"
            lSql = lSql & " Select 'NCredito', ROUND(SUM(importe_ncredito),2) Total, ROUND((SUM(importe_ncredito) * 100/ @TotalLiq),2) Porc from vz_liquidaciones where fecha = '#Fecha#' and id_estado=2;"


            lSql = lSql.Replace("#Fecha#", cFunciones.gFncConvertDateToString(pFecha, "YYYY/MM/DD"))

            With Cmd
                .Connection = lCnn
                .CommandType = CommandType.Text
                .CommandText = lSql

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cLiquidacion.Dat_GetTotalLiquidacionesdelDiaxFecha")
            pAdmin.Log.fncGrabarLogERR("Error en cLiquidacion.Dat_GetTotalLiquidacionesdelDiaxFecha:" & ex.Message)
            Return Nothing
        End Try
    End Function


#End Region

End Class
