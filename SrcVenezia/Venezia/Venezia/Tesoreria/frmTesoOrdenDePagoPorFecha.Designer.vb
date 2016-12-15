<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTesoOrdenDePagoPorFecha
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbEstados = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnBusq = New System.Windows.Forms.Button()
        Me.lblNomProove = New System.Windows.Forms.Label()
        Me.txtProove = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpFechaD = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaH = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbEstados)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.btnBusq)
        Me.GroupBox1.Controls.Add(Me.lblNomProove)
        Me.GroupBox1.Controls.Add(Me.txtProove)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.dtpFechaD)
        Me.GroupBox1.Controls.Add(Me.dtpFechaH)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Gainsboro
        Me.GroupBox1.Location = New System.Drawing.Point(10, 10)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(1)
        Me.GroupBox1.Size = New System.Drawing.Size(445, 82)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros de Busqueda"
        '
        'cmbEstados
        '
        Me.cmbEstados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstados.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbEstados.FormattingEnabled = True
        Me.cmbEstados.Location = New System.Drawing.Point(315, 52)
        Me.cmbEstados.Margin = New System.Windows.Forms.Padding(1)
        Me.cmbEstados.Name = "cmbEstados"
        Me.cmbEstados.Size = New System.Drawing.Size(117, 21)
        Me.cmbEstados.TabIndex = 55
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(271, 52)
        Me.Label7.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 56
        Me.Label7.Text = "Estado:"
        '
        'btnBusq
        '
        Me.btnBusq.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnBusq.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBusq.Location = New System.Drawing.Point(131, 50)
        Me.btnBusq.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBusq.Name = "btnBusq"
        Me.btnBusq.Size = New System.Drawing.Size(21, 21)
        Me.btnBusq.TabIndex = 7
        Me.btnBusq.Text = "..."
        Me.btnBusq.UseVisualStyleBackColor = False
        '
        'lblNomProove
        '
        Me.lblNomProove.AutoSize = True
        Me.lblNomProove.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNomProove.Location = New System.Drawing.Point(157, 54)
        Me.lblNomProove.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.lblNomProove.Name = "lblNomProove"
        Me.lblNomProove.Size = New System.Drawing.Size(115, 13)
        Me.lblNomProove.TabIndex = 54
        Me.lblNomProove.Text = "__________________"
        '
        'txtProove
        '
        Me.txtProove.Location = New System.Drawing.Point(67, 52)
        Me.txtProove.Margin = New System.Windows.Forms.Padding(1)
        Me.txtProove.Name = "txtProove"
        Me.txtProove.Size = New System.Drawing.Size(62, 20)
        Me.txtProove.TabIndex = 6
        Me.txtProove.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 54)
        Me.Label6.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 13)
        Me.Label6.TabIndex = 52
        Me.Label6.Text = "Proveedor:"
        '
        'dtpFechaD
        '
        Me.dtpFechaD.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaD.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaD.Location = New System.Drawing.Point(111, 22)
        Me.dtpFechaD.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpFechaD.Name = "dtpFechaD"
        Me.dtpFechaD.Size = New System.Drawing.Size(99, 20)
        Me.dtpFechaD.TabIndex = 1
        '
        'dtpFechaH
        '
        Me.dtpFechaH.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaH.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaH.Location = New System.Drawing.Point(253, 22)
        Me.dtpFechaH.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpFechaH.Name = "dtpFechaH"
        Me.dtpFechaH.Size = New System.Drawing.Size(99, 20)
        Me.dtpFechaH.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(216, 22)
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
        Me.Label2.Size = New System.Drawing.Size(106, 13)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Fecha Orden Desde:"
        '
        'btnGenerar
        '
        Me.btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.Location = New System.Drawing.Point(20, 107)
        Me.btnGenerar.Margin = New System.Windows.Forms.Padding(1)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(95, 21)
        Me.btnGenerar.TabIndex = 27
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.UseVisualStyleBackColor = False
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Location = New System.Drawing.Point(267, 107)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(1)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(95, 21)
        Me.btnSalir.TabIndex = 26
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'frmTesoOrdenDePagoPorFecha
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(474, 147)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnGenerar)
        Me.Controls.Add(Me.btnSalir)
        Me.Name = "frmTesoOrdenDePagoPorFecha"
        Me.Text = "Consulta Ordenes de Pago por fecha"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cmbEstados As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents btnBusq As Button
    Friend WithEvents lblNomProove As Label
    Friend WithEvents txtProove As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents dtpFechaD As DateTimePicker
    Friend WithEvents dtpFechaH As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnGenerar As Button
    Friend WithEvents btnSalir As Button
End Class
