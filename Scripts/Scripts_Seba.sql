use venezia_20170303;

select ch.id_cheque as Id,  ban.nomb_bco_red as Banco, 
ch.importe as Importe, cl.nombre as Origen, 
DATE_FORMAT(liq.fecha, '%d/%m/%Y') as Recibido 
from vz_cheques as ch, cl_clientes as cl, 
sis_bancos as ban, vz_liquidaciones as liq  
where ch.id_liquidacion = liq.id_liquidacion 
and ch.NroCli = cl.NroCli 
and ch.id_bco = ban.id_bco 
and ch.id_estado = 2

select ch.NroCli, cl.nombre as Cliente, round(sum(ch.importe),2) as Total
,round((sum(ch.importe)*100/(Select Sum(importe) from vz_cheques where id_estado=0)),2) Porcentaje, max(fecha_pago) UltFPago
from vz_cheques as ch, cl_clientes as cl
where ch.NroCli = cl.NroCli 
and ch.id_estado = 0
group by ch.Nrocli
order by Porcentaje desc;

Select * from vz_liquidaciones where fecha = '20170303';




/*-------------TESORERIA----------------------------------------*/
/*Total de liquidaciones*/
Select round(sum(importe_cash + importe_cheques + importe_retenciones + importe_transferencias + importe_ncredito),2) Total from vz_liquidaciones where fecha = CURDATE() and id_estado=2;

/*Cantidad de liquidaciones*/
Select count(*) Total from vz_liquidaciones where fecha = CURDATE() and id_estado=2;

/*Ingresos de liquidaciones*/
SET @TotalLiq = (Select sum(importe_cash + importe_cheques + importe_retenciones + importe_transferencias + importe_ncredito) Total from vz_liquidaciones where fecha = '20170303' and id_estado=2);
Select 'Efectivo', ROUND(SUM(importe_cash),2) Total, ROUND((SUM(importe_cash) * 100/ @TotalLiq),2) Porc from vz_liquidaciones where fecha = '20170303' and id_estado=2
union
Select 'Cheques', ROUND(SUM(importe_cheques),2) Total, ROUND((SUM(importe_cheques) * 100/ @TotalLiq),2) Porc from vz_liquidaciones where fecha = '20170303' and id_estado=2
union
Select 'Transferencias', ROUND(SUM(importe_transferencias),2) Total, ROUND((SUM(importe_transferencias)* 100/ @TotalLiq),2) Porc from vz_liquidaciones where fecha = '20170303' and id_estado=2
union
Select 'Retenciones', ROUND(SUM(importe_retenciones),2) Total, ROUND((SUM(importe_retenciones) * 100/ @TotalLiq),2) Porc from vz_liquidaciones where fecha = '20170303' and id_estado=2
union
Select 'NCredito', ROUND(SUM(importe_ncredito),2) Total, ROUND((SUM(importe_ncredito) * 100/ @TotalLiq),2) Porc from vz_liquidaciones where fecha = '20170303' and id_estado=2;

/*Diferencia de Caja*/

/*Liquidaciones x Vendedor*/
Select ven.NombreVen, round(sum(importe_cash + importe_cheques + importe_retenciones + importe_transferencias + importe_ncredito),2) Cobrado
from vz_liquidaciones as liq, ven_vendedor as ven
where liq.id_vendedor = ven.id_vendedor
and liq.fecha = '20170303'
and liq.id_estado=2
Group by liq.id_vendedor;

/*FACTURAS */
select f.CodForm,s.Descripcion  from ven_facturas as f, sis_formularios as s
WHERE f.CodForm = s.CodForm
group by f.CodForm 

select * from ven_facturas
where FecOp = '20170303'
and MarcaAnulado ='N'

/*FACTURAS PROFORMAS*/
select f.CodForm,s.Descripcion  from ven_factprof as f, sis_formularios as s
WHERE f.CodForm = s.CodForm
group by f.CodForm 


select * from ven_factprof

SELECT * FROM sis_formularios




sql="select v.NombreVen, count(*) Cant, round(Sum(f.Tot_Fact_sIVA),2) TotalsIVA,  round(Sum(f.Tot_Fact),2) TotalcIVA,  round(Sum(Tot_Comi),2) Comision "
sql=sql & " from ven_facturas as f, ven_vendedor as v"
sql=sql & " where FecOp = '20170303'"
sql=sql & " and f.Id_Vendedor = v.Id_Vendedor "
sql=sql & " and MarcaAnulado ='N'"
sql=sql & " and CodForm in('0151', '0101')"
sql=sql & " group by v.NombreVen ""



sql="select ifnull(sum(abs(Importe)),0) Total from vz_liquidaciones_conciliacion"
sql=sql & " where Id_Deudores is null"
sql=sql & " AND fecha = '20160812'"
sql=sql & " and id_estado =0"


sql="Select ven.NombreVen, round(sum(importe_cash + importe_cheques + importe_retenciones + importe_transferencias + importe_ncredito),2) Cobrado"
sql=sql & "from vz_liquidaciones as liq, ven_vendedor as ven"
sql=sql&"where liq.id_vendedor = ven.id_vendedor"
sql=sql&"and liq.fecha = '20170303'"
sql=sql&"and liq.id_estado=2"
sql=sql&"Group by liq.id_vendedor;"

