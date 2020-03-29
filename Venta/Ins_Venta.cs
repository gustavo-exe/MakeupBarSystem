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
    public partial class Ins_Venta : Form
    {
        public Ins_Venta()
        {
            InitializeComponent();
        }

      
        private void btnReturn_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Men_Venta ventana = new Men_Venta();
            ventana.Show();
        }
    }
}
