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
    public partial class View_Entrega : Form
    {
        private int state;
        Conexion conexion;

        public View_Entrega()
        {
            InitializeComponent();
            conexion = new Conexion();
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
            this.Hide();
            Men_Entrega ventana = new Men_Entrega();
            ventana.Show();
        }

        private void View_Entrega_Load(object sender, EventArgs e)
        {
            DataTable Datos = conexion.consulta(string.Format("SELECT nombreEmpresa as 'Nombre de la Empresa', nombreContrato as 'Nombre del contacto', telefono as 'Telefono', correo as 'Correo' FROM serviciodeentrega;"));
            verServicio.DataSource = Datos;
            verServicio.Refresh();
        }
    }
}
