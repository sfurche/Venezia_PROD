Imports VzComercial
Imports VzTesoreria

Public Class frmTesoLiquidacionesAltaRapida

    Public mLiq As cLiquidacion
    Public mLiqBkp As String

    Private Sub frmTesoLiquidacionesAlta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            subCargarVendedores()
            dtpFechaLiq.Enabled = False
            Select Case Me.TipoDeOperacion
                Case FrmBase.EnuOPERACION.MODIF
                    mLiqBkp = mLiq.ToXML
                    SubCargarDatosLiq(mLiq)
                Case FrmBase.EnuOPERACION.CONS
                    mLiqBkp = mLiq.ToXML
                    SubCargarDatosLiq(mLiq)
                    'Si solo es consulta inhabilito todos los controles.
                    groupGeneral.Enabled = False

                Case FrmBase.EnuOPERACION.ALTA
                    mLiq = New cLiquidacion(gAdmin)
                    subCargarVendedores()
                Case Else
                    Me.Close()
            End Select

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesAltaRapida.frmTesoLiquidacionesAlta_Load")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesAltaRapida.frmTesoLiquidacionesAlta_Load:" & ex.Message)
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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesAltaRapida.subCargarVendedores")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesAltaRapida.subCargarVendedores:" & ex.Message)
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
            dtpFechaLiq.Value = mLiq.Fecha
            cmbVendedores.Text = mLiq.Vendedor.Nombre
            lblTotalLiq.Text = "$" & mLiq.TotalLiq()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesAltaRapida.SubCargarDatosLiq")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesAltaRapida.SubCargarDatosLiq:" & ex.Message)
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
                MsgBox("No se puede ingresar liquidacion fecha valor", MsgBoxStyle.Exclamation, "Error de validacion")
                Exit Sub
            End If

            If IsNothing(cmbVendedores.SelectedItem) Then
                MsgBox("Debe seleccionar el vendedor asociado a la liquidacion", MsgBoxStyle.Exclamation, "Error de validacion")
                Exit Sub
            End If
            '----------------------------------------------------

            If mLiq.EsNuevo = True Then

                Me.mLiq.Fecha = dtpFechaLiq.Value
                Me.mLiq.Vendedor = cmbVendedores.SelectedItem

                'Agrego las liquidaciones relacionadas a los montos fijos.

                If Double.Parse(txtTotalEfectivo.Text) > 0 Then
                    lLiqDet = New cLiquidacion_Det(gAdmin)
                    lLiqDet.Tipo_Valor = cLiquidacion_Det.enuTipoValor.Efectivo
                    lLiqDet.Importe = Double.Parse(txtTotalEfectivo.Text)
                    mLiq.AddLiqDetalle(lLiqDet)
                End If

                If Double.Parse(txtTotalCheques.Text) > 0 Then
                    lLiqDet = New cLiquidacion_Det(gAdmin)
                    lLiqDet.Tipo_Valor = cLiquidacion_Det.enuTipoValor.Cheque
                    lLiqDet.Importe = Double.Parse(txtTotalCheques.Text)
                    lLiqDet.Completo = False
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

                Me.mLiq.Guardar()
            Else
                'ACA VA LA ACTUALIZACION DE UNA LIQUIDACION.

                'If Double.Parse(txtTotalCheques.Text) > 0 Then
                '    lLiqDet = mLiq.GetLiqDetCheques
                '    If IsNothing(lLiqDet) Then
                '        lLiqDet = New cLiquidacion_Det(gAdmin)
                '        lLiqDet.Tipo_Valor = cLiquidacion_Det.enuTipoValor.Cheque
                '        lLiqDet.Importe = Double.Parse(txtTotalCheques.Text)
                '        mLiq.AddLiqDetalle(lLiqDet)
                '    End If
                'End If

            End If

            MsgBox("Liquidacion guardada con exito !", vbInformation, "Ok")
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesAltaRapida.btnAceptar_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesAltaRapida.btnAceptar_Click:" & ex.Message)
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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesAltaRapida.txtTotalEfectivo_LostFocus")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesAltaRapida.txtTotalEfectivo_LostFocus:" & ex.Message)
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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesAltaRapida.txtTotalTransf_LostFocus")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesAltaRapida.txtTotalTransf_LostFocus:" & ex.Message)
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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesAltaRapida.txtTotalRet_LostFocus")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesAltaRapida.txtTotalRet_LostFocus:" & ex.Message)
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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesAltaRapida.txtTotalNC_LostFocus")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesAltaRapida.txtTotalNC_LostFocus:" & ex.Message)
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
            ' lTotal = lTotal + mLiq.Importe_Cheques

            lblTotalLiq.Text = "$ " & lTotal.ToString()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesAltaRapida.ActualizarTotalLiq")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesAltaRapida.ActualizarTotalLiq:" & ex.Message)
        End Try
    End Sub

    Private Sub txtTotCheques_LostFocus(sender As Object, e As EventArgs) Handles txtTotalCheques.LostFocus
        Try
            If txtTotalCheques.Text.Trim = "" Then
                txtTotalCheques.Text = "0"
            End If

            If Not IsNumeric(txtTotalRet.Text.Trim) Then
                MsgBox("El importe debe ser numerico", MsgBoxStyle.Exclamation, "Error de validacion")
                Exit Sub
            End If

            ActualizarTotalLiq()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiquidacionesAltaRapida.txtTotCheques_LostFocus")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiquidacionesAltaRapida.txtTotCheques_LostFocus:" & ex.Message)
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

End Class
