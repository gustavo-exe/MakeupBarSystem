using MySql.Data.MySqlClient;
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
        private claseListaCliente clientes;
        private Conexion conexion;
        public Act_Cliente()
        {
            InitializeComponent();
            cliente = new claseCliente();
            clientes = new claseListaCliente();
            Cargar_Datos();
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        

        private void Cargar_Datos()
        {
            string sql = "";

            sql = string.Format("SELECT * FROM cliente");
            DataTable t1 = clientes.SQL(sql);
            ListaClientes.DataSource = null;
            ListaClientes.DataSource = t1;
            ListaClientes.DisplayMember = "Nombre";
            ListaClientes.ValueMember = "idCliente";
            ListaClientes.Refresh();




        }
        

    }
}
