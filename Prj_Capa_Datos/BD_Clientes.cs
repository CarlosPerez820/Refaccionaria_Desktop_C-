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
using System.ComponentModel;
using System.Security.Cryptography;

namespace Prj_Capa_Datos
{
    public class BD_Clientes: Cls_Conexion
    {

        public void BD_Registrar_Clientes(EN_Cliente cli)
        {
            MySqlConnection cn = new MySqlConnection();

            try
            {
                cn.ConnectionString = Conectar();
                cn.Open();

                string query = "INSERT INTO Clientes (Id_cliente, nombre_completo, direccion, telefono, limite_credito) VALUES (@Id_cliente,@nombre_completo,@direccion,@telefono,@limite_credito)";

                using (MySqlCommand command = new MySqlCommand(query, cn))
                {
                    command.Parameters.AddWithValue("@Id_cliente", cli.IDCliente); 
                    command.Parameters.AddWithValue("@nombre_completo", cli.NombreCompleto);
                    command.Parameters.AddWithValue("@direccion", cli.Direccion);
                    command.Parameters.AddWithValue("@telefono", cli.Telefono);
                    command.Parameters.AddWithValue("@limite_credito", cli.Credito);

                    command.ExecuteNonQuery();
                }


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

        public DataTable BD_Listar_Cliente()
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = Conectar();

            try
            {
                cn.Open();

                // Crea un objeto MySqlCommand con la consulta SQL y la conexión
                MySqlCommand query = new MySqlCommand("SELECT * FROM Clientes", cn);

                // Crea un objeto DataTable para almacenar el resultado
                DataTable listaClientes = new DataTable();

                // Crea un adaptador de datos para ejecutar la consulta y llenar el DataTable
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query);
                dataAdapter.Fill(listaClientes);

                return listaClientes;   

                cn.Close();

            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error en Listar Clientes" + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return null;
            }
            
        }

        public void BD_Editar_Cliente(EN_Cliente cli, string _id) 
        {
            MySqlConnection cn = new MySqlConnection();

            try
            {
                cn.ConnectionString = Conectar();

                string query = "UPDATE Clientes set nombre_completo=@nombre_completo, direccion=@direccion, telefono=@telefono, limite_credito=@limite_credito WHERE Id_cliente = @id;";


                cn.Open();

                using (MySqlCommand command = new MySqlCommand(query, cn))
                {
                    command.Parameters.AddWithValue("@id", _id);
                    command.Parameters.AddWithValue("@nombre_completo", cli.NombreCompleto);
                    command.Parameters.AddWithValue("@direccion", cli.Direccion);
                    command.Parameters.AddWithValue("@telefono", cli.Telefono);
                    command.Parameters.AddWithValue("@limite_credito", cli.Credito);


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

        public void BD_Eliminar_Cliente(string id)
        {
            MySqlConnection cn = new MySqlConnection();

            try
            {
                cn.ConnectionString = Conectar();

                string query = "DELETE FROM Clientes WHERE Id_cliente = @id";

                cn.Open();

                using (MySqlCommand command = new MySqlCommand(query, cn))
                {
                    command.Parameters.AddWithValue("@id", id);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("El registro fue eliminado exitosamente.");
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ningún registro para eliminar.");
                    }
                }

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

        public void BD_Buscar_Cliente(string valor)
        {

        }

        public DataTable BD_Buscar_Cliente_porValor(string valor)
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = Conectar();

            try
            {
                cn.Open();
                string query = "SELECT * FROM Clientes WHERE Id_cliente=@id";

                using (MySqlCommand command = new MySqlCommand(query, cn))
                {
                    command.Parameters.AddWithValue("@id", valor);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        return dataTable;
                    }
                }

                cn.Close();

            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al buscar Producto" + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return null;
            }
        }
    }
}
