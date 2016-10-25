<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTesoLiquidacionesAltaRapida
    Inherits FrmBase

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
        Me.groupGeneral = New System.Windows.Forms.GroupBox()
        Me.txtTotalCheques = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblTotalLiq = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbVendedores = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTotalRet = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTotalEfectivo = New System.Windows.Forms.TextBox()
        Me.txtTotalTransf = New System.Windows.Forms.TextBox()
        Me.txtTotalNC = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFechaLiq = New System.Windows.Forms.DateTimePicker()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.groupGeneral.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupGeneral
        '
        Me.groupGeneral.Controls.Add(Me.txtTotalCheques)
        Me.groupGeneral.Controls.Add(Me.Label12)
        Me.groupGeneral.Controls.Add(Me.lblTotalLiq)
        Me.groupGeneral.Controls.Add(Me.Label14)
        Me.groupGeneral.Controls.Add(Me.cmbVendedores)
        Me.groupGeneral.Controls.Add(Me.Label7)
        Me.groupGeneral.Controls.Add(Me.txtTotalRet)
        Me.groupGeneral.Controls.Add(Me.Label6)
        Me.groupGeneral.Controls.Add(Me.txtTotalEfectivo)
        Me.groupGeneral.Controls.Add(Me.txtTotalTransf)
        Me.groupGeneral.Controls.Add(Me.txtTotalNC)
        Me.groupGeneral.Controls.Add(Me.Label4)
        Me.groupGeneral.Controls.Add(Me.Label3)
        Me.groupGeneral.Controls.Add(Me.Label2)
        Me.groupGeneral.Controls.Add(Me.Label1)
        Me.groupGeneral.Controls.Add(Me.dtpFechaLiq)
        Me.groupGeneral.ForeColor = System.Drawing.Color.Gainsboro
        Me.groupGeneral.Location = New System.Drawing.Point(12, 31)
        Me.groupGeneral.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.groupGeneral.Name = "groupGeneral"
        Me.groupGeneral.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.groupGeneral.Size = New System.Drawing.Size(2067, 248)
        Me.groupGeneral.TabIndex = 6
        Me.groupGeneral.TabStop = False
        Me.groupGeneral.Text = "Datos Generales"
        '
        'txtTotalCheques
        '
        Me.txtTotalCheques.Location = New System.Drawing.Point(538, 145)
        Me.txtTotalCheques.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTotalCheques.Name = "txtTotalCheques"
        Me.txtTotalCheques.Size = New System.Drawing.Size(225, 38)
        Me.txtTotalCheques.TabIndex = 4
        Me.txtTotalCheques.Text = "0"
        Me.txtTotalCheques.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(395, 145)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(137, 32)
        Me.Label12.TabIndex = 28
        Me.Label12.Text = "Cheques:"
        '
        'lblTotalLiq
        '
        Me.lblTotalLiq.AutoSize = True
        Me.lblTotalLiq.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.900001!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalLiq.Location = New System.Drawing.Point(1793, 48)
        Me.lblTotalLiq.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.lblTotalLiq.Name = "lblTotalLiq"
        Me.lblTotalLiq.Size = New System.Drawing.Size(64, 39)
        Me.lblTotalLiq.TabIndex = 26
        Me.lblTotalLiq.Text = "$ 0"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.900001!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(1666, 48)
        Me.Label14.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(102, 39)
        Me.Label14.TabIndex = 25
        Me.Label14.Text = "Total:"
        '
        'cmbVendedores
        '
        Me.cmbVendedores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVendedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbVendedores.FormattingEnabled = True
        Me.cmbVendedores.Location = New System.Drawing.Point(808, 48)
        Me.cmbVendedores.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbVendedores.Name = "cmbVendedores"
        Me.cmbVendedores.Size = New System.Drawing.Size(585, 39)
        Me.cmbVendedores.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(650, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(147, 32)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Vendedor:"
        '
        'txtTotalRet
        '
        Me.txtTotalRet.Location = New System.Drawing.Point(1480, 145)
        Me.txtTotalRet.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTotalRet.Name = "txtTotalRet"
        Me.txtTotalRet.Size = New System.Drawing.Size(206, 38)
        Me.txtTotalRet.TabIndex = 6
        Me.txtTotalRet.Text = "0"
        Me.txtTotalRet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(1296, 145)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(182, 32)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Retenciones:"
        '
        'txtTotalEfectivo
        '
        Me.txtTotalEfectivo.Location = New System.Drawing.Point(158, 145)
        Me.txtTotalEfectivo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTotalEfectivo.Name = "txtTotalEfectivo"
        Me.txtTotalEfectivo.Size = New System.Drawing.Size(209, 38)
        Me.txtTotalEfectivo.TabIndex = 3
        Me.txtTotalEfectivo.Text = "0"
        Me.txtTotalEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalTransf
        '
        Me.txtTotalTransf.Location = New System.Drawing.Point(1016, 145)
        Me.txtTotalTransf.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTotalTransf.Name = "txtTotalTransf"
        Me.txtTotalTransf.Size = New System.Drawing.Size(229, 38)
        Me.txtTotalTransf.TabIndex = 5
        Me.txtTotalTransf.Text = "0"
        Me.txtTotalTransf.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalNC
        '
        Me.txtTotalNC.Location = New System.Drawing.Point(1787, 145)
        Me.txtTotalNC.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTotalNC.Name = "txtTotalNC"
        Me.txtTotalNC.Size = New System.Drawing.Size(225, 38)
        Me.txtTotalNC.TabIndex = 7
        Me.txtTotalNC.Text = "0"
        Me.txtTotalNC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(1709, 145)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 32)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "NC:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(805, 145)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(211, 32)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Transferencias:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(37, 145)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 32)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Efectivo:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(299, 32)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Fecha De Liquidacion:"
        '
        'dtpFechaLiq
        '
        Me.dtpFechaLiq.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaLiq.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaLiq.Location = New System.Drawing.Point(360, 48)
        Me.dtpFechaLiq.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtpFechaLiq.Name = "dtpFechaLiq"
        Me.dtpFechaLiq.Size = New System.Drawing.Size(257, 38)
        Me.dtpFechaLiq.TabIndex = 1
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Location = New System.Drawing.Point(1520, 326)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(253, 50)
        Me.btnAceptar.TabIndex = 8
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Location = New System.Drawing.Point(1789, 326)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(253, 50)
        Me.btnSalir.TabIndex = 12
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'frmTesoLiquidacionesAltaRapida
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 31.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(2105, 413)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.groupGeneral)
        Me.Name = "frmTesoLiquidacionesAltaRapida"
        Me.Text = "Liquidaciones Alta Rapida"
        Me.groupGeneral.ResumeLayout(False)
        Me.groupGeneral.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents groupGeneral As GroupBox
    Friend WithEvents txtTotalCheques As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents lblTotalLiq As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents cmbVendedores As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtTotalRet As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtTotalEfectivo As TextBox
    Friend WithEvents txtTotalTransf As TextBox
    Friend WithEvents txtTotalNC As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpFechaLiq As DateTimePicker
    Friend WithEvents btnAceptar As Button
    Friend WithEvents btnSalir As Button
End Class
