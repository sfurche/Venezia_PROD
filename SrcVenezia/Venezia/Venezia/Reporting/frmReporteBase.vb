Imports Microsoft.Reporting.WinForms
Imports System.IO
Public Class frmReporteBase
    'Public mDt As DataTable = Nothing
    Public mArrParameters As ArrayList = Nothing ' Arraylist de objetos tipo ReportParameter
    Public mArrDataSources As ArrayList = Nothing ' Arraylist de objetos tipo ReportDataSource
    Public mRDLCPath As String
    Public mPageSettings As System.Drawing.Printing.PageSettings = Nothing
    Public mRptName As String = "NombreReporte"

    Private Sub frmReporteBase_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim lParameter As ReportParameter = Nothing
        Dim lRds As ReportDataSource = Nothing
        Try

            If IsNothing(mArrDataSources) Or IsNothing(mArrParameters) Or mRDLCPath.Trim = "" Then
                MsgBox("Error al crear el reporte", MsgBoxStyle.Critical)
                Me.Close()
            End If

            'Busco la ruta fisica del rdlc (IMPORTANTE: Para que funcine el RDLC tiene que tener seteado generar copia local)
            Dim exeFolder As String = Path.GetDirectoryName(Application.ExecutablePath)
            Dim reportPath As String = Path.Combine(exeFolder, "Reporting\" & mRDLCPath.Trim)

            rptViewer.LocalReport.ReportPath = reportPath
            rptViewer.LocalReport.DataSources.Clear()

            'Cargo los parametros
            For Each lParameter In mArrParameters
                rptViewer.LocalReport.SetParameters(DirectCast(lParameter, ReportParameter))
            Next

            'Cargo los datasets para la consulta de info.
            For Each lRds In mArrDataSources
                rptViewer.LocalReport.DataSources.Add(lRds)
            Next

            'Cargo la configuracion de la pagina
            rptViewer.SetPageSettings(mPageSettings)
            rptViewer.LocalReport.DisplayName = mRptName

            rptViewer.RefreshReport()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "frmReporteBase.frmReporteBase_Load")
            gAdmin.Log.fncGrabarLogERR("Error en frmReporteBase.frmReporteBase_Load" & ex.Message)
        End Try

    End Sub

End Class