Imports VzAdmin
Imports MySql.Data.MySqlClient

Public Class cEstado
    Private _Id_Estado As Integer
    Private _TipoEstado As enuTipoEstado
    Private _Estado As String

    Private gAdmin As VzAdmin.cAdmin

#Region "Propiedades"

    Public Property Id_Estado As Integer
        Get
            Return _Id_Estado
        End Get
        Set(value As Integer)
            _Id_Estado = value
        End Set
    End Property

    Public Property TipoEstado As enuTipoEstado
        Get
            Return _TipoEstado
        End Get
        Set(value As enuTipoEstado)
            _TipoEstado = value
        End Set
    End Property

    Public Property Estado As String
        Get
            Return _Estado
        End Get
        Set(value As String)
            _Estado = value
        End Set
    End Property

#End Region

#Region "EnuTipoEstado"

    Public Enum enuTipoEstado
        Cheque = 0
        Liquidacion = 1
        Liquidacion_det = 2
        Orden_De_Pago = 3
        EstadoError = 99
    End Enum

    Public Shared Function EnuTipoEstadoGetCod(ByVal pTipoValor As enuTipoEstado) As String
        Select Case pTipoValor
            Case enuTipoEstado.Cheque
                Return "vz_cheques"
            Case enuTipoEstado.Liquidacion
                Return "vz_liquidaciones"
            Case enuTipoEstado.Liquidacion_det
                Return "vz_liquidaciones_det"
            Case enuTipoEstado.Orden_De_Pago
                Return "vz_ordenes_de_pago"
            Case Else
                Return ""
        End Select
    End Function

    Public Shared Function EnuTipoEstadoGetEnu(ByVal pTipoValor As String) As enuTipoEstado
        Select Case pTipoValor
            Case "vz_cheques"
                Return enuTipoEstado.Cheque
            Case "vz_liquidaciones"
                Return enuTipoEstado.Liquidacion
            Case "vz_liquidaciones_det"
                Return enuTipoEstado.Liquidacion_det
            Case "vz_ordenes_de_pago"
                Return enuTipoEstado.Orden_De_Pago
            Case Else
                Return enuTipoEstado.EstadoError
        End Select
    End Function

#End Region


#Region "Funciones"

    Public Sub New()

    End Sub

    Public Sub New(ByRef pAdmin As VzAdmin.cAdmin)
        gAdmin = pAdmin
    End Sub

    Public Shared Function GetEstadoxIdTipoEstado(ByRef pAdmin As VzAdmin.cAdmin, ByVal pIdEstado As Integer, ByVal pTipoEstado As enuTipoEstado) As cEstado
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lEstado As cEstado = Nothing

        Try
            lDt = Dat_GetEstadoxIDTipo(pAdmin, pIdEstado, pTipoEstado)

            If lDt.Rows.Count > 0 Then

                For Each lDr In lDt.Rows
                    lEstado = New cEstado(pAdmin)
                    lEstado.Id_Estado = lDr("id_estado")
                    lEstado.Estado = lDr("estado")
                    lEstado.TipoEstado = EnuTipoEstadoGetEnu(lDr("tabla"))
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cEstado.GetEstadoxIdTipoEstado")
            pAdmin.Log.fncGrabarLogERR("Error en cEstado.GetEstadoxIdTipoEstado:" & ex.Message)
        End Try

        Return lEstado

    End Function

    Public Shared Function GetEstadoAllxTipoEstado(ByRef pAdmin As VzAdmin.cAdmin, ByVal pTipoEstado As enuTipoEstado) As ArrayList
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lEstado As cEstado = Nothing
        Dim lArray As ArrayList = Nothing

        Try
            lDt = Dat_GetEstadoAllxTipo(pAdmin, pTipoEstado)

            If lDt.Rows.Count > 0 Then
                lArray = New ArrayList
                For Each lDr In lDt.Rows
                    lEstado = New cEstado(pAdmin)
                    lEstado.Id_Estado = lDr("id_estado")
                    lEstado.Estado = lDr("estado")
                    lEstado.TipoEstado = EnuTipoEstadoGetEnu(lDr("tabla"))

                    lArray.Add(lEstado)
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cEstado.GetEstadoAllxTipoEstado")
            pAdmin.Log.fncGrabarLogERR("Error en cEstado.GetEstadoAllxTipoEstado:" & ex.Message)
        End Try

        Return lArray

    End Function

#End Region

#Region "Base de Datos"

    Private Shared Function Dat_GetEstadoxIDTipo(ByRef pAdmin As VzAdmin.cAdmin, ByVal pIdEstado As Integer, ByVal pTipoEstado As enuTipoEstado) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "Select * from vz_estados where id_estado=#Id# and tabla='#tipoEstado#'"
            Sql = Sql.Replace("#Id#", pIdEstado)
            Sql = Sql.Replace("#tipoEstado#", EnuTipoEstadoGetCod(pTipoEstado))

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cEstado.Dat_GetEstadoxIDTipo")
            pAdmin.Log.fncGrabarLogERR("Error en cEstado.Dat_GetEstadoxIDTipo:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Shared Function Dat_GetEstadoAllxTipo(ByRef pAdmin As VzAdmin.cAdmin, ByVal pTipoEstado As enuTipoEstado) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "Select * from vz_estados where tabla='#tipoEstado#'"
            Sql = Sql.Replace("#tipoEstado#", EnuTipoEstadoGetCod(pTipoEstado))

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cEstado.Dat_GetEstadoxIDTipo")
            pAdmin.Log.fncGrabarLogERR("Error en cEstado.Dat_GetEstadoxIDTipo:" & ex.Message)
            Return Nothing
        End Try
    End Function

#End Region


End Class
