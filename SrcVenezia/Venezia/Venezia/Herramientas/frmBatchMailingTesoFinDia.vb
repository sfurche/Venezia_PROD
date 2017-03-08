Imports VzAdmin
Imports VzProcesos

Public Class frmBatchMailingTesoFinDia
    Private Sub frmBatchMailingTesoFinDia_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            '----------------------------------P-E-R-M-I-S-O-S---------------------------------------------------
            SetPermisos()
            '---------------------------------------------------------------------------------------------------

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            dtpFecha.Value = Date.Today

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmBatchMailingTesoFinDia.frmBatchMailingAutomatico_Load")
            gAdmin.Log.fncGrabarLogERR("Error en frmBatchMailingTesoFinDia.frmBatchMailingAutomatico_Load:" & ex.Message)
        End Try
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub SetPermisos()
        Dim lPermiso As cPermiso = Nothing
        Try

            lPermiso = gAdmin.User.GetPermiso("HERR_PROC: Mailing TesoInicio Fin de Dia")
            If lPermiso.Admin = cPermiso.enuBinario.Si Then
                Exit Sub
            End If

            If Not (lPermiso.Ejecuta = cPermiso.enuBinario.Si) Then
                MsgBox("No tiene permisos para acceder a esta opcion.", vbExclamation, "Acceso denegado")
                Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
            End If

            If Not lPermiso.Ejecuta = cPermiso.enuBinario.Si Then
                btnProcesarMailPendientes.Enabled = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmBatchMailingTesoFinDia.SetPermisos")
            gAdmin.Log.fncGrabarLogERR("Error en frmBatchMailingTesoFinDia.SetPermisos:" & ex.Message)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnProcesarMailPendientes_Click(sender As Object, e As EventArgs) Handles btnProcesarMailPendientes.Click
        Try
            If cMailingTesoFinDia.Ejecutar(gAdmin, dtpFecha.Value) Then
                MsgBox("El proceso se ejecuto correctamente.", MsgBoxStyle.Information, "Proceso OK")
            Else
                MsgBox("El proceso fallo.", MsgBoxStyle.Exclamation, "Proceso NOK")
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmBatchMailingTesoFinDia.btnProcesarMailPendientes_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmBatchMailingTesoFinDia.btnProcesarMailPendientes_Click:" & ex.Message)
        End Try
    End Sub
End Class