
Imports MySql.Data.MySqlClient

Public Class cLog

    Public Fecha As DateTime
    Public Mensaje As String
    Public Categoria As String
    Public Usuario As String
    Private gAdmin As cAdmin

    Public Sub New()

    End Sub

    Public Sub New(ByRef pAdmin As cAdmin)
        gAdmin = pAdmin
    End Sub

    Public Sub Dispose()
        Me.Dispose()
    End Sub

    Public Sub fncGrabarLogERR(ByVal pMensaje As String)
        NegLog_Ins_EVT(pMensaje, "ERROR")
    End Sub

    Public Sub fncGrabarLogSignIn(ByVal pMensaje As String)
        NegLog_Ins_EVT(pMensaje, "LOGIN")
    End Sub

    Public Sub fncGrabarLogActividad(ByVal pMensaje As String)
        NegLog_Ins_EVT(pMensaje, "ACTIVIDAD")
    End Sub

    Public Sub fncGrabarLogAuditoria(ByVal pEvento As String, ByVal pTipoObj As String, ByVal IdObj As String, ByVal pUsuario As Integer, ByVal pInformacion As String, ByVal pNewValue As String, ByVal pOldValue As String)
        Try
            Dat_Log_Ins(pEvento, pTipoObj, IdObj, pUsuario, pInformacion, pOldValue, pNewValue)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cLog.fncGrabarLogAuditoria")
            fncGrabarLogERR("Error en cLog.fncGrabarLogAuditoria:" & ex.Message)
        End Try
    End Sub


    Public Shared Function NegLog_Ins_EVT(ByVal pMensaje As String, ByVal pCategoria As String) As Boolean
        NegLog_Ins_EVT = False

        Dim EventLogPpal As New System.Diagnostics.EventLog

        If Not System.Diagnostics.EventLog.SourceExists("Venezia") Then
            System.Diagnostics.EventLog.CreateEventSource("Venezia", "Venezia_Log")
        End If

        EventLogPpal.Source = "Venezia"
        EventLogPpal.Log = "Venezia_Log"

        EventLogPpal.WriteEntry("Tipo: " & pCategoria.Trim & vbCrLf & pMensaje)

        EventLogPpal.Dispose()

    End Function

    Public Shared Function NegLog_BusqxFDFH(ByVal pFDesde As Date, ByVal pFHasta As Date) As ArrayList
        NegLog_BusqxFDFH = Nothing
        'Dim lDt As DataTable

        'lDt = DatLog_BuscxFDFH(pFDesde, pFHasta)
        'Return (FncCargarArrayLog(lDt))

    End Function

    Private Shared Function FncCargarArrayLog(ByVal pDt As DataTable) As ArrayList

        Dim lLOG As cLog
        Dim lArrayLog As New ArrayList
        Dim lDr As DataRow

        For Each lDr In pDt.Rows
            lLOG = New cLog
            With lLOG
                .Fecha = lDr("Fec_Log")
                .Categoria = lDr("Categoria")
                .Mensaje = lDr("Mensaje")
                .Usuario = lDr("Usu_Modif")
            End With
            lArrayLog.Add(lLOG)
        Next

        Return lArrayLog
    End Function


#Region "Base de Datos"

    Private Function Dat_Log_Ins(ByVal pEvento As String, ByVal pTipoObj As String, ByVal pIdObj As String, ByVal pUsuario As Integer, ByVal pInformacion As String, ByVal pNewValue As String, ByVal pOldValue As String) As Boolean

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lCnn As MySqlConnection

        Try
            Dat_Log_Ins = False

            lCnn = gAdmin.DbCnn.GetInstanceCon
            Sql = "CALL vz_log_ins_audit(now(),'#pEvento#','#pTipoObj#', #pIdObj# ,#idusr#, '#pInformacion#', '#OldValue#', '#NewValue#') "

            Sql = Sql.Replace("#pEvento#", pEvento)
            Sql = Sql.Replace("#pTipoObj#", pTipoObj)
            Sql = Sql.Replace("#pIdObj#", pIdObj)
            Sql = Sql.Replace("#idusr#", pUsuario)
            Sql = Sql.Replace("#pInformacion#", pInformacion)
            Sql = Sql.Replace("#OldValue#", pOldValue)
            Sql = Sql.Replace("#NewValue#", pNewValue)

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

            Dat_Log_Ins = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cLog.Dat_Log_Ins")
            fncGrabarLogERR("Error en cLog.Dat_Log_Ins:" & ex.Message)
            Return False
        End Try
    End Function

#End Region

End Class

