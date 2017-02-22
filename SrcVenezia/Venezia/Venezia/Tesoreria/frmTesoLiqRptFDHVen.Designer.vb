<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTesoLiqRptFDHVen
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbEstados = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbVendedores = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFechaLiqH = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFechaLiqD = New System.Windows.Forms.DateTimePicker()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.btnSalir)
        Me.Panel1.Location = New System.Drawing.Point(4, 5)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(388, 234)
        Me.Panel1.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbEstados)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cmbVendedores)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dtpFechaLiqH)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtpFechaLiqD)
        Me.GroupBox1.Controls.Add(Me.btnGenerar)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Gainsboro
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.GroupBox1.Size = New System.Drawing.Size(372, 185)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'cmbEstados
        '
        Me.cmbEstados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstados.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbEstados.FormattingEnabled = True
        Me.cmbEstados.Location = New System.Drawing.Point(67, 103)
        Me.cmbEstados.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.cmbEstados.Name = "cmbEstados"
        Me.cmbEstados.Size = New System.Drawing.Size(163, 21)
        Me.cmbEstados.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 103)
        Me.Label7.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Estado:"
        '
        'cmbVendedores
        '
        Me.cmbVendedores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVendedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbVendedores.FormattingEnabled = True
        Me.cmbVendedores.Location = New System.Drawing.Point(67, 68)
        Me.cmbVendedores.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.cmbVendedores.Name = "cmbVendedores"
        Me.cmbVendedores.Size = New System.Drawing.Size(285, 21)
        Me.cmbVendedores.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 68)
        Me.Label3.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Vendedor:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(193, 33)
        Me.Label2.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Fecha Hasta:"
        '
        'dtpFechaLiqH
        '
        Me.dtpFechaLiqH.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaLiqH.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaLiqH.Location = New System.Drawing.Point(267, 33)
        Me.dtpFechaLiqH.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.dtpFechaLiqH.Name = "dtpFechaLiqH"
        Me.dtpFechaLiqH.Size = New System.Drawing.Size(99, 20)
        Me.dtpFechaLiqH.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 33)
        Me.Label1.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Fecha Desde:"
        '
        'dtpFechaLiqD
        '
        Me.dtpFechaLiqD.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaLiqD.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaLiqD.Location = New System.Drawing.Point(83, 33)
        Me.dtpFechaLiqD.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.dtpFechaLiqD.Name = "dtpFechaLiqD"
        Me.dtpFechaLiqD.Size = New System.Drawing.Size(99, 20)
        Me.dtpFechaLiqD.TabIndex = 8
        '
        'btnGenerar
        '
        Me.btnGenerar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerar.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.Location = New System.Drawing.Point(143, 144)
        Me.btnGenerar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(95, 22)
        Me.btnGenerar.TabIndex = 6
        Me.btnGenerar.Text = "&Generar"
        Me.btnGenerar.UseVisualStyleBackColor = False
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Location = New System.Drawing.Point(286, 204)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(95, 22)
        Me.btnSalir.TabIndex = 5
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'frmTesoLiqRptFDHVen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(401, 245)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.Name = "frmTesoLiqRptFDHVen"
        Me.Text = "Reporte de Liquidaciones Historicas"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpFechaLiqD As DateTimePicker
    Friend WithEvents btnGenerar As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpFechaLiqH As DateTimePicker
    Friend WithEvents cmbVendedores As ComboBox
    Friend WithEvents cmbEstados As ComboBox
    Friend WithEvents Label7 As Label
End Class
