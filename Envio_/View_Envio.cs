using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MakeupBarSystem.Envio_;

namespace MakeupBarSystem.Envio
{
    public partial class View_Envio : Form
    {
        private int state;
        Conexion conexion;
        public View_Envio()
        {
            InitializeComponent();
            conexion = new Conexion();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Men_Envio ventana = new Men_Envio();
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

        private void View_Envio_Load(object sender, EventArgs e)
        {
            DataTable Datos = conexion.consulta(String.Format("SELECT idEnvio as 'Envio',  idCliente as 'Cliente',Direccion,Telefono,idServicioDeEntrega as 'Servicio de entrega' FROM envio;"));
            verEnvio.DataSource = Datos;
            verEnvio.Refresh();
        }

        private void verEnvio_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
