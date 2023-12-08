using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Prj_Capa_Datos
{
     public class BD_Utilitario : Cls_Conexion
    {

        public static string BD_NroDoc(int idtipo) 
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = Conectar2();

            try
            {
                cn.Open();

                string query = "SELECT Serie, Numero_T FROM tipodoc WHERE IdTipo = @IdTipo";
                MySqlCommand command = new MySqlCommand(query, cn);
                command.Parameters.AddWithValue("@IdTipo", idtipo);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    // Accede a los datos de cada columna por su nombre o índice
                    string NumeroDoc = reader.GetString("Serie") +"-"+ reader.GetString("Numero_T");

                    Console.WriteLine(NumeroDoc);

                    return NumeroDoc;
                }

                reader.Close();
                cn.Close();

            }
            catch (Exception ex) 
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error 2021" + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return "";
        
        }

        public static void BD_ActualizarNro(int idtipo, string numero) 
        {
            MySqlConnection cn = new MySqlConnection(Conectar2());
    
            try
            {
                cn.Open();

                MySqlCommand command = new MySqlCommand("UPDATE tipodoc SET Numero_T = @nuevoNumero WHERE IdTipo = @id", cn);

                // Asigna los valores a los parámetros de la consulta
                command.Parameters.AddWithValue("@nuevoNumero", numero);
                command.Parameters.AddWithValue("@id", idtipo);

                // Ejecuta la consulta
                int rowsAffected = command.ExecuteNonQuery();

                cn.Close();
            }

            catch (Exception ex) 
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error En actualizar consecutivo:" + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        public static string BD_Leer_Solo_Numero(int idtipo) 
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = Conectar2();

            try 
            {
                cn.Open();

                string query = "SELECT Numero_T FROM tipodoc WHERE IdTipo = @IdTipo";
                MySqlCommand command = new MySqlCommand(query, cn);
                command.Parameters.AddWithValue("@IdTipo", idtipo);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    // Accede a los datos de cada columna por su nombre o índice
                    string NumeroX = reader.GetString("Numero_T");

                    Console.WriteLine(NumeroX);

                    return NumeroX;
                }

                reader.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error 2021" + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return "";
        }

      




    }
}
