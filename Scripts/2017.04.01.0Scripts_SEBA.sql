update vz_settings
set valor = '17.4.1.0'
where id_setting = 4;

/*---------------------------ESTADOS-------------------------------------------------------------*/

INSERT INTO vz_estados values(0,'vz_ordencompra','Pendiente');
INSERT INTO vz_estados values(1,'vz_ordencompra','Confirmada');
INSERT INTO vz_estados values(2,'vz_ordencompra','Recibida');
INSERT INTO vz_estados values(99,'vz_ordencompra','Anulada');

/*----------------------------------------------------------------------------------------*/


drop procedure IF EXISTS vz_Facturas_GetUtilidadxIdFac;

DELIMITER //

CREATE PROCEDURE `vz_Facturas_GetUtilidadxIdFac`(IN _Id_Fac INT)
BEGIN

select ROUND((Sum(PcioTotal) - sum(CantProd*PcioCosto)),2) Utilidad from ven_detfac  where Id_Fac = _Id_Fac  ;

END //	


/*----------------------------------------------------------------------------------------*/
/*------------------------------ORDEN DE COMPRA-------------------------------------------*/

DROP TABLE IF EXISTS vz_ordencompra;

CREATE TABLE `vz_ordencompra` (
  `id_ordencompra` INT NOT NULL,
  `fecha` DATE NOT NULL,
  `CodProve` INT NOT NULL,
  `importe` DOUBLE NOT NULL,
  `fecha_entrega` DATE NOT NULL,
  `id_estado` INT NULL,
  UNIQUE INDEX `id_ordencompra_UNIQUE` (`id_ordencompra` ASC),
  PRIMARY KEY (`id_ordencompra`),
  INDEX `vzordencopra_fkproveedotr_idx` (`CodProve` ASC),
  INDEX `vzordencompra_fkidestado_idx` (`id_estado` ASC),
  CONSTRAINT `vzordencompra_fkproveedotr`
    FOREIGN KEY (`CodProve`)
    REFERENCES `prv_proveedor` (`CodProve`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
 CONSTRAINT `fk_vz_ordencompra_estado`
    FOREIGN KEY (`id_estado`)
    REFERENCES `vz_estados` (`id_estado`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

/*----------------------------------------------------------------------------------------*/

DROP TABLE IF EXISTS vz_ordencompra_det;

CREATE TABLE `vz_ordencompra_det` (
  `id_ordencompra_det` INT NOT NULL,
  `id_ordencompra` INT NOT NULL,
  `CodArt` INT NOT NULL,
  `cantidad` INT NOT NULL,
  `preciounitario` DOUBLE NOT NULL,
  PRIMARY KEY (`id_ordencompra_det`),
  INDEX `vzordencompradet_idordc_idx` (`id_ordencompra` ASC),
  INDEX `vzordencompradet_codart_idx` (`CodArt` ASC),
  CONSTRAINT `vzordencompradet_idordc`
    FOREIGN KEY (`id_ordencompra`)
    REFERENCES `vz_ordencompra` (`id_ordencompra`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `vzordencompradet_codart`
    FOREIGN KEY (`CodArt`)
    REFERENCES `pro_articulos` (`CodArt`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


/*----------------------------------------------------------------------------------------*/
drop procedure IF EXISTS vz_ordencompra_ins;

DELIMITER //

CREATE PROCEDURE `vz_ordencompra_ins`(  
  `_fecha` DATE  ,
  `_CodProve` INT  ,
  `_importe` DOUBLE  ,
  `_fecha_entrega` DATE ,
  `_idusr` INT )
BEGIN

DECLARE v_nr INT;

START TRANSACTION;

SET v_nr =(select count(*) + 1 from vz_ordencompra);

Insert INTO vz_ordencompra (
id_ordencompra, 
fecha, 
CodProve, 
importe, 
fecha_entrega,
id_estado)

VALUES
(v_nr,
`_fecha`,
`_CodProve`,
`_importe`,
`_fecha_entrega`,
0 );
         
CALL vz_log_ins(now(), 'INS', 'vz_ordencompra', v_nr,_idusr, '');
  
COMMIT;
select v_nr;

END //	

/*----------------------------------------------------------------------------------------*/

DROP PROCEDURE IF EXISTS vz_ordencompra_upd;

DELIMITER //
CREATE PROCEDURE `vz_ordencompra_upd`(  
  `_id_ordencompra` INT, 
  `_fecha` DATE  ,
  `_CodProve` INT  ,
  `_importe` DOUBLE  ,
  `_fecha_entrega` DATE ,
  `_idusr` INT )
  
BEGIN

START TRANSACTION;

UPDATE vz_ordencompra 
SET fecha = _fecha,
CodProve = _CodProve, 
importe = _importe,
fecha_entrega = _fecha_entrega
WHERE id_ordencompra = _id_ordencompra;
         
CALL vz_log_ins(now(), 'UPD', 'vz_ordencompra', _id_ordencompra,_idusr, '');
  
COMMIT;

END //	

/*----------------------------------------------------------------------------------------*/

DROP PROCEDURE IF EXISTS vz_ordencompra_cabest;

DELIMITER //

CREATE PROCEDURE `vz_ordencompra_cabest`(  
IN _id_ordencompra INT,
IN _estado INT,
 IN _idusr INT)
BEGIN
/*Actualiza el estado de las ordenes de compra.*/
declare old_estado INT;

START TRANSACTION;

set old_estado = (select id_estado from vz_ordencompra WHERE id_ordencompra =_id_ordencompra);

UPDATE vz_ordencompra 
SET id_estado = _estado
WHERE id_ordencompra =_id_ordencompra;

CALL vz_log_auditoria_ins(now(), 'CHEST', 'vz_ordencompra', _id_ordencompra, _idusr, '', _estado, old_estado);

COMMIT;

END //

/*----------------------------------------------------------------------------------------*/