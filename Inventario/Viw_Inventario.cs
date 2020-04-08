﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeupBarSystem.Inventario
{
    public partial class Viw_Inventario : Form
    {
        Conexion conexion;
        private int state;

        public Viw_Inventario()
        {
            InitializeComponent();
            conexion = new Conexion();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventas ventana = new Ventas();
            ventana.Show();
        }

        private void button4_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Viw_Inventario_Load(object sender, EventArgs e)
        {
            DataTable Datos = conexion.consulta(String.Format("SELECT idInventario AS 'N', precio AS 'Precio', idCodigoDeBarra AS CodigoDeBarra,Cantidad  FROM inventario;"));
            dataGridView1.DataSource = Datos;
            dataGridView1.Refresh();
        }
    }
}
