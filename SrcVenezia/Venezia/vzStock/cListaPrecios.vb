Imports VzAdmin
Imports MySql.Data.MySqlClient

Public Class cListaPrecios

#Region "Propiedades"
    Private gAdmin As VzAdmin.cAdmin

    Private _IdLista As Integer
    Private _CodLista As Integer
    Private _Descripcion As String
    Private _FVig As Date
    Private _FVto As Date
    Private _Lista As ArrayList

    Public Property IdLista As Integer
        Get
            Return _IdLista
        End Get
        Set(value As Integer)
            _IdLista = value
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

    Public Property Descripcion As String
        Get
            Return _Descripcion
        End Get
        Set(value As String)
            _Descripcion = value
        End Set
    End Property

    Public Property FVig As Date
        Get
            Return _FVig
        End Get
        Set(value As Date)
            _FVig = value
        End Set
    End Property

    Public Property FVto As Date
        Get
            Return _FVto
        End Get
        Set(value As Date)
            _FVto = value
        End Set
    End Property

    Public Property Lista As ArrayList
        Get
            Return _Lista
        End Get
        Set(value As ArrayList)
            _Lista = value
        End Set
    End Property

#End Region

#Region "Funciones"

    Public Sub New(ByRef pAdmin As cAdmin)
        Me.gAdmin = pAdmin
        Me.Lista = New ArrayList
    End Sub

    Private Sub subCargarDatos(ByVal lDr As DataRow)
        Try
            _IdLista = lDr("Id_CodLista")
            _CodLista = lDr("Codlista")
            _Descripcion = lDr("Descripcion")
            _FVig = cFunciones.gFncgetDbValue(lDr("FVig"), cFunciones.TipoDato.FECHA)
            _FVto = cFunciones.gFncgetDbValue(lDr("FVto"), cFunciones.TipoDato.FECHA)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cListaPrecios.subCargarDatos")
            gAdmin.Log.fncGrabarLogERR("Error en cListaPrecios.subCargarDatos:" & ex.Message)
        End Try

    End Sub

    Public Sub subCargarDatosPrecios()
        'Para no cargar siempre todo el detalle, se hace con este metodo a demanda.
        Try
            Lista = cListaPreciosDet.GetListasDePreciosDetxLP(gAdmin, Me.IdLista)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cListaPrecios.subCargarDatosPrecios")
            gAdmin.Log.fncGrabarLogERR("Error en cListaPrecios.subCargarDatosPrecios:" & ex.Message)
        End Try

    End Sub

    Public Sub subCargarDatosPrecios(ByVal pDescArticulo As String)
        'Para no cargar siempre todo el detalle, se hace con este metodo a demanda. Aca filtra por la descripcion del articulo.
        Try
            Lista = cListaPreciosDet.GetListasDePreciosDetxLP(gAdmin, Me.IdLista, pDescArticulo)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cListaPrecios.subCargarDatosPrecios")
            gAdmin.Log.fncGrabarLogERR("Error en cListaPrecios.subCargarDatosPrecios:" & ex.Message)
        End Try

    End Sub

    Public Shared Function GetListaPreciosxCod(ByRef pAdmin As VzAdmin.cAdmin, ByVal pCodLista As Integer) As cListaPrecios
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lLista As cListaPrecios = Nothing

        Try
            lDt = Dat_GetListaDePredcioxIdLista(pAdmin, pCodLista)

            If lDt.Rows.Count > 0 Then

                For Each lDr In lDt.Rows
                    lLista = New cListaPrecios(pAdmin)
                    lLista.subCargarDatos(lDr)
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cListaPrecios.GetListaPreciosxCod")
            pAdmin.Log.fncGrabarLogERR("Error en cListaPrecios.GetListaPreciosxCod:" & ex.Message)
        End Try

        Return lLista

    End Function

    Public Shared Function GetAllListasDePrecios(ByRef pAdmin As VzAdmin.cAdmin) As ArrayList
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lArray As New ArrayList
        Dim lLista As cListaPrecios = Nothing

        Try
            lDt = Dat_GetListaDePrecioGetAll(pAdmin)

            If lDt.Rows.Count > 0 Then
                For Each lDr In lDt.Rows
                    lLista = New cListaPrecios(pAdmin)
                    lLista.subCargarDatos(lDr)
                    lArray.Add(lLista)
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cListaPrecios.GetAllListasDePrecios")
            pAdmin.Log.fncGrabarLogERR("Error en cListaPrecios.GetAllListasDePrecios:" & ex.Message)
        End Try

        Return lArray

    End Function

    Public Shared Function GetListasDePreciosxConsulta(ByRef pAdmin As VzAdmin.cAdmin, ByVal pCriterio As String) As ArrayList
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lArray As New ArrayList
        Dim lLista As cListaPrecios = Nothing

        Try
            lDt = Dat_GetListaDePredcioxConsulta(pAdmin, pCriterio)

            If lDt.Rows.Count > 0 Then
                For Each lDr In lDt.Rows
                    lLista = New cListaPrecios(pAdmin)
                    lLista.subCargarDatos(lDr)
                    lArray.Add(lLista)
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cListaPrecios.GetListasDePreciosxConsulta")
            pAdmin.Log.fncGrabarLogERR("Error en cListaPrecios.GetListasDePreciosxConsulta:" & ex.Message)
        End Try

        Return lArray

    End Function

#End Region

#Region "Base de Datos"

    Private Shared Function Dat_GetListaDePredcioxIdLista(ByRef pAdmin As VzAdmin.cAdmin, ByVal pIdLista As Integer) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "SELECT * FROM  pro_rel_lista WHERE Id_CodLista =#pCodigo#"
            Sql = Sql.Replace("#pCodigo#", pIdLista)


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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cListaPrecios.Dat_GetListaDePredcioxIdLista")
            pAdmin.Log.fncGrabarLogERR("Error en cListaPrecios.Dat_GetListaDePredcioxIdLista:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Shared Function Dat_GetListaDePredcioxConsulta(ByRef pAdmin As VzAdmin.cAdmin, ByVal pCriterio As String) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "Select * From pro_listaprecio Where Descripcion Like '%#pCriterio#%' OR Id_CodLista like '%#pCriterio#%'  order by Codlista"
            Sql = Sql.Replace("#pCriterio#", pCriterio)

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cListaPrecios.Dat_GetListaDePredcioxIdLista")
            pAdmin.Log.fncGrabarLogERR("Error en cListaPrecios.Dat_GetListaDePredcioxIdLista:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Shared Function Dat_GetListaDePrecioGetAll(ByRef pAdmin As VzAdmin.cAdmin) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "SELECT * FROM  pro_listaprecio  order by Codlista"

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cListaPrecios.Dat_GetListaDePrecioGetAll")
            pAdmin.Log.fncGrabarLogERR("Error en cListaPrecios.Dat_GetListaDePrecioGetAll:" & ex.Message)
            Return Nothing
        End Try
    End Function

#End Region

End Class
