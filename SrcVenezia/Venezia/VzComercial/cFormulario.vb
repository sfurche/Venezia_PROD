Imports MySql.Data.MySqlClient
Imports VzAdmin

Public Class cFormulario

#Region "Propiedades"

    Private gAdmin As VzAdmin.cAdmin

    Private _CodForm As String
    Private _Descripcion As String
    Private _DescRed As String
    Private _ImputStock As String
    Private _ImputSdoCC As String
    Private _ImputIVA As String
    Private _UltNroComp As Integer
    Private _ColorBack As Integer

    Public Property CodForm As String
        Get
            Return _CodForm
        End Get
        Set(value As String)
            _CodForm = value
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

    Public Property DescRed As String
        Get
            Return _DescRed
        End Get
        Set(value As String)
            _DescRed = value
        End Set
    End Property

    Public Property ImputStock As String
        Get
            Return _ImputStock
        End Get
        Set(value As String)
            _ImputStock = value
        End Set
    End Property

    Public Property ImputSdoCC As String
        Get
            Return _ImputSdoCC
        End Get
        Set(value As String)
            _ImputSdoCC = value
        End Set
    End Property

    Public Property ImputIVA As String
        Get
            Return _ImputIVA
        End Get
        Set(value As String)
            _ImputIVA = value
        End Set
    End Property

    Public Property UltNroComp As Integer
        Get
            Return _UltNroComp
        End Get
        Set(value As Integer)
            _UltNroComp = value
        End Set
    End Property

    Public Property ColorBack As Integer
        Get
            Return _ColorBack
        End Get
        Set(value As Integer)
            _ColorBack = value
        End Set
    End Property


#End Region

#Region "Funciones"

    Public Sub New(ByRef pAdmin As cAdmin)
        gAdmin = pAdmin
    End Sub

    Public Shared Function GetFormularioxCod(ByRef pAdmin As VzAdmin.cAdmin, ByVal pCodForm As Integer) As cFormulario
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lForm As cFormulario = Nothing

        Try
            lDt = Dat_GetFormularioxCod(pAdmin, pCodForm)

            If lDt.Rows.Count > 0 Then

                For Each lDr In lDt.Rows
                    lForm = New cFormulario(pAdmin)
                    lForm.CodForm = lDr("CodForm")
                    lForm.Descripcion = lDr("Descripcion")
                    lForm.DescRed = lDr("DescRed")
                    lForm.ImputStock = lDr("ImputStock")
                    lForm.ImputSdoCC = lDr("ImputSdoCC")
                    lForm.ImputIVA = lDr("ImputIVA")
                    lForm.UltNroComp = lDr("UltNroComp")
                    lForm.ColorBack = lDr("ColorBack")
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cFormulario.GetFormularioxCod")
            pAdmin.Log.fncGrabarLogERR("Error en cFormulario.GetFormularioxCod:" & ex.Message)
        End Try

        Return lForm

    End Function

#End Region

#Region "Base de Datos"

    Private Shared Function Dat_GetFormularioxCod(ByRef pAdmin As VzAdmin.cAdmin, ByVal pCodForm As Integer) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "SELECT * FROM sis_formularios where CodForm = #pCodForm# "
            Sql = Sql.Replace("#pCodForm#", pCodForm)


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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cFormulario.Dat_GetFormularioxCod")
            pAdmin.Log.fncGrabarLogERR("Error en cFormulario.Dat_GetFormularioxCod:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Shared Function Dat_GetFormularioGetAll(ByRef pAdmin As VzAdmin.cAdmin) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "SELECT * FROM sis_formularios"

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cFormulario.Dat_GetFormularioGetAll")
            pAdmin.Log.fncGrabarLogERR("Error en cFormulario.Dat_GetFormularioGetAll:" & ex.Message)
            Return Nothing
        End Try
    End Function

#End Region
End Class
