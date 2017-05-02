update vz_settings
set valor = '17.4.24.0'
where id_setting = 4;


/*----------------------------------------------------------------------------------------*/

ALTER TABLE vz_ordencompra ADD observaciones text;

insert vz_permisos(id_permiso, nombre, observaciones) values (31, 'STK_OC: Consulta de Orden de Compra', '');
insert vz_permisos_usuario (id_permiso, idusr, alta, baja, modifica, consulta, ejecuta, supervisa, admin) values (31,19,'S','S','S','S','S','S','S');


/*----------------------------------------------------------------------------------------*/

DROP PROCEDURE IF EXISTS vz_liquidaciones_TotalDetxFecha;

DELIMITER //

CREATE PROCEDURE `vz_liquidaciones_TotalDetxFecha`(
`_fecha` DATETIME 
  )
BEGIN

DECLARE vTotalLiq DOUBLE;
DECLARE vFechaInicio DATE;

SET vTotalLiq = ifnull((Select sum(importe_cash + importe_cheques + importe_retenciones + importe_transferencias + importe_ncredito) Total from vz_liquidaciones where fecha = _fecha and id_estado=2),0); 
SET vFechaInicio = (select concat(year(_fecha), '/', month(_fecha), '/01'));

Select 'Efectivo', ifnull(ROUND(SUM(importe_cash),2),0) Total, ifnull(ROUND((SUM(importe_cash) * 100/ vTotalLiq),2),0) Porc,
ifnull((Select ifnull(round(sum(importe_cash),2),0) Acumulado from vz_liquidaciones where fecha >= vFechaInicio AND fecha <= _fecha and id_estado= 2),0) Acumulado
from vz_liquidaciones where fecha = _fecha and id_estado=2

union 

Select 'Cheques', ifnull(ROUND(SUM(importe_cheques),2),0) Total, ifnull(ROUND((SUM(importe_cheques) * 100/ vTotalLiq),2),0) Porc,
ifnull((Select ifnull(round(sum(importe_cheques),2),0) Acumulado from vz_liquidaciones where fecha >= vFechaInicio AND fecha <= _fecha and id_estado= 2),0) Acumulado
 from vz_liquidaciones where fecha = _fecha and id_estado=2 

union 

Select 'Transferencias', ifnull(ROUND(SUM(importe_transferencias),2),0) Total, ifnull(ROUND((SUM(importe_transferencias)* 100/ vTotalLiq),2),0) Porc,
(Select ifnull(round(sum(importe_transferencias),2),0) Acumulado from vz_liquidaciones where fecha >= vFechaInicio AND fecha <= _fecha and id_estado= 2) Acumulado
from vz_liquidaciones where fecha = _fecha and id_estado=2 

union 

Select 'Retenciones', ifnull(ROUND(SUM(importe_retenciones),2),0) Total, ifnull(ROUND((SUM(importe_retenciones) * 100/ vTotalLiq),2),0) Porc,
ifnull((Select ifnull(round(sum(importe_retenciones),2),0) Acumulado from vz_liquidaciones where fecha >= vFechaInicio AND fecha <= _fecha and id_estado= 2),0) Acumulado
from vz_liquidaciones where fecha = _fecha and id_estado=2 

union 
Select 'NCredito', ifnull(ROUND(SUM(importe_ncredito),2),0) Total, ifnull(ROUND((SUM(importe_ncredito) * 100/ vTotalLiq),2),0) Porc,
ifnull((Select ifnull(round(sum(importe_ncredito),2),0) Acumulado from vz_liquidaciones where fecha >= vFechaInicio AND fecha <= _fecha and id_estado= 2),0) Acumulado
from vz_liquidaciones where fecha = _fecha and id_estado=2;

END //

/*----------------------------------------------------------------------------------------*/




/*----------------------------------------------------------------------------------------*/
drop procedure IF EXISTS vz_ordencompra_ins;

DELIMITER //

CREATE PROCEDURE `vz_ordencompra_ins`(  
  `_fecha` DATE  ,
  `_CodProve` INT  ,
  `_importe` DOUBLE  ,
  `_fecha_entrega` DATE ,
  `_observaciones` TEXT,
  `_idusr` INT )
BEGIN

DECLARE v_nr INT;

START TRANSACTION;

SET v_nr =IFNULL((select max(id_ordencompra) + 1 from vz_ordencompra),1);

Insert INTO vz_ordencompra (
id_ordencompra, 
fecha, 
CodProve, 
importe, 
fecha_entrega,
observaciones,
id_estado)

VALUES
(v_nr,
`_fecha`,
`_CodProve`,
`_importe`,
`_fecha_entrega`,
`_observaciones`,
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
  `_observaciones` TEXT,
  `_idusr` INT )
  
BEGIN

START TRANSACTION;

UPDATE vz_ordencompra 
SET fecha = _fecha,
CodProve = _CodProve, 
importe = _importe,
fecha_entrega = _fecha_entrega,
observaciones = _observaciones
WHERE id_ordencompra = _id_ordencompra;
         
CALL vz_log_ins(now(), 'UPD', 'vz_ordencompra', _id_ordencompra,_idusr, '');
  
COMMIT;

END //	

/*----------------------------------------------------------------------------------------*/


