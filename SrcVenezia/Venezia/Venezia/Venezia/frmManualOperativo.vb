Public Class frmManualOperativo
    Private Sub frmManualOperativo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AxAcroPDF1.src = System.Windows.Forms.Application.StartupPath() & "\ManualOperativo.pdf"
    End Sub
End Class