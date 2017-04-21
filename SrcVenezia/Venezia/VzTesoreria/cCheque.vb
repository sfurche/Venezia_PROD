Imports VzTesoreria
Imports MySql.Data.MySqlClient
Imports VzAdmin
Imports VzAdmin.cEnums
Imports VzComercial

<Serializable()> Public Class cCheque

#Region "Declaraciones"

    Private gAdmin As VzAdmin.cAdmin
    Private _id_Cheque As Integer
    Private _id_Liquidacion As Integer
    Private _Propio As enuBinario
    Private _Banco As cBanco
    Private _Numero As String
    Private _Directo As enuBinario
    Private _Cruzado As enuBinario
    Private _Orden As enuBinario
    Private _Fecha_Pago As Date
    Private _Fecha_Vencimiento As Date
    'Private _Fecha_Liquidacion As Date
    'Private _Tipo_Liquidacion As enuTipoLiqCheque = enuTipoLiqCheque.Pendiente
    Private _Importe As Double
    Private _NroCli As String
    Private _Obaservaciones As String
    Private _Estado As cEstado
    Private _EsNuevo As Boolean = True
    Private _Id_Orden As Integer  'Orden de Pago.

#Region "EnuBinario"

    'Public Enum enuBinario
    '    Si = 1
    '    No = 2
    '    Null = 0
    'End Enum

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

    '#Region "enuTipoLiqCheque"

    '    Public Enum enuTipoLiqCheque
    '        Pendiente = 0
    '        Cobrado = 1
    '        Depositado = 2
    '        Transferido = 3
    '        Rechazado = 4
    '        Null = 99

    '    End Enum

    '    Public Shared Function enuTipoLiqChequeGetCod(ByVal pTipoValor As enuBinario) As String
    '        Select Case pTipoValor
    '            Case enuTipoLiqCheque.Pendiente
    '                Return "P"
    '            Case enuTipoLiqCheque.Cobrado
    '                Return "C"
    '            Case enuTipoLiqCheque.Depositado
    '                Return "D"
    '            Case enuTipoLiqCheque.Transferido
    '                Return "T"
    '            Case enuTipoLiqCheque.Rechazado
    '                Return "R"
    '            Case Else
    '                Return "P"
    '        End Select
    '    End Function

    '    Public Shared Function enuTipoLiqChequeGetEnu(ByVal pTipoValor As String) As enuTipoLiqCheque
    '        Select Case pTipoValor
    '            Case "P"
    '                Return enuTipoLiqCheque.Pendiente
    '            Case "C"
    '                Return enuTipoLiqCheque.Cobrado
    '            Case "D"
    '                Return enuTipoLiqCheque.Depositado
    '            Case "T"
    '                Return enuTipoLiqCheque.Transferido
    '            Case "R"
    '                Return enuTipoLiqCheque.Rechazado
    '            Case Else
    '                Return enuTipoLiqCheque.Pendiente
    '        End Select
    '    End Function

    '#End Region

    '-----------------------------------------------------------------------------------

    Public Property Id_Cheque As Integer
        Get
            Return _id_Cheque
        End Get
        Set(value As Integer)
            _id_Cheque = value
        End Set
    End Property

    Public Property Propio As enuBinario
        Get
            Return _Propio
        End Get
        Set(value As enuBinario)
            _Propio = value
        End Set
    End Property

    Public Property Banco As cBanco
        Get
            Return _Banco
        End Get
        Set(value As cBanco)
            _Banco = value
        End Set
    End Property

    Public Property Numero As String
        Get
            Return _Numero
        End Get
        Set(value As String)
            _Numero = value
        End Set
    End Property

    Public Property Directo As enuBinario
        Get
            Return _Directo
        End Get
        Set(value As enuBinario)
            _Directo = value
        End Set
    End Property

    Public Property Cruzado As enuBinario
        Get
            Return _Cruzado
        End Get
        Set(value As enuBinario)
            _Cruzado = value
        End Set
    End Property

    Public Property Fecha_Pago As Date
        Get
            Return _Fecha_Pago
        End Get
        Set(value As Date)
            _Fecha_Pago = value
            _Fecha_Vencimiento = DateAdd(DateInterval.Day, 30, value)

        End Set
    End Property

    Public Property Fecha_Vencimiento As Date
        Get
            Return _Fecha_Vencimiento
        End Get
        Set(value As Date)
            _Fecha_Vencimiento = value
        End Set
    End Property

    'Public Property Fecha_Liquidacion As Date
    '    Get
    '        Return _Fecha_Liquidacion
    '    End Get
    '    Set(value As Date)
    '        _Fecha_Liquidacion = value
    '    End Set
    'End Property

    'Public Property Tipo_Liquidacion As enuTipoLiqCheque
    '    Get
    '        Return _Tipo_Liquidacion
    '    End Get
    '    Set(value As enuTipoLiqCheque)
    '        _Tipo_Liquidacion = value
    '    End Set
    'End Property

    Public Property Importe As Double
        Get
            Return _Importe
        End Get
        Set(value As Double)
            _Importe = value
        End Set
    End Property

    Public Property Obaservaciones As String
        Get
            Return _Obaservaciones
        End Get
        Set(value As String)
            _Obaservaciones = value
        End Set
    End Property

    Public Property Estado As cEstado
        Get
            Return _Estado
        End Get
        Set(value As cEstado)
            _Estado = value
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

    Public Property Id_Liquidacion As Integer
        Get
            Return _id_Liquidacion
        End Get
        Set(value As Integer)
            _id_Liquidacion = value
        End Set
    End Property

    Public Property NroCli As String
        Get
            Return _NroCli
        End Get
        Set(value As String)
            _NroCli = value
        End Set
    End Property

    Public Property Orden As enuBinario
        Get
            Return _Orden
        End Get
        Set(value As enuBinario)
            _Orden = value
        End Set
    End Property

    Public Property Id_Orden As Integer
        Get
            Return _Id_Orden
        End Get
        Set(value As Integer)
            _Id_Orden = value
        End Set
    End Property

#End Region

#Region "Funciones"

    Public Sub New()

    End Sub

    Public Sub New(ByRef pAdmin As VzAdmin.cAdmin)
        gAdmin = pAdmin
    End Sub

    Private Sub subCargarDatos(ByVal lDr As DataRow)
        Try
            _Propio = EnuBinarioGetEnu(lDr("propio"))
            _id_Liquidacion = cFunciones.gFncgetDbValue(lDr("id_liquidacion"), cFunciones.TipoDato.NUMERO)
            _Banco = cBanco.Banco_BusqxId(gAdmin, lDr("id_bco"))
            _id_Cheque = lDr("id_cheque")
            _Numero = lDr("numero")
            _Directo = EnuBinarioGetEnu(lDr("directo"))
            _Cruzado = EnuBinarioGetEnu(lDr("cruzado"))
            _Orden = EnuBinarioGetEnu(lDr("orden"))
            _Fecha_Pago = cFunciones.gFncgetDbValue(lDr("fecha_pago"), cFunciones.TipoDato.FECHA)
            _Fecha_Vencimiento = cFunciones.gFncgetDbValue(lDr("fecha_vencimiento"), cFunciones.TipoDato.FECHA)
            '_Fecha_Liquidacion = cFunciones.gFncgetDbValue(lDr("fecha_liquidacion"), cFunciones.TipoDato.FECHA)
            '_Tipo_Liquidacion = enuTipoLiqChequeGetEnu(cFunciones.gFncgetDbValue(lDr("tipo_liquidacion"), cFunciones.TipoDato.TEXTO))
            _Importe = lDr("importe")
            _NroCli = cFunciones.gFncgetDbValue(lDr("NroCli"), cFunciones.TipoDato.TEXTO)
            _Obaservaciones = cFunciones.gFncgetDbValue(lDr("observaciones"), cFunciones.TipoDato.TEXTO)
            _Estado = cEstado.GetEstadoxIdTipoEstado(gAdmin, lDr("id_estado"), cEstado.enuTipoEstado.Cheque)
            _Id_Orden = cFunciones.gFncgetDbValue(lDr("id_orden"), cFunciones.TipoDato.NUMERO)
            _EsNuevo = False

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCheque.subCargarDatos")
            gAdmin.Log.fncGrabarLogERR("Error en cCheque.subCargarDatos:" & ex.Message)
        End Try

    End Sub

    Public Function Guardar() As Boolean
        Guardar = False
        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lCnn As MySqlConnection
        Dim lDt As DataTable

        Try
            lCnn = Me.gAdmin.DbCnn.GetInstanceCon

            If Me.EsNuevo = True Then
                lCnn = gAdmin.DbCnn.GetInstanceCon

                Sql = "CALL vz_cheques_ins ('#IdPropio#',#IdLiquidacion#, #IdBco#,'#numero#','#directo#', '#cruzado#', '#orden#',  '#fecha_pago#','#fecha_vencimiento#', #importe#,'#NroCli#','#observac#',#idusr#)"
                Sql = Sql.Replace("#IdPropio#", EnuBinarioGetCod(Me.Propio))
                Sql = Sql.Replace("#IdLiquidacion#", (Me.Id_Liquidacion))
                Sql = Sql.Replace("#IdBco#", Me.Banco.Id_Banco)
                Sql = Sql.Replace("#numero#", Me.Numero)
                Sql = Sql.Replace("#directo#", EnuBinarioGetCod(Me.Directo))
                Sql = Sql.Replace("#cruzado#", EnuBinarioGetCod(Me.Cruzado))
                Sql = Sql.Replace("#orden#", EnuBinarioGetCod(Me.Orden))
                Sql = Sql.Replace("#fecha_pago#", VzAdmin.cFunciones.gFncConvertDateToString(Me.Fecha_Pago, "YYYY/MM/DD"))
                Sql = Sql.Replace("#fecha_vencimiento#", VzAdmin.cFunciones.gFncConvertDateToString(Me.Fecha_Vencimiento, "YYYY/MM/DD"))
                'Sql = Sql.Replace("#fecha_liquidacion#", VzAdmin.cFunciones.gFncConvertDateToString(Me.Fecha_Liquidacion, "YYYY/MM/DD"))
                'Sql = Sql.Replace("#tipo_liquidacion#", enuTipoLiqChequeGetCod(Me.Tipo_Liquidacion))
                Sql = Sql.Replace("#importe#", Me.Importe)
                Sql = Sql.Replace("#NroCli#", Me.NroCli.Trim)
                Sql = Sql.Replace("#observac#", Me.Obaservaciones.Trim)
                Sql = Sql.Replace("#idusr#", gAdmin.User.Id)

                Cmd.Connection = lCnn
                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = Sql

                If lCnn.State = ConnectionState.Closed Then
                    lCnn.Open()
                End If

                Dim lDa As New MySqlDataAdapter(Cmd)
                lDt = New DataTable
                lDa.Fill(lDt)
                lCnn.Close()

                Me.EsNuevo = False
                Me.Id_Cheque = lDt(0)(0)

            Else   'ACA DEBERIA IR EL UPDATE

                lCnn = gAdmin.DbCnn.GetInstanceCon
                'Sql = "CALL vz_cheques_upd (#Id_Cheque#, '#IdPropio#',#IdLiquidacion#, #IdBco#,'#numero#','#directo#', '#cruzado#', '#orden#','#fecha_pago#','#fecha_vencimiento#','#fecha_liquidacion#','#tipo_liquidacion#', #importe#,'#NroCli#', '#observac#', #Id_Estado#, #idusr#)"
                Sql = "CALL vz_cheques_upd (#Id_Cheque#, '#IdPropio#',#IdLiquidacion#, #IdBco#,'#numero#','#directo#', '#cruzado#', '#orden#','#fecha_pago#','#fecha_vencimiento#', #importe#,'#NroCli#', '#observac#', #Id_Estado#, #idusr#)"
                Sql = Sql.Replace("#Id_Cheque#", Me.Id_Cheque)
                Sql = Sql.Replace("#IdPropio#", EnuBinarioGetCod(Me.Propio))
                Sql = Sql.Replace("#IdLiquidacion#", (Me.Id_Liquidacion))
                Sql = Sql.Replace("#IdBco#", Me.Banco.Id_Banco)
                Sql = Sql.Replace("#numero#", Me.Numero)
                Sql = Sql.Replace("#directo#", EnuBinarioGetCod(Me.Directo))
                Sql = Sql.Replace("#cruzado#", EnuBinarioGetCod(Me.Cruzado))
                Sql = Sql.Replace("#orden#", EnuBinarioGetCod(Me.Orden))
                Sql = Sql.Replace("#fecha_pago#", VzAdmin.cFunciones.gFncConvertDateToString(Me._Fecha_Pago, "YYYY/MM/DD"))
                Sql = Sql.Replace("#fecha_vencimiento#", VzAdmin.cFunciones.gFncConvertDateToString(Me.Fecha_Vencimiento, "YYYY/MM/DD"))
                Sql = Sql.Replace("#importe#", Me.Importe)
                Sql = Sql.Replace("#NroCli#", Me.NroCli.Trim)
                Sql = Sql.Replace("#observac#", Me.Obaservaciones.Trim)
                Sql = Sql.Replace("#Id_Estado#", Me.Estado.Id_Estado)
                Sql = Sql.Replace("#idusr#", gAdmin.User.Id)

                'If Not (Me.Tipo_Liquidacion = VzTesoreria.cCheque.enuTipoLiqCheque.Null) Then
                'Sql = Sql.Replace("#fecha_liquidacion#", VzAdmin.cFunciones.gFncConvertDateToString(Me.Fecha_Liquidacion, "YYYY/MM/DD"))
                'Sql = Sql.Replace("#tipo_liquidacion#", enuTipoLiqChequeGetCod(Me.Tipo_Liquidacion))
                'Else
                '    Sql = Sql.Replace("#fecha_liquidacion#", "null")
                '    Sql = Sql.Replace("#tipo_liquidacion#", "null")
                'End If


                Cmd.Connection = lCnn
                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = Sql

                If lCnn.State = ConnectionState.Closed Then
                    lCnn.Open()
                End If

                Cmd.ExecuteNonQuery()
                lCnn.Close()

                Me.EsNuevo = False

            End If

            Guardar = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCheque.Guardar")
            gAdmin.Log.fncGrabarLogERR("Error en cCheque.Guardar:" & ex.Message)
        End Try
    End Function

    Public Function Anular() As Boolean
        Anular = False
        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lCnn As MySqlConnection
        Dim lDt As DataTable = Nothing

        Try
            If Not Me.Estado.Id_Estado = 0 Then 'En Cartera
                MsgBox("El cheque no se puede anular por estar en estado '" & Me.Estado.Estado & "'", MsgBoxStyle.Exclamation)
                Anular = False
                Exit Function
            End If

            lCnn = Me.gAdmin.DbCnn.GetInstanceCon

            '99 ES ESTADO ANULADO
            Me.Estado = cEstado.GetEstadoxIdTipoEstado(gAdmin, 99, cEstado.enuTipoEstado.Cheque)

            If Me.EsNuevo = False Then
                lCnn = gAdmin.DbCnn.GetInstanceCon

                Sql = "CALL vz_cheques_cambest ('#id_cheque#',#id_estado#, #idusr#)"
                Sql = Sql.Replace("#id_cheque#", Me.Id_Cheque)
                Sql = Sql.Replace("#id_estado#", Me.Estado.Id_Estado)
                Sql = Sql.Replace("#idusr#", gAdmin.User.Id)

                Cmd.Connection = lCnn
                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = Sql

                If lCnn.State = ConnectionState.Closed Then
                    lCnn.Open()
                End If

                Cmd.ExecuteNonQuery()
                lCnn.Close()

            End If

            Anular = True


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCheque.Anular")
            gAdmin.Log.fncGrabarLogERR("Error en cCheque.Anular:" & ex.Message)
        End Try
    End Function

    Private Sub ChkRechazadonMailing()
        Dim lMail As New cEmail(gAdmin)
        Dim lHtml As String = ""
        Dim lCliente As cCliente = Nothing
        Dim lSetting As cSetting = Nothing
        Dim lOp As cOrdenDePago = Nothing
        Try
            lSetting = cSetting.GetSettingxCodigo(gAdmin, "Mailing_ChkRechazado")
            lMail.Tipo_Mailing = "Cheque Rechazado"
            lMail.Fecha = Date.Today
            lMail.Html = True
            lMail.Para = lSetting.Valor.ToString.Trim
            lMail.Asunto = "Nuevo Cheque Rechazado (Nro." & Me.Numero.ToString & " - " & Me.Banco.NombreRed.Trim & ")"


            'Armo el HTML con los valores para reemplazar:
            '--------------------------------------------
            lHtml = "<HTML><H1>Notificacion Automatica de Cheque Rechazado <HR> </H1>"
            lHtml = lHtml & "<BODY> <BIG>Se acaba de registrar un nuevo cheque rechazado. A continuacion los datos del mismo: </BIG> <P>"
            lHtml = lHtml & "<B> Banco: </B> #Banco_Nombre# <BR>"
            lHtml = lHtml & "<B> Numero: </B> #Cheque_Numero# <BR>"
            lHtml = lHtml & "<B> Importe: </B> #Cheque_Importe# <BR>"
            lHtml = lHtml & "<B> Origen del Cheque:</B>  #Cheque_Origen# #Cheque_Cliente_Nombre# <BR>"
            lHtml = lHtml & "<B> Orden de Pago Nro:</B>  #OrdenPago_Numero# <BR>"
            lHtml = lHtml & "<B> Destino del Cheque: </B> #OrdenPago_Destino# #OrdenPago_Proveedor_Nombre# <BR>"
            lHtml = lHtml & "</BODY></HTML>"


            'Ahora solo reemplazo los valores en el HTML
            '-------------------------------------------

            lHtml = lHtml.Replace("#Banco_Nombre#", Me.Banco.NombreRed.Trim)
            lHtml = lHtml.Replace("#Cheque_Numero#", Me.Numero)
            lHtml = lHtml.Replace("#Cheque_Importe#", Me.Importe.ToString)


            If Me.Propio = enuBinario.No Then
                lCliente = cCliente.GetClientexNroCliente(gAdmin, Me.NroCli)
                lHtml = lHtml.Replace("#Cheque_Origen#", "Terceros ")
                lHtml = lHtml.Replace("#Cheque_Cliente_Nombre#", "(" & lCliente.Nombre & ")")
            Else
                lHtml = lHtml.Replace("#Cheque_Origen#", " Propio")
                lHtml = lHtml.Replace("#Cheque_Cliente_Nombre#", "")
            End If


            lOp = cOrdenDePago.GetOrdenDePagoxId(gAdmin, Me.Id_Orden)
            lHtml = lHtml.Replace("#OrdenPago_Numero#", lOp.Id_Orden.ToString)
            If lOp.Tipo_Destino = cOrdenDePago.enuTipoDestinoOrdenPago.Proveedores Then
                lHtml = lHtml.Replace("#OrdenPago_Destino#", "Proveedor ")
                lHtml = lHtml.Replace("#OrdenPago_Proveedor_Nombre#", "(" & lOp.Proveedor.Nombre & ")")
            Else
                lHtml = lHtml.Replace("#OrdenPago_Destino#", "Cobro/Deposito ")
                lHtml = lHtml.Replace("#OrdenPago_Proveedor_Nombre#", "")
            End If

            lMail.Body = lHtml
            lMail.Guardar()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCheque.ChkRechazadonMailing")
            gAdmin.Log.fncGrabarLogERR("Error en cCheque.ChkRechazadonMailing:" & ex.Message)
        End Try
    End Sub

    Public Function Rechazar() As Boolean
        Rechazar = False
        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lCnn As MySqlConnection
        Dim lDt As DataTable = Nothing

        Try
            If Not Me.Estado.Id_Estado = 1 Then 'Liquidado
                MsgBox("El cheque no se puede anular por estar en estado '" & Me.Estado.Estado & "'", MsgBoxStyle.Exclamation)
                Rechazar = False
                Exit Function
            End If

            lCnn = Me.gAdmin.DbCnn.GetInstanceCon

            '2 ES ESTADO RECHAZADO PENDIENTE DE GESTION
            Me.Estado = cEstado.GetEstadoxIdTipoEstado(gAdmin, 2, cEstado.enuTipoEstado.Cheque)

            If Me.EsNuevo = False Then
                lCnn = gAdmin.DbCnn.GetInstanceCon

                Sql = "CALL vz_cheques_cambest ('#id_cheque#',#id_estado#, #idusr#)"
                Sql = Sql.Replace("#id_cheque#", Me.Id_Cheque)
                Sql = Sql.Replace("#id_estado#", Me.Estado.Id_Estado)
                Sql = Sql.Replace("#idusr#", gAdmin.User.Id)

                Cmd.Connection = lCnn
                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = Sql

                If lCnn.State = ConnectionState.Closed Then
                    lCnn.Open()
                End If

                Cmd.ExecuteNonQuery()
                lCnn.Close()

                ChkRechazadonMailing()
            End If

            Rechazar = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCheque.Rechazar")
            gAdmin.Log.fncGrabarLogERR("Error en cCheque.Rechazar:" & ex.Message)
        End Try
    End Function

    Public Function Recuperar() As Boolean
        Recuperar = False
        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lCnn As MySqlConnection
        Dim lDt As DataTable = Nothing
        Dim lArrayConcil As ArrayList = Nothing
        Dim lDeudor As cDeudor = Nothing

        Try
            If Not Me.Estado.Id_Estado = 2 Then 'Rechazado Pte
                MsgBox("El cheque no se puede recuperar por estar en estado '" & Me.Estado.Estado & "'", MsgBoxStyle.Exclamation)
                Recuperar = False
                Exit Function
            End If

            'Valido si hay hay alguna conciliacion asociada al cheque rechazado. Si no hay, no le dejo cambiar el estado.
            lArrayConcil = cConciliacionLiq.GetDeudoresxIdCheque(gAdmin, Me.Id_Cheque)
            If IsNothing(lArrayConcil) Then
                Recuperar = False
                MsgBox("No se encontraron liquidaciones Asociadas a este cheque. Revise las conciliaciones.", MsgBoxStyle.Critical, "Error al Recuperar")
                Exit Function
            Else
                If lArrayConcil.Count = 0 Then
                    Recuperar = False
                    MsgBox("No se encontraron liquidaciones Asociadas a este cheque. Revise las conciliaciones.", MsgBoxStyle.Critical, "Error al Recuperar")
                    Exit Function
                End If
            End If

            lCnn = Me.gAdmin.DbCnn.GetInstanceCon

            '3 ES ESTADO RECHAZADO LIQUIDADO / RECUPERADO
            Me.Estado = cEstado.GetEstadoxIdTipoEstado(gAdmin, 3, cEstado.enuTipoEstado.Cheque)

            If Me.EsNuevo = False Then
                lCnn = gAdmin.DbCnn.GetInstanceCon

                Sql = "CALL vz_cheques_cambest ('#id_cheque#',#id_estado#, #idusr#)"
                Sql = Sql.Replace("#id_cheque#", Me.Id_Cheque)
                Sql = Sql.Replace("#id_estado#", Me.Estado.Id_Estado)
                Sql = Sql.Replace("#idusr#", gAdmin.User.Id)

                Cmd.Connection = lCnn
                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = Sql

                If lCnn.State = ConnectionState.Closed Then
                    lCnn.Open()
                End If

                Cmd.ExecuteNonQuery()
                lCnn.Close()

            End If

            Recuperar = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCheque.Recuperar")
            gAdmin.Log.fncGrabarLogERR("Error en cCheque.Recuperar:" & ex.Message)
        End Try
    End Function


#End Region

#Region "Shared Functions"

    Public Shared Function SetOrdenDePago(ByRef pAdmin As cAdmin, ByVal pArrayCheques As ArrayList, ByVal pNroOrden As Integer) As Boolean
        SetOrdenDePago = False
        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lCnn As MySqlConnection = Nothing
        Dim lDt As DataTable = Nothing
        Dim lCheque As cCheque = Nothing
        'Dim lTransac As MySqlTransaction = Nothing

        Try

            If IsNothing(pArrayCheques) Then
                Return True
            End If

            lCnn = pAdmin.DbCnn.GetInstanceCon
            'If lCnn.State = ConnectionState.Closed Then
            '    lCnn.Open()
            'End If
            'lTransac = lCnn.BeginTransaction(1)
            Cmd.Connection = lCnn
            Cmd.CommandType = CommandType.Text

            'Primero blanqueo las ordenes de todos los cheuqes asociados a la orden de pago.
            Sql = "UPDATE vz_cheques set id_orden = null ,  id_estado = 0  WHERE id_orden  = #id_orden# ;"
            Sql = Sql.Replace("#id_orden#", pNroOrden)

            'lTransac.Commit()

            'lTransac = lCnn.BeginTransaction(2)
            For Each lCheque In pArrayCheques

                Sql = "UPDATE vz_cheques set id_orden = #id_orden# , id_estado = 1 WHERE id_cheque = #id_cheque# ;"
                Sql = Sql.Replace("#id_cheque#", lCheque.Id_Cheque)
                Sql = Sql.Replace("#id_orden#", pNroOrden)

                Cmd.CommandText = Sql

                If lCnn.State = ConnectionState.Closed Then
                    lCnn.Open()
                End If
                Cmd.ExecuteNonQuery()
            Next

            'lTransac.Commit()

            lCnn.Close()
            SetOrdenDePago = True

        Catch ex As Exception
            'lTransac.Rollback()

            If Not IsNothing(lCnn) Then
                lCnn.Close()
            End If
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCheque.SetOrdenDePago")
            pAdmin.Log.fncGrabarLogERR("Error en cCheque.SetOrdenDePago:" & ex.Message)
        End Try
    End Function

    Public Shared Function GetChequesAll(ByRef pAdmin As VzAdmin.cAdmin) As ArrayList
        Dim lDt As DataTable
        Dim lArray As ArrayList = Nothing
        Dim lDr As DataRow
        Dim lChq As cCheque

        Try
            lDt = Dat_GetChequesAll(pAdmin)

            If lDt.Rows.Count > 0 Then

                lArray = New ArrayList

                For Each lDr In lDt.Rows
                    lChq = New cCheque(pAdmin)
                    lChq.subCargarDatos(lDr)
                    lArray.Add(lChq)
                Next

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCheque.GetChequesAll")
            pAdmin.Log.fncGrabarLogERR("Error en cCheque.GetChequesAll:" & ex.Message)
            Return Nothing
        End Try

        Return lArray

    End Function

    Public Shared Function GetChequesxFecEmisionDH(ByRef pAdmin As VzAdmin.cAdmin, ByVal pFecD As Date, ByVal pFecH As Date) As ArrayList
        Dim lDt As DataTable
        Dim lArray As New ArrayList
        Dim lDr As DataRow
        Dim lChq As cCheque

        Try
            lDt = Dat_GetChequesxFecEmisionDH(pAdmin, pFecD, pFecH)

            If lDt.Rows.Count > 0 Then

                For Each lDr In lDt.Rows
                    lChq = New cCheque(pAdmin)
                    lChq.subCargarDatos(lDr)
                    lArray.Add(lChq)
                Next

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCheque.GetChequesxFecEmisionDH")
            pAdmin.Log.fncGrabarLogERR("Error en cCheque.GetChequesxFecEmisionDH:" & ex.Message)
        End Try

        Return lArray

    End Function

    Public Shared Function GetChequesxFecVtoDH(ByRef pAdmin As VzAdmin.cAdmin, ByVal pFecD As Date, ByVal pFecH As Date) As ArrayList
        Dim lDt As DataTable
        Dim lArray As New ArrayList
        Dim lDr As DataRow
        Dim lChq As cCheque

        Try
            lDt = Dat_GetChequesxFecVtoDH(pAdmin, pFecD, pFecH)

            If lDt.Rows.Count > 0 Then

                For Each lDr In lDt.Rows
                    lChq = New cCheque(pAdmin)
                    lChq.subCargarDatos(lDr)
                    lArray.Add(lChq)
                Next

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCheque.GetChequesxFecVtoDH")
            pAdmin.Log.fncGrabarLogERR("Error en cCheque.GetChequesxFecVtoDH:" & ex.Message)
        End Try

        Return lArray

    End Function

    Public Shared Function GetChequesxIdLiq(ByRef pAdmin As VzAdmin.cAdmin, ByVal pId As Integer) As ArrayList
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lChq As cCheque = Nothing
        Dim lArray As ArrayList = Nothing

        Try
            lDt = Dat_GetChequesxIdLiq(pAdmin, pId)

            If lDt.Rows.Count > 0 Then
                lArray = New ArrayList

                For Each lDr In lDt.Rows

                    lChq = New cCheque(pAdmin)
                    lChq.subCargarDatos(lDr)
                    lArray.Add(lChq)
                Next

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCheque.GetChequesxIdLiq")
            pAdmin.Log.fncGrabarLogERR("Error en cCheque.GetChequesxIdLiq:" & ex.Message)
        End Try

        Return lArray

    End Function

    Public Shared Function GetChequesxEstado(ByRef pAdmin As VzAdmin.cAdmin, ByVal pId_Estado As Integer) As ArrayList
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lChq As cCheque = Nothing
        Dim lArray As ArrayList = Nothing

        Try
            lDt = Dat_GetChequesxEstado(pAdmin, pId_Estado)

            If lDt.Rows.Count > 0 Then
                lArray = New ArrayList

                For Each lDr In lDt.Rows

                    lChq = New cCheque(pAdmin)
                    lChq.subCargarDatos(lDr)
                    lArray.Add(lChq)
                Next

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCheque.GetChequesxEstado")
            pAdmin.Log.fncGrabarLogERR("Error en cCheque.GetChequesxEstado:" & ex.Message)
        End Try

        Return lArray

    End Function

    Public Shared Function GetChequesxOrdenDePago(ByRef pAdmin As VzAdmin.cAdmin, ByVal pOP As Integer) As ArrayList
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lChq As cCheque = Nothing
        Dim lArray As New ArrayList

        Try
            lDt = Dat_GetChequesxOrdenDePago(pAdmin, pOP)

            If lDt.Rows.Count > 0 Then

                For Each lDr In lDt.Rows

                    lChq = New cCheque(pAdmin)
                    lChq.subCargarDatos(lDr)
                    lArray.Add(lChq)
                Next

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCheque.GetChequesxOrdenDePago")
            pAdmin.Log.fncGrabarLogERR("Error en cCheque.GetChequesxOrdenDePago:" & ex.Message)
        End Try

        Return lArray

    End Function

    Public Shared Function GetChequesConsulta(ByRef pAdmin As VzAdmin.cAdmin, ByVal pnro_cheque As String, ByVal p_propio As String, ByVal p_fecha_PagoD As Date, ByVal p_fecha_PagoH As Date,
            ByVal p_id_estado As Integer, ByVal p_id_banco As Integer, ByVal p_directo As String, ByVal p_orden As String,
            ByVal p_cruzado As String, ByVal p_NroCli As String) As ArrayList

        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lChq As cCheque = Nothing
        Dim lArray As ArrayList = Nothing

        Try
            lDt = Dat_GetChequesConsulta(pAdmin, pnro_cheque, p_propio, p_fecha_PagoD, p_fecha_PagoH, p_id_estado, p_id_banco, p_directo, p_orden, p_cruzado, p_NroCli)

            If lDt.Rows.Count > 0 Then
                lArray = New ArrayList

                For Each lDr In lDt.Rows
                    lChq = New cCheque(pAdmin)
                    lChq.subCargarDatos(lDr)
                    lArray.Add(lChq)
                Next

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCheque.GetChequesConsulta")
            pAdmin.Log.fncGrabarLogERR("Error en cCheque.GetChequesConsulta:" & ex.Message)
        End Try

        Return lArray

    End Function

    Public Shared Function GetChequesxID(ByRef pAdmin As VzAdmin.cAdmin, ByVal pIdCheque As Integer) As cCheque
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lChq As cCheque = Nothing

        Try
            lDt = Dat_GetChequesxID(pAdmin, pIdCheque)

            If lDt.Rows.Count > 0 Then

                For Each lDr In lDt.Rows
                    lChq = New cCheque(pAdmin)
                    lChq.subCargarDatos(lDr)
                Next

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCheque.GetChequesxId")
            pAdmin.Log.fncGrabarLogERR("Error en cCheque.GetChequesxId:" & ex.Message)
            lChq = Nothing
        End Try

        Return lChq

    End Function



#End Region

#Region "Base de Datos"

    Private Shared Function Dat_GetChequesxID(ByRef pAdmin As VzAdmin.cAdmin, ByVal pIdChq As String) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "Select * from vz_cheques where id_cheque=#Id#"
            Sql = Sql.Replace("#Id#", pIdChq)

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCheque.Dat_GeChequesxID")
            pAdmin.Log.fncGrabarLogERR("Error en cCheque.Dat_GetLiquidacionxID:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Shared Function Dat_GetChequesxIdLiq(ByRef pAdmin As VzAdmin.cAdmin, ByVal pIdLiq As String) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "Select * from vz_cheques where id_liquidacion=#Id# and not id_estado=99"
            Sql = Sql.Replace("#Id#", pIdLiq)

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCheque.Dat_GetChequesxIdLiq")
            pAdmin.Log.fncGrabarLogERR("Error en cCheque.Dat_GetChequesxIdLiq:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Shared Function Dat_GetChequesxOrdenDePago(ByRef pAdmin As VzAdmin.cAdmin, ByVal pIdOrden As String) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "Select * from vz_cheques where id_orden=#Id#"
            Sql = Sql.Replace("#Id#", pIdOrden)

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCheque.Dat_GetChequesxOrdenDePago")
            pAdmin.Log.fncGrabarLogERR("Error en cCheque.Dat_GetChequesxOrdenDePago:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Shared Function Dat_GetChequesAll(ByRef pAdmin As VzAdmin.cAdmin) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "Select * from vz_cheques"

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCheque.Dat_GetChequesAll")
            pAdmin.Log.fncGrabarLogERR("Error en cCheque.Dat_GetChequesAll:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Shared Function Dat_GetChequesxFecEmisionDH(ByRef pAdmin As VzAdmin.cAdmin, ByVal pFecD As Date, ByVal pFecH As Date) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon

            Sql = "select * from vz_cheques where where fecha_emision >= '#fecd#' and fecha_emision <= '#fech#' and not id_estado=99"

            Sql = Sql.Replace("#fecd#", VzAdmin.cFunciones.gFncConvertDateToString(pFecD, "YYYY/MM/DD"))
            Sql = Sql.Replace("#fech#", VzAdmin.cFunciones.gFncConvertDateToString(pFecH, "YYYY/MM/DD"))

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCheque.Dat_GetChequesxFecEmisionDH")
            pAdmin.Log.fncGrabarLogERR("Error en cCheque.Dat_GetChequesxFecEmisionDH:  " & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Shared Function Dat_GetChequesxFecVtoDH(ByRef pAdmin As VzAdmin.cAdmin, ByVal pFecD As Date, ByVal pFecH As Date) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon

            Sql = "Select * from vz_cheques where where fecha_vencimiento >= '#fecd#' and fecha_vencimiento <= '#fech#' and not id_estado=99"

            Sql = Sql.Replace("#fecd#", VzAdmin.cFunciones.gFncConvertDateToString(pFecD, "YYYY/MM/DD"))
            Sql = Sql.Replace("#fech#", VzAdmin.cFunciones.gFncConvertDateToString(pFecH, "YYYY/MM/DD"))

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCheque.Dat_GetChequesxFecVtoDH")
            pAdmin.Log.fncGrabarLogERR("Error en cCheque.Dat_GetChequesxFecVtoDH:  " & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Function Dat_RptChequesFDFHEstado(ByRef pAdmin As VzAdmin.cAdmin, ByVal pPropio As String, ByVal pFpagoD As Date, ByVal pFpagoH As Date, ByVal pFVtoD As Date, ByVal pFVtoH As Date, ByVal pEstado As Integer) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon

            Sql = "  SELECT  "
            Sql = Sql & "id_cheque , id_liquidacion , propio , B.nomb_bco_red banco , numero , directo , cruzado ,	orden, fecha_pago, fecha_vencimiento , importe , observaciones ,  E.estado "
            Sql = Sql & "From vz_cheques As C, sis_bancos As B, vz_estados E "
            Sql = Sql & "Where C.id_bco = B.id_bco "
            Sql = Sql & "And C.id_estado = E.id_estado "
            Sql = Sql & " And E.tabla = 'vz_cheques' "
            Sql = Sql & "And fecha_pago >= '#fed#' "
            Sql = Sql & " And Fecha_Pago <= '#feh#' "
            Sql = Sql & "And fecha_vencimiento >= '#fvtod#' "
            Sql = Sql & "And Fecha_Vencimiento <= '#fvtoh#' "
            Sql = Sql & "And C.id_estado= #estado# "
            Sql = Sql & "And C.propio = '#propio#' "
            Sql = Sql & "ORDER BY fecha_pago asc ; "


            Sql = Sql.Replace("#propio#", pPropio)
            Sql = Sql.Replace("#fed#", VzAdmin.cFunciones.gFncConvertDateToString(pFpagoD, "YYYY/MM/DD"))
            Sql = Sql.Replace("#feh#", VzAdmin.cFunciones.gFncConvertDateToString(pFpagoH, "YYYY/MM/DD"))
            Sql = Sql.Replace("#fvtod#", VzAdmin.cFunciones.gFncConvertDateToString(pFVtoD, "YYYY/MM/DD"))
            Sql = Sql.Replace("#fvtoh#", VzAdmin.cFunciones.gFncConvertDateToString(pFVtoH, "YYYY/MM/DD"))
            Sql = Sql.Replace("#estado#", pEstado.ToString)

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCheque.Dat_RptChequesFDFHEstado")
            pAdmin.Log.fncGrabarLogERR("Error en cCheque.Dat_RptChequesFDFHEstado:  " & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Function Dat_RptChequesxDestProvFOrP(ByRef pAdmin As VzAdmin.cAdmin, ByVal pFOpDesde As Date, ByVal pFOpHasta As Date, ByVal pIdProve As Integer) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            '  Call vz_cheques_ChkxDestProvFOrP('2016/01/01','2017/01/01',3);
            Sql = "Call vz_cheques_ChkxDestProvFOrP('#fed#','#feh#',#pIdProve#);"

            Sql = Sql.Replace("#fed#", VzAdmin.cFunciones.gFncConvertDateToString(pFOpDesde, "YYYY/MM/DD"))
            Sql = Sql.Replace("#feh#", VzAdmin.cFunciones.gFncConvertDateToString(pFOpHasta, "YYYY/MM/DD"))
            Sql = Sql.Replace("#pIdProve#", pIdProve.ToString)

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCheque.Dat_RptChequesFDFHEstado")
            pAdmin.Log.fncGrabarLogERR("Error en cCheque.Dat_RptChequesFDFHEstado:  " & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Enum Dat_RptChequesxArrayCheques_CAMPOS
        NroCheque = 1
        Importe = 2
        Fec_Pago = 3
        Banco = 4
        Cruzado = 5
        Directo = 6
        Orden = 7
        Vto = 8
        Estado = 9
        Cliente = 10
        OrdenP = 11
    End Enum

    Public Shared Function Dat_RptChequesxArrayCheques(ByRef pAdmin As VzAdmin.cAdmin, ByVal pArrayCheques As ArrayList, ByVal pCampoOrden As Dat_RptChequesxArrayCheques_CAMPOS, ByVal pAsc As Boolean) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection
        Dim lCheque As cCheque = Nothing
        Dim lLista As String = ""
        Dim lCont As Integer = 0

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon

            Sql = "   Select DISTINCT id_cheque , id_liquidacion ,propio ,B.nomb_bco_red banco,numero ,directo ,cruzado ,orden,fecha_pago, fecha_vencimiento ,"
            Sql = Sql & " importe ,observaciones ,E.estado"
            Sql = Sql & " FROM vz_cheques As C "
            Sql = Sql & " LEFT JOIN sis_bancos As B On  C.id_bco = B.id_bco"
            Sql = Sql & " LEFT JOIN vz_estados E On C.id_estado = E.id_estado"
            Sql = Sql & " WHERE C.id_cheque In (#arraycheques#)"
            Sql = Sql & " And E.tabla = 'vz_cheques' ORDER BY "


            Select Case pCampoOrden
                Case Dat_RptChequesxArrayCheques_CAMPOS.Banco
                    Sql = Sql & "id_banco" & IIf(pAsc = True, " ASC", " DESC")
                Case Dat_RptChequesxArrayCheques_CAMPOS.Cliente
                    Sql = Sql & "NroCli" & IIf(pAsc = True, " ASC", " DESC")
                Case Dat_RptChequesxArrayCheques_CAMPOS.Cruzado
                    Sql = Sql & "cruzado" & IIf(pAsc = True, " ASC", " DESC")
                Case Dat_RptChequesxArrayCheques_CAMPOS.Directo
                    Sql = Sql & "directo" & IIf(pAsc = True, " ASC", " DESC")
                Case Dat_RptChequesxArrayCheques_CAMPOS.Estado
                    Sql = Sql & "id_estado" & IIf(pAsc = True, " ASC", " DESC")
                Case Dat_RptChequesxArrayCheques_CAMPOS.Fec_Pago
                    Sql = Sql & "fecha_pago" & IIf(pAsc = True, " ASC", " DESC")
                Case Dat_RptChequesxArrayCheques_CAMPOS.Importe
                    Sql = Sql & "importe" & IIf(pAsc = True, " ASC", " DESC")
                Case Dat_RptChequesxArrayCheques_CAMPOS.NroCheque
                    Sql = Sql & "numero" & IIf(pAsc = True, " ASC", " DESC")
                Case Dat_RptChequesxArrayCheques_CAMPOS.Orden
                    Sql = Sql & "orden" & IIf(pAsc = True, " ASC", " DESC")
                Case Dat_RptChequesxArrayCheques_CAMPOS.OrdenP
                    Sql = Sql & "id_orden" & IIf(pAsc = True, " ASC", " DESC")
                Case Dat_RptChequesxArrayCheques_CAMPOS.Vto
            End Select



            Sql = Sql & ";"

            If Not IsNothing(pArrayCheques) Then
                For Each lCheque In pArrayCheques
                    If lCont = 0 Then
                        lLista = lCheque.Id_Cheque.ToString
                    Else
                        lLista = lLista & "," & lCheque.Id_Cheque.ToString
                    End If
                    lCont = lCont + 1
                Next
            End If

            Sql = Sql.Replace("#arraycheques#", lLista)

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCheque.Dat_RptChequesxArrayCheques")
            pAdmin.Log.fncGrabarLogERR("Error en cCheque.Dat_RptChequesxArrayCheques:  " & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Shared Function Dat_GetChequesConsulta(ByRef pAdmin As VzAdmin.cAdmin, ByVal pnro_cheque As String, ByVal p_propio As String, ByVal p_fecha_PagoD As Date, ByVal p_fecha_PagoH As Date,
            ByVal p_id_estado As Integer, ByVal p_id_banco As Integer, ByVal p_directo As String, ByVal p_orden As String,
            ByVal p_cruzado As String, ByVal p_NroCli As String) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            'Sql = "  Call vz_spTesoLiqChequesConsultas(0,' ', '2015/01/01', '2018/01/01',99, 0, ' ', ' ',  ' ', ' ')"
            Sql = "Call vz_cheques_consultas('#_nro_cheque#', '#_propio#','#_fecha_PagoD#','#_fecha_PagoH#' ,#_id_estado#, #_id_banco#, '#_directo#', '#_orden#',  '#_cruzado#', '#_NroCli#')"
            Sql = Sql.Replace("#_nro_cheque#", pnro_cheque)
            Sql = Sql.Replace("#_propio#", p_propio)
            Sql = Sql.Replace("#_fecha_PagoD#", VzAdmin.cFunciones.gFncConvertDateToString(p_fecha_PagoD, "YYYY/MM/DD"))
            Sql = Sql.Replace("#_fecha_PagoH#", VzAdmin.cFunciones.gFncConvertDateToString(p_fecha_PagoH, "YYYY/MM/DD"))
            Sql = Sql.Replace("#_id_estado#", p_id_estado)
            Sql = Sql.Replace("#_id_banco#", p_id_banco)
            Sql = Sql.Replace("#_directo#", p_directo)
            Sql = Sql.Replace("#_orden#", p_orden)
            Sql = Sql.Replace("#_cruzado#", p_cruzado)
            Sql = Sql.Replace("#_NroCli#", p_NroCli)

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCheque.Dat_GetChequesConsulta")
            pAdmin.Log.fncGrabarLogERR("Error en cCheque.Dat_GetChequesConsulta:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Shared Function Dat_GetChequesxEstado(ByRef pAdmin As VzAdmin.cAdmin, ByVal pId_Estado As Integer) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "select * from vz_cheques where id_estado=#Id#"
            Sql = Sql.Replace("#Id#", pId_Estado)

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCheque.Dat_GetChequesxEstado")
            pAdmin.Log.fncGrabarLogERR("Error en cCheque.Dat_GetChequesxEstado:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Function Dat_GetCantChequesxEstado(ByRef pAdmin As VzAdmin.cAdmin, ByVal pId_Estado As Integer) As Integer

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "select count(*) from vz_cheques where id_estado = #Id# ;"
            Sql = Sql.Replace("#Id#", pId_Estado)

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

            Return lDt.Rows(0)(0)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCheque.Dat_GetCantChequesxEstado")
            pAdmin.Log.fncGrabarLogERR("Error en cCheque.Dat_GetCantChequesxEstado:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Function Dat_GetTotalChequesxEstado(ByRef pAdmin As VzAdmin.cAdmin, ByVal pId_Estado As Integer) As Double

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon

            Sql = "select round(sum(importe),2)  from vz_cheques  where id_estado = #Id# ;"

            Sql = Sql.Replace("#Id#", pId_Estado)

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

            Return lDt.Rows(0)(0)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCheque.Dat_GetTotalChequesxEstado")
            pAdmin.Log.fncGrabarLogERR("Error en cCheque.Dat_GetTotalChequesxEstado:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Function Dat_GetTotalCaidaChequesxDiasFuturo(ByRef pAdmin As VzAdmin.cAdmin, ByVal pCantDias As Integer) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            'Sql = "select DATE_FORMAT(fecha_pago, '%d/%m/%Y') Fecha_Pago, count(*) Cantidad, round(sum(importe),2) Total from vz_cheques where id_estado =0  and fecha_pago <= DATE_ADD(CURDATE(), INTERVAL #CantDias# DAY) group by fecha_pago order by fecha_pago ;"

            Sql = "SELECT 'En fecha' as FechaPago, count(*) Cantidad, round(sum(importe),2) Total "
            Sql = Sql & "FROM vz_cheques "
            Sql = Sql & "WHERE id_estado =0  and fecha_pago < CURDATE() "
            Sql = Sql & "UNION "
            Sql = Sql & "(SELECT DATE_FORMAT(fecha_pago, '%d/%m/%Y') FechaPago, count(*) Cantidad, round(sum(importe),2) "
            Sql = Sql & "Total FROM vz_cheques "
            Sql = Sql & "WHERE id_estado =0 and fecha_pago >= CURDATE() and fecha_pago <= DATE_ADD(CURDATE(), INTERVAL #CantDias# DAY) group by fecha_pago order by fecha_pago); "

            Sql = Sql.Replace("#CantDias#", pCantDias)

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCheque.Dat_GetTotalCaidaChequesxDiasFuturo")
            pAdmin.Log.fncGrabarLogERR("Error en cCheque.Dat_GetTotalCaidaChequesxDiasFuturo:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Function Dat_GetDetalleChequesxEstado(ByRef pAdmin As VzAdmin.cAdmin, ByVal pId_estado As Integer) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "select ch.id_cheque as Id,  ban.nomb_bco_red as Banco, ch.importe as Importe, cl.nombre as Origen, DATE_FORMAT(liq.fecha, '%d/%m/%Y') as Recibido from vz_cheques as ch, cl_clientes as cl, sis_bancos as ban, vz_liquidaciones as liq  where ch.id_liquidacion = liq.id_liquidacion and ch.NroCli = cl.NroCli and ch.id_bco = ban.id_bco and ch.id_estado = #id_estado#; "

            Sql = Sql.Replace("#id_estado#", pId_estado)

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCheque.Dat_GetTotalCaidaChequesxDiasFuturo")
            pAdmin.Log.fncGrabarLogERR("Error en cCheque.Dat_GetTotalCaidaChequesxDiasFuturo:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Function Dat_RptChequesRankingxCliente(ByRef pAdmin As VzAdmin.cAdmin) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "Select ch.NroCli, cl.nombre As Cliente, round(sum(ch.importe),2) As Total"
            Sql = Sql & " ,round((sum(ch.importe)*100/(Select Sum(importe) from vz_cheques where id_estado=0)),2) Porcentaje, max(fecha_pago) UltFPago"
            Sql = Sql & " From vz_cheques As ch, cl_clientes As cl"
            Sql = Sql & " Where ch.NroCli = cl.NroCli "
            Sql = Sql & " And ch.id_estado = #id_estado#"
            Sql = Sql & " group by ch.Nrocli"
            Sql = Sql & " order by Porcentaje desc;"

            'Solo cheques en cartera
            Sql = Sql.Replace("#id_estado#", 0)

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cCheque.Dat_RptChequesxRankingxCliente")
            pAdmin.Log.fncGrabarLogERR("Error en cCheque.Dat_RptChequesxRankingxCliente:" & ex.Message)
            Return Nothing
        End Try
    End Function

#End Region

End Class
