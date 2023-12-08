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
    public class BD_Ventas: Cls_Conexion
    {
        public void BD_registrar_Venta(EN_Ventas ven)
        {
            {
                MySqlConnection cn = new MySqlConnection();

                try
                {
                    cn.ConnectionString = Conectar();
                    cn.Open();

                    string query = "INSERT INTO Ventas (folioVenta, fechaVenta, horaVenta, formaPago, cliente, idProducto, codigoProducto, descripcionProducto, " +
                        "tipoProducto, nota, cantidadProducto, precioVenta, precioFinal, importeProducto, subTotal, porcentajeDescuento, totalVenta, estatus) " +
                        "VALUES (@folioVenta, @fechaVenta, @horaVenta, @formaPago, @cliente, @idProducto, @codigoProducto, @descripcionProducto," +
                        "@tipoProducto, @nota, @cantidadProducto, @precioVenta, @precioFinal, @importeProducto, @subTotal, @porcentajeDescuento, @totalVenta, @estatus)";

                    using (MySqlCommand command = new MySqlCommand(query, cn))
                    {
                        command.Parameters.AddWithValue("@folioVenta", ven.FolioVenta);
                        command.Parameters.AddWithValue("@fechaVenta", ven.FechaVenta);
                        command.Parameters.AddWithValue("@horaVenta", ven.HoraVenta);
                        command.Parameters.AddWithValue("@formaPago", ven.FormaPago);
                        command.Parameters.AddWithValue("@cliente", ven.Cliente);
                        command.Parameters.AddWithValue("@idProducto", ven.idProducto);
                        command.Parameters.AddWithValue("@codigoProducto", ven.CodigoProducto);
                        command.Parameters.AddWithValue("@descripcionProducto", ven.DescripcionProducto);
                        command.Parameters.AddWithValue("@tipoProducto", ven.TipoProducto);
                        command.Parameters.AddWithValue("@nota", ven.Nota);
                        command.Parameters.AddWithValue("@cantidadProducto", ven.CantidadProducto);
                        command.Parameters.AddWithValue("@precioVenta", ven.PrecioVenta);
                        command.Parameters.AddWithValue("@precioFinal", ven.PrecioFinal);
                        command.Parameters.AddWithValue("@importeProducto", ven.ImporteProducto);
                        command.Parameters.AddWithValue("@subTotal", ven.SubTotal);
                        command.Parameters.AddWithValue("@porcentajeDescuento", ven.PorcentajeDescuento);
                        command.Parameters.AddWithValue("@totalVenta", ven.TotalVenta);
                        command.Parameters.AddWithValue("@estatus", ven.Estatus);

                        command.ExecuteNonQuery();
                    }

                    //MessageBox.Show("Venta: " + ven.FolioVenta + " Registrada ");

                    cn.Close();
                }
                catch (Exception ex)
                {
                    if (cn.State == ConnectionState.Open)
                    {
                        cn.Close();
                    }
                    MessageBox.Show("Hay problemas con Ventas-Registro: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
        }



        public DataTable BD_Buscar_Venta_porFolio(string valor)
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = Conectar();

            try
            {
                cn.Open();
                string query = "SELECT * FROM Ventas WHERE folioVenta=@folio and estatus!=@tipo";

                using (MySqlCommand command = new MySqlCommand(query, cn))
                {
                    command.Parameters.AddWithValue("@folio", valor);
                    command.Parameters.AddWithValue("@tipo", "Devolucion");

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
                MessageBox.Show("Error al buscar Venta para Devolucion" + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return null;
            }
        }


        public void BD_actualizar_Estado(string folio, string codigo)
        {
            MySqlConnection cn = new MySqlConnection();

            try
            {
                cn.ConnectionString = Conectar();

                string query = "UPDATE Ventas set estatus=@estatus WHERE folioVenta = @folio and codigoProducto=@codigo;";

                cn.Open();

                using (MySqlCommand command = new MySqlCommand(query, cn))
                {
                    command.Parameters.AddWithValue("@estatus", "Devolucion");
                    command.Parameters.AddWithValue("@folio", folio);
                    command.Parameters.AddWithValue("@codigo", codigo);


                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("La fila fue actualizada exitosamente.");
                        MessageBox.Show("Se concreto la devolucion exitosamente");
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
                MessageBox.Show("Hay problemas en Actualizar Venta: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }


        public DataTable BD_Listar_Devoluciones()
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = Conectar();

            try
            {
                cn.Open();
                string query = "SELECT * FROM Ventas WHERE estatus=@estatus";

                using (MySqlCommand command = new MySqlCommand(query, cn))
                {
                    command.Parameters.AddWithValue("@estatus", "Devolucion");

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
                MessageBox.Show("Error al buscar Devolucion" + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return null;
            }
        }

        public DataTable BD_Buscar_Venta_porDia(string valor)
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = Conectar();

            try
            {
                cn.Open();
                string query = "SELECT * FROM Ventas WHERE fechaVenta=@fecha and formaPago!=@forma";

                using (MySqlCommand command = new MySqlCommand(query, cn))
                {
                    command.Parameters.AddWithValue("@fecha", valor);
                    command.Parameters.AddWithValue("@forma", "Transferencia");

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
                MessageBox.Show("Error al buscar Venta para Fecha" + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return null;
            }


        }

        public DataTable BD_Lista_Ventas_Mes()
        {
            MySqlConnection cn = new MySqlConnection(Conectar());
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("sp_listar_Ventas_Mes", cn);
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

                MessageBox.Show("Error BD Ventas " + ex.Message, "Listar venta MES", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }


        public DataTable BD_Buscar_Venta_Especifica(string valor, string valor2)
        {
            MySqlConnection cn = new MySqlConnection(Conectar());
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("sp_listar_Ventas_especificas", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("_valor", valor);
                da.SelectCommand.Parameters.AddWithValue("_valor2", valor2);
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
                MessageBox.Show("Error BD Ventas BuscarDia" + ex.Message, "Listar Ventas Fechas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        public DataTable BD_Buscar_TodasVenta_porDia(string valor)
        {
            MySqlConnection cn = new MySqlConnection(Conectar());
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("sp_listar_TodasVentas_delDia", cn);
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
                MessageBox.Show("Error BD Ventas BuscarDia" + ex.Message, "Listar toda Venta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        public DataTable BD_Buscar_TodasVenta_porSemana()
        {
            MySqlConnection cn = new MySqlConnection(Conectar());
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("sp_listar_TodasVentas_Semana", cn);
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

                MessageBox.Show("Error BD Ventas " + ex.Message, "Listar venta Semana", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }


        public DataTable BD_Buscar_TodasVenta_porMes()
        {
            MySqlConnection cn = new MySqlConnection(Conectar());
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("sp_listar_TodasVentas_Mes", cn);
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

                MessageBox.Show("Error BD Ventas " + ex.Message, "Listar venta Mes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }


        public DataTable BD_Buscar_TodasVenta_porFechas(string valor, string valor2)
        {
            MySqlConnection cn = new MySqlConnection(Conectar());
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("sp_listar_TodasVentas_Especificas", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("_valor", valor);
                da.SelectCommand.Parameters.AddWithValue("_valor2", valor2);
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
                MessageBox.Show("Error BD Ventas BuscarDia" + ex.Message, "Listar Ventas Fechas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        public DataTable BD_Buscar_Ventas_mes_grafica()
        {
            MySqlConnection cn = new MySqlConnection(Conectar());
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("sp_grafica_mes", cn);
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

                MessageBox.Show("Error BD Ventas " + ex.Message, "Listar grafica  Mes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        public DataTable BD_Buscar_Ventas_semana_grafica()
        {
            MySqlConnection cn = new MySqlConnection(Conectar());
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("sp_grafica_semana", cn);
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

                MessageBox.Show("Error BD Ventas " + ex.Message, "Listar grafica Semana", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }


        public DataTable BD_Buscar_Ventas_dia_grafica()
        {
            MySqlConnection cn = new MySqlConnection(Conectar());
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("sp_grafica_dia", cn);
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

                MessageBox.Show("Error BD Ventas " + ex.Message, "Listar grafica Dia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }



        /*----------------------------------------------------------------------------------------------------------------------------------------------------------------------------0*/
        //              Inicia Bloque para Apartados

        public void BD_nuevo_Apartado(EN_Apartados apart)
        {
            {
                MySqlConnection cn = new MySqlConnection();

                try
                {
                    cn.ConnectionString = Conectar();
                    cn.Open();

                    string query = "INSERT INTO Apartados (folioVenta, fechaVenta, horaVenta, formaPago, cliente, descripcionVenta, " +
                        "totalVenta, cantidadAbonada, fechaUltimoPago, totalRestante, estado) " +
                        "VALUES (@folioVenta, @fechaVenta, @horaVenta, @formaPago, @cliente, @descripcionVenta," +
                        "@totalVenta, @cantidadAbonada, @fechaUltimoPago, @totalRestante, @estado)";

                    using (MySqlCommand command = new MySqlCommand(query, cn))
                    {
                        command.Parameters.AddWithValue("@folioVenta", apart.FolioVenta);
                        command.Parameters.AddWithValue("@fechaVenta", apart.FechaVenta);
                        command.Parameters.AddWithValue("@horaVenta", apart.HoraVenta);
                        command.Parameters.AddWithValue("@formaPago", apart.FormaPago);
                        command.Parameters.AddWithValue("@cliente", apart.Cliente);
                        command.Parameters.AddWithValue("@descripcionVenta", apart.DescripcionVenta);
                        command.Parameters.AddWithValue("@totalVenta", apart.TotalVenta);
                        command.Parameters.AddWithValue("@cantidadAbonada", apart.CantidadAbonada);
                        command.Parameters.AddWithValue("@fechaUltimoPago", apart.FechaUltimoPago);
                        command.Parameters.AddWithValue("@totalRestante", apart.TotalRestante);
                        command.Parameters.AddWithValue("@estado",  apart.Estatus);

                        command.ExecuteNonQuery();
                    }

                    //MessageBox.Show("Venta: " + ven.FolioVenta + " Registrada ");

                    cn.Close();
                }
                catch (Exception ex)
                {
                    if (cn.State == ConnectionState.Open)
                    {
                        cn.Close();
                    }
                    MessageBox.Show("Hay problemas con Apartados-Registro: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
        }


        public DataTable BD_Listar_Apartados( )
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = Conectar();

            try
            {
                cn.Open();
                string query = "SELECT * FROM Apartados WHERE totalRestante>=0";

                using (MySqlCommand command = new MySqlCommand(query, cn))
                {

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
                MessageBox.Show("Error al buscar Venta para Fecha" + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return null;
            }
        }

        public void BD_actualizar_Apartado(double abono, DateTime fecha, double restante, int id)
        {
            MySqlConnection cn = new MySqlConnection();

            try
            {
                cn.ConnectionString = Conectar();

                string query = "UPDATE Apartados set cantidadAbonada=@abono, fechaUltimoPago=@fecha, totalRestante=@restante  WHERE id = @id;";

                cn.Open();

                using (MySqlCommand command = new MySqlCommand(query, cn))
                {
                    command.Parameters.AddWithValue("@abono", abono);
                    command.Parameters.AddWithValue("@fecha", fecha);
                    command.Parameters.AddWithValue("@restante", restante);
                    command.Parameters.AddWithValue("@id", id);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("La fila fue actualizada exitosamente.");
                        MessageBox.Show("Se realizo el abono exitosamente");
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
                Console.WriteLine("Hay problemas en: " + ex.Message);
                MessageBox.Show("Hay problemas en registrar Abono: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }


    }
}