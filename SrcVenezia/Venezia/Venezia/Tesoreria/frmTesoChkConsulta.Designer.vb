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
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvwConsulta
        '
        Me.lvwConsulta.CheckBoxes = True
        Me.lvwConsulta.FullRowSelect = True
        Me.lvwConsulta.GridLines = True
        Me.lvwConsulta.Location = New System.Drawing.Point(17, 37)
        Me.lvwConsulta.Name = "lvwConsulta"
        Me.lvwConsulta.Size = New System.Drawing.Size(2363, 770)
        Me.lvwConsulta.TabIndex = 0
        Me.lvwConsulta.UseCompatibleStateImageBehavior = False
        Me.lvwConsulta.View = System.Windows.Forms.View.Details
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblTotal)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.lvwConsulta)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Gainsboro
        Me.GroupBox2.Location = New System.Drawing.Point(22, 215)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(2385, 880)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Cheques"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.900001!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(1681, 818)
        Me.lblTotal.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(64, 39)
        Me.lblTotal.TabIndex = 28
        Me.lblTotal.Text = "$ 0"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.900001!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(1534, 818)
        Me.Label14.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(102, 39)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "Total:"
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Location = New System.Drawing.Point(2148, 1099)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(253, 50)
        Me.btnSalir.TabIndex = 17
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'btnGenOrdenPago
        '
        Me.btnGenOrdenPago.AutoSize = True
        Me.btnGenOrdenPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenOrdenPago.Location = New System.Drawing.Point(1866, 1099)
        Me.btnGenOrdenPago.Name = "btnGenOrdenPago"
        Me.btnGenOrdenPago.Size = New System.Drawing.Size(253, 50)
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
        Me.GroupBox1.Location = New System.Drawing.Point(22, 14)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(2379, 195)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros de Busqueda"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(1872, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 32)
        Me.Label6.TabIndex = 53
        Me.Label6.Text = "Orden:"
        '
        'cmbOrden
        '
        Me.cmbOrden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOrden.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbOrden.FormattingEnabled = True
        Me.cmbOrden.Location = New System.Drawing.Point(1981, 52)
        Me.cmbOrden.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbOrden.Name = "cmbOrden"
        Me.cmbOrden.Size = New System.Drawing.Size(100, 39)
        Me.cmbOrden.TabIndex = 52
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(1629, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 32)
        Me.Label4.TabIndex = 51
        Me.Label4.Text = "Directo:"
        '
        'cmbDirecto
        '
        Me.cmbDirecto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDirecto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbDirecto.FormattingEnabled = True
        Me.cmbDirecto.Location = New System.Drawing.Point(1757, 52)
        Me.cmbDirecto.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbDirecto.Name = "cmbDirecto"
        Me.cmbDirecto.Size = New System.Drawing.Size(100, 39)
        Me.cmbDirecto.TabIndex = 50
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(1382, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 32)
        Me.Label3.TabIndex = 49
        Me.Label3.Text = "Cruzado:"
        '
        'cmbCruzado
        '
        Me.cmbCruzado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCruzado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbCruzado.FormattingEnabled = True
        Me.cmbCruzado.Location = New System.Drawing.Point(1523, 52)
        Me.cmbCruzado.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbCruzado.Name = "cmbCruzado"
        Me.cmbCruzado.Size = New System.Drawing.Size(100, 39)
        Me.cmbCruzado.TabIndex = 48
        '
        'txtNroCheque
        '
        Me.txtNroCheque.Location = New System.Drawing.Point(1110, 52)
        Me.txtNroCheque.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtNroCheque.Name = "txtNroCheque"
        Me.txtNroCheque.Size = New System.Drawing.Size(254, 38)
        Me.txtNroCheque.TabIndex = 47
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(931, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(175, 32)
        Me.Label5.TabIndex = 46
        Me.Label5.Text = "Cheque Nro:"
        '
        'btnBusq
        '
        Me.btnBusq.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnBusq.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBusq.Location = New System.Drawing.Point(1548, 122)
        Me.btnBusq.Margin = New System.Windows.Forms.Padding(11, 10, 11, 10)
        Me.btnBusq.Name = "btnBusq"
        Me.btnBusq.Size = New System.Drawing.Size(55, 50)
        Me.btnBusq.TabIndex = 43
        Me.btnBusq.Text = "..."
        Me.btnBusq.UseVisualStyleBackColor = False
        '
        'lblNomCliente
        '
        Me.lblNomCliente.AutoSize = True
        Me.lblNomCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNomCliente.Location = New System.Drawing.Point(1616, 122)
        Me.lblNomCliente.Name = "lblNomCliente"
        Me.lblNomCliente.Size = New System.Drawing.Size(285, 32)
        Me.lblNomCliente.TabIndex = 45
        Me.lblNomCliente.Text = "__________________"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(1185, 122)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(113, 32)
        Me.Label15.TabIndex = 44
        Me.Label15.Text = "Cliente:"
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(1305, 122)
        Me.txtCliente.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(233, 38)
        Me.txtCliente.TabIndex = 42
        Me.txtCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmbBanco
        '
        Me.cmbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBanco.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbBanco.FormattingEnabled = True
        Me.cmbBanco.Location = New System.Drawing.Point(581, 122)
        Me.cmbBanco.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbBanco.Name = "cmbBanco"
        Me.cmbBanco.Size = New System.Drawing.Size(567, 39)
        Me.cmbBanco.TabIndex = 37
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(458, 122)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 32)
        Me.Label8.TabIndex = 41
        Me.Label8.Text = "Banco:"
        '
        'dtpFPagoD
        '
        Me.dtpFPagoD.CustomFormat = "dd/MM/yyyy"
        Me.dtpFPagoD.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFPagoD.Location = New System.Drawing.Point(282, 52)
        Me.dtpFPagoD.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtpFPagoD.Name = "dtpFPagoD"
        Me.dtpFPagoD.Size = New System.Drawing.Size(257, 38)
        Me.dtpFPagoD.TabIndex = 36
        '
        'dtpFPagoH
        '
        Me.dtpFPagoH.CustomFormat = "dd/MM/yyyy"
        Me.dtpFPagoH.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFPagoH.Location = New System.Drawing.Point(651, 52)
        Me.dtpFPagoH.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtpFPagoH.Name = "dtpFPagoH"
        Me.dtpFPagoH.Size = New System.Drawing.Size(257, 38)
        Me.dtpFPagoH.TabIndex = 35
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(554, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 32)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Hasta:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(265, 32)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Fecha Pago Desde:"
        '
        'btnAplicar
        '
        Me.btnAplicar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAplicar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAplicar.Location = New System.Drawing.Point(2152, 35)
        Me.btnAplicar.Name = "btnAplicar"
        Me.btnAplicar.Size = New System.Drawing.Size(208, 71)
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
        Me.cmbEstados.Location = New System.Drawing.Point(131, 122)
        Me.cmbEstados.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbEstados.Name = "cmbEstados"
        Me.cmbEstados.Size = New System.Drawing.Size(306, 39)
        Me.cmbEstados.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 122)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 32)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Estado:"
        '
        'btnExportar
        '
        Me.btnExportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportar.Location = New System.Drawing.Point(22, 1101)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(208, 50)
        Me.btnExportar.TabIndex = 54
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.UseVisualStyleBackColor = False
        '
        'frmTesoChkConsulta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 31.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(2418, 1161)
        Me.Controls.Add(Me.btnExportar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnGenOrdenPago)
        Me.Name = "frmTesoChkConsulta"
        Me.Text = "Consulta de Cheques"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
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
End Class
