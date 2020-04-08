using MakeupBarSystem.Proveedor;
using MakeupBarSystem.ServicioDeEntrega;
using MakeupBarSystem.Envio_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeupBarSystem
{
    public partial class Servicio : Form
    {
        private int state;

        public Servicio()
        {
            InitializeComponent();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
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
            Modulos ventana = new Modulos();
            ventana.Show();
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            this.Hide();
            View_inventario ventana = new View_inventario();
            ventana.Show();
        }

        private void btnServicioEntrega_Click(object sender, EventArgs e)
        {
            this.Hide();
            Men_Entrega ventana = new Men_Entrega();
            ventana.Show();
        }

        private void btnEnvio_Click(object sender, EventArgs e)
        {
            this.Hide();
            Men_Envio ventana = new Men_Envio();
            ventana.Show();
        }
    }
}
