using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using MySql.Data.MySqlClient;
using Prj_Capa_Entidad;
using System.Windows.Forms;

namespace Prj_Capa_Datos
{
   public  class BD_usuario : Cls_Conexion 
    {

        public DataTable BD_Listar_Usuarios()
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = Conectar();

            try
            {
                cn.Open();

                // Crea un objeto MySqlCommand con la consulta SQL y la conexión
                MySqlCommand query = new MySqlCommand("SELECT * FROM usuarios", cn);

                // Crea un objeto DataTable para almacenar el resultado
                DataTable listaUsuarios = new DataTable();

                // Crea un adaptador de datos para ejecutar la consulta y llenar el DataTable
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query);
                dataAdapter.Fill(listaUsuarios);

                return listaUsuarios;

                cn.Close();

            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error en Listar Usuarios" + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return null;
            }

        }


    }
}
