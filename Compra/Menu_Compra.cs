using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeupBarSystem.Compra
{
    public partial class Menu_Compra : Form
    {
        public Menu_Compra()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Insertar_Compra ventana = new Insertar_Compra();
            ventana.Show();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ver_Compra ventana = new Ver_Compra();
            ventana.Show();
        }

        private void btnActulizar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Modificar_Compra ventana = new Modificar_Compra();
            ventana.Show();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Modulos ventana = new Modulos();
            ventana.Show();
        }
    }
}
