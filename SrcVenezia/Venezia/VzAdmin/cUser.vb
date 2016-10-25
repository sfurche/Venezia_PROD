Imports MySql.Data.MySqlClient

Public Class cUser

#Region "Declaraciones"

    Private _Usuario As String = ""
    Private _Pwd As String = ""
    Private _PwdEnc As String = ""
    Private _Id As Integer
    Private _FecBaja As Date
    Private _FecAlta As Date
    Private _Validado As Boolean = False
    Private _Permisos As ArrayList = Nothing

    Private gAdmin As cAdmin


    Public Property Usuario As String
        Get
            Return _Usuario
        End Get
        Set(value As String)
            _Usuario = value
        End Set
    End Property

    Public Property Pwd As String
        Get
            Return _Pwd
        End Get
        Set(value As String)
            _Pwd = value
        End Set
    End Property

    Public ReadOnly Property Validado As Boolean
        Get
            Return _Validado
        End Get
    End Property

    Public Property Id As Integer
        Get
            Return _Id
        End Get
        Set(value As Integer)
            _Id = value
        End Set
    End Property

    Public Property FecBaja As Date
        Get
            Return _FecBaja
        End Get
        Set(value As Date)
            _FecBaja = value
        End Set
    End Property

    Public Property FecAlta As Date
        Get
            Return _FecAlta
        End Get
        Set(value As Date)
            _FecAlta = value
        End Set
    End Property

    Public Property Permisos As ArrayList
        Get
            Return _Permisos
        End Get
        Set(value As ArrayList)
            _Permisos = value
        End Set
    End Property

#End Region

#Region "Funciones"

    Public Sub New()

    End Sub

    Public Sub New(ByRef pAdmin As cAdmin)
        gAdmin = pAdmin
    End Sub

    Public Sub Dispose()
        Me.Dispose()
    End Sub

    Public Function Validar(ByVal pUsuario As String, ByVal pPwd As String) As Boolean
        Dim lDt As DataTable

        Try
            _Usuario = pUsuario.ToLower()
            lDt = Dat_GetUsuario(_Usuario)

            If Not IsNothing(lDt) And lDt.Rows.Count > 0 Then
                _PwdEnc = lDt.Rows(0)("clave")
                _FecAlta = lDt.Rows(0)("falta")
                _FecBaja = lDt.Rows(0)("fbaja")
                _Id = lDt.Rows(0)("idusr")
                _Pwd = Dencry(_PwdEnc.Trim).Trim
                _Permisos = cPermiso.GetPermisosxUsuario(gAdmin, Me.Id)

                If _Pwd = pPwd.Trim Then
                    _Validado = True
                Else
                    _Validado = False
                End If

            Else
                _Validado = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cUser.Validar")
            gLog.fncGrabarLogERR("Error en cUser.Validar:" & ex.Message)
        End Try

        Return _Validado

    End Function

    Public Sub Load(ByVal pDr As DataRow)
        Try

            _PwdEnc = pDr("clave")
            _FecAlta = pDr("falta")
            _FecBaja = pDr("fbaja")
            _Id = pDr("idusr")
            _Pwd = Dencry(_PwdEnc.Trim).Trim
            _Usuario = pDr("idusr")
            _Permisos = cPermiso.GetPermisosxUsuario(gadmin, Me.Id)
            _Validado = False

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cUser.Load")
            gLog.fncGrabarLogERR("Error en cUser.Load:" & ex.Message)
        End Try
    End Sub

    Public Function Encry(sCadena)
        ' Encry( <sCadena> )
        ' Encripta los caracteres de la cadena de caracteres <sCadena>.
        Dim sReturn As String
        Dim lCadena As String
        Dim i As Byte

        sReturn = ""
        For i = 1 To Len(sCadena)
            lCadena = Int((Asc(Mid(sCadena, i, 1)) + i) Mod 256)
            lCadena = (lCadena Mod 16) * 16 + Int(lCadena / 16)
            sReturn = sReturn + Chr(lCadena)
        Next
        Encry = sReturn

    End Function

    Private Function Dencry(sCadena As String) As String

        '* Dencry( <sCadena> )
        '* Desencripta los caracteres de la cadena de caracteres <sCadena>.
        '*
        Dim sReturn As String
        Dim lCadena As String
        Dim i As Byte

        sReturn = ""
        For i = 1 To Len(sCadena)
            lCadena = Asc(Mid(sCadena, i, 1))
            lCadena = Int(lCadena Mod 16) * 16 + Int(lCadena / 16)
            lCadena = Int((lCadena + 256 - i) Mod 256)
            sReturn = sReturn + Chr(lCadena)
        Next
        Dencry = sReturn

    End Function

    Public Function GetPermiso(ByVal pNomPermiso As String) As cPermiso
        Dim lPermiso As cPermiso = Nothing
        GetPermiso = Nothing
        Try
            For Each lPermiso In Me.Permisos
                If lPermiso.Nombre = pNomPermiso Then
                    GetPermiso = lPermiso
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cUser.GetPermiso")
            gLog.fncGrabarLogERR("Error en cUser.GetPermiso:" & ex.Message)
        End Try
    End Function

#End Region

#Region "Shared Functions"

    Public Shared Function GetUsuarioxId(ByRef pAdmin As cAdmin, ByVal pIdUsr As Integer) As cUser
        Dim lDt As DataTable = Nothing
        GetUsuarioxId = Nothing

        Try
            lDt = Dat_GetUsuarioxID(pAdmin, pIdUsr)

            If lDt.Rows.Count > 0 Then
                GetUsuarioxId = New cUser()
                GetUsuarioxId.Load(lDt(0))
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cUser.Dat_GetUsuario")
            gLog.fncGrabarLogERR("Error en cUser.Dat_GetUsuario:" & ex.Message)
        End Try
    End Function

#End Region

#Region "Base de Datos"

    Public Function Dat_GetUsuario(ByVal pUser As String) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = gDbCnn.GetInstanceCon
            Sql = "Select * from sis_usuarios where nombre='#Nombre'"
            Sql = Sql.Replace("#Nombre", pUser.ToLower)

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cUser.Dat_GetUsuario")
            gLog.fncGrabarLogERR("Error en cUser.Dat_GetUsuario:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Function Dat_GetUsuarioxID(ByRef pAdmin As VzAdmin.cAdmin, ByVal pIdUsr As Integer) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = gDbCnn.GetInstanceCon
            Sql = "Select * from sis_usuarios where idusr=#idusr#"
            Sql = Sql.Replace("#idusr#", pIdUsr)

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cUser.Dat_GetUsuarioxID")
            gLog.fncGrabarLogERR("Error en cUser.Dat_GetUsuarioxID:" & ex.Message)
            Return Nothing
        End Try
    End Function


#End Region

End Class
