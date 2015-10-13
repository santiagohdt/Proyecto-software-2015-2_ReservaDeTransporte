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
    public partial class ConfiguracionVehiculos : Form
    {
        private MySqlCommand cmd;

        public ConfiguracionVehiculos()
        {
            InitializeComponent();
            CargarVehiculos();
        }

        private void CargarVehiculos()
        {
            cmd = CapaDatos.CapaDatos.crearComando();
            cmd.Parameters.Clear();
            cmd.CommandText = "SELECT * FROM vehiculos";

            dataVechiculos.DataSource = CapaDatos.CapaDatos.ejecutarComandoSelect(cmd);
        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            textColor.Text = "";
            textPlaca.Text = "";
            dateSOAT.Value = DateTime.Now;
            dateTecnicoMecanica.Value = DateTime.Now;
        }

        private void buttonAlmacenar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textPlaca.Text))
            {
                MessageBox.Show("Por favor indique la placa del vehículo");
                return;
            }

            if (String.IsNullOrEmpty(textColor.Text))
            {
                MessageBox.Show("Por favor indique el color del vehículo");
                return;
            }

            cmd.Parameters.Clear();
            cmd.CommandText = "INSERT INTO vehiculos (placa, color, soat, tecnicomecanica) VALUES (@placa, @color, @soat, @tecnicomecanica)";
            cmd.Parameters.AddWithValue("@placa", textPlaca.Text);
            cmd.Parameters.AddWithValue("@color", textPlaca.Text);
            cmd.Parameters.AddWithValue("@soat", dateSOAT.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@tecnicomecanica", dateTecnicoMecanica.Value.ToString("yyyy-MM-dd"));

            if (CapaDatos.CapaDatos.ejecutarComando(cmd))
            {
                CargarVehiculos();
                MessageBox.Show("Se ha almacenado correctamente el vehículo.");
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error al almacenar el vehículo.");
            }
        }

        private void dataVechiculos_Click(object sender, EventArgs e)
        {
            try
            {
                textPlaca.Text = dataVechiculos["placa", dataVechiculos.CurrentRow.Index].Value.ToString();
                textColor.Text = dataVechiculos["color", dataVechiculos.CurrentRow.Index].Value.ToString();
                dateSOAT.Value = Convert.ToDateTime(dataVechiculos["soat", dataVechiculos.CurrentRow.Index].Value.ToString());
                dateTecnicoMecanica.Value = Convert.ToDateTime(dataVechiculos["tecnicomecanica", dataVechiculos.CurrentRow.Index].Value.ToString());
            }
            catch
            {

                throw;
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                dataVechiculos["id", dataVechiculos.CurrentRow.Index].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Por favor indique el vehículo que desea eliminar.");
                return;
            }

            cmd = CapaDatos.CapaDatos.crearComando();
            cmd.Parameters.Clear();
            cmd.CommandText = "DELETE FROM vehiculos WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", dataVechiculos["id", dataVechiculos.CurrentRow.Index].Value.ToString());

            if (CapaDatos.CapaDatos.ejecutarComando(cmd))
            {
                CargarVehiculos();
                MessageBox.Show("Se ha eliminado correctamente el vehículo.");
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error al eliminar el vehículo.");
            }
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textPlaca.Text))
            {
                MessageBox.Show("Por favor indique la placa del vehículo");
                return;
            }

            if (String.IsNullOrEmpty(textColor.Text))
            {
                MessageBox.Show("Por favor indique el color del vehículo");
                return;
            }

            try
            {
                dataVechiculos["id", dataVechiculos.CurrentRow.Index].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Por favor indique el vehículo que desea modificar.");
                return;
            }

            cmd.Parameters.Clear();
            cmd.CommandText = "UPDATE vehiculos SET placa = @placa, color = @color, soat = @soat, tecnicomecanica = @tecnicomecanica WHERE id = @id";
            cmd.Parameters.AddWithValue("@placa", textPlaca.Text);
            cmd.Parameters.AddWithValue("@color", textPlaca.Text);
            cmd.Parameters.AddWithValue("@soat", dateSOAT.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@tecnicomecanica", dateTecnicoMecanica.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@id", dataVechiculos["id", dataVechiculos.CurrentRow.Index].Value.ToString());

            if (CapaDatos.CapaDatos.ejecutarComando(cmd))
            {
                CargarVehiculos();
                MessageBox.Show("Se ha almacenado correctamente el vehículo.");
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error al almacenar el vehículo.");
            }
        }
    }
}
