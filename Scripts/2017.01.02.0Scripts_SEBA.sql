
update vz_settings
set valor = '17.1.2.0'
where id_setting = 4;

/*----------------------------------------------------------------------------------------*/
drop table vz_mailing;

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
and  idusr=_idusr;

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

insert vz_permisos_usuario (id_permiso, idusr, alta, baja, modifica, consulta, ejecuta, supervisa, admin) values (24,19,'S','S','S','S','S','S','S');

/*-------------------------------------------------------------------------------------------------------------------------------*/


delete from vz_settings where cod_setting='Mailing_ChkRechazado';
insert into vz_settings (id_setting, cod_setting, tipo_dato, valor, observaciones)
values(7,'Mailing_ChkRechazado', 1, 'sebastianfurche@gmail.com;gabrieladossena@gmail.com', 'Lista de distribucion mailing de cheques rechazados');



delete from vz_settings where cod_setting='Mailing_TesoInicioDia';
insert into vz_settings (id_setting, cod_setting, tipo_dato, valor, observaciones)
values(8,'Mailing_TesoInicioDia', 1, 'sebastianfurche@gmail.com;gabrieladossena@gmail.com', 'Lista de distribucion mailing de Tesoreria Inicio de Dia');


/*----------------------------------------------------------------------------------------*/


Buenos dias,

A continuacion se adjunta un breve resumen de la informacion mas importante para empezar el dia:

CHQUES EN CARTERA
Actualmente hay #CantChequesenCartera# cheques en cartera por un total de  #SumaChequesenCartera# pesos.

Estos es la caida de cheques para los proximos dias:

Cheques rechazados pendientes de levantar:


/*--Cheques en cartera---*/
select count(*) from vz_cheques where id_estado = 0;

select round(sum(importe),2)  from vz_cheques  where id_estado = 0;

select fecha_pago, round(sum(importe),2) from vz_cheques 
where id_estado =0
and fecha_pago <= DATE_ADD(CURDATE(), INTERVAL 7 DAY)
group by fecha_pago
order by fecha_pago



