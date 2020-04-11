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
    public partial class Men_ProductoGeneral : Form
    {
        public Men_ProductoGeneral()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ins_ProductoGeneral ventana = new Ins_ProductoGeneral(); 
            ventana.Show();
            
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            this.Hide();
            View_ProductoGeneral ventana = new View_ProductoGeneral();
            ventana.Show();
        }

        private void btnActulizar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Act_ProductoGeneral ventana = new Act_ProductoGeneral();
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
