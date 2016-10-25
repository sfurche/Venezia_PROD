<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTesoLiquidacionesCons
    'Inherits System.Windows.Forms.Form

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
        Me.gbox1 = New System.Windows.Forms.GroupBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.dtpFechaH = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFechaD = New System.Windows.Forms.DateTimePicker()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.lvwConsulta = New System.Windows.Forms.ListView()
        Me.Panel1.SuspendLayout()
        Me.gbox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.Controls.Add(Me.gbox1)
        Me.Panel1.Controls.Add(Me.btnSalir)
        Me.Panel1.Controls.Add(Me.lvwConsulta)
        Me.Panel1.Location = New System.Drawing.Point(17, 14)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(2378, 1121)
        Me.Panel1.TabIndex = 0
        '
        'gbox1
        '
        Me.gbox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbox1.Controls.Add(Me.btnBuscar)
        Me.gbox1.Controls.Add(Me.dtpFechaH)
        Me.gbox1.Controls.Add(Me.Label2)
        Me.gbox1.Controls.Add(Me.Label1)
        Me.gbox1.Controls.Add(Me.dtpFechaD)
        Me.gbox1.ForeColor = System.Drawing.Color.LightGray
        Me.gbox1.Location = New System.Drawing.Point(10, 8)
        Me.gbox1.Margin = New System.Windows.Forms.Padding(10, 9, 10, 9)
        Me.gbox1.Name = "gbox1"
        Me.gbox1.Padding = New System.Windows.Forms.Padding(10, 9, 10, 9)
        Me.gbox1.Size = New System.Drawing.Size(2353, 137)
        Me.gbox1.TabIndex = 5
        Me.gbox1.TabStop = False
        Me.gbox1.Text = "Filtros"
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnBuscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Location = New System.Drawing.Point(2043, 59)
        Me.btnBuscar.Margin = New System.Windows.Forms.Padding(10, 9, 10, 9)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(254, 52)
        Me.btnBuscar.TabIndex = 3
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'dtpFechaH
        '
        Me.dtpFechaH.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaH.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaH.Location = New System.Drawing.Point(801, 64)
        Me.dtpFechaH.Name = "dtpFechaH"
        Me.dtpFechaH.Size = New System.Drawing.Size(257, 38)
        Me.dtpFechaH.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(593, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(183, 32)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Fecha Hasta:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(40, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(191, 32)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Fecha Desde:"
        '
        'dtpFechaD
        '
        Me.dtpFechaD.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaD.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaD.Location = New System.Drawing.Point(255, 64)
        Me.dtpFechaD.Name = "dtpFechaD"
        Me.dtpFechaD.Size = New System.Drawing.Size(257, 38)
        Me.dtpFechaD.TabIndex = 0
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Location = New System.Drawing.Point(2108, 1036)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(10, 9, 10, 9)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(254, 52)
        Me.btnSalir.TabIndex = 4
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'lvwConsulta
        '
        Me.lvwConsulta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwConsulta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvwConsulta.FullRowSelect = True
        Me.lvwConsulta.GridLines = True
        Me.lvwConsulta.Location = New System.Drawing.Point(10, 162)
        Me.lvwConsulta.Margin = New System.Windows.Forms.Padding(10, 9, 10, 9)
        Me.lvwConsulta.Name = "lvwConsulta"
        Me.lvwConsulta.Size = New System.Drawing.Size(2352, 853)
        Me.lvwConsulta.TabIndex = 3
        Me.lvwConsulta.UseCompatibleStateImageBehavior = False
        Me.lvwConsulta.View = System.Windows.Forms.View.Details
        '
        'frmTesoLiquidacionesCons
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 31.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(2416, 1147)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(10, 9, 10, 9)
        Me.Name = "frmTesoLiquidacionesCons"
        Me.Text = "Consulta de Liquidaciones"
        Me.Panel1.ResumeLayout(False)
        Me.gbox1.ResumeLayout(False)
        Me.gbox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents gbox1 As GroupBox
    Friend WithEvents btnBuscar As Button
    Friend WithEvents dtpFechaH As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpFechaD As DateTimePicker
    Friend WithEvents btnSalir As Button
    Friend WithEvents lvwConsulta As ListView
End Class
