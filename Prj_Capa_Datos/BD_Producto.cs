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
using System.Collections;
using System.Security.Cryptography;

namespace Prj_Capa_Datos
{
     public class BD_Producto : Cls_Conexion
    {
        public void BD_Registrar_Producto(EN_Producto pro)
        {
            MySqlConnection cn = new MySqlConnection();

            try
            {
                cn.ConnectionString = Conectar();
                cn.Open();

                string query = "INSERT INTO Productos (codigo, descripcion, tipo, precioCompra, precioVenta, precioMayoreo, precioEspecial, categoria, cantidadActual, cantidadMinima) " +
                    "VALUES (@codigo,@descripcion,@tipo,@precioCompra,@precioVenta,@precioMayoreo,@precioEspecial,@categoria,@cantidadActual,@cantidadMinima)";

                using (MySqlCommand command = new MySqlCommand(query, cn))
                {
                    command.Parameters.AddWithValue("@codigo", pro.Codigo);
                    command.Parameters.AddWithValue("@descripcion", pro.Descripcion);
                    command.Parameters.AddWithValue("@tipo", pro.Tipo);
                    command.Parameters.AddWithValue("@precioCompra", pro.PrecioCompra);
                    command.Parameters.AddWithValue("@precioVenta", pro.PrecioVenta);
                    command.Parameters.AddWithValue("@precioMayoreo", pro.PrecioMayoreo);
                    command.Parameters.AddWithValue("@precioEspecial", pro.PrecioEspecial);
                    command.Parameters.AddWithValue("@categoria", pro.Categoria);
                    command.Parameters.AddWithValue("@cantidadActual", pro.CantidadActual);
                    command.Parameters.AddWithValue("@cantidadMinima", pro.CantidadMinima);

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
                MessageBox.Show("Hay problemas con Productos-Registro: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }



        public DataTable BD_Lista_Todo_Producto()
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = Conectar();

            try
            {
                cn.Open();
                MySqlCommand query = new MySqlCommand("SELECT * FROM Productos", cn);

                DataTable listaProductos = new DataTable();

                // Crea un adaptador de datos para ejecutar la consulta y llenar el DataTable
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query);
                dataAdapter.Fill(listaProductos);

                return listaProductos;

                cn.Close();

            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error en Listar Productos" + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return null;
            }
        }

        public DataTable BD_Lista_Producto_Bajos()
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = Conectar();

            try
            {
                cn.Open();
                MySqlCommand query = new MySqlCommand("select * from Productos where cantidadActual < cantidadMinima", cn);

                DataTable listaProductos = new DataTable();

                // Crea un adaptador de datos para ejecutar la consulta y llenar el DataTable
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query);
                dataAdapter.Fill(listaProductos);

                return listaProductos;

                cn.Close();

            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error en Listar Productos bajos de inventario" + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return null;
            }
        }

        public void BD_Eliminar_Producto(int idpro)
        {
            MySqlConnection cn = new MySqlConnection();

            try
            {
                cn.ConnectionString = Conectar();

                string query = "DELETE FROM Productos WHERE id = @id";

                cn.Open();

                using (MySqlCommand command = new MySqlCommand(query, cn))
                {
                    command.Parameters.AddWithValue("@id", idpro);

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

        public DataTable BD_Buscar_producto_porValor(string valor)
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = Conectar();

            try
            {
                cn.Open();
                string query = "SELECT * FROM Productos WHERE id=@id";

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

        public DataTable BD_Buscar_producto_porValor_Cadena(string valor)
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = Conectar();

            try
            {
                cn.Open();
                string query = "SELECT * FROM Productos WHERE descripcion LIKE CONCAT('%', @valor, '%') or codigo LIKE CONCAT('%', @valor, '%') or categoria LIKE CONCAT('%', @valor, '%')";

                using (MySqlCommand command = new MySqlCommand(query, cn))
                {
                    command.Parameters.AddWithValue("@valor", valor);

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


        public void BD_actualizar_Producto(EN_Producto pro, int _id)
        {
            MySqlConnection cn = new MySqlConnection();

            try
            {
                cn.ConnectionString = Conectar();

                string query = "UPDATE Productos set codigo=@codigo, descripcion=@descripcion, tipo=@tipo, precioCompra=@precioCompra, precioVenta=@precioVenta, precioMayoreo=@precioMayoreo, precioEspecial=@precioEspecial, " +
                    "categoria=@categoria, cantidadActual=@cantidadActual, cantidadMinima=@cantidadMinima WHERE id = @id;";

                
                    cn.Open();

                    using (MySqlCommand command = new MySqlCommand(query, cn))
                    {
                        command.Parameters.AddWithValue("@id", _id);
                        command.Parameters.AddWithValue("@codigo", pro.Codigo);
                        command.Parameters.AddWithValue("@descripcion", pro.Descripcion);
                        command.Parameters.AddWithValue("@tipo", pro.Tipo);
                        command.Parameters.AddWithValue("@precioCompra", pro.PrecioCompra);
                        command.Parameters.AddWithValue("@precioVenta", pro.PrecioVenta);
                        command.Parameters.AddWithValue("@precioMayoreo", pro.PrecioMayoreo);
                        command.Parameters.AddWithValue("@precioEspecial", pro.PrecioEspecial);
                        command.Parameters.AddWithValue("@categoria", pro.Categoria);
                        command.Parameters.AddWithValue("@cantidadActual", pro.CantidadActual);
                        command.Parameters.AddWithValue("@cantidadMinima", pro.CantidadMinima);

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




        public void BD_actualizar_Cantidad(int _id, int _cantidad)
        {
            MySqlConnection cn = new MySqlConnection();

            try
            {
                cn.ConnectionString = Conectar();

                string query = "UPDATE Productos set cantidadActual=@cantidadActual WHERE id = @id;";

                cn.Open();

                using (MySqlCommand command = new MySqlCommand(query, cn))
                {
                    command.Parameters.AddWithValue("@id", _id);
                    command.Parameters.AddWithValue("@cantidadActual", _cantidad);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("La fila fue actualizada exitosamente.");
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


        public void BD_actualizar_CantidadDevolucion(int _id, int _cantidad)
        {
            MySqlConnection cn = new MySqlConnection();

            try
            {
                cn.ConnectionString = Conectar();

                string query = "UPDATE Productos set cantidadActual=cantidadActual+@cantidad WHERE id = @id;";

                cn.Open();

                using (MySqlCommand command = new MySqlCommand(query, cn))
                {
                    command.Parameters.AddWithValue("@id", _id);
                    command.Parameters.AddWithValue("@cantidad", _cantidad);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("La fila fue actualizada exitosamente.");
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



        public DataTable BD_Buscar_cantidad_Producto(string valor)
        {
            MySqlConnection cn = new MySqlConnection(Conectar());
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("Sp_Listar_cantidad", cn);
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

                MessageBox.Show("Error BD Producto" + ex.Message, "Listar cantidad ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }



    }
}
