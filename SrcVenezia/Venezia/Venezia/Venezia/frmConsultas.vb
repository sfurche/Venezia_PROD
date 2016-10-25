Imports VzAdmin
Imports VzComercial

Public Class frmConsultas

#Region "Propiedades"
    Public pTipoObjeto As cAdmin.EnuOBJETOS
#End Region

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnSeleccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeleccionar.Click
        Try
            If lvwConsulta.SelectedItems.Count = 0 Then
                MsgBox("Debe seleccionar un item de la lista.", MsgBoxStyle.Exclamation, "No selecciono nada")
            Else
                If Me.FrmLlamador.Tag = "ALTALIQUIDACION" Then
                    Select Case pTipoObjeto
                        Case cAdmin.EnuOBJETOS.Cliente
                            DirectCast(Me.FrmLlamador, frmTesoLiquidacionesAlta).SetCliente(lvwConsulta.SelectedItems(0).Tag)
                            Me.Close()
                    End Select
                ElseIf Me.FrmLlamador.Tag = "ALTAORDENDEPAGO" Then
                    Select Case pTipoObjeto
                        Case cAdmin.EnuOBJETOS.Proveedores
                            DirectCast(Me.FrmLlamador, frmTesoOrdenDePagoAlta).SetProveedor(lvwConsulta.SelectedItems(0).Tag)
                            Me.Close()
                    End Select
                ElseIf Me.FrmLlamador.Tag = "CONSULTAORDENESDEPAGO" Then
                    Select Case pTipoObjeto
                        Case cAdmin.EnuOBJETOS.Proveedores
                            DirectCast(Me.FrmLlamador, frmTesoOrdenDePagoConsulta).SetProveedor(lvwConsulta.SelectedItems(0).Tag)
                            Me.Close()
                    End Select
                ElseIf Me.FrmLlamador.Tag = "TESOCHKRPTXPROV" Then
                    Select Case pTipoObjeto
                        Case cAdmin.EnuOBJETOS.Proveedores
                            DirectCast(Me.FrmLlamador, frmTesoChkRptxProv).SetProveedor(lvwConsulta.SelectedItems(0).Tag)
                            Me.Close()
                    End Select
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message.Trim, MsgBoxStyle.Critical, "Error en FrmConsultas_btnSeleccionar_Click")
            gAdmin.Log.fncGrabarLogERR("Error en FrmConsultas_btnSeleccionar_Click :" & ex.Message)
        End Try
    End Sub

    Private Sub SubSetCabecera()
        lvwConsulta.Columns.Add("Codigo", 80, HorizontalAlignment.Center)
        lvwConsulta.Columns.Add("Descripcion", 200, HorizontalAlignment.Center)
    End Sub

    Private Sub lvwConsulta_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwConsulta.DoubleClick
        Try
            btnSeleccionar_Click(sender, e)
        Catch ex As Exception
            MsgBox(ex.Message.Trim, MsgBoxStyle.Critical, "Error en FrmConsultas_lvwConsulta_DoubleClick")
            gAdmin.Log.fncGrabarLogERR("Error en FrmConsultas_lvwConsulta_DoubleClick :" & ex.Message)
        End Try

    End Sub

    Private Sub FrmConsultas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SubSetCabecera()
            txtNombre.Focus()

            Select Case pTipoObjeto
                Case cAdmin.EnuOBJETOS.Cliente
                    Me.Text = "Consulta de Clientes"
                    lblNombre.Text = "Cliente:"
                Case cAdmin.EnuOBJETOS.Proveedores
                    Me.Text = "Consulta de Proveedores"
                    lblNombre.Text = "Proveedor:"
                Case Else
                    MsgBox("Aun no esta Definida.", MsgBoxStyle.Exclamation)
                    Me.Close()
            End Select

        Catch ex As Exception
            MsgBox(ex.Message.Trim, MsgBoxStyle.Critical, "Error en FrmConsultas_Load")
            gAdmin.Log.fncGrabarLogERR("Error en FrmConsultas_Load :" & ex.Message)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Try
            If txtNombre.Text.Trim.Length Then
                Select Case pTipoObjeto
                    Case cAdmin.EnuOBJETOS.Cliente
                        FncCargarGrillaClientes(cCliente.Busq_ClientexNroONombre(gAdmin, txtNombre.Text.Trim))
                    Case cAdmin.EnuOBJETOS.Proveedores
                        FncCargarGrillaProveedores(cProveedor.GetProveedorxNroONombre(gAdmin, txtNombre.Text.Trim))
                    Case Else
                        MsgBox("Aun no esta disponible esta funcionalidad.", MsgBoxStyle.Exclamation)
                        Me.Close()
                End Select
            End If

        Catch ex As Exception
            MsgBox(ex.Message.Trim, MsgBoxStyle.Critical, "Error en FrmConsultas_btnBuscar_Click")
            gAdmin.Log.fncGrabarLogERR("Error en FrmConsultas_btnBuscar_Click :" & ex.Message)
        End Try
    End Sub

    Private Sub FncCargarGrillaClientes(ByVal pAr As ArrayList)
        Dim lCliente As VzComercial.cCliente = Nothing
        Dim lItem As ListViewItem
        Try
            lvwConsulta.BeginUpdate()
            lvwConsulta.Clear()

            lvwConsulta.Columns.Add("Codigo", 80, HorizontalAlignment.Center)
            lvwConsulta.Columns.Add("Cliente", 250, HorizontalAlignment.Left)

            For Each lCliente In pAr
                lItem = New ListViewItem
                lItem.Tag = lCliente
                lItem.Text = lCliente.NroCli
                lItem.SubItems.Add(lCliente.Nombre)
                lvwConsulta.Items.Add(lItem)
            Next
            lvwConsulta.EndUpdate()
            lblCant.Text = "Cantidad encontrados : " & pAr.Count.ToString

        Catch ex As Exception
            MsgBox(ex.Message.Trim, MsgBoxStyle.Critical, "Error en FrmConsultas.FncCargarGrillaClientes")
            gAdmin.Log.fncGrabarLogERR("Error en FrmConsultas.FncCargarGrillaClientes :" & ex.Message)
        End Try
    End Sub

    Private Sub FncCargarGrillaProveedores(ByVal pAr As ArrayList)
        Dim lProveedor As VzComercial.cProveedor = Nothing
        Dim lItem As ListViewItem
        Try
            lvwConsulta.BeginUpdate()
            lvwConsulta.Clear()

            lvwConsulta.Columns.Add("Codigo", 80, HorizontalAlignment.Center)
            lvwConsulta.Columns.Add("Proveedor", 250, HorizontalAlignment.Left)

            For Each lProveedor In pAr
                lItem = New ListViewItem
                lItem.Tag = lProveedor
                lItem.Text = lProveedor.Id_Proveedor
                lItem.SubItems.Add(lProveedor.Nombre)
                lvwConsulta.Items.Add(lItem)
            Next
            lvwConsulta.EndUpdate()
            lblCant.Text = "Cantidad encontrados : " & pAr.Count.ToString

        Catch ex As Exception
            MsgBox(ex.Message.Trim, MsgBoxStyle.Critical, "Error en FrmConsultas.FncCargarGrillaProveedores")
            gAdmin.Log.fncGrabarLogERR("Error en FrmConsultas.FncCargarGrillaProveedores :" & ex.Message)
        End Try
    End Sub

    Private Sub txtNombre_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNombre.KeyUp
        Select Case e.KeyCode
            Case Keys.Enter
                btnBuscar_Click(sender, e)
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub lvwConsulta_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvwConsulta.KeyUp
        Select Case e.KeyCode
            Case Keys.Enter
                btnSeleccionar_Click(sender, e)
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub
End Class