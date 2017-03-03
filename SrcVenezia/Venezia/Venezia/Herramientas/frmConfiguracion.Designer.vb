<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfiguracion
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
        Me.components = New System.ComponentModel.Container()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lvwConsulta = New System.Windows.Forms.ListView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmCambiarValor = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Location = New System.Drawing.Point(615, 378)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(95, 21)
        Me.btnSalir.TabIndex = 17
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lvwConsulta)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Gainsboro
        Me.GroupBox2.Location = New System.Drawing.Point(4, 8)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.GroupBox2.Size = New System.Drawing.Size(718, 359)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Settings"
        '
        'lvwConsulta
        '
        Me.lvwConsulta.AllowColumnReorder = True
        Me.lvwConsulta.FullRowSelect = True
        Me.lvwConsulta.GridLines = True
        Me.lvwConsulta.Location = New System.Drawing.Point(6, 18)
        Me.lvwConsulta.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.lvwConsulta.MultiSelect = False
        Me.lvwConsulta.Name = "lvwConsulta"
        Me.lvwConsulta.Size = New System.Drawing.Size(708, 329)
        Me.lvwConsulta.TabIndex = 0
        Me.lvwConsulta.UseCompatibleStateImageBehavior = False
        Me.lvwConsulta.View = System.Windows.Forms.View.Details
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(40, 40)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmCambiarValor})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(150, 26)
        '
        'tsmCambiarValor
        '
        Me.tsmCambiarValor.Name = "tsmCambiarValor"
        Me.tsmCambiarValor.Size = New System.Drawing.Size(149, 22)
        Me.tsmCambiarValor.Text = "Cambiar Valor"
        '
        'btnModificar
        '
        Me.btnModificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnModificar.Location = New System.Drawing.Point(10, 374)
        Me.btnModificar.Margin = New System.Windows.Forms.Padding(1)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(133, 21)
        Me.btnModificar.TabIndex = 18
        Me.btnModificar.Text = "Modificar Valor"
        Me.btnModificar.UseVisualStyleBackColor = False
        '
        'frmConfiguracion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(727, 405)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.GroupBox2)
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Name = "frmConfiguracion"
        Me.Text = "Configuracion"
        Me.GroupBox2.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnSalir As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lvwConsulta As ListView
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents tsmCambiarValor As ToolStripMenuItem
    Friend WithEvents btnModificar As Button
End Class
