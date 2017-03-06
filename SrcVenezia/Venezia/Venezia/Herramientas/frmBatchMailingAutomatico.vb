Imports VzAdmin
Imports vzprocesos

Public Class frmBatchMailingAutomatico

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub frmBatchMailingAutomatico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            '----------------------------------P-E-R-M-I-S-O-S---------------------------------------------------
            SetPermisos()
            '---------------------------------------------------------------------------------------------------

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            SubCargarGrilla()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmBatchMailingAutomatico.frmBatchMailingAutomatico_Load")
            gAdmin.Log.fncGrabarLogERR("Error en frmBatchMailingAutomatico.frmBatchMailingAutomatico_Load:" & ex.Message)
        End Try
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub SetPermisos()
        Dim lPermiso As cPermiso = Nothing
        Try

            lPermiso = gAdmin.User.GetPermiso("HERR_PROC: Mailing Automatico")
            If lPermiso.Admin = cPermiso.enuBinario.Si Then
                Exit Sub
            End If

            If Not (lPermiso.Ejecuta = cPermiso.enuBinario.Si Or lPermiso.Consulta = cPermiso.enuBinario.Si) Then
                MsgBox("No tiene permisos para acceder a esta opcion.", vbExclamation, "Acceso denegado")
                Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
            End If

            If Not lPermiso.Ejecuta = cPermiso.enuBinario.Si Then
                btnProcesarMailPendientes.Enabled = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmBatchMailingAutomatico.SetPermisos")
            gAdmin.Log.fncGrabarLogERR("Error en frmBatchMailingAutomatico.SetPermisos:" & ex.Message)
        End Try
    End Sub

    Private Sub SubCargarGrilla()
        Dim lItem As ListViewItem = Nothing
        Dim lEmail As cEmail = Nothing
        Dim lArray As ArrayList = Nothing

        Try
            lArray = cEmail.GetMailingxEstado(gAdmin, 0)

            DGConsulta.DataSource = lArray

            DGConsulta.ForeColor = Color.Black

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmComVendedoresCons_Load.SubCargarGrilla")
            gAdmin.Log.fncGrabarLogERR("Error en frmComVendedoresCons_Load.SubCargarGrilla:" & ex.Message)
        End Try

    End Sub

    Private Sub btnProcesarMailPendientes_Click(sender As Object, e As EventArgs) Handles btnProcesarMailPendientes.Click
        Try
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            If VzProcesos.cMailingAutomatico.EnviarMailsPendientes(gAdmin) = True Then
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                MsgBox("El proseso se ejecuto correctamente!.", vbInformation, "Proceso OK")
            Else
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                MsgBox("Fallo el proceso. Revise los logs.", MsgBoxStyle.Exclamation, "Proceso NOK")
            End If
            SubCargarGrilla()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmComVendedoresCons_Load.SubCargarGrilla")
            gAdmin.Log.fncGrabarLogERR("Error en frmComVendedoresCons_Load.SubCargarGrilla:" & ex.Message)
        End Try
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

End Class