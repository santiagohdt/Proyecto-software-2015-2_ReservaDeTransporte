using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminItinerariosUQ.MenuPrincipal
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void buttonUsuarios_Click(object sender, EventArgs e)
        {
            Configuracion.ConfiguracionUsuarios form = new Configuracion.ConfiguracionUsuarios();
            form.Show();
        }

        private void buttonVehiculos_Click(object sender, EventArgs e)
        {
            Configuracion.ConfiguracionVehiculos form = new Configuracion.ConfiguracionVehiculos();
            form.Show();
        }

        private void buttonFacultades_Click(object sender, EventArgs e)
        {
            Configuracion.ConfiguracionFacultades form = new Configuracion.ConfiguracionFacultades();
            form.Show();
        }

        private void buttonItinerario_Click(object sender, EventArgs e)
        {
            Itinerario.Itinerario form = new Itinerario.Itinerario();
            form.Show();
        }
    }
}
