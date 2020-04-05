﻿using MakeupBarSystem.MenuDelModulo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeupBarSystem.Empleado
{
    public partial class Viw_Empleado : Form
    {
        Conexion conexion;
        private int state;

        public Viw_Empleado()
        {
            InitializeComponent();
            conexion = new Conexion();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Men_Empleado ventana = new Men_Empleado();
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
                dataGridView1.Dock = DockStyle.Fill;
                state = 0;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Viw_Empleado_Load(object sender, EventArgs e)
        {
            DataTable Datos = conexion.consulta(String.Format("SELECT * FROM empleado;"));
            dataGridView1.DataSource = Datos;
            dataGridView1.Refresh();
        }
    }
}
