using MakeupBarSystem.Factura;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeupBarSystem.Venta
{
    public partial class Men_Venta : Form
    {
        public Men_Venta()
        {
            InitializeComponent();
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

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ins_Venta ventana = new Ins_Venta();
            ventana.Show();
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
            Viw_Venta ventana = new Viw_Venta();
            ventana.Show();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Viw_Factura ventana = new Viw_Factura();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

    }
}
