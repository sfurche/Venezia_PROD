Imports VzTesoreria
Imports VzComercial
Imports VzAdmin

Public Class frmTesoLiquidacionesAlta
    Inherits FrmBase

    Public mLiq As cLiquidacion
    Public mLiqBkp As String
    Dim mSettingClient As String = ""

    Private Sub frmTesoLiquidacionesAlta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            '----------------------------------P-E-R-M-I-S-O-S---------------------------------------------------
            SetPermisos()
            '---------------------------------------------------------------------------------------------------
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            Me.Tag = "ALTALIQUIDACION"
            dtpFechaLiq.Enabled = False

            SubSetCabeceraCheque()
            SubSetCabeceraTransferencias()
            subCargarBancos()
            subCargarVendedores()

            Select Case Me.TipoDeOperacion
                Case FrmBase.EnuOPERACION.MODIF
                    mLiqBkp = mLiq.ToXML
                    SubCargarDatosLiq(mLiq)
                Case FrmBase.EnuOPERACION.CONS
                    mLiqBkp = mLiq.ToXML
                    SubCargarDatosLiq(mLiq)
                Case FrmBase.EnuOPERACION.ALTA
                    mLiq = New cLiquidacion(gAdmin)
                    SubSetCabeceraCheque()
                    subCargarBancos()
                    subCargarVendedores()
                Case Else
                    Me.Close()
            End Select

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesAlta.frmTesoLiquidacionesAlta_Load")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesAlta.frmTesoLiquidacionesAlta_Load:" & ex.Message)
        End Try
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

    End Sub

    Private Sub SetPermisos()
        Dim lPermiso As cPermiso = Nothing
        Try

            lPermiso = gAdmin.User.GetPermiso("TESO_LIQ: Nueva Liquidacion")

            'Si es admin hace tiene permiso pleno.
            If lPermiso.Admin = cPermiso.enuBinario.Si Then
                Exit Sub
            End If

            If Not (lPermiso.Consulta = cPermiso.enuBinario.Si) Then
                MsgBox("No tiene permisos para acceder a esta opcion.", vbExclamation, "Acceso denegado")
                Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
            End If

            If Not (lPermiso.Alta = cPermiso.enuBinario.Si Or lPermiso.Modificacion = cPermiso.enuBinario.Si) Then
                SetReadOnly()
            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesAlta.SetPermisos")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesAlta.SetPermisos:" & ex.Message)
        End Try
    End Sub

    Public Sub SetReadOnly()
        txtCliente.ReadOnly = True
        txtImporte.ReadOnly = True
        txtNroCheque.ReadOnly = True
        txtObservac.ReadOnly = True
        txtTotalCheques.ReadOnly = True
        txtTotalEfectivo.ReadOnly = True
        txtTotalNC.ReadOnly = True
        txtTotalRet.ReadOnly = True
        txtTotalTransf.ReadOnly = True
        dtpFecEmision.Enabled = False
        dtpFechaLiq.Enabled = False
        btnAceptar.Visible = False
        btnBusq.Visible = False
        btnGuardar.Visible = False
        btnEliminarCheque.Visible = False
        cmbBanco.Enabled = False
        cmbVendedores.Enabled = False
        chkCruzado.Enabled = False
        optDirecto.Enabled = False
        optAlaOrden.Enabled = False
        optNoAlaOrden.Enabled = False
        optTerceros.Enabled = False
        chkCertificado.Enabled = False
        optAlPortador.Enabled = False

        'Inhabilito funcionalidad del panel de transferencias.
        dtpTransfFecha.Enabled = False
        btnBusqCliTransf.Enabled = False
        txtTotalTransf.ReadOnly = True
        txtTransfCli.ReadOnly = True
        btnTransfAdd.Enabled = False
        btnTransfDel.Enabled = False

    End Sub

    Public Sub SetCliente(ByVal pCliente As cCliente)
        Try
            If mSettingClient = "Cheque" Then
                lblNomCliente.Text = pCliente.Nombre
                txtCliente.Text = pCliente.NroCli
                txtCliente.Tag = pCliente
            ElseIf mSettingClient = "Transferencia" Then
                lblCliTransf.Text = pCliente.Nombre
                txtTransfCli.Text = pCliente.NroCli
                txtTransfCli.Tag = pCliente
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesAlta.SetCliente")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesAlta.SetCliente:" & ex.Message)
        End Try
    End Sub

    Private Sub subCargarBancos()
        Dim lArrayBancos As ArrayList
        Dim lBanco As cBanco = Nothing
        Try
            cmbBanco.Items.Clear()

            lArrayBancos = cBanco.Banco_GetAll(gAdmin)

            For Each lBanco In lArrayBancos
                cmbBanco.Items.Add(lBanco)
            Next
            cmbBanco.DisplayMember = "NombreComb"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesAlta.subCargarBancos")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesAlta.subCargarBancos:" & ex.Message)
        End Try
    End Sub

    Private Sub subCargarVendedores()
        Dim lArrayVend As ArrayList
        Dim lVendedor As cVendedor = Nothing
        Try
            cmbVendedores.Items.Clear()

            lArrayVend = cVendedor.GetVendedoresAll(gAdmin)

            For Each lVendedor In lArrayVend
                cmbVendedores.Items.Add(lVendedor)
            Next

            cmbVendedores.DisplayMember = "Nombre"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesAlta.subCargarVendedores")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesAlta.subCargarVendedores:" & ex.Message)
        End Try

    End Sub

    Private Sub SubSetCabeceraCheque()
        Try
            lvwConsulta.BeginUpdate()
            lvwConsulta.Clear()

            lvwConsulta.Columns.Add("NroCheque", 70, HorizontalAlignment.Center)
            lvwConsulta.Columns.Add("Importe", 70, HorizontalAlignment.Right)
            lvwConsulta.Columns.Add("Fec_Pago", 80, HorizontalAlignment.Center)
            lvwConsulta.Columns.Add("Banco", 200, HorizontalAlignment.Left)
            lvwConsulta.Columns.Add("Cruzado", 70, HorizontalAlignment.Center)
            lvwConsulta.Columns.Add("Directo", 70, HorizontalAlignment.Center)
            lvwConsulta.Columns.Add("Orden", 70, HorizontalAlignment.Center)
            lvwConsulta.Columns.Add("Vto", 80, HorizontalAlignment.Center)
            lvwConsulta.Columns.Add("Estado", 80, HorizontalAlignment.Center)
            lvwConsulta.Columns.Add("Cliente", 80, HorizontalAlignment.Center)

            lvwConsulta.EndUpdate()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesCons.SubSetCabecera")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesCons.SubSetCabecera:" & ex.Message)
        End Try
    End Sub

    Private Sub SubSetCabeceraTransferencias()
        Try
            lvwTransf.BeginUpdate()
            lvwTransf.Clear()

            lvwTransf.Columns.Add("IdTransf", 60, HorizontalAlignment.Center)
            lvwTransf.Columns.Add("Fecha", 70, HorizontalAlignment.Center)
            lvwTransf.Columns.Add("Importe", 60, HorizontalAlignment.Right)
            lvwTransf.Columns.Add("Cliente", 150, HorizontalAlignment.Left)
            lvwTransf.Columns.Add("Estado", 80, HorizontalAlignment.Center)
            lvwTransf.Columns.Add("Observ", 160, HorizontalAlignment.Center)

            lvwTransf.EndUpdate()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesCons.SubSetCabeceraTransferencias")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesCons.SubSetCabeceraTransferencias:" & ex.Message)
        End Try
    End Sub

    Private Sub subCargarTransferencias()
        Dim lItem As ListViewItem
        Dim lTransf As cTransferencia = Nothing
        Dim lSumTr As Decimal = 0
        Try

            lblTotalTransf.Text = "$ 0"
            SubSetCabeceraTransferencias()

            If Not IsNothing(mLiq.Transferencias) Then

                For Each lTransf In mLiq.Transferencias
                    lItem = New ListViewItem()
                    lItem.Text = lTransf.Id_Transferencia
                    lItem.SubItems.Add(cFunciones.gFncConvertDateToString(lTransf.Fecha, "DD/MM/YYYY"))
                    lItem.SubItems.Add(lTransf.Importe.ToString("C"))
                    lItem.SubItems.Add(cCliente.GetClientexNroCliente(gAdmin, lTransf.NroCli).Nombre.Trim)
                    lItem.SubItems.Add(lTransf.Estado.Estado)
                    lItem.SubItems.Add(lTransf.Observaciones)
                    lItem.Tag = lTransf
                    lvwTransf.Items.Add(lItem)
                    lSumTr = lSumTr + lTransf.Importe
                Next

                lblTotalTransf.Text = "$ " & lSumTr.ToString()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesCons.subCargarTransferencias")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesCons.subCargarTransferencias:" & ex.Message)
        End Try
    End Sub

    Private Sub subCargarCheques()
        Dim lItem As ListViewItem
        Dim lChk As cCheque
        Dim lLiqDet As cLiquidacion_Det
        Dim lSumChk As Decimal = 0
        Try

            lbltotalCheques.Text = "$ 0"

            SubSetCabeceraCheque()
            lLiqDet = mLiq.GetLiqDetCheques()

            If Not IsNothing(lLiqDet) Then
                If Not IsNothing(lLiqDet.Cheques) Then
                    For Each lChk In lLiqDet.Cheques
                        lItem = New ListViewItem()
                        lItem.Text = lChk.Numero
                        lItem.SubItems.Add(lChk.Importe.ToString("C"))
                        lItem.SubItems.Add(cFunciones.gFncConvertDateToString(lChk.Fecha_Pago, "DD/MM/YYYY"))
                        lItem.SubItems.Add(lChk.Banco.Nombre)
                        lItem.SubItems.Add(lChk.Cruzado.ToString)
                        lItem.SubItems.Add(lChk.Directo.ToString)
                        lItem.SubItems.Add(lChk.Orden.ToString)
                        lItem.SubItems.Add(cFunciones.gFncConvertDateToString(lChk.Fecha_Vencimiento.ToShortDateString, "DD/MM/YYYY"))
                        lItem.SubItems.Add(lChk.Estado.Estado)
                        lItem.SubItems.Add(lChk.NroCli)
                        lItem.Tag = lChk
                        lvwConsulta.Items.Add(lItem)
                        lSumChk = lSumChk + lChk.Importe
                    Next
                    lbltotalCheques.Text = "$ " & lLiqDet.GetSumCheques.ToString()
                End If
                'txtTotalCheques.Text = lLiqDet.Importe.ToString()
            End If
            Me.ActualizarTotalLiq()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesCons.subCargarCheque")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesCons.subCargarCheque:" & ex.Message)
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim lItem As ListViewItem = Nothing
        Dim lCheque As cCheque = Nothing
        Dim lLiqDet As cLiquidacion_Det
        Try
            'VALIDACIONES
            If Not IsNumeric(txtNroCheque.Text.Trim) Then
                MsgBox("El nro de cheque debe ser numerico", MsgBoxStyle.Exclamation, "Error de validacion")
                Exit Sub
            End If

            If Not IsNumeric(txtImporte.Text.Trim) Then
                MsgBox("El importe ingresado no es valido", MsgBoxStyle.Exclamation, "Error de validacion")
                Exit Sub
            End If

            If dtpFecEmision.Value < DateAdd(DateInterval.Day, -30, Date.Today()) Then
                MsgBox("No se puede ingresar un cheque vencido", MsgBoxStyle.Exclamation, "Error de validacion")
                Exit Sub
            End If

            If IsNothing(cmbBanco.SelectedItem) Then
                MsgBox("Debe seleccionar el Banco emisor del cheque", MsgBoxStyle.Exclamation, "Error de validacion")
                Exit Sub
            End If

            If IsNothing(txtCliente.Tag) Then
                MsgBox("Debe seleccionar el Cliente emisor del cheque", MsgBoxStyle.Exclamation, "Error de validacion")
                Exit Sub
            End If
            '----------------------------------------------------

            lCheque = New cCheque(gAdmin)

            lCheque.Numero = txtNroCheque.Text.Trim
            lCheque.Importe = txtImporte.Text.Trim
            lCheque.Propio = cCheque.enuBinario.No  'Como esta cargando una liquidacion, el cheque no es propio.
            lCheque.Directo = IIf(optDirecto.Checked, cCheque.enuBinario.Si, cCheque.enuBinario.No)
            lCheque.Cruzado = IIf(chkCruzado.Checked, cCheque.enuBinario.Si, cCheque.enuBinario.No)
            lCheque.Orden = IIf(optAlaOrden.Checked, cCheque.enuBinario.Si, cCheque.enuBinario.No)
            lCheque.Banco = cmbBanco.SelectedItem
            lCheque.Fecha_Pago = dtpFecEmision.Value
            lCheque.NroCli = DirectCast(txtCliente.Tag, cCliente).NroCli
            lCheque.Obaservaciones = txtObservac.Text.Trim
            lCheque.Estado = cEstado.GetEstadoxIdTipoEstado(gAdmin, 0, cEstado.enuTipoEstado.Cheque)


            '--Obtengo la liquidacion que tiene chequues
            lLiqDet = mLiq.GetLiqDetCheques()

            If IsNothing(lLiqDet) Then  '--> Valido si existe cheque

                lLiqDet = New cLiquidacion_Det(gAdmin)   '--> Creo la liquidacion detalle para guardar los cheques.
                lLiqDet.AddCheque(lCheque)  '--> Agrego el cheque al array
                mLiq.AddLiqDetalle(lLiqDet) '--> Agrego la liquidacion detalle a la liquidacion actual
            Else  '-->Si la liquidacion con cheques ya existe, solo agrego el cheque.

                lLiqDet.AddCheque(lCheque)

            End If

            subCargarCheques()

            '-Blanqueo los campos y vuelvo a posicionar para seguir cargando
            cmbBanco.SelectedItem = Nothing
            chkCruzado.Checked = False
            optDirecto.Checked = True
            optAlaOrden.Checked = True
            dtpFecEmision.Value = Date.Today()
            txtImporte.Text = String.Empty
            txtObservac.Text = String.Empty
            txtNroCheque.Text = String.Empty

            '2016/0810 Se mantiene el cliente para el siguiente cheque a pedido de JORGE LOPEZ.
            'txtCliente.Text = String.Empty
            'txtCliente.Tag = Nothing
            'lblNomCliente.Text = "Nombre Cliente"
            txtNroCheque.Focus()
            '---------------------------------

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesCons.btnGuardar_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesCons.btnGuardar_Click:" & ex.Message)
        End Try
    End Sub

    Private Sub SubCargarDatosLiq(ByVal pLiq As cLiquidacion)
        '--ESTE METODO CARGA TODOS LOS DATOS DE LA LIQUIDACION

        Try
            mLiq = pLiq
            txtTotalEfectivo.Text = mLiq.Importe_Cash
            txtTotalNC.Text = mLiq.Importe_NCredito
            txtTotalRet.Text = mLiq.Importe_Retenciones
            txtTotalTransf.Text = mLiq.Importe_Transferencias
            txtTotalCheques.Text = mLiq.Importe_Cheques
            dtpFechaLiq.Value = mLiq.Fecha
            cmbVendedores.Text = mLiq.Vendedor.Nombre
            lblTotalLiq.Text = "$" & mLiq.TotalLiq()
            lblEstado.Text = mLiq.Estado.Estado
            subCargarCheques()
            subCargarTransferencias()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesAlta.SubCargarDatosLiq")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesAlta.SubCargarDatosLiq:" & ex.Message)
        End Try

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click

        Me.Close()

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim lLiqDet As cLiquidacion_Det = Nothing
        Try

            'VALIDACIONES
            If Not IsNumeric(txtTotalEfectivo.Text.Trim) Then
                MsgBox("El nro de cheque debe ser numerico", MsgBoxStyle.Exclamation, "Error de validacion")
                Exit Sub
            End If

            If Not IsNumeric(txtTotalNC.Text.Trim) Then
                MsgBox("El importe ingresado no es valido", MsgBoxStyle.Exclamation, "Error de validacion")
                txtTotalNC.Focus()
                Exit Sub
            End If

            If Not IsNumeric(txtTotalRet.Text.Trim) Then
                MsgBox("El importe ingresado no es valido", MsgBoxStyle.Exclamation, "Error de validacion")
                txtTotalRet.Focus()
                Exit Sub
            End If

            If Not IsNumeric(txtTotalTransf.Text.Trim) Then
                MsgBox("El importe ingresado no es valido", MsgBoxStyle.Exclamation, "Error de validacion")
                txtTotalTransf.Focus()
                Exit Sub
            End If

            If Not IsNumeric(txtTotalCheques.Text.Trim) Then
                MsgBox("El importe ingresado no es valido", MsgBoxStyle.Exclamation, "Error de validacion")
                txtTotalCheques.Focus()
                Exit Sub
            End If

            If dtpFechaLiq.Value < DateAdd(DateInterval.Day, -30, Date.Today()) Then
                MsgBox("No se puede ingresar una liquidacion fecha valor", MsgBoxStyle.Exclamation, "Error de validacion")
                Exit Sub
            End If

            If IsNothing(cmbVendedores.SelectedItem) Then
                MsgBox("Debe seleccionar el vendedor asociado a la liquidacion", MsgBoxStyle.Exclamation, "Error de validacion")
                Exit Sub
            End If

            If Me.TipoDeOperacion = EnuOPERACION.CONS Then
                Select Case MsgBox("Esta seguro que desea guardar los cambios en liquidacion ? ", MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel, "Guardar")
                    Case MsgBoxResult.No
                        Me.Close()
                    Case MsgBoxResult.Cancel
                        Exit Sub
                End Select
            End If
            '----------------------------------------------------

            'Actualizo Datos Fijos
            Me.mLiq.Fecha = dtpFechaLiq.Value
            Me.mLiq.Vendedor = cmbVendedores.SelectedItem

            If mLiq.EsNuevo = True Then

                'Agrego las liquidaciones relacionadas a los montos fijos.

                If Double.Parse(txtTotalEfectivo.Text) > 0 Then
                    lLiqDet = New cLiquidacion_Det(gAdmin)
                    lLiqDet.Tipo_Valor = cLiquidacion_Det.enuTipoValor.Efectivo
                    lLiqDet.Importe = Double.Parse(txtTotalEfectivo.Text)
                    mLiq.AddLiqDetalle(lLiqDet)
                End If

                If Double.Parse(txtTotalNC.Text) > 0 Then
                    lLiqDet = New cLiquidacion_Det(gAdmin)
                    lLiqDet.Tipo_Valor = cLiquidacion_Det.enuTipoValor.NCredito
                    lLiqDet.Importe = Double.Parse(txtTotalNC.Text)
                    mLiq.AddLiqDetalle(lLiqDet)
                End If

                If Double.Parse(txtTotalRet.Text) > 0 Then
                    lLiqDet = New cLiquidacion_Det(gAdmin)
                    lLiqDet.Tipo_Valor = cLiquidacion_Det.enuTipoValor.Retencion
                    lLiqDet.Importe = Double.Parse(txtTotalRet.Text)
                    mLiq.AddLiqDetalle(lLiqDet)
                End If

                If Double.Parse(txtTotalTransf.Text) > 0 Then
                    lLiqDet = New cLiquidacion_Det(gAdmin)
                    lLiqDet.Tipo_Valor = cLiquidacion_Det.enuTipoValor.Transferencia
                    lLiqDet.Importe = Double.Parse(txtTotalTransf.Text)
                    mLiq.AddLiqDetalle(lLiqDet)
                End If

                If Double.Parse(txtTotalCheques.Text) > 0 Then 'Valido si hay importe en cheques

                    lLiqDet = mLiq.GetLiqDetCheques 'Traigo la liquidacion en cheques si existe

                    If IsNothing(lLiqDet) Then 'Si no estan cargados los cheques cargo el valor de la cabecera.
                        lLiqDet = New cLiquidacion_Det(gAdmin)
                        lLiqDet.Tipo_Valor = cLiquidacion_Det.enuTipoValor.Cheque
                        lLiqDet.Importe = Double.Parse(txtTotalCheques.Text)
                        lLiqDet.ValidarCompletitud()
                        mLiq.AddLiqDetalle(lLiqDet)
                    Else 'Si ya estaba cargada solo actualizo el valor total de cheques.
                        lLiqDet.Importe = Double.Parse(txtTotalCheques.Text)
                    End If

                End If

            Else 'ACA VA LA ACTUALIZACION DE UNA LIQUIDACION.

                lLiqDet = mLiq.GetLiqDetxTipo(cLiquidacion_Det.enuTipoValor.Efectivo)
                If IsNothing(lLiqDet) Then
                    If Double.Parse(txtTotalEfectivo.Text) > 0 Then
                        lLiqDet = New cLiquidacion_Det(gAdmin)
                        lLiqDet.Tipo_Valor = cLiquidacion_Det.enuTipoValor.Efectivo
                        lLiqDet.Importe = Double.Parse(txtTotalEfectivo.Text)
                        lLiqDet.Id_Liquidacion = mLiq.Id_Liquidacion
                        mLiq.AddLiqDetalle(lLiqDet)
                    End If
                Else
                    lLiqDet.Importe = Double.Parse(txtTotalEfectivo.Text)
                End If

                lLiqDet = mLiq.GetLiqDetxTipo(cLiquidacion_Det.enuTipoValor.NCredito)
                If IsNothing(lLiqDet) Then
                    If Double.Parse(txtTotalNC.Text) > 0 Then
                        lLiqDet = New cLiquidacion_Det(gAdmin)
                        lLiqDet.Tipo_Valor = cLiquidacion_Det.enuTipoValor.NCredito
                        lLiqDet.Importe = Double.Parse(txtTotalNC.Text)
                        lLiqDet.Id_Liquidacion = mLiq.Id_Liquidacion
                        mLiq.AddLiqDetalle(lLiqDet)
                    End If
                Else
                    lLiqDet.Importe = Double.Parse(txtTotalNC.Text)
                End If

                lLiqDet = mLiq.GetLiqDetxTipo(cLiquidacion_Det.enuTipoValor.Retencion)
                If IsNothing(lLiqDet) Then
                    If Double.Parse(txtTotalRet.Text) > 0 Then
                        lLiqDet = New cLiquidacion_Det(gAdmin)
                        lLiqDet.Tipo_Valor = cLiquidacion_Det.enuTipoValor.Retencion
                        lLiqDet.Importe = Double.Parse(txtTotalRet.Text)
                        lLiqDet.Id_Liquidacion = mLiq.Id_Liquidacion
                        mLiq.AddLiqDetalle(lLiqDet)
                    End If
                Else
                    lLiqDet.Importe = Double.Parse(txtTotalRet.Text)
                End If

                lLiqDet = mLiq.GetLiqDetxTipo(cLiquidacion_Det.enuTipoValor.Transferencia)
                If IsNothing(lLiqDet) Then
                    If Double.Parse(txtTotalTransf.Text) > 0 Then
                        lLiqDet = New cLiquidacion_Det(gAdmin)
                        lLiqDet.Tipo_Valor = cLiquidacion_Det.enuTipoValor.Transferencia
                        lLiqDet.Importe = Double.Parse(txtTotalTransf.Text)
                        lLiqDet.Id_Liquidacion = mLiq.Id_Liquidacion
                        mLiq.AddLiqDetalle(lLiqDet)
                    End If
                Else
                    lLiqDet.Importe = Double.Parse(txtTotalTransf.Text)
                End If

                lLiqDet = mLiq.GetLiqDetCheques 'Traigo la liquidacion en cheques si existe
                If IsNothing(lLiqDet) Then
                    If Double.Parse(txtTotalCheques.Text) > 0 Then 'Valido si hay importe en cheques
                        lLiqDet = New cLiquidacion_Det(gAdmin)
                        lLiqDet.Tipo_Valor = cLiquidacion_Det.enuTipoValor.Cheque
                        lLiqDet.Importe = Double.Parse(txtTotalCheques.Text)
                        lLiqDet.ValidarCompletitud()
                        lLiqDet.Id_Liquidacion = mLiq.Id_Liquidacion
                        mLiq.AddLiqDetalle(lLiqDet)
                    End If
                Else
                    lLiqDet.Importe = Double.Parse(txtTotalCheques.Text)
                End If
            End If

            Me.mLiq.Guardar()

            MsgBox("Liquidacion guardada con exito !", vbInformation, "Ok")
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesAlta.btnAceptar_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesAlta.btnAceptar_Click:" & ex.Message)
        End Try
    End Sub

    Private Sub btnEliminarCheque_Click(sender As Object, e As EventArgs) Handles btnEliminarCheque.Click

        Dim lItem As ListViewItem = Nothing
        Dim lCheque As cCheque = Nothing
        Dim lLiqDet As cLiquidacion_Det
        Try
            'VALIDACIONES
            If lvwConsulta.SelectedItems.Count = 0 Then
                MsgBox("Debe seleccionar el cheque que desea eliminar.", MsgBoxStyle.Exclamation, "Error de validacion")
                Exit Sub
            End If

            '----------------------------------------------------

            '--Obtengo la liquidacion que tiene chequues
            lLiqDet = mLiq.GetLiqDetCheques()

            If Not IsNothing(lLiqDet) Then  '--> Valido si existe cheque

                lItem = lvwConsulta.SelectedItems(0)
                lCheque = lItem.Tag
                lLiqDet.EliminarCheque(lCheque.Numero, lCheque.Banco.Id_Banco)

            End If

            subCargarCheques()

            '-Blanqueo los campos y vuelvo a posicionar para seguir cargando
            cmbBanco.SelectedItem = Nothing
            chkCruzado.Checked = False
            chkCertificado.Checked = False
            optAlPortador.Checked = False
            optNoAlaOrden.Checked = False
            optDirecto.Checked = True
            optTerceros.Checked = False
            dtpFecEmision.Value = Date.Today()
            txtImporte.Text = String.Empty
            txtObservac.Text = String.Empty
            txtNroCheque.Text = ""
            txtNroCheque.Focus()
            '---------------------------------

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesAlta.btnEliminarCheque_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesAlta.btnEliminarCheque_Click:" & ex.Message)
        End Try
    End Sub

    Private Sub txtTotalEfectivo_LostFocus(sender As Object, e As EventArgs) Handles txtTotalEfectivo.LostFocus
        Try

            If txtTotalEfectivo.Text.Trim = "" Then
                txtTotalEfectivo.Text = "0"
            End If

            If Not IsNumeric(txtTotalEfectivo.Text.Trim) Then
                MsgBox("El importe debe ser numerico", MsgBoxStyle.Exclamation, "Error de validacion")
                txtTotalEfectivo.Focus()
                Exit Sub
            End If

            ActualizarTotalLiq()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesAlta.txtTotalEfectivo_LostFocus")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesAlta.txtTotalEfectivo_LostFocus:" & ex.Message)
        End Try

    End Sub

    Private Sub txtTotalTransf_LostFocus(sender As Object, e As EventArgs) Handles txtTotalTransf.LostFocus
        Try
            If txtTotalTransf.Text.Trim = "" Then
                txtTotalTransf.Text = "0"
            End If

            If Not IsNumeric(txtTotalTransf.Text.Trim) Then
                MsgBox("El importe debe ser numerico", MsgBoxStyle.Exclamation, "Error de validacion")
                txtTotalTransf.Focus()
                Exit Sub
            End If

            ActualizarTotalLiq()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesAlta.txtTotalTransf_LostFocus")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesAlta.txtTotalTransf_LostFocus:" & ex.Message)
        End Try
    End Sub

    Private Sub txtTotalRet_LostFocus(sender As Object, e As EventArgs) Handles txtTotalRet.LostFocus
        Try
            If txtTotalRet.Text.Trim = "" Then
                txtTotalRet.Text = "0"
            End If

            If Not IsNumeric(txtTotalRet.Text.Trim) Then
                MsgBox("El importe debe ser numerico", MsgBoxStyle.Exclamation, "Error de validacion")
                txtTotalRet.Focus()
                Exit Sub
            End If

            ActualizarTotalLiq()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesAlta.txtTotalRet_LostFocus")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesAlta.txtTotalRet_LostFocus:" & ex.Message)
        End Try
    End Sub

    Private Sub txtTotalNC_LostFocus(sender As Object, e As EventArgs) Handles txtTotalNC.LostFocus
        Try

            If txtTotalNC.Text.Trim = "" Then
                txtTotalNC.Text = "0"
            End If

            If Not IsNumeric(txtTotalNC.Text.Trim) Then
                MsgBox("El importe debe ser numerico", MsgBoxStyle.Exclamation, "Error de validacion")
                txtTotalNC.Focus()
                Exit Sub
            End If

            ActualizarTotalLiq()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesAlta.txtTotalNC_LostFocus")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesAlta.txtTotalNC_LostFocus:" & ex.Message)
        End Try
    End Sub

    Private Sub ActualizarTotalLiq()
        Dim lTotal As Double = 0

        Try
            lblTotalLiq.Text = "$ 0"

            lTotal = lTotal + Double.Parse(txtTotalEfectivo.Text)
            lTotal = lTotal + Double.Parse(txtTotalCheques.Text)
            lTotal = lTotal + Double.Parse(txtTotalNC.Text)
            lTotal = lTotal + Double.Parse(txtTotalRet.Text)
            lTotal = lTotal + Double.Parse(txtTotalTransf.Text)

            lblTotalLiq.Text = "$ " & lTotal.ToString()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesAlta.ActualizarTotalLiq")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesAlta.ActualizarTotalLiq:" & ex.Message)
        End Try
    End Sub

    Private Sub txtTotCheques_LostFocus(sender As Object, e As EventArgs) Handles txtTotalCheques.LostFocus
        Try
            If txtTotalCheques.Text.Trim = "" Then
                txtTotalCheques.Text = "0"
            End If

            If Not IsNumeric(txtTotalRet.Text.Trim) Then
                MsgBox("El importe debe ser numerico", MsgBoxStyle.Exclamation, "Error de validacion")
                txtTotalCheques.Focus()
                Exit Sub
            End If

            ActualizarTotalLiq()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesAlta.txtTotCheques_LostFocus")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesAlta.txtTotCheques_LostFocus:" & ex.Message)
        End Try
    End Sub

    Private Sub btnBusq_Click(sender As Object, e As EventArgs) Handles btnBusq.Click
        Try
            mSettingClient = "Cheque"
            DirectCast(Me.MdiParent, frmPrincipal).SubAbrirConsulta(cAdmin.EnuOBJETOS.Cliente, Me)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesAlta.btnBusq_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesAlta.btnBusq_Click:" & ex.Message)
        End Try
    End Sub

    Private Sub txtTotalEfectivo_GotFocus(sender As Object, e As EventArgs) Handles txtTotalEfectivo.GotFocus
        txtTotalEfectivo.SelectAll()
    End Sub

    Private Sub txtTotalCheques_GotFocus(sender As Object, e As EventArgs) Handles txtTotalCheques.GotFocus
        txtTotalCheques.SelectAll()
    End Sub

    Private Sub txtTotalNC_GotFocus(sender As Object, e As EventArgs) Handles txtTotalNC.GotFocus
        txtTotalNC.SelectAll()
    End Sub

    Private Sub txtTotalRet_GotFocus(sender As Object, e As EventArgs) Handles txtTotalRet.GotFocus
        txtTotalRet.SelectAll()
    End Sub

    Private Sub txtTotalTransf_GotFocus(sender As Object, e As EventArgs) Handles txtTotalTransf.GotFocus
        txtTotalTransf.SelectAll()
    End Sub

    Private Sub txtCliente_LostFocus(sender As Object, e As EventArgs) Handles txtCliente.LostFocus
        Dim lCliente As cCliente = Nothing
        Try
            If Not txtCliente.Text.Trim = "" Then
                lCliente = cCliente.GetClientexNroCliente(gAdmin, txtCliente.Text.Trim)
                If Not IsNothing(lCliente) Then
                    mSettingClient = "Cheque"
                    SetCliente(lCliente)
                Else
                    txtCliente.Text = ""
                    lblNomCliente.Text = "_____________"
                    txtCliente.Tag = Nothing
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesAlta.txtCliente_LostFocus")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesAlta.txtCliente_LostFocus:" & ex.Message)
        End Try
    End Sub

    Private Sub txtTotalEfectivo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTotalEfectivo.KeyPress
        ' Lista con los caracteres que deseo permitir.
        Dim caracteresPermitidos As String = "1234567890.-+" & Convert.ToChar(8)
        ' Carácter presionado.
        Dim c As Char = e.KeyChar
        ' Si la tecla presionada no se encuentra en la matriz 
        ' de caracteres permitidos, anulamos la tecla pulsada.
        If (Not (caracteresPermitidos.Contains(c))) Then
            ' Deshechamos el carácter
            e.Handled = True
        End If
    End Sub

    Private Sub txtTotalCheques_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTotalCheques.KeyPress
        ' Lista con los caracteres que deseo permitir.
        Dim caracteresPermitidos As String = "1234567890.-+" & Convert.ToChar(8)
        ' Carácter presionado.
        Dim c As Char = e.KeyChar
        ' Si la tecla presionada no se encuentra en la matriz 
        ' de caracteres permitidos, anulamos la tecla pulsada.
        If (Not (caracteresPermitidos.Contains(c))) Then
            ' Deshechamos el carácter
            e.Handled = True
        End If
    End Sub

    Private Sub txtTotalNC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTotalNC.KeyPress
        ' Lista con los caracteres que deseo permitir.
        Dim caracteresPermitidos As String = "1234567890.-+" & Convert.ToChar(8)
        ' Carácter presionado.
        Dim c As Char = e.KeyChar
        ' Si la tecla presionada no se encuentra en la matriz 
        ' de caracteres permitidos, anulamos la tecla pulsada.
        If (Not (caracteresPermitidos.Contains(c))) Then
            ' Deshechamos el carácter
            e.Handled = True
        End If
    End Sub

    Private Sub txtTotalRet_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTotalRet.KeyPress
        ' Lista con los caracteres que deseo permitir.
        Dim caracteresPermitidos As String = "1234567890.-+" & Convert.ToChar(8)
        ' Carácter presionado.
        Dim c As Char = e.KeyChar
        ' Si la tecla presionada no se encuentra en la matriz 
        ' de caracteres permitidos, anulamos la tecla pulsada.
        If (Not (caracteresPermitidos.Contains(c))) Then
            ' Deshechamos el carácter
            e.Handled = True
        End If
    End Sub

    Private Sub txtTotalTransf_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTotalTransf.KeyPress
        ' Lista con los caracteres que deseo permitir.
        Dim caracteresPermitidos As String = "1234567890.-+" & Convert.ToChar(8)
        ' Carácter presionado.
        Dim c As Char = e.KeyChar
        ' Si la tecla presionada no se encuentra en la matriz 
        ' de caracteres permitidos, anulamos la tecla pulsada.
        If (Not (caracteresPermitidos.Contains(c))) Then
            ' Deshechamos el carácter
            e.Handled = True
        End If
    End Sub

    Private Sub txtImporte_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtImporte.KeyPress
        ' Lista con los caracteres que deseo permitir.
        Dim caracteresPermitidos As String = "1234567890.-+" & Convert.ToChar(8)
        ' Carácter presionado.
        Dim c As Char = e.KeyChar
        ' Si la tecla presionada no se encuentra en la matriz 
        ' de caracteres permitidos, anulamos la tecla pulsada.
        If (Not (caracteresPermitidos.Contains(c))) Then
            ' Deshechamos el carácter
            e.Handled = True
        End If
    End Sub

    Private Sub PicTransfDet_Click(sender As Object, e As EventArgs) Handles PicTransfDet.Click
        If pnlTransferencias.Visible = True Then
            pnlTransferencias.Visible = False
        Else
            pnlTransferencias.Visible = True
        End If
    End Sub

    Private Sub lblCerrarTransf_Click(sender As Object, e As EventArgs) Handles lblCerrarTransf.Click
        pnlTransferencias.Visible = False
    End Sub

    Private Sub btnTransfAdd_Click(sender As Object, e As EventArgs) Handles btnTransfAdd.Click
        Dim lItem As ListViewItem = Nothing
        Dim lTransf As cTransferencia = Nothing

        Try
            'VALIDACIONES
            If Not IsNumeric(txtTransfImporte.Text.Trim) Then
                MsgBox("El importe ingresado no es valido", MsgBoxStyle.Exclamation, "Error de validacion")
                Exit Sub
            End If

            If dtpTransfFecha.Value.Date > Date.Today().Date Then
                MsgBox("No se puede ingresar una transferencia futura", MsgBoxStyle.Exclamation, "Error de validacion")
                Exit Sub
            End If

            If IsNothing(txtTransfCli.Tag) Then
                MsgBox("Debe seleccionar el Cliente emisor de la transferencia", MsgBoxStyle.Exclamation, "Error de validacion")
                Exit Sub
            End If
            '----------------------------------------------------

            lTransf = New cTransferencia(gAdmin)
            If mLiq.EsNuevo = False Then
                lTransf.Id_Liquidacion = mLiq.Id_Liquidacion
            End If
            lTransf.Fecha = dtpTransfFecha.Value
            lTransf.Importe = txtTransfImporte.Text
            lTransf.NroCli = DirectCast(txtTransfCli.Tag, cCliente).NroCli
            lTransf.Estado = cEstado.GetEstadoxIdTipoEstado(gAdmin, 0, cEstado.enuTipoEstado.Transferencia)
            lTransf.Observaciones = txtTransfObserv.Text.Trim
            lTransf.EsNuevo = True

            If IsNothing(mLiq.Transferencias) Then  '--> valido si el array existe
                mLiq.Transferencias = New ArrayList
                mLiq.Transferencias.Add(lTransf)  '--> Agrego la transf al array
            Else
                mLiq.Transferencias.Add(lTransf)
            End If

            subCargarTransferencias()

            '-Blanqueo los campos y vuelvo a posicionar para seguir cargando
            dtpTransfFecha.Value = Date.Today()
            txtTransfImporte.Text = "0"
            txtTransfObserv.Text = String.Empty
            txtTransfCli.Text = ""
            lblCliTransf.Text = "_____________"
            txtTransfCli.Tag = Nothing
            dtpTransfFecha.Focus()
            '---------------------------------

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesCons.btnTransfAdd_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesCons.btnTransfAdd_Click:" & ex.Message)
        End Try
    End Sub

    Private Sub btnTransfDel_Click(sender As Object, e As EventArgs) Handles btnTransfDel.Click
        Dim lItem As ListViewItem = Nothing
        Dim lTransf As cTransferencia = Nothing
        Dim lTransfItem As cTransferencia = Nothing

        Try
            'VALIDACIONES
            If lvwTransf.SelectedItems.Count = 0 Then
                MsgBox("Debe seleccionar la transferencia que desea eliminar.", MsgBoxStyle.Exclamation, "Error de validacion")
                Exit Sub
            End If

            '----------------------------------------------------

            lItem = lvwTransf.SelectedItems(0)
            lTransf = lItem.Tag
            If lTransf.EsNuevo = False Then
                lTransf.Anular()
            End If

            For Each lTransfItem In mLiq.Transferencias
                If lTransfItem Is lTransf Then
                    mLiq.Transferencias.Remove(lTransfItem) 'Elimino la transf del array de la liquidacion.
                    Exit For
                End If
            Next
            subCargarTransferencias()

            '-Blanqueo los campos y vuelvo a posicionar para seguir cargando
            dtpTransfFecha.Value = Date.Today()
            txtTransfImporte.Text = "0"
            txtTransfObserv.Text = String.Empty
            txtTransfCli.Text = ""
            lblCliTransf.Text = "_____________"
            txtTransfCli.Tag = Nothing
            dtpTransfFecha.Focus()
            '---------------------------------

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesAlta.btnTransfDel_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesAlta.btnTransfDel_Click:" & ex.Message)
        End Try
    End Sub

    Private Sub btnBusqCliTransf_Click(sender As Object, e As EventArgs) Handles btnBusqCliTransf.Click
        Try
            mSettingClient = "Transferencia"
            DirectCast(Me.MdiParent, frmPrincipal).SubAbrirConsulta(cAdmin.EnuOBJETOS.Cliente, Me)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesAlta.btnBusqCliTransf_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesAlta.btnBusqCliTransf_Click:" & ex.Message)
        End Try
    End Sub

    Private Sub txtTransfCli_LostFocus(sender As Object, e As EventArgs) Handles txtTransfCli.LostFocus
        Dim lCliente As cCliente = Nothing
        Try
            If Not txtCliente.Text.Trim = "" Then
                lCliente = cCliente.GetClientexNroCliente(gAdmin, txtTransfCli.Text.Trim)
                If Not IsNothing(lCliente) Then
                    mSettingClient = "Transferencia"
                    SetCliente(lCliente)
                Else
                    txtTransfCli.Text = ""
                    lblCliTransf.Text = "_____________"
                    txtTransfCli.Tag = Nothing
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesAlta.txtTransfCli_LostFocus")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesAlta.txtTransfCli_LostFocus:" & ex.Message)
        End Try
    End Sub

    Private Sub txtImporteTransfDet_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTransfImporte.KeyPress
        ' Lista con los caracteres que deseo permitir.
        Dim caracteresPermitidos As String = "1234567890.-+" & Convert.ToChar(8)
        ' Carácter presionado.
        Dim c As Char = e.KeyChar
        ' Si la tecla presionada no se encuentra en la matriz 
        ' de caracteres permitidos, anulamos la tecla pulsada.
        If (Not (caracteresPermitidos.Contains(c))) Then
            ' Deshechamos el carácter
            e.Handled = True
        End If
    End Sub

End Class