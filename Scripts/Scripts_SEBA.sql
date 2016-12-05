update vz_settings
set valor = '16.12.01.0'
where id_setting = 4;

/*----------------------------------------------------------------------------------------*/

drop procedure vz_spTesoLiqRptChequesFDFHEstado;

/*----------------------------------------------------------------------------------------*/

INSERT INTO vz_estados values(0,'vz_transferencias','Registrada');
INSERT INTO vz_estados values(1,'vz_transferencias','Conciliada');
INSERT INTO vz_estados values(99,'vz_transferencias','Anulada');

/*----------------------------------------------------------------------------------------*/

CREATE TABLE `vz_transferencias` (
  `id_transferencia` INT NOT NULL,
  `id_liquidacion` INT NOT NULL,
  `fecha` DATE NOT NULL,
  `NroCli` VARCHAR(45) NULL,
  `importe` DOUBLE NOT NULL,
  `id_estado` INT NOT NULL,
  `observaciones` VARCHAR(450) NULL,
  PRIMARY KEY (`id_transferencia`),
  INDEX `fk_vz_transferencias_Nrocli_idx` (`NroCli` ASC),
  CONSTRAINT `fk_vz_transferencias_Nrocli`
    FOREIGN KEY (`NroCli`)
    REFERENCES `cl_clientes` (`NroCli`)
     ON DELETE NO ACTION
    ON UPDATE NO ACTION,
    CONSTRAINT `fk_vz_transferencias_Estado`
    FOREIGN KEY (`id_estado`)
    REFERENCES `vz_estados` (`id_estado`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

/*----------------------------------------------------------------------------------------*/

DELIMITER //
CREATE  PROCEDURE `vz_transferencias_ins`(  
  `_id_liquidacion` INT,
  `_fecha` DATE ,
  `_NroCli` VARCHAR(45) ,
  `_importe` DOUBLE ,
  `_observaciones` VARCHAR(450)  ,
  `_idusr` INT )
BEGIN
/*Inserta las liquidaciones.*/
/*Ejemplo de invocacion:  CALL vz_transferencias_ins(14,'20160809','001000', 23333, 'observac',7)  */

DECLARE v_nr INT;

START TRANSACTION;

SET v_nr =(select count(*) + 1 from vz_transferencias);

INSERT INTO vz_transferencias
(`id_transferencia`,
`id_liquidacion`,
`fecha`,
`NroCli`,
`importe`,
`id_estado`,
`observaciones`)
VALUES
(v_nr,
`_id_liquidacion`,
`_fecha`,
`_NroCli`,
`_importe`,
0,
`_observaciones`);
  
CALL vz_log_ins(now(), 'INS', 'vz_transferencias', v_nr,_idusr, '');
  
COMMIT;
select v_nr;

END //

/*----------------------------------------------------------------------------------------*/

DELIMITER //

CREATE PROCEDURE `vz_transferencias_cambest`(
 IN   _id_transferencia INT,
 IN   _id_estado INT,
 IN    _idusr INT)
BEGIN

declare old_estado INT;

START TRANSACTION;

set old_estado = (select id_estado from vz_transferencias where id_transferencia = _id_transferencia);

UPDATE  vz_transferencias 
SET id_estado =_id_estado
where id_transferencia = _id_transferencia;

CALL vz_log_auditoria_ins(now(), 'CHEST', 'vz_transferencias', _id_transferencia,_idusr, '', _id_estado, old_estado);

COMMIT;

END //

	

/*----------------------------------------------------------------------------------------*/







