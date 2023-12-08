using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using Prj_Capa_Entidad;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Prj_Capa_Datos
{
    public class BD_Gastos : Cls_Conexion
    {
        public void BD_Registrar_Gasto(EN_Gastos gas)
        {
            MySqlConnection cn = new MySqlConnection();

            try
            {
                cn.ConnectionString = Conectar();
                cn.Open();

                string query = "INSERT INTO Gastos (fecha, descripcion, monto) VALUES (@fecha, @descripcion, @monto)";

                using (MySqlCommand command = new MySqlCommand(query, cn))
                {
                    command.Parameters.AddWithValue("@fecha", gas.fecha);
                    command.Parameters.AddWithValue("@descripcion", gas.descripcion);
                    command.Parameters.AddWithValue("@monto", gas.monto);

                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Gasto/Compra Registrada exitosamente");
                cn.Close();
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Hay problemas en registrar Gasto: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        public DataTable BD_Listar_Gastos()
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = Conectar();

            try
            {
                cn.Open();

                // Crea un objeto MySqlCommand con la consulta SQL y la conexión
                MySqlCommand query = new MySqlCommand("SELECT * FROM Gastos", cn);

                // Crea un objeto DataTable para almacenar el resultado
                DataTable listaGastos = new DataTable();

                // Crea un adaptador de datos para ejecutar la consulta y llenar el DataTable
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query);
                dataAdapter.Fill(listaGastos);

                return listaGastos;

                cn.Close();

            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error en Listar Gastos" + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return null;
            }

        }


        public DataTable BD_Listar_Gastos_Mes()
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = Conectar();

            try
            {
                cn.Open();

                // Crea un objeto MySqlCommand con la consulta SQL y la conexión
                MySqlCommand query = new MySqlCommand("SELECT * FROM Gastos WHERE MONTH(fecha) = MONTH(CURRENT_DATE()) AND YEAR(fecha) = YEAR(CURRENT_DATE())", cn);

                // Crea un objeto DataTable para almacenar el resultado
                DataTable listaGastos = new DataTable();

                // Crea un adaptador de datos para ejecutar la consulta y llenar el DataTable
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query);
                dataAdapter.Fill(listaGastos);

                return listaGastos;

                cn.Close();

            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error en Listar Gastos" + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return null;
            }

        }



        public void BD_Editar_Gastos(EN_Gastos gas, int _id)
        {
            MySqlConnection cn = new MySqlConnection();

            try
            {
                cn.ConnectionString = Conectar();

                string query = "UPDATE Gastos set fecha=@fecha, descripcion=@descripcion, monto=@monto WHERE id = @id;";


                cn.Open();

                using (MySqlCommand command = new MySqlCommand(query, cn))
                {
                    command.Parameters.AddWithValue("@id", _id);
                    command.Parameters.AddWithValue("@fecha", gas.fecha);
                    command.Parameters.AddWithValue("@descripcion", gas.descripcion);
                    command.Parameters.AddWithValue("@monto", gas.monto);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("La fila fue actualizada exitosamente.");
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ninguna fila para actualizar.");
                    }

                    cn.Close();
                }
            }


            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                Console.WriteLine("Hay problemas en Actualizar: " + ex.Message);
                MessageBox.Show("Hay problemas en Actualizar: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

    }
    }
