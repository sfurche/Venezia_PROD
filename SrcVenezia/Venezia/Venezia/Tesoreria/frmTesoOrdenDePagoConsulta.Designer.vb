<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTesoOrdenDePagoConsulta
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
        Me.cmbDestino = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtIdOrden = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpFechaD = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaH = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnAplicar = New System.Windows.Forms.Button()
        Me.cmbEstados = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnAbrir = New System.Windows.Forms.Button()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lvwConsulta = New System.Windows.Forms.ListView()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnBusq)
        Me.GroupBox1.Controls.Add(Me.lblNomProove)
        Me.GroupBox1.Controls.Add(Me.txtProove)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cmbDestino)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtIdOrden)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.dtpFechaD)
        Me.GroupBox1.Controls.Add(Me.dtpFechaH)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btnAplicar)
        Me.GroupBox1.Controls.Add(Me.cmbEstados)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Gainsboro
        Me.GroupBox1.Location = New System.Drawing.Point(5, 4)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(1)
        Me.GroupBox1.Size = New System.Drawing.Size(831, 82)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros de Busqueda"
        '
        'btnBusq
        '
        Me.btnBusq.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnBusq.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBusq.Location = New System.Drawing.Point(337, 50)
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
        Me.lblNomProove.Location = New System.Drawing.Point(363, 54)
        Me.lblNomProove.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.lblNomProove.Name = "lblNomProove"
        Me.lblNomProove.Size = New System.Drawing.Size(115, 13)
        Me.lblNomProove.TabIndex = 54
        Me.lblNomProove.Text = "__________________"
        '
        'txtProove
        '
        Me.txtProove.Location = New System.Drawing.Point(273, 52)
        Me.txtProove.Margin = New System.Windows.Forms.Padding(1)
        Me.txtProove.Name = "txtProove"
        Me.txtProove.Size = New System.Drawing.Size(62, 20)
        Me.txtProove.TabIndex = 6
        Me.txtProove.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(213, 54)
        Me.Label6.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 13)
        Me.Label6.TabIndex = 52
        Me.Label6.Text = "Proveedor:"
        '
        'cmbDestino
        '
        Me.cmbDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDestino.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbDestino.FormattingEnabled = True
        Me.cmbDestino.Location = New System.Drawing.Point(52, 52)
        Me.cmbDestino.Margin = New System.Windows.Forms.Padding(1)
        Me.cmbDestino.Name = "cmbDestino"
        Me.cmbDestino.Size = New System.Drawing.Size(145, 21)
        Me.cmbDestino.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 54)
        Me.Label3.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 51
        Me.Label3.Text = "Destino:"
        '
        'txtIdOrden
        '
        Me.txtIdOrden.Location = New System.Drawing.Point(427, 22)
        Me.txtIdOrden.Margin = New System.Windows.Forms.Padding(1)
        Me.txtIdOrden.Name = "txtIdOrden"
        Me.txtIdOrden.Size = New System.Drawing.Size(78, 20)
        Me.txtIdOrden.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(374, 22)
        Me.Label5.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 46
        Me.Label5.Text = "Id Orden:"
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
        Me.dtpFechaH.Location = New System.Drawing.Point(265, 22)
        Me.dtpFechaH.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpFechaH.Name = "dtpFechaH"
        Me.dtpFechaH.Size = New System.Drawing.Size(99, 20)
        Me.dtpFechaH.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(226, 22)
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
        'btnAplicar
        '
        Me.btnAplicar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAplicar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAplicar.Location = New System.Drawing.Point(737, 28)
        Me.btnAplicar.Margin = New System.Windows.Forms.Padding(1)
        Me.btnAplicar.Name = "btnAplicar"
        Me.btnAplicar.Size = New System.Drawing.Size(78, 30)
        Me.btnAplicar.TabIndex = 8
        Me.btnAplicar.Text = "&Aplicar"
        Me.btnAplicar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAplicar.UseVisualStyleBackColor = False
        '
        'cmbEstados
        '
        Me.cmbEstados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstados.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbEstados.FormattingEnabled = True
        Me.cmbEstados.Location = New System.Drawing.Point(565, 21)
        Me.cmbEstados.Margin = New System.Windows.Forms.Padding(1)
        Me.cmbEstados.Name = "cmbEstados"
        Me.cmbEstados.Size = New System.Drawing.Size(117, 21)
        Me.cmbEstados.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(520, 24)
        Me.Label7.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Estado:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnAbrir)
        Me.GroupBox2.Controls.Add(Me.lblTotal)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.lvwConsulta)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Gainsboro
        Me.GroupBox2.Location = New System.Drawing.Point(5, 88)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(1)
        Me.GroupBox2.Size = New System.Drawing.Size(831, 369)
        Me.GroupBox2.TabIndex = 19
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Ordenes de Pago"
        '
        'btnAbrir
        '
        Me.btnAbrir.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnAbrir.ForeColor = System.Drawing.Color.Gainsboro
        Me.btnAbrir.Location = New System.Drawing.Point(17, 343)
        Me.btnAbrir.Name = "btnAbrir"
        Me.btnAbrir.Size = New System.Drawing.Size(75, 23)
        Me.btnAbrir.TabIndex = 29
        Me.btnAbrir.Text = "Abrir"
        Me.btnAbrir.UseVisualStyleBackColor = False
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.900001!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(630, 343)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(28, 17)
        Me.lblTotal.TabIndex = 28
        Me.lblTotal.Text = "$ 0"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.900001!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(575, 343)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(44, 17)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "Total:"
        '
        'lvwConsulta
        '
        Me.lvwConsulta.FullRowSelect = True
        Me.lvwConsulta.GridLines = True
        Me.lvwConsulta.Location = New System.Drawing.Point(6, 16)
        Me.lvwConsulta.Margin = New System.Windows.Forms.Padding(1)
        Me.lvwConsulta.Name = "lvwConsulta"
        Me.lvwConsulta.Size = New System.Drawing.Size(820, 325)
        Me.lvwConsulta.TabIndex = 0
        Me.lvwConsulta.UseCompatibleStateImageBehavior = False
        Me.lvwConsulta.View = System.Windows.Forms.View.Details
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Location = New System.Drawing.Point(736, 459)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(1)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(95, 21)
        Me.btnSalir.TabIndex = 20
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'frmTesoOrdenDePagoConsulta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(841, 482)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnSalir)
        Me.Margin = New System.Windows.Forms.Padding(1)
        Me.Name = "frmTesoOrdenDePagoConsulta"
        Me.Text = "Consulta de Ordenes de Pago"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtIdOrden As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents dtpFechaD As DateTimePicker
    Friend WithEvents dtpFechaH As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnAplicar As Button
    Friend WithEvents cmbEstados As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lblTotal As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents lvwConsulta As ListView
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnBusq As Button
    Friend WithEvents lblNomProove As Label
    Friend WithEvents txtProove As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbDestino As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnAbrir As Button
End Class
