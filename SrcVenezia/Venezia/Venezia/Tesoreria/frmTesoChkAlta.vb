Imports VzComercial
Imports VzTesoreria

Public Class frmTesoChkAlta

    Public mCheque As cCheque

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

                'Si el cheque esta liquidado permito que lo marquen como rechazado.
                If mCheque.Estado.Id_Estado = 1 Then
                    btnRechazado.Enabled = True
                Else
                    btnrechazado.Enabled = False
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

    Private Sub frmTesoChkAlta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            subCargarBancos()
            subCargarDatos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoChkAlta.frmTesoChkAlta_Load")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoChkAlta.frmTesoChkAlta_Load:" & ex.Message)
        End Try
    End Sub

    Private Sub btnRechazado_Click(sender As Object, e As EventArgs) Handles btnRechazado.Click
        Try
            If MsgBox("Desea marcar este cheque como RECHAZADO ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Marcar como rechazado") = MsgBoxResult.Yes Then
                mCheque.Rechazar()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoChkAlta.btnRechazado_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoChkAlta.btnRechazado_Click:" & ex.Message)
        End Try
    End Sub
End Class