﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeupBarSystem.Proveedor
{
    public partial class ViewProveedor : Form
    {
        private int state;
        Conexion conexion;

        public ViewProveedor()
        {
            InitializeComponent();
            conexion = new Conexion();
        }

        private void label1_Click(object sender, EventArgs e)
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
           if (state == 1)
            {
                this.WindowState = FormWindowState.Maximized;
                state = 0;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            View_inventario ventana = new View_inventario();
            ventana.Show();
        }

        private void ViewProveedor_Load(object sender, EventArgs e)
        {
            DataTable Datos = conexion.consulta(String.Format("SELECT IdProveedor, nombreEmpresa as 'Nombre de la empresa', nombreDelContrato as 'Nombre del contacto', telefonoContacto as 'Telefono del contacto', correo as 'Correo', descripcion as 'Descripción' FROM proveedor;"));
            verproveedor.DataSource = Datos;
            verproveedor.Refresh();
        }
    }
}
