using MakeupBarSystem.Venta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeupBarSystem.Factura
{
    public partial class Men_Factura : Form
    {
        public Men_Factura()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnActulizar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Act_Venta ventana = new Act_Venta();
            ventana.Show();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            this.Hide();
            Viw_Factura ventana = new Viw_Factura();
            ventana.Show();
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventas ventana = new Ventas();
            ventana.Show();
        }
    }
    
}
