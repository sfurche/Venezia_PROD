Imports VzComercial
Imports VzAdmin
Imports MySql.Data.MySqlClient

Public Class cDeudor_Mov

#Region "Propiedades"

    Private gAdmin As cAdmin

    Private _Id_Mov As Integer
    Private _Id_Deudores As Integer
    Private _Descripcion As String
    Private _Id_Fac As Integer
    Private _FecAplica As Date
    Private _ImpoComp As Decimal
    Private _MarcaAnulado As enuBinario
    Private _IdUsr As Integer
    Private _FecOp As Date
    Private _HoraOP As DateTime

    Public Property Id_Mov As Integer
        Get
            Return _Id_Mov
        End Get
        Set(value As Integer)
            _Id_Mov = value
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

    Public Property Descripcion As String
        Get
            Return _Descripcion
        End Get
        Set(value As String)
            _Descripcion = value
        End Set
    End Property

    Public Property Id_Fac As Integer
        Get
            Return _Id_Fac
        End Get
        Set(value As Integer)
            _Id_Fac = value
        End Set
    End Property

    Public Property FecAplica As Date
        Get
            Return _FecAplica
        End Get
        Set(value As Date)
            _FecAplica = value
        End Set
    End Property

    Public Property ImpoComp As Decimal
        Get
            Return _ImpoComp
        End Get
        Set(value As Decimal)
            _ImpoComp = value
        End Set
    End Property

    Public Property MarcaAnulado As enuBinario
        Get
            Return _MarcaAnulado
        End Get
        Set(value As enuBinario)
            _MarcaAnulado = value
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

    Public Property FecOp As Date
        Get
            Return _FecOp
        End Get
        Set(value As Date)
            _FecOp = value
        End Set
    End Property

    Public Property HoraOP As Date
        Get
            Return _HoraOP
        End Get
        Set(value As Date)
            _HoraOP = value
        End Set
    End Property

#End Region



#Region "EnuBinario"

    Public Enum enuBinario
        Si = 1
        No = 2
        Null = 0
    End Enum

    Public Shared Function EnuBinarioGetCod(ByVal pTipoValor As enuBinario) As String
        Select Case pTipoValor
            Case enuBinario.Si
                Return "S"
            Case enuBinario.No
                Return "N"
            Case Else
                Return ""
        End Select
    End Function

    Public Shared Function EnuBinarioGetEnu(ByVal pTipoValor As String) As enuBinario
        Select Case pTipoValor
            Case "S"
                Return enuBinario.Si
            Case "N"
                Return enuBinario.No
            Case Else
                Return enuBinario.Null
        End Select
    End Function

#End Region


#Region "Funciones"

    Public Sub New(ByRef pAdmin As cAdmin)
        gAdmin = pAdmin
    End Sub

    Public Shared Function Load_Deudores_Mov(ByRef pAdmin As cAdmin, ByVal lDr As DataRow) As cDeudor_Mov

        Dim lMovDeudor As cDeudor_Mov = Nothing

        Try
            With lMovDeudor
                lMovDeudor = New cDeudor_Mov(pAdmin)
                .Id_Mov = lDr("Id_Mov")
                .Id_Deudores = lDr("Id_Deudores")
                .Descripcion = lDr("Descripcion")
                .Id_Fac = lDr("Id_Fac")
                .FecAplica = lDr("FecAplica")
                .ImpoComp = lDr("ImpoComp")
                .MarcaAnulado = EnuBinarioGetEnu(lDr("MarcaAnulado"))
                .IdUsr = lDr("IdUsr")
                .FecOp = lDr("FecOp")
                .HoraOP = lDr("HoraOP")
            End With

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cDeudor_Mov.Load_Deudores_Mov")
            pAdmin.Log.fncGrabarLogERR("Error en cDeudor_Mov.Load_Deudores_Mov:" & ex.Message)
        End Try

        Return lMovDeudor

    End Function


    Public Shared Function GetDeudoresMovxIdMov(ByRef pAdmin As VzAdmin.cAdmin, ByVal pIdMov As Integer) As cDeudor_Mov
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lMovDeudor As cDeudor_Mov = Nothing

        Try
            lDt = Dat_GetDeudoresMovxIdMov(pAdmin, pIdMov)

            If lDt.Rows.Count > 0 Then

                For Each lDr In lDt.Rows
                    lMovDeudor = Load_Deudores_Mov(pAdmin, lDr)
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cDeudor_Mov.GetDeudoresMovxIdMov")
            pAdmin.Log.fncGrabarLogERR("Error en cDeudor_Mov.GetDeudoresMovxIdMov:" & ex.Message)
        End Try

        Return lMovDeudor

    End Function


    Public Shared Function GetDeudoresMovxIdDeudores(ByRef pAdmin As VzAdmin.cAdmin, ByVal pId_Deudores As Integer) As ArrayList
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lArray As ArrayList = Nothing
        Dim lMovDeudor As cDeudor_Mov = Nothing

        Try
            lDt = Dat_GetDeudoresMovxIdDeudor(pAdmin, pId_Deudores)

            If lDt.Rows.Count > 0 Then

                For Each lDr In lDt.Rows
                    lArray = New ArrayList
                    lMovDeudor = Load_Deudores_Mov(pAdmin, lDr)
                    lArray.Add(lMovDeudor)
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cDeudor_Mov.GetDeudoresMovxIdDeudores")
            pAdmin.Log.fncGrabarLogERR("Error en cDeudor_Mov.GetDeudoresMovxIdDeudores:" & ex.Message)
        End Try

        Return lArray

    End Function


#End Region

#Region "Base de Datos"
    Private Shared Function Dat_GetDeudoresMovxIdMov(ByRef pAdmin As VzAdmin.cAdmin, ByVal pIdMov As Integer) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "SELECT * FROM ven_movdeu where Id_Mov= #pIdMov# "
            Sql = Sql.Replace("#pIdMov#", pIdMov)


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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cDeudor_Mov.Dat_GetDeudoresMovxIdMov")
            pAdmin.Log.fncGrabarLogERR("Error en cDeudor_Mov.Dat_GetDeudoresMovxIdMov:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Shared Function Dat_GetDeudoresMovxIdDeudor(ByRef pAdmin As VzAdmin.cAdmin, ByVal pId_Deudor As Integer) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "SELECT * FROM ven_movdeu where Id_Deudores= #pId_Deudor# "
            Sql = Sql.Replace("#pId_Deudor#", pId_Deudor)


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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cDeudor_Mov.Dat_GetDeudoresMovxIdDeudor")
            pAdmin.Log.fncGrabarLogERR("Error en cDeudor_Mov.Dat_GetDeudoresMovxIdDeudor:" & ex.Message)
            Return Nothing
        End Try
    End Function


#End Region

End Class
