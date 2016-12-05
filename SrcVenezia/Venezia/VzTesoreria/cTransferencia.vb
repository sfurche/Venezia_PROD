Imports VzTesoreria
Imports MySql.Data.MySqlClient
Imports VzAdmin
Imports VzComercial

Public Class cTransferencia

#Region "Declaraciones"

    Private gAdmin As VzAdmin.cAdmin

    Private _Id_Transferencia As Integer
    Private _Id_Liquidacion As Integer
    Private _Fecha As String
    Private _NroCli As String
    Private _Importe As Double
    Private _Estado As cEstado
    Private _Observaciones As String
    Private _EsNuevo As Boolean = True

    Public Property Id_Transferencia As Integer
        Get
            Return _Id_Transferencia
        End Get
        Set(value As Integer)
            _Id_Transferencia = value
        End Set
    End Property

    Public Property Id_Liquidacion As Integer
        Get
            Return _Id_Liquidacion
        End Get
        Set(value As Integer)
            _Id_Liquidacion = value
        End Set
    End Property

    Public Property Fecha As String
        Get
            Return _Fecha
        End Get
        Set(value As String)
            _Fecha = value
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

    Public Property NroCli As String
        Get
            Return _NroCli
        End Get
        Set(value As String)
            _NroCli = value
        End Set
    End Property

#End Region

#Region "Funciones"

    Public Sub New()

    End Sub

    Public Sub New(ByRef pAdmin As VzAdmin.cAdmin)
        gAdmin = pAdmin
    End Sub

    Public Sub Dispose()
        Me.Dispose()
    End Sub

    Public Sub Save()
        Try
            If Me.EsNuevo = True Then
                Dat_Transferencias_Ins()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cTransferencia.Save")
            gAdmin.Log.fncGrabarLogERR("Error en cTransferencia.Save" & ex.Message)
        End Try
    End Sub

    Public Sub Load(ByVal pDt As DataRow)
        Try

            Me.Id_Transferencia = pDt("id_transferencia")
            Me.Id_Liquidacion = pDt("id_liquidacion")
            Me.Fecha = pDt("fecha")
            Me.Importe = pDt("importe")
            Me.Estado = cEstado.GetEstadoxIdTipoEstado(gAdmin, pDt("id_estado"), cEstado.enuTipoEstado.Transferencia)
            Me.Observaciones = pDt("observaciones")
            Me.NroCli = pDt("NroCli")
            Me.EsNuevo = False

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cTransferencia.Load")
            gAdmin.Log.fncGrabarLogERR("Error en cTransferencia.Load" & ex.Message)
        End Try
    End Sub

    Public Function Anular() As Boolean
        Anular = False
        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lCnn As MySqlConnection

        Try
            If Not Me.Estado.Id_Estado = 0 Then 'Registrada
                MsgBox("La transferencia no se puede anular por estar en estado '" & Me.Estado.Estado & "'", MsgBoxStyle.Exclamation)
                Anular = False
                Exit Function
            End If

            lCnn = Me.gAdmin.DbCnn.GetInstanceCon

            '99 ES ESTADO ANULADO
            Me.Estado = cEstado.GetEstadoxIdTipoEstado(gAdmin, 99, cEstado.enuTipoEstado.Transferencia)

            If Me.EsNuevo = False Then
                lCnn = gAdmin.DbCnn.GetInstanceCon


                Sql = "CALL vz_transferencias_cambest ('#id_transferencia#',#id_estado#, #idusr#)"
                Sql = Sql.Replace("#id_transferencia#", Me.Id_Transferencia)
                Sql = Sql.Replace("#id_estado#", Me.Estado.Id_Estado)
                Sql = Sql.Replace("#idusr#", gAdmin.User.Id)

                Cmd.Connection = lCnn
                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = Sql

                If lCnn.State = ConnectionState.Closed Then
                    lCnn.Open()
                End If

                Cmd.ExecuteNonQuery()
                lCnn.Close()

            End If

            Anular = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cTransferencia.Anular")
            gAdmin.Log.fncGrabarLogERR("Error en cTransferencia.Anular:" & ex.Message)
        End Try
    End Function

    Public Function Conciliar() As Boolean
        Conciliar = False
        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lCnn As MySqlConnection

        Try
            If Not Me.Estado.Id_Estado = 0 Then 'Registrada
                MsgBox("La transferencia no se puede conciliar por estar en estado '" & Me.Estado.Estado & "'", MsgBoxStyle.Exclamation)
                Conciliar = False
                Exit Function
            End If

            lCnn = Me.gAdmin.DbCnn.GetInstanceCon

            '1 ES ESTADO CONCILIADA
            Me.Estado = cEstado.GetEstadoxIdTipoEstado(gAdmin, 1, cEstado.enuTipoEstado.Transferencia)

            If Me.EsNuevo = False Then
                lCnn = gAdmin.DbCnn.GetInstanceCon

                Sql = "CALL vz_transferencias_cambest ('#id_transferencia#',#id_estado#, #idusr#)"
                Sql = Sql.Replace("#id_transferencia#", Me.Id_Transferencia)
                Sql = Sql.Replace("#id_estado#", Me.Estado.Id_Estado)
                Sql = Sql.Replace("#idusr#", gAdmin.User.Id)

                Cmd.Connection = lCnn
                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = Sql

                If lCnn.State = ConnectionState.Closed Then
                    lCnn.Open()
                End If

                Cmd.ExecuteNonQuery()
                lCnn.Close()

            End If

            Conciliar = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cTransferencia.Conciliar")
            gAdmin.Log.fncGrabarLogERR("Error en cTransferencia.Conciliar:" & ex.Message)
        End Try
    End Function

#End Region

#Region "Shared Functions"

    Public Shared Function GetTransferenciaxId(ByRef pAdmin As cAdmin, ByVal pId As Integer) As cTransferencia

        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lTransf As cTransferencia = Nothing

        Try
            lDt = Dat_GetTransferenciasxID(pAdmin, pId)

            If lDt.Rows.Count > 0 Then

                For Each lDr In lDt.Rows
                    lTransf = New cTransferencia(pAdmin)
                    lTransf.Load(lDr)
                Next

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cTransferencia.GetTransferenciaxId")
            pAdmin.Log.fncGrabarLogERR("Error en cTransferencia.GetTransferenciaxId" & ex.Message)
        End Try

        Return lTransf
    End Function

    Public Shared Function GetTransferenciasxIdLiq(ByRef pAdmin As cAdmin, ByVal pIdLiq As Integer) As ArrayList
        Dim lArray As ArrayList = Nothing
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lTransf As cTransferencia = Nothing

        Try
            lDt = Dat_GetTransferenciasxIDLiq(pAdmin, pIdLiq)

            If lDt.Rows.Count > 0 Then
                lArray = New ArrayList

                For Each lDr In lDt.Rows
                    lTransf = New cTransferencia(pAdmin)
                    lTransf.Load(lDr)
                    lArray.Add(lTransf)
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cTransferencia.GetTransferenciasxIdLiq")
            pAdmin.Log.fncGrabarLogERR("Error en cTransferencia.GetTransferenciasxIdLiq" & ex.Message)
            lArray = Nothing
        End Try

        Return lArray

    End Function

    Public Shared Function Transferencias_GetAll(ByRef pAdmin As cAdmin) As ArrayList
        Dim lArray As ArrayList = Nothing
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lTransf As cTransferencia = Nothing

        Try
            lDt = Dat_GetTransferenciasAll(pAdmin)

            If lDt.Rows.Count > 0 Then
                lArray = New ArrayList

                For Each lDr In lDt.Rows
                    lTransf = New cTransferencia(pAdmin)
                    lTransf.load(lDr)
                    lArray.Add(lTransf)
                Next

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cTransferencia.Transferencias_GetAll")
            pAdmin.Log.fncGrabarLogERR("Error en cTransferencia.Transferencias_GetAll" & ex.Message)
            lArray = Nothing
        End Try

        Return lArray

    End Function

#End Region

#Region "Base de Datos"

    Private Function Dat_Transferencias_Ins() As Boolean

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lCnn As MySqlConnection

        Try
            Dat_Transferencias_Ins = False

            lCnn = gAdmin.DbCnn.GetInstanceCon
            Sql = "CALL vz_transferencias_ins(#pLiq#,'#pFec#','#pNroCli#', #pImporte#, '#pObs#',#idusr#) "

            Sql = Sql.Replace("#pLiq#", Me.Id_Liquidacion)
            Sql = Sql.Replace("#pFec#", cFunciones.gFncConvertDateToString(Me.Fecha, "YYYY/MM/DD"))
            Sql = Sql.Replace("#pNroCli#", Me.NroCli)
            Sql = Sql.Replace("#pImporte#", Me.Importe.ToString().Replace(",", "."))
            Sql = Sql.Replace("#pObs#", Me.Observaciones)
            Sql = Sql.Replace("#idusr#", gAdmin.User.Id)

            With Cmd
                .Connection = lCnn
                .CommandType = CommandType.Text
                .CommandText = Sql

                If lCnn.State = ConnectionState.Closed Then
                    lCnn.Open()
                End If
                Cmd.ExecuteNonQuery()

                lCnn.Close()
            End With

            Dat_Transferencias_Ins = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cTransferencia.Dat_Transferencias_Ins")
            gAdmin.Log.fncGrabarLogERR("Error en cTransferencia.Dat_Transferencias_Ins:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Shared Function Dat_GetTransferenciasxID(ByRef pAdmin As VzAdmin.cAdmin, ByVal pId As Integer) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "select * from vz_transferencias where id_transferencia =#Id#"
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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cTransferencia.Dat_GetTransferenciasxID")
            pAdmin.Log.fncGrabarLogERR("Error en cTransferencia.Dat_GetTransferenciasxID:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Shared Function Dat_GetTransferenciasxIDLiq(ByRef pAdmin As VzAdmin.cAdmin, ByVal pIdLiq As Integer) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "select * from vz_transferencias where id_liquidacion =#Id# AND id_estado < 99"
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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cTransferencia.Dat_GetTransferenciasxIDLiq")
            pAdmin.Log.fncGrabarLogERR("Error en cTransferencia.Dat_GetTransferenciasxIDLiq:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Shared Function Dat_GetTransferenciasxFDFHxCli(ByRef pAdmin As VzAdmin.cAdmin, ByVal pFecD As Date, ByVal pFecH As Date, ByVal pNroCli As String) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "SELECT * FROM vz_transferencias WHERE fecha >= '%#pFecD#%'  AND fecha <= '%#pFecH#%' AND id_estado < 99 "
            Sql = Sql & "AND ('%#pNroCli#%'= '' OR NroCli='%#pNroCli#%' ) "
            Sql = Sql & "ORDER BY fecha asc"
            Sql = Sql.Replace("#pFecD#", pFecD)
            Sql = Sql.Replace("#pFecH#", pFecH)
            Sql = Sql.Replace("#pNroCli#", pNroCli.Trim)

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cTransferencia.Dat_GetTransferenciasxFDFHxCli")
            pAdmin.Log.fncGrabarLogERR("Error en cTransferencia.Dat_GetTransferenciasxFDFHxCli:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Shared Function Dat_GetTransferenciasAll(ByRef pAdmin As VzAdmin.cAdmin) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "select * from vz_transferencias order id_transferencia"

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cTransferencia.Dat_GetTransferenciasAll")
            pAdmin.Log.fncGrabarLogERR("Error en cTransferencia.Dat_GetTransferenciasAll:" & ex.Message)
            Return Nothing
        End Try
    End Function

#End Region

End Class
