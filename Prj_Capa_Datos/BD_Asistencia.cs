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
 public class BD_Asistencia : Cls_Conexion
    {

        public static bool entrada = false;

        public void BD_registrar_entrada(EN_Asistencia asi) 
        {
            MySqlConnection cn = new MySqlConnection(Conectar());
            MySqlCommand cmd = new MySqlCommand("sp_registrar_Entrada", cn);
            try
            {
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                cmd.Parameters.AddWithValue("xId_asis", asi.IdAsistencia);
                cmd.Parameters.AddWithValue("xId_Cliente", asi.IdCliente);
                cmd.Parameters.AddWithValue("xNombre_dia", asi.NombreDia);
                cmd.Parameters.AddWithValue("xHoIngreso", asi.HoraIngre);
                cmd.Parameters.AddWithValue("xfechaCorte", asi.FechaCorte);
               
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                entrada=true;
            }
            catch (Exception ex)
            {
                entrada = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Hay problemas en...Registrar Entradaa:"+asi.IdAsistencia +":" + ex.Message, "Marcar Entrada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
            }
        }

        //Entrada: en el mimso dia
        public bool BD_Verificar_si_Cliente_YaMarco_su_Asistencia(string idper) 
        {
            bool retornocarro = false;
            Int32 resultado = 0;

            MySqlConnection cn = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();

            cn.ConnectionString = Conectar();

            cmd.CommandText = "sp_verificar_si_Cliente_YaMarco_su_Asistencia";
            cmd.Connection = cn;
            cmd.CommandTimeout = 20;
            cmd.CommandType = CommandType.StoredProcedure;

            //parametros
            cmd.Parameters.AddWithValue("xidcliente", idper);

            try
            {
                cn.Open();
                //0=falso
                //>=1 verdaero
                resultado = Convert.ToInt32(cmd.ExecuteScalar());
                if (resultado > 0)
                {
                    retornocarro = true;
                }
                else
                {
                    retornocarro = false;
                }

                cmd.Parameters.Clear();
                cmd.Dispose();
                cmd = null;
                cn.Close();
                cn = null;

            }
            catch (Exception ex)
            {
                entrada = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Hay problemas Verificar Asistencia:" + ex.Message, "Verificar Asistencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            return retornocarro;
            
        }
            

        public bool BD_Verificar_si_Cliente_YaMarco_su_Entrada(string idper)
        {
            bool retornocarro = false;
            Int32 resultado = 0;

            MySqlConnection cn = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();

            cn.ConnectionString = Conectar();

            cmd.CommandText = "sp_verificar_si_Cliente_YaMarco_su_Entrada";
            cmd.Connection = cn;
            cmd.CommandTimeout = 20;
            cmd.CommandType = CommandType.StoredProcedure;

            //parametros
            cmd.Parameters.AddWithValue("xidcliente", idper);

            try
            {
                cn.Open();
                //0=falso
                //>=1 verdaero
                resultado = Convert.ToInt32(cmd.ExecuteScalar());
                if (resultado > 0)
                {
                    retornocarro = true;
                }
                else
                {
                    retornocarro = false;
                }

                cmd.Parameters.Clear();
                cmd.Dispose();
                cmd = null;
                cn.Close();
                cn = null;

            }
            catch (Exception ex)
            {
                entrada = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Hay problemas Verificar_Entrada:" + ex.Message, "Verificar Entrada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            return retornocarro;

        }

        public DataTable BD_Listar_Todas_Asistencias() 
        {
            MySqlConnection cn = new MySqlConnection();
            try 
            {
                cn.ConnectionString = Conectar();
                MySqlDataAdapter da = new MySqlDataAdapter("sp_listar_Todas_Asistencias", cn);
                da.SelectCommand.CommandType=CommandType.StoredProcedure;

                DataTable Dato = new DataTable();

                da.Fill(Dato);
                da = null;
                return Dato;
            }
            catch (Exception ex)
            {
                entrada = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Hay problemas Listar Visitas:" + ex.Message, "Verificar Entrada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            return null;
        }

        public DataTable BD_Buscar_Asistencia_porValor(string valor)
        {
            MySqlConnection cn = new MySqlConnection(Conectar());
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("Sp_Buscar_Asistencia_porValor", cn);
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

                MessageBox.Show("Error BD Asistencia Buscar" + ex.Message, "Listar todo persona", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        public DataTable BD_Buscar_Asistencia_porNombre(string valor)
        {
            MySqlConnection cn = new MySqlConnection(Conectar());
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("Sp_Buscar_Asistencia_porNombre", cn);
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

                MessageBox.Show("Error BD Asistencia Nombre" + ex.Message, "Listar todo persona", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        public DataTable BD_Listar_numero_Visitas_por_cliente(string valor)
        {
            MySqlConnection cn = new MySqlConnection(Conectar());
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("sp_listar_visitas_anuales", cn);
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

                MessageBox.Show("Error BD Asistencia -" + ex.Message, "Listar Numero de visitas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        public DataTable BD_Meses_Pagados(string valor)
        {
            MySqlConnection cn = new MySqlConnection(Conectar());
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("sp_listar_meses_pagados", cn);
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

                MessageBox.Show("Error BD Asistencia -" + ex.Message, "Listar Meses Pagados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }


        public DataTable BD_Listar_Visitar_x_Mes()
        {
            MySqlConnection cn = new MySqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                MySqlDataAdapter da = new MySqlDataAdapter("sp_listar_visitas_x_mes", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable Dato = new DataTable();

                da.Fill(Dato);
                da = null;
                return Dato;
            }
            catch (Exception ex)
            {
                entrada = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Hay problemas visitas por mes:" + ex.Message, "Verificar Entrada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            return null;
        }



        public DataTable BD_Listar_Visitar_x_Semana()
        {
            MySqlConnection cn = new MySqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                MySqlDataAdapter da = new MySqlDataAdapter("sp_listar_visitas_x_semana", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable Dato = new DataTable();

                da.Fill(Dato);
                da = null;
                return Dato;
            }
            catch (Exception ex)
            {
                entrada = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Hay problemas visitas por semana:" + ex.Message, "Verificar Entrada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            return null;
        }


        public DataTable BD_Listar_Visitar_x_Dia()
        {
            MySqlConnection cn = new MySqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                MySqlDataAdapter da = new MySqlDataAdapter("sp_listar_visitas_x_dia", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable Dato = new DataTable();

                da.Fill(Dato);
                da = null;
                return Dato;
            }
            catch (Exception ex)
            {
                entrada = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Hay problemas visitas por Dia:" + ex.Message, "Verificar Entrada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            return null;
        }


    }
}
