using System;
using System.Xml;
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
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;

namespace AdminItinerariosUQ.Itinerario
{
    public partial class Itinerario : Form
    {
        private MySqlCommand cmd;
        private List<CapaDatos.Pasajero> misPasajeros;

        public Itinerario()
        {
            InitializeComponent();
            CargarFacultades();
            CargarVehiculos();
            CargarConductores();
            CargarItinerarios();            

            misPasajeros = new List<CapaDatos.Pasajero>();            
        }

        private void CargarItinerarios()
        {
            cmd = CapaDatos.CapaDatos.crearComando();
            cmd.Parameters.Clear();
            cmd.CommandText = "SELECT * FROM itinerarios ORDER by fecha_solicitud DESC";

            dataItinerarios.DataSource = CapaDatos.CapaDatos.ejecutarComandoSelect(cmd);
        }

        private void SerializeParams<T>(XDocument doc, List<T> paramList)
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(paramList.GetType());

            System.Xml.XmlWriter writer = doc.CreateWriter();

            serializer.Serialize(writer, paramList);

            writer.Close();
        }

        private List<T> DeserializeParams<T>(XDocument doc)
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<T>));

            System.Xml.XmlReader reader = doc.CreateReader();

            List<T> result = (List<T>)serializer.Deserialize(reader);
            reader.Close();

            return result;
        }

        private void CargarConductores()
        {
            cmd = CapaDatos.CapaDatos.crearComando();
            cmd.Parameters.Clear();
            cmd.CommandText = "SELECT id, CONCAT(nombres, ' ', apellidos) as display FROM usuarios WHERE tipos_usuarios_id = 2";

            comboConductor.DataSource = CapaDatos.CapaDatos.ejecutarComandoSelect(cmd);
            comboConductor.DisplayMember = "display";
            comboConductor.ValueMember = "id";

            comboConductor.SelectedIndex = -1;
        }

        private void CargarVehiculos()
        {
            cmd = CapaDatos.CapaDatos.crearComando();
            cmd.Parameters.Clear();
            cmd.CommandText = "SELECT id, CONCAT(placa, ' - ', color) as display FROM vehiculos";

            comboVehiculo.DataSource = CapaDatos.CapaDatos.ejecutarComandoSelect(cmd);
            comboVehiculo.DisplayMember = "display";
            comboVehiculo.ValueMember = "id";

            comboVehiculo.SelectedIndex = -1;
        }

        private void CargarFacultades()
        {
            cmd = CapaDatos.CapaDatos.crearComando();
            cmd.Parameters.Clear();
            cmd.CommandText = "SELECT * FROM facultades";

            comboFacultad.DataSource = CapaDatos.CapaDatos.ejecutarComandoSelect(cmd);
            comboFacultad.DisplayMember = "nombre";
            comboFacultad.ValueMember = "id";

            comboFacultad.SelectedIndex = -1;
        }

        private void Itinerario_Load(object sender, EventArgs e)
        {

        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            comboFacultad.SelectedIndex = -1;
            dateFechaSolicitud.Value = DateTime.Now;
            textNombreSolicitante.Text = "";
            textApellidoSolicitante.Text = "";
            textResponsableActividad.Text = "";
            textDocumentoResponsable.Text = "";
            textDescripcionActividad.Text = "";
            textSitioSalida.Text = "";
            textSitioLlegada.Text = "";
            dateFechaSalida.Value = DateTime.Now;
            dateFechaLlegada.Value = DateTime.Now;
            textNombrePasajero.Text = "";
            textDocumentoPasajero.Text = "";
            textVinculacionPasajero.Text = "";
            dataPasajeros.DataSource = null;
            misPasajeros = new List<CapaDatos.Pasajero>();
            comboConductor.SelectedIndex = -1;
            comboVehiculo.SelectedIndex = -1;
            textObservaciones.Text = "";
        }

        private void buttonAgregarPasajero_Click(object sender, EventArgs e)
        {
            dataPasajeros.DataSource = null;

            CapaDatos.Pasajero miPasajero = new CapaDatos.Pasajero
            {
                Nombre = textNombrePasajero.Text,
                Documento = textDocumentoPasajero.Text,
                Vinculacion = textVinculacionPasajero.Text
            };

            misPasajeros.Add(miPasajero);
            dataPasajeros.DataSource = misPasajeros;
        }

        private void buttonAlmacenar_Click(object sender, EventArgs e)
        {
            if (dataPasajeros.Rows.Count == 0)
            {
                MessageBox.Show("Debe indicar al menos 1 pasajero");
                return;
            }

            if (String.IsNullOrEmpty(textNombreSolicitante.Text))
            {
                MessageBox.Show("Por favor indique el nombre del solicitante.");
                return;
            }

            if (String.IsNullOrEmpty(textApellidoSolicitante.Text))
            {
                MessageBox.Show("Por favor indique el apellido del solicitante.");
                return;
            }
            if (String.IsNullOrEmpty(textResponsableActividad.Text))
            {
                MessageBox.Show("Por favor indique el responsable de la actividad.");
                return;
            }
            if (String.IsNullOrEmpty(textDocumentoResponsable.Text))
            {
                MessageBox.Show("Por favor indique el documento del responsable.");
                return;
            }
            if (String.IsNullOrEmpty(textDescripcionActividad.Text))
            {
                MessageBox.Show("Por favor indique la descripción de la actividad.");
                return;
            }
            if (String.IsNullOrEmpty(textSitioSalida.Text))
            {
                MessageBox.Show("Por favor indique el sitio de salida.");
                return;
            }
            if (String.IsNullOrEmpty(textSitioLlegada.Text))
            {
                MessageBox.Show("Por favor indique el sitio de llegada.");
                return;
            }

            if (String.IsNullOrEmpty(comboFacultad.Text))
            {
                MessageBox.Show("Por favor indique la facultad.");
                return;
            }
            if (String.IsNullOrEmpty(comboConductor.Text))
            {
                MessageBox.Show("Por favor indique el conductor.");
                return;
            }
            if (String.IsNullOrEmpty(comboVehiculo.Text))
            {
                MessageBox.Show("Por favor indique el vehículo.");
                return;
            }

            XDocument misPasajerosString = new XDocument();
            SerializeParams(misPasajerosString, misPasajeros);

            cmd = CapaDatos.CapaDatos.crearComando();
            cmd.Parameters.Clear();
            cmd.CommandText = "INSERT INTO itinerarios (fecha_solicitud, nombre_solicitante, apellido_solicitante, responsable_actividad, cedula_responsable, descripcion_actividad, sitio_salida, sitio_destino, fecha_salida, fecha_llegada, pasajeros, facultades_id, usuarios_id_conductor, vehiculos_id, observaciones) VALUES (@fecha_solicitud, @nombre_solicitante, @apellido_solicitante, @responsable_actividad, @cedula_responsable, @descripcion_actividad, @sitio_salida, @sitio_destino, @fecha_salida, @fecha_llegada, @pasajeros, @facultades_id, @usuarios_id_conductor, @vehiculos_id, @observaciones)";

            cmd.Parameters.AddWithValue("@fecha_solicitud", dateFechaSolicitud.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@nombre_solicitante", textNombreSolicitante.Text);
            cmd.Parameters.AddWithValue("@apellido_solicitante", textApellidoSolicitante.Text);
            cmd.Parameters.AddWithValue("@responsable_actividad", textResponsableActividad.Text);
            cmd.Parameters.AddWithValue("@cedula_responsable", textDocumentoResponsable.Text);
            cmd.Parameters.AddWithValue("@descripcion_actividad", textDescripcionActividad.Text);
            cmd.Parameters.AddWithValue("@sitio_salida", textSitioSalida.Text);
            cmd.Parameters.AddWithValue("@sitio_destino", textSitioLlegada.Text);
            cmd.Parameters.AddWithValue("@fecha_salida", dateFechaSalida.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@fecha_llegada", dateFechaLlegada.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@pasajeros", misPasajerosString.ToString());
            cmd.Parameters.AddWithValue("@facultades_id", comboFacultad.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@usuarios_id_conductor", comboConductor.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@vehiculos_id", comboVehiculo.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@observaciones", textObservaciones.Text);

            if (CapaDatos.CapaDatos.ejecutarComando(cmd))
            {
                CargarItinerarios();
                MessageBox.Show("Se ha almacenado correctamente el itinerario.");
                return;
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error al almacenar el itinerario.");
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                dataItinerarios["id", dataItinerarios.CurrentRow.Index].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Por favor indique el itinerario que desea eliminar.");
            }

            cmd = CapaDatos.CapaDatos.crearComando();
            cmd.CommandText = "DELETE FROM itinerarios WHERE id = @id";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", dataItinerarios["id", dataItinerarios.CurrentRow.Index].Value.ToString());

            if (CapaDatos.CapaDatos.ejecutarComando(cmd))
            {
                CargarItinerarios();
                MessageBox.Show("Se ha eliminado correctamente el itinerario");
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error al eliminar el itinerario");
            }
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            if (dataPasajeros.Rows.Count == 0)
            {
                MessageBox.Show("Debe indicar al menos 1 pasajero");
                return;
            }

            if (String.IsNullOrEmpty(textNombreSolicitante.Text))
            {
                MessageBox.Show("Por favor indique el nombre del solicitante.");
                return;
            }

            if (String.IsNullOrEmpty(textApellidoSolicitante.Text))
            {
                MessageBox.Show("Por favor indique el apellido del solicitante.");
                return;
            }
            if (String.IsNullOrEmpty(textResponsableActividad.Text))
            {
                MessageBox.Show("Por favor indique el responsable de la actividad.");
                return;
            }
            if (String.IsNullOrEmpty(textDocumentoResponsable.Text))
            {
                MessageBox.Show("Por favor indique el documento del responsable.");
                return;
            }
            if (String.IsNullOrEmpty(textDescripcionActividad.Text))
            {
                MessageBox.Show("Por favor indique la descripción de la actividad.");
                return;
            }
            if (String.IsNullOrEmpty(textSitioSalida.Text))
            {
                MessageBox.Show("Por favor indique el sitio de salida.");
                return;
            }
            if (String.IsNullOrEmpty(textSitioLlegada.Text))
            {
                MessageBox.Show("Por favor indique el sitio de llegada.");
                return;
            }

            if (String.IsNullOrEmpty(comboFacultad.Text))
            {
                MessageBox.Show("Por favor indique la facultad.");
                return;
            }
            if (String.IsNullOrEmpty(comboConductor.Text))
            {
                MessageBox.Show("Por favor indique el conductor.");
                return;
            }
            if (String.IsNullOrEmpty(comboVehiculo.Text))
            {
                MessageBox.Show("Por favor indique el vehículo.");
                return;
            }

            try
            {
                dataItinerarios["id", dataItinerarios.CurrentRow.Index].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Por favor indique el itinerario que desea modificar.");
                return;
            }

            XDocument misPasajerosString = new XDocument();
            SerializeParams(misPasajerosString, misPasajeros);

            cmd = CapaDatos.CapaDatos.crearComando();
            cmd.Parameters.Clear();
            cmd.CommandText = "UPDATE itinerarios SET observaciones = @observaciones, fecha_solicitud = @fecha_solicitud, nombre_solicitante = @nombre_solicitante, apellido_solicitante = @apellido_solicitante, responsable_actividad = @responsable_actividad, cedula_responsable = @cedula_responsable, descripcion_actividad = @descripcion_actividad, sitio_salida = @sitio_salida, sitio_destino = @sitio_destino, fecha_salida = @fecha_salida, fecha_llegada = @fecha_llegada, pasajeros = @pasajeros, facultades_id = @facultades_id, usuarios_id_conductor = @usuarios_id_conductor, vehiculos_id = @vehiculos_id WHERE id = @id";

            cmd.Parameters.AddWithValue("@id", dataItinerarios["id", dataItinerarios.CurrentRow.Index].Value.ToString());
            cmd.Parameters.AddWithValue("@fecha_solicitud", dateFechaSolicitud.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@nombre_solicitante", textNombreSolicitante.Text);
            cmd.Parameters.AddWithValue("@apellido_solicitante", textApellidoSolicitante.Text);
            cmd.Parameters.AddWithValue("@responsable_actividad", textResponsableActividad.Text);
            cmd.Parameters.AddWithValue("@cedula_responsable", textDocumentoResponsable.Text);
            cmd.Parameters.AddWithValue("@descripcion_actividad", textDescripcionActividad.Text);
            cmd.Parameters.AddWithValue("@sitio_salida", textSitioSalida.Text);
            cmd.Parameters.AddWithValue("@sitio_destino", textSitioLlegada.Text);
            cmd.Parameters.AddWithValue("@fecha_salida", dateFechaSalida.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@fecha_llegada", dateFechaLlegada.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@pasajeros", misPasajerosString.ToString());
            cmd.Parameters.AddWithValue("@facultades_id", comboFacultad.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@usuarios_id_conductor", comboConductor.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@vehiculos_id", comboVehiculo.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@observaciones", textObservaciones.Text);

            if (CapaDatos.CapaDatos.ejecutarComando(cmd))
            {
                CargarItinerarios();
                MessageBox.Show("Se ha almacenado correctamente el itinerario.");
                return;
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error al almacenar el itinerario.");
            }
        }

        private void dataItinerarios_Click(object sender, EventArgs e)
        {
            try
            {
                dataPasajeros.DataSource = null;
                dateFechaSolicitud.Value = Convert.ToDateTime(dataItinerarios["fecha_solicitud", dataItinerarios.CurrentRow.Index].Value.ToString());
                textNombreSolicitante.Text = dataItinerarios["nombre_solicitante", dataItinerarios.CurrentRow.Index].Value.ToString();
                textApellidoSolicitante.Text = dataItinerarios["apellido_solicitante", dataItinerarios.CurrentRow.Index].Value.ToString();
                textResponsableActividad.Text = dataItinerarios["responsable_actividad", dataItinerarios.CurrentRow.Index].Value.ToString();
                textDocumentoResponsable.Text = dataItinerarios["cedula_responsable", dataItinerarios.CurrentRow.Index].Value.ToString();
                textDescripcionActividad.Text = dataItinerarios["descripcion_actividad", dataItinerarios.CurrentRow.Index].Value.ToString();
                textSitioSalida.Text = dataItinerarios["sitio_salida", dataItinerarios.CurrentRow.Index].Value.ToString();
                textSitioLlegada.Text = dataItinerarios["sitio_destino", dataItinerarios.CurrentRow.Index].Value.ToString();
                dateFechaSalida.Value = Convert.ToDateTime(dataItinerarios["fecha_salida", dataItinerarios.CurrentRow.Index].Value.ToString());
                dateFechaLlegada.Value = Convert.ToDateTime(dataItinerarios["fecha_llegada", dataItinerarios.CurrentRow.Index].Value.ToString());
                
                string misPasajerosString  = @dataItinerarios["pasajeros", dataItinerarios.CurrentRow.Index].Value.ToString();
                XDocument doc = XDocument.Parse(misPasajerosString);
                misPasajeros = DeserializeParams<CapaDatos.Pasajero>(doc);
                dataPasajeros.DataSource = misPasajeros;

                comboFacultad.SelectedValue = dataItinerarios["facultades_id", dataItinerarios.CurrentRow.Index].Value.ToString();
                comboConductor.SelectedValue = dataItinerarios["usuarios_id_conductor", dataItinerarios.CurrentRow.Index].Value.ToString();
                comboVehiculo.SelectedValue = dataItinerarios["vehiculos_id", dataItinerarios.CurrentRow.Index].Value.ToString();
                textObservaciones.Text = dataItinerarios["observaciones", dataItinerarios.CurrentRow.Index].Value.ToString();
            }
            catch
            {

            }
        }
    }
}
