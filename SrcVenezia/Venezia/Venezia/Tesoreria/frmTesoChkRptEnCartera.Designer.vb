<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTesoChkRptEnCartera
    Inherits FrmBase

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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFvtoH = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFvtoD = New System.Windows.Forms.DateTimePicker()
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
        Me.Panel1.Location = New System.Drawing.Point(10, 10)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(409, 167)
        Me.Panel1.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dtpFvtoH)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtpFvtoD)
        Me.GroupBox1.Controls.Add(Me.btnGenerar)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Gainsboro
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(1)
        Me.GroupBox1.Size = New System.Drawing.Size(392, 125)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkGray
        Me.Label3.Location = New System.Drawing.Point(13, 64)
        Me.Label3.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(206, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Ordenado por fecha de pago ascendente."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(226, 31)
        Me.Label2.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Hasta:"
        '
        'dtpFvtoH
        '
        Me.dtpFvtoH.CustomFormat = "dd/MM/yyyy"
        Me.dtpFvtoH.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFvtoH.Location = New System.Drawing.Point(274, 28)
        Me.dtpFvtoH.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpFvtoH.Name = "dtpFvtoH"
        Me.dtpFvtoH.Size = New System.Drawing.Size(99, 20)
        Me.dtpFvtoH.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 31)
        Me.Label1.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Fecha Pago Desde:"
        '
        'dtpFvtoD
        '
        Me.dtpFvtoD.CustomFormat = "dd/MM/yyyy"
        Me.dtpFvtoD.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFvtoD.Location = New System.Drawing.Point(119, 28)
        Me.dtpFvtoD.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpFvtoD.Name = "dtpFvtoD"
        Me.dtpFvtoD.Size = New System.Drawing.Size(99, 20)
        Me.dtpFvtoD.TabIndex = 8
        '
        'btnGenerar
        '
        Me.btnGenerar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerar.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.Location = New System.Drawing.Point(136, 89)
        Me.btnGenerar.Margin = New System.Windows.Forms.Padding(4)
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
        Me.btnSalir.Location = New System.Drawing.Point(307, 138)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(95, 22)
        Me.btnSalir.TabIndex = 5
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'frmTesoChkRptEnCartera
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(422, 178)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(1)
        Me.Name = "frmTesoChkRptEnCartera"
        Me.Text = "Reporte de Cheques en Cartera "
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpFvtoH As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpFvtoD As DateTimePicker
    Friend WithEvents btnGenerar As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents Label3 As Label
End Class
