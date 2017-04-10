Imports MySql.Data.MySqlClient
Imports VzAdmin

Public Class cFactura


#Region "Base de Datos"

    Public Shared Function Dat_GetTotalFactAgrupVendxFechaDH(ByRef pAdmin As VzAdmin.cAdmin, ByVal pFechaD As Date, ByVal pFechaH As Date) As DataTable

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            'Sql = "select v.NombreVen, count(*) Cant, round(Sum(f.Tot_Fact_sIVA),2) TotalsIVA,  round(Sum(f.Tot_Fact),2) TotalcIVA,  round(Sum(Tot_Comi),2) Comision "
            'Sql = Sql & " from ven_facturas as f, ven_vendedor as v"
            'Sql = Sql & " where FecEmi >= '#pFechaD#'  and FecEmi <= '#pFechaH#'  "
            'Sql = Sql & " and f.Id_Vendedor = v.Id_Vendedor "
            'Sql = Sql & " and MarcaAnulado ='N'"
            'Sql = Sql & " and CodForm in('0151', '0101')"
            'Sql = Sql & " group by v.NombreVen "
            'Sql = Sql & " order by TotalsIVA desc; "

            'Sql = "select v.NombreVen, count(*) Cant, round(Sum(f.Tot_Fact_sIVA),2) TotalsIVA,  round(Sum(f.Tot_Fact),2) TotalcIVA,  round(Sum(Tot_Comi),2) Comision, "
            'Sql = Sql & " (select round(Sum(Tot_Fact),2) TotalcIVA from ven_facturas where FecEmi >= '#pFechaDMesAnt#'and FecEmi <'#pFechaD#' and Id_Vendedor = v.Id_Vendedor and MarcaAnulado ='N' and CodForm in('0151', '0101')) Mes_Anterior"
            'Sql = Sql & " from ven_facturas as f, ven_vendedor as v "
            'Sql = Sql & " where FecEmi >= '#pFechaD#' "
            'Sql = Sql & " and FecEmi  <= '#pFechaH#' "
            'Sql = Sql & " and f.Id_Vendedor = v.Id_Vendedor "
            'Sql = Sql & " and MarcaAnulado ='N' "
            'Sql = Sql & " and CodForm in('0151', '0101') "
            'Sql = Sql & " group by v.NombreVen "
            'Sql = Sql & " order by TotalsIVA desc; "

            'SMF: Ultima version 20170409 
            Sql = " SELECT NombreVen, COUNT(*) Cant, "
            Sql = Sql & " IFNULL(ROUND(SUM(Tot_Fact),2),0) TotalcIVA,  "
            Sql = Sql & " IFNULL((Select ROUND(SUM(Tot_Fact),2) TotalcIVA FROM ven_facturas where FecEmi >= '#pFechaDMesAnt#'AND FecEmi >'#pFechaHMesAnt#' AND Id_Vendedor = A.Id_Vendedor AND MarcaAnulado ='N' AND CodForm in('0151', '0101')),0) Al_Mes_Anterior,"
            Sql = Sql & " IFNULL(ROUND(SUM(Tot_Comi),2),0) Comision,"
            Sql = Sql & " IFNULL(ROUND(sum(Utilidad),2),0) Utilidad"
            Sql = Sql & " FROM ("
            Sql = Sql & " SELECT f.Id_Fac, v.Id_Vendedor, v.NombreVen, f.Tot_Fact,  f.Tot_Comi, f.CodForm, ROUND((d.PcioTotal - d.PcioCosto * d.CantProd),2) Utilidad"
            Sql = Sql & " FROM ven_facturas as f, ven_vendedor as v, ven_detfac d"
            Sql = Sql & " WHERE FecEmi >= '#pFechaD#'  AND FecEmi  <= '#pFechaH#'  AND f.Id_Vendedor = v.Id_Vendedor  AND f.MarcaAnulado ='N'  AND CodForm = '0101'  AND d.MarcaAnulado ='N'"
            Sql = Sql & " AND f.Id_Fac = d.Id_Fac"
            Sql = Sql & " GROUP BY f.Id_Fac, v.Id_Vendedor, v.NombreVen, f.Tot_Fact,  f.Tot_Comi, f.CodForm"
            Sql = Sql & " UNION"
            Sql = Sql & " SELECT f.Id_Fac,  v.Id_Vendedor, v.NombreVen, f.Tot_Fact,  f.Tot_Comi, f.CodForm, ROUND((d.PcioTotal/1.21 - d.PcioCosto * d.CantProd),2) Utilidad"
            Sql = Sql & " FROM ven_facturas as f, ven_vendedor as v, ven_detfac d"
            Sql = Sql & " WHERE FecEmi >= '#pFechaD#'  AND FecEmi  <= '#pFechaH#'  AND f.Id_Vendedor = v.Id_Vendedor  AND f.MarcaAnulado ='N'  AND CodForm  ='0151'  AND d.MarcaAnulado ='N'"
            Sql = Sql & " AND f.Id_Fac = d.Id_Fac"
            Sql = Sql & " GROUP BY f.Id_Fac, v.Id_Vendedor, v.NombreVen, f.Tot_Fact,  f.Tot_Comi, f.CodForm"
            Sql = Sql & " ) AS A "
            Sql = Sql & " GROUP BY NombreVen  ORDER BY TotalcIVA desc; "

            Sql = Sql.Replace("#pFechaD#", cFunciones.gFncConvertDateToString(pFechaD, "YYYY/MM/DD"))
            Sql = Sql.Replace("#pFechaH#", cFunciones.gFncConvertDateToString(pFechaH, "YYYY/MM/DD"))
            Sql = Sql.Replace("#pFechaDMesAnt#", cFunciones.gFncConvertDateToString(DateAdd(DateInterval.Month, -1, pFechaD), "YYYY/MM/DD"))
            Sql = Sql.Replace("#pFechaHMesAnt#", cFunciones.gFncConvertDateToString(DateAdd(DateInterval.Month, -1, pFechaH), "YYYY/MM/DD"))


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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cFactura.Dat_GetTotalFactAgrupVendxFechaDH")
            pAdmin.Log.fncGrabarLogERR("Error en cFactura.Dat_GetTotalFactAgrupVendxFechaDH" & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Function Dat_GetTotalFacturasCIVAxFechaDH(ByRef pAdmin As VzAdmin.cAdmin, ByVal pFechaD As Date, ByVal pFechaH As Date) As Double

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "select ifnull(round(Sum(Abs(Tot_Fact)),2), 0) Total from ven_facturas where FecEmi >= '#pFechaD#'  and FecEmi <= '#pFechaH#' and MarcaAnulado ='N'  and CodForm in('0151', '0101');"
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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cFactura.Dat_GetTotalFacturasCIVAxFechaDH")
            pAdmin.Log.fncGrabarLogERR("Error en cFactura.Dat_GetTotalFacturasCIVAxFechaDH:" & ex.Message)
            Return Nothing
        End Try
    End Function


    Public Shared Function Dat_GetCantFacturasxFechaDH(ByRef pAdmin As VzAdmin.cAdmin, ByVal pFechaD As Date, ByVal pFechaH As Date) As Integer

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "select count(*) from ven_facturas where FecEmi >= '#pFechaD#'  and FecEmi <= '#pFechaH#'  and MarcaAnulado ='N'  and CodForm in('0151', '0101');"
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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cFactura.Dat_GetTotalFacturasxFecha")
            pAdmin.Log.fncGrabarLogERR("Error en cFactura.Dat_GetTotalFacturasxFecha:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Function Dat_GetTotalNotasDebitoxFechaDH(ByRef pAdmin As VzAdmin.cAdmin, ByVal pFechaD As Date, ByVal pFechaH As Date) As Double

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "select  ifnull(round(Sum(Abs(Tot_Fact)),2), 0) TotalcIVA from ven_facturas where FecEmi >= '#pFechaD#'  and FecEmi <= '#pFechaH#'   and MarcaAnulado ='N'  and CodForm in('0102', '0152');"
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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cFactura.Dat_GetTotalNotasDebitoxFechaDH")
            pAdmin.Log.fncGrabarLogERR("Error en cFactura.Dat_GetTotalNotasDebitoxFechaDH:" & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Function Dat_GetTotalNotasCreditoxFechaDH(ByRef pAdmin As VzAdmin.cAdmin, ByVal pFechaD As Date, ByVal pFechaH As Date) As Double

        Dim Cmd As New MySqlCommand
        Dim Sql As String
        Dim lDt As DataTable
        Dim lCnn As MySqlConnection

        Try
            lCnn = pAdmin.DbCnn.GetInstanceCon
            Sql = "select ifnull(round(Sum(Abs(Tot_Fact)),2), 0) Total from ven_facturas where FecEmi >= '#pFechaD#'  and FecEmi <= '#pFechaH#'  and MarcaAnulado ='N'  and CodForm in('0153', '0103');"
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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "cFactura.Dat_GetTotalNotasCreditoxFechaDH")
            pAdmin.Log.fncGrabarLogERR("Error en cFactura.Dat_GetTotalNotasCreditoxFechaDH:" & ex.Message)
            Return Nothing
        End Try
    End Function



#End Region


End Class
