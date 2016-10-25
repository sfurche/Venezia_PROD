Imports MySql.Data.MySqlClient

Public Class cVendedor

    Private _IdKey As Integer
    Private _IdVendedor As Integer
    Private _Nombre As String
    Private gAdmin As VzAdmin.cAdmin

#Region "Propiedades"

    Public Property IdKey As Integer
        Get
            Return _IdKey
        End Get
        Set(value As Integer)
            _IdKey = value
        End Set
    End Property

    Public Property IdVendedor As Integer
        Get
            Return _IdVendedor
        End Get
        Set(value As Integer)
            _IdVendedor = value
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

#End Region

#Region "Funciones"

    Public Sub New()

    End Sub

    Public Sub New(ByRef pAdmin As VzAdmin.cAdmin)
        gAdmin = pAdmin
    End Sub

    Public Sub New(ByRef pAdmin As VzAdmin.cAdmin, ByVal pid_Vendedor As Integer)
        gAdmin = pAdmin
    End Sub

    Private Sub subCargarDatos(ByVal lDr As DataRow)

        Try
            _IdKey = lDr("Id_KeyV")
            _IdVendedor = lDr("IdVendedor")
            _Nombre = lDr("NombreVen")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cVendedor.subCargarDatos")
            gAdmin.Log.fncGrabarLogERR("Error en cVendedor.subCargarDatos:" & ex.Message)
        End Try

    End Sub

#End Region


#Region "Shared Functions"


    Public Shared Function GetVendedorexId(ByRef pAdmin As VzAdmin.cAdmin, ByVal pId As Integer) As cVendedor
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lVen As cVendedor = Nothing

        Try

            lDt = Dat_GetVendedorxID(pAdmin, pId)

            If lDt.Rows.Count > 0 Then

                For Each lDr In lDt.Rows
                    lVen = New cVendedor(pAdmin)
                    lVen.IdKey = lDr("Id_KeyV")
                    lVen.IdVendedor = lDr("Id_Vendedor")
                    lVen.Nombre = lDr("NombreVen")
                Next

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cVendedor.GetVendedorexId")
            pAdmin.Log.fncGrabarLogERR("Error en cVendedor.GetVendedorexId:" & ex.Message)
            Return Nothing
        End Try

        Return lVen

    End Function

    Public Shared Function GetVendedoresAll(ByRef pAdmin As VzAdmin.cAdmin) As ArrayList
        Dim lDt As DataTable
        Dim lArray As ArrayList = Nothing
        Dim lDr As DataRow
        Dim lVen As cVendedor

        Try

            lDt = Dat_GetVendedorAll(pAdmin)

            If lDt.Rows.Count > 0 Then

                lArray = New ArrayList

                For Each lDr In lDt.Rows
                    lVen = New cVendedor(pAdmin)
                    lVen.IdKey = lDr("Id_KeyV")
                    lVen.IdVendedor = lDr("Id_Vendedor")
                    lVen.Nombre = lDr("NombreVen")
                    lArray.Add(lVen)
                Next

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cVendedor.GetVendedoresAll")
            pAdmin.Log.fncGrabarLogERR("Error en cVendedor.GetVendedoresAll:" & ex.Message)
            Return Nothing
        End Try

        Return lArray

    End Function

#End Region

#Region "Base de Datos"

    Private Shared Function Dat_GetVendedorxID(ByRef pAdmin As VzAdmin.cAdmin, ByVal pIdVendedor As String) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "Select * from ven_vendedor where Id_Vendedor=#IdVendedor"
            Sql = Sql.Replace("#IdVendedor", pIdVendedor)

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cVendedor.Dat_GetVendedorxID")
            pAdmin.Log.fncGrabarLogERR("Error en cVendedor.Dat_GetVendedorxID:" & ex.Message)
            Return Nothing
        End Try
    End Function


    Private Shared Function Dat_GetVendedorAll(ByRef pAdmin As VzAdmin.cAdmin) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "Select * from ven_vendedor"

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cVendedor.Dat_GetVendedorAll")
            pAdmin.Log.fncGrabarLogERR("Error en cVendedor.Dat_GetVendedorAll:" & ex.Message)
            Return Nothing
        End Try
    End Function


#End Region


End Class
