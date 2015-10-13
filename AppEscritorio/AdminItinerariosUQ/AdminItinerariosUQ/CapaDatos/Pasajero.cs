using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminItinerariosUQ.CapaDatos
{
    public class Pasajero
    {
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string documento;

        public string Documento
        {
            get { return documento; }
            set { documento = value; }
        }
        private string vinculacion;

        public string Vinculacion
        {
            get { return vinculacion; }
            set { vinculacion = value; }
        }
    }
}
