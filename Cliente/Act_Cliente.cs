using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeupBarSystem.Cliente
{
    public partial class Act_Cliente : Form
    {
        private int state;
        private claseCliente cliente;
        public Act_Cliente()
        {
            InitializeComponent();
            cliente = new claseCliente();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Men_Cliente ventana = new Men_Cliente();
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (ListaClientes.SelectedValue == null)
            MessageBox.Show("Debes seleccionar un alumno del listado.");

        }


        private void Cargar_Datos()
        {
            string sql = "";
            sql = string.Format("SELECT iddepartamento, codigoDepartamento, nombreDepartamento, habilitado FROM sigecli.departamentos where codigoDepartamento like '%{0}%' or nombreDepartamento like '%{0}%'", txtFiltro.Text);
            
            DataTable t1 = cliente.SQL(sql);
            cliente.DataSource = null;
            cliente.DataSource = t1;
            cliente.Refresh();
        }

    }
}
