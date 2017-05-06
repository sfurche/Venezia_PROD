Imports MySql.Data.MySqlClient
Imports VzAdmin

Public Class cConciliacionLiq

#Region "Propiedades"

    Private gAdmin As VzAdmin.cAdmin

    Private _Id_Liq_Con As Integer
    Private _Id_Liquidacion As Integer
    Private _Id_Deudores As Integer
    Private _Importe As Decimal
    Private _Aplicacion As String
    Private _Fecha As Date
    Private _Hora As TimeSpan
    Private _Estado As cEstado
    Private _IdUsr As Integer
    Private _Id_Cheque As Integer

    Public Property Id_Liq_Con As Integer
        Get
            Return _Id_Liq_Con
        End Get
        Set(value As Integer)
            _Id_Liq_Con = value
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

    Public Property Id_Deudores As Integer
        Get
            Return _Id_Deudores
        End Get
        Set(value As Integer)
            _Id_Deudores = value
        End Set
    End Property

    Public Property Importe As Decimal
        Get
            Return _Importe
        End Get
        Set(value As Decimal)
            _Importe = value
        End Set
    End Property

    Public Property Aplicacion As String
        Get
            Return _Aplicacion
        End Get
        Set(value As String)
            _Aplicacion = value
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

    Public Property Hora As TimeSpan
        Get
            Return _Hora
        End Get
        Set(value As TimeSpan)
            _Hora = value
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

    Public Property Id_Cheque As Integer
        Get
            Return _Id_Cheque
        End Get
        Set(value As Integer)
            _Id_Cheque = value
        End Set
    End Property

    Public Property IdUsr As Integer
        Get
            Return _IdUsr
        End Get
        Set(value As Integer)
            _IdUsr = value
        End Set
    End Property

#End Region

#Region "Funciones"

    Public Sub New(ByRef pAdmin As cAdmin)
        gAdmin = pAdmin
    End Sub

    Public Shared Function Load(ByRef pAdmin As cAdmin, ByVal lDr As DataRow) As cConciliacionLiq

        Dim lConciLiq As cConciliacionLiq = Nothing

        Try
            lConciLiq = New cConciliacionLiq(pAdmin)
            With lConciLiq
                .Id_Liq_Con = lDr("id_liq_con")
                .Id_Liquidacion = lDr("Id_Liquidacion")
                .Id_Deudores = cFunciones.gFncgetDbValue(lDr("Id_Deudores"), cFunciones.TipoDato.NUMERO)
                .Importe = lDr("importe")
                .Aplicacion = lDr("aplicacion")
                .Fecha = lDr("fecha")
                .Hora = lDr("hora")
                .Estado = cEstado.GetEstadoxIdTipoEstado(pAdmin, lDr("id_liq_con"), cEstado.enuTipoEstado.Liquidacion_Conciliacion)
                .IdUsr = lDr("id_liq_con")
                .Id_Cheque = cFunciones.gFncgetDbValue(lDr("id_cheque"), cFunciones.TipoDato.NUMERO)

            End With

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cConciliacionLiq.Load")
            pAdmin.Log.fncGrabarLogERR("Error en cConciliacionLiq.Load: " & ex.Message)
        End Try

        Return lConciLiq

    End Function

    Public Shared Function GetDeudoresxIdCheque(ByRef pAdmin As VzAdmin.cAdmin, ByVal pId_Cheque As Integer) As ArrayList
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lConcil As cConciliacionLiq = Nothing
        Dim lArray As New ArrayList

        Try
            lDt = Dat_GetConciliacionxIdCheque(pAdmin, pId_Cheque)

            If lDt.Rows.Count > 0 Then
                For Each lDr In lDt.Rows
                    lConcil = Load(pAdmin, lDr)
                    lArray.Add(lConcil)
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cConciliacionLiq.GetDeudoresxIdCheque")
            pAdmin.Log.fncGrabarLogERR("Error en cConciliacionLiq.GetDeudoresxIdCheque:" & ex.Message)
        End Try

        Return lArray

    End Function

    Public Overrides Function ToString() As String
        ToString = ""

        Try
            ToString = Me.GetType.ToString & " Id_Liq_Con = " & Me.Id_Liq_Con.ToString & vbCrLf
            ToString = Me.GetType.ToString & " Id_Liquidacion = " & Me.Id_Liquidacion.ToString & vbCrLf
            ToString = Me.GetType.ToString & " _Id_Deudores = " & Me._Id_Deudores.ToString & vbCrLf
            ToString = Me.GetType.ToString & " Importe = " & Me.Importe.ToString & vbCrLf
            ToString = Me.GetType.ToString & " Aplicacion = " & Me.Aplicacion.ToString & vbCrLf
            ToString = Me.GetType.ToString & " Fecha = " & Me.Fecha.ToString & vbCrLf
            ToString = Me.GetType.ToString & " Hora = " & Me.Hora.ToString & vbCrLf
            ToString = Me.GetType.ToString & " Estado = " & Me.Estado.ToString & vbCrLf
            ToString = Me.GetType.ToString & " IdUsr = " & Me.IdUsr.ToString & vbCrLf
            ToString = Me.GetType.ToString & " Id_Cheque = " & Me.Id_Cheque.ToString & vbCrLf

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cConciliacionLiq.ToString")
            gAdmin.Log.fncGrabarLogERR("Error en cConciliacionLiq.ToString" & ex.Message)
        End Try

    End Function

#End Region

#Region "Base de Datos"

    Private Shared Function Dat_GetConciliacionxIdCheque(ByRef pAdmin As VzAdmin.cAdmin, ByVal pIdCheque As Integer) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "select * from vz_liquidaciones_conciliacion  where id_cheque = #Id# and id_estado = 0 "
            Sql = Sql.Replace("#Id#", pIdCheque)

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cConciliacionLiq.Dat_GetConciliacionxIdCheque")
            pAdmin.Log.fncGrabarLogERR("Error en cConciliacionLiq.Dat_GetConciliacionxIdCheque:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Function Dat_GetTotalAjustesxFechaEstado(ByRef pAdmin As VzAdmin.cAdmin, ByVal pFecha As Date, ByVal pIdEstado As Integer) As Double

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "select ifnull(sum(abs(Importe)),0) Total from vz_liquidaciones_conciliacion"
            Sql = Sql & " where Id_Deudores is null"
            Sql = Sql & " AND fecha = '#IdEstado#'"
            Sql = Sql & " and id_estado = #IdEstado# "

            Sql = Sql.Replace("#IdEstado#", pIdEstado)
            Sql = Sql.Replace("#IdEstado#", cFunciones.gFncConvertDateToString(pFecha, "YYYY/MM/DD"))

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cConciliacionLiq.Dat_GetTotalAjustesxFechaEstado")
            pAdmin.Log.fncGrabarLogERR("Error en cConciliacionLiq.Dat_GetTotalAjustesxFechaEstado:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Function Dat_GetConsultaDeConciliacionLiquidacion(ByRef pAdmin As VzAdmin.cAdmin, ByVal pIdLiquidacion As Integer) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try

            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "SELECT d.Descripcion Tipo, d.CompNro, d.FecEmi, d.TotalComp Importe, c.Importe Imputacion, Aplicacion, u.nombre Usuario"
            Sql = Sql & " FROM vz_liquidaciones_conciliacion c, ven_deudores d, sis_usuarios u"
            Sql = Sql & " WHERE c.id_liquidacion = #IdLiquidacion# "
            Sql = Sql & " AND c.Id_Deudores=d.Id_Deudores"
            Sql = Sql & " AND c.idusr=u.idusr"
            Sql = Sql & " AND c.id_estado=0"
            Sql = Sql & " UNION"
            Sql = Sql & " SELECT 'Ajuste',  '' , c.fecha , 0, c.Importe Imputacion, ifnull(Aplicacion, 'T'), u.nombre Usuario"
            Sql = Sql & " FROM vz_liquidaciones_conciliacion c, sis_usuarios u"
            Sql = Sql & " WHERE c.id_liquidacion = #IdLiquidacion# "
            Sql = Sql & " AND c.Id_Deudores is null"
            Sql = Sql & " AND c.idusr=u.idusr"
            Sql = Sql & " AND c.id_estado=0 "

            Sql = Sql.Replace("#IdLiquidacion#", pIdLiquidacion)

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cConciliacionLiq.Dat_GetConsultaDeConciliacionLiquidacion")
            pAdmin.Log.fncGrabarLogERR("Error en cConciliacionLiq.Dat_GetConsultaDeConciliacionLiquidacion:" & ex.Message)
            Return Nothing
        End Try
    End Function

#End Region

End Class
