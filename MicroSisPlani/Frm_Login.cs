using MicroSisPlani.Personal;
using Prj_Capa_Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace MicroSisPlani
{
    public partial class Frm_Login : Form
    {
        DataTable dato = new DataTable();

        public Frm_Login()
        {
            InitializeComponent();
        }

        private void Frm_Login_Load(object sender, EventArgs e)
        {
            RN_Usuario obj = new RN_Usuario();
            

            dato = obj.RN_Listar_Usuarios();
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            // Crear una instancia de Stopwatch
           // Stopwatch stopwatch = new Stopwatch();

            // Iniciar el cronómetro
           // stopwatch.Start();

          

            string usuario;
            string pass;

            usuario = txt_usuario.Text;
            pass = txt_pass.Text;

            // MessageBox.Show(usuario + "-"+pass);
            Boolean validacion = false;

            if (dato.Rows.Count>0) 
            {
                foreach (DataRow fila in dato.Rows)
                {
                    string _usuario = (string)fila["usuario"];
                    string _pass = (string)fila["pass"];
                    string _rol = (string)fila["rol"];

                    if (_usuario == usuario) 
                    {
                        if (_pass == pass) 
                        {
                            //MessageBox.Show("Usuario correcto: "+_rol);
                            validacion = true;

                            lbl_cargando.Visible = true;

                            // Ocultar el formulario actual
                            this.Hide();

                            // Mostrar el nuevo formulario
                            //NuevoFormulario nuevoForm = new NuevoFormulario();
                            //nuevoForm.Show();

                            Frm_Principal principal = new Frm_Principal(_rol);
                            principal.ShowDialog();
                            this.Close();
                        }
                    }
                }
            }

            if (validacion==false) 
            {
                MessageBox.Show("Usuario/Contraseña incorrecta");
                txt_usuario.Text = "";
                txt_pass.Text = "";
            }


           // stopwatch.Stop();

            // Obtener el tiempo transcurrido en milisegundos
          //  long tiempoTranscurridoMs = stopwatch.ElapsedMilliseconds;

          //  Console.WriteLine($"Tiempo transcurrido: {tiempoTranscurridoMs} ms");


        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
