using MakeupBarSystem.Inventario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MakeupBarSystem.Maquillaje_;
using MakeupBarSystem.Producto_General;
using MakeupBarSystem.Factura;
using MakeupBarSystem.Venta;

namespace MakeupBarSystem
{
    public partial class Ventas : Form
    {
        private int state;

        public Ventas()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Modulos ventana = new Modulos();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            this.Hide();
            Viw_Inventario ventana = new Viw_Inventario();
            ventana.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Men_ProductoGeneral ventana = new Men_ProductoGeneral();
            ventana.Show();
        }

        private void btnMaquillaje_Click(object sender, EventArgs e)
        {
            this.Hide();
            Men_Maquillaje ventana = new Men_Maquillaje();
            ventana.Show();
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            this.Hide();
            Men_Factura ventana = new Men_Factura();
            ventana.Show();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            this.Hide();
            Men_Venta ventana = new Men_Venta();
            ventana.Show();
        }

    }
    }
   

