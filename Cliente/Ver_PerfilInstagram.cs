﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeupBarSystem.Cliente
{
    public partial class Ver_PerfilInstagram : Form
    {
        private int state;
        public Ver_PerfilInstagram()
        {
            InitializeComponent();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Men_Cliente ventana = new Men_Cliente();
            ventana.Show();
        }

     
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (state == 0)
            {
                this.WindowState = FormWindowState.Normal;

                state = 1;
            }
            else
           if (state == 1)
            {
                this.WindowState = FormWindowState.Maximized;
                state = 0;
            }
        }
    }
}