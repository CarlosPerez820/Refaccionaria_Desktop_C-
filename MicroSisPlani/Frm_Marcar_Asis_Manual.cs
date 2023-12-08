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
using System.Windows.Forms.DataVisualization.Charting;


namespace MicroSisPlani
{
    public partial class Frm_Marcar_Asis_Manual : Form
    {
        public Frm_Marcar_Asis_Manual()
        {
            InitializeComponent();

            chart1.Series.Clear();
            //CrearGrafica1();
            CrearGraficaVisitas();

            cbo_tipoGrafica.SelectedIndex = 0;
        }

        private void Frm_Marcar_Asis_Manual_Load(object sender, EventArgs e)
        {
           
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            lbl_hora.Text = DateTime.Now.ToString("hhh:mm:ss");
        }

        private void CrearGraficaVisitas()
        {   
        }

        private void CrearGraficaSemanal()
        {    
        }

        private void CrearGraficaDiaria()
        {
        }

        private String Convertir_mes_a_Texto(String numeromes)
        {
            String textoMes;
            int mes = Int32.Parse(numeromes);

            switch (mes)
            {
                case 1:
                    textoMes = "Enero";
                    break;
                case 2:
                    textoMes = "Febrero";
                    break;
                case 3:
                    textoMes = "Marzo";
                    break;
                case 4:
                    textoMes = "Abril";
                    break;
                case 5:
                    textoMes = "Mayo";
                    break;
                case 6:
                    textoMes = "Junio";
                    break;
                case 7:
                    textoMes = "Julio";
                    break;
                case 8:
                    textoMes = "Agosto";
                    break;
                case 9:
                    textoMes = "Septiembre";
                    break;
                case 10:
                    textoMes = "Octubre";
                    break;
                case 11:
                    textoMes = "Noviembre";
                    break;
                case 12:
                    textoMes = "Diciembre";
                    break;
                default:
                    textoMes = "";
                    break;
            }
            return textoMes;
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }


        private void cbo_tipoGrafica_SelectionChangeCommitted(object sender, EventArgs e)
        {

            switch (cbo_tipoGrafica.SelectedIndex)
            {
                case 0:
                    chart1.Series.Clear();
                    CrearGraficaVisitas();
                    break;
                case 1:
                    chart1.Series.Clear();
                    CrearGraficaSemanal();
                    break;
                case 2:
                    chart1.Series.Clear();
                    CrearGraficaDiaria();
                    break;
                default:
                    chart1.Series.Clear();
                    break;
            }
           
        }

        private void cb_Grafica2_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void cbo_tipoGrafica_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            
        }
    }
}
