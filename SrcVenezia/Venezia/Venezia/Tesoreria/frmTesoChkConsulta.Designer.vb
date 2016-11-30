<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTesoChkConsulta
    Inherits TemplateForm

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
        Me.lvwConsulta = New System.Windows.Forms.ListView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.pnlExportar = New System.Windows.Forms.Panel()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbCampos = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.optDescendente = New System.Windows.Forms.RadioButton()
        Me.optAscendente = New System.Windows.Forms.RadioButton()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnGenOrdenPago = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbOrden = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbDirecto = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbCruzado = New System.Windows.Forms.ComboBox()
        Me.txtNroCheque = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnBusq = New System.Windows.Forms.Button()
        Me.lblNomCliente = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.cmbBanco = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpFPagoD = New System.Windows.Forms.DateTimePicker()
        Me.dtpFPagoH = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnAplicar = New System.Windows.Forms.Button()
        Me.cmbEstados = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.btnVerDetalle = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        Me.pnlExportar.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvwConsulta
        '
        Me.lvwConsulta.CheckBoxes = True
        Me.lvwConsulta.FullRowSelect = True
        Me.lvwConsulta.GridLines = True
        Me.lvwConsulta.Location = New System.Drawing.Point(6, 16)
        Me.lvwConsulta.Margin = New System.Windows.Forms.Padding(1)
        Me.lvwConsulta.Name = "lvwConsulta"
        Me.lvwConsulta.Size = New System.Drawing.Size(889, 325)
        Me.lvwConsulta.TabIndex = 0
        Me.lvwConsulta.UseCompatibleStateImageBehavior = False
        Me.lvwConsulta.View = System.Windows.Forms.View.Details
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.pnlExportar)
        Me.GroupBox2.Controls.Add(Me.lblTotal)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.lvwConsulta)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Gainsboro
        Me.GroupBox2.Location = New System.Drawing.Point(8, 90)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(1)
        Me.GroupBox2.Size = New System.Drawing.Size(894, 369)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Cheques"
        '
        'pnlExportar
        '
        Me.pnlExportar.Controls.Add(Me.btnOK)
        Me.pnlExportar.Controls.Add(Me.Label9)
        Me.pnlExportar.Controls.Add(Me.cmbCampos)
        Me.pnlExportar.Controls.Add(Me.GroupBox3)
        Me.pnlExportar.Location = New System.Drawing.Point(1, 239)
        Me.pnlExportar.Name = "pnlExportar"
        Me.pnlExportar.Size = New System.Drawing.Size(342, 102)
        Me.pnlExportar.TabIndex = 29
        Me.pnlExportar.Visible = False
        '
        'btnOK
        '
        Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Location = New System.Drawing.Point(268, 34)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(1)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 37)
        Me.btnOK.TabIndex = 55
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(13, 18)
        Me.Label9.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 13)
        Me.Label9.TabIndex = 52
        Me.Label9.Text = "Ordenar por:"
        '
        'cmbCampos
        '
        Me.cmbCampos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCampos.FormattingEnabled = True
        Me.cmbCampos.Location = New System.Drawing.Point(16, 37)
        Me.cmbCampos.Name = "cmbCampos"
        Me.cmbCampos.Size = New System.Drawing.Size(121, 21)
        Me.cmbCampos.TabIndex = 1
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.optDescendente)
        Me.GroupBox3.Controls.Add(Me.optAscendente)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Gainsboro
        Me.GroupBox3.Location = New System.Drawing.Point(143, 18)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(110, 63)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Orden"
        '
        'optDescendente
        '
        Me.optDescendente.AutoSize = True
        Me.optDescendente.Location = New System.Drawing.Point(15, 39)
        Me.optDescendente.Name = "optDescendente"
        Me.optDescendente.Size = New System.Drawing.Size(89, 17)
        Me.optDescendente.TabIndex = 1
        Me.optDescendente.Text = "Descendente"
        Me.optDescendente.UseVisualStyleBackColor = True
        '
        'optAscendente
        '
        Me.optAscendente.AutoSize = True
        Me.optAscendente.Checked = True
        Me.optAscendente.Location = New System.Drawing.Point(15, 16)
        Me.optAscendente.Name = "optAscendente"
        Me.optAscendente.Size = New System.Drawing.Size(82, 17)
        Me.optAscendente.TabIndex = 0
        Me.optAscendente.TabStop = True
        Me.optAscendente.Text = "Ascendente"
        Me.optAscendente.UseVisualStyleBackColor = True
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.900001!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(630, 343)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(28, 17)
        Me.lblTotal.TabIndex = 28
        Me.lblTotal.Text = "$ 0"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.900001!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(575, 343)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(44, 17)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "Total:"
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Location = New System.Drawing.Point(806, 461)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(1)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(95, 21)
        Me.btnSalir.TabIndex = 17
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'btnGenOrdenPago
        '
        Me.btnGenOrdenPago.AutoSize = True
        Me.btnGenOrdenPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenOrdenPago.Location = New System.Drawing.Point(700, 461)
        Me.btnGenOrdenPago.Margin = New System.Windows.Forms.Padding(1)
        Me.btnGenOrdenPago.Name = "btnGenOrdenPago"
        Me.btnGenOrdenPago.Size = New System.Drawing.Size(102, 23)
        Me.btnGenOrdenPago.TabIndex = 16
        Me.btnGenOrdenPago.Text = "Orden de Pago"
        Me.btnGenOrdenPago.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cmbOrden)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cmbDirecto)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmbCruzado)
        Me.GroupBox1.Controls.Add(Me.txtNroCheque)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.btnBusq)
        Me.GroupBox1.Controls.Add(Me.lblNomCliente)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtCliente)
        Me.GroupBox1.Controls.Add(Me.cmbBanco)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.dtpFPagoD)
        Me.GroupBox1.Controls.Add(Me.dtpFPagoH)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btnAplicar)
        Me.GroupBox1.Controls.Add(Me.cmbEstados)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Gainsboro
        Me.GroupBox1.Location = New System.Drawing.Point(8, 6)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(1)
        Me.GroupBox1.Size = New System.Drawing.Size(892, 82)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros de Busqueda"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(702, 22)
        Me.Label6.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 53
        Me.Label6.Text = "Orden:"
        '
        'cmbOrden
        '
        Me.cmbOrden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOrden.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbOrden.FormattingEnabled = True
        Me.cmbOrden.Location = New System.Drawing.Point(743, 22)
        Me.cmbOrden.Margin = New System.Windows.Forms.Padding(1)
        Me.cmbOrden.Name = "cmbOrden"
        Me.cmbOrden.Size = New System.Drawing.Size(40, 21)
        Me.cmbOrden.TabIndex = 52
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(611, 22)
        Me.Label4.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 51
        Me.Label4.Text = "Directo:"
        '
        'cmbDirecto
        '
        Me.cmbDirecto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDirecto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbDirecto.FormattingEnabled = True
        Me.cmbDirecto.Location = New System.Drawing.Point(659, 22)
        Me.cmbDirecto.Margin = New System.Windows.Forms.Padding(1)
        Me.cmbDirecto.Name = "cmbDirecto"
        Me.cmbDirecto.Size = New System.Drawing.Size(40, 21)
        Me.cmbDirecto.TabIndex = 50
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(518, 22)
        Me.Label3.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 49
        Me.Label3.Text = "Cruzado:"
        '
        'cmbCruzado
        '
        Me.cmbCruzado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCruzado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbCruzado.FormattingEnabled = True
        Me.cmbCruzado.Location = New System.Drawing.Point(571, 22)
        Me.cmbCruzado.Margin = New System.Windows.Forms.Padding(1)
        Me.cmbCruzado.Name = "cmbCruzado"
        Me.cmbCruzado.Size = New System.Drawing.Size(40, 21)
        Me.cmbCruzado.TabIndex = 48
        '
        'txtNroCheque
        '
        Me.txtNroCheque.Location = New System.Drawing.Point(416, 22)
        Me.txtNroCheque.Margin = New System.Windows.Forms.Padding(1)
        Me.txtNroCheque.Name = "txtNroCheque"
        Me.txtNroCheque.Size = New System.Drawing.Size(98, 20)
        Me.txtNroCheque.TabIndex = 47
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(349, 22)
        Me.Label5.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 46
        Me.Label5.Text = "Cheque Nro:"
        '
        'btnBusq
        '
        Me.btnBusq.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnBusq.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBusq.Location = New System.Drawing.Point(580, 51)
        Me.btnBusq.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBusq.Name = "btnBusq"
        Me.btnBusq.Size = New System.Drawing.Size(21, 21)
        Me.btnBusq.TabIndex = 43
        Me.btnBusq.Text = "..."
        Me.btnBusq.UseVisualStyleBackColor = False
        '
        'lblNomCliente
        '
        Me.lblNomCliente.AutoSize = True
        Me.lblNomCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNomCliente.Location = New System.Drawing.Point(606, 51)
        Me.lblNomCliente.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.lblNomCliente.Name = "lblNomCliente"
        Me.lblNomCliente.Size = New System.Drawing.Size(115, 13)
        Me.lblNomCliente.TabIndex = 45
        Me.lblNomCliente.Text = "__________________"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(444, 51)
        Me.Label15.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(42, 13)
        Me.Label15.TabIndex = 44
        Me.Label15.Text = "Cliente:"
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(489, 51)
        Me.txtCliente.Margin = New System.Windows.Forms.Padding(1)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(90, 20)
        Me.txtCliente.TabIndex = 42
        Me.txtCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmbBanco
        '
        Me.cmbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBanco.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbBanco.FormattingEnabled = True
        Me.cmbBanco.Location = New System.Drawing.Point(218, 51)
        Me.cmbBanco.Margin = New System.Windows.Forms.Padding(1)
        Me.cmbBanco.Name = "cmbBanco"
        Me.cmbBanco.Size = New System.Drawing.Size(215, 21)
        Me.cmbBanco.TabIndex = 37
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(172, 51)
        Me.Label8.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 13)
        Me.Label8.TabIndex = 41
        Me.Label8.Text = "Banco:"
        '
        'dtpFPagoD
        '
        Me.dtpFPagoD.CustomFormat = "dd/MM/yyyy"
        Me.dtpFPagoD.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFPagoD.Location = New System.Drawing.Point(106, 22)
        Me.dtpFPagoD.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpFPagoD.Name = "dtpFPagoD"
        Me.dtpFPagoD.Size = New System.Drawing.Size(99, 20)
        Me.dtpFPagoD.TabIndex = 36
        '
        'dtpFPagoH
        '
        Me.dtpFPagoH.CustomFormat = "dd/MM/yyyy"
        Me.dtpFPagoH.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFPagoH.Location = New System.Drawing.Point(244, 22)
        Me.dtpFPagoH.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpFPagoH.Name = "dtpFPagoH"
        Me.dtpFPagoH.Size = New System.Drawing.Size(99, 20)
        Me.dtpFPagoH.TabIndex = 35
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(208, 22)
        Me.Label1.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Hasta:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 22)
        Me.Label2.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 13)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Fecha Pago Desde:"
        '
        'btnAplicar
        '
        Me.btnAplicar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAplicar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAplicar.Location = New System.Drawing.Point(807, 15)
        Me.btnAplicar.Margin = New System.Windows.Forms.Padding(1)
        Me.btnAplicar.Name = "btnAplicar"
        Me.btnAplicar.Size = New System.Drawing.Size(78, 30)
        Me.btnAplicar.TabIndex = 31
        Me.btnAplicar.Text = "&Aplicar"
        Me.btnAplicar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAplicar.UseVisualStyleBackColor = False
        '
        'cmbEstados
        '
        Me.cmbEstados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstados.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbEstados.FormattingEnabled = True
        Me.cmbEstados.Location = New System.Drawing.Point(49, 51)
        Me.cmbEstados.Margin = New System.Windows.Forms.Padding(1)
        Me.cmbEstados.Name = "cmbEstados"
        Me.cmbEstados.Size = New System.Drawing.Size(117, 21)
        Me.cmbEstados.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(5, 51)
        Me.Label7.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Estado:"
        '
        'btnExportar
        '
        Me.btnExportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportar.Location = New System.Drawing.Point(8, 462)
        Me.btnExportar.Margin = New System.Windows.Forms.Padding(1)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(78, 21)
        Me.btnExportar.TabIndex = 54
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.UseVisualStyleBackColor = False
        '
        'btnVerDetalle
        '
        Me.btnVerDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVerDetalle.Location = New System.Drawing.Point(94, 462)
        Me.btnVerDetalle.Margin = New System.Windows.Forms.Padding(1)
        Me.btnVerDetalle.Name = "btnVerDetalle"
        Me.btnVerDetalle.Size = New System.Drawing.Size(78, 21)
        Me.btnVerDetalle.TabIndex = 55
        Me.btnVerDetalle.Text = "Ver Detalle"
        Me.btnVerDetalle.UseVisualStyleBackColor = False
        '
        'frmTesoChkConsulta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(910, 485)
        Me.Controls.Add(Me.btnVerDetalle)
        Me.Controls.Add(Me.btnExportar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnGenOrdenPago)
        Me.Margin = New System.Windows.Forms.Padding(1)
        Me.Name = "frmTesoChkConsulta"
        Me.Text = "Consulta de Cheques"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.pnlExportar.ResumeLayout(False)
        Me.pnlExportar.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lvwConsulta As ListView
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lblTotal As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnGenOrdenPago As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnAplicar As Button
    Friend WithEvents cmbEstados As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpFPagoD As DateTimePicker
    Friend WithEvents dtpFPagoH As DateTimePicker
    Friend WithEvents btnBusq As Button
    Friend WithEvents lblNomCliente As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents txtCliente As TextBox
    Friend WithEvents cmbBanco As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtNroCheque As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbOrden As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbDirecto As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbCruzado As ComboBox
    Friend WithEvents btnExportar As Button
    Friend WithEvents btnVerDetalle As Button
    Friend WithEvents pnlExportar As Panel
    Friend WithEvents btnOK As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents cmbCampos As ComboBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents optDescendente As RadioButton
    Friend WithEvents optAscendente As RadioButton
End Class
