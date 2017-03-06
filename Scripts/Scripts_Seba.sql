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
Select round(sum(importe_cash + importe_cheques + importe_retenciones + importe_transferencias + importe_ncredito),2) Total from vz_liquidaciones where fecha = '20170303';
/*Cantidad de liquidaciones*/
Select 'Cantidad', count(*) Total from vz_liquidaciones where fecha = '20170303';

/*Ingresos de liquidaciones*/
SET @TotalLiq = (Select sum(importe_cash + importe_cheques + importe_retenciones + importe_transferencias + importe_ncredito) Total from vz_liquidaciones where fecha = '20170303');
Select 'Efectivo', ROUND(SUM(importe_cash),2) Total, ROUND((SUM(importe_cash) * 100/ @TotalLiq),2) Porc from vz_liquidaciones where fecha = '20170303'
union
Select 'Cheques', ROUND(SUM(importe_cheques),2) Total, ROUND((SUM(importe_cheques) * 100/ @TotalLiq),2) Porc from vz_liquidaciones where fecha = '20170303'
union
Select 'Transferencias', ROUND(SUM(importe_transferencias),2) Total, ROUND((SUM(importe_transferencias)* 100/ @TotalLiq),2) Porc from vz_liquidaciones where fecha = '20170303'
union
Select 'Retenciones', ROUND(SUM(importe_retenciones),2) Total, ROUND((SUM(importe_retenciones) * 100/ @TotalLiq),2) Porc from vz_liquidaciones where fecha = '20170303'
union
Select 'NCredito', ROUND(SUM(importe_ncredito),2) Total, ROUND((SUM(importe_ncredito) * 100/ @TotalLiq),2) Porc from vz_liquidaciones where fecha = '20170303';

/*Diferencia de Caja*/

/*Liquidaciones x Vendedor*/
Select ven.NombreVen, round(sum(importe_cash + importe_cheques + importe_retenciones + importe_transferencias + importe_ncredito),2) Cobrado
from vz_liquidaciones as liq, ven_vendedor as ven
where liq.id_vendedor = ven.id_vendedor
and liq.fecha = '20170303'
Group by liq.id_vendedor;

select f.CodForm,s.Descripcion  from ven_facturas as f, sis_formularios as s
WHERE f.CodForm = s.CodForm
group by f.CodForm 

select * from ven_facturas
where FecOp = '20170303'
and MarcaAnulado ='N'


SELECT * FROM sis_formularios
