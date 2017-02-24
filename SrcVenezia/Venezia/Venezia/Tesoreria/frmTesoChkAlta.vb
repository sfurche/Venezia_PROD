Imports VzComercial
Imports VzTesoreria
Imports VzAdmin

Public Class frmTesoChkAlta

    Public mCheque As cCheque
    Dim mPermiso As cPermiso = Nothing
    Private Sub frmTesoChkAlta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            '----------------------------------P-E-R-M-I-S-O-S---------------------------------------------------
            SetPermisos()
            '---------------------------------------------------------------------------------------------------

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            subCargarBancos()
            subCargarDatos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoChkAlta.frmTesoChkAlta_Load")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoChkAlta.frmTesoChkAlta_Load:" & ex.Message)
        End Try
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub SetPermisos()
        Try

            mPermiso = gAdmin.User.GetPermiso("TESO_CHQ: Consulta de Cheques")

            If mPermiso.Admin = cPermiso.enuBinario.Si Then
                Exit Sub
            End If

            If Not (mPermiso.Modificacion = cPermiso.enuBinario.Si Or mPermiso.Consulta = cPermiso.enuBinario.Si) Then
                MsgBox("No tiene permisos para acceder a esta opcion.", vbExclamation, "Acceso denegado")
                Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
            End If

            If Not mPermiso.Modificacion = cPermiso.enuBinario.Si Then
                btnRechazado.Enabled = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmCfgPermisosConsulta.SetPermisos")
            gAdmin.Log.fncGrabarLogERR("Error en frmCfgPermisosConsulta.SetPermisos:" & ex.Message)
        End Try
    End Sub


    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Public Sub SetCliente(ByVal pCliente As cCliente)
        Try

            lblNomCliente.Text = pCliente.Nombre
            txtCliente.Text = pCliente.NroCli
            txtCliente.Tag = pCliente

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoChkAlta.SetCliente")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoChkAlta.SetCliente:" & ex.Message)
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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoChkAlta.subCargarBancos")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoChkAlta.subCargarBancos:" & ex.Message)
        End Try
    End Sub

    Private Sub subCargarDatos()
        Dim lConcil As cConciliacionLiq = Nothing
        Try

            If Not IsNothing(mCheque) Then

                txtNroCheque.Text = mCheque.Numero.ToString
                txtImporte.Text = mCheque.Importe.ToString
                txtObservac.Text = mCheque.Obaservaciones
                txtCliente.Text = mCheque.NroCli
                dtpFecPago.Value = mCheque.Fecha_Pago
                cmbBanco.Text = mCheque.Banco.NombreComb

                'Seteo el origen del cheque
                If mCheque.Directo = cCheque.enuBinario.Si Then
                    optDirecto.Checked = True
                    optTerceros.Checked = False
                Else
                    optDirecto.Checked = False
                    optTerceros.Checked = True
                End If

                'Valido si esa cruzado
                If mCheque.Cruzado = cCheque.enuBinario.Si Then
                    chkCruzado.Checked = True
                Else
                    chkCruzado.Checked = False
                End If

                If mCheque.Orden = cCheque.enuBinario.Si Then
                    optAlaOrden.Checked = True
                    optNoAlaOrden.Checked = False
                    optAlPortador.Checked = False
                Else
                    optAlaOrden.Checked = False
                    optNoAlaOrden.Checked = True
                    optAlPortador.Checked = False
                End If

                lblEstadoChk.Text = mCheque.Estado.Estado
                Select Case mCheque.Estado.Id_Estado
                    Case 0 'Si el cheque esta en cartera lo pongo en verde
                        lblEstadoChk.ForeColor = Color.GreenYellow
                    Case 1 'Si el cheque esta liquidado lo pongo en azul.
                        lblEstadoChk.ForeColor = Color.PowderBlue
                    Case 2 'Si el cheque esta rechazado pendiente de gestion lo pongo en rojo
                        lblEstadoChk.ForeColor = Color.Red
                End Select

                'Si el boton rechazado esta habilitado por el esquema de permisos valido si es factible rechazarlo/recuperarlo
                If btnRechazado.Enabled = True Then
                    'Si el cheque esta liquidado permito que lo marquen como rechazado.
                    If mCheque.Estado.Id_Estado = 1 Then
                        btnRechazado.Text = "Rechazado"
                        btnRechazado.Enabled = True
                    ElseIf mCheque.Estado.Id_Estado = 2 Then  'Si el cheque esta Rechazado Pte permito que lo marquen como recuperado.
                        btnRechazado.Text = "Recuperado"
                    Else
                        btnRechazado.Enabled = False
                    End If
                End If

                'Escribo un comentario sobre las liquidaciones asociadas
                lblDatosLiquidaciones.Text = "Recibido en la liquidacion nro=" & mCheque.Id_Liquidacion.ToString
                    If mCheque.Estado.Id_Estado = 3 Then
                        lConcil = cConciliacionLiq.GetDeudoresxIdCheque(gAdmin, mCheque.Id_Cheque)(0)
                        lblDatosLiquidaciones.Text = lblDatosLiquidaciones.Text & " y recuperado en la nro=" & lConcil.Id_Liquidacion.ToString
                    End If


                End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoChkAlta.subCargarDatos")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoChkAlta.subCargarDatos:" & ex.Message)
        End Try
    End Sub

    Private Sub txtCliente_TextChanged(sender As Object, e As EventArgs) Handles txtCliente.TextChanged
        Dim lCliente As cCliente = Nothing
        Try
            If Not txtCliente.Text.Trim = "" Then
                lCliente = cCliente.GetClientexNroCliente(gAdmin, txtCliente.Text.Trim)
                If Not IsNothing(lCliente) Then
                    SetCliente(lCliente)
                Else
                    txtCliente.Text = ""
                    lblNomCliente.Text = "_____________"
                    txtCliente.Tag = Nothing
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoChkAlta.txtCliente_TextChanged")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoChkAlta.txtCliente_TextChanged:" & ex.Message)
        End Try
    End Sub

    Private Sub btnRechazado_Click(sender As Object, e As EventArgs) Handles btnRechazado.Click
        Try

            If btnRechazado.Text = "Rechazado" Then

                If MsgBox("Desea marcar este cheque como RECHAZADO ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Marcar como rechazado") = MsgBoxResult.Yes Then
                    mCheque.Rechazar()
                    subCargarBancos()
                    subCargarDatos()
                End If

            Else
                If MsgBox("Desea marcar este cheque como liquidado (RECUPERADO) ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Marcar como recuperado") = MsgBoxResult.Yes Then
                    mCheque.Recuperar()
                    subCargarBancos()
                    subCargarDatos()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoChkAlta.btnRechazado_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoChkAlta.btnRechazado_Click:" & ex.Message)
        End Try
    End Sub


End Class