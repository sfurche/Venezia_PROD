<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStkOrdenCompraAlta
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
        Me.btnBusq = New System.Windows.Forms.Button()
        Me.lblNomProove = New System.Windows.Forms.Label()
        Me.txtProove = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCriterioBusq = New System.Windows.Forms.TextBox()
        Me.lblFechaEntrega = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.dtpFechaEntrega = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblProcErr = New System.Windows.Forms.Label()
        Me.lblProcOK = New System.Windows.Forms.Label()
        Me.lblTotalImp = New System.Windows.Forms.Label()
        Me.lvwConsulta = New System.Windows.Forms.ListView()
        Me.imgAbrir = New System.Windows.Forms.PictureBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.imgAbrir, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.AutoSize = True
        Me.GroupBox1.Controls.Add(Me.imgAbrir)
        Me.GroupBox1.Controls.Add(Me.lblNombre)
        Me.GroupBox1.Controls.Add(Me.dtpFechaEntrega)
        Me.GroupBox1.Controls.Add(Me.btnBusq)
        Me.GroupBox1.Controls.Add(Me.lblNomProove)
        Me.GroupBox1.Controls.Add(Me.txtProove)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtCriterioBusq)
        Me.GroupBox1.Controls.Add(Me.lblFechaEntrega)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Gainsboro
        Me.GroupBox1.Location = New System.Drawing.Point(4, 5)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.GroupBox1.Size = New System.Drawing.Size(710, 143)
        Me.GroupBox1.TabIndex = 28
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de Carga"
        '
        'btnBusq
        '
        Me.btnBusq.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnBusq.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBusq.Location = New System.Drawing.Point(168, 12)
        Me.btnBusq.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnBusq.Name = "btnBusq"
        Me.btnBusq.Size = New System.Drawing.Size(21, 21)
        Me.btnBusq.TabIndex = 51
        Me.btnBusq.Text = "..."
        Me.btnBusq.UseVisualStyleBackColor = False
        '
        'lblNomProove
        '
        Me.lblNomProove.AutoSize = True
        Me.lblNomProove.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNomProove.Location = New System.Drawing.Point(194, 16)
        Me.lblNomProove.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.lblNomProove.Name = "lblNomProove"
        Me.lblNomProove.Size = New System.Drawing.Size(115, 13)
        Me.lblNomProove.TabIndex = 52
        Me.lblNomProove.Text = "__________________"
        '
        'txtProove
        '
        Me.txtProove.Location = New System.Drawing.Point(104, 15)
        Me.txtProove.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.txtProove.Name = "txtProove"
        Me.txtProove.Size = New System.Drawing.Size(62, 20)
        Me.txtProove.TabIndex = 49
        Me.txtProove.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(40, 20)
        Me.Label6.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 13)
        Me.Label6.TabIndex = 50
        Me.Label6.Text = "Proveedor:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(18, 93)
        Me.Label2.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Observaciones:"
        '
        'txtCriterioBusq
        '
        Me.txtCriterioBusq.Location = New System.Drawing.Point(104, 90)
        Me.txtCriterioBusq.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.txtCriterioBusq.Multiline = True
        Me.txtCriterioBusq.Name = "txtCriterioBusq"
        Me.txtCriterioBusq.Size = New System.Drawing.Size(583, 38)
        Me.txtCriterioBusq.TabIndex = 4
        '
        'lblFechaEntrega
        '
        Me.lblFechaEntrega.AutoSize = True
        Me.lblFechaEntrega.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaEntrega.Location = New System.Drawing.Point(6, 56)
        Me.lblFechaEntrega.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.lblFechaEntrega.Name = "lblFechaEntrega"
        Me.lblFechaEntrega.Size = New System.Drawing.Size(95, 13)
        Me.lblFechaEntrega.TabIndex = 3
        Me.lblFechaEntrega.Text = "Fecha de Entrega:"
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Location = New System.Drawing.Point(614, 718)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(95, 23)
        Me.btnSalir.TabIndex = 29
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Location = New System.Drawing.Point(507, 718)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(95, 23)
        Me.btnGuardar.TabIndex = 30
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'dtpFechaEntrega
        '
        Me.dtpFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaEntrega.Location = New System.Drawing.Point(104, 50)
        Me.dtpFechaEntrega.Name = "dtpFechaEntrega"
        Me.dtpFechaEntrega.Size = New System.Drawing.Size(102, 20)
        Me.dtpFechaEntrega.TabIndex = 53
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblProcErr)
        Me.GroupBox2.Controls.Add(Me.lblProcOK)
        Me.GroupBox2.Controls.Add(Me.lblTotalImp)
        Me.GroupBox2.Controls.Add(Me.lvwConsulta)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Gainsboro
        Me.GroupBox2.Location = New System.Drawing.Point(4, 150)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(1)
        Me.GroupBox2.Size = New System.Drawing.Size(710, 557)
        Me.GroupBox2.TabIndex = 31
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detalle de Productos"
        '
        'lblProcErr
        '
        Me.lblProcErr.AutoSize = True
        Me.lblProcErr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcErr.ForeColor = System.Drawing.Color.OrangeRed
        Me.lblProcErr.Location = New System.Drawing.Point(411, 535)
        Me.lblProcErr.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.lblProcErr.Name = "lblProcErr"
        Me.lblProcErr.Size = New System.Drawing.Size(129, 13)
        Me.lblProcErr.TabIndex = 22
        Me.lblProcErr.Text = "Procesados con ERROR:"
        '
        'lblProcOK
        '
        Me.lblProcOK.AutoSize = True
        Me.lblProcOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcOK.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.lblProcOK.Location = New System.Drawing.Point(220, 535)
        Me.lblProcOK.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.lblProcOK.Name = "lblProcOK"
        Me.lblProcOK.Size = New System.Drawing.Size(84, 13)
        Me.lblProcOK.TabIndex = 21
        Me.lblProcOK.Text = "Procesados OK:"
        '
        'lblTotalImp
        '
        Me.lblTotalImp.AutoSize = True
        Me.lblTotalImp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalImp.Location = New System.Drawing.Point(27, 535)
        Me.lblTotalImp.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.lblTotalImp.Name = "lblTotalImp"
        Me.lblTotalImp.Size = New System.Drawing.Size(98, 13)
        Me.lblTotalImp.TabIndex = 20
        Me.lblTotalImp.Text = "Total Importados: 0"
        '
        'lvwConsulta
        '
        Me.lvwConsulta.AllowColumnReorder = True
        Me.lvwConsulta.FullRowSelect = True
        Me.lvwConsulta.GridLines = True
        Me.lvwConsulta.Location = New System.Drawing.Point(6, 15)
        Me.lvwConsulta.Margin = New System.Windows.Forms.Padding(1)
        Me.lvwConsulta.Name = "lvwConsulta"
        Me.lvwConsulta.Size = New System.Drawing.Size(699, 505)
        Me.lvwConsulta.TabIndex = 0
        Me.lvwConsulta.UseCompatibleStateImageBehavior = False
        Me.lvwConsulta.View = System.Windows.Forms.View.Details
        '
        'imgAbrir
        '
        Me.imgAbrir.Image = Global.Venezia.My.Resources.Resources.folder_view
        Me.imgAbrir.InitialImage = Global.Venezia.My.Resources.Resources.folder_view
        Me.imgAbrir.Location = New System.Drawing.Point(676, 11)
        Me.imgAbrir.Name = "imgAbrir"
        Me.imgAbrir.Size = New System.Drawing.Size(26, 22)
        Me.imgAbrir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgAbrir.TabIndex = 56
        Me.imgAbrir.TabStop = False
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.Location = New System.Drawing.Point(539, 15)
        Me.lblNombre.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(133, 13)
        Me.lblNombre.TabIndex = 54
        Me.lblNombre.Text = "Importar desde un archivo:"
        '
        'frmStkOrdenCompraAlta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(722, 747)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.GroupBox1)
        Me.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.Name = "frmStkOrdenCompraAlta"
        Me.Text = "Alta de Orden de Compra"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.imgAbrir, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCriterioBusq As TextBox
    Friend WithEvents lblFechaEntrega As Label
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnBusq As Button
    Friend WithEvents lblNomProove As Label
    Friend WithEvents txtProove As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents btnGuardar As Button
    Friend WithEvents dtpFechaEntrega As DateTimePicker
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lblProcErr As Label
    Friend WithEvents lblProcOK As Label
    Friend WithEvents lblTotalImp As Label
    Friend WithEvents lvwConsulta As ListView
    Friend WithEvents lblNombre As Label
    Friend WithEvents imgAbrir As PictureBox
End Class
