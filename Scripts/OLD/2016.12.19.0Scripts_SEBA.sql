
update vz_settings
set valor = '16.12.19.0'
where id_setting = 4;



/*----------------------------------------------------------------------------------------*/
drop procedure IF EXISTS vz_ListaPreciosDet_ins;

DELIMITER //
CREATE  PROCEDURE `vz_ListaPreciosDet_ins`(  
  `_id_CodLista` int(11) ,
  `_CodLista` int(11) ,
  `_CodArt` int(11) ,
  `_PcioUnit` double ,
  `_PcioCaja` double ,
  `_PorComis` double ,
  `_idusr` INT )
BEGIN
/*Inserta o modifica los precios por lista*/

DECLARE v_nr INT;

START TRANSACTION;

SET v_nr =(select max(idDetalleLista) + 1 from pro_detlista);

INSERT INTO pro_detlista
(`Empre`,
`idDetalleLista`,
`id_CodLista`,
`CodLista`,
`CodArt`,
`CodProd`,
`PcioUnit`,
`PcioCaja`,
`PorComis`)
VALUES
('001',
v_nr,
`_id_CodLista`,
`_CodLista`,
`_CodArt`,
CONCAT('001', LPAD(_CodArt,4,'0')),
`_PcioUnit`,
0,
`_PorComis`);
  
    IF _id_CodLista = 19 THEN 
		update pro_articulos set PcioVta= _PcioUnit where CodArt = _CodArt;
    END IF;
    
  
CALL vz_log_ins(now(), 'INS', 'vz_transferencias', v_nr,_idusr, '');

CALL vz_precios_log_ins(_CodArt, _PcioUnit, _id_CodLista, _idusr);
   
COMMIT;
select v_nr;

END //

/*----------------------------------------------------------------------------------------*/
drop procedure IF EXISTS vz_ListaPreciosDet_upd;

DELIMITER //
CREATE  PROCEDURE `vz_ListaPreciosDet_upd`(  
  `_idDetalleLista` int(11) ,
  `_PcioUnit` double ,
  `_idusr` INT )
BEGIN
/*Modifica los precios por lista*/

DECLARE vCodArt INT;
DECLARE vCodLista INT;

SET vCodArt =(select CodArt from pro_detlista where idDetalleLista = _idDetalleLista );

SET vCodLista =(select Id_CodLista from pro_detlista where idDetalleLista = _idDetalleLista );

START TRANSACTION;

UPDATE  pro_detlista 
SET PcioUnit =_PcioUnit
where idDetalleLista = _idDetalleLista;
  
      IF vCodLista = 19 THEN 
		update pro_articulos set PcioVta= _PcioUnit where CodArt = vCodArt;
	  END IF;
      
CALL vz_log_ins(now(), 'UPD', 'pro_detlista', _idDetalleLista,_idusr, _PcioUnit);

CALL vz_precios_log_ins(vCodArt, _PcioUnit, vCodLista, _idusr);
   
COMMIT;

END //



