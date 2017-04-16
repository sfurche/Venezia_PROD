Imports VzAdmin
Imports VzComercial
Imports vzStock

Public Class frmStkOrdenCompraAlta
    Public mOrdenCompra As cOrdenCompra

    Dim mPermiso As cPermiso = Nothing

    Private Sub frmStkOrdenCompraAlta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Tag = "STKALTAORDENDECOMPRA"

            '----------------------------------P-E-R-M-I-S-O-S---------------------------------------------------
            SetPermisos()
            '---------------------------------------------------------------------------------------------------

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkOrdenCompraAlta.frmStkOrdenCompraAlta_Load")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkOrdenCompraAlta.frmStkOrdenCompraAlta_Load:" & ex.Message)
        End Try
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub SetPermisos()
        Try

            mPermiso = gAdmin.User.GetPermiso("STK_OC: Alta de Orden de Compra")

            If mPermiso.Admin = cPermiso.enuBinario.Si Then
                Exit Sub
            End If

            If Not (mPermiso.Admin = cPermiso.enuBinario.Si Or mPermiso.Consulta = cPermiso.enuBinario.Si) Then
                MsgBox("No tiene permisos para acceder a esta opcion.", vbExclamation, "Acceso denegado")
                Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkOrdenCompraAlta.SetPermisos")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkOrdenCompraAlta.SetPermisos:" & ex.Message)
        End Try
    End Sub

    Private Sub btnBusq_Click(sender As Object, e As EventArgs) Handles btnBusq.Click
        Try
            DirectCast(Me.MdiParent, frmPrincipal).SubAbrirConsulta(cAdmin.EnuOBJETOS.Proveedores, Me)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkOrdenCompraAlta.btnBusq_Click")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkOrdenCompraAlta.btnBusq_Click:" & ex.Message)
        End Try
    End Sub

    Private Sub txtProove_LostFocus(sender As Object, e As EventArgs) Handles txtProove.LostFocus
        Dim pProove As cProveedor = Nothing
        Try
            If Not txtProove.Text.Trim = "" Then
                pProove = cProveedor.GetProveedorxNro(gAdmin, txtProove.Text.Trim)
                If Not IsNothing(pProove) Then
                    SetProveedor(pProove)
                Else
                    txtProove.Text = ""
                    lblNomProove.Text = "_____________"
                    txtProove.Tag = Nothing
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkOrdenCompraAlta.txtProove_LostFocus")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkOrdenCompraAlta.txtProove_LostFocus:" & ex.Message)
        End Try
    End Sub

    Public Sub SetProveedor(ByVal pProove As cProveedor)
        Try
            lblNomProove.Text = pProove.Nombre
            txtProove.Text = pProove.Id_Proveedor
            txtProove.Tag = pProove
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmStkOrdenCompraAlta.SetCliente")
            gAdmin.Log.fncGrabarLogERR("Error en frmStkOrdenCompraAlta.SetCliente:" & ex.Message)
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try


            'VALIDACIONES

            If IsNothing(txtProove.Tag) Then
                MsgBox("Debe seleccionar el Proveedor.", MsgBoxStyle.Exclamation, "Error de validacion")
                Exit Sub
            End If
            '----------------------------------------------------

            If Me.TipoDeOperacion = EnuOPERACION.ALTA Or Me.TipoDeOperacion = EnuOPERACION.MODIF Then
                'Insert
                If Me.TipoDeOperacion = EnuOPERACION.ALTA Then
                    mOrdenCompra = New cOrdenCompra(gAdmin)
                    mOrdenCompra.EsNuevo = True
                End If

                'GUARDO LA INFORMAION


            Else 'update


            End If

            MsgBox("La orden se guardo con exito !!", MsgBoxStyle.Information, "Ok")

                Me.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class