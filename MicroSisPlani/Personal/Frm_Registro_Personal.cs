
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
using System.Globalization;

namespace MicroSisPlani.Personal
{
    public partial class Frm_Registro_Personal : Form
    {

        public Frm_Registro_Personal()
        {
            InitializeComponent();
        }       
      
        private void Frm_Registro_Personal_Load(object sender, EventArgs e)
        {
            txt_IdProducto.Text = RN_Utilitario.RN_NroDoc(2);
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

            RN_Producto obj = new RN_Producto();
            EN_Producto pro = new EN_Producto();

            try
            {
                pro.Codigo = txt_codigo.Text;
                pro.Descripcion = txt_Descripcion.Text;
                pro.Tipo = txt_tipo.Text;
                pro.PrecioCompra = Double.Parse(txt_PrecioCompra.Text);
                pro.PrecioVenta = Double.Parse(txt_PrecioVenta.Text);
                pro.PrecioMayoreo = Double.Parse(txt_PrecioMayoreo.Text);
                pro.PrecioEspecial = Double.Parse(txt_PrecioEspecial.Text);
                pro.Categoria = txt_Categoria.Text;
                pro.CantidadActual = Int32.Parse(txt_cantidad.Text);
                pro.CantidadMinima = Int32.Parse(txt_CantidadMinima.Text);
                
                obj.RN_Registrar_Producto(pro);

               // Actualizar_SiguienteNumero(2);

                MessageBox.Show("Datos Guardados");

            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error al Registrar producto, intente de nuevo o comuniquese con Soporte");
            }
        }

        private void VerificarDatos() 
        {


            if (txt_codigo.Text!="") 
            {
                MessageBox.Show("Funciona la validacion");
            }
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            Registrar_Personal();
            //VerificarDatos();
            this.Tag = "";
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

        private void txt_cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            char decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            bool isDecimalSeparator = e.KeyChar == decimalSeparator;
            bool isDigit = char.IsDigit(e.KeyChar);
            bool isControl = char.IsControl(e.KeyChar);

            // Permitir el separador decimal solo una vez y no al comienzo
            if (isDecimalSeparator && txt_cantidad.Text.Contains(decimalSeparator.ToString()))
            {
                e.Handled = true;
            }
            else if (isDigit || isControl || isDecimalSeparator)
            {
                // Permitir dígitos, teclas de control y el separador decimal
                e.Handled = false;
            }
            else
            {
                // Bloquear cualquier otro carácter
                e.Handled = true;
            }
        }

        private void txt_PrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            char decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            bool isDecimalSeparator = e.KeyChar == decimalSeparator;
            bool isDigit = char.IsDigit(e.KeyChar);
            bool isControl = char.IsControl(e.KeyChar);

            // Permitir el separador decimal solo una vez y no al comienzo
            if (isDecimalSeparator && txt_PrecioCompra.Text.Contains(decimalSeparator.ToString()))
            {
                e.Handled = true;
            }
            else if (isDigit || isControl || isDecimalSeparator)
            {
                // Permitir dígitos, teclas de control y el separador decimal
                e.Handled = false;
            }
            else
            {
                // Bloquear cualquier otro carácter
                e.Handled = true;
            }
        }

        private void txt_PrecioMayoreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            char decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            bool isDecimalSeparator = e.KeyChar == decimalSeparator;
            bool isDigit = char.IsDigit(e.KeyChar);
            bool isControl = char.IsControl(e.KeyChar);

            // Permitir el separador decimal solo una vez y no al comienzo
            if (isDecimalSeparator && txt_PrecioMayoreo.Text.Contains(decimalSeparator.ToString()))
            {
                e.Handled = true;
            }
            else if (isDigit || isControl || isDecimalSeparator)
            {
                // Permitir dígitos, teclas de control y el separador decimal
                e.Handled = false;
            }
            else
            {
                // Bloquear cualquier otro carácter
                e.Handled = true;
            }
        }

        private void txt_CantidadMinima_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void txt_CantidadMinima_KeyPress(object sender, KeyPressEventArgs e)
        {
            char decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            bool isDecimalSeparator = e.KeyChar == decimalSeparator;
            bool isDigit = char.IsDigit(e.KeyChar);
            bool isControl = char.IsControl(e.KeyChar);

            // Permitir el separador decimal solo una vez y no al comienzo
            if (isDecimalSeparator && txt_CantidadMinima.Text.Contains(decimalSeparator.ToString()))
            {
                e.Handled = true;
            }
            else if (isDigit || isControl || isDecimalSeparator)
            {
                // Permitir dígitos, teclas de control y el separador decimal
                e.Handled = false;
            }
            else
            {
                // Bloquear cualquier otro carácter
                e.Handled = true;
            }
        }

        private void txt_PrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            char decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            bool isDecimalSeparator = e.KeyChar == decimalSeparator;
            bool isDigit = char.IsDigit(e.KeyChar);
            bool isControl = char.IsControl(e.KeyChar);

            // Permitir el separador decimal solo una vez y no al comienzo
            if (isDecimalSeparator && txt_PrecioVenta.Text.Contains(decimalSeparator.ToString()))
            {
                e.Handled = true;
            }
            else if (isDigit || isControl || isDecimalSeparator)
            {
                // Permitir dígitos, teclas de control y el separador decimal
                e.Handled = false;
            }
            else
            {
                // Bloquear cualquier otro carácter
                e.Handled = true;
            }
        }

        private void txt_PrecioEspecial_KeyPress(object sender, KeyPressEventArgs e)
        {
            char decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            bool isDecimalSeparator = e.KeyChar == decimalSeparator;
            bool isDigit = char.IsDigit(e.KeyChar);
            bool isControl = char.IsControl(e.KeyChar);

            // Permitir el separador decimal solo una vez y no al comienzo
            if (isDecimalSeparator && txt_PrecioEspecial.Text.Contains(decimalSeparator.ToString()))
            {
                e.Handled = true;
            }
            else if (isDigit || isControl || isDecimalSeparator)
            {
                // Permitir dígitos, teclas de control y el separador decimal
                e.Handled = false;
            }
            else
            {
                // Bloquear cualquier otro carácter
                e.Handled = true;
            }
        }
    }
}
