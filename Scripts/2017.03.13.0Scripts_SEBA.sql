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