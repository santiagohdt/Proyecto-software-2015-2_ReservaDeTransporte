using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace AdminItinerariosUQ.Configuracion
{
    public partial class ConfiguracionFacultades : Form
    {
        private MySqlCommand cmd;

        public ConfiguracionFacultades()
        {
            InitializeComponent();
            CargarFacultades();
        }

        private void CargarFacultades()
        {
            cmd = CapaDatos.CapaDatos.crearComando();
            cmd.Parameters.Clear();
            cmd.CommandText = "SELECT * FROM facultades ORDER By nombre";

            dataFacultades.DataSource = CapaDatos.CapaDatos.ejecutarComandoSelect(cmd);
        }

        private void buttonAlmacenar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textFacultad.Text))
            {
                MessageBox.Show("Por favor indique el nombre de la facultad.");
                return;
            }

            cmd = CapaDatos.CapaDatos.crearComando();
            cmd.Parameters.Clear();
            cmd.CommandText = "INSERT INTO facultades (nombre) VALUES (@nombre)";
            cmd.Parameters.AddWithValue("@nombre", textFacultad.Text);

            if (CapaDatos.CapaDatos.ejecutarComando(cmd))
            {
                CargarFacultades();
                MessageBox.Show("Se ha almacenado correctamente la facultad");
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error al almacenar la facultad.");
            }
        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            textFacultad.Text = "";
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                dataFacultades["id", dataFacultades.CurrentRow.Index].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Por favor indique la facultad que desea eliminar.");
                return;
            }

            cmd = CapaDatos.CapaDatos.crearComando();
            cmd.Parameters.Clear();
            cmd.CommandText = "DELETE FROM facultades WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", dataFacultades["id", dataFacultades.CurrentRow.Index].Value.ToString());

            if (CapaDatos.CapaDatos.ejecutarComando(cmd))
            {
                CargarFacultades();
                MessageBox.Show("Se ha eliminado correctamente la facultad");
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error al eliminar la facultad.");
            }
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textFacultad.Text))
            {
                MessageBox.Show("Por favor indique el nombre de la facultad.");
                return;
            }

            try
            {
                dataFacultades["id", dataFacultades.CurrentRow.Index].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Por favor indique la facultad que desea modificar.");
                return;
            }

            cmd = CapaDatos.CapaDatos.crearComando();
            cmd.Parameters.Clear();
            cmd.CommandText = "UPDATE facultades SET nombre = @nombre WHERE id = @id";
            cmd.Parameters.AddWithValue("@nombre", textFacultad.Text);
            cmd.Parameters.AddWithValue("@id", dataFacultades["id", dataFacultades.CurrentRow.Index].Value.ToString());

            if (CapaDatos.CapaDatos.ejecutarComando(cmd))
            {
                CargarFacultades();
                MessageBox.Show("Se ha modificado correctamente la facultad");
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error al modificar la facultad.");
            }
        }

        private void dataFacultades_Click(object sender, EventArgs e)
        {
            try
            {
                textFacultad.Text = dataFacultades["nombre", dataFacultades.CurrentRow.Index].Value.ToString();
            }
            catch
            {                                
            }
        }
    }
}
