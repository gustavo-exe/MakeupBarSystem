﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MakeupBarSystem.MenuDelModulo;

namespace MakeupBarSystem
{
    public partial class Modulos : Form
    {
        int state;
        public Modulos()
        {
            InitializeComponent();
        }

        private void btnModuloVentas_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            

            if (state == 0)
            {
                this.WindowState = FormWindowState.Normal;

                state = 1;
            }
            else
            if(state == 1)
            {
                this.WindowState = FormWindowState.Maximized;
                state = 0;
            }

     
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            //Agregan MakeupBarSystem.MenuDelModulo;
            this.Hide();
            Men_Empleado ventana = new Men_Empleado();
            ventana.Show();
        }
    }
}
