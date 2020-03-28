using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MakeupBarSystem.Maquillaje;

namespace MakeupBarSystem.Maquillaje_
{
    public partial class Men_Maquillaje : Form
    {
        private int state;
        public Men_Maquillaje()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ins_Maquillaje ventana = new Ins_Maquillaje();
            ventana.Show();
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

        private void btnVer_Click(object sender, EventArgs e)
        {
            this.Hide();
            View_Maquillaje ventana = new View_Maquillaje();
            ventana.Show();
        }

        private void btnActulizar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Act_Maquillaje ventana = new Act_Maquillaje();
            ventana.Show();
        }
    }
}
