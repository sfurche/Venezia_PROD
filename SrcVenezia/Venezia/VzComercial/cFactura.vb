Imports MySql.Data.MySqlClient
Imports VzAdmin

Public Class cFactura


#Region "Base de Datos"

    Public Shared Function Dat_GetTotalFactAgrupVendxFecha(ByRef pAdmin As VzAdmin.cAdmin, ByVal pFecha As Date) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "select v.NombreVen, count(*) Cant, round(Sum(f.Tot_Fact_sIVA),2) TotalsIVA,  round(Sum(f.Tot_Fact),2) TotalcIVA,  round(Sum(Tot_Comi),2) Comision "
            Sql = Sql & " from ven_facturas as f, ven_vendedor as v"
            Sql = Sql & " where FecOp = '20170303'"
            Sql = Sql & " and f.Id_Vendedor = v.Id_Vendedor "
            Sql = Sql & " and MarcaAnulado ='N'"
            Sql = Sql & " and CodForm in('0151', '0101')"
            Sql = Sql & " group by v.NombreVen "
            Sql = Sql & " order by TotalsIVA desc; "

            Sql = Sql.Replace("#Fecha#", cFunciones.gFncConvertDateToString(pFecha, "YYYY/MM/DD"))

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cFactura.Dat_GetTotalFactAgrupVendxFecha")
            pAdmin.Log.fncGrabarLogERR("Error en cFactura.Dat_GetTotalFactAgrupVendxFecha" & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Function Dat_GetTotalFacturasCIVAxFecha(ByRef pAdmin As VzAdmin.cAdmin, ByVal pFecha As Date) As Double

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "select ifnull(round(Sum(Abs(Tot_Fact)),2), 0) Total from ven_facturas where FecOp = '#Fecha#'  and MarcaAnulado ='N'  and CodForm in('0151', '0101');"
            Sql = Sql.Replace("#Fecha#", cFunciones.gFncConvertDateToString(pFecha, "YYYY/MM/DD"))

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cFactura.Dat_GetTotalFacturasxFecha")
            pAdmin.Log.fncGrabarLogERR("Error en cFactura.Dat_GetTotalFacturasxFecha:" & ex.Message)
            Return Nothing
        End Try
    End Function


    Public Shared Function Dat_GetCantFacturasxFecha(ByRef pAdmin As VzAdmin.cAdmin, ByVal pFecha As Date) As Integer

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "select count(*) from ven_facturas where FecOp = '#Fecha#'  and MarcaAnulado ='N'  and CodForm in('0151', '0101');"
            Sql = Sql.Replace("#Fecha#", cFunciones.gFncConvertDateToString(pFecha, "YYYY/MM/DD"))

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cFactura.Dat_GetTotalFacturasxFecha")
            pAdmin.Log.fncGrabarLogERR("Error en cFactura.Dat_GetTotalFacturasxFecha:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Function Dat_GetTotalNotasDebitoxFecha(ByRef pAdmin As VzAdmin.cAdmin, ByVal pFecha As Date) As Double

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "select  ifnull(round(Sum(Abs(Tot_Fact)),2), 0) TotalcIVA from ven_facturas where FecOp = '#Fecha#'  and MarcaAnulado ='N'  and CodForm in('0102', '0152');"
            Sql = Sql.Replace("#Fecha#", cFunciones.gFncConvertDateToString(pFecha, "YYYY/MM/DD"))

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cFactura.Dat_GetTotalFacturasxFecha")
            pAdmin.Log.fncGrabarLogERR("Error en cFactura.Dat_GetTotalFacturasxFecha:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Function Dat_GetTotalNotasCreditoxFecha(ByRef pAdmin As VzAdmin.cAdmin, ByVal pFecha As Date) As Double

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "select ifnull(round(Sum(Abs(Tot_Fact)),2), 0) Total from ven_facturas where FecOp = '#Fecha#'  and MarcaAnulado ='N'  and CodForm in('0153', '0103');"
            Sql = Sql.Replace("#Fecha#", cFunciones.gFncConvertDateToString(pFecha, "YYYY/MM/DD"))

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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cFactura.Dat_GetTotalFacturasxFecha")
            pAdmin.Log.fncGrabarLogERR("Error en cFactura.Dat_GetTotalFacturasxFecha:" & ex.Message)
            Return Nothing
        End Try
    End Function



#End Region


End Class
