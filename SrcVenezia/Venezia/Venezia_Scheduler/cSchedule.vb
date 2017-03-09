﻿Imports MySql.Data.MySqlClient
Imports VzAdmin

Public Class cSchedule


#Region "Propiedades"

    Private _Id_Schedule As Integer
    Private _Proceso As String
    Private _Inicio As DateTime
    Private _Fin As DateTime
    Private _Rate As String
    Private _NoHabiles As Boolean
    Private _UltEjecucion As Boolean
    Private _Descripcion As String

    Private gAdmin As VzAdmin.cAdmin

    Public Property Id_Schedule As Integer
        Get
            Return _Id_Schedule
        End Get
        Set(value As Integer)
            _Id_Schedule = value
        End Set
    End Property

    Public Property Proceso As String
        Get
            Return _Proceso
        End Get
        Set(value As String)
            _Proceso = value
        End Set
    End Property

    Public Property Inicio As Date
        Get
            Return _Inicio
        End Get
        Set(value As Date)
            _Inicio = value
        End Set
    End Property

    Public Property Fin As Date
        Get
            Return _Fin
        End Get
        Set(value As Date)
            _Fin = value
        End Set
    End Property

    Public Property Rate As String
        Get
            Return _Rate
        End Get
        Set(value As String)
            _Rate = value
        End Set
    End Property

    Public Property NoHabiles As Boolean
        Get
            Return _NoHabiles
        End Get
        Set(value As Boolean)
            _NoHabiles = value
        End Set
    End Property

    Public Property UltEjecucion As Boolean
        Get
            Return _UltEjecucion
        End Get
        Set(value As Boolean)
            _UltEjecucion = value
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return _Descripcion
        End Get
        Set(value As String)
            _Descripcion = value
        End Set
    End Property
#End Region

#Region "Funciones"

    Public Sub New()

    End Sub

    Public Sub New(pAdmin As cAdmin)
        Me.gAdmin = pAdmin
    End Sub

    Public Shared Function Load_Schedule(ByRef pAdmin As cAdmin, ByVal lDr As DataRow) As cSchedule

        Dim lSchedule As cSchedule = Nothing

        Try
            lSchedule = New cSchedule(pAdmin)
            With lSchedule
                .Id_Schedule = lDr("id_schedule")
                .Proceso = lDr("proceso")
                .Inicio = lDr("inicio")
                .Fin = lDr("fin")
                .Rate = lDr("rate")
                .NoHabiles = Boolean.Parse(lDr("nohabil"))
                .UltEjecucion = lDr("ultejec")
                .Descripcion = lDr("descripcion")
            End With

        Catch ex As Exception
            pAdmin.Log.fncGrabarLogERR("Error en cSchedule.Load_Schedule:" & ex.Message)
        End Try

        Return lSchedule

    End Function

    Public Shared Function GetSchedulexProceso(ByRef pAdmin As VzAdmin.cAdmin, ByVal pProceso As String) As cSchedule
        Dim lDr As DataRow
        Dim lSchedule As cSchedule = Nothing
        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "Select * from vz_scheduler where cod_setting='#pProceso#'"
            Sql = Sql.Replace("#pProceso#", pProceso)

            With Cmd
                .Connection = lCnn
                .CommandType = CommandType.Text
                .CommandText = Sql

                If lCnn.State = ConnectionState.Closed Then
                    lCnn.Open()
                End If
                Dim lAdap As New MySqlDataAdapter(Cmd)
                lDt = New DataTable
                lAdap.Fill(lDt)
                lCnn.Close()
            End With

            If lDt.Rows.Count > 0 Then

                For Each lDr In lDt.Rows
                    lSchedule = Load_Schedule(pAdmin, lDr)
                Next
            End If

        Catch ex As Exception
            pAdmin.Log.fncGrabarLogERR("Error en cSchedule.GetSchedulexProceso:" & ex.Message)
        End Try

        Return lSchedule

    End Function

    Public Shared Function GetAllSchedules(ByRef pAdmin As VzAdmin.cAdmin) As ArrayList
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lSchedule As cSchedule = Nothing
        Dim lArray As ArrayList = Nothing
        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "Select * from vz_scheduler"

            With Cmd
                .Connection = lCnn
                .CommandType = CommandType.Text
                .CommandText = Sql

                If lCnn.State = ConnectionState.Closed Then
                    lCnn.Open()
                End If
                Dim lAdap As New MySqlDataAdapter(Cmd)
                lDt = New DataTable
                lAdap.Fill(lDt)
                lCnn.Close()
            End With

            If lDt.Rows.Count > 0 Then
                lArray = New ArrayList
                For Each lDr In lDt.Rows
                    lSchedule = Load_Schedule(pAdmin, lDr)
                    lArray.Add(lSchedule)
                Next
            End If

        Catch ex As Exception
            pAdmin.Log.fncGrabarLogERR("Error en cSchedule.GetAllSchedules:" & ex.Message)
        End Try

        Return lArray
    End Function


    Private Function ActualizarUltEjecucion(ByRef pAdmin As VzAdmin.cAdmin) As Boolean

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lCnn As MySqlConnection

        ActualizarUltEjecucion = False
        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "UPDATE vz_scheduler SET ultejec = NOW() WHERE id_schedule =#pId_Schedule#"
            Sql = Sql.Replace("#pId_Schedule#", Me.Id_Schedule)


            With Cmd
                .Connection = lCnn
                .CommandType = CommandType.Text
                .CommandText = Sql

                If lCnn.State = ConnectionState.Closed Then
                    lCnn.Open()
                End If
                ActualizarUltEjecucion = Cmd.ExecuteNonQuery()
                lCnn.Close()
            End With

        Catch ex As Exception
            pAdmin.Log.fncGrabarLogERR("Error en cSchedule.ActualizarUltEjecucion:" & ex.Message)
            Return Nothing
        End Try

    End Function

#End Region

End Class

