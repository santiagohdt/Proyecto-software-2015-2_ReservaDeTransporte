using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminItinerariosUQ.CapaDatos
{
    class VGlobales
    {
        // Identificación de la aplicación.
        public static string NOMBRE_APLICACION = " - Itinerarios";

        // Variables constantes para la cadena de conexion de la base de datos.
        public static string HOST = "localhost";

        public static string USUARIO_DB = "arceing";
        public static string PASSWORD_DB = "pechuga";

        public static string DATABASE = "itinerarios";

        // Variable que almacena el usuario que hizo Log in.
        public static string usuario = "";
        public static string nombreCompletoUsuario = "";
        public static string idMedico = "";
        public static string tipoAcceso = "";


        /// <summary>
        /// Se almacena el tipo de usuario del login actual. | 1 = GENERAL | 2 = AUXILIAR | 3 = CONSULTAS |. ( -1 es invalido )
        /// </summary>
        public static int tipoUsuario = -1;
    }
}
