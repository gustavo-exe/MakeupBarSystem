using MakeupBarSystem.MenuDelModulo;
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
    public partial class Administrativo : Form
    {
        public Administrativo()
        {
            InitializeComponent();
        }

        private void btnMaquillaje_Click(object sender, EventArgs e)
        {
            this.Hide();
            Men_Empleado ventana = new Men_Empleado();
            ventana.Show();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            this.Hide();
            Navegador ventana = new Navegador();
            ventana.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Modulos ventana = new Modulos();
            ventana.Show();
        }
    }
}
