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
    public partial class Act_Venta : Form
    {
        public Act_Venta()
        {
            InitializeComponent();
        }

        private void Act_Venta_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Men_Venta ventana = new Men_Venta();
            ventana.Show();
        }
    }
}
