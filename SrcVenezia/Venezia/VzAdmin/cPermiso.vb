Imports MySql.Data.MySqlClient
Imports VzAdmin

Public Class cPermiso


#Region "Declaraciones"

    Private _Id_Permiso As Integer
    Private _Nombre As String
    Private _Observaciones As String
    Private _Alta As enuBinario
    Private _Baja As enuBinario
    Private _Modificacion As enuBinario
    Private _Ejecuta As enuBinario
    Private _Consulta As enuBinario
    Private _Supervisa As enuBinario
    Private _Admin As enuBinario

    Private gAdmin As cAdmin

    Public Property Id_Permiso As Integer
        Get
            Return _Id_Permiso
        End Get
        Set(value As Integer)
            _Id_Permiso = value
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

    Public Property Observaciones As String
        Get
            Return _Observaciones
        End Get
        Set(value As String)
            _Observaciones = value
        End Set
    End Property

    Public Property Alta As enuBinario
        Get
            Return _Alta
        End Get
        Set(value As enuBinario)
            _Alta = value
        End Set
    End Property

    Public Property Baja As enuBinario
        Get
            Return _Baja
        End Get
        Set(value As enuBinario)
            _Baja = value
        End Set
    End Property

    Public Property Modificacion As enuBinario
        Get
            Return _Modificacion
        End Get
        Set(value As enuBinario)
            _Modificacion = value
        End Set
    End Property

    Public Property Ejecuta As enuBinario
        Get
            Return _Ejecuta
        End Get
        Set(value As enuBinario)
            _Ejecuta = value
        End Set
    End Property

    Public Property Consulta As enuBinario
        Get
            Return _Consulta
        End Get
        Set(value As enuBinario)
            _Consulta = value
        End Set
    End Property

    Public Property Supervisa As enuBinario
        Get
            Return _Supervisa
        End Get
        Set(value As enuBinario)
            _Supervisa = value
        End Set
    End Property

    Public Property Admin As enuBinario
        Get
            Return _Admin
        End Get
        Set(value As enuBinario)
            _Admin = value
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

    Public Sub Load(ByVal pDr As DataRow)
        Try
            _Id_Permiso = pDr("id_permiso")
            _Nombre = pDr("nombre")
            _Observaciones = pDr("observaciones")
            _Alta = EnuBinarioGetEnu(pDr("alta"))
            _Baja = EnuBinarioGetEnu(pDr("baja"))
            _Modificacion = EnuBinarioGetEnu(pDr("modifica"))
            _Ejecuta = EnuBinarioGetEnu(pDr("ejecuta"))
            _Consulta = EnuBinarioGetEnu(pDr("consulta"))
            _Supervisa = EnuBinarioGetEnu(pDr("supervisa"))
            _Admin = EnuBinarioGetEnu(pDr("admin"))

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cPermiso.Load")
            gLog.fncGrabarLogERR("Error en cPermiso.Load:" & ex.Message)
        End Try
    End Sub

    Public Shared Function GetPermisosxUsuario(ByRef pAdmin As cAdmin, ByVal pidUser As Integer) As ArrayList
        Dim lDt As DataTable
        Dim lDr As DataRow = Nothing
        Dim lArray As New ArrayList
        Dim lPermiso As cPermiso = Nothing
        Try

            lDt = Dat_GetPermisosUsuario(pAdmin, pidUser)


            For Each lDr In lDt.Rows
                lPermiso = New cPermiso(pAdmin)
                lPermiso.Load(lDr)
                lArray.Add(lPermiso)
            Next

            Return lArray

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cPermiso.GetPermisosxUsuario")
            pAdmin.Log.fncGrabarLogERR("Error en cPermiso.GetPermisosxUsuario:" & ex.Message)
            Return Nothing
        End Try
    End Function

#End Region

#Region "Base de Datos"
    Public Shared Function Dat_GetPermisosUsuario(ByRef pAdmin As cAdmin, ByVal pidUser As Integer) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "call vz_permisos_usuarios_consulta (#idusr#)"
            Sql = Sql.Replace("#idusr#", pidUser)

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cPermiso.Dat_GetPermisosUsuario")
            pAdmin.Log.fncGrabarLogERR("Error en cPermiso.Dat_GetPermisosUsuario:" & ex.Message)
            Return Nothing
        End Try
    End Function
#End Region


End Class
