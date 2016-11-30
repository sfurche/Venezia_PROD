<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTesoLiquidacionesAlta
    Inherits FrmBase

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTesoLiquidacionesAlta))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblEst = New System.Windows.Forms.Label()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.groupCheques = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.chkCertificado = New System.Windows.Forms.CheckBox()
        Me.chkCruzado = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.optTerceros = New System.Windows.Forms.RadioButton()
        Me.optDirecto = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.optAlPortador = New System.Windows.Forms.RadioButton()
        Me.optNoAlaOrden = New System.Windows.Forms.RadioButton()
        Me.optAlaOrden = New System.Windows.Forms.RadioButton()
        Me.txtObservac = New System.Windows.Forms.TextBox()
        Me.btnBusq = New System.Windows.Forms.Button()
        Me.lblNomCliente = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.btnEliminarCheque = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lbltotalCheques = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtpFecEmision = New System.Windows.Forms.DateTimePicker()
        Me.txtImporte = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtNroCheque = New System.Windows.Forms.TextBox()
        Me.cmbBanco = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lvwConsulta = New System.Windows.Forms.ListView()
        Me.groupGeneral = New System.Windows.Forms.GroupBox()
        Me.PicTransfDet = New System.Windows.Forms.PictureBox()
        Me.txtTotalCheques = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblTotalLiq = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbVendedores = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTotalRet = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTotalEfectivo = New System.Windows.Forms.TextBox()
        Me.txtTotalTransf = New System.Windows.Forms.TextBox()
        Me.txtTotalNC = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFechaLiq = New System.Windows.Forms.DateTimePicker()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        Me.groupCheques.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.groupGeneral.SuspendLayout()
        CType(Me.PicTransfDet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.Controls.Add(Me.lblEst)
        Me.Panel1.Controls.Add(Me.lblEstado)
        Me.Panel1.Controls.Add(Me.btnAceptar)
        Me.Panel1.Controls.Add(Me.btnSalir)
        Me.Panel1.Controls.Add(Me.groupCheques)
        Me.Panel1.Controls.Add(Me.groupGeneral)
        Me.Panel1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Panel1.Location = New System.Drawing.Point(5, 8)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(791, 532)
        Me.Panel1.TabIndex = 0
        '
        'lblEst
        '
        Me.lblEst.AutoSize = True
        Me.lblEst.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEst.Location = New System.Drawing.Point(663, 3)
        Me.lblEst.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.lblEst.Name = "lblEst"
        Me.lblEst.Size = New System.Drawing.Size(43, 13)
        Me.lblEst.TabIndex = 11
        Me.lblEst.Text = "Estado:"
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Location = New System.Drawing.Point(711, 3)
        Me.lblEstado.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(34, 13)
        Me.lblEstado.TabIndex = 10
        Me.lblEstado.Text = "Inicial"
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Location = New System.Drawing.Point(565, 502)
        Me.btnAceptar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(95, 22)
        Me.btnAceptar.TabIndex = 24
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Location = New System.Drawing.Point(676, 502)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(95, 22)
        Me.btnSalir.TabIndex = 25
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'groupCheques
        '
        Me.groupCheques.Controls.Add(Me.GroupBox4)
        Me.groupCheques.Controls.Add(Me.GroupBox3)
        Me.groupCheques.Controls.Add(Me.GroupBox2)
        Me.groupCheques.Controls.Add(Me.txtObservac)
        Me.groupCheques.Controls.Add(Me.btnBusq)
        Me.groupCheques.Controls.Add(Me.lblNomCliente)
        Me.groupCheques.Controls.Add(Me.Label15)
        Me.groupCheques.Controls.Add(Me.txtCliente)
        Me.groupCheques.Controls.Add(Me.btnEliminarCheque)
        Me.groupCheques.Controls.Add(Me.Label13)
        Me.groupCheques.Controls.Add(Me.lbltotalCheques)
        Me.groupCheques.Controls.Add(Me.Label11)
        Me.groupCheques.Controls.Add(Me.btnGuardar)
        Me.groupCheques.Controls.Add(Me.Label10)
        Me.groupCheques.Controls.Add(Me.dtpFecEmision)
        Me.groupCheques.Controls.Add(Me.txtImporte)
        Me.groupCheques.Controls.Add(Me.Label9)
        Me.groupCheques.Controls.Add(Me.txtNroCheque)
        Me.groupCheques.Controls.Add(Me.cmbBanco)
        Me.groupCheques.Controls.Add(Me.Label8)
        Me.groupCheques.Controls.Add(Me.Label5)
        Me.groupCheques.Controls.Add(Me.lvwConsulta)
        Me.groupCheques.ForeColor = System.Drawing.Color.Gainsboro
        Me.groupCheques.Location = New System.Drawing.Point(8, 111)
        Me.groupCheques.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.groupCheques.Name = "groupCheques"
        Me.groupCheques.Padding = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.groupCheques.Size = New System.Drawing.Size(775, 385)
        Me.groupCheques.TabIndex = 6
        Me.groupCheques.TabStop = False
        Me.groupCheques.Text = "Detalle de Cheques"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chkCertificado)
        Me.GroupBox4.Controls.Add(Me.chkCruzado)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Gainsboro
        Me.GroupBox4.Location = New System.Drawing.Point(230, 95)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.GroupBox4.Size = New System.Drawing.Size(90, 85)
        Me.GroupBox4.TabIndex = 20
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Cobro"
        '
        'chkCertificado
        '
        Me.chkCertificado.AutoSize = True
        Me.chkCertificado.Location = New System.Drawing.Point(12, 49)
        Me.chkCertificado.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.chkCertificado.Name = "chkCertificado"
        Me.chkCertificado.Size = New System.Drawing.Size(76, 17)
        Me.chkCertificado.TabIndex = 56
        Me.chkCertificado.Text = "Certificado"
        Me.chkCertificado.UseVisualStyleBackColor = True
        '
        'chkCruzado
        '
        Me.chkCruzado.AutoSize = True
        Me.chkCruzado.Checked = True
        Me.chkCruzado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCruzado.Location = New System.Drawing.Point(12, 26)
        Me.chkCruzado.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.chkCruzado.Name = "chkCruzado"
        Me.chkCruzado.Size = New System.Drawing.Size(65, 17)
        Me.chkCruzado.TabIndex = 55
        Me.chkCruzado.Text = "Cruzado"
        Me.chkCruzado.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.optTerceros)
        Me.GroupBox3.Controls.Add(Me.optDirecto)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Gainsboro
        Me.GroupBox3.Location = New System.Drawing.Point(137, 95)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.GroupBox3.Size = New System.Drawing.Size(87, 85)
        Me.GroupBox3.TabIndex = 19
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Origen"
        '
        'optTerceros
        '
        Me.optTerceros.AutoSize = True
        Me.optTerceros.Location = New System.Drawing.Point(11, 49)
        Me.optTerceros.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.optTerceros.Name = "optTerceros"
        Me.optTerceros.Size = New System.Drawing.Size(67, 17)
        Me.optTerceros.TabIndex = 3
        Me.optTerceros.Text = "Terceros"
        Me.optTerceros.UseVisualStyleBackColor = True
        '
        'optDirecto
        '
        Me.optDirecto.AutoSize = True
        Me.optDirecto.Checked = True
        Me.optDirecto.Location = New System.Drawing.Point(11, 25)
        Me.optDirecto.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.optDirecto.Name = "optDirecto"
        Me.optDirecto.Size = New System.Drawing.Size(59, 17)
        Me.optDirecto.TabIndex = 2
        Me.optDirecto.TabStop = True
        Me.optDirecto.Text = "Directo"
        Me.optDirecto.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.optAlPortador)
        Me.GroupBox2.Controls.Add(Me.optNoAlaOrden)
        Me.GroupBox2.Controls.Add(Me.optAlaOrden)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Gainsboro
        Me.GroupBox2.Location = New System.Drawing.Point(21, 95)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.GroupBox2.Size = New System.Drawing.Size(109, 85)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Beficiario"
        '
        'optAlPortador
        '
        Me.optAlPortador.AutoSize = True
        Me.optAlPortador.Location = New System.Drawing.Point(14, 65)
        Me.optAlPortador.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.optAlPortador.Name = "optAlPortador"
        Me.optAlPortador.Size = New System.Drawing.Size(77, 17)
        Me.optAlPortador.TabIndex = 2
        Me.optAlPortador.Text = "Al Portador"
        Me.optAlPortador.UseVisualStyleBackColor = True
        '
        'optNoAlaOrden
        '
        Me.optNoAlaOrden.AutoSize = True
        Me.optNoAlaOrden.Checked = True
        Me.optNoAlaOrden.Location = New System.Drawing.Point(14, 19)
        Me.optNoAlaOrden.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.optNoAlaOrden.Name = "optNoAlaOrden"
        Me.optNoAlaOrden.Size = New System.Drawing.Size(91, 17)
        Me.optNoAlaOrden.TabIndex = 1
        Me.optNoAlaOrden.TabStop = True
        Me.optNoAlaOrden.Text = "No a la Orden"
        Me.optNoAlaOrden.UseVisualStyleBackColor = True
        '
        'optAlaOrden
        '
        Me.optAlaOrden.AutoSize = True
        Me.optAlaOrden.Location = New System.Drawing.Point(14, 41)
        Me.optAlaOrden.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.optAlaOrden.Name = "optAlaOrden"
        Me.optAlaOrden.Size = New System.Drawing.Size(75, 17)
        Me.optAlaOrden.TabIndex = 0
        Me.optAlaOrden.Text = "A la Orden"
        Me.optAlaOrden.UseVisualStyleBackColor = True
        '
        'txtObservac
        '
        Me.txtObservac.Location = New System.Drawing.Point(98, 189)
        Me.txtObservac.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.txtObservac.Multiline = True
        Me.txtObservac.Name = "txtObservac"
        Me.txtObservac.Size = New System.Drawing.Size(668, 25)
        Me.txtObservac.TabIndex = 23
        '
        'btnBusq
        '
        Me.btnBusq.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnBusq.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBusq.Location = New System.Drawing.Point(467, 62)
        Me.btnBusq.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnBusq.Name = "btnBusq"
        Me.btnBusq.Size = New System.Drawing.Size(21, 21)
        Me.btnBusq.TabIndex = 16
        Me.btnBusq.Text = "..."
        Me.btnBusq.UseVisualStyleBackColor = False
        '
        'lblNomCliente
        '
        Me.lblNomCliente.AutoSize = True
        Me.lblNomCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNomCliente.Location = New System.Drawing.Point(493, 66)
        Me.lblNomCliente.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.lblNomCliente.Name = "lblNomCliente"
        Me.lblNomCliente.Size = New System.Drawing.Size(85, 13)
        Me.lblNomCliente.TabIndex = 29
        Me.lblNomCliente.Text = "_____________"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(330, 63)
        Me.Label15.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(42, 13)
        Me.Label15.TabIndex = 28
        Me.Label15.Text = "Cliente:"
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(376, 63)
        Me.txtCliente.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(90, 20)
        Me.txtCliente.TabIndex = 15
        Me.txtCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnEliminarCheque
        '
        Me.btnEliminarCheque.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminarCheque.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnEliminarCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminarCheque.Image = CType(resources.GetObject("btnEliminarCheque.Image"), System.Drawing.Image)
        Me.btnEliminarCheque.Location = New System.Drawing.Point(643, 117)
        Me.btnEliminarCheque.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnEliminarCheque.Name = "btnEliminarCheque"
        Me.btnEliminarCheque.Size = New System.Drawing.Size(51, 35)
        Me.btnEliminarCheque.TabIndex = 22
        Me.btnEliminarCheque.UseVisualStyleBackColor = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(15, 189)
        Me.Label13.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(81, 13)
        Me.Label13.TabIndex = 25
        Me.Label13.Text = "Observaciones:"
        '
        'lbltotalCheques
        '
        Me.lbltotalCheques.AutoSize = True
        Me.lbltotalCheques.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalCheques.Location = New System.Drawing.Point(574, 369)
        Me.lbltotalCheques.Name = "lbltotalCheques"
        Me.lbltotalCheques.Size = New System.Drawing.Size(25, 13)
        Me.lbltotalCheques.TabIndex = 24
        Me.lbltotalCheques.Text = "$ 0"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(487, 369)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(82, 13)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Total Cheques: "
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(578, 117)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(51, 35)
        Me.btnGuardar.TabIndex = 21
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(339, 29)
        Me.Label10.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(85, 13)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Fecha De Pago:"
        '
        'dtpFecEmision
        '
        Me.dtpFecEmision.CustomFormat = "dd/MM/yyyy"
        Me.dtpFecEmision.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFecEmision.Location = New System.Drawing.Point(426, 29)
        Me.dtpFecEmision.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.dtpFecEmision.Name = "dtpFecEmision"
        Me.dtpFecEmision.Size = New System.Drawing.Size(99, 20)
        Me.dtpFecEmision.TabIndex = 10
        '
        'txtImporte
        '
        Me.txtImporte.Location = New System.Drawing.Point(236, 29)
        Me.txtImporte.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.Size = New System.Drawing.Size(81, 20)
        Me.txtImporte.TabIndex = 9
        Me.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(189, 29)
        Me.Label9.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Importe:"
        '
        'txtNroCheque
        '
        Me.txtNroCheque.Location = New System.Drawing.Point(82, 29)
        Me.txtNroCheque.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.txtNroCheque.Name = "txtNroCheque"
        Me.txtNroCheque.Size = New System.Drawing.Size(100, 20)
        Me.txtNroCheque.TabIndex = 8
        '
        'cmbBanco
        '
        Me.cmbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBanco.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbBanco.FormattingEnabled = True
        Me.cmbBanco.Location = New System.Drawing.Point(62, 63)
        Me.cmbBanco.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.cmbBanco.Name = "cmbBanco"
        Me.cmbBanco.Size = New System.Drawing.Size(247, 21)
        Me.cmbBanco.TabIndex = 11
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(15, 63)
        Me.Label8.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Banco:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 29)
        Me.Label5.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Cheque Nro:"
        '
        'lvwConsulta
        '
        Me.lvwConsulta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwConsulta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvwConsulta.FullRowSelect = True
        Me.lvwConsulta.GridLines = True
        Me.lvwConsulta.Location = New System.Drawing.Point(15, 217)
        Me.lvwConsulta.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lvwConsulta.Name = "lvwConsulta"
        Me.lvwConsulta.Size = New System.Drawing.Size(754, 149)
        Me.lvwConsulta.TabIndex = 5
        Me.lvwConsulta.UseCompatibleStateImageBehavior = False
        Me.lvwConsulta.View = System.Windows.Forms.View.Details
        '
        'groupGeneral
        '
        Me.groupGeneral.Controls.Add(Me.PicTransfDet)
        Me.groupGeneral.Controls.Add(Me.txtTotalCheques)
        Me.groupGeneral.Controls.Add(Me.Label12)
        Me.groupGeneral.Controls.Add(Me.lblTotalLiq)
        Me.groupGeneral.Controls.Add(Me.Label14)
        Me.groupGeneral.Controls.Add(Me.cmbVendedores)
        Me.groupGeneral.Controls.Add(Me.Label7)
        Me.groupGeneral.Controls.Add(Me.txtTotalRet)
        Me.groupGeneral.Controls.Add(Me.Label6)
        Me.groupGeneral.Controls.Add(Me.txtTotalEfectivo)
        Me.groupGeneral.Controls.Add(Me.txtTotalTransf)
        Me.groupGeneral.Controls.Add(Me.txtTotalNC)
        Me.groupGeneral.Controls.Add(Me.Label4)
        Me.groupGeneral.Controls.Add(Me.Label3)
        Me.groupGeneral.Controls.Add(Me.Label2)
        Me.groupGeneral.Controls.Add(Me.Label1)
        Me.groupGeneral.Controls.Add(Me.dtpFechaLiq)
        Me.groupGeneral.ForeColor = System.Drawing.Color.Gainsboro
        Me.groupGeneral.Location = New System.Drawing.Point(8, 15)
        Me.groupGeneral.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.groupGeneral.Name = "groupGeneral"
        Me.groupGeneral.Padding = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.groupGeneral.Size = New System.Drawing.Size(775, 93)
        Me.groupGeneral.TabIndex = 5
        Me.groupGeneral.TabStop = False
        Me.groupGeneral.Text = "Datos Generales"
        '
        'PicTransfDet
        '
        Me.PicTransfDet.Image = Global.Venezia.My.Resources.Resources.pencil
        Me.PicTransfDet.Location = New System.Drawing.Point(462, 59)
        Me.PicTransfDet.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.PicTransfDet.Name = "PicTransfDet"
        Me.PicTransfDet.Size = New System.Drawing.Size(22, 23)
        Me.PicTransfDet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicTransfDet.TabIndex = 29
        Me.PicTransfDet.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PicTransfDet, "Detalle de Transferencias")
        '
        'txtTotalCheques
        '
        Me.txtTotalCheques.Location = New System.Drawing.Point(200, 61)
        Me.txtTotalCheques.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.txtTotalCheques.Name = "txtTotalCheques"
        Me.txtTotalCheques.Size = New System.Drawing.Size(87, 20)
        Me.txtTotalCheques.TabIndex = 4
        Me.txtTotalCheques.Text = "0"
        Me.txtTotalCheques.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(146, 61)
        Me.Label12.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 13)
        Me.Label12.TabIndex = 28
        Me.Label12.Text = "Cheques:"
        '
        'lblTotalLiq
        '
        Me.lblTotalLiq.AutoSize = True
        Me.lblTotalLiq.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.900001!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalLiq.Location = New System.Drawing.Point(672, 20)
        Me.lblTotalLiq.Name = "lblTotalLiq"
        Me.lblTotalLiq.Size = New System.Drawing.Size(31, 17)
        Me.lblTotalLiq.TabIndex = 26
        Me.lblTotalLiq.Text = "$ 0"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.900001!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(625, 20)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(50, 17)
        Me.Label14.TabIndex = 25
        Me.Label14.Text = "Total:"
        '
        'cmbVendedores
        '
        Me.cmbVendedores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVendedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbVendedores.FormattingEnabled = True
        Me.cmbVendedores.Location = New System.Drawing.Point(303, 20)
        Me.cmbVendedores.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.cmbVendedores.Name = "cmbVendedores"
        Me.cmbVendedores.Size = New System.Drawing.Size(277, 21)
        Me.cmbVendedores.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(244, 20)
        Me.Label7.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Vendedor:"
        '
        'txtTotalRet
        '
        Me.txtTotalRet.Location = New System.Drawing.Point(563, 61)
        Me.txtTotalRet.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.txtTotalRet.Name = "txtTotalRet"
        Me.txtTotalRet.Size = New System.Drawing.Size(80, 20)
        Me.txtTotalRet.TabIndex = 6
        Me.txtTotalRet.Text = "0"
        Me.txtTotalRet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(491, 61)
        Me.Label6.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Retenciones:"
        '
        'txtTotalEfectivo
        '
        Me.txtTotalEfectivo.Location = New System.Drawing.Point(59, 61)
        Me.txtTotalEfectivo.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.txtTotalEfectivo.Name = "txtTotalEfectivo"
        Me.txtTotalEfectivo.Size = New System.Drawing.Size(81, 20)
        Me.txtTotalEfectivo.TabIndex = 3
        Me.txtTotalEfectivo.Text = "0"
        Me.txtTotalEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalTransf
        '
        Me.txtTotalTransf.Location = New System.Drawing.Point(374, 61)
        Me.txtTotalTransf.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.txtTotalTransf.Name = "txtTotalTransf"
        Me.txtTotalTransf.Size = New System.Drawing.Size(88, 20)
        Me.txtTotalTransf.TabIndex = 5
        Me.txtTotalTransf.Text = "0"
        Me.txtTotalTransf.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalNC
        '
        Me.txtTotalNC.Location = New System.Drawing.Point(678, 61)
        Me.txtTotalNC.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.txtTotalNC.Name = "txtTotalNC"
        Me.txtTotalNC.Size = New System.Drawing.Size(87, 20)
        Me.txtTotalNC.TabIndex = 7
        Me.txtTotalNC.Text = "0"
        Me.txtTotalNC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(649, 61)
        Me.Label4.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(25, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "NC:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(295, 61)
        Me.Label3.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Transferencias:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 61)
        Me.Label2.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Efectivo:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 20)
        Me.Label1.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Fecha De Liquidacion:"
        '
        'dtpFechaLiq
        '
        Me.dtpFechaLiq.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaLiq.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaLiq.Location = New System.Drawing.Point(135, 20)
        Me.dtpFechaLiq.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.dtpFechaLiq.Name = "dtpFechaLiq"
        Me.dtpFechaLiq.Size = New System.Drawing.Size(99, 20)
        Me.dtpFechaLiq.TabIndex = 1
        '
        'frmTesoLiquidacionesAlta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(800, 541)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.Name = "frmTesoLiquidacionesAlta"
        Me.Text = "Alta de Liquidacion"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.groupCheques.ResumeLayout(False)
        Me.groupCheques.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.groupGeneral.ResumeLayout(False)
        Me.groupGeneral.PerformLayout()
        CType(Me.PicTransfDet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents groupCheques As GroupBox
    Friend WithEvents lvwConsulta As ListView
    Friend WithEvents groupGeneral As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpFechaLiq As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbVendedores As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtTotalRet As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtTotalEfectivo As TextBox
    Friend WithEvents txtTotalTransf As TextBox
    Friend WithEvents txtTotalNC As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents dtpFecEmision As DateTimePicker
    Friend WithEvents txtImporte As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtNroCheque As TextBox
    Friend WithEvents cmbBanco As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents btnAceptar As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents lbltotalCheques As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents btnEliminarCheque As Button
    Friend WithEvents lblTotalLiq As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txtTotalCheques As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents lblEst As Label
    Friend WithEvents lblEstado As Label
    Friend WithEvents btnBusq As Button
    Friend WithEvents lblNomCliente As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents txtCliente As TextBox
    Friend WithEvents txtObservac As TextBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents chkCertificado As CheckBox
    Friend WithEvents chkCruzado As CheckBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents optTerceros As RadioButton
    Friend WithEvents optDirecto As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents optAlPortador As RadioButton
    Friend WithEvents optNoAlaOrden As RadioButton
    Friend WithEvents optAlaOrden As RadioButton
    Friend WithEvents PicTransfDet As PictureBox
    Friend WithEvents ToolTip1 As ToolTip
End Class
