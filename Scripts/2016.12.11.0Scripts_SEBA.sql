
update vz_settings
set valor = '16.12.11.0'
where id_setting = 4;


/*----------------------------------------------------------------------------------------*/
INSERT INTO vz_settings (id_setting, cod_setting, tipo_dato, valor, observaciones)
VALUES(5,'StkCargaPreciosSepMiles',1,'.','Ruta default para el archivo de carga masiva de precios.');

INSERT INTO vz_settings (id_setting, cod_setting, tipo_dato, valor, observaciones)
VALUES(6,'StkCargaPreciosSepDec',1,',','Ruta default para el archivo de carga masiva de precios.');

/*----------------------------------------------------------------------------------------*/

CREATE TABLE `vz_precios_log` (
  `id_precios_log` INT NOT NULL,
  `CodArt` VARCHAR(45) NOT NULL,
  `Precio` DOUBLE NOT NULL,
  `id_CodLista` INT NULL,
  `fecha` TIMESTAMP NOT NULL,
  PRIMARY KEY (`id_precios_log`),
  UNIQUE INDEX `id_precios_log_UNIQUE` (`id_precios_log` ASC),
  INDEX `idx_precioslog_prod_fecha` (`CodArt` ASC, `id_CodLista` ASC, `fecha` ASC),
  INDEX `fk_precioslog_codlista_idx` (`id_CodLista` ASC),
  CONSTRAINT `fk_precioslog_codlista`
    FOREIGN KEY (`id_CodLista`)
    REFERENCES `pro_listaprecio` (`Id_CodLista`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

/*----------------------------------------------------------------------------------------*/	

DELIMITER //
CREATE  PROCEDURE `vz_precios_log_ins`(  
  `_CodArt` VARCHAR(45) ,
  `_Precio` DOUBLE ,
  `_id_CodLista` INT,
  `_idusr` INT   )
BEGIN
/*Inserta las liquidaciones.*/
/*Ejemplo de invocacion:  CALL vz_precios_log_ins(14,'20160809','001000', 23333, 'observac',7)  */

DECLARE v_nr INT;

START TRANSACTION;

SET v_nr =(select count(*) + 1 from vz_precios_log);

INSERT INTO vz_precios_log
(  `id_precios_log`  ,
  `CodArt`,
  `Precio`  ,
  `id_CodLista` ,
  `fecha` )
VALUES
(v_nr,
  _CodArt ,
  _Precio  ,
  _id_CodLista ,
  now() );
  
CALL vz_log_ins(now(), 'INS', 'vz_precios_log', v_nr,_idusr, '');
  
COMMIT;
select v_nr;

END //

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
		update pro_articulos set PcioVta= _PcioUnit where CodArt = _CodArt;
	  END IF;
      
CALL vz_log_ins(now(), 'UPD', 'pro_detlista', _idDetalleLista,_idusr, _PcioUnit);

CALL vz_precios_log_ins(vCodArt, _PcioUnit, vCodLista, _idusr);
   
COMMIT;

END //
/*----------------------------------------------------------------------------------------*/

DELIMITER //
CREATE  PROCEDURE `pro_articulos_updcosto`(  
  `_CodArt` int(11) ,
  `_PcioCosto` double ,
  `_idusr` INT )
BEGIN
/*Modifica el costo de los articulos*/

START TRANSACTION;

UPDATE  pro_articulos 
SET PcioCosto =_PcioCosto
where CodArt = _CodArt;
  
CALL vz_log_ins(now(), 'UPD', 'pro_articulos', _CodArt,_idusr, _PcioCosto);

CALL vz_precios_log_ins(_CodArt, _PcioCosto, null, _idusr);
   
COMMIT;

END //



/*----------------------------------------------------------------------------------------*/

/*----------------------------------------------------------------------------------------*/

/*----------------------------------------------------------------------------------------*/