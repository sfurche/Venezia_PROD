
Public Class cLog

    Public Fecha As DateTime
    Public Mensaje As String
    Public Categoria As String
    Public Usuario As String


    Public Sub Dispose()
        Me.Dispose()
    End Sub

    Public Sub fncGrabarLogERR(ByVal pMensaje As String)
        NegLog_Ins(pMensaje, "ERROR")
    End Sub

    Public Sub fncGrabarLogSignIn(ByVal pMensaje As String)
        NegLog_Ins(pMensaje, "LOGIN")
    End Sub

    Public Sub fncGrabarLogActividad(ByVal pMensaje As String)
        NegLog_Ins(pMensaje, "ACTIVIDAD")
    End Sub

    Public Sub fncGrabarLogAuditoria(ByVal pEvento As String, ByVal pTipoObj As String, ByVal IdObj As String, ByVal pUsuario As Integer, ByVal pNewValue As String, ByVal pOldValue As String)
        'NegLog_Ins(pMensaje, "AUDITORIA")
    End Sub


    Public Shared Function NegLog_Ins(ByVal pMensaje As String, ByVal pCategoria As String) As Boolean
        NegLog_Ins = False
        'Dim Rta As Boolean
        'Rta = DatLog_Ins(pMensaje, pCategoria)
        'Return Rta
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

End Class

