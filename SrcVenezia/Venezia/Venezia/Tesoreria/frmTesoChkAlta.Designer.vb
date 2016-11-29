<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTesoChkAlta
    Inherits TemplateForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.chkCertificado = New System.Windows.Forms.CheckBox()
        Me.chkCruzado = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.optTerceros = New System.Windows.Forms.RadioButton()
        Me.optDirecto = New System.Windows.Forms.RadioButton()
        Me.txtObservac = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.optAlPortador = New System.Windows.Forms.RadioButton()
        Me.optNoAlaOrden = New System.Windows.Forms.RadioButton()
        Me.optAlaOrden = New System.Windows.Forms.RadioButton()
        Me.btnBusq = New System.Windows.Forms.Button()
        Me.lblNomCliente = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtpFecPago = New System.Windows.Forms.DateTimePicker()
        Me.txtImporte = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtNroCheque = New System.Windows.Forms.TextBox()
        Me.cmbBanco = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblEstadoChk = New System.Windows.Forms.Label()
        Me.btnRechazado = New System.Windows.Forms.Button()
        Me.lblDatosLiquidaciones = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblDatosLiquidaciones)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.txtObservac)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.btnBusq)
        Me.GroupBox1.Controls.Add(Me.lblNomCliente)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtCliente)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.dtpFecPago)
        Me.GroupBox1.Controls.Add(Me.txtImporte)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtNroCheque)
        Me.GroupBox1.Controls.Add(Me.cmbBanco)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Gainsboro
        Me.GroupBox1.Location = New System.Drawing.Point(12, 42)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1343, 746)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos del Cheque"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chkCertificado)
        Me.GroupBox4.Controls.Add(Me.chkCruzado)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Gainsboro
        Me.GroupBox4.Location = New System.Drawing.Point(598, 312)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(241, 202)
        Me.GroupBox4.TabIndex = 9
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Cobro"
        '
        'chkCertificado
        '
        Me.chkCertificado.AutoSize = True
        Me.chkCertificado.Location = New System.Drawing.Point(31, 118)
        Me.chkCertificado.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chkCertificado.Name = "chkCertificado"
        Me.chkCertificado.Size = New System.Drawing.Size(190, 36)
        Me.chkCertificado.TabIndex = 56
        Me.chkCertificado.Text = "Certificado"
        Me.chkCertificado.UseVisualStyleBackColor = True
        '
        'chkCruzado
        '
        Me.chkCruzado.AutoSize = True
        Me.chkCruzado.Location = New System.Drawing.Point(31, 61)
        Me.chkCruzado.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chkCruzado.Name = "chkCruzado"
        Me.chkCruzado.Size = New System.Drawing.Size(160, 36)
        Me.chkCruzado.TabIndex = 55
        Me.chkCruzado.Text = "Cruzado"
        Me.chkCruzado.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.optTerceros)
        Me.GroupBox3.Controls.Add(Me.optDirecto)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Gainsboro
        Me.GroupBox3.Location = New System.Drawing.Point(350, 312)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(232, 202)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Origen"
        '
        'optTerceros
        '
        Me.optTerceros.AutoSize = True
        Me.optTerceros.Location = New System.Drawing.Point(30, 118)
        Me.optTerceros.Name = "optTerceros"
        Me.optTerceros.Size = New System.Drawing.Size(163, 36)
        Me.optTerceros.TabIndex = 3
        Me.optTerceros.Text = "Terceros"
        Me.optTerceros.UseVisualStyleBackColor = True
        '
        'optDirecto
        '
        Me.optDirecto.AutoSize = True
        Me.optDirecto.Checked = True
        Me.optDirecto.Location = New System.Drawing.Point(30, 60)
        Me.optDirecto.Name = "optDirecto"
        Me.optDirecto.Size = New System.Drawing.Size(142, 36)
        Me.optDirecto.TabIndex = 2
        Me.optDirecto.TabStop = True
        Me.optDirecto.Text = "Directo"
        Me.optDirecto.UseVisualStyleBackColor = True
        '
        'txtObservac
        '
        Me.txtObservac.Location = New System.Drawing.Point(254, 604)
        Me.txtObservac.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtObservac.Multiline = True
        Me.txtObservac.Name = "txtObservac"
        Me.txtObservac.ReadOnly = True
        Me.txtObservac.Size = New System.Drawing.Size(1066, 114)
        Me.txtObservac.TabIndex = 10
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.optAlPortador)
        Me.GroupBox2.Controls.Add(Me.optNoAlaOrden)
        Me.GroupBox2.Controls.Add(Me.optAlaOrden)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Gainsboro
        Me.GroupBox2.Location = New System.Drawing.Point(41, 312)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(290, 202)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Beficiario"
        '
        'optAlPortador
        '
        Me.optAlPortador.AutoSize = True
        Me.optAlPortador.Location = New System.Drawing.Point(38, 154)
        Me.optAlPortador.Name = "optAlPortador"
        Me.optAlPortador.Size = New System.Drawing.Size(194, 36)
        Me.optAlPortador.TabIndex = 2
        Me.optAlPortador.Text = "Al Portador"
        Me.optAlPortador.UseVisualStyleBackColor = True
        '
        'optNoAlaOrden
        '
        Me.optNoAlaOrden.AutoSize = True
        Me.optNoAlaOrden.Location = New System.Drawing.Point(38, 101)
        Me.optNoAlaOrden.Name = "optNoAlaOrden"
        Me.optNoAlaOrden.Size = New System.Drawing.Size(227, 36)
        Me.optNoAlaOrden.TabIndex = 1
        Me.optNoAlaOrden.Text = "No a la Orden"
        Me.optNoAlaOrden.UseVisualStyleBackColor = True
        '
        'optAlaOrden
        '
        Me.optAlaOrden.AutoSize = True
        Me.optAlaOrden.Checked = True
        Me.optAlaOrden.Location = New System.Drawing.Point(38, 44)
        Me.optAlaOrden.Name = "optAlaOrden"
        Me.optAlaOrden.Size = New System.Drawing.Size(187, 36)
        Me.optAlaOrden.TabIndex = 0
        Me.optAlaOrden.TabStop = True
        Me.optAlaOrden.Text = "A la Orden"
        Me.optAlaOrden.UseVisualStyleBackColor = True
        '
        'btnBusq
        '
        Me.btnBusq.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnBusq.Enabled = False
        Me.btnBusq.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBusq.Location = New System.Drawing.Point(401, 219)
        Me.btnBusq.Margin = New System.Windows.Forms.Padding(11, 10, 11, 10)
        Me.btnBusq.Name = "btnBusq"
        Me.btnBusq.Size = New System.Drawing.Size(55, 50)
        Me.btnBusq.TabIndex = 6
        Me.btnBusq.Text = "..."
        Me.btnBusq.UseVisualStyleBackColor = False
        '
        'lblNomCliente
        '
        Me.lblNomCliente.AutoSize = True
        Me.lblNomCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNomCliente.Location = New System.Drawing.Point(469, 229)
        Me.lblNomCliente.Name = "lblNomCliente"
        Me.lblNomCliente.Size = New System.Drawing.Size(210, 32)
        Me.lblNomCliente.TabIndex = 65
        Me.lblNomCliente.Text = "_____________"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(35, 226)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(113, 32)
        Me.Label15.TabIndex = 64
        Me.Label15.Text = "Cliente:"
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(158, 226)
        Me.txtCliente.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(233, 38)
        Me.txtCliente.TabIndex = 5
        Me.txtCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(35, 604)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(213, 32)
        Me.Label13.TabIndex = 63
        Me.Label13.Text = "Observaciones:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(832, 67)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(219, 32)
        Me.Label10.TabIndex = 62
        Me.Label10.Text = "Fecha De Pago:"
        '
        'dtpFecPago
        '
        Me.dtpFecPago.CustomFormat = "dd/MM/yyyy"
        Me.dtpFecPago.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFecPago.Location = New System.Drawing.Point(1063, 67)
        Me.dtpFecPago.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtpFecPago.Name = "dtpFecPago"
        Me.dtpFecPago.Size = New System.Drawing.Size(257, 38)
        Me.dtpFecPago.TabIndex = 3
        '
        'txtImporte
        '
        Me.txtImporte.Location = New System.Drawing.Point(580, 67)
        Me.txtImporte.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.ReadOnly = True
        Me.txtImporte.Size = New System.Drawing.Size(209, 38)
        Me.txtImporte.TabIndex = 2
        Me.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(457, 67)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(118, 32)
        Me.Label9.TabIndex = 60
        Me.Label9.Text = "Importe:"
        '
        'txtNroCheque
        '
        Me.txtNroCheque.Location = New System.Drawing.Point(214, 67)
        Me.txtNroCheque.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtNroCheque.Name = "txtNroCheque"
        Me.txtNroCheque.ReadOnly = True
        Me.txtNroCheque.Size = New System.Drawing.Size(209, 38)
        Me.txtNroCheque.TabIndex = 1
        '
        'cmbBanco
        '
        Me.cmbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBanco.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbBanco.FormattingEnabled = True
        Me.cmbBanco.Location = New System.Drawing.Point(158, 148)
        Me.cmbBanco.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbBanco.Name = "cmbBanco"
        Me.cmbBanco.Size = New System.Drawing.Size(652, 39)
        Me.cmbBanco.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(35, 148)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 32)
        Me.Label8.TabIndex = 56
        Me.Label8.Text = "Banco:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(35, 67)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(175, 32)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "Cheque Nro:"
        '
        'btnSalir
        '
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Location = New System.Drawing.Point(1063, 812)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(269, 53)
        Me.btnSalir.TabIndex = 1
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(920, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 32)
        Me.Label1.TabIndex = 66
        Me.Label1.Text = "Estado:"
        '
        'lblEstadoChk
        '
        Me.lblEstadoChk.AutoSize = True
        Me.lblEstadoChk.Location = New System.Drawing.Point(1057, 7)
        Me.lblEstadoChk.Name = "lblEstadoChk"
        Me.lblEstadoChk.Size = New System.Drawing.Size(141, 32)
        Me.lblEstadoChk.TabIndex = 67
        Me.lblEstadoChk.Text = "Liquidado"
        '
        'btnRechazado
        '
        Me.btnRechazado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRechazado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRechazado.Location = New System.Drawing.Point(9, 812)
        Me.btnRechazado.Name = "btnRechazado"
        Me.btnRechazado.Size = New System.Drawing.Size(269, 53)
        Me.btnRechazado.TabIndex = 11
        Me.btnRechazado.Text = "Rechazado"
        Me.btnRechazado.UseVisualStyleBackColor = True
        '
        'lblDatosLiquidaciones
        '
        Me.lblDatosLiquidaciones.AutoSize = True
        Me.lblDatosLiquidaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatosLiquidaciones.Location = New System.Drawing.Point(35, 544)
        Me.lblDatosLiquidaciones.Name = "lblDatosLiquidaciones"
        Me.lblDatosLiquidaciones.Size = New System.Drawing.Size(483, 32)
        Me.lblDatosLiquidaciones.TabIndex = 66
        Me.lblDatosLiquidaciones.Text = "Datos de las liquidaciones asociadas"
        '
        'frmTesoChkAlta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 31.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1375, 890)
        Me.Controls.Add(Me.btnRechazado)
        Me.Controls.Add(Me.lblEstadoChk)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmTesoChkAlta"
        Me.Text = "Cheque "
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtObservac As TextBox
    Friend WithEvents btnBusq As Button
    Friend WithEvents lblNomCliente As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents txtCliente As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents dtpFecPago As DateTimePicker
    Friend WithEvents txtImporte As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtNroCheque As TextBox
    Friend WithEvents cmbBanco As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btnSalir As Button
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
    Friend WithEvents Label1 As Label
    Friend WithEvents lblEstadoChk As Label
    Friend WithEvents btnRechazado As Button
    Friend WithEvents lblDatosLiquidaciones As Label
End Class
