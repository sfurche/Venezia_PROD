Imports System.Timers
Imports System.Diagnostics
Imports VzAdmin

Public Class Venezia_Scheduler

    Public gArraySchedules As ArrayList = Nothing
    Public gAdmin As cAdmin = Nothing

    Public tPpal As New Timers.Timer   'Este es el timer principal
    Public tPEnvioMailsPendientes As New Timers.Timer   'Este el timer asociado al proceso "EnvioMailsPendientes"
    Public tPMailingInicioDia As New Timers.Timer   'Este el timer asociado al proceso "MailingInicioDia"
    Public tPMailingFinDia As New Timers.Timer   'Este el timer asociado al proceso "MailingFinDia"

    'Es la configuracion de cada proceso. 
    Public lSch_EnvioMailsPendientes As cSchedule = Nothing
    Public lSch_MailingInicioDia As cSchedule = Nothing
    Public lSch_MailingFinDia As cSchedule = Nothing


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
            '====================================================
            '=============SOLO PARA DEBUGGEAR EL SERVICIO======== 
            'Para debuggear se deja abierta la solucion en el visual studio pero sin ejecutar.
            'Se activa la linea  System.Diagnostics.Debugger.Launch() 
            'Luego se compila y se instala el servicio. 
            'Al iniciar el servicio abre el mensaje de debug y ahi seleccionamos la instancia de visual studio que tenemos abierta y listo.

            'System.Diagnostics.Debugger.Launch()

            '====================================================
            '====================================================

            'Creo la conexion a la base de datos del servicio.
            gAdmin = New VzAdmin.cAdmin(My.Settings.DBCnn_Srv, My.Settings.DBCnn_DBName, My.Settings.DBCnn_DBPort)

            'pruebo la conexion y si no funciona, bajo el servicio.
            If Not gAdmin.DbCnn.TestConnection Then
                EventLogPpal.WriteEntry("Error al iniciar la conexion con la base de datos. El servicio se detendra. -" & Now.ToString)
                Me.Stop()
            End If

            EventLogPpal.WriteEntry("El servicio fue iniciado. -" & Now.ToString)

            LoadScheduler()

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
        Dim lConfiguracion As String = ""
        Try

            gArraySchedules = cSchedule.GetAllSchedules(gAdmin)

            '=============CONFIGURACION DE TIMERS ==============



            '------Configuracion Principal--------------------------------------------

            AddHandler tPpal.Elapsed, AddressOf tPpal_Elapsed
            tPpal.Interval = 5 * 1000 '5 segundos
            lConfiguracion = "Proceso tPpal Rate= " & tPpal.Interval.ToString & " segundos." & vbCrLf
            tPpal.Start()

            '------EnvioMailsPendientes ------------------------------------------------------
            lSch_EnvioMailsPendientes = cSchedule.GetSchedulexProceso(gAdmin, "EnvioMailsPendientes")

            EventLogPpal.WriteEntry("1" & IIf(IsNothing(lSch_EnvioMailsPendientes), "Nada", "lleno"))
            EventLogPpal.WriteEntry("1" & IIf(IsNothing(gAdmin), "cnn Nada", "cnn lleno"))

            AddHandler tPEnvioMailsPendientes.Elapsed, AddressOf tPEnvioMailsPendientes_Elapsed
            tPEnvioMailsPendientes.Interval = lSch_EnvioMailsPendientes.Rate
            lConfiguracion = lConfiguracion & "Proceso tPEnvioMailsPendientes Rate= " & tPEnvioMailsPendientes.Interval.ToString & " segundos." & vbCrLf



            '------MailingInicioDia ------------------------------------------------------
            lSch_MailingInicioDia = cSchedule.GetSchedulexProceso(gAdmin, "MailingInicioDia")
            AddHandler tPMailingInicioDia.Elapsed, AddressOf tPMailingInicioDia_Elapsed
            tPMailingInicioDia.Interval = lSch_MailingInicioDia.Rate
            lConfiguracion = lConfiguracion & "Proceso tPMailingInicioDia Rate= " & tPMailingInicioDia.Interval.ToString & " segundos." & vbCrLf


            'EventLogPpal.WriteEntry("PASO3")

            '------MailingFinDia ------------------------------------------------------
            lSch_MailingFinDia = cSchedule.GetSchedulexProceso(gAdmin, "MailingFinDia")
            AddHandler tPMailingFinDia.Elapsed, AddressOf tPMailingFinDia_Elapsed
            tPMailingFinDia.Interval = lSch_MailingFinDia.Rate
            lConfiguracion = lConfiguracion & "Proceso tPMailingFinDia Rate= " & tPMailingFinDia.Interval.ToString & " segundos." & vbCrLf

            'EventLogPpal.WriteEntry("PASO4")

            EventLogPpal.WriteEntry("La configuración se cargo de la siguiente manera: " & vbCrLf & lConfiguracion)

            'BORRARRR PRUEBA DE FERIADOS. 
            EventLogPpal.WriteEntry("Es Feriado 24/03 fer " & cFeriado.EsFeriado(gAdmin, "2017/03/24"))
            EventLogPpal.WriteEntry("Es Feriado 26/03dom " & cFeriado.EsFeriado(gAdmin, "2017/03/26"))
            EventLogPpal.WriteEntry("Es Feriado 28/03 mar " & cFeriado.EsFeriado(gAdmin, "2017/03/28"))
            EventLogPpal.WriteEntry("Es Feriado 29/03 mi " & cFeriado.EsFeriado(gAdmin, "2017/03/29"))
            EventLogPpal.WriteEntry("Es Feriado 30/03 ju " & cFeriado.EsFeriado(gAdmin, "2017/03/30"))
            EventLogPpal.WriteEntry("Es Feriado 31/03 vi " & cFeriado.EsFeriado(gAdmin, "2017/03/31"))


        Catch ex As Exception
            EventLogPpal.WriteEntry("Error en Venezia_Scheduler.LoadScheduler : " & ex.Message)
        End Try
    End Sub

    Private Sub Validar_tPEnvioMailsPendientes()
        Try
            If lSch_EnvioMailsPendientes.NoHabiles = False Then
                If cFeriado.EsFeriado(gAdmin, Date.Today) = True Then
                    tPEnvioMailsPendientes.Stop()
                Else
                    tPEnvioMailsPendientes.Start()
                End If
            End If

        Catch ex As Exception
            EventLogPpal.WriteEntry("Error en Venezia__Scheduler.Validar_tPEnvioMailsPendientes : " & ex.Message)
        End Try

    End Sub

    Private Sub Validar_tPMailingInicioDia()
        Try
            If lSch_MailingInicioDia.NoHabiles = False Then
                If cFeriado.EsFeriado(gAdmin, Date.Today) = True Then
                    tPMailingInicioDia.Stop()
                Else
                    tPMailingInicioDia.Start()
                End If
            End If

        Catch ex As Exception
            EventLogPpal.WriteEntry("Error en Venezia__Scheduler.Validar_tPMailingInicioDia : " & ex.Message)
        End Try

    End Sub

    Private Sub Validar_tPMailingFinDia()
        Try
            If lSch_MailingFinDia.NoHabiles = False Then
                If cFeriado.EsFeriado(gAdmin, Date.Today) = True Then
                    tPMailingFinDia.Stop()
                Else
                    tPMailingFinDia.Start()
                End If
            End If

        Catch ex As Exception
            EventLogPpal.WriteEntry("Error en Venezia__Scheduler.Validar_tPMailingFinDia : " & ex.Message)
        End Try

    End Sub

    Private Sub DeternerTimers()
        Try
            tPEnvioMailsPendientes.Stop()
            tPMailingInicioDia.Stop()  'Este el timer asociado al proceso "MailingInicioDia"
            tPMailingFinDia.Stop()    'Este el timer asociado al proceso "MailingFinDia"

        Catch ex As Exception
            EventLogPpal.WriteEntry("Error en Venezia_Scheduler.DeternerTimers : " & ex.Message)
        End Try

    End Sub

#End Region

#Region "Ejecución de Procesos"

    Private Sub tPpal_Elapsed()
        Try
            Validar_tPEnvioMailsPendientes()


        Catch ex As Exception
            EventLogPpal.WriteEntry("Error en Venezia_Scheduler.tPpal_Elapsed : " & ex.Message)
        End Try
    End Sub

    Private Sub tPEnvioMailsPendientes_Elapsed()
        Try
            'valido si el proceso esta corriendo
            If lSch_EnvioMailsPendientes.IsRunning = True Then
                Exit Sub
            Else
                lSch_EnvioMailsPendientes.IsRunning = True
            End If

            'Cuando termina el proceso retorno a habilitar el procso
            lSch_EnvioMailsPendientes.IsRunning = False
        Catch ex As Exception
            EventLogPpal.WriteEntry("Error en Venezia_Scheduler.tPEnvioMailsPendientes_Elapsed : " & ex.Message)
        End Try
    End Sub


    Private Sub tPMailingInicioDia_Elapsed()
        Try
            'valido si el proceso esta corriendo
            If lSch_MailingInicioDia.IsRunning = True Then
                Exit Sub
            Else
                lSch_MailingInicioDia.IsRunning = True
            End If

            'Cuando termina el proceso retorno a habilitar el procso
            lSch_MailingInicioDia.IsRunning = False

        Catch ex As Exception
            EventLogPpal.WriteEntry("Error en Venezia_Scheduler.tPMailingInicioDia_Elapsed : " & ex.Message)
        End Try
    End Sub

    Private Sub tPMailingFinDia_Elapsed()
        Try
            'valido si el proceso esta corriendo
            If lSch_MailingFinDia.IsRunning = True Then
                Exit Sub
            Else
                lSch_MailingFinDia.IsRunning = True
            End If

            'Cuando termina el proceso retorno a habilitar el procso
            lSch_MailingFinDia.IsRunning = False

        Catch ex As Exception
            EventLogPpal.WriteEntry("Error en Venezia_Scheduler.tPMailingFinDia_Elapsed : " & ex.Message)
        End Try
    End Sub

#End Region

End Class
