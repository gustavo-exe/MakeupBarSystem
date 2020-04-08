using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MakeupBarSystem.MenuDelModulo;
using MakeupBarSystem.Cliente;
using MakeupBarSystem.ServicioDeEntrega;
using MakeupBarSystem.Proveedor;
using MakeupBarSystem.Inventario;
using MakeupBarSystem.Producto;

namespace MakeupBarSystem
{
    public partial class Modulos : Form
    {
        int state;
        public Modulos()
        {
            InitializeComponent();
        }

        private void btnModuloVentas_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
            if(state == 1)
            {
                this.WindowState = FormWindowState.Maximized;
                state = 0;
            }

     
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            //Agregan MakeupBarSystem.MenuDelModulo;
            this.Hide();
            Men_Empleado ventana = new Men_Empleado();
            ventana.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventas ventana = new Ventas();
            ventana.Show();
        }

             private void BtnCliente_Click(object sender, EventArgs e)
        {
             // Muestra el menú de clientes
            this.Hide();
            Men_Cliente ventana = new Men_Cliente();
            ventana.Show();
        }

        private void btnServicios_Click(object sender, EventArgs e)
        {
            this.Hide();
            Servicio ventana = new Servicio();
            ventana.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Login ventana = new Login();
            ventana.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            Instagram
            Cliente
            Empleado
            ServicioDeEntrega
           */


            if (comboBox1.SelectedIndex == 0)
            {
                this.Hide();
                Ver_PerfilInstagram ventana = new Ver_PerfilInstagram();
                ventana.Show();
            }
            if (comboBox1.SelectedIndex == 1)
            { 
            this.Hide();
            Men_Cliente venta = new Men_Cliente();
            venta.Show();
            }
            if (comboBox1.SelectedIndex == 2)
            {
                this.Hide();
                Men_Empleado venta = new Men_Empleado();
                venta.Show();
            }
            if (comboBox1.SelectedIndex == 3)
            {
                this.Hide();
                Men_Entrega venta = new Men_Entrega();
                venta.Show();
            }

            /*
            Proveedor
           MisProductos
            Inventario
            */
            if (comboBox1.SelectedIndex == 4)
            {
                this.Hide();
                ViewProveedor ventana = new ViewProveedor();
                ventana.Show();
            }
            if (comboBox1.SelectedIndex == 5)
            {
                this.Hide();
                Viw_Producto venta = new Viw_Producto();
                venta.Show();
            }

            if (comboBox1.SelectedIndex == 6)
            {
                this.Hide();
                View_inventario venta = new View_inventario();
                venta.Show();
            }

        }
    }
}
