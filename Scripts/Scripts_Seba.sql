use venezia_20170303;




/*----------------------------------------------------------------------------------------*/
/*-----------------------------UTILIDAD---------------------------------------------------*/
/*----------------------------------------------------------------------------------------*/

drop procedure IF EXISTS vz_Facturas_GetUtilidadxIdFac;

DELIMITER //

CREATE PROCEDURE `vz_Facturas_GetUtilidadxIdFac`(IN _Id_Fac INT)
BEGIN

select ROUND((Sum(PcioTotal) - sum(CantProd*PcioCosto)),2) Utilidad from ven_detfac  where Id_Fac = _Id_Fac  ;

END //	

/*----------------------------------------------------------------------------------------*/

select count(*), sum(Tot_Fact_sIVA), sum(Tot_Fact), sum(Tot_Comi),  sum(Utilidad)
from (
select Tot_Fact_sIVA, Tot_Fact, Tot_Comi, 
 (select ROUND((Sum(PcioTotal) - sum(CantProd*PcioCosto)),2) Utilidad from ven_detfac  where Id_Fac = f.Id_Fac  ) Utilidad
 from ven_facturas as f
 where FecEmi >= '2017/03/01'  and FecEmi  <= '2017/03/15'  and MarcaAnulado ='N'  and CodForm in('0151', '0101')  ) as a


/*----------------------------------------------------------------------------------------*/



 select v.NombreVen, count(*) Cant, round(Sum(f.Tot_Fact_sIVA),2) TotalsIVA,  round(Sum(f.Tot_Fact),2) TotalcIVA,  round(Sum(Tot_Comi),2) Comision, 
 (select round(Sum(Tot_Fact),2) TotalcIVA from ven_facturas where FecEmi >= '2017/02/01'and FecEmi >'2017/03/01' and Id_Vendedor = v.Id_Vendedor and MarcaAnulado ='N' and CodForm in('0151', '0101')) Mes_Anterior,
 SUM((select ROUND((Sum(PcioTotal) - sum(CantProd*PcioCosto)),2) Utilidad from ven_detfac  where Id_Fac = f.Id_Fac  and MarcaAnulado ='N' )) Utilidad
 from ven_facturas as f, ven_vendedor as v  
 where FecEmi >= '2017/03/01'  and FecEmi  <= '2017/03/15'  and f.Id_Vendedor = v.Id_Vendedor  and MarcaAnulado ='N'  and CodForm in('0151', '0101')  
 group by v.NombreVen  order by TotalsIVA desc; 
 
 select * from ven_vendedor
 
 
select * from ven_detfac  where Id_Fac in(
select Id_Fac from ven_facturas 
where FecEmi >= '2017/03/01'  and FecEmi  <= '2017/03/15' and MarcaAnulado ='N'  and CodForm in('0151', '0101')  
and Id_Vendedor = 4) and MarcaAnulado ='N' 
 
 
 
 
  select v.Id_Vendedor, v.NombreVen, count(*) Cant, 
 round(Sum(f.Tot_Fact_sIVA),2) TotalsIVA,  
 round(Sum(f.Tot_Fact),2) TotalcIVA,  
 round(Sum(Tot_Comi),2) Comision, 
 (select round(Sum(Tot_Fact),2) TotalcIVA from ven_facturas where FecEmi >= '2017/02/01'and FecEmi >'2017/03/01' and Id_Vendedor = v.Id_Vendedor and MarcaAnulado ='N' and CodForm in('0151', '0101')) Mes_Anterior,
 SUM(( CASE f.CodForm 
 WHEN '0101'THEN (
select ROUND((Sum(PcioTotal) - sum(CantProd*PcioCosto)),2) Utilidad from ven_detfac  where Id_Fac = f.Id_Fac and f.CodForm='0101' and MarcaAnulado ='N' 
 ) 
 WHEN '151' THEN (
select ROUND((Sum(PcioTotal/1.21) - sum(CantProd*PcioCosto)),2) Utilidad from ven_detfac  where Id_Fac = f.Id_Fac and f.CodForm='0101' and MarcaAnulado ='N' 
 ) end
 )) Utilidad
 from ven_facturas as f, ven_vendedor as v  
 where FecEmi >= '2017/03/01'  and FecEmi  <= '2017/03/15'  and f.Id_Vendedor = v.Id_Vendedor  and MarcaAnulado ='N'  and CodForm in('0151', '0101')  
 group by v.NombreVen  order by TotalsIVA desc; 


SELECT *
 from ven_facturas as f, ven_detfac AS d
 where FecEmi >= '2017/03/01'  and FecEmi  <= '2017/03/15'  and d.MarcaAnulado ='N'  and f.MarcaAnulado ='N' and CodForm in('0151', '0101')  
and f.Id_Fac = d.Id_Fac
 
 
 --------------------------------------------------------------------------------------
 
 ULTIMO
 
  select v.Id_Vendedor, v.NombreVen, count(*) Cant, 
 round(Sum(f.Tot_Fact_sIVA),2) TotalsIVA,  
 round(Sum(f.Tot_Fact),2) TotalcIVA,  
 round(Sum(Tot_Comi),2) Comision, 
 (select round(Sum(Tot_Fact),2) TotalcIVA from ven_facturas where FecEmi >= '2017/02/01'and FecEmi >'2017/03/01' and Id_Vendedor = v.Id_Vendedor and MarcaAnulado ='N' and CodForm in('0151', '0101')) Mes_Anterior,
 SUM(( CASE f.CodForm 
 WHEN '0101'THEN (
select ROUND((Sum(PcioTotal) - sum(CantProd*PcioCosto)),2) Utilidad from ven_detfac  where Id_Fac = f.Id_Fac and f.CodForm='0101' and MarcaAnulado ='N' 
 ) 
 WHEN '151' THEN (
select ROUND((Sum(PcioTotal/1.21) - sum(CantProd*PcioCosto)),2) Utilidad from ven_detfac  where Id_Fac = f.Id_Fac and f.CodForm='0101' and MarcaAnulado ='N' 
 ) end
 )) Utilidad
 from ven_facturas as f, ven_vendedor as v  
 where FecEmi >= '2017/03/01'  and FecEmi  <= '2017/03/15'  and f.Id_Vendedor = v.Id_Vendedor  and MarcaAnulado ='N'  and CodForm in('0151', '0101')  
 group by v.NombreVen  order by TotalsIVA desc; 


SELECT *
 from ven_facturas as f, ven_detfac AS d
 where FecEmi >= '2017/03/01'  and FecEmi  <= '2017/03/15'  and d.MarcaAnulado ='N'  and f.MarcaAnulado ='N' and CodForm in('0151', '0101')  
and f.Id_Fac = d.Id_Fac


--CONTROLO LOS VALORES.

select sum(Costo), Sum(Total), sum(Utilidad)
from (
select (CantProd*PcioCosto) Costo, (PcioTotal) Total, (PcioTotal-(CantProd*PcioCosto)) Utilidad
from ven_detfac  where Id_Fac in(
select Id_Fac from ven_facturas 
where FecEmi >= '2017/03/01'  and FecEmi  <= '2017/03/15' and MarcaAnulado ='N'  and CodForm = '0101' 
and Id_Vendedor = 13 ) and MarcaAnulado ='N' 
UNION
select (CantProd*PcioCosto) Costo, (PcioTotal/1.21) Total, ((PcioTotal/1.21)-(CantProd*PcioCosto)) Utilidad
from ven_detfac  where Id_Fac in(
select Id_Fac from ven_facturas 
where FecEmi >= '2017/03/01'  and FecEmi  <= '2017/03/15' and MarcaAnulado ='N'  and CodForm ='0151'  
and Id_Vendedor = 13) and MarcaAnulado ='N' 
 ) as a

4 184974.98000000004	334831.1453719009	149856.16537190074

12 165975.56000000006	293310.1238016526	127334.56380165274

13 37880	31324	-6556
 
 
 ------------------------------------------------------------------------------------------------------------------------------------------------
 04/04/2017
 
 
 
 
 
 
SELECT Id_Vendedor, NombreVen, COUNT(*) Cant, 
 ROUND(SUM(Tot_Fact_sIVA),2) TotalsIVA,  
 ROUND(SUM(Tot_Fact),2) TotalcIVA,  
 ROUND(SUM(Tot_Comi),2) Comision, 
 (SELECT ROUND(SUM(Tot_Fact),2) TotalcIVA FROM ven_facturas where FecEmi >= '2017/02/01'AND FecEmi >'2017/03/01' AND Id_Vendedor = v.Id_Vendedor AND MarcaAnulado ='N' AND CodForm in('0151', '0101')) Mes_Anterior,
 ROUND(sum(Utilidad),2) Utilidad
 FROM (

 SELECT f.Id_Fac, Id_DetFac, v.Id_Vendedor, v.NombreVen, f.Tot_Fact_sIVA, f.Tot_Fact,  f.Tot_Comi, f.CodForm, PcioUnit, PcioTotal, PcioCosto, ROUND((PcioTotal-PcioCosto*CantProd),2) Utilidad
 FROM ven_facturas as f, ven_vendedor as v, ven_detfac d
 WHERE FecEmi >= '2017/03/01'  AND FecEmi  <= '2017/03/15'  AND f.Id_Vendedor = v.Id_Vendedor  AND f.MarcaAnulado ='N'  AND CodForm = '0101'  AND d.MarcaAnulado ='N'
 AND f.Id_Fac = d.Id_Fac
 AND f.Id_Vendedor=2
 UNION
 SELECT f.Id_Fac, Id_DetFac, v.Id_Vendedor, v.NombreVen, f.Tot_Fact_sIVA, f.Tot_Fact,  f.Tot_Comi, f.CodForm, PcioUnit, PcioTotal, PcioCosto, ROUND((PcioTotal/1.21 - PcioCosto*CantProd),2) Utilidad
 FROM ven_facturas as f, ven_vendedor as v, ven_detfac d
 WHERE FecEmi >= '2017/03/01'  AND FecEmi  <= '2017/03/15'  AND f.Id_Vendedor = v.Id_Vendedor  AND f.MarcaAnulado ='N'  AND CodForm  ='0151'  AND d.MarcaAnulado ='N'
 AND f.Id_Fac = d.Id_Fac
 AND f.Id_Vendedor=2
 ORDER BY Id_DetFac
 
) AS A 
 GROUP BY v.NombreVen  ORDER BY TotalsIVA desc; 

------------------------------------------------------------
============================================================


============================================================

SELECT sum(Utilidad) FROM (

 SELECT f.Id_Fac, Id_DetFac, v.Id_Vendedor, v.NombreVen, f.Tot_Fact_sIVA, f.Tot_Fact,  f.Tot_Comi, f.CodForm, PcioUnit, PcioTotal, PcioCosto, ROUND((PcioTotal-PcioCosto*CantProd),2) Utilidad
 FROM ven_facturas as f, ven_vendedor as v, ven_detfac d
 WHERE FecEmi >= '2017/03/01'  AND FecEmi  <= '2017/03/15'  AND f.Id_Vendedor = v.Id_Vendedor  AND f.MarcaAnulado ='N'  AND CodForm = '0101'  AND d.MarcaAnulado ='N'
 AND f.Id_Fac = d.Id_Fac
 AND f.Id_Vendedor=2
 UNION
 SELECT f.Id_Fac, Id_DetFac, v.Id_Vendedor, v.NombreVen, f.Tot_Fact_sIVA, f.Tot_Fact,  f.Tot_Comi, f.CodForm, PcioUnit, PcioTotal, PcioCosto, ROUND((PcioTotal/1.21 - PcioCosto*CantProd),2) Utilidad
 FROM ven_facturas as f, ven_vendedor as v, ven_detfac d
 WHERE FecEmi >= '2017/03/01'  AND FecEmi  <= '2017/03/15'  AND f.Id_Vendedor = v.Id_Vendedor  AND f.MarcaAnulado ='N'  AND CodForm  ='0151'  AND d.MarcaAnulado ='N'
 AND f.Id_Fac = d.Id_Fac
 AND f.Id_Vendedor=2
 ORDER BY Id_DetFac
 
) AS A 

 
 
 
 
 select * from ven_detfac where Id_Fac=96127
 
 
 
 
 
 
 
 
 
 
 
 
 