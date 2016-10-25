Imports VzAdmin
Imports MySql.Data.MySqlClient
Imports vzStock

Public Class cListaPreciosDet

#Region "Propiedades"
    Private gAdmin As VzAdmin.cAdmin

    Private idDetalleLista As Integer
    Private _IdLista As Integer
    Private _CodLista As Integer
    Private _Articulo As cArticulo
    Private _CodProd As String
    Private _PcioUnitario As Double
    Private _pcioCaja As Double
    Private _PorComision As Double

    Public Property IdDetalleLista1 As Integer
        Get
            Return idDetalleLista
        End Get
        Set(value As Integer)
            idDetalleLista = value
        End Set
    End Property

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

    Public Property Articulo As cArticulo
        Get
            Return _Articulo
        End Get
        Set(value As cArticulo)
            _Articulo = value
        End Set
    End Property

    Public Property CodProd As String
        Get
            Return _CodProd
        End Get
        Set(value As String)
            _CodProd = value
        End Set
    End Property

    Public Property PcioUnitario As Double
        Get
            Return _PcioUnitario
        End Get
        Set(value As Double)
            _PcioUnitario = value
        End Set
    End Property

    Public Property PcioCaja As Double
        Get
            Return _pcioCaja
        End Get
        Set(value As Double)
            _pcioCaja = value
        End Set
    End Property

    Public Property PorComision As Double
        Get
            Return _PorComision
        End Get
        Set(value As Double)
            _PorComision = value
        End Set
    End Property


#End Region

#Region "Funciones"

    Public Sub New(ByRef pAdmin As cAdmin)
        Me.gAdmin = pAdmin
    End Sub

    Private Sub subCargarDatos(ByVal lDr As DataRow)
        Try

            idDetalleLista = lDr("IdDetalleLista")
            IdLista = lDr("id_CodLista")
            CodLista = lDr("CodLista")
            Articulo = cArticulo.GetArticuloxCod(gAdmin, lDr("CodArt"))
            CodProd = cFunciones.gFncgetDbValue(lDr("CodProd"), cFunciones.TipoDato.TEXTO)
            PcioUnitario = cFunciones.gFncgetDbValue(lDr("PcioUnit"), cFunciones.TipoDato.NUMERO)
            PcioCaja = cFunciones.gFncgetDbValue(lDr("PcioCaja"), cFunciones.TipoDato.NUMERO)
            PorComision = cFunciones.gFncgetDbValue(lDr("PorComis"), cFunciones.TipoDato.NUMERO)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cListaPreciosDet.subCargarDatos")
            gAdmin.Log.fncGrabarLogERR("Error en cListaPreciosDet.subCargarDatos:" & ex.Message)
        End Try

    End Sub

    Public Shared Function GetListaPreciosDetxIdDet(ByRef pAdmin As VzAdmin.cAdmin, ByVal pCodListaDet As Integer) As cListaPreciosDet
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lLista As cListaPreciosDet = Nothing

        Try
            lDt = Dat_GetListaDePredcioDetxIdDet(pAdmin, pCodListaDet)

            If lDt.Rows.Count > 0 Then

                For Each lDr In lDt.Rows
                    lLista = New cListaPreciosDet(pAdmin)
                    lLista.subCargarDatos(lDr)
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cListaPreciosDet.GetListaPreciosDetxIdDet")
            pAdmin.Log.fncGrabarLogERR("Error en cListaPreciosDet.GetListaPreciosDetxIdDet:" & ex.Message)
        End Try

        Return lLista

    End Function

    Public Shared Function GetListasDePreciosDetxLP(ByRef pAdmin As VzAdmin.cAdmin, ByVal pIdLista As Integer) As ArrayList
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lArray As New ArrayList
        Dim lLista As cListaPreciosDet = Nothing

        Try
            lDt = Dat_GetListaDePredcioDetxIdLista(pAdmin, pIdLista)

            If lDt.Rows.Count > 0 Then
                'lArray = New ArrayList
                For Each lDr In lDt.Rows
                    lLista = New cListaPreciosDet(pAdmin)
                    lLista.subCargarDatos(lDr)
                    lArray.Add(lLista)
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cListaPreciosDet.GetListasDePreciosDetxLP")
            pAdmin.Log.fncGrabarLogERR("Error en cListaPreciosDet.GetListasDePreciosDetxLP:" & ex.Message)
        End Try

        Return lArray

    End Function

    Public Shared Function GetListasDePreciosDetxLP(ByRef pAdmin As VzAdmin.cAdmin, ByVal pIdLista As Integer, ByVal pDescArticulo As String) As ArrayList
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lArray As New ArrayList
        Dim lLista As cListaPreciosDet = Nothing

        Try
            lDt = Dat_GetListaDePredcioDetxIdListaxDescArt(pAdmin, pIdLista, pDescArticulo)

            If lDt.Rows.Count > 0 Then
                'lArray = New ArrayList
                For Each lDr In lDt.Rows
                    lLista = New cListaPreciosDet(pAdmin)
                    lLista.subCargarDatos(lDr)
                    lArray.Add(lLista)
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cListaPreciosDet.GetListasDePreciosDetxLP")
            pAdmin.Log.fncGrabarLogERR("Error en cListaPreciosDet.GetListasDePreciosDetxLP:" & ex.Message)
        End Try

        Return lArray

    End Function

#End Region

#Region "Base de Datos"

    Private Shared Function Dat_GetListaDePredcioDetxIdLista(ByRef pAdmin As VzAdmin.cAdmin, ByVal pIdLista As Integer) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            'Sql = "SELECT * FROM  pro_detlista WHERE id_CodLista =#pCodigo#"
            'Tuve que cambiar el script, porque en las listas de precios hay articulos que no existen en la tabla de articulos, entonces falla al armar el objeto. 
            'Esto es porque la baja de los articulos viejos es fisica.
            'Para evitar hacer una normalizacion de datos, lo que hice fue un inner join y solo traigo los precios de los articulos que existen en la tabla articulos.

            Sql = "SELECT pro_detlista.*  FROM  pro_detlista inner join pro_articulos on pro_detlista.CodArt = pro_articulos.CodArt "
            Sql = Sql & "WHERE id_CodLista =#pCodigo#"
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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cListaPreciosDet.Dat_GetListaDePredcioDetxIdLista")
            pAdmin.Log.fncGrabarLogERR("Error en cListaPreciosDet.Dat_GetListaDePredcioDetxIdLista:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Shared Function Dat_GetListaDePredcioDetxIdListaxDescArt(ByRef pAdmin As VzAdmin.cAdmin, ByVal pIdLista As Integer, ByVal pDescArt As String) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            'Sql = "SELECT d.* FROM  pro_detlista as d, pro_articulos as a "
            'Tuve que cambiar el script, porque en las listas de precios hay articulos que no existen en la tabla de articulos, entonces falla al armar el objeto. 
            'Esto es porque la baja de los articulos viejos es fisica.
            'Para evitar hacer una normalizacion de datos, lo que hice fue un inner join y solo traigo los precios de los articulos que existen en la tabla articulos.

            Sql = "SELECT pro_detlista.*  FROM  pro_detlista inner join pro_articulos on pro_detlista.CodArt = pro_articulos.CodArt "
            Sql = Sql & "WHERE pro_detlista.CodArt = pro_articulos.CodArt and id_CodLista = #pCodigo# "
            Sql = Sql & "and pro_articulos.descripcion like '%#pCriterio#%'"
            Sql = Sql.Replace("#pCodigo#", pIdLista)
            Sql = Sql.Replace("#pCriterio#", pDescArt)

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cListaPreciosDet.Dat_GetListaDePredcioDetxIdLista")
            pAdmin.Log.fncGrabarLogERR("Error en cListaPreciosDet.Dat_GetListaDePredcioDetxIdLista:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Shared Function Dat_GetListaDePredcioDetxIdDet(ByRef pAdmin As VzAdmin.cAdmin, ByVal pIdListaDet As Integer) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "SELECT * FROM  pro_detlista WHERE id_CodLista =#idDetalleLista#"
            Sql = Sql.Replace("#idDetalleLista#", pIdListaDet)


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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cListaPreciosDet.Dat_GetListaDePredcioDetxIdDet")
            pAdmin.Log.fncGrabarLogERR("Error en cListaPreciosDet.Dat_GetListaDePredcioDetxIdDet:" & ex.Message)
            Return Nothing
        End Try
    End Function

#End Region

End Class

