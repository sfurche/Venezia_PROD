<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStkCargaPrecios
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.imgAbrir = New System.Windows.Forms.PictureBox()
        Me.lblPath = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbListaPrecios = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSimular = New System.Windows.Forms.Button()
        Me.txtCriterioBusq = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblProcErr = New System.Windows.Forms.Label()
        Me.lblProcOK = New System.Windows.Forms.Label()
        Me.lblTotalImp = New System.Windows.Forms.Label()
        Me.lvwConsulta = New System.Windows.Forms.ListView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmCambiarPrecio = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1.SuspendLayout()
        CType(Me.imgAbrir, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Location = New System.Drawing.Point(1647, 1292)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(253, 50)
        Me.btnSalir.TabIndex = 26
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.AutoSize = True
        Me.GroupBox1.Controls.Add(Me.imgAbrir)
        Me.GroupBox1.Controls.Add(Me.lblPath)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbListaPrecios)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnSimular)
        Me.GroupBox1.Controls.Add(Me.txtCriterioBusq)
        Me.GroupBox1.Controls.Add(Me.lblNombre)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Gainsboro
        Me.GroupBox1.Location = New System.Drawing.Point(27, 24)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(1893, 298)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de Carga"
        '
        'imgAbrir
        '
        Me.imgAbrir.Image = Global.Venezia.My.Resources.Resources.folder_view
        Me.imgAbrir.InitialImage = Global.Venezia.My.Resources.Resources.folder_view
        Me.imgAbrir.Location = New System.Drawing.Point(176, 117)
        Me.imgAbrir.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.imgAbrir.Name = "imgAbrir"
        Me.imgAbrir.Size = New System.Drawing.Size(69, 52)
        Me.imgAbrir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgAbrir.TabIndex = 23
        Me.imgAbrir.TabStop = False
        '
        'lblPath
        '
        Me.lblPath.AutoSize = True
        Me.lblPath.Location = New System.Drawing.Point(256, 134)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(780, 32)
        Me.lblPath.TabIndex = 22
        Me.lblPath.Text = "___________________________________________________"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(43, 222)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(227, 32)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Observaciones:"
        '
        'cmbListaPrecios
        '
        Me.cmbListaPrecios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbListaPrecios.FormattingEnabled = True
        Me.cmbListaPrecios.Location = New System.Drawing.Point(165, 48)
        Me.cmbListaPrecios.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.cmbListaPrecios.Name = "cmbListaPrecios"
        Me.cmbListaPrecios.Size = New System.Drawing.Size(1209, 39)
        Me.cmbListaPrecios.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(43, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 32)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Lista:"
        '
        'btnSimular
        '
        Me.btnSimular.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSimular.Location = New System.Drawing.Point(1549, 55)
        Me.btnSimular.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSimular.Name = "btnSimular"
        Me.btnSimular.Size = New System.Drawing.Size(253, 67)
        Me.btnSimular.TabIndex = 18
        Me.btnSimular.Text = "Simular"
        Me.btnSimular.UseVisualStyleBackColor = False
        '
        'txtCriterioBusq
        '
        Me.txtCriterioBusq.Location = New System.Drawing.Point(309, 215)
        Me.txtCriterioBusq.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtCriterioBusq.Name = "txtCriterioBusq"
        Me.txtCriterioBusq.Size = New System.Drawing.Size(1547, 38)
        Me.txtCriterioBusq.TabIndex = 4
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.Location = New System.Drawing.Point(43, 134)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(116, 32)
        Me.lblNombre.TabIndex = 3
        Me.lblNombre.Text = "Origen:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblProcErr)
        Me.GroupBox2.Controls.Add(Me.lblProcOK)
        Me.GroupBox2.Controls.Add(Me.lblTotalImp)
        Me.GroupBox2.Controls.Add(Me.lvwConsulta)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Gainsboro
        Me.GroupBox2.Location = New System.Drawing.Point(27, 327)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox2.Size = New System.Drawing.Size(1893, 944)
        Me.GroupBox2.TabIndex = 28
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Precios"
        '
        'lblProcErr
        '
        Me.lblProcErr.AutoSize = True
        Me.lblProcErr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcErr.ForeColor = System.Drawing.Color.OrangeRed
        Me.lblProcErr.Location = New System.Drawing.Point(1095, 877)
        Me.lblProcErr.Name = "lblProcErr"
        Me.lblProcErr.Size = New System.Drawing.Size(334, 32)
        Me.lblProcErr.TabIndex = 22
        Me.lblProcErr.Text = "Procesados con ERROR:"
        '
        'lblProcOK
        '
        Me.lblProcOK.AutoSize = True
        Me.lblProcOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcOK.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.lblProcOK.Location = New System.Drawing.Point(586, 877)
        Me.lblProcOK.Name = "lblProcOK"
        Me.lblProcOK.Size = New System.Drawing.Size(221, 32)
        Me.lblProcOK.TabIndex = 21
        Me.lblProcOK.Text = "Procesados OK:"
        '
        'lblTotalImp
        '
        Me.lblTotalImp.AutoSize = True
        Me.lblTotalImp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalImp.Location = New System.Drawing.Point(72, 877)
        Me.lblTotalImp.Name = "lblTotalImp"
        Me.lblTotalImp.Size = New System.Drawing.Size(258, 32)
        Me.lblTotalImp.TabIndex = 20
        Me.lblTotalImp.Text = "Total Importados: 0"
        '
        'lvwConsulta
        '
        Me.lvwConsulta.AllowColumnReorder = True
        Me.lvwConsulta.FullRowSelect = True
        Me.lvwConsulta.GridLines = True
        Me.lvwConsulta.Location = New System.Drawing.Point(16, 50)
        Me.lvwConsulta.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lvwConsulta.Name = "lvwConsulta"
        Me.lvwConsulta.Size = New System.Drawing.Size(1857, 805)
        Me.lvwConsulta.TabIndex = 0
        Me.lvwConsulta.UseCompatibleStateImageBehavior = False
        Me.lvwConsulta.View = System.Windows.Forms.View.Details
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(40, 40)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmCambiarPrecio})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(334, 105)
        '
        'tsmCambiarPrecio
        '
        Me.tsmCambiarPrecio.Name = "tsmCambiarPrecio"
        Me.tsmCambiarPrecio.Size = New System.Drawing.Size(333, 46)
        Me.tsmCambiarPrecio.Text = "Cambiar Precio"
        '
        'frmStkCargaPrecios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 31.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1934, 1365)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnSalir)
        Me.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.Name = "frmStkCargaPrecios"
        Me.Text = "Carga Masiva de Precios"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.imgAbrir, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSalir As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cmbListaPrecios As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSimular As Button
    Friend WithEvents txtCriterioBusq As TextBox
    Friend WithEvents lblNombre As Label
    Friend WithEvents lblPath As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents imgAbrir As PictureBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lvwConsulta As ListView
    Friend WithEvents lblProcErr As Label
    Friend WithEvents lblProcOK As Label
    Friend WithEvents lblTotalImp As Label
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents tsmCambiarPrecio As ToolStripMenuItem
End Class
