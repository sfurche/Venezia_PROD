
update vz_settings
set valor = '16.11.21.0'
where id_setting = 4;


update vz_estados set estado = 'Rechazado Pte' where tabla='vz_cheques' and id_estado=2;
insert into vz_estados (id_estado,tabla, estado) values (3, 'vz_cheques','Rechazado Liq');


DROP PROCEDURE vz_comments_ins;

DELIMITER //
CREATE  PROCEDURE `vz_comments_ins`(  
 
  `_text` TEXT ,
  `_tabla` VARCHAR(100)  ,
  `_evento` VARCHAR(150)  ,
  `_id_objeto` INT  ,
  `_idusr` INT )
BEGIN
/*Inserta las liquidaciones.*/
/*Ejemplo de invocacion:  CALL vz_comments_ins('Texto de comentario','vz_liquidaciones','conciliacion', 2, 9)  */

DECLARE v_nr INT;

START TRANSACTION;

SET v_nr =(select count(*) + 1 from vz_comments);

INSERT INTO vz_comments
(`id_comment`,
`text`,
`fecha`,
`tabla`,
`evento`,
`id_objeto`,
`idusr`)
VALUES
(v_nr,
`_text`,
now(),
`_tabla`,
`_evento`,
`_id_objeto`,
`_idusr`);
  
CALL vz_log_ins(now(), 'INS', 'vz_comments', v_nr,_idusr, '');
  
COMMIT;
select v_nr;

END //


ALTER TABLE vz_liquidaciones_conciliacion
ADD COLUMN id_cheque INT NULL AFTER idusr;

DROP PROCEDURE vz_liquidaciones_conciliacion_ins;

DELIMITER //
CREATE PROCEDURE vz_liquidaciones_conciliacion_ins(	
 IN   _id_liquidacion INT, 
 IN   _Id_Deudores INT,
 IN   _Id_Cheque INT,
 IN   _importe DOUBLE,
 IN   _aplicacion VARCHAR(1),
 IN   _fecha DATE ,
 IN   _hora TIME,
 IN   _idusr INT)
BEGIN
/*Inserta la conciliacion de las liquidaciones.*/
/*Ejemplo de invocacion: CALL vz_liquidaciones_conciliacion_ins(7, 124917, 2900, 'T','2016/07/17', '12:30:21', 7);  */
DECLARE v_id_liq_con INT;

START TRANSACTION;

SET v_id_liq_con =(select max(id_liq_con) + 1 from vz_liquidaciones_conciliacion);

set v_id_liq_con = IFNULL(v_id_liq_con,1);

INSERT INTO vz_liquidaciones_conciliacion (id_liq_con, id_liquidacion, Id_Deudores, id_cheque, importe, aplicacion, fecha, hora, id_estado, idusr)
VALUES (v_id_liq_con, _id_liquidacion, _Id_Deudores, _Id_Cheque, _importe, _aplicacion,  _fecha, _hora , 0, _idusr);

CALL vz_log_ins(now(), 'INS', 'vz_liquidaciones_conciliacion', v_id_liq_con, _idusr, '');

COMMIT;

END //





