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
using MicroSisPlani;
using Prj_Capa_Datos;
using Prj_Capa_Entidad;
using Prj_Capa_Negocio;

namespace MicroSisPlani.Personal
{
    public partial class Frm_Registrar_Img : Form
    {

        private string Path = @"C:\Users\Bioxor\source\repos\WebCamSave\WebCamSave\";
        private bool HayDispositivos;
        private FilterInfoCollection MisDispositivios;
        private VideoCaptureDevice MiWebCam;

        public Frm_Registrar_Img()
        {
            InitializeComponent();
        }

        private void Frm_Registrar_Img_Load(object sender, EventArgs e)
        {
            CargaDispositivos();
            lbl1.Text = RN_Utilitario.RN_NroDoc(2);
        }

        public void CargaDispositivos()
        {
            MisDispositivios = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (MisDispositivios.Count > 0)
            {
                HayDispositivos = true;
                for (int i = 0; i < MisDispositivios.Count; i++)
                    comboBox1.Items.Add(MisDispositivios[i].Name.ToString());
                comboBox1.Text = MisDispositivios[0].Name.ToString();
            }
            else
                HayDispositivos = false;

        }

        private void CerrarWebCam()
        {
            if (MiWebCam != null && MiWebCam.IsRunning)
            {
                MiWebCam.SignalToStop();
                MiWebCam = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Capturando(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap Imagen = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = Imagen;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            CerrarWebCam();
        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            CerrarWebCam();
            int i = comboBox1.SelectedIndex;
            string NombreVideo = MisDispositivios[i].MonikerString;
            MiWebCam = new VideoCaptureDevice(NombreVideo);
            MiWebCam.NewFrame += new NewFrameEventHandler(Capturando);
            MiWebCam.Start();

            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (MiWebCam != null && MiWebCam.IsRunning)
            {
                

                pictureBox2.Image = pictureBox1.Image;
                pictureBox2.Image.Save(@"C:\Users\BJ.DESKTOP-OCAB3JL\Pictures\fotoscliente\" +lbl1.Text+".jpeg", ImageFormat.Jpeg);
            }
            Frm_Registro_Personal pruba = new Frm_Registro_Personal();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            string Nruta = @"C:\Users\BJ.DESKTOP-OCAB3JL\Pictures\fotoscliente\" + lbl1.Text + ".jpeg";
            Frm_Registro_Personal pruba = new Frm_Registro_Personal();

            this.Tag = "";
            this.Close();

           // MessageBox.Show(Nruta);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
