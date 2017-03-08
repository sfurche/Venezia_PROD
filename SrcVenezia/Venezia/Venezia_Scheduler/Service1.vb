Imports System.Timers
Imports System.Diagnostics

Public Class Service1

    Public Sub New()

        MyBase.New()
        InitializeComponent()
        If Not System.Diagnostics.EventLog.SourceExists("Venezia_Scheduler") Then
            System.Diagnostics.EventLog.CreateEventSource("Venezia_Scheduler",
            "Venezia_Scheduler_Log")
        End If
        EventLogPpal.Source = "Venezia_Scheduler"
        EventLogPpal.Log = "Venezia_Scheduler_Log"

    End Sub

    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.

        EventLogPpal.WriteEntry("Inicio el servicio " & Now.ToString)

        TimerPpal.Interval = 5 * 1000 '5 segundos
        TimerPpal.Start()

    End Sub


    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.

        TimerPpal.Stop()

        EventLogPpal.WriteEntry("Finalizo el servicio " & Now.ToString)

    End Sub

    Private Sub TimerPpal_Tick(sender As Object, e As EventArgs) Handles TimerPpal.Tick
        MsgBox("Probando")
    End Sub
End Class
