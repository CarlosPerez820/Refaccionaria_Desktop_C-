﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace MicroSisPlani.Personal
{
    public partial class Frm_Explorador_Personal : Form
    {
        public Frm_Explorador_Personal()
        {
            InitializeComponent();
        }

        private void Frm_Explorador_Personal_Load(object sender, EventArgs e)
        {
            
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }
    }
}
