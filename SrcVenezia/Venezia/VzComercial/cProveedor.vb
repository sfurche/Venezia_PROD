Imports MySql.Data.MySqlClient
Imports VzAdmin
Imports VzComercial
Public Class cProveedor

#Region "Propiedades"

    Private gAdmin As VzAdmin.cAdmin

    Private _Id_Proveedor As Integer
    Private _Nombre As String
    Private _Domicilio As String
    Private _Localidad As String
    Private _Cod_Post As String
    Private _Telefono As String
    Private _CatIva As cCondicionIVA
    Private _Cuit As String
    Private _SitIB As cSitIB
    Private _Nro_IB As String
    Private _Mar_Reten As enuBinario
    Private _Mar_Reten_ARF As enuBinario
    Private _Alic_Reten As Double
    Private _Alic_Reten_ARF As Double

    Public Property Id_Proveedor As Integer
        Get
            Return _Id_Proveedor
        End Get
        Set(value As Integer)
            _Id_Proveedor = value
        End Set
    End Property

    Public Property Nombre As String
        Get
            Return _Nombre
        End Get
        Set(value As String)
            _Nombre = value
        End Set
    End Property

    Public Property Domicilio As String
        Get
            Return _Domicilio
        End Get
        Set(value As String)
            _Domicilio = value
        End Set
    End Property

    Public Property Localidad As String
        Get
            Return _Localidad
        End Get
        Set(value As String)
            _Localidad = value
        End Set
    End Property

    Public Property Cod_Post As String
        Get
            Return _Cod_Post
        End Get
        Set(value As String)
            _Cod_Post = value
        End Set
    End Property

    Public Property Telefono As String
        Get
            Return _Telefono
        End Get
        Set(value As String)
            _Telefono = value
        End Set
    End Property

    Public Property CatIva As cCondicionIVA
        Get
            Return _CatIva
        End Get
        Set(value As cCondicionIVA)
            _CatIva = value
        End Set
    End Property

    Public Property Cuit As String
        Get
            Return _Cuit
        End Get
        Set(value As String)
            _Cuit = value
        End Set
    End Property

    Public Property SitIB As cSitIB
        Get
            Return _SitIB
        End Get
        Set(value As cSitIB)
            _SitIB = value
        End Set
    End Property

    Public Property Nro_IB As String
        Get
            Return _Nro_IB
        End Get
        Set(value As String)
            _Nro_IB = value
        End Set
    End Property

    Public Property Mar_Reten As enuBinario
        Get
            Return _Mar_Reten
        End Get
        Set(value As enuBinario)
            _Mar_Reten = value
        End Set
    End Property

    Public Property Mar_Reten_ARF As enuBinario
        Get
            Return _Mar_Reten_ARF
        End Get
        Set(value As enuBinario)
            _Mar_Reten_ARF = value
        End Set
    End Property

    Public Property Alic_Reten As Double
        Get
            Return _Alic_Reten
        End Get
        Set(value As Double)
            _Alic_Reten = value
        End Set
    End Property

    Public Property Alic_Reten_ARF As Double
        Get
            Return _Alic_Reten_ARF
        End Get
        Set(value As Double)
            _Alic_Reten_ARF = value
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

    Public Sub New()

    End Sub

    Public Sub New(ByRef pAdmin As cAdmin)
        gAdmin = pAdmin
    End Sub

    Public Shared Function Load_Proveedor(ByRef pAdmin As VzAdmin.cAdmin, ByVal lDr As DataRow) As cProveedor

        Dim lProveedor As cProveedor = Nothing

        Try
            lProveedor = New cProveedor(pAdmin)
            lProveedor.Id_Proveedor = lDr("CodProve")
            lProveedor.Nombre = lDr("Nombre")
            lProveedor.Domicilio = lDr("Domicilio")
            lProveedor.Localidad = lDr("Localidad")
            lProveedor.Cod_Post = lDr("Cod_Post")
            lProveedor.Telefono = lDr("Tel")
            lProveedor.Cuit = lDr("Cuit")
            lProveedor.CatIva = cCondicionIVA.GetCatIvaxCod(pAdmin, lDr("Id_CatIva"))
            lProveedor.SitIB = cSitIB.GetSitIBxCod(pAdmin, lDr("Cod_Sit_IB"))
            lProveedor.Nro_IB = lDr("Nro_IB")
            lProveedor.Mar_Reten = EnuBinarioGetEnu(cFunciones.gFncgetDbValue(lDr("Mar_Reten"), cFunciones.TipoDato.TEXTO))
            lProveedor.Mar_Reten_ARF = EnuBinarioGetEnu(cFunciones.gFncgetDbValue(lDr("Mar_Reten_ARF"), cFunciones.TipoDato.TEXTO))
            lProveedor.Alic_Reten = lDr("Alic_Reten")
            lProveedor.Alic_Reten_ARF = lDr("Alic_Reten_ARF")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cProveedor.Load_Proveedor")
            pAdmin.Log.fncGrabarLogERR("Error en cProveedor.Load_Proveedor:" & ex.Message)
        End Try

        Return lProveedor

    End Function

    Public Shared Function GetProveedorxNro(ByRef pAdmin As VzAdmin.cAdmin, ByVal pNro As String) As cProveedor
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lProveedor As cProveedor = Nothing

        Try
            lDt = Dat_GetProveedorxNro(pAdmin, pNro)

            If lDt.Rows.Count > 0 Then

                For Each lDr In lDt.Rows
                    lProveedor = Load_Proveedor(pAdmin, lDr)
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cProveedor.GetProveedorxNroProveedor")
            pAdmin.Log.fncGrabarLogERR("Error en cProveedor.GetProveedorxNroProveedor:" & ex.Message)
        End Try

        Return lProveedor

    End Function

    Public Shared Function GetAllProveedor(ByRef pAdmin As VzAdmin.cAdmin) As ArrayList
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lArray As ArrayList = New ArrayList
        Dim lProveedor As cProveedor = Nothing

        Try
            lDt = Dat_GetProveedorGetAll(pAdmin)

            If lDt.Rows.Count > 0 Then
                For Each lDr In lDt.Rows
                    lProveedor = Load_Proveedor(pAdmin, lDr)
                    lArray.Add(lProveedor)
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cProveedor.GetAllProveedor")
            pAdmin.Log.fncGrabarLogERR("Error en cProveedor.GetAllProveedor:" & ex.Message)
        End Try

        Return lArray

    End Function

    Public Shared Function GetProveedorxNroONombre(ByRef pAdmin As VzAdmin.cAdmin, ByVal pCli As String) As ArrayList
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lArray As ArrayList = New ArrayList
        Dim lProveedor As cProveedor = Nothing

        Try
            lDt = Dat_BuscarProveedorxNroONombre(pAdmin, pCli)

            If lDt.Rows.Count > 0 Then
                For Each lDr In lDt.Rows
                    lProveedor = Load_Proveedor(pAdmin, lDr)
                    lArray.Add(lProveedor)
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cProveedor.Busq_ProveedorxNroONombre")
            pAdmin.Log.fncGrabarLogERR("Error en cProveedor.Busq_ProveedorxNroONombre:" & ex.Message)
        End Try

        Return lArray

    End Function

#End Region

#Region "Base de Datos"

    Private Shared Function Dat_GetProveedorxNro(ByRef pAdmin As VzAdmin.cAdmin, ByVal pNroProv As String) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "SELECT * FROM prv_proveedor where CodProve='#pNroProv#'"
            Sql = Sql.Replace("#pNroProv#", pNroProv)

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cProveedor.Dat_GetProveedorxNro")
            pAdmin.Log.fncGrabarLogERR("Error en cProveedor.Dat_GetProveedorxNro:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Shared Function Dat_BuscarProveedorxNroONombre(ByRef pAdmin As VzAdmin.cAdmin, ByVal pProv As String) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "SELECT * FROM prv_proveedor where CodProve like '%#pProv#%' or Nombre like '%#pProv#%'"
            Sql = Sql.Replace("#pProv#", pProv.Trim)

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCliente.Dat_BuscarProveedorxNroONombre")
            pAdmin.Log.fncGrabarLogERR("Error en cCliente.Dat_BuscarProveedorxNroONombre:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Shared Function Dat_GetProveedorGetAll(ByRef pAdmin As VzAdmin.cAdmin) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "SELECT * FROM prv_proveedor"

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cProveedor.Dat_GetProveedorGetAll")
            pAdmin.Log.fncGrabarLogERR("Error en cProveedor.Dat_GetProveedorGetAll:" & ex.Message)
            Return Nothing
        End Try
    End Function

#End Region


End Class
