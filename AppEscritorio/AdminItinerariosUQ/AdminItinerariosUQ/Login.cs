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

namespace AdminItinerariosUQ
{
    public partial class Login : Form
    {
        private MySqlCommand cmd;

        public Login()
        {
            InitializeComponent();
        }

        private void buttonEntrar_Click(object sender, EventArgs e)
        {
            cmd = CapaDatos.CapaDatos.crearComando();
            cmd.Parameters.Clear();
            cmd.CommandText = "SELECT * FROM usuarios WHERE usuario = @usuario AND password = @password AND tipos_usuarios_id = 1 LIMIT 1";
            cmd.Parameters.AddWithValue("@usuario", textUsuario.Text);
            cmd.Parameters.AddWithValue("@password", textContrasena.Text);

            DataTable miUsuario = CapaDatos.CapaDatos.ejecutarComandoSelect(cmd);

            if (miUsuario.Rows.Count > 0)
            {
                this.Visible = false;
                MenuPrincipal.MenuPrincipal form = new MenuPrincipal.MenuPrincipal();
                form.Show();
            }
            else
            {
                MessageBox.Show("Por favor revise Usuario / Contraseña");
            }            
        }
    }
}
