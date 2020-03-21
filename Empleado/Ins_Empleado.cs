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

namespace MakeupBarSystem.Empleado
{
    public partial class Ins_Empleado : Form
    {
        int state;
        public Ins_Empleado()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            PanelColor1.BackColor = Color.FromArgb(217, 4, 142);
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            panelColor2.BackColor = Color.FromArgb(217, 4, 142);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            panelColor3.BackColor = Color.FromArgb(217, 4, 142);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.WindowState = FormWindowState.Minimized;

            
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Men_Empleado ventana = new Men_Empleado();
            ventana.Show();
        }
    }
}
