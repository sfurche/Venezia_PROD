Imports System.Data.OleDb
Public Class frmFondoPantalla

#Region " Código generado por el Diseñador de Windows Forms "
    Inherits FrmBase
    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnAplicar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents PicPreview As System.Windows.Forms.PictureBox
    Friend WithEvents optCentrar As System.Windows.Forms.RadioButton
    Friend WithEvents optNormal As System.Windows.Forms.RadioButton
    Friend WithEvents optAjustar As System.Windows.Forms.RadioButton
    Friend WithEvents lblImagen As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnSinImagen As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optAjustar = New System.Windows.Forms.RadioButton()
        Me.btnSinImagen = New System.Windows.Forms.Button()
        Me.optNormal = New System.Windows.Forms.RadioButton()
        Me.optCentrar = New System.Windows.Forms.RadioButton()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.lblImagen = New System.Windows.Forms.Label()
        Me.PicPreview = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnAplicar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PicPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optAjustar)
        Me.GroupBox1.Controls.Add(Me.btnSinImagen)
        Me.GroupBox1.Controls.Add(Me.optNormal)
        Me.GroupBox1.Controls.Add(Me.optCentrar)
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Controls.Add(Me.lblImagen)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(264, 233)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Imagen de Fondo"
        '
        'optAjustar
        '
        Me.optAjustar.Checked = True
        Me.optAjustar.Location = New System.Drawing.Point(24, 191)
        Me.optAjustar.Name = "optAjustar"
        Me.optAjustar.Size = New System.Drawing.Size(64, 24)
        Me.optAjustar.TabIndex = 28
        Me.optAjustar.TabStop = True
        Me.optAjustar.Text = "Ajustar"
        '
        'btnSinImagen
        '
        Me.btnSinImagen.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSinImagen.Location = New System.Drawing.Point(168, 24)
        Me.btnSinImagen.Name = "btnSinImagen"
        Me.btnSinImagen.Size = New System.Drawing.Size(88, 37)
        Me.btnSinImagen.TabIndex = 27
        Me.btnSinImagen.Text = "Sin Imagen"
        '
        'optNormal
        '
        Me.optNormal.Location = New System.Drawing.Point(104, 191)
        Me.optNormal.Name = "optNormal"
        Me.optNormal.Size = New System.Drawing.Size(64, 24)
        Me.optNormal.TabIndex = 26
        Me.optNormal.Text = "Normal"
        '
        'optCentrar
        '
        Me.optCentrar.Location = New System.Drawing.Point(176, 191)
        Me.optCentrar.Name = "optCentrar"
        Me.optCentrar.Size = New System.Drawing.Size(64, 24)
        Me.optCentrar.TabIndex = 25
        Me.optCentrar.Text = "Centrar"
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Location = New System.Drawing.Point(16, 24)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(144, 37)
        Me.btnBuscar.TabIndex = 24
        Me.btnBuscar.Text = "Buscar una imagen ..."
        '
        'lblImagen
        '
        Me.lblImagen.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImagen.Location = New System.Drawing.Point(16, 64)
        Me.lblImagen.Name = "lblImagen"
        Me.lblImagen.Size = New System.Drawing.Size(240, 124)
        Me.lblImagen.TabIndex = 23
        Me.lblImagen.Text = "Imagen :"
        '
        'PicPreview
        '
        Me.PicPreview.Location = New System.Drawing.Point(9, 20)
        Me.PicPreview.Name = "PicPreview"
        Me.PicPreview.Size = New System.Drawing.Size(255, 231)
        Me.PicPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicPreview.TabIndex = 2
        Me.PicPreview.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.PicPreview)
        Me.GroupBox2.Location = New System.Drawing.Point(280, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(277, 261)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Muestra"
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Location = New System.Drawing.Point(192, 247)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 3
        Me.btnSalir.Text = "Salir"
        '
        'btnAplicar
        '
        Me.btnAplicar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAplicar.Location = New System.Drawing.Point(104, 247)
        Me.btnAplicar.Name = "btnAplicar"
        Me.btnAplicar.Size = New System.Drawing.Size(75, 23)
        Me.btnAplicar.TabIndex = 4
        Me.btnAplicar.Text = "Aplicar"
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Location = New System.Drawing.Point(16, 247)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.Text = "Aceptar"
        '
        'frmFondoPantalla
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.ClientSize = New System.Drawing.Size(569, 281)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnAplicar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmFondoPantalla"
        Me.Opacity = 0.01R
        Me.Text = "frmFondoPantalla"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PicPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Declaraciones"
    Dim gPathImagen As String = ""
    Dim gSizeModeImag As Integer
#End Region

    Private Sub optNormal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optNormal.CheckedChanged
        If optNormal.Checked = True Then
            PicPreview.SizeMode = PictureBoxSizeMode.Normal
        End If
    End Sub

    Private Sub optCentrar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCentrar.CheckedChanged
        If optCentrar.Checked = True Then
            PicPreview.SizeMode = PictureBoxSizeMode.CenterImage
        End If
    End Sub

    Private Sub optAjustar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optAjustar.CheckedChanged
        If optAjustar.Checked = True Then
            PicPreview.SizeMode = PictureBoxSizeMode.StretchImage
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click

        OpenFileDialog1.Title = "Abrir una imagen"
        OpenFileDialog1.Filter = "Imagenes (*.Jpg)|*.jpg|Dibujos (*.Bmp)|*.bmp|Archivos (*.Gif)|*.gif"

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            lblImagen.Text = "Imagen: " & OpenFileDialog1.FileName
            PicPreview.Image = Image.FromFile(OpenFileDialog1.FileName)
            PicPreview.Show()
            gPathImagen = OpenFileDialog1.FileName
        End If


    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnAplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAplicar.Click
        Dim MiFormPadre As frmPrincipal

        Try

            MiFormPadre = Me.MdiParent

            If gPathImagen.Length = 0 Then
                gSubGuardarFondo_registry("", 0)
            Else
                gSubGuardarFondo_registry(gPathImagen.Trim, PicPreview.SizeMode)
            End If

            MiFormPadre.SetFondoPantalla()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al setear el fondo de pantalla.")
        End Try
    End Sub

    Private Sub btnSinImagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSinImagen.Click
        lblImagen.Text = "Imagen: Sin imagen"
        PicPreview.Image = Nothing
        gPathImagen = ""
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            btnAplicar_Click(Me, Nothing)
            Me.Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al setear el fondo de pantalla.")
        End Try
    End Sub

    Private Sub frmFondoPantalla_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            gPathImagen = gFncGetValorFondo_Registry("Background")
            gSizeModeImag = Integer.Parse(gFncGetValorFondo_Registry("BackGrSizeMode"))
            If gPathImagen = "" Then
                lblImagen.Text = "imagen: Sin imagen"
            Else
                lblImagen.Text = "imagen: " & gPathImagen
                PicPreview.Image = Image.FromFile(gPathImagen)
                PicPreview.SizeMode = gSizeModeImag
                PicPreview.Show()
            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error cargando el fondo de pantalla")
        End Try
    End Sub

End Class
