<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTesoChkRptxProv
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
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.groupGeneral = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFechaOpH = New System.Windows.Forms.DateTimePicker()
        Me.btnBusq = New System.Windows.Forms.Button()
        Me.lblNomProove = New System.Windows.Forms.Label()
        Me.txtProove = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpFechaOpD = New System.Windows.Forms.DateTimePicker()
        Me.groupGeneral.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Location = New System.Drawing.Point(837, 261)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(253, 50)
        Me.btnSalir.TabIndex = 18
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'btnGenerar
        '
        Me.btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.Location = New System.Drawing.Point(560, 261)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(253, 50)
        Me.btnGenerar.TabIndex = 19
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.UseVisualStyleBackColor = False
        '
        'groupGeneral
        '
        Me.groupGeneral.Controls.Add(Me.Label1)
        Me.groupGeneral.Controls.Add(Me.dtpFechaOpH)
        Me.groupGeneral.Controls.Add(Me.btnBusq)
        Me.groupGeneral.Controls.Add(Me.lblNomProove)
        Me.groupGeneral.Controls.Add(Me.txtProove)
        Me.groupGeneral.Controls.Add(Me.Label6)
        Me.groupGeneral.Controls.Add(Me.Label5)
        Me.groupGeneral.Controls.Add(Me.dtpFechaOpD)
        Me.groupGeneral.ForeColor = System.Drawing.Color.Gainsboro
        Me.groupGeneral.Location = New System.Drawing.Point(12, 22)
        Me.groupGeneral.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.groupGeneral.Name = "groupGeneral"
        Me.groupGeneral.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.groupGeneral.Size = New System.Drawing.Size(1078, 213)
        Me.groupGeneral.TabIndex = 22
        Me.groupGeneral.TabStop = False
        Me.groupGeneral.Text = "Datos Generales"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(585, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 32)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "Hasta "
        '
        'dtpFechaOpH
        '
        Me.dtpFechaOpH.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaOpH.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaOpH.Location = New System.Drawing.Point(716, 46)
        Me.dtpFechaOpH.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtpFechaOpH.Name = "dtpFechaOpH"
        Me.dtpFechaOpH.Size = New System.Drawing.Size(257, 38)
        Me.dtpFechaOpH.TabIndex = 49
        '
        'btnBusq
        '
        Me.btnBusq.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnBusq.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBusq.Location = New System.Drawing.Point(351, 113)
        Me.btnBusq.Margin = New System.Windows.Forms.Padding(11, 10, 11, 10)
        Me.btnBusq.Name = "btnBusq"
        Me.btnBusq.Size = New System.Drawing.Size(55, 50)
        Me.btnBusq.TabIndex = 47
        Me.btnBusq.Text = "..."
        Me.btnBusq.UseVisualStyleBackColor = False
        '
        'lblNomProove
        '
        Me.lblNomProove.AutoSize = True
        Me.lblNomProove.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNomProove.Location = New System.Drawing.Point(419, 122)
        Me.lblNomProove.Name = "lblNomProove"
        Me.lblNomProove.Size = New System.Drawing.Size(285, 32)
        Me.lblNomProove.TabIndex = 48
        Me.lblNomProove.Text = "__________________"
        '
        'txtProove
        '
        Me.txtProove.Location = New System.Drawing.Point(180, 119)
        Me.txtProove.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtProove.Name = "txtProove"
        Me.txtProove.Size = New System.Drawing.Size(158, 38)
        Me.txtProove.TabIndex = 4
        Me.txtProove.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(20, 122)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(154, 32)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Proveedor:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(265, 32)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Fecha Pago Desde:"
        '
        'dtpFechaOpD
        '
        Me.dtpFechaOpD.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaOpD.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaOpD.Location = New System.Drawing.Point(294, 46)
        Me.dtpFechaOpD.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtpFechaOpD.Name = "dtpFechaOpD"
        Me.dtpFechaOpD.Size = New System.Drawing.Size(257, 38)
        Me.dtpFechaOpD.TabIndex = 0
        '
        'frmTesoChkRptxProv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 31.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1119, 338)
        Me.Controls.Add(Me.groupGeneral)
        Me.Controls.Add(Me.btnGenerar)
        Me.Controls.Add(Me.btnSalir)
        Me.Name = "frmTesoChkRptxProv"
        Me.Text = "Listado de Cheques x Proveedor"
        Me.groupGeneral.ResumeLayout(False)
        Me.groupGeneral.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnSalir As Button
    Friend WithEvents btnGenerar As Button
    Friend WithEvents groupGeneral As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpFechaOpH As DateTimePicker
    Friend WithEvents btnBusq As Button
    Friend WithEvents lblNomProove As Label
    Friend WithEvents txtProove As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents dtpFechaOpD As DateTimePicker
End Class
