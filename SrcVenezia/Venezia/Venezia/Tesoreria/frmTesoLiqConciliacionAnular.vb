Imports VzTesoreria

Public Class frmTesoLiqConciliacionAnular
    Private Sub frmTesoLiqConciliacionAnular_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            subCargarLiquidaciones()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiqConciliacionAnular.frmTesoLiqConciliacionAnular_Load")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiqConciliacionAnular.frmTesoLiqConciliacionAnular_Load:" & ex.Message)
        End Try
    End Sub

    Private Sub subCargarLiquidaciones()
        Dim lArray As ArrayList
        Dim lLiq As cLiquidacion = Nothing
        Try
            cmbLiquidacion.Items.Clear()

            lArray = cLiquidacion.GetLiquidacionesxAnularConciliacion(gAdmin)

            For Each lLiq In lArray
                cmbLiquidacion.Items.Add(lLiq)
                cmbLiquidacion.DisplayMember = "DisplayName"
            Next

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiqConciliacionAnular.subCargarLiquidaciones")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiqConciliacionAnular.subCargarLiquidaciones:" & ex.Message)
        End Try

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim lLiq As cLiquidacion = Nothing
        Try
            If IsNothing(cmbLiquidacion.SelectedItem) Then
                MsgBox("Debe seleccionar una liquidacion conciliada para poder anular.", MsgBoxStyle.Exclamation, "Faltan Datos")
                Exit Sub
            End If

            If MsgBox("Esta seguro que desea anular la conciliacion?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmacion") = vbNo Then
                Exit Sub
            End If

            lLiq = DirectCast(cmbLiquidacion.SelectedItem, cLiquidacion)

            lLiq.Anular_Conciliacion()

            MsgBox("Liquidacion anulada con exito.", MsgBoxStyle.Information, "Anulacion Ok")

            subCargarLiquidaciones()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiqConciliacionAnular.btnAceptar_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiqConciliacionAnular.btnAceptar_Click:" & ex.Message)
        End Try
    End Sub

    Private Sub frmTesoLiqConciliacionAnular_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        Try
            subCargarLiquidaciones()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmTesoLiqConciliacionAnular.frmTesoLiqConciliacionAnular_GotFocus")
            gAdmin.Log.fncGrabarLogERR("Error en frmTesoLiqConciliacionAnular.frmTesoLiqConciliacionAnular_GotFocus:" & ex.Message)
        End Try
    End Sub
End Class