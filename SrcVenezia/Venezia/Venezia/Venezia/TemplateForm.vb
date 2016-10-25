Public Class TemplateForm
    Inherits System.Windows.Forms.Form

#Region "Declaraciones"

    Public Enum EnuOPERACION
        CONS = 1
        ALTA = 2
        MODIF = 3
        BAJA = 4
        ELIMINA = 5
        SEGINF = 6
        ADMIN = 7
        SUPERVISION = 8
    End Enum

    Dim lOper As New EnuOPERACION
    Public Property TipoDeOperacion() As EnuOPERACION
        Get
            Return lOper
        End Get
        Set(ByVal Value As EnuOPERACION)
            lOper = Value
        End Set
    End Property

    Dim lMensaje As String
    Public Property Mensaje() As String
        Get
            Return lMensaje
        End Get
        Set(ByVal Value As String)
            lMensaje = Value
        End Set
    End Property

    'Este es el formulario llamador, al cual despues de hacer alguna modificacion quiero
    'que se actualice.
    Public FrmLlamador As TemplateForm
    Public Overridable Sub ActualizarForm()

    End Sub

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

    Public Sub New()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TemplateForm))
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        'Me.Cursor = System.Windows.Forms.Cursors.Default
        'Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.1!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Gainsboro
        Me.Icon = CType(My.Resources.Logo, System.Drawing.Icon)
        Me.AutoSize = True
    End Sub



End Class
