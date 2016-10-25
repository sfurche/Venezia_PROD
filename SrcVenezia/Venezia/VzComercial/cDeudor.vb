Imports MySql.Data.MySqlClient
Imports VzAdmin
Imports VzComercial

Public Class cDeudor


#Region "Propiedades"

    Private gAdmin As cAdmin

    Private _Id_Deudores As Integer
    Private _Formulario As cFormulario 'CodForm
    Private _CompSuc As String
    Private _CompNro As String
    Private _FecEmi As Date
    Private _FecVto As Date
    Private _CodZona As cVendedor
    Private _Cliente As cCliente ' NroCli
    Private _Id_Fac As Integer
    Private _Descripcion As String
    Private _IngImpoEfvo As Decimal
    Private _IngImpoCheque As Decimal
    Private _ImpoTransf As Decimal
    Private _IngDescTransf As String
    Private _IngRetIVA As Decimal
    Private _IngRetGanancias As Decimal
    Private _IngSUSS As Decimal
    Private _IngRetIIBB As Decimal
    Private _IngRedondeo As Decimal
    Private _TotalComp As Decimal
    Private _DeduccionesComp As Decimal
    Private _SaldoComp As Decimal
    Private _ObservComp As String
    Private _MarcaAnulado As enuBinario
    Private _Aplica As String
    Private _IdUsr As Integer
    Private _FecOp As Date
    Private _HoraOP As TimeSpan
    Private _Aplicacion As String  'Determina en la conciliacion si fue aplicacion TOTAL o PARCIAL.


    Public Property Id_Deudores As Integer
        Get
            Return _Id_Deudores
        End Get
        Set(value As Integer)
            _Id_Deudores = value
        End Set
    End Property

    Public Property Formulario As cFormulario
        Get
            Return _Formulario
        End Get
        Set(value As cFormulario)
            _Formulario = value
        End Set
    End Property

    Public Property CompSuc As String
        Get
            Return _CompSuc
        End Get
        Set(value As String)
            _CompSuc = value
        End Set
    End Property

    Public Property CompNro As String
        Get
            Return _CompNro
        End Get
        Set(value As String)
            _CompNro = value
        End Set
    End Property

    Public Property FecEmi As Date
        Get
            Return _FecEmi
        End Get
        Set(value As Date)
            _FecEmi = value
        End Set
    End Property

    Public Property FecVto As Date
        Get
            Return _FecVto
        End Get
        Set(value As Date)
            _FecVto = value
        End Set
    End Property

    Public Property CodZona As cVendedor
        Get
            Return _CodZona
        End Get
        Set(value As cVendedor)
            _CodZona = value
        End Set
    End Property

    Public Property Cliente As cCliente
        Get
            Return _Cliente
        End Get
        Set(value As cCliente)
            _Cliente = value
        End Set
    End Property

    Public Property Id_Fac As Integer
        Get
            Return _Id_Fac
        End Get
        Set(value As Integer)
            _Id_Fac = value
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

    Public Property IngImpoEfvo As Decimal
        Get
            Return _IngImpoEfvo
        End Get
        Set(value As Decimal)
            _IngImpoEfvo = value
        End Set
    End Property

    Public Property IngImpoCheque As Decimal
        Get
            Return _IngImpoCheque
        End Get
        Set(value As Decimal)
            _IngImpoCheque = value
        End Set
    End Property

    Public Property ImpoTransf As Decimal
        Get
            Return _ImpoTransf
        End Get
        Set(value As Decimal)
            _ImpoTransf = value
        End Set
    End Property

    Public Property IngDescTransf As String
        Get
            Return _IngDescTransf
        End Get
        Set(value As String)
            _IngDescTransf = value
        End Set
    End Property

    Public Property IngRetIVA As Decimal
        Get
            Return _IngRetIVA
        End Get
        Set(value As Decimal)
            _IngRetIVA = value
        End Set
    End Property

    Public Property IngRetGanancias As Decimal
        Get
            Return _IngRetGanancias
        End Get
        Set(value As Decimal)
            _IngRetGanancias = value
        End Set
    End Property

    Public Property IngSUSS As Decimal
        Get
            Return _IngSUSS
        End Get
        Set(value As Decimal)
            _IngSUSS = value
        End Set
    End Property

    Public Property IngRetIIBB As Decimal
        Get
            Return _IngRetIIBB
        End Get
        Set(value As Decimal)
            _IngRetIIBB = value
        End Set
    End Property

    Public Property IngRedondeo As Decimal
        Get
            Return _IngRedondeo
        End Get
        Set(value As Decimal)
            _IngRedondeo = value
        End Set
    End Property

    Public Property TotalComp As Decimal
        Get
            Return _TotalComp
        End Get
        Set(value As Decimal)
            _TotalComp = value
        End Set
    End Property

    Public Property DeduccionesComp As Decimal
        Get
            Return _DeduccionesComp
        End Get
        Set(value As Decimal)
            _DeduccionesComp = value
        End Set
    End Property

    Public Property SaldoComp As Decimal
        Get
            Return _SaldoComp
        End Get
        Set(value As Decimal)
            _SaldoComp = value
        End Set
    End Property

    Public Property ObservComp As String
        Get
            Return _ObservComp
        End Get
        Set(value As String)
            _ObservComp = value
        End Set
    End Property

    Public Property MarcaAnulado As enuBinario
        Get
            Return _MarcaAnulado
        End Get
        Set(value As enuBinario)
            _MarcaAnulado = value
        End Set
    End Property

    Public Property Aplica As String
        Get
            Return _Aplica
        End Get
        Set(value As String)
            _Aplica = value
        End Set
    End Property

    Public Property IdUsr As Integer
        Get
            Return _IdUsr
        End Get
        Set(value As Integer)
            _IdUsr = value
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

    Public Property HoraOP As TimeSpan
        Get
            Return _HoraOP
        End Get
        Set(value As TimeSpan)
            _HoraOP = value
        End Set
    End Property

    Public Property Aplicacion As String
        Get
            Return _Aplicacion
        End Get
        Set(value As String)
            _Aplicacion = value
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

    Public Shared Function Load_Deudor(ByRef pAdmin As cAdmin, ByVal lDr As DataRow) As cDeudor

        Dim lDeudor As cDeudor = Nothing

        Try
            lDeudor = New cDeudor(pAdmin)
            With lDeudor
                .Id_Deudores = lDr("Id_Deudores")
                .Formulario = cFormulario.GetFormularioxCod(pAdmin, lDr("CodForm"))
                .CompSuc = lDr("CompSuc")
                .CompNro = lDr("CompNro")
                .FecEmi = lDr("FecEmi")
                .FecVto = lDr("FecVto")
                .CodZona = cVendedor.GetVendedorexId(pAdmin, lDr("CodZona"))
                .Cliente = cCliente.GetClientexNroCliente(pAdmin, lDr("NroCli"))
                .Id_Fac = lDr("Id_Fac")
                .Descripcion = lDr("Descripcion")
                .IngImpoEfvo = lDr("IngImpoEfvo")
                .IngImpoCheque = lDr("IngImpoCheque")
                .ImpoTransf = lDr("ImpoTransf")
                .IngDescTransf = lDr("IngDescTransf")
                .IngRetIVA = lDr("IngRetIVA")
                .IngRetGanancias = lDr("IngRetGanancias")
                .IngSUSS = lDr("IngSUSS")
                .IngRetIIBB = lDr("IngRetIIBB")
                .IngRedondeo = lDr("IngRedondeo")
                .TotalComp = lDr("TotalComp")
                .DeduccionesComp = lDr("DeduccionesComp")
                .SaldoComp = lDr("SaldoComp")
                .ObservComp = lDr("ObservComp")
                .MarcaAnulado = EnuBinarioGetEnu(lDr("MarcaAnulado"))
                .Aplica = lDr("Aplica")
                .IdUsr = lDr("IdUsr")
                .FecOp = lDr("FecOp")
                .HoraOP = lDr("HoraOP")
                .Aplicacion = "T"
            End With

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cDeudor.Load_Deudor")
            pAdmin.Log.fncGrabarLogERR("Error en cDeudor.Load_Deudor:" & ex.Message)
        End Try

        Return lDeudor

    End Function

    Public Shared Function GetDeudoresxIdDeudor(ByRef pAdmin As VzAdmin.cAdmin, ByVal pId_Deudores As Integer) As cDeudor
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lDeudor As cDeudor = Nothing

        Try
            lDt = Dat_GetDeudorxIdDeudor(pAdmin, pId_Deudores)

            If lDt.Rows.Count > 0 Then

                For Each lDr In lDt.Rows
                    lDeudor = Load_Deudor(pAdmin, lDr)
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cDeudor.GetDeudoresxIdDeudor")
            pAdmin.Log.fncGrabarLogERR("Error en cDeudor.GetDeudoresxIdDeudor:" & ex.Message)
        End Try

        Return lDeudor

    End Function

    Public Shared Function GetRecibosxIdLiquidacion(ByRef pAdmin As VzAdmin.cAdmin, ByVal pId_Liquidacion As Integer) As ArrayList
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lArray As ArrayList = Nothing
        Dim lDeudor As cDeudor = Nothing

        Try
            lDt = Dat_GetRecibosxIdLiquidacion(pAdmin, pId_Liquidacion)

            If lDt.Rows.Count > 0 Then

                For Each lDr In lDt.Rows
                    lArray = New ArrayList
                    lDeudor = Load_Deudor(pAdmin, lDr)
                    lArray.Add(lDeudor)
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cDeudor.GetDeudoresxIdLiquidacion")
            pAdmin.Log.fncGrabarLogERR("Error en cDeudor.GetDeudoresxIdLiquidacion:" & ex.Message)
        End Try

        Return lArray

    End Function

    Public Shared Function GetRecibosxConciliar(ByRef pAdmin As VzAdmin.cAdmin) As ArrayList
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lArray As ArrayList = Nothing
        Dim lDeudor As cDeudor = Nothing

        Try
            lDt = Dat_GetRecibosxConciliar(pAdmin)

            If lDt.Rows.Count > 0 Then

                lArray = New ArrayList

                For Each lDr In lDt.Rows
                    lDeudor = Load_Deudor(pAdmin, lDr)
                    lArray.Add(lDeudor)
                Next

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cDeudor.GetDeudoresxConciliar")
            pAdmin.Log.fncGrabarLogERR("Error en cDeudor.GetDeudoresxConciliar:" & ex.Message)
        End Try

        Return lArray

    End Function

    Public Shared Function GetRecibosxConciliarxVen(ByRef pAdmin As VzAdmin.cAdmin, ByVal pIdVen As Integer, ByVal pAllVen As Boolean, ByVal pRecHist As Boolean) As ArrayList
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lArray As ArrayList = Nothing
        Dim lDeudor As cDeudor = Nothing

        Try
            lDt = Dat_GetRecibosxConciliarxVen(pAdmin, pIdVen, pAllVen, pRecHist)

            If lDt.Rows.Count > 0 Then

                lArray = New ArrayList
                For Each lDr In lDt.Rows
                    lDeudor = Load_Deudor(pAdmin, lDr)
                    lArray.Add(lDeudor)
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cDeudor.GetDeudoresxConciliar")
            pAdmin.Log.fncGrabarLogERR("Error en cDeudor.GetDeudoresxConciliar:" & ex.Message)
        End Try

        Return lArray

    End Function

#End Region

#Region "Base de Datos"

    Private Shared Function Dat_GetDeudorxIdDeudor(ByRef pAdmin As VzAdmin.cAdmin, ByVal pIdDeudor As Integer) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "SELECT * FROM ven_deudores where Id_Deudores= #pIdDeudor# "
            Sql = Sql.Replace("#pIdDeudor#", pIdDeudor)


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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cDeudor.Dat_GetDeudorxIdDeudor")
            pAdmin.Log.fncGrabarLogERR("Error en cDeudor.Dat_GetDeudorxIdDeudor:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Shared Function Dat_GetRecibosxIdLiquidacion(ByRef pAdmin As VzAdmin.cAdmin, ByVal pIdLiquidacion As Integer) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "SELECT * FROM ven_deudores where Id_Deudores In (Select Id_Deudores from vz_liquidaciones_Conciliacion Where  Id_Liquidacion = #pIdLiquidacion# and id_estado = 0 and Id_Deudores is not null)"
            Sql = Sql.Replace("#pIdLiquidacion#", pIdLiquidacion)


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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cDeudor.Dat_GetRecibosxIdLiquidacion")
            pAdmin.Log.fncGrabarLogERR("Error en cDeudor.Dat_GetRecibosxIdLiquidacion:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Shared Function Dat_GetRecibosxConciliar(ByRef pAdmin As VzAdmin.cAdmin) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "Select * from ven_deudores Where CodForm = '0104' and FecOp = CurDate() "
            Sql = Sql & "And Id_Deudores Not In (Select Id_Deudores from vz_liquidaciones_Conciliacion Where fecha  = CurDate() And id_estado = 0 and Id_Deudores is not null)"

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cDeudor.Dat_GetDeudorxConciliar")
            pAdmin.Log.fncGrabarLogERR("Error en cDeudor.Dat_GetDeudorxConciliar:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Shared Function Dat_GetRecibosxConciliarxVen(ByRef pAdmin As VzAdmin.cAdmin, ByVal pVen As Integer, ByVal pAllVen As Boolean, ByVal pRecHist As Boolean) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "Select * from ven_deudores Where (CodForm = '0104' or CodForm = '0154' or CodForm = '0103') "
            If pRecHist = False Then
                Sql = Sql & "and FecOp = CurDate()"
            Else
                Sql = Sql & "and FecOp >= '2016/08/01'" 'Fecha que empezamos a conciliar liquidaciones.
            End If

            If pAllVen = False Then
                Sql = Sql & " and CodZona= #pVen# "
                Sql = Sql.Replace("#pVen#", pVen)
            End If

            ' Sql = Sql & "And Id_Deudores Not In (Select Id_Deudores from vz_liquidaciones_Conciliacion Where fecha  = CurDate() And id_estado = 0 and Id_Deudores is not null)"
            Sql = Sql & "And Id_Deudores Not In (Select Id_Deudores from vz_liquidaciones_Conciliacion Where id_estado = 0 and Id_Deudores is not null and aplicacion='T')"

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cDeudor.Dat_GetRecibosxConciliarxVen")
            pAdmin.Log.fncGrabarLogERR("Error en cDeudor.Dat_GetRecibosxConciliarxVen:" & ex.Message)
            Return Nothing
        End Try
    End Function

#End Region

End Class
