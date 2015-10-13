<?php
header("Content-Type: text/javascript");
include 'conexion.php';

$obj = array();
if(isset($_GET['callback']) && isset($_GET['consulta']))
{
	$callback = $_GET['callback'];
	$consulta = $_GET['consulta'];	

	// Inicio de sesión
	if($consulta == 'iniciarSesion' && isset($_GET['data'])){

		$misParamentros = json_decode($_GET['data']);
		$usuario = $misParamentros->{'usuario'};
		$password = $misParamentros->{'password'};

		mysql_query('SET CHARACTER SET utf8');
		$sql = "SELECT id, usuario, tipos_usuarios_id FROM usuarios WHERE usuario = '$usuario' AND password = '$password' AND tipos_usuarios_id = 2 LIMIT 1";

		$resultset = mysql_query($sql,$connection);
		$records = array();
			//Loop through all our records and add them to our array
		while($r = mysql_fetch_assoc($resultset))
		{
			$records[] = $r;
		}

		if(count($records) > 0){
			$obj['resultado'] = '1';
			$obj['query'] = $records;
			echo $callback.'(' . json_encode($obj) . ')';
		}else{
			$obj['resultado'] = '0';
			$obj['query'] = $records;
			echo $callback.'(' . json_encode($obj) . ')';
		}
	}

	// Ver itinerario
	if($consulta == 'verItinerario'){

		$misParamentros = json_decode($_GET['data']);
		$fecha = $misParamentros->{'fecha'};
		$idUsuario = $misParamentros->{'idUsuario'};
		
		mysql_query('SET CHARACTER SET utf8');
		$sql = "SELECT f.nombre as facultad,i.responsable_actividad, i.descripcion_actividad, i.sitio_salida, i.sitio_destino as 'sitio_llegada', i.fecha_salida, i.fecha_llegada, v.placa as 'vehiculo', i.observaciones   FROM itinerarios i JOIN usuarios u ON i.usuarios_id_conductor = u.id JOIN facultades f ON i.facultades_id = f.id JOIN vehiculos v ON i.vehiculos_id = v.id WHERE i.usuarios_id_conductor = '$idUsuario' AND fecha_salida = '$fecha'";

		$resultset = mysql_query($sql,$connection);
		$records = array();
			//Loop through all our records and add them to our array
		while($r = mysql_fetch_assoc($resultset))
		{
			$records[] = $r;
		}

		if(count($records) > 0){
			$obj['resultado'] = '1';
			$obj['query'] = $records;
			echo $callback.'(' . json_encode($obj) . ')';
		}else{
			$obj['resultado'] = '0';
			$obj['query'] = $records;
			echo $callback.'(' . json_encode($obj) . ')';
		}
	}			
}
?>