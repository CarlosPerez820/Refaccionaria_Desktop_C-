using MicroSisPlani.Personal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prj_Capa_Datos;
using Prj_Capa_Entidad;
using Prj_Capa_Negocio;
using MicroSisPlani.Msm_Forms;
using Microsoft.VisualBasic;
using DevComponents.DotNetBar.Controls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;
using Google.Protobuf.WellKnownTypes;
using System.Threading;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Runtime.InteropServices;
using DocumentFormat.OpenXml.Drawing;
using DevComponents.DotNetBar;

namespace MicroSisPlani
{
    public partial class Frm_Principal : Form
    {
        private DataTable productosParaVenta = new DataTable();
        private DataTable productosInventario = new DataTable();
        private DataTable listaDeClientes = new DataTable();

        private string role;

        private int numeroMayoreo = 1000;
        public Frm_Principal(string role)
        {
            InitializeComponent();
            this.role = role;

            // Configurar propiedades del ToolTip
            toolTip2.AutoPopDelay = 5000; // Retraso antes de que el ToolTip se cierre (en milisegundos)
            toolTip2.InitialDelay = 500; // Retraso antes de que el ToolTip aparezca (en milisegundos)
            toolTip2.ReshowDelay = 500; // Retraso antes de que el ToolTip vuelva a aparecer si el cursor se desplaza nuevamente (en milisegundos)
            toolTip2.ShowAlways = true; // Mostrar el ToolTip incluso si la ventana no está activa

            // Otras propiedades del ToolTip
            toolTip2.BackColor = Color.LightYellow; // Color de fondo
            toolTip2.ForeColor = Color.Black; // Color del texto
          //  toolTip2.UseFading = true; // Aplicar efecto de atenuación al mostrar y ocultar
        //    toolTip2.UseAnimation = true; // Aplicar animación al mostrar y ocultar
            toolTip2.IsBalloon = true; // Mostrar ToolTip en forma de globo de diálogo


        }

        public void Frm_Principal_Load(object sender, EventArgs e)
        {
            verificarRol();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            //Configuración de los ListView
            ConfigurarListView_Asis();
            Configurar_ListView_ProductosVenta();
            Configurar_ListView_Venta();
            Configurar_ListView_Inventario();
            Configurar_ListView_Gastos();
            Configurar_ListView_Clientes();
            Configurar_ListView_Lista_Devoluciones();
            //Llenado de ListView de Productos
            P_Cargar_Todo_Inventario();
            P_Cargar_Todos_Clientes();

            cargarApartados();
            P_Cargar_Todos_ProductosVenta();
            P_Cargar_Todo_Gastos();
            P_Cargar_Todo_Lista_Devoluciones();

            MostrarVentasDia();

            lb_numVenta.Text = RN_Utilitario.RN_NroDoc(1);

            llenarComboBox();

            stopwatch.Stop();
            long tiempoTranscurridoMs = stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"Tiempo transcurrido: {tiempoTranscurridoMs} ms");
        }

        private void verificarRol() 
        {
            if (role == "administrador") 
            {
                Bt_NewPerso.Visible = true;
                Btn_EditPerso.Visible = true;
                btn_cancel_horio.Visible = true;
                elButton2.Visible = true;
                elButton3.Visible = true;
                elButton6.Visible = true;
            }
        }
        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Utilitarios u = new Utilitarios();
                u.Mover_formulario(this);
            }
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_mini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bt_personal_Click(object sender, EventArgs e)
        {
            elTab1.SelectedTabPageIndex = 1;
            elTabPage2.Visible = true;
            P_Cargar_Todo_Inventario();
        }

        private void btn_Asis_With_Huella_Click(object sender, EventArgs e)
        {
            Frm_Marcar_Asistencia asi = new Frm_Marcar_Asistencia();
            asi.ShowDialog();
        }

        private void bt_Explo_Asis_Click(object sender, EventArgs e)
        {
            elTab1.SelectedTabPageIndex = 2;
            elTabPage3.Visible = true;
        }

        private void bt_exploJusti_Click(object sender, EventArgs e)
        {
            Frm_Marcar_Asistencia asi = new Frm_Marcar_Asistencia();
            asi.ShowDialog();
        }

        private void bt_Config_Click(object sender, EventArgs e)
        {
            elTab1.SelectedTabPageIndex = 3;
            elTabPage3.Visible = true;
            P_Cargar_Todo_Inventario();
        }

        private void Btn_Cerrar_TabPers_Click(object sender, EventArgs e)
        {
            elTab1.SelectedTabPageIndex = 0;
            elTabPage1.Visible = true;
        }

        private void btn_cerrarEx_Asis_Click(object sender, EventArgs e)
        {
            elTab1.SelectedTabPageIndex = 0;
            elTabPage3.Visible = true;
        }


        //Cargar apartados

        private void cargarApartados() {

            string[] columnasAMostrar = { "id","folioVenta", "fechaVenta", "horaVenta", "cliente", "descripcionVenta", "totalVenta", "cantidadAbonada", "fechaUltimoPago", "totalRestante" };

            RN_Ventas ven1 = new RN_Ventas();
            DataTable data = new DataTable();
            data = ven1.RN_Listar_Apartados();

            dataGV_Credito.DataSource = data;

            foreach (DataGridViewColumn columna in dataGV_Credito.Columns)
            {
                if (!columnasAMostrar.Contains(columna.HeaderText))
                {
                    columna.Visible = false;
                }
            }

          //  dataGV_Credito.Columns[8].HeaderText = "Ultimo_Abono";
        }

        // Bloque de codigo correspondiente al Inventario/Almacen de Productos ----------------------------
        private void Configurar_ListView_Inventario()
        {
            var lis = lsv_person;

            lis.Columns.Clear();
            lis.Items.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;

            //Las columnas
            lis.Columns.Add("ID producto", 40, HorizontalAlignment.Center);
            lis.Columns.Add("Codigo", 190, HorizontalAlignment.Center);
            lis.Columns.Add("Descripcion", 440, HorizontalAlignment.Left);
            lis.Columns.Add("Cantidad", 60, HorizontalAlignment.Center);
            lis.Columns.Add("CantidadMinima", 60, HorizontalAlignment.Right);
            lis.Columns.Add("Categoria", 140, HorizontalAlignment.Center);
            lis.Columns.Add("PrecioCompra", 90, HorizontalAlignment.Center);
            lis.Columns.Add("PrecioVenta", 80, HorizontalAlignment.Center);
            lis.Columns.Add("PrecioMayoreo", 80, HorizontalAlignment.Center);
            lis.Columns.Add("PrecioEspecial", 80, HorizontalAlignment.Center);

           
        }

        //Llenado de ListView De Productos
        private void Llenar_ListView(DataTable data)
        {
            Console.WriteLine("Inicia llenado de tabla");

            lsv_person.Items.Clear();

           

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["id"].ToString()); //Cabecera ListView

                //columnas
                list.SubItems.Add(dr["codigo"].ToString());
                list.SubItems.Add(dr["descripcion"].ToString()).BackColor = System.Drawing.Color.Red; ;
                list.SubItems.Add(dr["cantidadActual"].ToString());
                list.SubItems.Add(dr["cantidadMinima"].ToString());
                list.SubItems.Add(dr["categoria"].ToString());
                list.SubItems.Add(dr["precioCompra"].ToString());
                list.SubItems.Add(dr["precioVenta"].ToString());
                list.SubItems.Add(dr["precioMayoreo"].ToString());
                list.SubItems.Add(dr["precioEspecial"].ToString());

                // list.UseItemStyleForSubItems = false; // Permite personalizar el estilo de las subcolumnas

                //list.SubItems[2].ForeColor = Color.Blue;

                lsv_person.Items.Add(list); //Si no se pone el listView no se llenara

//                list.SubItems[2].ForeColor = Color.Blue;

            }
           // lsv_person.DrawSubItem += lsv_person_DrawSubItem;
            //lsv_person.Columns[7].BackColor = Color.Orange;
            Lbl_total.Text = Convert.ToString(lsv_person.Items.Count);
            // Manejar los eventos OwnerDraw y DrawSubItem
            lsv_person.OwnerDraw = true;
            lsv_person.DrawItem += lsv_person_DrawItem;

           
        }

        private void P_Cargar_Todo_Inventario()
        {
            RN_Producto obj = new RN_Producto();
            DataTable miTabla = new DataTable();
            //productosInventario = obj.RN_Lista_Todo_Producto();
           
            miTabla = obj.RN_Lista_Todo_Producto();
            // Ordena el DataTable alfabéticamente por la columna "Nombre"
            var filasOrdenadas = miTabla.AsEnumerable()
                .OrderBy(row => row.Field<string>("Descripcion"));

            // Crea un nuevo DataTable con las filas ordenadas
            productosInventario = filasOrdenadas.CopyToDataTable();


            if (productosInventario.Rows.Count > 0)
            {
                Console.WriteLine("Si se obtuvieron filas de la tabla");
                Llenar_ListView(productosInventario);
            }
            else
            {
                lsv_person.Items.Clear();
            }

        }

        private void Cargar_Inventario_BD() 
        {
            RN_Producto obj = new RN_Producto();
            productosInventario = obj.RN_Lista_Todo_Producto();
        }

        private void P_Buscar_Producto_porValor(string valor)
        {
            /*
            RN_Producto obj = new RN_Producto();
            DataTable dato = new DataTable();
            dato = obj.RN_Buscar_producto_porValor_Cadena(valor);

            //MessageBox.Show(dato.Rows.Count.ToString());
            if (dato.Rows.Count > 0)
            {
                Llenar_ListView(dato);
            }
            else
            {
                lsv_person.Items.Clear();
            }
            */

        }

        private void txt_Buscar_OnValueChanged(object sender, EventArgs e) 
        {
            Console.WriteLine("Inicia metodo de cambio de valor en busqueda");

            if (txt_Buscar.Text.Length > 4)
            {
                string terminoBusqueda = txt_Buscar.Text.Trim().ToLower();

                if (!string.IsNullOrEmpty(terminoBusqueda))
                {
                    // Realizar la búsqueda en el DataTable utilizando LINQ para filtrar los resultados.
                    Console.WriteLine("----------" + terminoBusqueda);
                    var resultados = from row in productosInventario.AsEnumerable()
                                     where row.Field<string>("codigo").ToLower().Contains(terminoBusqueda) ||
                                           row.Field<string>("descripcion").ToLower().Contains(terminoBusqueda) ||
                                           row.Field<string>("categoria").ToLower().Contains(terminoBusqueda)
                                     select row;

                    if (resultados.Count() > 0)
                    {
                        Llenar_ListView(resultados.CopyToDataTable());
                    }
                    else
                    {
                        lsv_person.Items.Clear();
                    }
                }
                else
                {
                    lsv_person.Items.Clear();
                }
            }
            else if(txt_Buscar.Text.Length == 0)
            {
                Console.WriteLine("La busuqeda es vacia y se rellena");
                Llenar_ListView(productosInventario);
            }


        }

        private void Bt_NewPerso_Click(object sender, EventArgs e)
        {
            Frm_Registro_Personal asi = new Frm_Registro_Personal();
            asi.ShowDialog();
        }

        private void Btn_EditPerso_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            Frm_Edit_Personal per = new Frm_Edit_Personal();
            string idper = "";

            if (lsv_person.SelectedItems.Count == 0)
            {
                fil.Show();
                ver.Lbl_Msm1.Text = "Por favor, Seleccione el personal que quiere Editar";
                ver.ShowDialog();
                fil.Hide();
                return;
            }
            else
            {
                var lis = lsv_person.SelectedItems[0];
                idper = lis.SubItems[0].Text;

                // MessageBox.Show("El ID es : "+ idper);

                fil.Show();
                per.Tag = idper;
                per.ShowDialog();
                fil.Hide();

                if (per.Tag.ToString() == "A")
                {
                    P_Cargar_Todo_Inventario();
                }
            }
        }

        private void bt_eliminarPersonal_Click(object sender, EventArgs e)
        {
            string idpro = "";

            if (lsv_person.SelectedItems.Count == 0)
            {
                MessageBox.Show("Por favor seleccionar personal");
                return;
            }
            else
            {
                var lis = lsv_person.SelectedItems[0];
                idpro = lis.SubItems[0].Text;

                RN_Producto obj = new RN_Producto();

                if (MessageBox.Show("¿Desea el producto" + idpro + " ?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    obj.RN_Eliminar_Producto(int.Parse(idpro));
                    P_Cargar_Todo_Inventario();
                }
                else
                {
                    P_Cargar_Todo_Inventario();
                }
            }
        }

        // Inicia Bloque de codigo correspondiente a la interfaz de CLIENTES ---------------------------------------------------------------------------------------------------
        private void Configurar_ListView_Clientes()
        {
            var lis = lsv_cliente;

            lis.Columns.Clear();
            lis.Items.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;

            //Las columnas
            lis.Columns.Add("ID cliente", 160, HorizontalAlignment.Center);
            lis.Columns.Add("Nombre", 300, HorizontalAlignment.Center);
            lis.Columns.Add("Direccion", 300, HorizontalAlignment.Center);
            lis.Columns.Add("Telefono", 110, HorizontalAlignment.Center);
            lis.Columns.Add("Credito", 100, HorizontalAlignment.Center);
        }

        private void Llenar_ListView_Clientes(DataTable data)
        {
            lsv_cliente.Items.Clear();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["Id_cliente"].ToString()); //Cabecera ListView

                //columnas
                list.SubItems.Add(dr["nombre_completo"].ToString());
                list.SubItems.Add(dr["direccion"].ToString());
                list.SubItems.Add(dr["telefono"].ToString());
                list.SubItems.Add(dr["limite_credito"].ToString());

                lsv_cliente.Items.Add(list); //Si no se pone el listView no se llenara
            }
            Lbl_totalCientes.Text = Convert.ToString(lsv_cliente.Items.Count);
        }

        private void P_Cargar_Todos_Clientes()
        {
            RN_Cliente obj = new RN_Cliente();
         

            listaDeClientes = obj.RN_Listar_Cliente();
            if (listaDeClientes.Rows.Count > 0)
            {
                Llenar_ListView_Clientes(listaDeClientes);
                //MessageBox.Show("Si hay registros - " + dato.Rows.Count);
            }
            else
            {
                lsv_person.Items.Clear();
                //MessageBox.Show("No hay registros");
            }

        }


        // Inicia Bloque de codigo correspondiente a la interfaz de Ventas ------------------------------------------------------------------------------------------------
        private void Configurar_ListView_ProductosVenta()
        {
            var lis = lsv_productos2;

            lis.Columns.Clear();
            lis.Items.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;

            //Las columnas
            lis.Columns.Add("ID", 60, HorizontalAlignment.Center);
            lis.Columns.Add("Codigo", 200, HorizontalAlignment.Center);
            lis.Columns.Add("Descripcion", 340, HorizontalAlignment.Left);
            lis.Columns.Add("Categoria", 140, HorizontalAlignment.Center);
            lis.Columns.Add("Precio", 100, HorizontalAlignment.Center);
            lis.Columns.Add("Cantidad", 110, HorizontalAlignment.Center);
        }
        private void Configurar_ListView_Venta()
        {
            var lis = lsv_venta;

            lis.Columns.Clear();
            lis.Items.Clear();
            lis.View = View.Details;
            lis.GridLines = true;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;

            //Las columnas
         
            lis.Columns.Add("Id", 70, HorizontalAlignment.Center);
            lis.Columns.Add("codigo", 150, HorizontalAlignment.Center);
            lis.Columns.Add("Descripcion", 230, HorizontalAlignment.Left);
            lis.Columns.Add("Cantidad", 110, HorizontalAlignment.Center);
            lis.Columns.Add("PrecioO", 110, HorizontalAlignment.Center);
            lis.Columns.Add("PrecioF", 110, HorizontalAlignment.Center);
            lis.Columns.Add("Nota", 160, HorizontalAlignment.Center);
            lis.Columns.Add("Total", 90, HorizontalAlignment.Center);
            lis.Columns.Add("Categoria", 0, HorizontalAlignment.Center);
        }

        private void Llenar_ListView_ProductosVenta(DataTable data)
        {
            lsv_productos2.Items.Clear();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["id"].ToString()); //Cabecera ListView

                //columnas
                
                list.SubItems.Add(dr["codigo"].ToString());
                list.SubItems.Add(dr["descripcion"].ToString());
                list.SubItems.Add(dr["categoria"].ToString());
                list.SubItems.Add(dr["precioVenta"].ToString());
                list.SubItems.Add(dr["cantidadActual"].ToString());

                lsv_productos2.Items.Add(list); //Si no se pone el listView no se llenara
            }
            Lbl_total.Text = Convert.ToString(lsv_productos2.Items.Count);
        }

        private void Llenar_ListView_Venta(DataTable data, string cantidad)
        {
            String _id = lsv_productos2.SelectedItems[0].SubItems[0].Text;
            String codigo = lsv_productos2.SelectedItems[0].SubItems[1].Text;
            String descripcion = lsv_productos2.SelectedItems[0].SubItems[2].Text;
            String categoria = lsv_productos2.SelectedItems[0].SubItems[3].Text;
            String precio = lsv_productos2.SelectedItems[0].SubItems[4].Text;
           
            String precioFinal = precio;
            string nota = "Normal";

            double sumaTotal = Convert.ToDouble(lb_Total.Text);

            if (Convert.ToInt32(cantidad)>=numeroMayoreo) 
            {
                DataRow productoRow = productosParaVenta.Rows.Find(Convert.ToInt32(_id));
                precioFinal = productoRow["precioMayoreo"].ToString();
                MessageBox.Show(precioFinal);
                nota = "MAYOREO";
            }

            ListViewItem list = new ListViewItem(_id); //Cabecera ListView

            list.SubItems.Add(codigo);
            list.SubItems.Add(descripcion);
            list.SubItems.Add(cantidad);
            list.SubItems.Add(precio);
            list.SubItems.Add(precioFinal);
            list.SubItems.Add(nota);

            //list.SubItems.Add();

            double total = Int32.Parse(cantidad) * double.Parse(precioFinal);

            String totalText = Convert.ToString(total);

            sumaTotal = sumaTotal + total;

            lb_Total.Text = Convert.ToString(sumaTotal);

            double totalFinalT = double.Parse(lb_Total.Text) - double.Parse(lbl_descuentoTotal.Text);
            lbl_totalFinal.Text = totalFinalT.ToString();

            // MessageBox.Show(totalText);

            list.SubItems.Add(totalText);
            list.SubItems.Add(categoria);

            lsv_venta.Items.Add(list); //Si no se pone el listView no se llenara

            Lbl_total.Text = Convert.ToString(lsv_productos2.Items.Count);


        }
        private void P_Cargar_Todos_ProductosVenta()
        {


            RN_Producto obj = new RN_Producto();
            DataTable dato = new DataTable();

            productosParaVenta = obj.RN_Lista_Todo_Producto();
            productosParaVenta.PrimaryKey = new DataColumn[] { productosParaVenta.Columns["id"] };

        }

        private void P_Buscar_Producto_porValorVenta(string valor)
        {
            RN_Producto obj = new RN_Producto();
            DataTable dato = new DataTable();

            dato = obj.RN_Buscar_producto_porValor_Cadena(valor);
            if (dato.Rows.Count > 0)
            {
                Llenar_ListView_ProductosVenta(dato);
            }
            else
            {
                lsv_productos2.Items.Clear();
            }
        }
        //------------------------------------------------------------------------------Bloque de Gastos-------------------------------------------------------------
        private void Configurar_ListView_Gastos()
        {
            var lis = lsv_listaGastos;

            lis.Columns.Clear();
            lis.Items.Clear();
            lis.View = View.Details;
            lis.GridLines = true;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;

            //Las columnas
            lis.Columns.Add("ID", 100, HorizontalAlignment.Center);
            lis.Columns.Add("Fecha", 200, HorizontalAlignment.Center);
            lis.Columns.Add("Descripcion", 370, HorizontalAlignment.Center);
            lis.Columns.Add("Monto", 100, HorizontalAlignment.Center);

        }

        private void Llenar_ListView_Gastos(DataTable data)
        {
            lsv_listaGastos.Items.Clear();

            DateTime variable;
            string variableFecha;
            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];

                variable = DateTime.Parse(dr["fecha"].ToString());
                variableFecha = variable.ToString("yyyy-MM-dd");

                ListViewItem list = new ListViewItem(dr["id"].ToString()); //Cabecera ListView

                //columnas
                list.SubItems.Add(variableFecha);
                list.SubItems.Add(dr["descripcion"].ToString());
                list.SubItems.Add(dr["monto"].ToString());
           

                lsv_listaGastos.Items.Add(list); //Si no se pone el listView no se llenara
            }
        }

        private void P_Cargar_Todo_Gastos()
        {
            RN_Gastos obj = new RN_Gastos();
            DataTable dato = new DataTable();

            dato = obj.RN_Listar_Gastos();

            if (dato.Rows.Count > 0)
            {
                Llenar_ListView_Gastos(dato);
            }
            else
            {
                lsv_listaGastos.Items.Clear();
            }

        }

        //----------------------------------------------------------        Devoluciones      -------------------------------------------------------------------------
        private void Configurar_ListView_DatosDevoluciones()
        {
            var lis = lsv_datosDevolucion;

            lis.Columns.Clear();
            lis.Items.Clear();
            lis.View = View.Details;
            lis.GridLines = true;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;

            //Las columnas
            lis.Columns.Add("ID", 0, HorizontalAlignment.Center);
            lis.Columns.Add("IDProducto", 0, HorizontalAlignment.Center);
            lis.Columns.Add("_idProducto", 0, HorizontalAlignment.Center);
            lis.Columns.Add("Producto", 315, HorizontalAlignment.Center);
            lis.Columns.Add("Cantidad", 100, HorizontalAlignment.Center);
            lis.Columns.Add("Importe", 80, HorizontalAlignment.Center);


        }

        private void Llenar_ListView_DatosDescuento(DataTable data)
        {
            lsv_datosDevolucion.Items.Clear();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];

                if (i==(data.Rows.Count-1)) 
                {
                    lbl_folioDevolucion.Text = dr[1].ToString();
                    lbl_fechaDevolucion.Text  = dr[2].ToString();
                    lbl_clienteDevolucion.Text = dr[5].ToString();
                    lbl_subTotalDevolucion.Text = dr[15].ToString();
                    lbl_descuentoDevolucion.Text = dr[16].ToString();
                    lbl_totalDevolucion.Text = dr[17].ToString();
                }
               

                ListViewItem list = new ListViewItem(dr["id"].ToString()); //Cabecera ListView

                //columnas
                list.SubItems.Add(dr["codigoProducto"].ToString());
                list.SubItems.Add(dr["idProducto"].ToString());

                list.SubItems.Add(dr["descripcionProducto"].ToString());
                list.SubItems.Add(dr["cantidadProducto"].ToString());
                list.SubItems.Add(dr["importeProducto"].ToString());


                lsv_datosDevolucion.Items.Add(list); //Si no se pone el listView no se llenara
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void Configurar_ListView_Lista_Devoluciones()
        {
            var lis = lsv_listaDevoluciones;

            lis.Columns.Clear();
            lis.Items.Clear();
            lis.View = View.Details;
            lis.GridLines = true;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;

            //Las columnas
            lis.Columns.Add("ID", 1, HorizontalAlignment.Center);
            lis.Columns.Add("Folio", 130, HorizontalAlignment.Center);
            lis.Columns.Add("Fecha", 80, HorizontalAlignment.Center);
            lis.Columns.Add("Cliente", 120, HorizontalAlignment.Center);
            lis.Columns.Add("Producto", 180, HorizontalAlignment.Center);
            lis.Columns.Add("Cantidad", 50, HorizontalAlignment.Center);
            lis.Columns.Add("importe", 70, HorizontalAlignment.Center);
            lis.Columns.Add("subTotal", 70, HorizontalAlignment.Center);
            lis.Columns.Add("Total", 70, HorizontalAlignment.Center);

        }

        private void Llenar_ListView_Lista_Devolucion(DataTable data)
        {
            lsv_listaDevoluciones.Items.Clear();

            DateTime variable;
            string variableFecha;

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];

                variable = DateTime.Parse(dr["fechaVenta"].ToString());
                variableFecha = variable.ToString("yyyy-MM-dd");


                    ListViewItem list = new ListViewItem(dr["id"].ToString()); //Cabecera ListView

                    //columnas
                    list.SubItems.Add(dr["folioVenta"].ToString());
                    list.SubItems.Add(variableFecha);
           
                    list.SubItems.Add(dr["cliente"].ToString());
                    list.SubItems.Add(dr["descripcionProducto"].ToString());
                    list.SubItems.Add(dr["cantidadProducto"].ToString());
                    list.SubItems.Add(dr["importeProducto"].ToString());
                    list.SubItems.Add(dr["subTotal"].ToString());
                    list.SubItems.Add(dr["porcentajeDescuento"].ToString());
                    list.SubItems.Add(dr["totalVenta"].ToString());
                    


                lsv_listaDevoluciones.Items.Add(list); //Si no se pone el listView no se llenara                
                
            }
        }

        private void P_Cargar_Todo_Lista_Devoluciones()
        {
            RN_Ventas obj = new RN_Ventas();
            DataTable dato = new DataTable();

            dato = obj.RN_Listar_Devoluciones();

            if (dato.Rows.Count > 0)
            {
                Llenar_ListView_Lista_Devolucion(dato);
            }
            else
            {
                lsv_listaDevoluciones.Items.Clear();
            }

        }


        private void txt_Buscar_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void Label9_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label21_Click(object sender, EventArgs e)
        {
        }

        private void label22_Click(object sender, EventArgs e)
        {
        }

        private void elTabPage1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void lsv_person_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsv_person.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lsv_person.SelectedItems[0];
                string descripcion = selectedItem.SubItems[2].Text;
                string precio = selectedItem.SubItems[7].Text;
                //  MessageBox.Show(descripcion);
                lblNombreProducto.Text = descripcion;
                lbl_precioProducto.Text = precio;
                //toolTip2.SetToolTip(lsv_person, descripcion); // Cambia 'toolTip1' al nombre del control ToolTip en tu formulario
            }
            else
            {
                //toolTip2.Hide(lsv_person);
                lblNombreProducto.Text = "";
            }
            
        }

        private void elTabPage2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Click en el TAB");
        }

        private void ElLabel1_Click(object sender, EventArgs e)
        {
        }

        private void Lbl_total_Click(object sender, EventArgs e)
        {
        }

        private void btn_VerTodoPerso_Click(object sender, EventArgs e)
        {
          //  Console.WriteLine("Inicia metodo click");

            txt_Buscar.OnValueChanged -= txt_Buscar_OnValueChanged;
            txt_Buscar.Text = "";
            txt_Buscar.OnValueChanged += txt_Buscar_OnValueChanged;

            
            //Configurar_ListView_Inventario();
            Cargar_Inventario_BD();
            
            P_Cargar_Todos_ProductosVenta();
        }

        private void elTabPage3_Click(object sender, EventArgs e)
        {
        }

        private void MostrarVentasDia()
        {
            /*
            String fecha = DateTime.UtcNow.ToString("yyyy-MM-dd");
            RN_Ventas obj = new RN_Ventas();
            DataTable data = new DataTable();
            data = obj.RN_Buscar_Venta_porDia(fecha);

            lbl_totalventas.Text = Convert.ToString(data.Rows.Count);

            */

        }

        private void ConfigurarListView_Asis()
        {
        }

        private void Llenar_ListView_Asistencia(DataTable dato)
        {
        }

        private void Llenar_ListView_AsistenciaVencidas(DataTable dato)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            limpiarVentas();
        }

        private void limpiarVentas() 
        {
            lsv_venta.Items.Clear();
            P_Cargar_Todos_ProductosVenta();
            lb_Total.Text = "0";

            //Limpiar formulario Servicio
            txt_codigo.Text = "";
            txt_costo.Text = "";
            txt_descripcion.Text = "";
            lbl_cambioVenta.Text = "";
            txt_PagoEfectivo.Text = "";

            OcultarRegistroServicio();
            //Formulario Descuento
            txt_porcentaje.Text = "";
            bnt_formularioDescuento.Visible = true;
            txt_porcentaje.Visible = false;
            lbl_descuento.Visible = false;
            btn_aplicarDescuento.Visible = false;

            cmBox_clientes.SelectedValue = "";
            lbl_descuentoTotal.Text = "0";
            lbl_totalFinal.Text = "0";

            //Anticipo
            txt_Anticipo.Text = "0";
            txt_Anticipo.Visible = false;
            btn_aplicarAnticipo.Visible = false;
        }

        private void pnl_falta_Paint(object sender, PaintEventArgs e)
        {
        }

        private void P_Buecar_Asistencia_porNombre(string valor)
        {
            RN_Asistencia obj = new RN_Asistencia();
            DataTable dato = new DataTable();

            dato = obj.RN_Buscar_Asistencia_porNombre(valor);
            if (dato.Rows.Count > 0)
            {
                Llenar_ListView_Asistencia(dato);
            }
            else
            {
                lsv_venta.Items.Clear();
                lbl_totalventas.Text = Convert.ToString(lsv_venta.Items.Count);
            }
        }


        private void lbl_totalasis_Click(object sender, EventArgs e)
        {
        }

        private void txtBuscarAsisNombre_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtBuscarAsisNombre_OnValueChanged(object sender, EventArgs e)
        {
            
            if (txtBuscarAsisNombre.Text.Length > 4)
            {
                string terminoBusqueda = txtBuscarAsisNombre.Text.Trim().ToLower();

                if (!string.IsNullOrEmpty(terminoBusqueda))
                {
                    // Realizar la búsqueda en el DataTable utilizando LINQ para filtrar los resultados.
                    Console.WriteLine("----------" + terminoBusqueda);
                    var resultados = from row in productosParaVenta.AsEnumerable()
                                     where row.Field<string>("codigo").ToLower().Contains(terminoBusqueda) ||
                                           row.Field<string>("descripcion").ToLower().Contains(terminoBusqueda) ||
                                           row.Field<string>("categoria").ToLower().Contains(terminoBusqueda)
                                     select row;

                    if (resultados.Count() > 0)
                    {
                        Llenar_ListView_ProductosVenta(resultados.CopyToDataTable());
                    }
                    else
                    {
                        lsv_productos2.Items.Clear();
                    }
                }
                else
                {
                    lsv_productos2.Items.Clear();
                }
            }
            else {
                lsv_productos2.Items.Clear();
            }
        }


        private void btnvencida_Click(object sender, EventArgs e)
        {
        }
        private void button2_Click(object sender, EventArgs e)
        {
        }

         private void lsv_productos2_DoubleClick(object sender, EventArgs e)
        {
            DataTable dato = new DataTable();
            string precio = lsv_productos2.SelectedItems[0].SubItems[4].Text;
            string cantidadOriginal = lsv_productos2.SelectedItems[0].SubItems[5].Text;
            double total = Convert.ToDouble(lb_Total.Text);
            double pago;

            string _id = lsv_productos2.SelectedItems[0].SubItems[0].Text;
            DataRow productoRow = productosParaVenta.Rows.Find(Convert.ToInt32(_id));


            if (txt_pago.Text == "")
            {
                pago = 0;
            }
            else
            {
                pago = Convert.ToDouble(txt_pago.Text);
            }


            string cantidad;
            int cantidadNumerica;

            cantidad = Interaction.InputBox("Ingrese la cantidad");


            if (cantidad == "")
            {
                
            }
            
            if (int.TryParse(cantidad, out cantidadNumerica))
            {
                if (cantidadNumerica <= Convert.ToInt32(cantidadOriginal))
                {

                    // Actualizar la cantidad
                    productoRow["cantidadActual"] = Convert.ToInt32(cantidadOriginal)-(cantidadNumerica); // Nueva cantidad deseada
                    // Aplicar los cambios
                    productosParaVenta.AcceptChanges();

                    Llenar_ListView_Venta(dato, cantidad);

                    Configurar_ListView_ProductosVenta();
                    txtBuscarAsisNombre.Text = "";

                   // double variableTotal = Convert.ToDouble(precio) * Convert.ToDouble(cantidad);

                    //total = total + variableTotal;

                    //lb_Total.Text = Convert.ToString(total);

                   // lbl_cambioVenta.Text = Convert.ToString(pago - total);
                    

                }
                else
                {
                    MessageBox.Show("Cantidad Insuficiente");
                }
            }
            else
            {
                MessageBox.Show("Ingrese un número");
            }


        }

        private void lsv_productos2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsv_productos2.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lsv_productos2.SelectedItems[0];
                string descripcion = selectedItem.SubItems[2].Text;
                //  MessageBox.Show(descripcion);
                lbl_nombreProductoVenta.Text = descripcion;
                //toolTip2.SetToolTip(lsv_person, descripcion); // Cambia 'toolTip1' al nombre del control ToolTip en tu formulario
            }
            else
            {
                //toolTip2.Hide(lsv_person);
                lbl_nombreProductoVenta.Text = "";
            }
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();


            EN_Ventas ven = new EN_Ventas();
            RN_Ventas venSQL = new RN_Ventas();

            EN_Apartados apartadoN = new EN_Apartados(); 

            String horaFolio = DateTime.Now.ToString("HHmmss");
            String fechaFolio = DateTime.Now.ToString("yyMd");
            
            //Cliente de venta
            String clienteVenta = "Cliente General";

            object selectedItem = cmBox_clientes.SelectedItem;
            if (selectedItem != null)
            {
                clienteVenta = cmBox_clientes.SelectedValue.ToString();
            }

            //Datos para la venta
            String horaVenta = DateTime.Now.ToString("HH:mm");
            DateTime fechaVenta = DateTime.Now;
            String folio = fechaFolio + horaFolio;
            String formaPago = "Efectivo";
            String estatus = "Concretada";
            string cantidadPagada = txt_PagoEfectivo.Text;
            string _cambio = lbl_cambioVenta.Text;
            double subTotal = double.Parse(lb_Total.Text);
            double descuento = double.Parse(lbl_descuentoTotal.Text);
            double total = subTotal-descuento;

            string descripcionTodosProductos="";


            object selectedItem2 = cmboxFormaPago.SelectedItem;
            if (selectedItem2 != null)
            {
                formaPago = cmboxFormaPago.SelectedValue.ToString();
            }

            //Variable Boolean
            bool realizado = false;

            int i = 0;

            //variables unias
            double _subTotal=0;
            double _descuento=0;
            double _totalVenta=0;
            double _totalVenta2 = 0;

            int tamanoArreglo = lsv_venta.Items.Count;

            string[] Aproductos = new string[tamanoArreglo];
            string[] APrecios = new string[tamanoArreglo];
            string[] ACantidades = new string[tamanoArreglo];
            string[] AImportes = new string[tamanoArreglo];

            //int contador = 0;

            foreach (ListViewItem item in lsv_venta.Items)
            {

                if (i == lsv_venta.Items.Count - 1)
                {
                    _subTotal = subTotal;
                    _descuento = descuento;
                    _totalVenta = total;
                    _totalVenta2 = total;
                    realizado = true;

                    if (formaPago == "Credito") 
                    {
                        _totalVenta = Convert.ToDouble(cantidadPagada);
                    }

                }

                ven.FolioVenta = folio;
                ven.FechaVenta = fechaVenta;
                ven.HoraVenta = horaVenta;
                ven.FormaPago = formaPago;
                ven.Cliente = clienteVenta;
                ven.idProducto = Convert.ToInt32(item.SubItems[0].Text);
                ven.CodigoProducto = Convert.ToString(item.SubItems[1].Text);
                ven.DescripcionProducto = Convert.ToString(item.SubItems[2].Text);
                ven.TipoProducto = Convert.ToString(item.SubItems[8].Text);
                ven.Nota = Convert.ToString(item.SubItems[6].Text);
                ven.CantidadProducto = Convert.ToInt32(item.SubItems[3].Text);
                ven.PrecioVenta = Convert.ToDouble(item.SubItems[4].Text);
                ven.PrecioFinal = Convert.ToDouble(item.SubItems[5].Text);
                ven.ImporteProducto = Convert.ToDouble(item.SubItems[7].Text);

                descripcionTodosProductos = descripcionTodosProductos + " || " + Convert.ToString(item.SubItems[2].Text);

                //Unicos por venta
                ven.SubTotal = _subTotal;
                ven.PorcentajeDescuento = _descuento;

                ven.TotalVenta = _totalVenta;
                ven.Estatus = estatus;


                //Arreglos
                Aproductos[i]= Convert.ToString(item.SubItems[2].Text);
                APrecios[i] = Convert.ToString(item.SubItems[4].Text);
                ACantidades[i] = Convert.ToString(item.SubItems[3].Text);
                AImportes[i] = Convert.ToString(item.SubItems[7].Text);
                // Console.WriteLine($"Folio: {ven.FolioVenta}, producto: {ven.DescripcionProducto}, subtotal: {ven.SubTotal}, descuento: {ven.PorcentajeDescuento}, total: {ven.TotalVenta}");

                 venSQL.RN_registrar_Venta(ven);

                if (item.SubItems[6].Text == "SERVICIO")
                {

                }
                else {
                   Actualizar_Cantidad(Convert.ToInt32(item.SubItems[0].Text), Convert.ToInt32(item.SubItems[3].Text));

                }
                   
                i = i + 1;

            }

            stopwatch.Stop();
            long tiempoTranscurridoMs = stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"Tiempo transcurrido: {tiempoTranscurridoMs} ms");

            if (realizado == true)
            {
              //  MessageBox.Show(formaPago);
                if (formaPago == "Credito") {

                    MessageBox.Show("Compra a credito");

                    apartadoN.FolioVenta = folio;
                    apartadoN.FechaVenta = fechaVenta;
                    apartadoN.HoraVenta = horaVenta;
                    apartadoN.FormaPago = formaPago;
                    apartadoN.Cliente = clienteVenta;
                    apartadoN.DescripcionVenta = descripcionTodosProductos;
                    apartadoN.TotalVenta = _totalVenta2;
                    apartadoN.CantidadAbonada = Convert.ToDouble(cantidadPagada);
                    apartadoN.FechaUltimoPago = fechaVenta;
                    apartadoN.TotalRestante = _totalVenta2 - Convert.ToDouble(cantidadPagada);
                    apartadoN.Estatus = "Pendiente";

                    venSQL.RN_nuevo_Apartado(apartadoN);

                    cargarApartados();
                }

                MessageBox.Show("Venta: " + folio + " Registrada ");
               // MessageBox.Show(GetDefaultPrinterName());
                Imprimir(folio, clienteVenta, _subTotal.ToString(), _descuento.ToString(),_totalVenta2.ToString(),Aproductos,ACantidades,AImportes,APrecios, cantidadPagada, _cambio);

                limpiarVentas();
                P_Cargar_Todo_Inventario();
            }

           


        }

        private static void Imprimir(string folio, string cliente, string subtotal, string desc, string total, string[] products, string[] cantidades, string[] importes, string[] preciosUnitario, string canPago, string cambio) 
        {
            try
            {
                string printerName = GetDefaultPrinterName();
                string logoPath = @"C:\logo\logo.jpeg";
                string message = "¡Gracias por su compra!";
                DateTime currentDate = DateTime.Now;

                /*
                string[] products = { "Valvula Admision y Escape Pulsar NS200 Baisiji (2)", "Filtro de Aceite FZ-16/FZ2.0/Fazzer/Boxer ENGG PLUS",
                    "Tuerca de Eje Trasero C/Rondana Integrada Cromada", "Valvula de Balon", "Tuerca P/Maza Lateral Nacional" };
                string[] cantidades = {"1","10","100","800","5"};
                string[] importes = {"8","20","8000","8000.50","22.50"};
                string[] preciosUnitario = { "8", "20", "8000", "8000", "22.50" }; */

                using (PrintDocument pd = new PrintDocument())
                {
                    pd.PrinterSettings.PrinterName = printerName;
                    pd.PrintPage += (sender, e) =>
                    {
                        Graphics graphics = e.Graphics;

                        // Cargar el logo
                        Image logo = Image.FromFile(logoPath);
                        graphics.DrawImage(logo, new RectangleF(10, 0, 250, 80));

                        // Imprimir la fecha y productos
                        string fecha = currentDate.ToString("dd/MM/yyyy");
                        string hora = currentDate.ToString("HH:mm:ss");
                        string direccion = "Emiliano Zapata 52, San Juan Piaxtla, Izucar de Mata.";
                        string telefonos = "Tel: 2434369277, Cel: 2431126003";
                        /*
                        string folio = "Fo291203123";
                        string cliente = "Cliente General";
                        string subtotal = "8000";
                        string desc = "10";
                        string total = "7000";
                        */
                        int yPos = 100;
                         //int yPos = 10;
                        
                        graphics.DrawString("Folio:" + folio, new Font("Arial", 8), Brushes.Black, new PointF(75, yPos));
                          yPos += 20;
                          graphics.DrawString("Fecha:"+fecha, new Font("Arial", 8), Brushes.Black, new PointF(10, yPos));
                          graphics.DrawString("Hora:" + hora, new Font("Arial", 8), Brushes.Black, new PointF(170, yPos));
                          yPos += 20;

                          graphics.DrawString(direccion, new Font("Arial", 8), Brushes.Black, new PointF(10, yPos));
                          yPos += 20;

                          graphics.DrawString(telefonos, new Font("Arial", 8), Brushes.Black, new PointF(30, yPos));
                          yPos += 20;

                          graphics.DrawString("Cliente:" + cliente, new Font("Arial", 8), Brushes.Black, new PointF(10, yPos));
                          yPos += 20;

                          graphics.DrawString("________________________________________________________", new Font("Arial", 8), Brushes.Black, new PointF(4, yPos));
                          yPos += 20;

                        
                        graphics.DrawString("C", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new PointF(3, yPos));
                        graphics.DrawString("Descripcion", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new PointF(22, yPos));
                        graphics.DrawString("P.U", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new PointF(205, yPos));
                        graphics.DrawString("Import", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new PointF(245, yPos));
                        yPos += 20;

                        for (int i = 0; i < products.Length; i++)
                        {
                            string producto = products[i];
                            string cantidad = cantidades[i];
                            string importe = importes[i];
                            string precioU = preciosUnitario[i];

                            string productoLinea = $"{importe:C}";
                            string cantidadLinea = $"{cantidad:C}";
                            string precioULinea = $"{precioU:C}";

                            // Imprime el precio a la derecha
                            graphics.DrawString(cantidadLinea, new Font("Arial", 8), Brushes.Black, 1, yPos);
                            graphics.DrawString(precioULinea, new Font("Arial", 8), Brushes.Black, 205, yPos);
                            graphics.DrawString(productoLinea, new Font("Arial", 8), Brushes.Black, 245, yPos);

                            // Calcula el tamaño del texto para ajustar el nombre del producto
                            SizeF textSize = graphics.MeasureString(producto, new Font("Arial", 8));

                            if (textSize.Width > 190) // Si el texto es demasiado ancho, divídelo en varias líneas
                            {
                                string[] palabras = producto.Split(' ');
                                string lineaActual = palabras[0];

                                for (int j = 1; j < palabras.Length; j++)
                                {
                                    if (graphics.MeasureString(lineaActual + " " + palabras[j], new Font("Arial", 8)).Width > 200)
                                    {
                                        graphics.DrawString(lineaActual, new Font("Arial", 8), Brushes.Black, 22, yPos);
                                        yPos += 10;

                                        lineaActual = palabras[j];
                                    }
                                    else
                                    {
                                        lineaActual += " " + palabras[j];
                                    }
                                }

                                graphics.DrawString(lineaActual, new Font("Arial", 8), Brushes.Black, 22, yPos);
                                yPos += 15;
                            }
                            else
                            {
                                graphics.DrawString(producto, new Font("Arial", 8), Brushes.Black, 22, yPos);
                                yPos += 15;
                            }
                        
                            
                        }
                       

                        graphics.DrawString("________________________________________________________", new Font("Arial", 8), Brushes.Black, new PointF(4, yPos));
                        yPos += 15;

                        graphics.DrawString("SubTotal: $"+subtotal, new Font("Arial", 8), Brushes.Black, new PointF(180, yPos));
                        yPos += 12;

                        graphics.DrawString("Se desconto: "+desc+"%", new Font("Arial", 8), Brushes.Black, new PointF(195, yPos));
                        yPos += 12;

                        graphics.DrawString("Total: $"+total, new Font("Arial", 8), Brushes.Black, new PointF(196, yPos));
                        yPos += 20;

                        graphics.DrawString("Se recibio: $" + canPago, new Font("Arial", 8), Brushes.Black, new PointF(170, yPos));
                        yPos += 20;

                        graphics.DrawString("Cambio: $" + cambio, new Font("Arial", 8), Brushes.Black, new PointF(170, yPos));
                        yPos += 20;

                        graphics.DrawString(message, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new PointF(50, yPos));

                        yPos += 10;

                        //graphics.DrawString(".", new Font("Arial", 8), Brushes.Black, new PointF(4, yPos));
                        

                        string autocutCommand = "\x1B\x69"; // Comando genérico para autocorte
                        graphics.DrawString(autocutCommand, new Font("Arial",8), Brushes.Black, 0,yPos);

                        e.HasMorePages = false;
                    };

                    pd.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hay problemas al imprimir: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private static string GetDefaultPrinterName()
        {
            PrinterSettings settings = new PrinterSettings();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                settings.PrinterName = printer;
                if (settings.IsDefaultPrinter)
                {
                    return printer;
                }
            }
            return null;
        }

        private void Actualizar_Cantidad(int id, int cantidad)
        {
            DataRow productoRow = productosParaVenta.Rows.Find(id);
            string cantidadOriginal = productoRow["cantidadActual"].ToString();

            RN_Producto obj = new RN_Producto();

           // int nuevaCantidad = Int32.Parse(cantidadOriginal) - cantidad;

            try
            {
                obj.RN_actualizar_Cantidad(id, Int32.Parse(cantidadOriginal));
                //P_Cargar_Todo_Inventario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void lsv_venta_SizeChanged(object sender, EventArgs e)
        {
        }

        private void SubMenu_Person_Opening(object sender, CancelEventArgs e)
        {
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (lsv_venta.SelectedItems.Count == 0)
            {
                MessageBox.Show("Por favor seleccionar Producto");
                return;
            }
            else
            {
                //MessageBox.Show(lsv_venta.SelectedItems[0].SubItems[3].Text);
                if (lsv_venta.SelectedItems[0].SubItems[6].Text== "SERVICIO") 
                {
                    double variableTotal;
                    String variable;

                    variable = lsv_venta.SelectedItems[0].SubItems[7].Text;
                    variableTotal = Convert.ToDouble(variable);
                    double valorAntiguo = Convert.ToDouble(lb_Total.Text);
                    lb_Total.Text = Convert.ToString(valorAntiguo - variableTotal);

                    lbl_totalFinal.Text = lb_Total.Text;

                    lsv_venta.Items.RemoveAt(lsv_venta.SelectedIndices[0]);
                }
                else
                {
                    double variableTotal;
                    String variable;

                    string _id = lsv_venta.SelectedItems[0].SubItems[0].Text;
                    DataRow productoRow = productosParaVenta.Rows.Find(Convert.ToInt32(_id));
                    string cantidadPro = lsv_venta.SelectedItems[0].SubItems[3].Text;
                    int cantidadRest = Convert.ToInt32(productoRow["cantidadActual"]);

                    // Actualizar la cantidad
                    productoRow["cantidadActual"] = Convert.ToInt32(cantidadPro) + (cantidadRest); // Nueva cantidad deseada
                    productosParaVenta.AcceptChanges();

                    for (int i = lsv_venta.SelectedIndices.Count - 1; i >= 0; i--)
                    {
                        variable = lsv_venta.SelectedItems[i].SubItems[7].Text;
                        variableTotal = Convert.ToDouble(variable);
                        double valorAntiguo = Convert.ToDouble(lb_Total.Text);
                        lb_Total.Text = Convert.ToString(valorAntiguo - variableTotal);
                        lbl_totalFinal.Text = lb_Total.Text;

                        lsv_venta.Items.RemoveAt(lsv_venta.SelectedIndices[i]);

                    }
                }
                
            }
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

        private void lb_numVenta_Click(object sender, EventArgs e)
        {

        }

        private void elTabPage4_Click(object sender, EventArgs e)
        {

        }

        private void txt_pago_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txt_pago_Enter(object sender, EventArgs e)
        {
            double pago;
            if (txt_pago.Text == "")
            {
                pago = 0;
            }
            else
            {
                pago = Convert.ToDouble(txt_pago.Text);
            }

            double total = Convert.ToDouble(lbl_totalFinal.Text);
            lbl_cambioVenta.Text = Convert.ToString(pago - total);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           MessageBox.Show(GetDefaultPrinterName());
           // Imprimir();
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Establece el estado inicial del formulario en Normal
            this.WindowState = FormWindowState.Maximized;

        }

        private void elButton1_Click(object sender, EventArgs e)
        {
            elTab1.SelectedTabPageIndex = 4;
            elTabPage4.Visible = true;
            P_Cargar_Todo_Inventario();
        }

        private void btn_cancel_horio_Click(object sender, EventArgs e)
        {
            Frm_Registro_Compradores cliente = new Frm_Registro_Compradores();
            cliente.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Configurar_ListView_Clientes();
            P_Cargar_Todos_Clientes();

        }

        public void pruebaMensajeInterfaz()
        {
            lsv_person.Items.Clear();
        }

        private void btn_importar_Click(object sender, EventArgs e)
        {
            Frm_Importar_Datos imp = new Frm_Importar_Datos();
            imp.ShowDialog();
        }

        private void elButton2_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            Frm_Editar_Compradores per = new Frm_Editar_Compradores();
            string idper = "";

            if (lsv_cliente.SelectedItems.Count == 0)
            {
                fil.Show();
                ver.Lbl_Msm1.Text = "Por favor, Seleccione el cliente que quiere Editar";
                ver.ShowDialog();
                fil.Hide();
                return;
            }
            else
            {
                var lis = lsv_cliente.SelectedItems[0];
                idper = lis.SubItems[0].Text;

                // MessageBox.Show("El ID es : "+ idper);

                fil.Show();
                per.Tag = idper;
                per.ShowDialog();
                fil.Hide();

                if (per.Tag.ToString() == "A")
                {
                    P_Cargar_Todo_Inventario();
                }
            }
        }

        private void elButton3_Click(object sender, EventArgs e)
        {
            string idcli = "";

            if (lsv_cliente.SelectedItems.Count == 0)
            {
                MessageBox.Show("Por favor seleccionar Cliente");
                return;
            }
            else
            {
                var lis = lsv_cliente.SelectedItems[0];
                idcli = lis.SubItems[0].Text;

                RN_Cliente obj = new RN_Cliente();

                if (MessageBox.Show("¿Desea al cliente" + idcli + " ?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    obj.RN_Eliminar_Cliente(idcli);
                    P_Cargar_Todos_Clientes();
                }
                else
                {
                    P_Cargar_Todos_Clientes();
                }
            }
        }

        private void elDivider2_Click(object sender, EventArgs e)
        {

        }

        private void btn_formularioServicio_Click(object sender, EventArgs e)
        {
            btn_formularioServicio.Visible = false;
            txt_codigo.Visible = true;
            txt_costo.Visible = true;
            txt_descripcion.Visible = true;
            btn_AgregarServicio.Visible = true;
            lbl_codigo.Visible = true;
            lbl_descripcion.Visible = true;
            lbl_costo.Visible = true;
        }


        private void btn_AgregarServicio_Click(object sender, EventArgs e)
        {
            if (txt_codigo.Text!="" && txt_descripcion.Text!="" && txt_costo.Text!="") 
            {
                int valorNumerico;   
                if (int.TryParse(txt_costo.Text, out valorNumerico))
                {
                    ListViewItem list = new ListViewItem("00"); //Cabecera ListView

                    list.SubItems.Add(txt_codigo.Text);
                    list.SubItems.Add(txt_descripcion.Text);
                    list.SubItems.Add("1");
                    list.SubItems.Add(txt_costo.Text);
                    list.SubItems.Add(txt_costo.Text);
                    list.SubItems.Add("SERVICIO");

                    list.SubItems.Add(txt_costo.Text);
                    list.SubItems.Add("SERVICIO");

                    lsv_venta.Items.Add(list); //Si no se pone el listView no se llenara

                    //Actualizar la suma del total
                    double sumaTotal = Convert.ToDouble(lb_Total.Text);
                    double total = double.Parse(txt_costo.Text);

                    sumaTotal = sumaTotal + total;

                    lb_Total.Text = Convert.ToString(sumaTotal);
                    lbl_totalFinal.Text = lb_Total.Text;

                    //Limpiar formulario
                    txt_codigo.Text = "";
                    txt_costo.Text = "";
                    txt_descripcion.Text = "";

                    OcultarRegistroServicio();
                }
                else
                {
                    MessageBox.Show("Ingreso un numero en el monto");
                }
               
            }
            else
            {
                MessageBox.Show("Rellene todos los campos");
            }
 
        }

        private void OcultarRegistroServicio()
        {
            btn_formularioServicio.Visible = true;
            txt_codigo.Visible = false;
            txt_costo.Visible = false;
            txt_descripcion.Visible = false;
            btn_AgregarServicio.Visible = false;
            lbl_codigo.Visible = false;
            lbl_descripcion.Visible = false;
            lbl_costo.Visible = false;
        }

        private void precioEspecialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lsv_venta.SelectedItems.Count == 0)
            {
                MessageBox.Show("Por favor seleccionar Producto");
                return;
            }
            else
            {
                if (lsv_venta.SelectedItems[0].SubItems[6].Text == "SERVICIO")
                {
                    MessageBox.Show("Es un Servicio");
                }
                else 
                {
                    //Obtener valores
                    string _id = lsv_venta.SelectedItems[0].SubItems[0].Text;

                    DataRow productoRow = productosParaVenta.Rows.Find(Convert.ToInt32(_id));

                    string totalOriginal = lsv_venta.SelectedItems[0].SubItems[7].Text;
                    string precioEspecial = productoRow["precioEspecial"].ToString();
                    string cantidad = lsv_venta.SelectedItems[0].SubItems[3].Text;
                    

                    double total = double.Parse(precioEspecial) * Int32.Parse(cantidad);

                    double diferencia = double.Parse(totalOriginal) - total;

                    //Cambiar Valores

                    lsv_venta.SelectedItems[0].SubItems[5].Text = precioEspecial;
                    lsv_venta.SelectedItems[0].SubItems[6].Text = "ESPECIAL";
                    lsv_venta.SelectedItems[0].SubItems[7].Text = total.ToString();

                    MessageBox.Show("Precio Especial Aplicado");

                    //Modificar Suma Total
                    double valorAntiguo = Convert.ToDouble(lb_Total.Text);
                    lb_Total.Text = Convert.ToString(valorAntiguo - diferencia);
                    lbl_totalFinal.Text = lb_Total.Text;
                }

            }
        }

        private void toolStripSeparator16_Click(object sender, EventArgs e)
        {

        }

        private void lb_Total_Click(object sender, EventArgs e)
        {

        }

        private void btn_aplicarDescuento_Click(object sender, EventArgs e)
        {
            double subTotal = double.Parse(lb_Total.Text);
            double porcentaje = double.Parse(txt_porcentaje.Text);

            double valorDescuento = (subTotal * porcentaje) / 100;

            lbl_descuentoTotal.Text = valorDescuento.ToString();

            lbl_totalFinal.Text = (subTotal - valorDescuento).ToString();
        }

        private void bnt_formularioDescuento_Click(object sender, EventArgs e)
        {
            bnt_formularioDescuento.Visible = false;
            txt_porcentaje.Visible = true;
            lbl_descuento.Visible = true;
            btn_aplicarDescuento.Visible = true;

        }

        private void txt_porcentaje_TextChanged(object sender, EventArgs e)
        {

        }

        private void llenarComboBox() 
        {
            cmBox_clientes.DataSource = listaDeClientes;
            cmBox_clientes.DisplayMember = "nombre_completo"; 
            cmBox_clientes.ValueMember = "nombre_completo";

            string valorPorDefecto = "Cliente General"; // El valor que deseas establecer como por defecto
            cmBox_clientes.SelectedValue = valorPorDefecto;

            List<string> formas = new List<string>
            {
                "Efectivo",
                "Transferencia",
                "Credito"
            };

            cmboxFormaPago.DataSource = formas;

        }

        private void precioMayoreoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            if (lsv_venta.SelectedItems.Count == 0)
            {
                MessageBox.Show("Por favor seleccionar Producto");
                return;
            }
            else
            {
                if (lsv_venta.SelectedItems[0].SubItems[6].Text == "SERVICIO")
                {
                    MessageBox.Show("Es un Servicio");
                }
                else
                {
                    //Obtener valores
                    string _id = lsv_venta.SelectedItems[0].SubItems[0].Text;

                    DataRow productoRow = productosParaVenta.Rows.Find(Convert.ToInt32(_id));

                    string totalOriginal = lsv_venta.SelectedItems[0].SubItems[7].Text;
                    string precioEspecial = productoRow["precioMayoreo"].ToString();
                    string cantidad = lsv_venta.SelectedItems[0].SubItems[3].Text;


                    double total = double.Parse(precioEspecial) * Int32.Parse(cantidad);

                    double diferencia = double.Parse(totalOriginal) - total;

                    //Cambiar Valores

                    lsv_venta.SelectedItems[0].SubItems[5].Text = precioEspecial;
                    lsv_venta.SelectedItems[0].SubItems[6].Text = "MAYOREO";
                    lsv_venta.SelectedItems[0].SubItems[7].Text = total.ToString();

                    MessageBox.Show("Precio de Mayoreo Aplicado");

                    //Modificar Suma Total
                    double valorAntiguo = Convert.ToDouble(lb_Total.Text);
                    lb_Total.Text = Convert.ToString(valorAntiguo - diferencia);
                    lbl_totalFinal.Text = lb_Total.Text;
                }

            }
        }

        private void lsv_person_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;

            // Obtener el valor de la segunda columna
            int cantidad = Int32.Parse(e.Item.SubItems[3].Text);
            int cantidadMinima = Int32.Parse(e.Item.SubItems[4].Text);
            // Comparar con el valor específico y cambiar el color de fondo
            if (cantidad <= cantidadMinima)
            {
                e.Item.BackColor = Color.Orange;
            }

        }

        private void lsv_person_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            Console.WriteLine("Llamada al metodo pintar");
            // Si es la columna 2 (índice 1), resalta el texto
            if (e.ColumnIndex == 2)
            {
                Console.WriteLine("Llamada al metodo pintar de la columna 2");

                e.DrawBackground();
                e.Graphics.DrawString(e.SubItem.Text, lsv_person.Font, Brushes.Red, e.Bounds);
            }
            else
            {
                // Si no es la columna 2, dibuja el fondo y el texto de forma predeterminada
                e.DrawDefault = true;
            }
        }

        private void pnl_titu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void elTabPage5_Click(object sender, EventArgs e)
        {

        }

        private void elButton4_Click(object sender, EventArgs e)
        {
            elTab1.SelectedTabPageIndex = 5;
            elTabPage6.Visible = true;
            P_Cargar_Todo_Inventario();
        }

        private void elButton7_Click(object sender, EventArgs e)
        {
            
            DateTime selectedDate = dtp_fecha.Value;
            string fechaFormato = selectedDate.ToString("yyyy-MM-dd");

            string descripcion = txt_fechaGasto.Text;
            double monto = double.Parse(txt_montoGasto.Text);

            RN_Gastos obj = new RN_Gastos();
            EN_Gastos gas = new EN_Gastos();

            gas.fecha = DateTime.Parse(fechaFormato);
            gas.descripcion = descripcion;
            gas.monto = monto;

            obj.RN_Registrar_Gasto(gas);

            DateTime fActual = DateTime.Now;
            dtp_fecha.Value = fActual;
            txt_montoGasto.Text = "";
            txt_fechaGasto.Text = "";

            P_Cargar_Todo_Gastos();
        }

        private void elTabPage6_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void lsv_listaGastos_DoubleClick(object sender, EventArgs e)
        {
            DateTime variable;

            variable = DateTime.Parse(lsv_listaGastos.SelectedItems[0].SubItems[1].Text);

            lbl_idGasto.Visible = true;
            lbl_idGasto.Text = lsv_listaGastos.SelectedItems[0].SubItems[0].Text;
            dtp_fecha.Value = variable;
            txt_fechaGasto.Text = lsv_listaGastos.SelectedItems[0].SubItems[2].Text;
            txt_montoGasto.Text = lsv_listaGastos.SelectedItems[0].SubItems[3].Text;

        }

        private void elButton6_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dtp_fecha.Value;
            string fechaFormato = selectedDate.ToString("yyyy-MM-dd");

            string descripcion = txt_fechaGasto.Text;
            double monto = double.Parse(txt_montoGasto.Text);

            RN_Gastos obj = new RN_Gastos();
            EN_Gastos gas = new EN_Gastos();

            gas.fecha = DateTime.Parse(fechaFormato);
            gas.descripcion = descripcion;
            gas.monto = monto;

            obj.RN_Actualizar_Gasto(gas, Int32.Parse(lbl_idGasto.Text));

            lbl_idGasto.Visible = false;
            lbl_idGasto.Text = "0";

            DateTime fActual = DateTime.Now;
            dtp_fecha.Value = fActual;
            txt_montoGasto.Text = "";
            txt_fechaGasto.Text = "";

            P_Cargar_Todo_Gastos();

        }

        private void btn_buscarFolio_Click(object sender, EventArgs e)
        {
            Configurar_ListView_DatosDevoluciones();
            RN_Ventas obj = new RN_Ventas();
            DataTable dato = new DataTable();
            dato = obj.RN_Buscar_Venta_porFolio(txt_BusquedaFolio.Text);

            if (dato.Rows.Count > 0)
            {
                Llenar_ListView_DatosDescuento(dato);
                btn_realizarDevolucion.Visible = true;
                
            }
            else
            {
               
                MessageBox.Show("No hay coincidencias");
                lsv_datosDevolucion.Clear();
            }
                       
            txt_BusquedaFolio.Text = "";
        }

        private void btn_realizarDevolucion_Click(object sender, EventArgs e)
        {
            RN_Ventas obj = new RN_Ventas();
            RN_Producto obj2 = new RN_Producto();

            obj.RN_actualizar_Estatus(lbl_folioDevolucion.Text, lbl_productoDevolucion.Text);

            lbl_folioDevolucion.Text = "Folio";
            lbl_fechaDevolucion.Text = "Fecha";
            lbl_clienteDevolucion.Text ="Cliente";
            lbl_subTotalDevolucion.Text = "0";
            lbl_descuentoDevolucion.Text = "0";
            lbl_totalDevolucion.Text = "0";
            lbl_productoDevolucion.Text = "0";

            if (lsv_datosDevolucion.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lsv_datosDevolucion.SelectedItems[0];
                string id = selectedItem.SubItems[2].Text;
                string cantidad = selectedItem.SubItems[4].Text;

                if (id != "0")
                {
                    obj2.RN_actualizar_CantidadDevolucion(int.Parse(id), int.Parse(cantidad));
                }
            }

          /*  foreach (ListViewItem item in lsv_datosDevolucion.Items)
            { 
                if (item.SubItems[1].Text != "0") 
                {
                    obj2.RN_actualizar_CantidadDevolucion(int.Parse(item.SubItems[1].Text), int.Parse(item.SubItems[3].Text));
                }
                
            }*/

            lsv_datosDevolucion.Clear();

            P_Cargar_Todo_Lista_Devoluciones();

            btn_realizarDevolucion.Visible = false;
        }

        private void elLabel20_Click(object sender, EventArgs e)
        {

        }

        private void elLabel45_Click(object sender, EventArgs e)
        {

        }

        private void lsv_cliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void txt_pago_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_PagoEfectivo_Enter(object sender, EventArgs e)
        {
           
        }

        private void txt_PagoEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                double pago;
                if (txt_PagoEfectivo.Text == "")
                {
                    pago = 0;
                }
                else
                {
                    pago = Convert.ToDouble(txt_PagoEfectivo.Text);
                }

                double total = Convert.ToDouble(lbl_totalFinal.Text);
                lbl_cambioVenta.Text = Convert.ToString(pago - total);

                e.Handled = true;
            }
        }

        private void elTabPage6_Click(object sender, EventArgs e)
        {

        }

        private void elTabPage2_Enter(object sender, EventArgs e)
        {
            Console.WriteLine("******************************************************************    Se cargo Tab2");
        }

        private void elTabPage2_TabIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Pagina de Productos");
        }

        private void btn_bajosInventario_Click(object sender, EventArgs e)
        {
            RN_Producto obj = new RN_Producto();
            DataTable dato = new DataTable();

            dato = obj.RN_Lista_Producto_Bajos();

            if (dato.Rows.Count > 0)
            {
                Llenar_ListView(dato);
            }
            else
            {
                lsv_person.Items.Clear();
            }
        }

        private void sumaDePrecios()
        {
            double suma = 0.0; // Variable para almacenar la suma

            // Recorre todos los elementos en el ListView
            foreach (ListViewItem item in lsv_venta.Items)
            {
                // Asegúrate de que haya suficientes elementos en la columna
                if (item.SubItems.Count > 1)
                {
                    // Convierte el texto en la columna a un valor numérico (en este caso, asumimos valores double)
                    double valor;
                    if (double.TryParse(item.SubItems[7].Text, out valor))
                    {
                        // Suma el valor a la suma total
                        suma += valor;
                    }
                    else
                    {
                        // Maneja el caso en el que el texto no se pueda convertir a un valor numérico si es necesario
                        // Puedes mostrar un mensaje de error o tomar alguna otra acción
                    }
                }
            }

            // El resultado estará en la variable "suma"
            Console.WriteLine("La suma de la columna 2 es: " + suma);
            lb_Total.Text = suma.ToString();
            double totalFinalT = double.Parse(lb_Total.Text) - double.Parse(lbl_descuentoTotal.Text);
            lbl_totalFinal.Text = totalFinalT.ToString();
            //Asegúrate de ajustar el índice de la columna(item.SubItems[1]) según la columna que deseas sumar. Además, ten en cuenta que este ejemplo asume que los valores en la columna son números dobles. Si los valores son de otro tipo, debes ajustar el tipo de datos en el que almacenas la suma y la conversión adecuada.

        }

        private void lsv_venta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               

                string cantidad;
                int cantidadNumerica;

                cantidad = Interaction.InputBox("Ingrese la cantidad");
                 

                if (int.TryParse(cantidad, out cantidadNumerica))
                {
                    ListViewItem selectedItem = lsv_venta.SelectedItems[0];
                    string _id = selectedItem.SubItems[0].Text;

                    DataRow productoRow = productosParaVenta.Rows.Find(Convert.ToInt32(_id));


                    string cantidadOriginal = productoRow["cantidadActual"].ToString();
                   // MessageBox.Show(cantidadOriginal + "---" + selectedItem.SubItems[3].Text);
                    if (cantidadNumerica <= Convert.ToInt32(cantidadOriginal)+ Convert.ToInt32(selectedItem.SubItems[3].Text))
                    {
                        productoRow["cantidadActual"] = (Convert.ToInt32(cantidadOriginal) + Convert.ToInt32(selectedItem.SubItems[3].Text)) - (cantidadNumerica); // Nueva cantidad deseada
                        //MessageBox.Show("Si alcanza");
                        selectedItem.SubItems[3].Text = cantidadNumerica.ToString();
                        double nuevoTotal = Convert.ToDouble(cantidadNumerica) * Convert.ToDouble(selectedItem.SubItems[5].Text);
                        selectedItem.SubItems[7].Text = nuevoTotal.ToString();

                        sumaDePrecios();
                    }
                    else
                    {
                        MessageBox.Show("Cantidad Insuficiente");
                    }
                   
                }
                else
                {
                    MessageBox.Show("Ingrese un número");
                }
              
            }
        }

        private void lsv_person_MouseHover(object sender, EventArgs e)
        {
            /*ListViewItem item = lsv_person.GetItemAt(lsv_person.Location.X, lsv_person.Location.Y);

            if (item != null)
            {
                toolTip2.SetToolTip(lsv_person, item.SubItems[2].Text);
                MessageBox.Show(item.SubItems[2].Text);
            }
            else
            {
                toolTip2.Hide(lsv_person);
            }*/
        }

        private void cmboxFormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
           // MessageBox.Show(cmboxFormaPago.SelectedValue.ToString());
        }

        private void dataGV_Credito_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Asegurarse de que se hizo clic en una fila válida
            {

                DataGridViewRow filaSeleccionada = dataGV_Credito.Rows[e.RowIndex];

                // Ahora puedes acceder a los valores de las celdas de la fila seleccionada
                lbl_idAbono.Text = filaSeleccionada.Cells["id"].Value.ToString();
                txt_compraCredito.Text = filaSeleccionada.Cells["folioVenta"].Value.ToString();
                lbl_restanteAbono.Text = filaSeleccionada.Cells["totalRestante"].Value.ToString();
                txt_clienteApartado.Text = filaSeleccionada.Cells["cliente"].Value.ToString();
                txt_totalCompra.Text = filaSeleccionada.Cells["totalVenta"].Value.ToString();
            }
        }

        private void btn_registroAbono_Click(object sender, EventArgs e)
        {
           
            RN_Ventas ventas1 = new RN_Ventas();
            EN_Ventas ven = new EN_Ventas();

            String hora = DateTime.Now.ToString("HH:mm");

            string folioVenta = Convert.ToString(txt_compraCredito.Text);
            DateTime fechaAbono = DateTime.Now;
            double abono = Convert.ToDouble(txt_abonoPago.Text);
            int id = Convert.ToInt32(lbl_idAbono.Text);
            double restante = Convert.ToDouble(lbl_restanteAbono.Text) - abono;

            ventas1.RN_Actualizar_Apartado(abono,fechaAbono, restante, id);
            

            ven.FolioVenta = folioVenta;
            ven.FechaVenta = fechaAbono;
            ven.HoraVenta = hora;
            ven.FormaPago = "Efectivo";
            ven.Cliente = Convert.ToString(txt_clienteApartado.Text);
            ven.idProducto = 00;
            ven.CodigoProducto = folioVenta;
            ven.DescripcionProducto = "Abono:"+fechaAbono+":"+folioVenta;
            ven.TipoProducto = "Credito";
            ven.Nota = "Pago/Abono";
            ven.CantidadProducto = 1;
           // MessageBox.Show(txt_totalCompra.Text);
            ven.PrecioVenta = Convert.ToDouble(txt_totalCompra.Text);
            ven.PrecioFinal = Convert.ToDouble(txt_totalCompra.Text);
            ven.ImporteProducto = Convert.ToDouble(txt_totalCompra.Text);
            ven.SubTotal = Convert.ToDouble(txt_totalCompra.Text);
            ven.PorcentajeDescuento = 0;
            ven.TotalVenta = abono;
            ven.Estatus = "Concretada";

             ventas1.RN_registrar_Venta(ven);


            limpiarCamposAbono();
            cargarApartados();

        }

        private void limpiarCamposAbono() 
        {
            lbl_idAbono.Text = "0";
            txt_compraCredito.Text = "";
            lbl_restanteAbono.Text = "0";
            txt_abonoPago.Text = "";
            txt_clienteApartado.Text = "";
            txt_totalCompra.Text = "";
        }

        private void btn_anticipo_Click(object sender, EventArgs e)
        {
            txt_Anticipo.Visible = true;
            btn_aplicarAnticipo.Visible = true;

        }

        private void btn_aplicarAnticipo_Click(object sender, EventArgs e)
        {
            double subTotal = double.Parse(lb_Total.Text);
            double anticipo = double.Parse(txt_Anticipo.Text);

            double valorFinal = (subTotal-anticipo);

            lbl_descuentoTotal.Text = anticipo.ToString();

            lbl_totalFinal.Text = (valorFinal).ToString();
        }

        private void lsv_datosDevolucion_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("HOla");
        }

        private void lsv_datosDevolucion_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lsv_datosDevolucion.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lsv_datosDevolucion.SelectedItems[0];
                string descripcion = selectedItem.SubItems[1].Text;

                MessageBox.Show(descripcion);
                lbl_productoDevolucion.Text = descripcion;
            }


        }
    }
}
