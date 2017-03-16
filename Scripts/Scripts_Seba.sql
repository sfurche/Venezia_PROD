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
 
 
 