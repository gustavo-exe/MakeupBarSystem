using MakeupBarSystem.Empleado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeupBarSystem.MenuDelModulo
{
    public partial class Men_Empleado : Form
    {
        private int state;

        public Men_Empleado()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            //Agregan using MakeupBarSystem.Empleado;
            this.Hide();
            Ins_Empleado ventana = new Ins_Empleado();
            ventana.Show();
        }

        private void btnVer_Click(object sender, EventArgs e)
        { 
            this.Hide();
            Viw_Empleado ventana = new Viw_Empleado();
            ventana.Show();
        }

        
        private void btnActulizar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Act_Empleado ventana = new Act_Empleado();
            ventana.Show();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Administrativo ventana = new Administrativo();
            ventana.Show();
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
