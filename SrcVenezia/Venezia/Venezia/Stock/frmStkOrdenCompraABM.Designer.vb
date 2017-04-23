<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStkOrdenCompraABM
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
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NumCantidad = New System.Windows.Forms.NumericUpDown()
        Me.lvwConsulta = New System.Windows.Forms.ListView()
        Me.imgAbrir = New System.Windows.Forms.PictureBox()
        Me.txtProove = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtObservac = New System.Windows.Forms.TextBox()
        Me.lblNomProove = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnBusqProv = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFechaEntrega = New System.Windows.Forms.DateTimePicker()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblProcErr = New System.Windows.Forms.Label()
        Me.lblProcOK = New System.Windows.Forms.Label()
        Me.lblTotalImp = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblDescripcionArt = New System.Windows.Forms.Label()
        Me.btnBusqArt = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCodArt = New System.Windows.Forms.TextBox()
        CType(Me.NumCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgAbrir, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnEliminar
        '
        Me.btnEliminar.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminar.Image = Global.Venezia.My.Resources.Resources._24x24_delete2
        Me.btnEliminar.Location = New System.Drawing.Point(1746, 41)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(79, 57)
        Me.btnEliminar.TabIndex = 0
        Me.btnEliminar.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(119, 109)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(161, 32)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Proveedor :"
        '
        'NumCantidad
        '
        Me.NumCantidad.Location = New System.Drawing.Point(1129, 48)
        Me.NumCantidad.Name = "NumCantidad"
        Me.NumCantidad.Size = New System.Drawing.Size(134, 38)
        Me.NumCantidad.TabIndex = 2
        Me.NumCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lvwConsulta
        '
        Me.lvwConsulta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvwConsulta.GridLines = True
        Me.lvwConsulta.Location = New System.Drawing.Point(15, 113)
        Me.lvwConsulta.Name = "lvwConsulta"
        Me.lvwConsulta.Size = New System.Drawing.Size(1824, 646)
        Me.lvwConsulta.TabIndex = 3
        Me.lvwConsulta.UseCompatibleStateImageBehavior = False
        Me.lvwConsulta.View = System.Windows.Forms.View.Details
        '
        'imgAbrir
        '
        Me.imgAbrir.Image = Global.Venezia.My.Resources.Resources.folder_view
        Me.imgAbrir.InitialImage = Global.Venezia.My.Resources.Resources.folder_view
        Me.imgAbrir.Location = New System.Drawing.Point(1741, 43)
        Me.imgAbrir.Name = "imgAbrir"
        Me.imgAbrir.Size = New System.Drawing.Size(60, 60)
        Me.imgAbrir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgAbrir.TabIndex = 4
        Me.imgAbrir.TabStop = False
        '
        'txtProove
        '
        Me.txtProove.Location = New System.Drawing.Point(299, 109)
        Me.txtProove.Name = "txtProove"
        Me.txtProove.Size = New System.Drawing.Size(161, 38)
        Me.txtProove.TabIndex = 5
        Me.txtProove.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtObservac)
        Me.GroupBox1.Controls.Add(Me.lblNomProove)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnBusqProv)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.imgAbrir)
        Me.GroupBox1.Controls.Add(Me.dtpFechaEntrega)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtProove)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Gainsboro
        Me.GroupBox1.Location = New System.Drawing.Point(17, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1845, 274)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de la Orden"
        '
        'txtObservac
        '
        Me.txtObservac.Location = New System.Drawing.Point(299, 171)
        Me.txtObservac.Multiline = True
        Me.txtObservac.Name = "txtObservac"
        Me.txtObservac.Size = New System.Drawing.Size(1507, 86)
        Me.txtObservac.TabIndex = 12
        '
        'lblNomProove
        '
        Me.lblNomProove.AutoSize = True
        Me.lblNomProove.Location = New System.Drawing.Point(550, 112)
        Me.lblNomProove.Name = "lblNomProove"
        Me.lblNomProove.Size = New System.Drawing.Size(525, 32)
        Me.lblNomProove.TabIndex = 11
        Me.lblNomProove.Text = "__________________________________"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(1385, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(350, 32)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Importar desde un archivo:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(76, 171)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(204, 32)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Obsevaciones:"
        '
        'btnBusqProv
        '
        Me.btnBusqProv.AutoSize = True
        Me.btnBusqProv.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnBusqProv.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBusqProv.Location = New System.Drawing.Point(476, 105)
        Me.btnBusqProv.Name = "btnBusqProv"
        Me.btnBusqProv.Size = New System.Drawing.Size(56, 45)
        Me.btnBusqProv.TabIndex = 8
        Me.btnBusqProv.Text = "..."
        Me.btnBusqProv.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(255, 32)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Fecha de Entrega :"
        '
        'dtpFechaEntrega
        '
        Me.dtpFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaEntrega.Location = New System.Drawing.Point(299, 43)
        Me.dtpFechaEntrega.Name = "dtpFechaEntrega"
        Me.dtpFechaEntrega.Size = New System.Drawing.Size(256, 38)
        Me.dtpFechaEntrega.TabIndex = 7
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.Location = New System.Drawing.Point(1680, 1155)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(180, 61)
        Me.btnSalir.TabIndex = 7
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'btnAgregar
        '
        Me.btnAgregar.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregar.Image = Global.Venezia.My.Resources.Resources._24x24_add2
        Me.btnAgregar.Location = New System.Drawing.Point(1647, 41)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(79, 57)
        Me.btnAgregar.TabIndex = 9
        Me.btnAgregar.UseVisualStyleBackColor = False
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.Location = New System.Drawing.Point(1491, 1155)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(179, 61)
        Me.btnGuardar.TabIndex = 10
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblProcErr)
        Me.GroupBox2.Controls.Add(Me.lblProcOK)
        Me.GroupBox2.Controls.Add(Me.lblTotalImp)
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.lblDescripcionArt)
        Me.GroupBox2.Controls.Add(Me.btnBusqArt)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtCodArt)
        Me.GroupBox2.Controls.Add(Me.lvwConsulta)
        Me.GroupBox2.Controls.Add(Me.NumCantidad)
        Me.GroupBox2.Controls.Add(Me.btnAgregar)
        Me.GroupBox2.Controls.Add(Me.btnEliminar)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Gainsboro
        Me.GroupBox2.Location = New System.Drawing.Point(17, 294)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1845, 837)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detalle de la Orden"
        '
        'lblProcErr
        '
        Me.lblProcErr.AutoSize = True
        Me.lblProcErr.ForeColor = System.Drawing.Color.OrangeRed
        Me.lblProcErr.Location = New System.Drawing.Point(771, 782)
        Me.lblProcErr.Name = "lblProcErr"
        Me.lblProcErr.Size = New System.Drawing.Size(304, 32)
        Me.lblProcErr.TabIndex = 21
        Me.lblProcErr.Text = "Procesados ERROR: 0"
        '
        'lblProcOK
        '
        Me.lblProcOK.AutoSize = True
        Me.lblProcOK.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.lblProcOK.Location = New System.Drawing.Point(457, 782)
        Me.lblProcOK.Name = "lblProcOK"
        Me.lblProcOK.Size = New System.Drawing.Size(244, 32)
        Me.lblProcOK.TabIndex = 20
        Me.lblProcOK.Text = "Procesados OK: 0"
        '
        'lblTotalImp
        '
        Me.lblTotalImp.AutoSize = True
        Me.lblTotalImp.Location = New System.Drawing.Point(119, 782)
        Me.lblTotalImp.Name = "lblTotalImp"
        Me.lblTotalImp.Size = New System.Drawing.Size(258, 32)
        Me.lblTotalImp.TabIndex = 19
        Me.lblTotalImp.Text = "Total Importados: 0"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(1432, 50)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(173, 38)
        Me.TextBox1.TabIndex = 18
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(1288, 50)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(138, 32)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Precio U :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(968, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(145, 32)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Cantidad :"
        '
        'lblDescripcionArt
        '
        Me.lblDescripcionArt.AutoSize = True
        Me.lblDescripcionArt.Location = New System.Drawing.Point(418, 53)
        Me.lblDescripcionArt.Name = "lblDescripcionArt"
        Me.lblDescripcionArt.Size = New System.Drawing.Size(525, 32)
        Me.lblDescripcionArt.TabIndex = 15
        Me.lblDescripcionArt.Text = "__________________________________"
        '
        'btnBusqArt
        '
        Me.btnBusqArt.AutoSize = True
        Me.btnBusqArt.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnBusqArt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBusqArt.Location = New System.Drawing.Point(344, 46)
        Me.btnBusqArt.Name = "btnBusqArt"
        Me.btnBusqArt.Size = New System.Drawing.Size(56, 45)
        Me.btnBusqArt.TabIndex = 14
        Me.btnBusqArt.Text = "..."
        Me.btnBusqArt.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(35, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(126, 32)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Articulo :"
        '
        'txtCodArt
        '
        Me.txtCodArt.Location = New System.Drawing.Point(167, 50)
        Me.txtCodArt.Name = "txtCodArt"
        Me.txtCodArt.Size = New System.Drawing.Size(161, 38)
        Me.txtCodArt.TabIndex = 13
        Me.txtCodArt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frmStkOrdenCompraABM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 31.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1875, 1240)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmStkOrdenCompraABM"
        Me.Text = "Atal de Orden de Compra"
        CType(Me.NumCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgAbrir, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnEliminar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents NumCantidad As NumericUpDown
    Friend WithEvents lvwConsulta As ListView
    Friend WithEvents imgAbrir As PictureBox
    Friend WithEvents txtProove As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dtpFechaEntrega As DateTimePicker
    Friend WithEvents btnBusqProv As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnAgregar As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents btnGuardar As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lblNomProove As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblDescripcionArt As Label
    Friend WithEvents btnBusqArt As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents txtCodArt As TextBox
    Friend WithEvents txtObservac As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblProcErr As Label
    Friend WithEvents lblProcOK As Label
    Friend WithEvents lblTotalImp As Label
End Class
