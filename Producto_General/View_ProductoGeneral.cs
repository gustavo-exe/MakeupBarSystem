using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MakeupBarSystem.Producto_General;

namespace MakeupBarSystem.Producto_General
{
    public partial class View_ProductoGeneral : Form
    {
        private int state;
        Conexion conexion;
        public View_ProductoGeneral()
        {
            InitializeComponent();
            conexion = new Conexion();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Men_ProductoGeneral ventana = new Men_ProductoGeneral();
            ventana.Show();
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

        private void View_ProductoGeneral_Load(object sender, EventArgs e)
        {
            DataTable Datos = conexion.consulta(String.Format("SELECT * FROM productogeneral;"));
            vistaProductoG.DataSource = Datos;
            vistaProductoG.Refresh();
        }
    }
}
