angular.module('myApp', ['onsen'])
.controller('myController', function($scope, $http) {
	var ctrl = this;

	ctrl.hostApp = 'http://localhost:82/SantiagoItinerarios/consultas.php?callback=JSON_CALLBACK';

	// Variables internas de sesión.
	ctrl.G_idUsuario = '';
	ctrl.G_nombreUsuario = '';
	ctrl.G_tipoUsuario = '';
	
	ctrl.fecha_itinerario = '';
	
	// Variables para el itinerario.
	ctrl.facultad = '';
	ctrl.responsable = '';
	ctrl.descripcion = '';
	ctrl.sitio_salida = '';
	ctrl.sitio_llegada = '';
	ctrl.fecha_salida = '';
	ctrl.fecha_llegada = '';
	ctrl.vehiculo = '';
	ctrl.observaciones = '';

	ctrl.cerrarSesion = function(){
		ctrl.G_idUsuario = '';
		ctrl.G_nombreUsuario = '';
		ctrl.G_tipoUsuario = '';
		$scope.myNavigator.resetToPage('home.html', { animation: 'default' });
		navigator.app.exitApp();
	};

	ctrl.iniciarSesion = function(){
		var data = {usuario: ctrl.usuario, password: ctrl.password};

		$http.jsonp(ctrl.hostApp + '&consulta=iniciarSesion' + "&data=" + JSON.stringify(data))
		.success(function(data){

			if (data.resultado === "1") {
				ctrl.usuario = '';
				ctrl.password = '';

				ctrl.G_tipoUsuario = data.query[0].tipos_usuarios_id;
				ctrl.G_nombreUsuario = data.query[0].usuario;
				ctrl.G_idUsuario = data.query[0].id;

				if (ctrl.G_tipoUsuario === '2') {
					$scope.myNavigator.pushPage('fecha-itinerarios.html', { animation : 'slide' } );
				}
			}
			else{
				ctrl.darMensaje('Ha ocurrido un error. Por favor revise los datos.');
			}
		});
	};
	
	ctrl.verItinerario = function(id){
		ons.notification.confirm({
			message: 'Desea ver el itinerario ?',			  
			  title: 'SISTEMA DE INFORMACIÓN',
			  buttonLabels: ['Si', 'No'],
			  animation: 'default', // or 'none'
			  primaryButtonIndex: 1,
			  cancelable: true,
			  callback: function(index) {
			  	if(index === 0){
				
				var fi = new Date(ctrl.fecha_itinerario);
				var fecha_itinerario =  fi.getFullYear() + "-" + (fi.getMonth()+1) + "-" + fi.getDate();
				ctrl.fecha_itinerario = fecha_itinerario;
			  		var data = {fecha: fecha_itinerario, idUsuario: ctrl.G_idUsuario};

					$http.jsonp(ctrl.hostApp + '&consulta=verItinerario' + "&data=" + JSON.stringify(data))
					.success(function(data){

						if (data.resultado === "1") {
							ctrl.facultad = data.query[0].facultad;
							ctrl.responsable = data.query[0].responsable_actividad;
							ctrl.descripcion = data.query[0].descripcion_actividad;
							ctrl.sitio_salida = data.query[0].sitio_salida;
							ctrl.sitio_llegada = data.query[0].sitio_llegada;
							ctrl.fecha_salida = data.query[0].fecha_salida;
							ctrl.fecha_llegada = data.query[0].fecha_llegada;
							ctrl.vehiculo = data.query[0].vehiculo;
							ctrl.observaciones = data.query[0].observaciones;
							$scope.myNavigator.pushPage('verItinerario.html', { animation : 'slide' } );
						}
						else{
							ctrl.darMensaje('No se han encontrado itinerarios para esta fecha.');
						}
					});
			  	}
			  	else{
			  		ctrl.darMensaje("Operación cancelada.");
			  	}
			  }
			});
	};

	ctrl.darMensaje = function(mensaje) {
		ons.notification.alert({
			message: mensaje,
			  // or messageHTML: '<div>Message in HTML</div>',
			  title: 'SISTEMA DE INFORMACIÓN',
			  buttonLabel: 'OK',
			  animation: 'default', // or 'none'
			  // modifier: 'optional-modifier'
			  callback: function() {
			    // Alert button is closed!
			}
		});
	};
});