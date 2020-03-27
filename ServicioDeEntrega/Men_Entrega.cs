using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeupBarSystem.ServicioDeEntrega
{
    public partial class Men_Entrega : Form
    {
        private int state;

        public Men_Entrega()
        {
            InitializeComponent();
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

        private void btnReturn_Click(object sender, EventArgs e)
        {
            
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ins_Entrega ventana = new Ins_Entrega();
            ventana.Show();
        }

        private void btnActulizar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Act_Entrega ventana = new Act_Entrega();
            ventana.Show();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            this.Hide();
            View_Entrega ventana = new View_Entrega();
            ventana.Show();
        }
    }
}
