<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTesoLiqConciliacion
    Inherits TemplateForm

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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblResta = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.picConciliaExacta = New System.Windows.Forms.PictureBox()
        Me.cmbLiquidacion = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnAplicarParcial = New System.Windows.Forms.Button()
        Me.chkAllVen = New System.Windows.Forms.CheckBox()
        Me.chkRecHist = New System.Windows.Forms.CheckBox()
        Me.lblTotalLiq = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lvwConsulta = New System.Windows.Forms.ListView()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.picConciliaExacta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblResta)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.picConciliaExacta)
        Me.GroupBox1.Controls.Add(Me.cmbLiquidacion)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Gainsboro
        Me.GroupBox1.Location = New System.Drawing.Point(13, 26)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1914, 140)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Liquidaciones pendienes de conciliacion"
        '
        'lblResta
        '
        Me.lblResta.AutoSize = True
        Me.lblResta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.900001!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResta.ForeColor = System.Drawing.Color.Red
        Me.lblResta.Location = New System.Drawing.Point(1667, 70)
        Me.lblResta.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.lblResta.Name = "lblResta"
        Me.lblResta.Size = New System.Drawing.Size(64, 39)
        Me.lblResta.TabIndex = 30
        Me.lblResta.Text = "$ 0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.900001!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(1520, 70)
        Me.Label2.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 39)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Resta:"
        '
        'picConciliaExacta
        '
        Me.picConciliaExacta.Image = Global.Venezia.My.Resources.Resources.check2
        Me.picConciliaExacta.Location = New System.Drawing.Point(1375, 61)
        Me.picConciliaExacta.Name = "picConciliaExacta"
        Me.picConciliaExacta.Size = New System.Drawing.Size(48, 48)
        Me.picConciliaExacta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picConciliaExacta.TabIndex = 15
        Me.picConciliaExacta.TabStop = False
        Me.picConciliaExacta.Visible = False
        '
        'cmbLiquidacion
        '
        Me.cmbLiquidacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLiquidacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbLiquidacion.FormattingEnabled = True
        Me.cmbLiquidacion.Location = New System.Drawing.Point(423, 61)
        Me.cmbLiquidacion.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbLiquidacion.Name = "cmbLiquidacion"
        Me.cmbLiquidacion.Size = New System.Drawing.Size(892, 39)
        Me.cmbLiquidacion.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(50, 61)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(348, 32)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Seleccione la Liquidacion:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnAplicarParcial)
        Me.GroupBox2.Controls.Add(Me.chkAllVen)
        Me.GroupBox2.Controls.Add(Me.chkRecHist)
        Me.GroupBox2.Controls.Add(Me.lblTotalLiq)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.lvwConsulta)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Gainsboro
        Me.GroupBox2.Location = New System.Drawing.Point(13, 172)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1914, 827)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Recibos"
        '
        'btnAplicarParcial
        '
        Me.btnAplicarParcial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAplicarParcial.Location = New System.Drawing.Point(615, 764)
        Me.btnAplicarParcial.Name = "btnAplicarParcial"
        Me.btnAplicarParcial.Size = New System.Drawing.Size(253, 50)
        Me.btnAplicarParcial.TabIndex = 15
        Me.btnAplicarParcial.Text = "Aplica Parcial"
        Me.btnAplicarParcial.UseVisualStyleBackColor = False
        '
        'chkAllVen
        '
        Me.chkAllVen.AutoSize = True
        Me.chkAllVen.Location = New System.Drawing.Point(286, 772)
        Me.chkAllVen.Name = "chkAllVen"
        Me.chkAllVen.Size = New System.Drawing.Size(301, 36)
        Me.chkAllVen.TabIndex = 30
        Me.chkAllVen.Text = "Ver todas las zonas"
        Me.chkAllVen.UseVisualStyleBackColor = True
        '
        'chkRecHist
        '
        Me.chkRecHist.AutoSize = True
        Me.chkRecHist.Location = New System.Drawing.Point(40, 772)
        Me.chkRecHist.Name = "chkRecHist"
        Me.chkRecHist.Size = New System.Drawing.Size(229, 36)
        Me.chkRecHist.TabIndex = 29
        Me.chkRecHist.Text = "Ver Historicos"
        Me.chkRecHist.UseVisualStyleBackColor = True
        '
        'lblTotalLiq
        '
        Me.lblTotalLiq.AutoSize = True
        Me.lblTotalLiq.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.900001!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalLiq.Location = New System.Drawing.Point(1636, 769)
        Me.lblTotalLiq.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.lblTotalLiq.Name = "lblTotalLiq"
        Me.lblTotalLiq.Size = New System.Drawing.Size(64, 39)
        Me.lblTotalLiq.TabIndex = 28
        Me.lblTotalLiq.Text = "$ 0"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.900001!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(1489, 769)
        Me.Label14.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(102, 39)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "Total:"
        '
        'lvwConsulta
        '
        Me.lvwConsulta.CheckBoxes = True
        Me.lvwConsulta.FullRowSelect = True
        Me.lvwConsulta.GridLines = True
        Me.lvwConsulta.Location = New System.Drawing.Point(17, 37)
        Me.lvwConsulta.Name = "lvwConsulta"
        Me.lvwConsulta.Size = New System.Drawing.Size(1882, 695)
        Me.lvwConsulta.TabIndex = 0
        Me.lvwConsulta.UseCompatibleStateImageBehavior = False
        Me.lvwConsulta.View = System.Windows.Forms.View.Details
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Location = New System.Drawing.Point(1674, 1026)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(253, 50)
        Me.btnSalir.TabIndex = 14
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Location = New System.Drawing.Point(1400, 1026)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(253, 50)
        Me.btnAceptar.TabIndex = 13
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'frmTesoLiqConciliacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 31.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1939, 1094)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmTesoLiqConciliacion"
        Me.Text = "Conciliacion de Liquidaciones"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.picConciliaExacta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cmbLiquidacion As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents lvwConsulta As ListView
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnAceptar As Button
    Friend WithEvents lblTotalLiq As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents picConciliaExacta As PictureBox
    Friend WithEvents lblResta As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents chkAllVen As CheckBox
    Friend WithEvents chkRecHist As CheckBox
    Friend WithEvents btnAplicarParcial As Button
End Class
