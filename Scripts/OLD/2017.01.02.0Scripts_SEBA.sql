update vz_settings
set valor = '17.1.2.0'
where id_setting = 4;

/*----------------------------------------------------------------------------------------*/
drop table  IF EXISTS vz_mailing;

CREATE TABLE `vz_mailing` (
  `id_mailing` INT NOT NULL,
  `fecha` DATETIME NOT NULL,
  `asunto` VARCHAR(200) NOT NULL DEFAULT '',
  `para` VARCHAR(500) NOT NULL DEFAULT '',
  `cc` VARCHAR(500) NOT NULL DEFAULT '',
  `bcc` VARCHAR(500) NOT NULL DEFAULT '',
  `body` TEXT NOT NULL,
  `html` BIT NOT NULL,
  `tipo_mailing` VARCHAR(100) NULL,
  `id_estado` INT NULL,
  PRIMARY KEY (`id_mailing`),
  INDEX `fk_vz_mailing_idestado_idx` (`id_estado` ASC),
  CONSTRAINT `fk_vz_mailing_idestado`
    FOREIGN KEY (`id_estado`)
    REFERENCES `vz_estados` (`id_estado`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

/*----------------------------------------------------------------------------------------*/

INSERT INTO vz_estados values(0,'vz_mailing','Pendiente');
INSERT INTO vz_estados values(1,'vz_mailing','Procesado');
INSERT INTO vz_estados values(99,'vz_mailing','Anulado');

/*----------------------------------------------------------------------------------------*/

drop procedure IF EXISTS vz_mailing_ins;

DELIMITER //
CREATE  PROCEDURE `vz_mailing_ins`(  
  `_fecha` DATETIME ,
  `_asunto` VARCHAR(200) ,
  `_para` VARCHAR(500) ,
  `_cc` VARCHAR(500) ,
  `_bcc` VARCHAR(500),
  `_body` TEXT ,
  `_html` BIT ,
  `_tipo_mailing` VARCHAR(100),
   `_idusr` INT 
 )
BEGIN
/*Inserta los mails para enviar.*/

DECLARE v_nr INT;

START TRANSACTION;

SET v_nr =(select count(*) + 1 from vz_mailing);

INSERT INTO vz_mailing
(id_mailing,
fecha,
asunto,
para,
cc,
bcc,
body,
html,
tipo_mailing,
id_estado)
VALUES
(v_nr,
_fecha,
_asunto,
_para,
_cc,
_bcc,
_body,
_html,
_tipo_mailing,
0);
  
CALL vz_log_ins(now(), 'INS', 'vz_mailing', v_nr,_idusr, '');
  
COMMIT;
select v_nr;

END //

/*----------------------------------------------------------------------------------------*/

drop procedure IF EXISTS vz_mailing_cambest;

DELIMITER //

CREATE PROCEDURE `vz_mailing_cambest`(
 IN   _id_mailing INT,
 IN   _id_estado INT,
 IN    _idusr INT)
BEGIN

declare old_estado INT;

START TRANSACTION;

set old_estado = (select id_estado from vz_mailing where id_mailing = _id_mailing);

UPDATE  vz_mailing 
SET id_estado =_id_estado
where id_mailing = _id_mailing;

CALL vz_log_auditoria_ins(now(), 'CHEST', 'vz_mailing', _id_mailing, _idusr, '', _id_estado, old_estado);

COMMIT;

END //	

/*----------------------------------------------------------------------------------------*/

drop procedure IF EXISTS vz_ListaPreciosDet_ins;

DELIMITER //

CREATE PROCEDURE `vz_ListaPreciosDet_ins`(  
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
CONCAT( LPAD(_CodLista,3,'0'), LPAD(_CodArt,4,'0')),
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


drop procedure IF EXISTS vz_permisos_usuarios_consulta;

DELIMITER //
CREATE PROCEDURE vz_permisos_usuarios_consulta(
 IN _idusr int 
  )
BEGIN

/*call vz_permisos_usuarios_consulta (19) */

Select p.id_permiso, p.nombre, p.observaciones, _idusr idusr,
ifnull(pu.alta, 'N') alta,
ifnull(pu.baja, 'N') baja,
ifnull(pu.modifica, 'N') modifica,
ifnull(pu.consulta, 'N') consulta,
ifnull(pu.ejecuta, 'N') ejecuta,
ifnull(pu.supervisa, 'N') supervisa,
ifnull(pu.admin, 'N') admin
from  vz_permisos p 
left join  vz_permisos_usuario pu 
on  pu.id_permiso = p.id_permiso
and  idusr=_idusr
order by nombre;
END //

/*----------------------------------------------------------------------------------------*/


/*----------------------------------------------------------------------------------------*/

drop procedure IF EXISTS vz_permisos_usuario_ins;

DELIMITER //
CREATE PROCEDURE `vz_permisos_usuario_ins`(  
  `_id_permiso` INT  ,
  `_idusr_permiso` INT  ,
  `_alta` VARCHAR(1) ,
  `_baja` VARCHAR(1) ,
  `_modifica` VARCHAR(1) ,
  `_consulta` VARCHAR(1) ,
  `_ejecuta` VARCHAR(1) ,
  `_supervisa` VARCHAR(1) ,
  `_admin` VARCHAR(1),
  `_idusr` INT 
  )
BEGIN
/*Inserta los permisos.*/

START TRANSACTION;

INSERT INTO vz_permisos_usuario
(
  `id_permiso` ,
  `idusr` ,
  `alta` ,
  `baja`,
  `modifica` ,
  `consulta` ,
  `ejecuta`,
  `supervisa`,
  `admin` )
VALUES(
  `_id_permiso` ,
  `_idusr_permiso` ,
  `_alta` ,
  `_baja`,
  `_modifica` ,
  `_consulta` ,
  `_ejecuta`,
  `_supervisa`,
  `_admin` 
);

  
CALL vz_log_ins(now(), 'INS', 'vz_permisos_usuario', _id_permiso,_idusr, '');
  
COMMIT;

END //


/*----------------------------------------------------------------------------------------*/

drop procedure IF EXISTS vz_permisos_usuario_upd;

DELIMITER //
CREATE PROCEDURE `vz_permisos_usuario_upd`(  
  `_id_permiso` INT  ,
  `_idusr_permiso` INT  ,
  `_alta` VARCHAR(1) ,
  `_baja` VARCHAR(1) ,
  `_modifica` VARCHAR(1) ,
  `_consulta` VARCHAR(1) ,
  `_ejecuta` VARCHAR(1) ,
  `_supervisa` VARCHAR(1) ,
  `_admin` VARCHAR(1),
  `_idusr` INT  )
BEGIN
/*Actualiza las ordenes de pago.*/

START TRANSACTION;

UPDATE vz_permisos_usuario
SET alta = _alta,
  baja = _baja,
  modifica = _modifica,
  consulta = _consulta,
  ejecuta= _ejecuta,
  supervisa= _supervisa,
  admin = _admin
WHERE  id_permiso = _id_permiso 
and  idusr = _idusr_permiso;

  
CALL vz_log_ins(now(), 'UPD', 'vz_permisos_usuario', _id_permiso, _idusr, '');
  
COMMIT;

END //

/*----------------------------------------------------------------------------------------*/

drop procedure IF EXISTS vz_comments_ins;

DELIMITER //

CREATE PROCEDURE `vz_comments_ins`(  
 
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

SET v_nr =(select max(id_comment) + 1 from vz_comments);

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

END//


/*-------------------------------------------------------------------------------------------------------------------------------*/
/*-------------------------------------------------------------------------------------------------------------------------------*/
drop procedure IF EXISTS vz_liquidaciones_TotalDetxFecha;

DELIMITER //

CREATE PROCEDURE `vz_liquidaciones_TotalDetxFecha`(
`_fecha` DATETIME 
  )
BEGIN

DECLARE vTotalLiq DOUBLE;

SET vTotalLiq = (Select sum(importe_cash + importe_cheques + importe_retenciones + importe_transferencias + importe_ncredito) Total from vz_liquidaciones where fecha = _fecha and id_estado=2); 

Select 'Efectivo', ROUND(SUM(importe_cash),2) Total, ROUND((SUM(importe_cash) * 100/ vTotalLiq),2) Porc from vz_liquidaciones where fecha = _fecha and id_estado=2 
union 
Select 'Cheques', ROUND(SUM(importe_cheques),2) Total, ROUND((SUM(importe_cheques) * 100/ vTotalLiq),2) Porc from vz_liquidaciones where fecha = _fecha and id_estado=2 
union 
Select 'Transferencias', ROUND(SUM(importe_transferencias),2) Total, ROUND((SUM(importe_transferencias)* 100/ vTotalLiq),2) Porc from vz_liquidaciones where fecha = _fecha and id_estado=2 
union 
Select 'Retenciones', ROUND(SUM(importe_retenciones),2) Total, ROUND((SUM(importe_retenciones) * 100/ vTotalLiq),2) Porc from vz_liquidaciones where fecha = _fecha and id_estado=2 
union 
Select 'NCredito', ROUND(SUM(importe_ncredito),2) Total, ROUND((SUM(importe_ncredito) * 100/ vTotalLiq),2) Porc from vz_liquidaciones where fecha = _fecha and id_estado=2;


END//


/*-------------------------------------------------------------------------------------------------------------------------------*/
/*-------------------------------------------------------------------------------------------------------------------------------*/


truncate table vz_permisos_usuario;
delete from vz_permisos;


insert vz_permisos(id_permiso, nombre, observaciones) values (1, 'TESO_LIQ: Nueva Liquidacion', '');
insert vz_permisos(id_permiso, nombre, observaciones) values (2, 'TESO_LIQ: Nueva Liquidacion Alta Rapida', '');
insert vz_permisos(id_permiso, nombre, observaciones) values (3, 'TESO_LIQ: Consulta de Liquidaciones', '');
insert vz_permisos(id_permiso, nombre, observaciones) values (4, 'TESO_LIQ: Conciliacion de Liquidaciones', '');
insert vz_permisos(id_permiso, nombre, observaciones) values (5, 'TESO_LIQ: Anular Conciliacion de Liquidaciones', '');
insert vz_permisos(id_permiso, nombre, observaciones) values (6, 'TESO_LIQ_RPT: Rendicion Diaria de valores', '');
insert vz_permisos(id_permiso, nombre, observaciones) values (7, 'TESO_LIQ_RPT: Liquidaciones Historicas', '');

insert vz_permisos(id_permiso, nombre, observaciones) values (8, 'TESO_ORDP: Alta Orden de Pago', '');
insert vz_permisos(id_permiso, nombre, observaciones) values (9, 'TESO_ORDP: Consulta Ordenes de Pago', '');
insert vz_permisos(id_permiso, nombre, observaciones) values (10, 'TESO_ORDP_RPT: Comprobante de Orden de Pago', '');
insert vz_permisos(id_permiso, nombre, observaciones) values (11, 'TESO_ORDP: Ordenes de Pago x Fecha', '');


insert vz_permisos(id_permiso, nombre, observaciones) values (12, 'TESO_CHQ: Consulta de Cheques', '');
insert vz_permisos(id_permiso, nombre, observaciones) values (13, 'TESO_CHQ_RPT: Cheques en Cartera', '');
insert vz_permisos(id_permiso, nombre, observaciones) values (14, 'TESO_CHQ_RPT: Cheques x Fecha de Emision', '');
insert vz_permisos(id_permiso, nombre, observaciones) values (15, 'TESO_CHQ_RPT: Cheques x Proveedor', '');

insert vz_permisos(id_permiso, nombre, observaciones) values (16, 'COM_VEN: Consulta de Vendedores', '');
insert vz_permisos(id_permiso, nombre, observaciones) values (17, 'COM_PRO: Consulta de Proveedores', '');

insert vz_permisos(id_permiso, nombre, observaciones) values (18, 'STK_ART: Consulta de Articulos', '');

insert vz_permisos(id_permiso, nombre, observaciones) values (19, 'STK_LP: Consulta Precios x Lista', '');
insert vz_permisos(id_permiso, nombre, observaciones) values (20, 'STK_LP: Consulta de Listas de Precio', '');
insert vz_permisos(id_permiso, nombre, observaciones) values (21, 'STK_LP: Carga Masiva de Precios', '');

insert vz_permisos(id_permiso, nombre, observaciones) values (22, 'HERR_CFG: Fondo de Pantalla', '');
insert vz_permisos(id_permiso, nombre, observaciones) values (23, 'HERR_CFG: Variables', '');

insert vz_permisos(id_permiso, nombre, observaciones) values (24, 'HERR_SEG: Consulta de Permisos', '');
insert vz_permisos(id_permiso, nombre, observaciones) values (25, 'HERR_PROC: Mailing Automatico', '');
insert vz_permisos(id_permiso, nombre, observaciones) values (26, 'HERR_PROC: Mailing TesoInicio de Dia', '');

insert vz_permisos(id_permiso, nombre, observaciones) values (27, 'TESO_CHQ_RPT: Ranking de Cheques x Cliente', '');
insert vz_permisos(id_permiso, nombre, observaciones) values (28, 'HERR_PROC: Mailing TesoInicio Fin de Dia', '');


insert vz_permisos_usuario (id_permiso, idusr, alta, baja, modifica, consulta, ejecuta, supervisa, admin) values (1,19,'S','S','S','S','S','S','S');
insert vz_permisos_usuario (id_permiso, idusr, alta, baja, modifica, consulta, ejecuta, supervisa, admin) values (2,19,'S','S','S','S','S','S','S');
insert vz_permisos_usuario (id_permiso, idusr, alta, baja, modifica, consulta, ejecuta, supervisa, admin) values (3,19,'S','S','S','S','S','S','S');
insert vz_permisos_usuario (id_permiso, idusr, alta, baja, modifica, consulta, ejecuta, supervisa, admin) values (4,19,'S','S','S','S','S','S','S');
insert vz_permisos_usuario (id_permiso, idusr, alta, baja, modifica, consulta, ejecuta, supervisa, admin) values (5,19,'S','S','S','S','S','S','S');
insert vz_permisos_usuario (id_permiso, idusr, alta, baja, modifica, consulta, ejecuta, supervisa, admin) values (6,19,'S','S','S','S','S','S','S');
insert vz_permisos_usuario (id_permiso, idusr, alta, baja, modifica, consulta, ejecuta, supervisa, admin) values (7,19,'S','S','S','S','S','S','S');
insert vz_permisos_usuario (id_permiso, idusr, alta, baja, modifica, consulta, ejecuta, supervisa, admin) values (8,19,'S','S','S','S','S','S','S');
insert vz_permisos_usuario (id_permiso, idusr, alta, baja, modifica, consulta, ejecuta, supervisa, admin) values (9,19,'S','S','S','S','S','S','S');
insert vz_permisos_usuario (id_permiso, idusr, alta, baja, modifica, consulta, ejecuta, supervisa, admin) values (10,19,'S','S','S','S','S','S','S');
insert vz_permisos_usuario (id_permiso, idusr, alta, baja, modifica, consulta, ejecuta, supervisa, admin) values (11,19,'S','S','S','S','S','S','S');
insert vz_permisos_usuario (id_permiso, idusr, alta, baja, modifica, consulta, ejecuta, supervisa, admin) values (12,19,'S','S','S','S','S','S','S');
insert vz_permisos_usuario (id_permiso, idusr, alta, baja, modifica, consulta, ejecuta, supervisa, admin) values (13,19,'S','S','S','S','S','S','S');
insert vz_permisos_usuario (id_permiso, idusr, alta, baja, modifica, consulta, ejecuta, supervisa, admin) values (14,19,'S','S','S','S','S','S','S');
insert vz_permisos_usuario (id_permiso, idusr, alta, baja, modifica, consulta, ejecuta, supervisa, admin) values (15,19,'S','S','S','S','S','S','S');
insert vz_permisos_usuario (id_permiso, idusr, alta, baja, modifica, consulta, ejecuta, supervisa, admin) values (16,19,'S','S','S','S','S','S','S');
insert vz_permisos_usuario (id_permiso, idusr, alta, baja, modifica, consulta, ejecuta, supervisa, admin) values (17,19,'S','S','S','S','S','S','S');
insert vz_permisos_usuario (id_permiso, idusr, alta, baja, modifica, consulta, ejecuta, supervisa, admin) values (18,19,'S','S','S','S','S','S','S');
insert vz_permisos_usuario (id_permiso, idusr, alta, baja, modifica, consulta, ejecuta, supervisa, admin) values (19,19,'S','S','S','S','S','S','S');
insert vz_permisos_usuario (id_permiso, idusr, alta, baja, modifica, consulta, ejecuta, supervisa, admin) values (20,19,'S','S','S','S','S','S','S');
insert vz_permisos_usuario (id_permiso, idusr, alta, baja, modifica, consulta, ejecuta, supervisa, admin) values (21,19,'S','S','S','S','S','S','S');
insert vz_permisos_usuario (id_permiso, idusr, alta, baja, modifica, consulta, ejecuta, supervisa, admin) values (22,19,'S','S','S','S','S','S','S');
insert vz_permisos_usuario (id_permiso, idusr, alta, baja, modifica, consulta, ejecuta, supervisa, admin) values (23,19,'S','S','S','S','S','S','S');
insert vz_permisos_usuario (id_permiso, idusr, alta, baja, modifica, consulta, ejecuta, supervisa, admin) values (24,19,'S','S','S','S','S','S','S');
insert vz_permisos_usuario (id_permiso, idusr, alta, baja, modifica, consulta, ejecuta, supervisa, admin) values (25,19,'S','S','S','S','S','S','S');
insert vz_permisos_usuario (id_permiso, idusr, alta, baja, modifica, consulta, ejecuta, supervisa, admin) values (26,19,'S','S','S','S','S','S','S');
insert vz_permisos_usuario (id_permiso, idusr, alta, baja, modifica, consulta, ejecuta, supervisa, admin) values (27,19,'S','S','S','S','S','S','S');
insert vz_permisos_usuario (id_permiso, idusr, alta, baja, modifica, consulta, ejecuta, supervisa, admin) values (28,19,'S','S','S','S','S','S','S');


/*-------------------------------------------------------------------------------------------------------------------------------*/

delete from vz_settings where cod_setting='Mailing_ChkRechazado';
insert into vz_settings (id_setting, cod_setting, tipo_dato, valor, observaciones)
values(7,'Mailing_ChkRechazado', 1, 'sebastianfurche@gmail.com;loirajulian@gmail.com;osvaldo.gonzalez@cdsurargentina.com.ar;consultas@cdsurargentina.com.ar', 'Lista de distribucion mailing de cheques rechazados');


delete from vz_settings where cod_setting='Mailing_TesoInicioDia';
insert into vz_settings (id_setting, cod_setting, tipo_dato, valor, observaciones)
values(8,'Mailing_TesoInicioDia', 1, 'sebastianfurche@gmail.com;osvaldo.gonzalez@cdsurargentina.com.ar;consultas@cdsurargentina.com.ar', 'Lista de distribucion mailing de Tesoreria Inicio de Dia');


delete from vz_settings where cod_setting='Mailing_TesoFinDia';
insert into vz_settings (id_setting, cod_setting, tipo_dato, valor, observaciones)
values(9,'Mailing_TesoFinDia', 1, 'sebastianfurche@gmail.com;osvaldo.gonzalez@cdsurargentina.com.ar;consultas@cdsurargentina.com.ar', 'Lista de distribucion mailing de Tesoreria Resumen Fin del Dia');

/*----------------------------------------------------------------------------------------*/

drop table  IF EXISTS vz_scheduler;

CREATE TABLE `vz_scheduler` (
  `id_schedule` INT NOT NULL,
  `proceso` VARCHAR(200) NOT NULL,
  `inicio` TIME(6) NOT NULL,
  `fin` TIME(6) NOT NULL,
  `rate` INT NOT NULL,
  `nohabiles` INT NOT NULL,
  `ultejec` DATETIME NOT NULL,
  `descripcion` VARCHAR(45) NULL,
  PRIMARY KEY (`id_schedule`),
  UNIQUE INDEX `id_schedule_UNIQUE` (`id_schedule` ASC));
     
/*----------------------------------------------------------------------------------------*/
	 
  INSERT INTO vz_scheduler (id_schedule, proceso, inicio, fin, rate, nohabiles, ultejec,  descripcion) values(1, 'EnvioMailsPendientes','06:00:00' , '21:00:00', 300 , 1, '2000/01/01 12:00', 'Envia todos los mails pendientes.');  
  INSERT INTO vz_scheduler (id_schedule, proceso, inicio, fin, rate, nohabiles, ultejec, descripcion) values(2, 'MailingInicioDia','07:00:00', '07:35:00', 1800,1, '2000/01/01 12:00' , 'Generacion de mailing de inicio de dia.');
  INSERT INTO vz_scheduler (id_schedule, proceso, inicio, fin, rate, nohabiles, ultejec, descripcion) values(3, 'MailingFinDia','18:00:00', '18:35:00', 1800,1, '2000/01/01 12:00' , 'Generacion de mailing de fin de dia.');
  
  /*----------------------------------------------------------------------------------------*/
    
  drop table  IF EXISTS vz_Feriados;
  
  CREATE TABLE `vz_Feriados` (
  `fecha` DATETIME NOT NULL,
  `Descripcion` VARCHAR(200) NOT NULL,
    PRIMARY KEY (`fecha`),
  UNIQUE INDEX `fecha_UNIQUE` (`fecha` ASC));
  
  INSERT INTO vz_feriados (fecha, descripcion) values ('2017/02/27','Carnaval');
  INSERT INTO vz_feriados (fecha, descripcion) values ('2017/02/28','Carnaval');
  INSERT INTO vz_feriados (fecha, descripcion) values ('2017/03/24','Día Nacional de la Memoria por la Verdad y la Justicia');
  INSERT INTO vz_feriados (fecha, descripcion) values ('2017/04/02','Día del Veterano y de los Caídos en la Guerra de Malvinas');
  INSERT INTO vz_feriados (fecha, descripcion) values ('2017/04/13','Jueves Santo');
  INSERT INTO vz_feriados (fecha, descripcion) values ('2017/04/14','Viernes Santo');
  INSERT INTO vz_feriados (fecha, descripcion) values ('2017/05/01','Día del Trabajador');
  INSERT INTO vz_feriados (fecha, descripcion) values ('2017/05/25','Día de la Revolución de Mayo');
  INSERT INTO vz_feriados (fecha, descripcion) values ('2017/06/17','Día Paso a la Inmortalidad del General Martín Miguel de Güemes');
  INSERT INTO vz_feriados (fecha, descripcion) values ('2017/06/20','Día Paso a la Inmortalidad del General Manuel Belgrano');  
  INSERT INTO vz_feriados (fecha, descripcion) values ('2017/07/09','Día de la Independencia');
  INSERT INTO vz_feriados (fecha, descripcion) values ('2017/08/21','Paso a la Inmortalidad del General José de San Martín');
  INSERT INTO vz_feriados (fecha, descripcion) values ('2017/10/16','Día del Respeto a la Diversidad Cultural');
  INSERT INTO vz_feriados (fecha, descripcion) values ('2017/11/20','Día de la Soberanía Nacional Original');
  INSERT INTO vz_feriados (fecha, descripcion) values ('2017/12/08','Inmaculada Concepción de María');
  INSERT INTO vz_feriados (fecha, descripcion) values ('2017/12/25','Navidad');
  INSERT INTO vz_feriados (fecha, descripcion) values ('2018/01/01','Año Nuevo');
  
/*----------------------------------------------------------------------------------------*/
insert into sis_usuarios(Empre, idusr, nombre, clave, nivelacceso,falta,fbaja,clavemy)
values ('001','21','Venezia_Schedule','aaa', '2' ,'2017/03/01','3001/01/01','');

set @Clave = (select clave from sis_usuarios where idusr=19);
update sis_usuarios
set clave = @Clave
where idusr=21;



