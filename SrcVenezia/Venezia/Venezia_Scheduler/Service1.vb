Imports System.Timers
Imports System.Diagnostics
Imports VzAdmin

Public Class Venezia__Scheduler

    Public gArraySchedules As ArrayList
    Public gAdmin As cAdmin


    Public tPpal As New Timers.Timer   'Este es el timer principal
    Public tPEnvioMailsPendientes As New Timers.Timer   'Este el timer asociado al proceso "EnvioMailsPendientes"
    Public tPMailingInicioDia As New Timers.Timer   'Este el timer asociado al proceso "MailingInicioDia"
    Public tPMailingFinDia As New Timers.Timer   'Este el timer asociado al proceso "MailingFinDia"


#Region "Eventos del Servicio"

    Public Sub New()

        MyBase.New()
        InitializeComponent()
        If Not System.Diagnostics.EventLog.SourceExists("Venezia_Scheduler") Then
            System.Diagnostics.EventLog.CreateEventSource("Venezia_Scheduler", "Venezia_Scheduler_Log")
        End If
        EventLogPpal.Source = "Venezia_Scheduler"


    End Sub

    Protected Overrides Sub OnStart(ByVal args() As String)
        Try

            'Creo la conexion a la base de datos del servicio.
            gAdmin = New VzAdmin.cAdmin(My.Settings.DBCnn_Srv, My.Settings.DBCnn_DBName, My.Settings.DBCnn_DBPort)

            'pruebo la conexion y si no funciona, bajo el servicio.
            If Not gAdmin.DbCnn.TestConnection Then
                EventLogPpal.WriteEntry("Error al iniciar la conexion con la base de datos. El servicio se detendra. -" & Now.ToString)
                Me.Stop()
            End If

            EventLogPpal.WriteEntry("El servicio fue iniciado. -" & Now.ToString)

            LoadScheduler()
            IniciarTimers()

        Catch ex As Exception
            EventLogPpal.WriteEntry("Error en Venezia__Scheduler.OnStart : " & ex.Message)
            Me.Stop()
        End Try

    End Sub

    Protected Overrides Sub OnStop()
        'Detengo los timers. 
        tPpal.Stop()
        EventLogPpal.WriteEntry("El servicio fue detenido. - " & Now.ToString)

    End Sub

    Protected Overrides Sub OnContinue()
        OnStart(Nothing)
    End Sub

    Protected Overrides Sub OnPause()
        OnStop()
    End Sub

#End Region

#Region "Configuracion de Schedules"

    Private Sub LoadScheduler()
        Dim lSchedule As cSchedule = Nothing
        Dim lConfiguracion As String = ""
        Try

            gArraySchedules = cSchedule.GetAllSchedules(gAdmin)

            '=============CONFIGURACION DE TIMERS ==============

            '------Configuracion Principal--------------------------------------------
            AddHandler tPpal.Elapsed, AddressOf tPpal_Elapsed
            tPpal.Interval = 2 * 1000 '5 segundos
            lConfiguracion = "Proceso tPpal Rate= " & tPpal.Interval.ToString & " segundos." & vbCrLf

            lSchedule = cSchedule.GetSchedulexProceso(gAdmin, "EnvioMailsPendientes")
            AddHandler tPpal.Elapsed, AddressOf tPEnvioMailsPendientes_Elapsed
            tPEnvioMailsPendientes.Interval = lSchedule.Rate
            lConfiguracion = lConfiguracion & "Proceso tPEnvioMailsPendientes Rate= " & tPEnvioMailsPendientes.Interval.ToString & " segundos." & vbCrLf

            lSchedule = cSchedule.GetSchedulexProceso(gAdmin, "MailingInicioDia")
            AddHandler tPpal.Elapsed, AddressOf tPMailingInicioDia_Elapsed
            tPMailingInicioDia.Interval = lSchedule.Rate
            lConfiguracion = lConfiguracion & "Proceso tPMailingInicioDia Rate= " & tPMailingInicioDia.Interval.ToString & " segundos." & vbCrLf

            lSchedule = cSchedule.GetSchedulexProceso(gAdmin, "MailingFinDia")
            AddHandler tPpal.Elapsed, AddressOf tPMailingFinDia_Elapsed
            tPMailingFinDia.Interval = lSchedule.Rate
            lConfiguracion = lConfiguracion & "Proceso tPMailingFinDia Rate= " & tPMailingFinDia.Interval.ToString & " segundos." & vbCrLf

            EventLogPpal.WriteEntry("La configuracion se cargo de la siguiente manera: " & vbCrLf & lConfiguracion)

        Catch ex As Exception
            EventLogPpal.WriteEntry("Error en Venezia__Scheduler.LoadScheduler : " & ex.Message)
        End Try
    End Sub

    Private Sub IniciarTimers()

        Try

            tPpal.Start()

        Catch ex As Exception
            EventLogPpal.WriteEntry("Error en Venezia__Scheduler.IniciarTimers : " & ex.Message)
        End Try

    End Sub

#End Region

#Region "Ejecución de Procesos"

    Private Sub tPpal_Elapsed()
        Try


        Catch ex As Exception
            EventLogPpal.WriteEntry("Error en Venezia__Scheduler.tPpal_Elapsed : " & ex.Message)
        End Try
    End Sub

    Private Sub tPEnvioMailsPendientes_Elapsed()
        Try


        Catch ex As Exception
            EventLogPpal.WriteEntry("Error en Venezia__Scheduler.tPEnvioMailsPendientes_Elapsed : " & ex.Message)
        End Try
    End Sub


    Private Sub tPMailingInicioDia_Elapsed()
        Try


        Catch ex As Exception
            EventLogPpal.WriteEntry("Error en Venezia__Scheduler.tPMailingInicioDia_Elapsed : " & ex.Message)
        End Try
    End Sub



    Private Sub tPMailingFinDia_Elapsed()
        Try


        Catch ex As Exception
            EventLogPpal.WriteEntry("Error en Venezia__Scheduler.tPMailingFinDia_Elapsed : " & ex.Message)
        End Try
    End Sub





#End Region

End Class
