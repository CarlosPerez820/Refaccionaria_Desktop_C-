
using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prj_Capa_Negocio;
using Prj_Capa_Datos;
using Prj_Capa_Entidad;


namespace MicroSisPlani.Personal
{
    public partial class Frm_Registro_Compradores : Form
    {

        public Frm_Registro_Compradores()
        {
            InitializeComponent();
        }       
      
        private void Frm_Registro_Compradores_Load(object sender, EventArgs e)
        {
            txt_IdCliente.Text = RN_Utilitario.RN_NroDoc(1);
        }


        private void button1_Click_1(object sender, EventArgs e)
        {          
        }

        private void button2_Click_1(object sender, EventArgs e)
        {           
        }


        private void pnl_titulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
          
        }

   

        public string nombreFoto;

        //Metodo para Obtener el ID en la interfaz
        public string nombreDeImagen() 
        {
            nombreFoto = RN_Utilitario.RN_NroDoc(2);
            return nombreFoto;
        }
      
        private void Registrar_Personal()
        {

            RN_Cliente obj = new RN_Cliente();
            EN_Cliente cli = new EN_Cliente();

            try
            {

                cli.IDCliente = txt_IdCliente.Text;
                cli.NombreCompleto = txt_nombre.Text;
                cli.Direccion = txt_direccion.Text;
                cli.Telefono = txt_telefono.Text;
                cli.Credito = int.Parse(txt_limiteCredito.Text);

                Console.WriteLine(cli.IDCliente);
                Console.WriteLine(cli.NombreCompleto);
                Console.WriteLine(cli.Direccion);
                Console.WriteLine(cli.Telefono);
                Console.WriteLine(cli.Credito);


                obj.RN_Registrar_Cliente(cli);

                Actualizar_SiguienteNumero(1);

                MessageBox.Show("Datos Guardados");

                

            }
            catch (Exception ex) 
            {
                MessageBox.Show("Hay un problema: "+ex);
            }
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            Registrar_Personal();
            this.Tag = "";
            Frm_Principal variable = new Frm_Principal("admin");
            variable.pruebaMensajeInterfaz();
            this.Close();

        }

        private double GenerarNextID(string numero) 
        {
            //0001
            //1
            double newnum = Convert.ToDouble(numero) + 1;
            return newnum; // 2
        }

        private void Actualizar_SiguienteNumero(int idtipo) 
        {
            string xnum = BD_Utilitario.BD_Leer_Solo_Numero(idtipo); //0001
            string xnuevonum = Convert.ToString(GenerarNextID(xnum));
            int td = xnuevonum.Length;
            string NuevoCorrelativo = "";

            if (xnuevonum.Length < 5) 
            {
                if (td == 1)
                {
                    NuevoCorrelativo = "0000" + xnuevonum;
                }
                if (td == 2)
                {
                    NuevoCorrelativo = "000" + xnuevonum;
                }
                if (td == 3)
                {
                    NuevoCorrelativo = "00" + xnuevonum;
                }
                if (td == 4)
                {
                    NuevoCorrelativo = "0" + xnuevonum;
                }
            }

            BD_Utilitario.BD_ActualizarNro(idtipo, NuevoCorrelativo);
        }

        private void cbo_sexo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void Bt_NewPerso_Click(object sender, EventArgs e)
        {
            Frm_Registrar_Img asi = new Frm_Registrar_Img();
            asi.ShowDialog();
        }


        private void button2_Click(object sender, EventArgs e)
        {                
        }

        private void elButton1_Click(object sender, EventArgs e)
        {
            Frm_Principal variable = new Frm_Principal("administrador");
            variable.pruebaMensajeInterfaz();
        }
    }
}
