
Imports MySql.Data.MySqlClient
Imports VzAdmin
Imports VzComercial

Public Class cCliente

#Region "Declaracioens"

    Private gAdmin As VzAdmin.cAdmin

    Private _NroCli As String
    Private _Nombre As String
    Private _Domicilio As String
    Private _Localidad As String
    Private _CodPost As String
    Private _Tel As String
    Private _Mail As String
    Private _Cuit As String
    Private _CatIva As cCondicionIVA
    Private _Id_CondPago As cCondicionPago
    Private _CodProv As String
    Private _CodLista As Integer
    Private _SdoACt As Integer
    Private _SdoAnt As Integer
    Private _SitIB As cSitIB
    Private _Nro_IB As String
    Private _Mar_Percep As String
    Private _Mar_Riesg As String
    Private _Alic_Percep_ARF As Decimal
    Private _Mar_Seg_Disp As String
    Private _Cant_dias_Exceso_Vto As Integer
    Private _MedioEnvio As cMedioEnvio
    Private _Usuario As Integer
    Private _FecOp As Date
    Private _HoraOp As TimeSpan
    Private _Acepto_Grabar As enuBinario
    Private _Marca_Baja As enuBinario
    Private _Marca_Moroso As enuBinario
    Private _MsgEsp As String
    Private _MsgFicha As String

    Public Property NroCli As String
        Get
            Return _NroCli
        End Get
        Set(value As String)
            _NroCli = value
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

    Public Property CodPost As String
        Get
            Return _CodPost
        End Get
        Set(value As String)
            _CodPost = value
        End Set
    End Property

    Public Property Tel As String
        Get
            Return _Tel
        End Get
        Set(value As String)
            _Tel = value
        End Set
    End Property

    Public Property Mail As String
        Get
            Return _Mail
        End Get
        Set(value As String)
            _Mail = value
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

    Public Property CatIva As cCondicionIVA
        Get
            Return _CatIva
        End Get
        Set(value As cCondicionIVA)
            _CatIva = value
        End Set
    End Property

    Public Property Id_CondPago As cCondicionPago
        Get
            Return _Id_CondPago
        End Get
        Set(value As cCondicionPago)
            _Id_CondPago = value
        End Set
    End Property

    Public Property CodProv As String
        Get
            Return _CodProv
        End Get
        Set(value As String)
            _CodProv = value
        End Set
    End Property

    Public Property CodLista As Integer
        Get
            Return _CodLista
        End Get
        Set(value As Integer)
            _CodLista = value
        End Set
    End Property

    Public Property SdoACt As Integer
        Get
            Return _SdoACt
        End Get
        Set(value As Integer)
            _SdoACt = value
        End Set
    End Property

    Public Property SdoAnt As Integer
        Get
            Return _SdoAnt
        End Get
        Set(value As Integer)
            _SdoAnt = value
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

    Public Property Mar_Percep As String
        Get
            Return _Mar_Percep
        End Get
        Set(value As String)
            _Mar_Percep = value
        End Set
    End Property

    Public Property Mar_Riesg As String
        Get
            Return _Mar_Riesg
        End Get
        Set(value As String)
            _Mar_Riesg = value
        End Set
    End Property

    Public Property Alic_Percep_ARF As Decimal
        Get
            Return _Alic_Percep_ARF
        End Get
        Set(value As Decimal)
            _Alic_Percep_ARF = value
        End Set
    End Property

    Public Property Mar_Seg_Disp As String
        Get
            Return _Mar_Seg_Disp
        End Get
        Set(value As String)
            _Mar_Seg_Disp = value
        End Set
    End Property

    Public Property Cant_dias_Exceso_Vto As Integer
        Get
            Return _Cant_dias_Exceso_Vto
        End Get
        Set(value As Integer)
            _Cant_dias_Exceso_Vto = value
        End Set
    End Property

    Public Property MedioEnvio As cMedioEnvio
        Get
            Return _MedioEnvio
        End Get
        Set(value As cMedioEnvio)
            _MedioEnvio = value
        End Set
    End Property

    Public Property Usuario As Integer
        Get
            Return _Usuario
        End Get
        Set(value As Integer)
            _Usuario = value
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

    Public Property HoraOp As TimeSpan
        Get
            Return _HoraOp
        End Get
        Set(value As TimeSpan)
            _HoraOp = value
        End Set
    End Property

    Public Property Acepto_Grabar As enuBinario
        Get
            Return _Acepto_Grabar
        End Get
        Set(value As enuBinario)
            _Acepto_Grabar = value
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

    Public Property Marca_Moroso As enuBinario
        Get
            Return _Marca_Moroso
        End Get
        Set(value As enuBinario)
            _Marca_Moroso = value
        End Set
    End Property

    Public Property MsgEsp As String
        Get
            Return _MsgEsp
        End Get
        Set(value As String)
            _MsgEsp = value
        End Set
    End Property

    Public Property MsgFicha As String
        Get
            Return _MsgFicha
        End Get
        Set(value As String)
            _MsgFicha = value
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

    Public Shared Function Load_Cliente(ByRef pAdmin As VzAdmin.cAdmin, ByVal lDr As DataRow) As cCliente

        Dim lCliente As cCliente = Nothing

        Try
            lCliente = New cCliente(pAdmin)
            lCliente.NroCli = lDr("NroCli")
            lCliente.Nombre = lDr("Nombre")
            lCliente.Domicilio = lDr("Domicilio")
            lCliente.Localidad = lDr("Localidad")
            lCliente.CodPost = lDr("CodPost")
            lCliente.Tel = lDr("Tel")
            lCliente.Mail = lDr("Mail")
            lCliente.Cuit = lDr("Cuit")
            lCliente.CatIva = cCondicionIVA.GetCatIvaxCod(pAdmin, lDr("Id_CatIva"))
            lCliente.Id_CondPago = cCondicionPago.GetCondPagoxCod(pAdmin, lDr("Id_CondPago"))
            lCliente.CodProv = lDr("CodProv")
            lCliente.CodLista = lDr("CodLista")
            lCliente.SdoACt = lDr("SdoACt")
            lCliente.SdoAnt = lDr("SdoAnt")
            lCliente.SitIB = cSitIB.GetSitIBxCod(pAdmin, lDr("Cod_Sit_IB"))
            lCliente.Nro_IB = lDr("Nro_IB")
            lCliente.Mar_Percep = lDr("Mar_Percep")
            lCliente.Mar_Riesg = lDr("Mar_Riesg")
            lCliente.Alic_Percep_ARF = lDr("Alic_Percep_ARF")
            lCliente.Mar_Seg_Disp = lDr("Mar_Seg_Disp")
            lCliente.Cant_dias_Exceso_Vto = lDr("Cant_dias_Exceso_Vto")
            lCliente.MedioEnvio = cMedioEnvio.GetMedioEnvioxCod(pAdmin, lDr("Id_ME"))
            lCliente.Usuario = lDr("idusr")
            lCliente.FecOp = lDr("FecOp")
            lCliente.HoraOp = lDr("HoraOp")
            lCliente.Acepto_Grabar = EnuBinarioGetEnu(cFunciones.gFncgetDbValue(lDr("Acepto_Grabar"), cFunciones.TipoDato.TEXTO))
            lCliente.Marca_Baja = EnuBinarioGetEnu(lDr("Marca_Baja"))
            lCliente.Marca_Moroso = EnuBinarioGetEnu(lDr("Marca_Moroso"))
            lCliente.MsgEsp = lDr("MsgEsp")
            lCliente.MsgFicha = lDr("MsgFicha")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCliente.Load_Cliente")
            pAdmin.Log.fncGrabarLogERR("Error en cCliente.Load_Cliente:" & ex.Message)
        End Try

        Return lCliente

    End Function

    Public Shared Function GetClientexNroCliente(ByRef pAdmin As VzAdmin.cAdmin, ByVal pNroCli As String) As cCliente
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lCliente As cCliente = Nothing

        Try
            lDt = Dat_GetClientexNro(pAdmin, pNroCli)

            If lDt.Rows.Count > 0 Then

                For Each lDr In lDt.Rows
                    lCliente = Load_Cliente(pAdmin, lDr)
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCliente.GetClientexNroCliente")
            pAdmin.Log.fncGrabarLogERR("Error en cCliente.GetClientexNroCliente:" & ex.Message)
        End Try

        Return lCliente

    End Function

    Public Shared Function Busq_ClientexNroONombre(ByRef pAdmin As VzAdmin.cAdmin, ByVal pCli As String) As ArrayList
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lArray As ArrayList = New ArrayList
        Dim lCliente As cCliente = Nothing

        Try
            lDt = Dat_BuscarClientexNroONombre(pAdmin, pCli)

            If lDt.Rows.Count > 0 Then
                For Each lDr In lDt.Rows
                    lCliente = Load_Cliente(pAdmin, lDr)
                    lArray.Add(lCliente)
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCliente.Busq_ClientexNroONombre")
            pAdmin.Log.fncGrabarLogERR("Error en cCliente.Busq_ClientexNroONombre:" & ex.Message)
        End Try

        Return lArray

    End Function

#End Region

#Region "Base de Datos"

    Private Shared Function Dat_GetClientexNro(ByRef pAdmin As VzAdmin.cAdmin, ByVal pNroCli As String) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "SELECT * FROM cl_clientes where NroCli='#pNroCli#'"
            Sql = Sql.Replace("#pNroCli#", pNroCli)

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCliente.Dat_GetClientexNro")
            pAdmin.Log.fncGrabarLogERR("Error en cCliente.Dat_GetClientexNro:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Shared Function Dat_BuscarClientexNroONombre(ByRef pAdmin As VzAdmin.cAdmin, ByVal pCli As String) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "SELECT * FROM cl_clientes where NroCli like '%#pCli#%' or Nombre like '%#pCli#%'"
            Sql = Sql.Replace("#pCli#", pCli.Trim)

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCliente.Dat_BuscarClientexNroONombre")
            pAdmin.Log.fncGrabarLogERR("Error en cCliente.Dat_BuscarClientexNroONombre:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Shared Function Dat_GetClienteGetAll(ByRef pAdmin As VzAdmin.cAdmin) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "SELECT * FROM cl_clientes"

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCliente.Dat_GetClienteGetAll")
            pAdmin.Log.fncGrabarLogERR("Error en cCliente.Dat_GetClienteGetAll:" & ex.Message)
            Return Nothing
        End Try
    End Function

#End Region


End Class
