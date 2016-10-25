<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTesoOrdenDePagoAlta
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnEliminarChk = New System.Windows.Forms.Button()
        Me.btnAddChk = New System.Windows.Forms.Button()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lvwConsulta = New System.Windows.Forms.ListView()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblEst = New System.Windows.Forms.Label()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.groupGeneral = New System.Windows.Forms.GroupBox()
        Me.btnBusq = New System.Windows.Forms.Button()
        Me.lblNomProove = New System.Windows.Forms.Label()
        Me.txtProove = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtObservac = New System.Windows.Forms.RichTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblTotalOrden = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbDestino = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTotalEfectivo = New System.Windows.Forms.TextBox()
        Me.txtTotalTransf = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox2.SuspendLayout()
        Me.groupGeneral.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Location = New System.Drawing.Point(1765, 1105)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(253, 50)
        Me.btnSalir.TabIndex = 7
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnEliminarChk)
        Me.GroupBox2.Controls.Add(Me.btnAddChk)
        Me.GroupBox2.Controls.Add(Me.lblTotal)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.lvwConsulta)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Gainsboro
        Me.GroupBox2.Location = New System.Drawing.Point(12, 378)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(2029, 709)
        Me.GroupBox2.TabIndex = 19
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Cheques"
        '
        'btnEliminarChk
        '
        Me.btnEliminarChk.AutoSize = True
        Me.btnEliminarChk.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminarChk.Image = Global.Venezia.My.Resources.Resources._24x24_delete2
        Me.btnEliminarChk.Location = New System.Drawing.Point(122, 624)
        Me.btnEliminarChk.Name = "btnEliminarChk"
        Me.btnEliminarChk.Size = New System.Drawing.Size(87, 79)
        Me.btnEliminarChk.TabIndex = 9
        Me.btnEliminarChk.UseVisualStyleBackColor = False
        '
        'btnAddChk
        '
        Me.btnAddChk.AutoSize = True
        Me.btnAddChk.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddChk.Image = Global.Venezia.My.Resources.Resources._24x24_add2
        Me.btnAddChk.Location = New System.Drawing.Point(29, 624)
        Me.btnAddChk.Name = "btnAddChk"
        Me.btnAddChk.Size = New System.Drawing.Size(87, 79)
        Me.btnAddChk.TabIndex = 8
        Me.btnAddChk.UseVisualStyleBackColor = False
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.900001!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(1663, 635)
        Me.lblTotal.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(64, 39)
        Me.lblTotal.TabIndex = 28
        Me.lblTotal.Text = "$ 0"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.900001!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(1391, 635)
        Me.Label14.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(248, 39)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "Total Cheques:"
        '
        'lvwConsulta
        '
        Me.lvwConsulta.CheckBoxes = True
        Me.lvwConsulta.FullRowSelect = True
        Me.lvwConsulta.GridLines = True
        Me.lvwConsulta.Location = New System.Drawing.Point(16, 37)
        Me.lvwConsulta.Name = "lvwConsulta"
        Me.lvwConsulta.Size = New System.Drawing.Size(1990, 575)
        Me.lvwConsulta.TabIndex = 0
        Me.lvwConsulta.UseCompatibleStateImageBehavior = False
        Me.lvwConsulta.View = System.Windows.Forms.View.Details
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Location = New System.Drawing.Point(1457, 1105)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(253, 50)
        Me.btnGuardar.TabIndex = 6
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'lblEst
        '
        Me.lblEst.AutoSize = True
        Me.lblEst.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEst.Location = New System.Drawing.Point(1691, 20)
        Me.lblEst.Name = "lblEst"
        Me.lblEst.Size = New System.Drawing.Size(112, 32)
        Me.lblEst.TabIndex = 23
        Me.lblEst.Text = "Estado:"
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Location = New System.Drawing.Point(1819, 20)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(89, 32)
        Me.lblEstado.TabIndex = 22
        Me.lblEstado.Text = "Inicial"
        '
        'groupGeneral
        '
        Me.groupGeneral.Controls.Add(Me.btnBusq)
        Me.groupGeneral.Controls.Add(Me.lblNomProove)
        Me.groupGeneral.Controls.Add(Me.txtProove)
        Me.groupGeneral.Controls.Add(Me.Label6)
        Me.groupGeneral.Controls.Add(Me.txtObservac)
        Me.groupGeneral.Controls.Add(Me.Label4)
        Me.groupGeneral.Controls.Add(Me.lblEst)
        Me.groupGeneral.Controls.Add(Me.lblEstado)
        Me.groupGeneral.Controls.Add(Me.lblTotalOrden)
        Me.groupGeneral.Controls.Add(Me.Label1)
        Me.groupGeneral.Controls.Add(Me.cmbDestino)
        Me.groupGeneral.Controls.Add(Me.Label7)
        Me.groupGeneral.Controls.Add(Me.txtTotalEfectivo)
        Me.groupGeneral.Controls.Add(Me.txtTotalTransf)
        Me.groupGeneral.Controls.Add(Me.Label3)
        Me.groupGeneral.Controls.Add(Me.Label2)
        Me.groupGeneral.Controls.Add(Me.Label5)
        Me.groupGeneral.Controls.Add(Me.dtpFecha)
        Me.groupGeneral.ForeColor = System.Drawing.Color.Gainsboro
        Me.groupGeneral.Location = New System.Drawing.Point(18, 5)
        Me.groupGeneral.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.groupGeneral.Name = "groupGeneral"
        Me.groupGeneral.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.groupGeneral.Size = New System.Drawing.Size(2023, 368)
        Me.groupGeneral.TabIndex = 21
        Me.groupGeneral.TabStop = False
        Me.groupGeneral.Text = "Datos Generales"
        '
        'btnBusq
        '
        Me.btnBusq.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnBusq.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBusq.Location = New System.Drawing.Point(903, 123)
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
        Me.lblNomProove.Location = New System.Drawing.Point(971, 132)
        Me.lblNomProove.Name = "lblNomProove"
        Me.lblNomProove.Size = New System.Drawing.Size(285, 32)
        Me.lblNomProove.TabIndex = 48
        Me.lblNomProove.Text = "__________________"
        '
        'txtProove
        '
        Me.txtProove.Location = New System.Drawing.Point(732, 129)
        Me.txtProove.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtProove.Name = "txtProove"
        Me.txtProove.Size = New System.Drawing.Size(158, 38)
        Me.txtProove.TabIndex = 4
        Me.txtProove.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(572, 132)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(154, 32)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Proveedor:"
        '
        'txtObservac
        '
        Me.txtObservac.Location = New System.Drawing.Point(18, 229)
        Me.txtObservac.Name = "txtObservac"
        Me.txtObservac.Size = New System.Drawing.Size(1982, 107)
        Me.txtObservac.TabIndex = 5
        Me.txtObservac.Text = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 193)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(213, 32)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Observaciones:"
        '
        'lblTotalOrden
        '
        Me.lblTotalOrden.AutoSize = True
        Me.lblTotalOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.900001!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalOrden.Location = New System.Drawing.Point(1771, 122)
        Me.lblTotalOrden.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.lblTotalOrden.Name = "lblTotalOrden"
        Me.lblTotalOrden.Size = New System.Drawing.Size(67, 39)
        Me.lblTotalOrden.TabIndex = 26
        Me.lblTotalOrden.Text = "$ 0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.900001!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(1644, 122)
        Me.Label1.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 39)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Total:"
        '
        'cmbDestino
        '
        Me.cmbDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDestino.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbDestino.FormattingEnabled = True
        Me.cmbDestino.Location = New System.Drawing.Point(143, 129)
        Me.cmbDestino.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbDestino.Name = "cmbDestino"
        Me.cmbDestino.Size = New System.Drawing.Size(381, 39)
        Me.cmbDestino.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(17, 132)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(120, 32)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Destino:"
        '
        'txtTotalEfectivo
        '
        Me.txtTotalEfectivo.Location = New System.Drawing.Point(659, 49)
        Me.txtTotalEfectivo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTotalEfectivo.Name = "txtTotalEfectivo"
        Me.txtTotalEfectivo.Size = New System.Drawing.Size(209, 38)
        Me.txtTotalEfectivo.TabIndex = 1
        Me.txtTotalEfectivo.Text = "0"
        Me.txtTotalEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalTransf
        '
        Me.txtTotalTransf.Location = New System.Drawing.Point(1265, 49)
        Me.txtTotalTransf.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTotalTransf.Name = "txtTotalTransf"
        Me.txtTotalTransf.Size = New System.Drawing.Size(229, 38)
        Me.txtTotalTransf.TabIndex = 2
        Me.txtTotalTransf.Text = "0"
        Me.txtTotalTransf.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(925, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(321, 32)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Total en Transferencias:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(419, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(235, 32)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Total en Efectivo:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(109, 32)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Fecha :"
        '
        'dtpFecha
        '
        Me.dtpFecha.CustomFormat = "dd/MM/yyyy"
        Me.dtpFecha.Enabled = False
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFecha.Location = New System.Drawing.Point(130, 49)
        Me.dtpFecha.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(257, 38)
        Me.dtpFecha.TabIndex = 0
        '
        'frmTesoOrdenDePagoAlta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 31.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2053, 1167)
        Me.Controls.Add(Me.groupGeneral)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnSalir)
        Me.Name = "frmTesoOrdenDePagoAlta"
        Me.Text = "Alta de Ordenes de Pago"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.groupGeneral.ResumeLayout(False)
        Me.groupGeneral.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnSalir As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lblTotal As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents lvwConsulta As ListView
    Friend WithEvents btnGuardar As Button
    Friend WithEvents lblEst As Label
    Friend WithEvents lblEstado As Label
    Friend WithEvents groupGeneral As GroupBox
    Friend WithEvents lblTotalOrden As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbDestino As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtTotalEfectivo As TextBox
    Friend WithEvents txtTotalTransf As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents dtpFecha As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents txtObservac As RichTextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents btnBusq As Button
    Friend WithEvents lblNomProove As Label
    Friend WithEvents txtProove As TextBox
    Friend WithEvents btnEliminarChk As Button
    Friend WithEvents btnAddChk As Button
End Class
