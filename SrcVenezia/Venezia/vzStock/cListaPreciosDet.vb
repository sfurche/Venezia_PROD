Imports VzAdmin
Imports MySql.Data.MySqlClient
Imports vzStock

Public Class cListaPreciosDet

#Region "Propiedades"
    Private gAdmin As VzAdmin.cAdmin

    Private _idDetalleLista As Integer
    Private _IdLista As Integer
    Private _CodLista As Integer
    Private _Articulo As cArticulo
    Private _CodProd As String
    Private _PcioUnitario As Double
    Private _pcioCaja As Double
    Private _PorComision As Double
    Private _Nuevo As Boolean = True

    Public Property IdDetalleLista As Integer
        Get
            Return _idDetalleLista
        End Get
        Set(value As Integer)
            _idDetalleLista = value
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

    Public Property Nuevo As Boolean
        Get
            Return _Nuevo
        End Get
        Set(value As Boolean)
            _Nuevo = value
        End Set
    End Property


#End Region

#Region "Funciones"

    Public Sub New(ByRef pAdmin As cAdmin)
        Me.gAdmin = pAdmin
    End Sub

    Private Sub subCargarDatos(ByVal lDr As DataRow)
        Try

            IdDetalleLista = lDr("idDetalleLista")
            IdLista = lDr("id_CodLista")
            CodLista = lDr("CodLista")
            Articulo = cArticulo.GetArticuloxCod(gAdmin, lDr("CodArt"))
            CodProd = cFunciones.gFncgetDbValue(lDr("CodProd"), cFunciones.TipoDato.TEXTO)
            PcioUnitario = cFunciones.gFncgetDbValue(lDr("PcioUnit"), cFunciones.TipoDato.NUMERO)
            PcioCaja = cFunciones.gFncgetDbValue(lDr("PcioCaja"), cFunciones.TipoDato.NUMERO)
            PorComision = cFunciones.gFncgetDbValue(lDr("PorComis"), cFunciones.TipoDato.NUMERO)
            Me.Nuevo = False

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cListaPreciosDet.subCargarDatos")
            gAdmin.Log.fncGrabarLogERR("Error en cListaPreciosDet.subCargarDatos:" & ex.Message)
        End Try

    End Sub

    Public Function Guardar() As Boolean
        Guardar = False

        Try
            If Me.Nuevo = True Then
                Guardar = Dat_ListaDePredcioDet_INS(Me.IdLista, Me.CodLista, Me.Articulo.CodArt, PcioUnitario, Me.PorComision)
            Else
                Guardar = Dat_ListaDePredcioDet_UPD(Me.IdDetalleLista, PcioUnitario, PorComision)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cListaPreciosDet.Guardar")
            gAdmin.Log.fncGrabarLogERR("Error en cListaPreciosDet.Guardar:" & ex.Message)
        End Try
    End Function

    Public Overrides Function ToString() As String
        ToString = ""

        Try
            ToString = Me.GetType.ToString & " IdDetalleLista = " & Me.IdDetalleLista.ToString & vbCrLf
            ToString = Me.GetType.ToString & " IdLista = " & Me.IdLista & vbCrLf
            ToString = Me.GetType.ToString & " CodLista = " & Me.CodLista & vbCrLf

            If IsNothing(Me.Articulo) Then
                ToString = Me.GetType.ToString & " Articulo = null" & vbCrLf
            Else
                ToString = Me.GetType.ToString & " Articulo = " & Me.Articulo.ToString & vbCrLf
            End If

            ToString = Me.GetType.ToString & " CodProd = " & Me.CodProd.ToString & vbCrLf
            ToString = Me.GetType.ToString & " PcioUnitario = " & Me.PcioUnitario.ToString("C") & vbCrLf
            ToString = Me.GetType.ToString & " PcioCaja = " & Me.PcioCaja.ToString("C") & vbCrLf
            ToString = Me.GetType.ToString & " PorComision = " & Me.PorComision.ToString & vbCrLf
            ToString = Me.GetType.ToString & " Nuevo = " & Me.Nuevo.ToString & vbCrLf

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cListaPreciosDet.ToString")
            gAdmin.Log.fncGrabarLogERR("Error en cListaPreciosDet.ToString" & ex.Message)
        End Try
    End Function

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

    Public Shared Function GetListaPreciosDetxListaxArt(ByRef pAdmin As VzAdmin.cAdmin, ByVal pCodLista As Integer, ByVal pCodArt As Integer) As cListaPreciosDet
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lPrecio As cListaPreciosDet = Nothing

        Try
            lDt = Dat_GetListaDePredcioDetxIdListaxCodArt(pAdmin, pCodLista, pCodArt)

            If lDt.Rows.Count > 0 Then

                For Each lDr In lDt.Rows
                    lPrecio = New cListaPreciosDet(pAdmin)
                    lPrecio.subCargarDatos(lDr)
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cListaPreciosDet.GetListaPreciosDetxIdDet")
            pAdmin.Log.fncGrabarLogERR("Error en cListaPreciosDet.GetListaPreciosDetxIdDet:" & ex.Message)
        End Try

        Return lPrecio
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

    Private Shared Function Dat_GetListaDePredcioDetxIdListaxCodArt(ByRef pAdmin As VzAdmin.cAdmin, ByVal pIdLista As Integer, ByVal pCodArt As Integer) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon

            Sql = "SELECT * FROM pro_detlista WHERE CodArt = #pCodArt# AND id_CodLista = #pCodLista#"
            Sql = Sql.Replace("#pCodArt#", pCodArt)
            Sql = Sql.Replace("#pCodLista#", pIdLista)

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cListaPreciosDet.Dat_GetListaDePredcioDetxIdListaxCodArt")
            pAdmin.Log.fncGrabarLogERR("Error en cListaPreciosDet.Dat_GetListaDePredcioDetxIdListaxCodArt:" & ex.Message)
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

    Private Function Dat_ListaDePredcioDet_INS(ByVal pid_CodLista As Integer, ByVal pCodLista As Integer, ByVal pCodArt As Integer, ByVal pPcioUnit As Double, ByVal pPorComis As Double) As Boolean

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lCnn As MySqlConnection

        Try
            Dat_ListaDePredcioDet_INS = False

            lCnn = gAdmin.DbCnn.GetInstanceCon
            Sql = "CALL vz_ListaPreciosDet_ins(#id_CodLista#,#CodLista#,#CodArt#,#PcioUnit#,#PcioCaja#,#PorComis#,#idusr#)"
            Sql = Sql.Replace("#id_CodLista#", pid_CodLista)
            Sql = Sql.Replace("#CodLista#", pCodLista)
            Sql = Sql.Replace("#CodArt#", pCodArt)
            Sql = Sql.Replace("#PcioUnit#", pPcioUnit)
            Sql = Sql.Replace("#PcioCaja#", 0)
            Sql = Sql.Replace("#PorComis#", pPorComis)
            Sql = Sql.Replace("#idusr#", gAdmin.User.Id)

            With Cmd
                .Connection = lCnn
                .CommandType = CommandType.Text
                .CommandText = Sql

                If lCnn.State = ConnectionState.Closed Then
                    lCnn.Open()
                End If
                Cmd.ExecuteNonQuery()
                lCnn.Close()
            End With

            Dat_ListaDePredcioDet_INS = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cListaPreciosDet.Dat_ListaDePredcioDet_INS")
            gAdmin.Log.fncGrabarLogERR("Error en cListaPreciosDet.Dat_ListaDePredcioDet_INS:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Function Dat_ListaDePredcioDet_UPD(ByVal pidDetalleLista As Integer, ByVal pPcioUnit As Double, ByVal pPorComis As Double) As Boolean

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lCnn As MySqlConnection

        Try
            Dat_ListaDePredcioDet_UPD = False

            lCnn = gAdmin.DbCnn.GetInstanceCon
            Sql = "CALL vz_ListaPreciosDet_upd(#idDetalleLista#,#PcioUnit#,#idusr#)"
            Sql = Sql.Replace("#idDetalleLista#", pidDetalleLista)
            Sql = Sql.Replace("#PcioUnit#", pPcioUnit)
            Sql = Sql.Replace("#idusr#", gAdmin.User.Id)

            With Cmd
                .Connection = lCnn
                .CommandType = CommandType.Text
                .CommandText = Sql

                If lCnn.State = ConnectionState.Closed Then
                    lCnn.Open()
                End If
                Cmd.ExecuteNonQuery()
                lCnn.Close()
            End With

            Dat_ListaDePredcioDet_UPD = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cListaPreciosDet.Dat_ListaDePredcioDet_UPD")
            gAdmin.Log.fncGrabarLogERR("Error en cListaPreciosDet.Dat_ListaDePredcioDet_UPD:" & ex.Message)
            Return Nothing
        End Try
    End Function

#End Region

End Class

