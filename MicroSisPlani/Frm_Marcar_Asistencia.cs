
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using Prj_Capa_Datos;
using Prj_Capa_Entidad;
using Prj_Capa_Negocio;
using DPFP;
using System.IO;
using MicroSisPlani.Msm_Forms;
using SpreadsheetLight;
using SpreadsheetLight.Drawing;
using DocumentFormat.OpenXml.Spreadsheet;

namespace MicroSisPlani
{
    public partial class Frm_Marcar_Asistencia : Form
    {
        public Frm_Marcar_Asistencia()
        {
            InitializeComponent();
        }

        private void lbl_msm_Click(object sender, EventArgs e)
        {
        }
        private void Frm_Marcar_Asistencia_Load(object sender, EventArgs e)
        {
            cbo_tipoCorte.SelectedIndex = 0;
            String fecha = DateTime.Now.ToString("yyyy-MM-dd");

            //MessageBox.Show(fecha);
         //   MessageBox.Show(fecha);
           // corteDelDia(fecha);

            Configurar_ListView_ListaVentas();
            P_Cargar_Todas_Ventas(fecha);
        }
        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_hora.Text = DateTime.Now.ToString("H:mm:ss");
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

        private void timer4_Tick(object sender, EventArgs e)
        {
        }

        private void lbl_hora_Click(object sender, EventArgs e)
        {
        }

        private void corteDelDia(DataTable datos) 
        {
           // int totalArticulos=0;
            double totalvendido=0;
            double totalDevuelto = 0;
            double totalGastos = 0;
            DataTable dataGastos = new DataTable();

            RN_Gastos obj = new RN_Gastos();
            dataGastos = obj.RN_Listar_Gastos_Mes();

            if (dataGastos.Rows.Count>0) 
            {
                for (int i = 0; i < dataGastos.Rows.Count; i++)
                {
                    // MessageBox.Show(datos.Rows[i][18].ToString());
                    totalGastos = totalGastos + Convert.ToDouble(dataGastos.Rows[i][3]);
                }
                lbl_gastosTotal.Text = totalGastos.ToString();
            }

            if (datos.Rows.Count > 0) 
            {
                for (int i = 0; i < datos.Rows.Count; i++)
                {
                   // MessageBox.Show(datos.Rows[i][18].ToString());
                    totalvendido = totalvendido + Convert.ToDouble(datos.Rows[i][17]);

                    if(Convert.ToString(datos.Rows[i][18])=="Devolucion")
                    {
                        totalDevuelto = totalDevuelto + Convert.ToDouble(datos.Rows[i][14]);
                    }
                }

                lb_num_Ventas.Text = Convert.ToString(datos.Rows.Count);
                Console.WriteLine(totalvendido);
                Console.WriteLine(totalDevuelto);
                lb_totalVentido.Text = "$" + Convert.ToString(totalvendido-totalDevuelto);
            }
           
        }

        private void corteSemana()
        {
            RN_Ventas obj = new RN_Ventas();
            DataTable data = new DataTable();
            data = obj.RN_Lista_Ventas_Semana();

            int totalArticulos = 0;
            double totalvendido = 0;

            for (int i = 0; i < data.Rows.Count; i++)
            {
                totalArticulos = totalArticulos + Convert.ToInt32(data.Rows[i][1]);
                totalvendido = totalvendido + Convert.ToDouble(data.Rows[i][2]);
            }

            lb_num_Ventas.Text = Convert.ToString(data.Rows.Count);
            lb_totalVentido.Text = "$" + Convert.ToString(totalvendido);
        
        }

        private void corteMes()
        {
            RN_Ventas obj = new RN_Ventas();
            DataTable data = new DataTable();
            data = obj.RN_Lista_Ventas_Mes();

            int totalArticulos = 0;
            double totalvendido = 0;

            for (int i = 0; i < data.Rows.Count; i++)
            {
                totalArticulos = totalArticulos + Convert.ToInt32(data.Rows[i][1]);
                totalvendido = totalvendido + Convert.ToDouble(data.Rows[i][2]);
            }

            lb_num_Ventas.Text = Convert.ToString(data.Rows.Count);
            lb_totalVentido.Text = "$" + Convert.ToString(totalvendido);
         
        }

        private void corteEspecifico(string valor, string valor2)
        {
            RN_Ventas obj = new RN_Ventas();
            DataTable data = new DataTable();
            data = obj.RN_Buscar_Venta_Especifica(valor, valor2);

            int totalArticulos = 0;
            double totalvendido = 0;

            for (int i = 0; i < data.Rows.Count; i++)
            {
                totalArticulos = totalArticulos + Convert.ToInt32(data.Rows[i][1]);
                totalvendido = totalvendido + Convert.ToDouble(data.Rows[i][2]);
            }

            lb_num_Ventas.Text = Convert.ToString(data.Rows.Count);
            lb_totalVentido.Text = "$" + Convert.ToString(totalvendido);
 
        }

        private void cbo_tipoCorte_SelectionChangeCommitted(object sender, EventArgs e)
        {
            String fecha = DateTime.Now.ToString("yyyy-MM-dd");

            switch (cbo_tipoCorte.SelectedIndex)
            {
                case 0:
                    lbl_titulo.Visible = true;
                    lbl_titulo.Text = "Del Dia";
                    dtp_fechaInicio.Visible = false;
                    dtp_fechaFin.Visible = false;
                    btn_aceptar.Visible = false;
                    dtp_dia.Visible = false;
                   // corteDelDia(fecha);
                    Configurar_ListView_ListaVentas();
           //         MessageBox.Show(fecha);
                    P_Cargar_Todas_Ventas(fecha);
                    break;
                case 1:
                    lbl_titulo.Visible = false;
                    dtp_fechaInicio.Visible = false;
                    dtp_fechaFin.Visible = false;
                    btn_aceptar.Visible = false;
                    dtp_dia.Visible = true;        
                    lb_num_Ventas.Text = "0";
                    lb_totalVentido.Text = "$0";
                  
                    //corteDelDia(fecha);
                    Configurar_ListView_ListaVentas();
                    break;
                    /*
                case 2:
                    lbl_titulo.Visible = true;
                    lbl_titulo.Text = "De la semana";
                    dtp_fechaInicio.Visible = false;
                    dtp_fechaFin.Visible = false;
                    btn_aceptar.Visible = false;
                    dtp_dia.Visible = false;
                    corteSemana();
                    Configurar_ListView_ListaVentas();
                    P_Cargar_Todas_VentasSemana();
                    break;
                case 3:
                    lbl_titulo.Visible = true;
                    lbl_titulo.Text = "Del Mes";
                    dtp_fechaInicio.Visible = false;
                    dtp_fechaFin.Visible = false;
                    btn_aceptar.Visible = false;
                    dtp_dia.Visible = false;
                    Configurar_ListView_ListaVentas();
                    P_Cargar_Todas_VentasMes();
                    corteMes();
                    break;
                case 4:
                    lbl_titulo.Visible = false;
                    dtp_fechaInicio.Visible = true;
                    dtp_fechaFin.Visible = true;
                    btn_aceptar.Visible = true;
                    dtp_dia.Visible = false;               
                    break;
                    default:
                    MessageBox.Show("Ninguna");
                    break;  */
            }
        }

        private void dtp_dia_ValueChanged(object sender, EventArgs e)
        {
            string fecha = dtp_dia.Value.ToString("yyyy/MM/dd");

            //MessageBox.Show(fecha);

            Configurar_ListView_ListaVentas();
            P_Cargar_Todas_Ventas(fecha);
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            string fechaInicio = dtp_fechaInicio.Value.ToString("yyyy/MM/dd");
            string fechaFin = dtp_fechaFin.Value.ToString("yyyy/MM/dd");

            corteEspecifico(fechaInicio, fechaFin);
            Configurar_ListView_ListaVentas();
            P_Cargar_Todas_VentasFechas(fechaInicio, fechaFin);

        }

        private void Configurar_ListView_ListaVentas()
        {
            var lis = lsv_ventas;

            lis.Columns.Clear();
            lis.Items.Clear();
            lis.View = View.Details;
            lis.GridLines = true;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;

            //Las columnas
            lis.Columns.Add("id", 1, HorizontalAlignment.Center);
            lis.Columns.Add("folio", 130, HorizontalAlignment.Center);
            lis.Columns.Add("fecha", 80, HorizontalAlignment.Center);
            lis.Columns.Add("cliente", 200, HorizontalAlignment.Center);
            lis.Columns.Add("producto", 300, HorizontalAlignment.Center);
            lis.Columns.Add("cantidad", 70, HorizontalAlignment.Center);
            lis.Columns.Add("importe", 70, HorizontalAlignment.Center);
            lis.Columns.Add("subtotal", 70, HorizontalAlignment.Center);
            lis.Columns.Add("descuento", 70, HorizontalAlignment.Center); 
            lis.Columns.Add("total", 70, HorizontalAlignment.Center);
            lis.Columns.Add("estado", 50, HorizontalAlignment.Center);

        }

        private void Llenar_ListView_ProductosVenta(DataTable data)
        {
            lsv_ventas.Items.Clear();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["id"].ToString()); //Cabecera ListView

                list.SubItems.Add(dr["folioVenta"].ToString());
                DateTime fecha = Convert.ToDateTime(dr["fechaVenta"]);
                list.SubItems.Add(fecha.ToString("dd/MM/yyyy"));
                
                list.SubItems.Add(dr["cliente"].ToString());
                list.SubItems.Add(dr["descripcionProducto"].ToString());
                list.SubItems.Add(dr["cantidadProducto"].ToString());
                list.SubItems.Add(dr["importeProducto"].ToString());
                list.SubItems.Add(dr["subTotal"].ToString());
                list.SubItems.Add(dr["porcentajeDescuento"].ToString());
                list.SubItems.Add(dr["totalVenta"].ToString());
                list.SubItems.Add(dr["estatus"].ToString());

                lsv_ventas.Items.Add(list); //Si no se pone el listView no se llenara
            }           
        }

        private void P_Cargar_Todas_Ventas(string fecha)
        {
            RN_Ventas obj = new RN_Ventas();
            DataTable dato = new DataTable();

            dato = obj.RN_Buscar_Venta_porDia(fecha);
            if (dato.Rows.Count > 0)
            {
                Llenar_ListView_ProductosVenta(dato);
                corteDelDia(dato);
            }
            else
            {
                lsv_ventas.Items.Clear();
            }
        }

        private void P_Cargar_Todas_VentasSemana()
        {
            RN_Ventas obj = new RN_Ventas();
            DataTable dato = new DataTable();

            dato = obj.RN_Buscar_TodasVenta_porSemana();
            if (dato.Rows.Count > 0)
            {
                Llenar_ListView_ProductosVenta(dato);
            }
            else
            {
                lsv_ventas.Items.Clear();
            }
        }

        private void P_Cargar_Todas_VentasMes()
        {
            RN_Ventas obj = new RN_Ventas();
            DataTable dato = new DataTable();

            dato = obj.RN_Buscar_TodasVenta_porMes();
            if (dato.Rows.Count > 0)
            {
                Llenar_ListView_ProductosVenta(dato);
            }
            else
            {
                lsv_ventas.Items.Clear();
            }
        }

        private void P_Cargar_Todas_VentasFechas(string valor, string valor2)
        {
            RN_Ventas obj = new RN_Ventas();
            DataTable dato = new DataTable();

            dato = obj.RN_Buscar_TodasVenta_porFechas(valor, valor2);
            if (dato.Rows.Count > 0)
            {
                Llenar_ListView_ProductosVenta(dato);
            }
            else
            {
                lsv_ventas.Items.Clear();
            }
        }

        private void btn_VerTodoPerso_Click(object sender, EventArgs e)
        {
            
            
        }

        private void bt_Explo_Asis_Click(object sender, EventArgs e)
        {
            string fecha = DateTime.UtcNow.ToString("yyyy-MM-dd");

            SLDocument sl = new SLDocument();

            System.Drawing.Bitmap bm = new System.Drawing.Bitmap(@"C:\Users\BJ.DESKTOP-OCAB3JL\Pictures\Camera Roll\automatiza.png");
            byte[] ba;
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                bm.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                ms.Close();
                ba = ms.ToArray();
            }

            SLPicture pic = new SLPicture(ba, DocumentFormat.OpenXml.Packaging.ImagePartType.Png);
            pic.SetPosition(0, 0);
            pic.ResizeInPixels(150, 80);
            sl.InsertPicture(pic);

            sl.SetCellValue("D2", "Reporte de Ventas");
            SLStyle estiloT = sl.CreateStyle();
            estiloT.Font.FontName = "Arial";
            estiloT.Font.FontSize = 14;
            estiloT.Font.Bold = true;
            sl.SetCellStyle("D2", estiloT);
            sl.MergeWorksheetCells("D2", "F2");

            int celdaCabecera = 6, celdaInicio = 6;

            sl.RenameWorksheet(SLDocument.DefaultFirstSheetName, "Ventas");
            sl.SetCellValue("C" + celdaCabecera, "Codigo Venta");
            sl.SetCellValue("D" + celdaCabecera, "Producto");
            sl.SetCellValue("E" + celdaCabecera, "Precio");
            sl.SetCellValue("F" + celdaCabecera, "Cantidad");
            sl.SetCellValue("G" + celdaCabecera, "subtotal");
            sl.SetCellValue("H" + celdaCabecera, "Descuento");
            sl.SetCellValue("I" + celdaCabecera, "Fecha");
            sl.SetCellValue("J" + celdaCabecera, "Total");

            SLStyle estiloEncabezado = sl.CreateStyle();
            estiloEncabezado.Font.FontName = "Arial";
            estiloEncabezado.Font.FontSize = 12;
            estiloEncabezado.Font.Bold = true;
            estiloEncabezado.Font.FontColor = System.Drawing.Color.White;
            estiloEncabezado.Fill.SetPattern(PatternValues.Solid, System.Drawing.Color.Blue, System.Drawing.Color.Blue);
            sl.SetCellStyle("C" + celdaCabecera, "J" + celdaCabecera, estiloEncabezado);

            RN_Ventas obj = new RN_Ventas();
            DataTable data = new DataTable();



            if (cbo_tipoCorte.SelectedIndex == 1)
            {
                fecha = dtp_dia.Value.ToString("yyyy-MM-dd");
            }

            data = obj.RN_Buscar_Venta_porDia(fecha);

            for (int i = 0; i < data.Rows.Count; i++)
            {
                celdaCabecera++;

                DataRow dr = data.Rows[i];

                DateTime fecha1 = Convert.ToDateTime(dr["fecha"]);

                sl.SetCellValue("C" + celdaCabecera, dr["Numero_Venta"].ToString());
                sl.SetCellValue("D" + celdaCabecera, dr["nombre"].ToString());
                sl.SetCellValue("E" + celdaCabecera, dr["precioUnidad"].ToString());
                sl.SetCellValue("F" + celdaCabecera, dr["cantidad"].ToString());
                sl.SetCellValue("G" + celdaCabecera, dr["precioTotal"].ToString());
                sl.SetCellValue("H" + celdaCabecera, dr["descuento"].ToString());
                sl.SetCellValue("I" + celdaCabecera, fecha1.ToString("dd/MM/yyyy"));
                sl.SetCellValue("J" + celdaCabecera, dr["totalVenta"].ToString());
            }

            SLStyle EstiloBorde = sl.CreateStyle();
            EstiloBorde.Border.LeftBorder.BorderStyle = BorderStyleValues.Thin;
            EstiloBorde.Border.LeftBorder.Color = System.Drawing.Color.Black;
            EstiloBorde.Border.TopBorder.BorderStyle = BorderStyleValues.Thin;
            EstiloBorde.Border.RightBorder.BorderStyle = BorderStyleValues.Thin;
            EstiloBorde.Border.BottomBorder.BorderStyle = BorderStyleValues.Thin;
            sl.SetCellStyle("C" + celdaInicio, "J" + celdaCabecera, EstiloBorde);

            sl.AutoFitColumn("C", "J");

            bool falla = false;

            try
            {
                sl.SaveAs(@"c:\Users\BJ.DESKTOP-OCAB3JL\Desktop\Nuevo - Vivero\Proyecto\Reportes\" + fecha + ".xlsx");
            }
            catch (Exception x)
            {
                MessageBox.Show("Error: " + x.Message);
                falla = true;
            }
            if (falla == false)
            {
                MessageBox.Show("Reporte Creado");
            }
        }
    }
}
