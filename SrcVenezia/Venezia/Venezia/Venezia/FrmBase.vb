
Imports System.ComponentModel

Public Class FrmBase
    Inherits TemplateForm

#Region " Código generado por el Diseñador de Windows Forms "

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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBase))
        Me.SuspendLayout()
        '
        'FrmBase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 31.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(650, 430)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Gainsboro
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.MaximizeBox = False
        Me.Name = "FrmBase"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Base"
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Declaraciones"

    'Public Enum EnuOPERACION
    '    CONS = 1
    '    ALTA = 2
    '    MODIF = 3
    '    BAJA = 4
    '    ELIMINA = 5
    '    SEGINF = 6
    '    ADMIN = 7
    'End Enum

    'Dim lOper As New EnuOPERACION
    'Public Property TipoDeOperacion() As EnuOPERACION
    '    Get
    '        Return lOper
    '    End Get
    '    Set(ByVal Value As EnuOPERACION)
    '        lOper = Value
    '    End Set
    'End Property

    'Dim lMensaje As String
    'Public Property Mensaje() As String
    '    Get
    '        Return lMensaje
    '    End Get
    '    Set(ByVal Value As String)
    '        lMensaje = Value
    '    End Set
    'End Property

    ''Este es el formulario llamador, al cual despues de hacer alguna modificacion quiero
    ''que se actualice.
    'Public FrmLlamador As FrmBase
    'Public Overridable Sub ActualizarForm()

    'End Sub

#End Region

    Private Sub FrmBase_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Dim Fppal As frmPrincipal
        Fppal = Me.MdiParent
        'If Me.IsMdiContainer = False Then
        '    Fppal.SetStPPal(Me.Text, lMensaje)
        'Else
        '    CType(Me, frmPrincipal).SetStPPal("Principal", lMensaje)
        'End If
    End Sub

    Private Sub FrmBase_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        Dim Fppal As frmPrincipal
        If Me.IsMdiContainer = False Then
            Fppal = Me.MdiParent
            'If Fppal.MdiChildren.Length - 1 = 0 Then 'El -1 es por el que estoy cerrando
            '    Fppal.SetStPPal("Principal", Fppal.lMensaje)
            'End If
        End If
    End Sub

End Class
