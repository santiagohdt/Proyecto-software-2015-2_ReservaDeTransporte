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
    public partial class ConfiguracionUsuarios : Form
    {
        private MySqlCommand cmd;

        public ConfiguracionUsuarios()
        {
            InitializeComponent();
            CargarTipoUsuarios();
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            cmd = CapaDatos.CapaDatos.crearComando();
            cmd.Parameters.Clear();
            cmd.CommandText = "SELECT * FROM usuarios ORDER by nombres";

            dataUsuarios.DataSource = CapaDatos.CapaDatos.ejecutarComandoSelect(cmd);
        }

        private void CargarTipoUsuarios()
        {
            cmd = CapaDatos.CapaDatos.crearComando();
            cmd.Parameters.Clear();
            cmd.CommandText = "SELECT * FROM tipos_usuarios";

            comboTipoUsuario.DataSource = CapaDatos.CapaDatos.ejecutarComandoSelect(cmd);
            comboTipoUsuario.DisplayMember = "nombre";
            comboTipoUsuario.ValueMember = "id";

            comboTipoUsuario.SelectedIndex = -1;
        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            textUsuario.Text = "";
            textPassword.Text = "";

            textNombres.Text = "";
            textApellidos.Text = "";
            textDocumento.Text = "";
            textDireccion.Text = "";
            textTelefono.Text = "";
            textEmail.Text = "";
            comboTipoUsuario.SelectedIndex = -1;
        }

        private void buttonAlmacenar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textUsuario.Text))
            {
                MessageBox.Show("Por favor indique el usuario.");
                return;
            }

            if (String.IsNullOrEmpty(textPassword.Text))
            {
                MessageBox.Show("Por favor indique el password.");
                return;
            }
            if (String.IsNullOrEmpty(textDocumento.Text))
            {
                MessageBox.Show("Por favor indique el documento.");
                return;
            }
            if (String.IsNullOrEmpty(textTelefono.Text))
            {
                MessageBox.Show("Por favor indique el teléfono.");
                return;
            }
            if (String.IsNullOrEmpty(textEmail.Text))
            {
                MessageBox.Show("Por favor indique el email.");
                return;
            }
            if (String.IsNullOrEmpty(textNombres.Text))
            {
                MessageBox.Show("Por favor indique los nombres del usuario.");
                return;
            }
            if (String.IsNullOrEmpty(textApellidos.Text))
            {
                MessageBox.Show("Por favor indique los apellidos.");
                return;
            }
            if (String.IsNullOrEmpty(textDireccion.Text))
            {
                MessageBox.Show("Por favor indique la dirección.");
                return;
            }

            if (String.IsNullOrEmpty(comboTipoUsuario.Text))
            {
                MessageBox.Show("Por favor indique el tipo de usuario.");
                return;
            }

            cmd = CapaDatos.CapaDatos.crearComando();
            cmd.Parameters.Clear();
            cmd.CommandText = "INSERT INTO usuarios (usuario, password, nombres, apellidos, documento, telefono, direccion, fecha_nacimiento, email, ultimo_ingreso, tipos_usuarios_id) VALUES (@usuario, @password, @nombres, @apellidos, @documento, @telefono, @direccion, @fecha_nacimiento, @email, now(), @tipos_usuarios_id)";
            cmd.Parameters.AddWithValue("@usuario", textUsuario.Text);
            cmd.Parameters.AddWithValue("@password", textPassword.Text);
            cmd.Parameters.AddWithValue("@nombres", textNombres.Text);
            cmd.Parameters.AddWithValue("@apellidos", textApellidos.Text);
            cmd.Parameters.AddWithValue("@documento", textDocumento.Text);
            cmd.Parameters.AddWithValue("@telefono", textTelefono.Text);
            cmd.Parameters.AddWithValue("@direccion", textDireccion.Text);
            cmd.Parameters.AddWithValue("@fecha_nacimiento", dateFechaNacimiento.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@email", textEmail.Text);
            cmd.Parameters.AddWithValue("@tipos_usuarios_id", comboTipoUsuario.SelectedValue.ToString());

            if (CapaDatos.CapaDatos.ejecutarComando(cmd))
            {
                CargarUsuarios();
                MessageBox.Show("Se ha almacenado correctamente el usuario");
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error al almacenar el usuario");
            }
        }

        private void dataUsuarios_Click(object sender, EventArgs e)
        {
            try
            {
                textUsuario.Text = dataUsuarios["usuario", dataUsuarios.CurrentRow.Index].Value.ToString();
                textPassword.Text = dataUsuarios["password", dataUsuarios.CurrentRow.Index].Value.ToString();
                textNombres.Text = dataUsuarios["nombres", dataUsuarios.CurrentRow.Index].Value.ToString();
                textApellidos.Text = dataUsuarios["apellidos", dataUsuarios.CurrentRow.Index].Value.ToString();
                textDocumento.Text = dataUsuarios["documento", dataUsuarios.CurrentRow.Index].Value.ToString();
                textTelefono.Text = dataUsuarios["telefono", dataUsuarios.CurrentRow.Index].Value.ToString();
                textDireccion.Text = dataUsuarios["direccion", dataUsuarios.CurrentRow.Index].Value.ToString();
                dateFechaNacimiento.Value = Convert.ToDateTime(dataUsuarios["fecha_nacimiento", dataUsuarios.CurrentRow.Index].Value.ToString());
                textEmail.Text = dataUsuarios["email", dataUsuarios.CurrentRow.Index].Value.ToString();
                comboTipoUsuario.SelectedValue = dataUsuarios["tipos_usuarios_id", dataUsuarios.CurrentRow.Index].Value.ToString();
            }
            catch
            {

            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                dataUsuarios["id", dataUsuarios.CurrentRow.Index].Value.ToString();
            }
            catch
            {
                return;
            }

            cmd = CapaDatos.CapaDatos.crearComando();
            cmd.CommandText = "DELETE FROM usuarios WHERE id = @id";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", dataUsuarios["id", dataUsuarios.CurrentRow.Index].Value.ToString());

            if (CapaDatos.CapaDatos.ejecutarComando(cmd))
            {
                CargarUsuarios();
                MessageBox.Show("Se ha eliminado correctamente el usuario.");
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error al eliminar el usuario.");
            }
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textUsuario.Text))
            {
                MessageBox.Show("Por favor indique el usuario.");
                return;
            }

            if (String.IsNullOrEmpty(textPassword.Text))
            {
                MessageBox.Show("Por favor indique el password.");
                return;
            }
            if (String.IsNullOrEmpty(textDocumento.Text))
            {
                MessageBox.Show("Por favor indique el documento.");
                return;
            }
            if (String.IsNullOrEmpty(textTelefono.Text))
            {
                MessageBox.Show("Por favor indique el teléfono.");
                return;
            }
            if (String.IsNullOrEmpty(textEmail.Text))
            {
                MessageBox.Show("Por favor indique el email.");
                return;
            }
            if (String.IsNullOrEmpty(textNombres.Text))
            {
                MessageBox.Show("Por favor indique los nombres del usuario.");
                return;
            }
            if (String.IsNullOrEmpty(textApellidos.Text))
            {
                MessageBox.Show("Por favor indique los apellidos.");
                return;
            }
            if (String.IsNullOrEmpty(textDireccion.Text))
            {
                MessageBox.Show("Por favor indique la dirección.");
                return;
            }

            if (String.IsNullOrEmpty(comboTipoUsuario.Text))
            {
                MessageBox.Show("Por favor indique el tipo de usuario.");
                return;
            }

            try
            {
                dataUsuarios["id", dataUsuarios.CurrentRow.Index].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Por favor indique el usuario que desea modificar.");
                return;
            }

            cmd = CapaDatos.CapaDatos.crearComando();
            cmd.Parameters.Clear();
            cmd.CommandText = "UPDATE usuarios SET usuario = @usuario, password = @password, nombres = @nombres, apellidos = @apellidos, documento = @documento, telefono = @telefono, direccion = @direccion, fecha_nacimiento = @fecha_nacimiento, email = @email, tipos_usuarios_id = @tipos_usuarios_id WHERE id = @id";
            cmd.Parameters.AddWithValue("@usuario", textUsuario.Text);
            cmd.Parameters.AddWithValue("@password", textPassword.Text);
            cmd.Parameters.AddWithValue("@nombres", textNombres.Text);
            cmd.Parameters.AddWithValue("@apellidos", textApellidos.Text);
            cmd.Parameters.AddWithValue("@documento", textDocumento.Text);
            cmd.Parameters.AddWithValue("@telefono", textTelefono.Text);
            cmd.Parameters.AddWithValue("@direccion", textDireccion.Text);
            cmd.Parameters.AddWithValue("@fecha_nacimiento", dateFechaNacimiento.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@email", textEmail.Text);
            cmd.Parameters.AddWithValue("@tipos_usuarios_id", comboTipoUsuario.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@id", dataUsuarios["id", dataUsuarios.CurrentRow.Index].Value.ToString());

            if (CapaDatos.CapaDatos.ejecutarComando(cmd))
            {
                CargarUsuarios();
                MessageBox.Show("Se ha modificado correctamente el usuario");
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error al modificar el usuario");
            }
        }
    }
}
