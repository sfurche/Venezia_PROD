call vz_ordenes_de_pago_x_fecha (' ',' ','2013/08/10','2016/10/16')
drop procedure IF EXISTS vz_ordenes_de_pago_x_fecha

DELIMITER $$
CREATE PROCEDURE vz_ordenes_de_pago_x_fecha(
 IN _estado varchar(45),
 IN _Nombre varchar(50),
 IN _fechad DATE,
 IN _fechah DATE)
BEGIN
/*call vz_ordenes_de_pago_x_fecha (' ',' ','2016/08/10','2016/08/16')*/
SELECT op.id_orden Id_orden ,op.fecha Fecha,op.importe_cash Importe_cash, op.importe_transferencia Importe_transferencia, op.importe_cheques Importe_cheques, op.tipo_destino Tipo_destino,op.destino Destino, op.CodProve CodProve, op.id_estado Id_estado, op.observaciones Observaciones, e.estado Estado, p.Nombre 
from vz_ordenes_de_pago as op inner join vz_estados as e 
on op.id_estado = e.id_estado
left outer join prv_proveedor as p on op.CodProve = p.CodProve
where e.tabla= 'vz_ordenes_de_pago' 
and fecha >= _fechad 
and fecha <= _fechah
and (estado=_estado or _estado=' ')
and (Nombre=_Nombre or _Nombre=' '); 

END$$
DELIMITER ;