Imports MySql.Data.MySqlClient
Imports VzAdmin

Public Class cFacturaProforma

    Public Shared Function Dat_GetTotalFacturasCIVAxFecha(ByRef pAdmin As VzAdmin.cAdmin, ByVal pFechaD As Date, ByVal pFechaH As Date) As Double

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "select ifnull(round(Sum(Abs(Tot_Fact)),2), 0) Total from ven_factprof where  FecEmi >= '#pFechaD#' and  FecEmi <= '#pFechaH#' and MarcaAnulado ='N';"
            Sql = Sql.Replace("#pFechaD#", cFunciones.gFncConvertDateToString(pFechaD, "YYYY/MM/DD"))
            Sql = Sql.Replace("#pFechaH#", cFunciones.gFncConvertDateToString(pFechaH, "YYYY/MM/DD"))

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

            Return Double.Parse(lDt.Rows(0)(0))

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cFacturaProforma.Dat_GetTotalFacturasxFecha")
            pAdmin.Log.fncGrabarLogERR("Error en cFacturaProforma.Dat_GetTotalFacturasxFecha:" & ex.Message)
            Return Nothing
        End Try
    End Function


    Public Shared Function Dat_GetCantFacturasxFecha(ByRef pAdmin As VzAdmin.cAdmin, ByVal pFechaD As Date, ByVal pFechaH As Date) As Integer

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "select count(*) from ven_factprof where FecEmi >= '#pFechaD#' and  FecEmi <= '#pFechaH#' and MarcaAnulado ='N' ;"
            Sql = Sql.Replace("#pFechaD#", cFunciones.gFncConvertDateToString(pFechaD, "YYYY/MM/DD"))
            Sql = Sql.Replace("#pFechaH#", cFunciones.gFncConvertDateToString(pFechaH, "YYYY/MM/DD"))

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

            Return Double.Parse(lDt.Rows(0)(0))

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cFacturaProforma.Dat_GetTotalFacturasxFecha")
            pAdmin.Log.fncGrabarLogERR("Error en cFacturaProforma.Dat_GetTotalFacturasxFecha:" & ex.Message)
            Return Nothing
        End Try
    End Function

End Class
