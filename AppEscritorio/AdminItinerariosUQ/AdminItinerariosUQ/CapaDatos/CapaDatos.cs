using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace AdminItinerariosUQ.CapaDatos
{
    class CapaDatos
    {
        public static MySqlCommand comando;
        public static MySqlConnection conexion;
        public static DataTable tabla;

        private static string cadena_conexion = string.Format("server={0};Database={1};Uid={2};Pwd={3};Allow Zero Datetime=True;Convert Zero Datetime=True;", VGlobales.HOST, VGlobales.DATABASE, VGlobales.USUARIO_DB, VGlobales.PASSWORD_DB);

        /// <summary>
        /// Metodo usado para crear un objeto de tipo MysqlCommand, el cual ya posee la conexión creada y esta listo para que le asignen la Query y sus parametros.
        /// </summary>
        /// <returns> Objeto de tipo MysqlCommand </returns>
        public static MySqlCommand crearComando()
        {
            if (conexion == null)
            {
                conexion = new MySqlConnection(cadena_conexion);
            }

            if (comando == null)
            {
                comando = conexion.CreateCommand();
            }
            return comando;
        }

        /// <summary>
        /// Metodo encargado de ejecutar un comando de tipo select
        /// </summary>
        /// <param name="comando"> Comando el cual posee la consulta que se va a efectuar. Junto con sus parametros.</param>
        /// <returns>DataTable con el contenido de la Query.; En caso de error arroja excepción.</returns>
        public static DataTable ejecutarComandoSelect(MySqlCommand cmd)
        {

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                da.Fill(ds, "Table");
            }
            catch (Exception ex)
            {
                //LOGS.LOGGER.crearLog(ex.StackTrace + "\n" + ex.Message);
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return ds.Tables[0];
        }                

        /// <summary>
        /// Metodo usado para ejecutar un comando de tipo INSERT, UPDATE, DELETE. Querys que no retornen resultados.
        /// </summary>
        /// <param name="comando"> Comando el cual posee la consulta que se va a efectuar. Junto con sus parametros.</param>
        /// <returns> True si fue satisfactorio ; False si ocurrió un error.</returns>
        public static bool ejecutarComando(MySqlCommand cmd)
        {
            try
            {
                if (cmd.Connection.State == ConnectionState.Closed)
                {
                    cmd.Connection.Open();
                }
                cmd.ExecuteNonQuery();
                return true;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;

                throw ex;

            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        /// <summary>
        /// Metodo especial para inserciones a la base de datos, en los cuales se requiere obtener el id de la inserción.
        /// </summary>
        /// <param name="comando">Comando con la consulta tipo INSERT</param>
        /// <returns>El id de la inserción</returns>
        public static int ejecutarComandoInsertId(MySqlCommand comando)
        {
            int id = -1;
            try
            {
                if (comando.Connection.State == ConnectionState.Closed)
                {
                    comando.Connection.Open();
                }

                comando.ExecuteNonQuery();
                id = unchecked((int)comando.LastInsertedId);
                return id;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return id;

            }
            finally
            {
                comando.Connection.Close();
            }
        }       
    }
}
