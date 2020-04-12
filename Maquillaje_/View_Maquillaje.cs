using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MakeupBarSystem.Maquillaje_;

namespace MakeupBarSystem.Maquillaje
{
    public partial class View_Maquillaje : Form
    {
        private int state;
        Conexion conexion;

        public View_Maquillaje()
        {
            InitializeComponent();
            conexion = new Conexion();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Men_Maquillaje ventana = new Men_Maquillaje();
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

        private void View_Maquillaje_Load(object sender, EventArgs e)
        {
            DataTable Datos = conexion.consulta(String.Format("SELECT * FROM maquillaje;"));
            verMaquillaje.DataSource = Datos;
            verMaquillaje.Refresh();
        }
    }
}
