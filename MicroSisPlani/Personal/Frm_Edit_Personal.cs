
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
using System.IO;



namespace MicroSisPlani.Personal
{
    public partial class Frm_Edit_Personal : Form
    {

        public Frm_Edit_Personal()
        {
            InitializeComponent();
        }          
     
        private void Frm_Edit_Personal_Load(object sender, EventArgs e)
        {
            Buscar_Producto_paraEditar(this.Tag.ToString());          

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void Listar_Roles()
        {
        }

        private void Listar_Distritos() 
        {
        }


        private void Buscar_Producto_paraEditar(string idpro) 
        {
            RN_Producto obj = new RN_Producto();   
            DataTable data = new DataTable();

            data = obj.RN_Buscar_producto_porValor(idpro);

            if (data.Rows.Count > 0)
            {

                txt_IdProducto.Text = Convert.ToString(data.Rows[0]["id"]);
                txt_codigo.Text = Convert.ToString(data.Rows[0]["codigo"]);
                txt_Descripcion.Text = Convert.ToString(data.Rows[0]["descripcion"]);
                txt_tipo.Text = Convert.ToString(data.Rows[0]["tipo"]);
                txt_PrecioCompra.Text = Convert.ToString(data.Rows[0]["precioCompra"]);
                txt_PrecioVenta.Text = Convert.ToString(data.Rows[0]["precioVenta"]);
                txt_PrecioMayoreo.Text = Convert.ToString(data.Rows[0]["precioMayoreo"]);
                txt_PrecioEspecial.Text = Convert.ToString(data.Rows[0]["precioEspecial"]);
                txt_Categoria.Text = Convert.ToString(data.Rows[0]["categoria"]);
                txt_cantidad.Text = Convert.ToString(data.Rows[0]["cantidadActual"]);
                txt_CantidadMinima.Text = Convert.ToString(data.Rows[0]["cantidadMinima"]);


            }
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

        private void Registrar_Personal()
        {
            RN_Producto obj = new RN_Producto();
            EN_Producto pro = new EN_Producto();

            try
            {
               /* pro.Id_producto = txt_IdProducto.Text;
                pro.Codigo_producto = txt_codigoproducto.Text;
                pro.Nombre = txt_nombre.Text;
                pro.Tipo = txt_tipo.Text;
                pro.PrecioVenta = Int32.Parse(txt_Precio.Text);
                pro.Descripcion = txt_descripcion.Text;
                pro.Cantidad = Int32.Parse(txt_cantidad.Text);

                obj.RN_actualizar_Producto(pro);

                MessageBox.Show("Datos Actualizados");
                this.Tag = "A";
                this.Close();
              */
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Actualizar_Personal()
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

                obj.RN_actualizar_Producto(pro, Int32.Parse(txt_IdProducto.Text));

                // Actualizar_SiguienteNumero(2);

                MessageBox.Show("Datos Guardados");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Registrar producto, intente de nuevo o comuniquese con Soporte");
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {
        }

        private void Bt_NewPerso_Click(object sender, EventArgs e)
        {
            Frm_Registrar_Img asi = new Frm_Registrar_Img();
            asi.ShowDialog();
        }

        private void btn_aceptar_Click_1(object sender, EventArgs e)
        {
            Actualizar_Personal();
            //VerificarDatos();
           // this.Tag = "";
            this.Close();
        }

        private void btn_cancelar_Click_1(object sender, EventArgs e)
        {

            this.Tag = "";
            this.Close();
        }
    }
}
