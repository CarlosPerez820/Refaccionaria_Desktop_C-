using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prj_Capa_Negocio;
using Prj_Capa_Datos;
using Prj_Capa_Entidad;
using System.IO;
using ExcelDataReader;
using System.Diagnostics;

namespace MicroSisPlani
{
    public partial class Frm_Importar_Datos : Form
    {
        public Frm_Importar_Datos()
        {
            InitializeComponent();
        }

        private void Frm_Importar_Datos_Load(object sender, EventArgs e)
        {

        }

        private void btn_seleccionarArchivo_Click(object sender, EventArgs e)
        {
            string rutaArchivo = string.Empty;

            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Filter = "Archivos de Excel (*.xls;*.xlsx)|*.xls;*.xlsx";


            if (openfile.ShowDialog() == DialogResult.OK)
            {
                rutaArchivo = openfile.FileName;
                txt_rutaArchivo.Text = rutaArchivo;
            }
        }

        private void importacionDeDatos() 
        {
            using (var stream = File.Open(txt_rutaArchivo.Text, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    // Leer la primera hoja de Excel
                    var dataSet = reader.AsDataSet();
                    var dataTable = dataSet.Tables[0];

                    // Conebctar a la base de datos MySQL
                    // MessageBox.Show(dataTable.Rows.Count.ToString());
                    EN_Producto pro = new EN_Producto();
                    BD_Producto obj = new BD_Producto();

                    try
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {

                            pro.Codigo = row[0].ToString();
                            pro.Descripcion = row[1].ToString();
                            pro.Tipo = row[2].ToString();
                            pro.PrecioCompra = Double.Parse(row[3].ToString());
                            pro.PrecioVenta = Double.Parse(row[4].ToString());
                            pro.PrecioMayoreo = Double.Parse(row[5].ToString());
                            pro.PrecioEspecial = Double.Parse(row[6].ToString());
                            pro.Categoria = row[7].ToString();
                            pro.CantidadActual = Int32.Parse(row[8].ToString());
                            pro.CantidadMinima = Int32.Parse(row[9].ToString());

                            //  MessageBox.Show(pro.Codigo + ", " + pro.Descripcion + "," + pro.Tipo + "," + pro.PrecioEspecial);

                            // MessageBox.Show(row[3].ToString());
                            obj.BD_Registrar_Producto(pro);
                        }
                        MessageBox.Show("Los datos se han subido correctamente a la base de datos.");

                        txt_rutaArchivo.Text = "";
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("A ocurrido un Problema por favor revise que su archivo concuerde con los datos");
                       
                    }
                    
                }
            }

            
        }
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            importacionDeDatos();

            stopwatch.Stop();
            long tiempoTranscurridoMs = stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"Tiempo transcurrido: {tiempoTranscurridoMs} ms");
        }
    }
}
