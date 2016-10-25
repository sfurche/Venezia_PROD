Imports VzAdmin
Imports MySql.Data.MySqlClient
Imports vzStock

Public Class cArticulo

#Region "Declaraciones"

    Private gAdmin As VzAdmin.cAdmin

    Private _CodArt As Integer
    Private _Descripcion As String
    Private _PcioCosto As Decimal
    Private _PcioVta As Decimal
    Private _Caja As cCajaArticulos
    Private _PorComis As Decimal
    Private _ImpStk As enuBinario
    Private _ArtacuStk As Integer
    Private _ArtRelXCaja As Integer
    Private _CalculaIVANdNc As enuBinario
    Private _Marca_Baja As enuBinario

    Public Property CodArt As Integer
        Get
            Return _CodArt
        End Get
        Set(value As Integer)
            _CodArt = value
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

    Public Property PcioCosto As Decimal
        Get
            Return _PcioCosto
        End Get
        Set(value As Decimal)
            _PcioCosto = value
        End Set
    End Property

    Public Property PcioVta As Decimal
        Get
            Return _PcioVta
        End Get
        Set(value As Decimal)
            _PcioVta = value
        End Set
    End Property

    Public Property Caja As cCajaArticulos
        Get
            Return _Caja
        End Get
        Set(value As cCajaArticulos)
            _Caja = value
        End Set
    End Property

    Public Property PorComis As Decimal
        Get
            Return _PorComis
        End Get
        Set(value As Decimal)
            _PorComis = value
        End Set
    End Property

    Public Property ImpStk As enuBinario
        Get
            Return _ImpStk
        End Get
        Set(value As enuBinario)
            _ImpStk = value
        End Set
    End Property

    Public Property ArtacuStk As Integer
        Get
            Return _ArtacuStk
        End Get
        Set(value As Integer)
            _ArtacuStk = value
        End Set
    End Property

    Public Property ArtRelXCaja As Integer
        Get
            Return _ArtRelXCaja
        End Get
        Set(value As Integer)
            _ArtRelXCaja = value
        End Set
    End Property

    Public Property CalculaIVANdNc As enuBinario
        Get
            Return _CalculaIVANdNc
        End Get
        Set(value As enuBinario)
            _CalculaIVANdNc = value
        End Set
    End Property

    Public Property Marca_Baja As enuBinario
        Get
            Return _Marca_Baja
        End Get
        Set(value As enuBinario)
            _Marca_Baja = value
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

    Public Sub CargarDatos(ByVal lDr As DataRow)
        Try
            If Not IsNothing(lDr) Then
                Me.CodArt = lDr("CodArt")
                Me.Descripcion = lDr("Descripcion")
                Me.PcioCosto = lDr("PcioCosto")
                Me.PcioVta = lDr("PcioVta")
                Me.Caja = cCajaArticulos.GetCajaArticulosxCod(Me.gAdmin, lDr("CodCaja"))
                Me.PorComis = lDr("PorComis")
                Me.Marca_Baja = EnuBinarioGetEnu(lDr("Marca_Baja"))
                Me.CalculaIVANdNc = EnuBinarioGetEnu(lDr("CalculaIVANdNc"))
                Me.ImpStk = EnuBinarioGetEnu(lDr("ImpStk"))
                Me.ArtacuStk = lDr("ArtacuStk")
                Me.ArtRelXCaja = lDr("ArtRelXCaja")
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cArticulo.CargarDatos")
            gAdmin.Log.fncGrabarLogERR("Error en cArticulo.CargarDatos:" & ex.Message)
        End Try

    End Sub

    Public Shared Function GetArticuloxCod(ByRef pAdmin As VzAdmin.cAdmin, ByVal pCodArt As Integer) As cArticulo
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lArticulo As cArticulo = Nothing

        Try
            lDt = Dat_GetArticuloxCod(pAdmin, pCodArt)

            If lDt.Rows.Count > 0 Then

                For Each lDr In lDt.Rows
                    lArticulo = New cArticulo(pAdmin)
                    lArticulo.CargarDatos(lDr)
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cArticulo.GetArticuloxCod")
            pAdmin.Log.fncGrabarLogERR("Error en cArticulo.GetArticuloxCod:" & ex.Message)
        End Try

        Return lArticulo

    End Function

    Public Shared Function GetArticulosxConsulta(ByRef pAdmin As VzAdmin.cAdmin, ByVal pCriterio As String) As ArrayList
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lArticulo As cArticulo = Nothing
        Dim lArray As New ArrayList

        Try
            lDt = Dat_GetArticulosxConsulta(pAdmin, pCriterio)

            If lDt.Rows.Count > 0 Then
                For Each lDr In lDt.Rows
                    lArticulo = New cArticulo(pAdmin)
                    lArticulo.CargarDatos(lDr)
                    lArray.Add(lArticulo)
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cArticulo.GetArticulosxConsulta")
            pAdmin.Log.fncGrabarLogERR("Error en cArticulo.GetArticulosxConsulta:" & ex.Message)
        End Try

        Return lArray

    End Function


#End Region

#Region "Base de Datos"

    Private Shared Function Dat_GetArticuloxCod(ByRef pAdmin As VzAdmin.cAdmin, ByVal pCodArt As Integer) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "SELECT * FROM pro_articulos where CodArt=#pCodArt#"
            Sql = Sql.Replace("#pCodArt#", pCodArt)

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cArticulo.Dat_GetArticuloxCod")
            pAdmin.Log.fncGrabarLogERR("Error en cArticulo.Dat_GetArticuloxCod:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Shared Function Dat_GetArticulosxConsulta(ByRef pAdmin As VzAdmin.cAdmin, ByVal pCriterio As String) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "SELECT * FROM pro_articulos where Descripcion Like '%#pCriterio#%' Or CodArt Like '%#pCriterio#%' "

            Sql = Sql.Replace("#pCriterio#", pCriterio.Trim)

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cArticulo.Dat_GetArticulosxConsulta")
            pAdmin.Log.fncGrabarLogERR("Error en cArticulo.Dat_GetArticulosxConsulta:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Shared Function Dat_GetArticuloGetAll(ByRef pAdmin As VzAdmin.cAdmin) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "SELECT * FROM pro_articulos"

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cArticulo.Dat_GetArticuloGetAll")
            pAdmin.Log.fncGrabarLogERR("Error en cArticulo.Dat_GetArticuloGetAll:" & ex.Message)
            Return Nothing
        End Try
    End Function

#End Region


End Class
