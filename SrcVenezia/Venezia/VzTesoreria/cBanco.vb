Imports VzTesoreria
Imports MySql.Data.MySqlClient
Imports VzAdmin

Public Class cBanco

#Region "Declaraciones"


    Private gAdmin As VzAdmin.cAdmin

    Private _id_Banco As Integer
    Private _CodBCRA As Integer
    Private _Nombre As String
    Private _NombreRed As String
    Private _NombreComb As String
    Private _EsNuevo As Boolean = True


    Public Property Id_Banco As Integer
        Get
            Return _id_Banco
        End Get
        Set(value As Integer)
            _id_Banco = value
        End Set
    End Property

    Public Property CodBCRA As Integer
        Get
            Return _CodBCRA
        End Get
        Set(value As Integer)
            _CodBCRA = value
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

    Public Property NombreRed As String
        Get
            Return _NombreRed
        End Get
        Set(value As String)
            _NombreRed = value
        End Set
    End Property

    Public Property EsNuevo As Boolean
        Get
            Return _EsNuevo
        End Get
        Set(value As Boolean)
            _EsNuevo = value
        End Set
    End Property

    Public Property NombreComb As String
        Get
            Return _NombreComb
        End Get
        Set(value As String)
            _NombreComb = value
        End Set
    End Property

#End Region

#Region "Funciones"

    Public Sub New()

    End Sub

    Public Sub New(ByRef pAdmin As VzAdmin.cAdmin)
        gAdmin = pAdmin
    End Sub

    Public Sub Dispose()
        Me.Dispose()
    End Sub

    Public Sub Save()
        Try
            MsgBox("Funcion save banco no disponible.", MsgBoxStyle.Critical)


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cBanco.Save")
            gAdmin.Log.fncGrabarLogERR("Error en cBanco.Save" & ex.Message)
        End Try
    End Sub


#End Region


#Region "Shared Functions"

    Public Shared Function Banco_BusqxId(ByRef pAdmin As cAdmin, ByVal pId_Banco As Integer) As cBanco

        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lBco As cBanco = Nothing

        Try
            lDt = Dat_GetBancosxID(pAdmin, pId_Banco)

            If lDt.Rows.Count > 0 Then

                For Each lDr In lDt.Rows
                    lBco = New cBanco(pAdmin)
                    lBco.Id_Banco = lDr("id_bco")
                    lBco.CodBCRA = lDr("cod_bco")
                    lBco.Nombre = lDr("nomb_bco")
                    lBco.NombreRed = lDr("nomb_bco_red")
                    lBco.EsNuevo = False
                Next

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cBanco.Banco_LoadxId")
            pAdmin.Log.fncGrabarLogERR("Error en cBanco.Banco_LoadxId" & ex.Message)
        End Try

        Return lBco
    End Function

    Public Shared Function Banco_BusqxNombreRed(ByRef pAdmin As cAdmin, ByVal pNombre As String) As ArrayList
        Dim lArray As ArrayList = Nothing
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lBco As cBanco = Nothing

        Try
            lDt = Dat_GetBancosxID(pAdmin, pNombre.Trim.ToUpper)

            If lDt.Rows.Count > 0 Then
                lArray = New ArrayList

                For Each lDr In lDt.Rows
                    lBco = New cBanco(pAdmin)
                    lBco.Id_Banco = lDr("id_bco")
                    lBco.CodBCRA = lDr("cod_bco")
                    lBco.Nombre = lDr("nomb_bco")
                    lBco.NombreRed = lDr("nomb_bco_red")
                    lBco.EsNuevo = False
                    lArray.Add(lBco)
                Next

            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cBanco.Banco_BusqxNombreRed")
            pAdmin.Log.fncGrabarLogERR("Error en cBanco.Banco_BusqxNombreRed" & ex.Message)
            lArray = Nothing
        End Try

        Return lArray

    End Function

    Public Shared Function Banco_GetAll(ByRef pAdmin As cAdmin) As ArrayList
        Dim lArray As ArrayList = Nothing
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lBco As cBanco = Nothing

        Try
            lDt = Dat_GetBancosAll(pAdmin)

            If lDt.Rows.Count > 0 Then
                lArray = New ArrayList

                For Each lDr In lDt.Rows
                    lBco = New cBanco(pAdmin)
                    lBco.Id_Banco = lDr("id_bco")
                    lBco.CodBCRA = lDr("cod_bco")
                    lBco.Nombre = lDr("nomb_bco")
                    lBco.NombreRed = lDr("nomb_bco_red")
                    lBco.NombreComb = lBco.CodBCRA & " - " & lBco.NombreRed
                    lBco.EsNuevo = False
                    lArray.Add(lBco)
                Next

            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cBanco.Banco_GetAll")
            pAdmin.Log.fncGrabarLogERR("Error en cBanco.Banco_GetAll" & ex.Message)
            lArray = Nothing
        End Try

        Return lArray

    End Function

#End Region

#Region "Base de Datos"

    Private Shared Function Dat_GetBancosxID(ByRef pAdmin As VzAdmin.cAdmin, ByVal pIdBco As String) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "select * from sis_bancos where id_bco =#Id#"
            Sql = Sql.Replace("#Id#", pIdBco)

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cBanco.Dat_GetBancosxID")
            pAdmin.Log.fncGrabarLogERR("Error en cBanco.Dat_GetBancosxID:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Shared Function Dat_GetBancosxNombreRed(ByRef pAdmin As VzAdmin.cAdmin, ByVal pNomRed As String) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "select * from sis_bancos where nomb_bco_red like '%#NomRed#%'"
            Sql = Sql.Replace("#NomRed#", pNomRed.Trim.ToUpper)

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cBanco.Dat_GetBancosxNombreRed")
            pAdmin.Log.fncGrabarLogERR("Error en cBanco.Dat_GetBancosxNombreRed:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Shared Function Dat_GetBancosAll(ByRef pAdmin As VzAdmin.cAdmin) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "select * from sis_bancos order by cod_bco"

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cBanco.Dat_GetBancosAll")
            pAdmin.Log.fncGrabarLogERR("Error en cBanco.Dat_GetBancosAll:" & ex.Message)
            Return Nothing
        End Try
    End Function

#End Region

End Class
