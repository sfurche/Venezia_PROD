Imports MySql.Data.MySqlClient
Imports VzAdmin

Public Class cComment

    Private _Id_Comment As Integer
    Private _Text As String
    Private _Fecha As TimeSpan
    Private _Tabla As String
    Private _Evento As String
    Private _Id_Objeto As Integer
    Private _User As cUser

    Private gAdmin As cAdmin

#Region "PROPIEDADES"

    Public Property Id_Comment As Integer
        Get
            Return _Id_Comment
        End Get
        Set(value As Integer)
            _Id_Comment = value
        End Set
    End Property

    Public Property Text As String
        Get
            Return _Text
        End Get
        Set(value As String)
            _Text = value
        End Set
    End Property

    Public Property Fecha As TimeSpan
        Get
            Return _Fecha
        End Get
        Set(value As TimeSpan)
            _Fecha = value
        End Set
    End Property

    Public Property Tabla As String
        Get
            Return _Tabla
        End Get
        Set(value As String)
            _Tabla = value
        End Set
    End Property

    Public Property Evento As String
        Get
            Return _Evento
        End Get
        Set(value As String)
            _Evento = value
        End Set
    End Property

    Public Property Id_Objeto As Integer
        Get
            Return _Id_Objeto
        End Get
        Set(value As Integer)
            _Id_Objeto = value
        End Set
    End Property

    Public Property User As cUser
        Get
            Return _User
        End Get
        Set(value As cUser)
            _User = value
        End Set
    End Property

#End Region

    Public Sub New()

    End Sub

    Public Sub New(ByRef pAdmin As cAdmin)
        gAdmin = pAdmin
    End Sub

    Public Sub Guardar()
        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lCnn As MySqlConnection

        Try
            lCnn = gAdmin.DbCnn.GetInstanceCon
            Sql = "CALL vz_comments_ins('#texto#','#tabla#', '#evento#', #id_objeto#, #idusr#)"
            Sql = Sql.Replace("#texto#", Me.Text)
            Sql = Sql.Replace("#tabla#", Me.Tabla)
            Sql = Sql.Replace("#evento#", Me.Evento)
            Sql = Sql.Replace("#id_objeto#", Me.Id_Objeto)
            Sql = Sql.Replace("#idusr#", gAdmin.User.Id)

            With Cmd
                .Connection = lCnn
                .CommandType = CommandType.Text
                .CommandText = Sql

                If lCnn.State = ConnectionState.Closed Then
                    lCnn.Open()
                End If
                Cmd.ExecuteNonQuery()
                lCnn.Close()
            End With


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cComment.Guardar")
            gAdmin.Log.fncGrabarLogERR("Error en cComment.Guardar" & ex.Message)
        End Try
    End Sub

    Public Sub Dispose()
        Me.Dispose()
    End Sub

    Public Sub Load(ByVal pDr As DataRow)
        Try
            Me.Id_Comment = pDr("id_comment")
            Me.Text = pDr("text")
            Me.Tabla = pDr("tabla")
            Me.Evento = pDr("evento")
            Me.Fecha = pDr("fecha")
            Me.Id_Objeto = pDr("id_objeto")
            Me.User = cUser.GetUsuarioxId(gAdmin, pDr("idusr"))

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cComment.Load")
            gAdmin.Log.fncGrabarLogERR("Error en cComment.Load" & ex.Message)
        End Try
    End Sub

#Region "Shared Functions"

    Public Shared Function GetComentariosxTablaIdObj(ByRef pAdmin As cAdmin, ByVal pTabla As String, ByVal pIdObj As String) As ArrayList
        Dim lDt As DataTable
        Dim lDr As DataRow
        Dim lComment As cComment = Nothing
        GetComentariosxTablaIdObj = Nothing

        Try
            lDt = Dat_GetComentariosxTablaIdObj(pAdmin, pTabla, pIdObj)

            If lDt.Rows.Count > 0 Then
                GetComentariosxTablaIdObj = New ArrayList

                For Each lDr In lDt.Rows
                    lComment = New cComment(pAdmin)
                    lComment.Load(lDr)
                    GetComentariosxTablaIdObj.Add(lComment)
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cComment.GetComentariosxTablaIdObj")
            pAdmin.Log.fncGrabarLogERR("Error en cComment.GetComentariosxTablaIdObj" & ex.Message)
        End Try

    End Function

#End Region


#Region "Base de Datos"

    Private Shared Function Dat_GetComentariosxTablaIdObj(ByRef pAdmin As VzAdmin.cAdmin, ByVal pTabla As String, ByVal pIdObj As String) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "select * from vz_comments where tabla ='#tabla#' and id_objeto=#id_objeto#"
            Sql = Sql.Replace("#tabla#", pTabla)
            Sql = Sql.Replace("#id_objeto#", pIdObj)

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

            Return lDt

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cComment.Dat_GetComentariosxTablaIdObj")
            pAdmin.Log.fncGrabarLogERR("Error en cComment.Dat_GetComentariosxTablaIdObj:" & ex.Message)
            Return Nothing
        End Try
    End Function

#End Region



End Class
