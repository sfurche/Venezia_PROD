<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCfgPermisosConsulta
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbUsuarios = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lvwConsulta = New System.Windows.Forms.ListView()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnUpdPWD = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmbUsuarios)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Gainsboro
        Me.GroupBox1.Location = New System.Drawing.Point(12, 23)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(2016, 148)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos del Usuario"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(77, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 32)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Usuario: "
        '
        'cmbUsuarios
        '
        Me.cmbUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUsuarios.FormattingEnabled = True
        Me.cmbUsuarios.Location = New System.Drawing.Point(220, 68)
        Me.cmbUsuarios.Name = "cmbUsuarios"
        Me.cmbUsuarios.Size = New System.Drawing.Size(1309, 39)
        Me.cmbUsuarios.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lvwConsulta)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Gainsboro
        Me.GroupBox2.Location = New System.Drawing.Point(12, 193)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(2016, 701)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Funciones y Permisos"
        '
        'lvwConsulta
        '
        Me.lvwConsulta.AllowColumnReorder = True
        Me.lvwConsulta.FullRowSelect = True
        Me.lvwConsulta.GridLines = True
        Me.lvwConsulta.Location = New System.Drawing.Point(6, 36)
        Me.lvwConsulta.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lvwConsulta.MultiSelect = False
        Me.lvwConsulta.Name = "lvwConsulta"
        Me.lvwConsulta.Size = New System.Drawing.Size(1999, 650)
        Me.lvwConsulta.TabIndex = 1
        Me.lvwConsulta.UseCompatibleStateImageBehavior = False
        Me.lvwConsulta.View = System.Windows.Forms.View.Details
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Location = New System.Drawing.Point(1764, 922)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(253, 50)
        Me.btnSalir.TabIndex = 27
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'btnUpdPWD
        '
        Me.btnUpdPWD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdPWD.Location = New System.Drawing.Point(305, 922)
        Me.btnUpdPWD.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnUpdPWD.Name = "btnUpdPWD"
        Me.btnUpdPWD.Size = New System.Drawing.Size(405, 50)
        Me.btnUpdPWD.TabIndex = 28
        Me.btnUpdPWD.Text = "Ver / Cambiar Contraseña"
        Me.btnUpdPWD.UseVisualStyleBackColor = False
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Location = New System.Drawing.Point(18, 922)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(253, 50)
        Me.btnGuardar.TabIndex = 29
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'frmCfgPermisosConsulta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 31.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2043, 1008)
        Me.Controls.Add(Me.btnUpdPWD)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmCfgPermisosConsulta"
        Me.Text = "Administracion de Permisos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbUsuarios As ComboBox
    Friend WithEvents btnSalir As Button
    Friend WithEvents lvwConsulta As ListView
    Friend WithEvents btnUpdPWD As Button
    Friend WithEvents btnGuardar As Button
End Class
