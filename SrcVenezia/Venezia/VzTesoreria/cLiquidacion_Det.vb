Imports VzTesoreria
Imports MySql.Data.MySqlClient
Imports VzAdmin

Public Class cLiquidacion_Det

    Private _Id_Liq_Det As Integer
    Private _Id_Liquidacion As Integer
    Private _Tipo_Valor As enuTipoValor   'Determina el tipo de valor (Efectivo, Cheque, Retencion, Nota de Credito, Transferencia)'
    Private _Importe As Double
    Private _Cheques As ArrayList
    Private _Observaciones As String
    Private _Estado As cEstado
    Private _EsNuevo As Boolean = True
    Private _Completo As Boolean = False

#Region "Declaraciones"

    Private gAdmin As VzAdmin.cAdmin

#Region "EnuEstadoLiq"

    'Public Enum EnuEstadoLiq
    '    Activo = 1
    '    Baja = 2
    '    Null = 0
    'End Enum

    'Public Function EnuBinarioGetCod(ByVal pTipoValor As EnuEstadoLiq) As String
    '    Select Case pTipoValor
    '        Case EnuEstadoLiq.Activo
    '            Return "A"
    '        Case EnuEstadoLiq.Baja
    '            Return "B"
    '        Case Else
    '            Return ""
    '    End Select
    'End Function

    'Public Function EnuBinarioGetEnu(ByVal pTipoValor As String) As EnuEstadoLiq
    '    Select Case pTipoValor
    '        Case "A"
    '            Return EnuEstadoLiq.Activo
    '        Case "B"
    '            Return EnuEstadoLiq.Baja
    '        Case Else
    '            Return EnuEstadoLiq.Null
    '    End Select
    'End Function

#End Region

#Region "EnuTipoValor"

    Public Enum enuTipoValor
        Efectivo = 1
        Cheque = 2
        Retencion = 3
        NCredito = 4
        Transferencia = 5
        Null = 0
    End Enum

    Public Shared Function EnuTipoValorGetCod(ByVal pTipoValor As enuTipoValor) As String
        Select Case pTipoValor
            Case enuTipoValor.Efectivo
                Return "E"
            Case enuTipoValor.Cheque
                Return "C"
            Case enuTipoValor.NCredito
                Return "N"
            Case enuTipoValor.Transferencia
                Return "T"
            Case enuTipoValor.Retencion
                Return "R"
            Case Else
                Return ""
        End Select
    End Function

    Public Shared Function EnuTipoValorGetEnu(ByVal pTipoValor As String) As enuTipoValor
        Select Case pTipoValor
            Case "E"
                Return enuTipoValor.Efectivo
            Case "C"
                Return enuTipoValor.Cheque
            Case "N"
                Return enuTipoValor.NCredito
            Case "T"
                Return enuTipoValor.Transferencia
            Case "R"
                Return enuTipoValor.Retencion
            Case Else
                Return enuTipoValor.Null
        End Select
    End Function

#End Region

    Public Property Id_Liq_Det As Integer
        Get
            Return _Id_Liq_Det
        End Get
        Set(value As Integer)
            _Id_Liq_Det = value
        End Set
    End Property

    Public Property Tipo_Valor As enuTipoValor
        Get
            Return _Tipo_Valor
        End Get
        Set(value As enuTipoValor)
            _Tipo_Valor = value
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

    Public Property Observaciones As String
        Get
            Return _Observaciones
        End Get
        Set(value As String)
            _Observaciones = value
        End Set
    End Property

    Private Property Estado As cEstado
        Get
            Return _Estado
        End Get
        Set(value As cEstado)
            _Estado = value
        End Set
    End Property

    Public Property Id_Liquidacion As Integer
        Get
            Return _id_Liquidacion
        End Get
        Set(value As Integer)
            _id_Liquidacion = value
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

    Public Property Completo As Boolean
        Get
            Me.ValidarCompletitud()
            Return _Completo
        End Get
        Set(value As Boolean)
            _Completo = value
        End Set
    End Property

#End Region

#Region "Funciones"


    Public Sub New()

    End Sub

    Public Sub New(ByRef pAdmin As VzAdmin.cAdmin)
        gAdmin = pAdmin
        Me.Cheques = New ArrayList
        Me.EsNuevo = True
    End Sub

    Public Sub Dispose()
        Me.Dispose()
    End Sub

    Public Function Guardar() As Boolean

        Guardar = False
        Dim Cmd As New MySqlCommand
        Dim Sql As String = ""
        Dim lCnn As MySqlConnection
        Dim lDt As DataTable
        Dim lChk As cCheque = Nothing

        Try

            lCnn = gAdmin.DbCnn.GetInstanceCon

            'CALL vz_liquidaciones_det_ins('E', 1, 105.55, 'OBSERVAC', 9) ; 
            If Me.EsNuevo = True Then
                Sql = "Call vz_liquidaciones_det_ins('#TipoVal#', #IdLiq#, #Importe#,'#Observac#' , #idusr#)"
                Sql = Sql.Replace("#TipoVal#", EnuTipoValorGetCod(Me.Tipo_Valor))
                Sql = Sql.Replace("#IdLiq#", Me.Id_Liquidacion)
                Sql = Sql.Replace("#Importe#", Me.Importe)
                Sql = Sql.Replace("#Observac#", Me.Observaciones)
                Sql = Sql.Replace("#idusr#", gAdmin.User.Id)
                EsNuevo = False

                Cmd.Connection = lCnn
                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = Sql

                If lCnn.State = ConnectionState.Closed Then
                    lCnn.Open()
                End If

                Dim lDa As New MySqlDataAdapter(Cmd)
                lDt = New DataTable
                lDa.Fill(lDt)
                lCnn.Close()

                Me.EsNuevo = False
                Me.Id_Liq_Det = lDt(0)(0)

                'GUARDO LOS CHEQUES.
                If Me.Tipo_Valor = enuTipoValor.Cheque Then
                    For Each lChk In Me.Cheques
                        lChk.Id_Liquidacion = Me.Id_Liquidacion
                        lChk.Guardar()
                    Next
                End If

            Else 'ACA DEBERIA IR EL UPDATE

                Sql = "Call vz_liquidaciones_det_upd(#id_liq_det#, '#TipoVal#', #IdLiq#, #Importe#,'#Observac#', #id_estado# ,#idusr#)"
                Sql = Sql.Replace("#id_liq_det#", Me.Id_Liq_Det)
                Sql = Sql.Replace("#TipoVal#", EnuTipoValorGetCod(Me.Tipo_Valor))
                Sql = Sql.Replace("#IdLiq#", Me.Id_Liquidacion)
                Sql = Sql.Replace("#Importe#", Me.Importe)
                Sql = Sql.Replace("#Observac#", Me.Observaciones)
                Sql = Sql.Replace("#id_estado#", Me.Estado.Id_Estado)
                Sql = Sql.Replace("#idusr#", gAdmin.User.Id)
                EsNuevo = False

                Cmd.Connection = lCnn
                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = Sql

                If lCnn.State = ConnectionState.Closed Then
                    lCnn.Open()
                End If

                Cmd.ExecuteNonQuery()
                lCnn.Close()

                Me.EsNuevo = False

                'UPDATE DE LOS CHEQUES.
                If Me.Tipo_Valor = enuTipoValor.Cheque Then
                    If Not IsNothing(Me.Cheques) Then
                        For Each lChk In Me.Cheques
                            lChk.Id_Liquidacion = Me.Id_Liquidacion
                            lChk.Guardar()
                        Next
                    End If
                End If


                End If

            Guardar = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cLiquidacion_Det.Guardar")
            gAdmin.Log.fncGrabarLogERR("Error en cLiquidacion_Det.Guardar" & ex.Message)
        End Try
    End Function

    Public Sub AddCheque(ByRef pCheque As cCheque)
        Dim lChk As cCheque = Nothing
        Dim lTotal As Double = 0

        Try
            '------Rafirmo el tipo de valor 
            Me.Tipo_Valor = enuTipoValor.Cheque

            If IsNothing(Me.Cheques) Then
                Me.Cheques = New ArrayList
            End If

            Me.Cheques.Add(pCheque)
            Me.ValidarCompletitud()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cLiquidacion_Det.AddCheque")
            gAdmin.Log.fncGrabarLogERR("Error en cLiquidacion_Det.AddCheque" & ex.Message)
        End Try

    End Sub

    Public Sub EliminarCheque(ByVal pNroCheque As String, ByVal pIdBanco As Integer)
        Dim lChk As cCheque = Nothing
        Dim lTotal As Double = 0

        Try
            lChk = Me.GetCheque(pNroCheque, pIdBanco)

            If lChk.EsNuevo Then  ' Si el cheque no estaba guardado lo borro directamente.
                If Not IsNothing(lChk) Then
                    Me.Cheques.Remove(lChk) '--Elimino el cheque
                End If
            Else 'Si el cheque habia estado guardado lo anulo.

                If lChk.Anular() = True Then
                    Me.Cheques.Remove(lChk)
                End If
            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cLiquidacion_Det.EliminarCheque")
            gAdmin.Log.fncGrabarLogERR("Error en cLiquidacion_Det.EliminarCheque" & ex.Message)
        End Try

    End Sub

    Public Function GetCheque(ByVal pNroCheque As String, ByVal pIdBanco As Integer) As cCheque
        GetCheque = Nothing
        Dim lChk As cCheque
        Try

            GetCheque = Nothing

            For Each lChk In Me.Cheques
                If lChk.Numero = pNroCheque And lChk.Banco.Id_Banco = pIdBanco Then
                    GetCheque = lChk
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cLiquidacion_Det.GetCheque")
            gAdmin.Log.fncGrabarLogERR("Error en cLiquidacion_Det.GetCheque" & ex.Message)
        End Try

    End Function

    'Public Sub RecalcularTotal()
    '    Dim lChk As cCheque = Nothing
    '    Dim lTotal As Double = 0

    '    Try

    '        If Me.Tipo_Valor = enuTipoValor.Cheque Then
    '            For Each lChk In Me.Cheques
    '                lTotal = lTotal + lChk.Importe
    '            Next

    '            Me.Importe = lTotal
    '        End If

    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "cLiquidacion_Det.RecalcularTotal")
    '        gAdmin.Log.fncGrabarLogERR("Error en cLiquidacion_Det.RecalcularTotal" & ex.Message)
    '    End Try

    'End Sub

    Public Sub ValidarCompletitud()
        Dim lChk As cCheque = Nothing
        Dim lTotal As Double = 0

        Try
            If Me.Tipo_Valor = enuTipoValor.Cheque Then
                If Not IsNothing(Me.Cheques) Then
                    For Each lChk In Me.Cheques
                        lTotal = lTotal + lChk.Importe
                    Next
                End If
                If Math.Round(Me.Importe, 2) = Math.Round(lTotal, 2) Then
                    Me.Completo = True
                Else
                    Me.Completo = False
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cLiquidacion_Det.ValidarCompletitud")
            gAdmin.Log.fncGrabarLogERR("Error en cLiquidacion_Det.ValidarCompletitud" & ex.Message)
        End Try

    End Sub

    Public Function GetSumCheques() As Double
        Dim lChk As cCheque = Nothing
        GetSumCheques = 0
        Try
            If Me.Tipo_Valor = enuTipoValor.Cheque And Not IsNothing(Me.Cheques) Then
                For Each lChk In Me.Cheques
                    GetSumCheques = GetSumCheques + lChk.Importe
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cLiquidacion_Det.GetSumCheques")
            gAdmin.Log.fncGrabarLogERR("Error en cLiquidacion_Det.GetSumCheques" & ex.Message)
        End Try

    End Function

#End Region

#Region "Shared Functions"

    Public Shared Function LiqDet_BusqxId(ByRef pAdmin As cAdmin, ByVal pId_LiqDet As Integer) As cLiquidacion_Det

        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lLiqDet As cLiquidacion_Det = Nothing

        Try
            lDt = Dat_GetLiqDetxID(pAdmin, pId_LiqDet)

            If lDt.Rows.Count > 0 Then

                For Each lDr In lDt.Rows
                    lLiqDet = New cLiquidacion_Det(pAdmin)
                    lLiqDet.Id_Liq_Det = lDr("id_liq_det")
                    lLiqDet.Id_Liquidacion = lDr("id_liquidacion")
                    lLiqDet.Tipo_Valor = cLiquidacion_Det.EnuTipoValorGetEnu(lDr("tipo_valor"))
                    lLiqDet.Importe = lDr("importe")
                    If lLiqDet.Tipo_Valor = enuTipoValor.Cheque Then
                        lLiqDet.Cheques = cCheque.GetChequesxIdLiq(pAdmin, lDr("id_liquidacion"))
                    Else
                        lLiqDet.Cheques = Nothing
                    End If
                    lLiqDet.Observaciones = cFunciones.gFncgetDbValue(lDr("observaciones"), cFunciones.TipoDato.TEXTO)
                    lLiqDet.Estado = cEstado.GetEstadoxIdTipoEstado(pAdmin, lDr("id_estado"), cEstado.enuTipoEstado.Liquidacion_det)
                    lLiqDet.EsNuevo = False
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cLiquidacion_Det.LiqDet_BusqxId")
            pAdmin.Log.fncGrabarLogERR("Error en cLiquidacion_Det.LiqDet_BusqxId" & ex.Message)
            lLiqDet = Nothing
        End Try

        Return lLiqDet
    End Function

    Public Shared Function LiqDet_BusqxIdLiquidacion(ByRef pAdmin As cAdmin, ByVal pIdLiquidacion As Integer) As ArrayList
        Dim lArray As ArrayList = Nothing
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lLiqDet As cLiquidacion_Det = Nothing

        Try
            lDt = Dat_GetLiqDetxIdLiq(pAdmin, pIdLiquidacion)

            If lDt.Rows.Count > 0 Then
                lArray = New ArrayList

                For Each lDr In lDt.Rows
                    lLiqDet = New cLiquidacion_Det(pAdmin)
                    lLiqDet.Id_Liq_Det = lDr("id_liq_det")
                    lLiqDet.Id_Liquidacion = lDr("id_liquidacion")
                    lLiqDet.Tipo_Valor = cLiquidacion_Det.EnuTipoValorGetEnu(lDr("tipo_valor"))
                    lLiqDet.Importe = lDr("importe")
                    If lLiqDet.Tipo_Valor = enuTipoValor.Cheque Then
                        lLiqDet.Cheques = cCheque.GetChequesxIdLiq(pAdmin, lDr("id_liquidacion"))
                    Else
                        lLiqDet.Cheques = Nothing
                    End If
                    lLiqDet.Observaciones = cFunciones.gFncgetDbValue(lDr("observaciones"), cFunciones.TipoDato.TEXTO)
                    lLiqDet.Estado = cEstado.GetEstadoxIdTipoEstado(pAdmin, lDr("id_estado"), cEstado.enuTipoEstado.Liquidacion_det)
                    lLiqDet.EsNuevo = False

                    lArray.Add(lLiqDet)
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cLiquidacion_Det.LiqDet_BusqxIdLiquidacion")
            pAdmin.Log.fncGrabarLogERR("Error en cLiquidacion_Det.LiqDet_BusqxIdLiquidacion" & ex.Message)
            lArray = Nothing
        End Try

        Return lArray

    End Function

#End Region

#Region "Base de Datos"

    Private Shared Function Dat_GetLiqDetxID(ByRef pAdmin As VzAdmin.cAdmin, ByVal pId As Integer) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "select * from vz_liquidaciones_det where id_liq_det =#Id#"
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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cLiquidacion_Det.Dat_GetLiqDetxID")
            pAdmin.Log.fncGrabarLogERR("Error en cLiquidacion_Det.Dat_GetLiqDetxID:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Shared Function Dat_GetLiqDetxIdLiq(ByRef pAdmin As VzAdmin.cAdmin, ByVal pIdLiq As Integer) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "select * from vz_liquidaciones_det where id_liquidacion = #IdLiq#"
            Sql = Sql.Replace("#IdLiq#", pIdLiq)

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cLiquidacion_Det.Dat_GetLiqDetxIdLiq")
            pAdmin.Log.fncGrabarLogERR("Error en cLiquidacion_Det.Dat_GetLiqDetxIdLiq:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Shared Function Dat_GetLiqDetAll(ByRef pAdmin As VzAdmin.cAdmin) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "select * from vz_liquidaciones_det"

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cLiquidacion_Det.Dat_GetLiqDetAll")
            pAdmin.Log.fncGrabarLogERR("Error en cLiquidacion_Det.Dat_GetLiqDetAll:" & ex.Message)
            Return Nothing
        End Try
    End Function

#End Region

End Class
