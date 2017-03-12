Imports System.Timers
Imports System.Diagnostics
Imports VzAdmin
Imports VzProcesos

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
        If Not System.Diagnostics.EventLog.SourceExists("Venezia_Schedule") Then
            System.Diagnostics.EventLog.CreateEventSource("Venezia_Schedule", "Venezia_Log")
        End If
        EventLogPpal.Source = "Venezia_Schedule"

    End Sub

    Protected Overrides Sub OnStart(ByVal args() As String)
        Try
            '====================================================
            '=============SOLO PARA DEBUGGEAR EL SERVICIO======== 
            'Para debuggear se deja abierta la solucion en el visual studio pero sin ejecutar.
            'Luego se compila y se instala el servicio. 
            'Iniciar el servicio y desde el visual studio asociar el proceso. (Menu Debug-> Attach to Process -> Seleccionar el servicio)
            'Detener el servicio, y activar la linea  System.Diagnostics.Debugger.Launch() en el evento en OnStart
            'Compilar y al iniciar el servicio desde servies.mcs abre el mensaje de debug y ahi seleccionamos la instancia de visual studio que tenemos abierta y listo.

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

            'Cargo el usuario del sistema para poder loguear actividad.
            gAdmin.User.Load(cUser.Dat_GetUsuarioxID(gAdmin, "21").Rows(0))
            gAdmin.User.Validar("Venezia_Schedule", "furche.1")

            EventLogPpal.WriteEntry("El servicio fue iniciado. -" & Now.ToString)

            LoadScheduler()

        Catch ex As Exception
            EventLogPpal.WriteEntry("Error en Venezia_Scheduler.OnStart : " & ex.Message)
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
            tPpal.Interval = My.Settings.RatetPpal * 1000
            lConfiguracion = "Proceso tPpal:" & vbCrLf
            lConfiguracion = lConfiguracion & "Rate= " & tPpal.Interval.ToString & " segundos." & vbCrLf & vbCrLf

            '------EnvioMailsPendientes ------------------------------------------------------
            lSch_EnvioMailsPendientes = cSchedule.GetSchedulexProceso(gAdmin, "EnvioMailsPendientes")
            AddHandler tPEnvioMailsPendientes.Elapsed, AddressOf tPEnvioMailsPendientes_Elapsed
            tPEnvioMailsPendientes.Interval = lSch_EnvioMailsPendientes.Rate * 1000
            lConfiguracion = lConfiguracion & "Proceso tPEnvioMailsPendientes:" & vbCrLf
            lConfiguracion = lConfiguracion & "Rate= " & (tPEnvioMailsPendientes.Interval / 1000).ToString & " segundos." & vbCrLf
            lConfiguracion = lConfiguracion & "Inicio= " & lSch_EnvioMailsPendientes.Inicio.ToString & " hs." & vbCrLf
            lConfiguracion = lConfiguracion & "Fin= " & lSch_EnvioMailsPendientes.Fin.ToString & " hs." & vbCrLf
            lConfiguracion = lConfiguracion & "No Habiles= " & lSch_EnvioMailsPendientes.NoHabiles.ToString & vbCrLf & vbCrLf

            '------MailingInicioDia ------------------------------------------------------
            lSch_MailingInicioDia = cSchedule.GetSchedulexProceso(gAdmin, "MailingInicioDia")
            AddHandler tPMailingInicioDia.Elapsed, AddressOf tPMailingInicioDia_Elapsed
            tPMailingInicioDia.Interval = lSch_MailingInicioDia.Rate * 1000
            lConfiguracion = lConfiguracion & "Proceso tPMailingInicioDia:" & vbCrLf
            lConfiguracion = lConfiguracion & "Rate= " & (tPMailingInicioDia.Interval / 1000).ToString & " segundos." & vbCrLf
            lConfiguracion = lConfiguracion & "Inicio= " & lSch_MailingInicioDia.Inicio.ToString & " hs." & vbCrLf
            lConfiguracion = lConfiguracion & "Fin= " & lSch_MailingInicioDia.Fin.ToString & " hs." & vbCrLf
            lConfiguracion = lConfiguracion & "No Habiles= " & lSch_MailingInicioDia.NoHabiles.ToString & vbCrLf & vbCrLf

            '------MailingFinDia ------------------------------------------------------
            lSch_MailingFinDia = cSchedule.GetSchedulexProceso(gAdmin, "MailingFinDia")
            AddHandler tPMailingFinDia.Elapsed, AddressOf tPMailingFinDia_Elapsed
            tPMailingFinDia.Interval = lSch_MailingFinDia.Rate * 1000
            lConfiguracion = lConfiguracion & "Proceso tPMailingInicioDia:" & vbCrLf
            lConfiguracion = lConfiguracion & "Rate= " & (tPMailingFinDia.Interval / 1000).ToString & " segundos." & vbCrLf
            lConfiguracion = lConfiguracion & "Inicio= " & lSch_MailingFinDia.Inicio.ToString & " hs." & vbCrLf
            lConfiguracion = lConfiguracion & "Fin= " & lSch_MailingFinDia.Fin.ToString & " hs." & vbCrLf
            lConfiguracion = lConfiguracion & "No Habiles= " & lSch_MailingFinDia.NoHabiles.ToString & vbCrLf & vbCrLf

            EventLogPpal.WriteEntry("La configuración se cargo de la siguiente manera: " & vbCrLf & lConfiguracion)

            '---------------Enciendo el timer principal del servicio.
            tPpal.Start()
            tPpal_Elapsed()

        Catch ex As Exception
            EventLogPpal.WriteEntry("Error en Venezia_Scheduler.LoadScheduler : " & ex.Message)
        End Try
    End Sub

    Private Sub Validar_tPEnvioMailsPendientes()
        Try
            If lSch_EnvioMailsPendientes.NoHabiles = False Then
                If cFeriado.EsFeriado(gAdmin, Date.Today) = True Then
                    If tPEnvioMailsPendientes.Enabled = True Then
                        tPEnvioMailsPendientes.Stop()
                        EventLogPpal.WriteEntry(Now.ToString & " - El timer tPEnvioMailsPendientes fue detenido. ")
                    End If
                    Exit Sub
                    End If
                End If

            If tPEnvioMailsPendientes.Enabled = False Then
                tPEnvioMailsPendientes.Start()
                EventLogPpal.WriteEntry(Now.ToString & " - El timer tPEnvioMailsPendientes fue iniciado. ")
            End If

        Catch ex As Exception
            EventLogPpal.WriteEntry("Error en Venezia_Scheduler.Validar_tPEnvioMailsPendientes : " & ex.Message)
        End Try

    End Sub

    Private Sub Validar_tPMailingInicioDia()
        Try
            If lSch_MailingInicioDia.NoHabiles = False Then
                If cFeriado.EsFeriado(gAdmin, Date.Today) = True Then
                    If tPMailingInicioDia.Enabled = True Then
                        tPMailingInicioDia.Stop()
                        EventLogPpal.WriteEntry(Now.ToString & " - El timer tPMailingInicioDia fue detenido. ")
                    End If
                    Exit Sub
                End If
            End If
            If tPMailingInicioDia.Enabled = False Then
                tPMailingInicioDia.Start()
                EventLogPpal.WriteEntry(Now.ToString & " - El timer tPMailingInicioDia fue iniciado. ")
            End If

        Catch ex As Exception
            EventLogPpal.WriteEntry("Error en Venezia_Scheduler.Validar_tPMailingInicioDia : " & ex.Message)
        End Try

    End Sub

    Private Sub Validar_tPMailingFinDia()
        Try
            If lSch_MailingFinDia.NoHabiles = False Then
                If cFeriado.EsFeriado(gAdmin, Date.Today) = True Then
                    If tPMailingFinDia.Enabled = True Then
                        tPMailingFinDia.Stop()
                        EventLogPpal.WriteEntry(Now.ToString & " - El timer tPMailingFinDia fue detenido. ")
                    End If
                    Exit Sub
                End If
            End If

            If tPMailingFinDia.Enabled = False Then
                tPMailingFinDia.Start()
                EventLogPpal.WriteEntry(Now.ToString & " - El timer tPMailingFinDia fue iniciado. ")
            End If

        Catch ex As Exception
            EventLogPpal.WriteEntry("Error en Venezia_Scheduler.Validar_tPMailingFinDia : " & ex.Message)
        End Try

    End Sub

    Private Sub DetenerTimers()
        Try
            tPEnvioMailsPendientes.Stop()
            tPMailingInicioDia.Stop()  'Este el timer asociado al proceso "MailingInicioDia"
            tPMailingFinDia.Stop()    'Este el timer asociado al proceso "MailingFinDia"

        Catch ex As Exception
            EventLogPpal.WriteEntry("Error en Venezia_Scheduler.DetenerTimers : " & ex.Message)
        End Try

    End Sub

#End Region

#Region "Ejecución de Procesos"

    Private Sub tPpal_Elapsed()
        Try
            Validar_tPEnvioMailsPendientes()
            Validar_tPMailingInicioDia()
            Validar_tPMailingFinDia()

        Catch ex As Exception
            EventLogPpal.WriteEntry("Error en Venezia_Scheduler.tPpal_Elapsed : " & ex.Message)
        End Try
    End Sub

    Private Sub tPEnvioMailsPendientes_Elapsed()
        Try
            EventLogPpal.WriteEntry(Now.ToString & " - Se ejecuta tPEnvioMailsPendientes_Elapsed. ")

            'valido si el proceso esta corriendo
            If lSch_EnvioMailsPendientes.IsRunning = True Then
                Exit Sub
            ElseIf (lSch_EnvioMailsPendientes.Inicio < Date.Now.TimeOfDay And Date.Now.TimeOfDay < lSch_EnvioMailsPendientes.Fin) Then
                lSch_EnvioMailsPendientes.IsRunning = True
                VzProcesos.cMailingAutomatico.EnviarMailsPendientes(gAdmin)
                'Cuando termina el proceso retorno a habilitar el procso
                lSch_EnvioMailsPendientes.IsRunning = False
            End If
        Catch ex As Exception
            EventLogPpal.WriteEntry("Error en Venezia_Scheduler.tPEnvioMailsPendientes_Elapsed : " & ex.Message)
            lSch_EnvioMailsPendientes.IsRunning = False
        End Try

    End Sub

    Private Sub tPMailingInicioDia_Elapsed()
        Try
            EventLogPpal.WriteEntry(Now.ToString & " - Se ejecuta tPMailingInicioDia_Elapsed. ")
            'valido si el proceso esta corriendo
            If lSch_EnvioMailsPendientes.IsRunning = True Then
                Exit Sub
            ElseIf (lSch_MailingInicioDia.Inicio < Date.Now.TimeOfDay And Date.Now.TimeOfDay < lSch_MailingInicioDia.Fin) Then
                lSch_MailingInicioDia.IsRunning = True
                VzProcesos.cMailingTesoInicioDia.Ejecutar(gAdmin)
                'Cuando termina el proceso retorno a habilitar el procso
                lSch_MailingInicioDia.IsRunning = False
            End If

        Catch ex As Exception
            EventLogPpal.WriteEntry("Error en Venezia_Scheduler.tPMailingInicioDia_Elapsed : " & ex.Message)
            lSch_MailingInicioDia.IsRunning = False
        End Try
    End Sub

    Private Sub tPMailingFinDia_Elapsed()
        Try
            EventLogPpal.WriteEntry(Now.ToString & " - Se ejecuta tPMailingFinDia_Elapsed. ")
            'valido si el proceso esta corriendo
            If lSch_MailingFinDia.IsRunning = True Then
                Exit Sub
            ElseIf (lSch_MailingFinDia.Inicio < Date.Now.TimeOfDay And Date.Now.TimeOfDay < lSch_MailingFinDia.Fin) Then
                lSch_MailingFinDia.IsRunning = True
                VzProcesos.cMailingTesoFinDia.Ejecutar(gAdmin, Date.Today)
                'Cuando termina el proceso retorno a habilitar el procso
                lSch_MailingFinDia.IsRunning = False
            End If

        Catch ex As Exception
            EventLogPpal.WriteEntry("Error en Venezia_Scheduler.tPMailingFinDia_Elapsed : " & ex.Message)
            lSch_MailingFinDia.IsRunning = False
        End Try
    End Sub

#End Region

End Class
