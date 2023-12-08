using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Prj_Capa_Entidad;



namespace Prj_Capa_Datos
{
  public class BD_Personal : Cls_Conexion
    {

        public void BD_Registrar_Personal(EN_Persona per)
        {
            MySqlConnection cn = new MySqlConnection();
            
            try
            {
                cn.ConnectionString = Conectar();
                MySqlCommand cmd = new MySqlCommand("Sp_Registrar_Clientes", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType= CommandType.StoredProcedure;

                //Parametros
                cmd.Parameters.AddWithValue("_Id_Cliente", per.IdCliente);
                cmd.Parameters.AddWithValue("_nombreCompleto", per.NombreCompleto);
                cmd.Parameters.AddWithValue("_edad", per.Edad);
                cmd.Parameters.AddWithValue("_fechaNaci", per.fechaNacimi);
                cmd.Parameters.AddWithValue("_direccion", per.Direccion);
                cmd.Parameters.AddWithValue("_Correo", per.Correo);
                cmd.Parameters.AddWithValue("_Celular", per.Celular);
                cmd.Parameters.AddWithValue("_tipoMembre", per.TipoMembresia);
                cmd.Parameters.AddWithValue("_fechaInicio", per.Fechainicio);
                cmd.Parameters.AddWithValue("_fechaCorte", per.Fechacorte);
                cmd.Parameters.AddWithValue("_metodoPago",per.Metodopago);
                cmd.Parameters.AddWithValue("_Foto", per.xImagen);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex) 
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Hay problemas: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            
            }
        }


        public void BD_actualizar_Personal(EN_Persona per)
        {
            MySqlConnection cn = new MySqlConnection();

            try
            {
                cn.ConnectionString = Conectar();
                MySqlCommand cmd = new MySqlCommand("Sp_Actualizar_Clientes", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;

                //Parametros
               cmd.Parameters.AddWithValue("_Id_cliente", per.IdCliente);
                cmd.Parameters.AddWithValue("_nombreCompleto", per.NombreCompleto);
                cmd.Parameters.AddWithValue("_edad", per.Edad);
                cmd.Parameters.AddWithValue("_fechaNaci", per.fechaNacimi);
                cmd.Parameters.AddWithValue("_direccion", per.Direccion);
                cmd.Parameters.AddWithValue("_correo", per.Correo);
                cmd.Parameters.AddWithValue("_celular", per.Celular);
                cmd.Parameters.AddWithValue("_tipoMembre", per.TipoMembresia);
                cmd.Parameters.AddWithValue("_FecInicio", per.Fechainicio);
                cmd.Parameters.AddWithValue("_FecCorte", per.Fechacorte);
                cmd.Parameters.AddWithValue("_metodoPago", per.Metodopago);
                cmd.Parameters.AddWithValue("_foto", per.xImagen);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Hay problemas: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        public static bool xhuella = false;

        public void BD_Registrar_Huella_Personal(string idper, object huella)
        {
            MySqlConnection cn = new MySqlConnection();

            try
            {
                cn.ConnectionString = Conectar();
                MySqlCommand cmd = new MySqlCommand("Sp_registroHuellas", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                cmd.Parameters.AddWithValue("xidcliente", idper);
                cmd.Parameters.AddWithValue("xhuellaclient", huella);
                

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                xhuella = true;
            }
            catch (Exception ex)
            {
                xhuella = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Hay problemas: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        public DataTable BD_Lista_Todo_personal()
        { 
            MySqlConnection cn = new MySqlConnection(Conectar());
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("Sp_Listar_Todo_Clientes", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dato = new DataTable();

                da.Fill(dato);
                return dato;
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }

                MessageBox.Show("Error BD Personal" + ex.Message, "Listar todo persona", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        public DataTable BD_Buscar_personal_porValor(string valor)
        {
            MySqlConnection cn = new MySqlConnection(Conectar());
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("Sp_Buscar_Cliente_porValor", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("_valor", valor);
                DataTable dato = new DataTable();

                da.Fill(dato);
                return dato;
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }

                MessageBox.Show("Error BD Personal" + ex.Message, "Listar todo persona", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }


        public void BD_Eliminar_Personal(string idper)
        {
            MySqlConnection cn = new MySqlConnection();

            try
            {
                cn.ConnectionString = Conectar();
                MySqlCommand cmd = new MySqlCommand("Sp_eliminarCliente", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                cmd.Parameters.AddWithValue("_idcliente", idper);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Usuario "+idper+" eliminado satisfactoriamente");

            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Hay problemas al eliminar: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        public void PruebaConexion() {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = Conectar();

            try
            {
                cn.Open();
                Console.WriteLine("Conexión exitosa a la base de datos.");
                MessageBox.Show("Conexión exitosa a la base de datos.");


                string query = "SELECT * FROM tipodoc";

                // Crea un objeto MySqlCommand y asigna la consulta y la conexión
                MySqlCommand command = new MySqlCommand(query, cn);

                // Crea un objeto MySqlDataReader para leer los datos de la tabla
                MySqlDataReader reader = command.ExecuteReader();

                // Itera sobre los resultados y muestra los datos en la consola
                while (reader.Read())
                {
                    // Accede a los datos de cada columna por su nombre o índice
                    int id = reader.GetInt32("IdTipo");
                    string nombre = reader.GetString("nombreTipo");
                    string serie = reader.GetString("serie");
                    string numero = reader.GetString("Numero_T");

                    Console.WriteLine($"ID: {id}, Nombre: {nombre}, serie: {serie}, numero: {numero}");
                }

                // Cierra el lector de datos
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al establecer la conexión: " + ex.Message);
                MessageBox.Show("Error al establecer la conexión: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }


    }
}
