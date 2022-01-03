
/*Consulta para las instalaciones*/

SELECT i.Id,i.Exitosa,i.Fecha,a.Nombre as Aplicacion,o.Nombre,o.Apellido,t.Marca,t.Modelo,t.Precio
		FROM 
		instalaciones as i inner join apps as a 
			on i.AppId=a.Id
		inner join operarios as o  on i.OperarioId=o.Id inner join telefonos as t
			on i.TelefonoId=t.Id

/*Consulta para Sensores telefonos relacion muchos a muchos*/

SELECT * 
      FROM 
      sensortelefono as st inner join sensor as s 
        on st.SensoresId=s.Id
      inner join telefonos as t
        on st.TelefonosId=t.Id