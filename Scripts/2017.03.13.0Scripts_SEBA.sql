update vz_settings
set valor = '17.3.13.0'
where id_setting = 4;

/*----------------------------------------------------------------------------------------*/

drop procedure IF EXISTS vz_Facturas_GetUtilidadxIdFac;

DELIMITER //

CREATE PROCEDURE `vz_Facturas_GetUtilidadxIdFac`(IN _Id_Fac INT)
BEGIN

select ROUND((Sum(PcioTotal) - sum(CantProd*PcioCosto)),2) Utilidad from ven_detfac  where Id_Fac = _Id_Fac  ;

END //	

/*----------------------------------------------------------------------------------------*/


