using MakeupBarSystem.Venta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeupBarSystem.Factura
{
    public partial class Viw_Factura : Form
    {
        Conexion conexion;
        private int state;

        public Viw_Factura()
        {
            InitializeComponent();
            conexion = new Conexion();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

 
        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Men_Venta ventana = new Men_Venta();
            ventana.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

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
                dvgFactura.Dock = DockStyle.Fill;
                state = 0;
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Viw_Factura_Load(object sender, EventArgs e)
        {
            
             DataTable Datos = conexion.consulta(String.Format("SELECT IdFactura as 'Numero De Factura', FechaActual as 'Fecha', IdEmpleado as 'Empleado',idCliente as 'Cliente' FROM makeupbar.factura"));
             dvgFactura.DataSource = Datos;
             dvgFactura.Refresh();
        }
    }
}
