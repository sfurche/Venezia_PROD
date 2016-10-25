Imports MySql.Data.MySqlClient
Imports VzAdmin

Public Class cSetting

    Private _Id_Setting As Integer
    Private _Cod_Setting As String
    Private _Tipo_Dato As cFunciones.TipoDato
    Private _Valor As String
    Private _Observaciones As String

    Private gAdmin As VzAdmin.cAdmin

#Region "Propiedades"

    Public Property Id_Setting As Integer
        Get
            Return _Id_Setting
        End Get
        Set(value As Integer)
            _Id_Setting = value
        End Set
    End Property

    Public Property Tipo_Dato As cFunciones.TipoDato
        Get
            Return _Tipo_Dato
        End Get
        Set(value As cFunciones.TipoDato)
            _Tipo_Dato = value
        End Set
    End Property

    Public Property Valor As String
        Get
            Return _Valor
        End Get
        Set(value As String)
            _Valor = value
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

    Public Property Cod_Setting As String
        Get
            Return _Cod_Setting
        End Get
        Set(value As String)
            _Cod_Setting = value
        End Set
    End Property

#End Region

#Region "Funciones"

    Public Sub New()

    End Sub

    Public Sub New(ByRef pAdmin As VzAdmin.cAdmin)
        gAdmin = pAdmin
    End Sub

    Public Shared Function Load_Setting(ByRef pAdmin As cAdmin, ByVal lDr As DataRow) As cSetting

        Dim lSetting As cSetting = Nothing

        Try
            lSetting = New cSetting(pAdmin)
            With lSetting
                .Id_Setting = lDr("id_setting")
                .Cod_Setting = lDr("cod_setting")
                .Tipo_Dato = lDr("tipo_dato")
                .Valor = lDr("valor")
                .Observaciones = lDr("observaciones")
            End With

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cSetting.Load_Deudor")
            pAdmin.Log.fncGrabarLogERR("Error en cSetting.Load_Setting:" & ex.Message)
        End Try

        Return lSetting

    End Function

    Public Sub Guardar()
        Try

            '''''  FALTA DESARROLLAR

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cSetting.Guardar")
            gAdmin.Log.fncGrabarLogERR("Error en cSetting.Guardar:" & ex.Message)
        End Try

    End Sub

    Public Shared Function GetSettingxCodigo(ByRef pAdmin As VzAdmin.cAdmin, ByVal pCodSetting As String) As cSetting
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lSetting As cSetting = Nothing

        Try
            lDt = Dat_GetSettingxCod(pAdmin, pCodSetting)

            If lDt.Rows.Count > 0 Then

                For Each lDr In lDt.Rows
                    lSetting = Load_Setting(pAdmin, lDr)
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cSetting.GetSettingxCodigo")
            pAdmin.Log.fncGrabarLogERR("Error en cSetting.GetSettingxCodigo:" & ex.Message)
        End Try

        Return lsetting

    End Function

    Public Shared Function GetAllSettings(ByRef pAdmin As VzAdmin.cAdmin) As ArrayList
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lSetting As cSetting = Nothing
        Dim lArray As ArrayList = Nothing

        Try
            lDt = Dat_GetAllSettings(pAdmin)

            If lDt.Rows.Count > 0 Then
                lArray = New ArrayList
                For Each lDr In lDt.Rows
                    lSetting = Load_Setting(pAdmin, lDr)
                    lArray.Add(lSetting)
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cSetting.GetAllSettings")
            pAdmin.Log.fncGrabarLogERR("Error en cSetting.GetAllSettings:" & ex.Message)
        End Try

        Return lArray
    End Function

    Public Function GetColeccionParametros() As ArrayList
        Dim lArray As ArrayList = Nothing
        Try
            Dim separator As String() = {";"c, Environment.NewLine}
            Dim querys As String() = Me.Valor.Split(separator, StringSplitOptions.RemoveEmptyEntries)


            For Each query As String In querys
                lArray.Add(query)
            Next


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cSetting.GetColeccionParametros")
            gAdmin.Log.fncGrabarLogERR("Error en cSetting.GetColeccionParametros:" & ex.Message)
        End Try

        Return lArray
    End Function

#End Region

#Region "Base de Datos"

    Private Shared Function Dat_GetSettingxCod(ByRef pAdmin As VzAdmin.cAdmin, ByVal pCodSetting As String) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "Select * from vz_settings where cod_setting='#pCodSetting#'"
            Sql = Sql.Replace("#pCodSetting#", pCodSetting)


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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cSetting.Dat_GetEstadoxIDTipo")
            pAdmin.Log.fncGrabarLogERR("Error en cSetting.Dat_GetEstadoxIDTipo:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Shared Function Dat_GetAllSettings(ByRef pAdmin As VzAdmin.cAdmin) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "Select * from vz_settings order by cod_setting"

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cSetting.Dat_GetAllSettings")
            pAdmin.Log.fncGrabarLogERR("Error en cSetting.Dat_GetAllSettings:" & ex.Message)
            Return Nothing
        End Try
    End Function

#End Region



End Class
