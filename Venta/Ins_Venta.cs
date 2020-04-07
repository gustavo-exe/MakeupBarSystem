﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeupBarSystem.Venta
{
    public partial class Ins_Venta : Form
    {
        Conexion conexion;
        private int state;
        private claseVenta venta;

        public Ins_Venta()
        {
            InitializeComponent();
            venta = new claseVenta();
            conexion = new Conexion();
        }


        private void btnReturn_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Men_Venta ventana = new Men_Venta();
            ventana.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidarVenta() == true)
            {
                venta.IdCliente = Convert.ToInt32(txtCliente.Text);
                venta.IdEmpleado = Convert.ToInt32(txtEmpleado.Text);
                venta.Fecha = DateTime.Today;



                if (venta.Venta())
                {
                    txtidventa.Text = Convert.ToString(venta.IdVenta);
                    txtidfactura.Text = Convert.ToString(venta.IdFactura);

                    MessageBox.Show("Registro guardado correctamente ","venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(string.Format("Error\n{0}", venta.Error.ToString()), "Venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }




            }
            else
            {
                MessageBox.Show("Se cancelo la edición");
            }

          
            
        }


        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Viw_Empleado_Load(object sender, EventArgs e)
        {
            DataTable Datos = conexion.consulta(String.Format("SELECT * FROM DetalleDeVenta;"));
            dgvVenta.DataSource = Datos;
            dgvVenta.Refresh();
        }


        private void Cargar_Datos()
        {
            txtCliente.Text = Convert.ToString(venta.IdCliente);
            txtEmpleado.Text = Convert.ToString(venta.IdEmpleado);
            txtidventa.Text = Convert.ToString(venta.IdVenta);
            txtidfactura.Text = Convert.ToString(venta.IdFactura);
            txtidproducto.Text = Convert.ToString(venta.IdProducto);
            txtprecio.Text = Convert.ToString(venta.Precio);
            txtcantidad.Text = Convert.ToString(venta.Cantidades);
            txtdescuento.Text = Convert.ToString(venta.Descuento);

            SendKeys.Send("{Tab}");
        }
        private void limpiar()
        {
            txtCliente.Text = "";
            txtEmpleado.Text = "";
            txtidventa.Text = "";
            txtidfactura.Text = "";
            txtidproducto.Text = "";
            txtprecio.Text = "";
            txtcantidad.Text = "";
            txtdescuento.Text = "";
        }

        private void limpiardetalle()
        {
            txtidproducto.Text = "";
            txtprecio.Text = "";
            txtcantidad.Text = "";
            txtdescuento.Text = "";
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (Validar() == true)
            {
              
                venta.IdVenta = Convert.ToInt32(txtidventa.Text);
                venta.IdFactura = Convert.ToInt32(txtidfactura.Text);
                venta.IdProducto = Convert.ToInt32(txtidproducto.Text);
                venta.Precio = Convert.ToInt32(txtprecio.Text);
                venta.Cantidades = Convert.ToInt32(txtcantidad.Text);
                venta.Descuento = Convert.ToInt32(txtdescuento.Text);

                if (venta.Insertar())
                {
                    MessageBox.Show("Registro guardado correctamente", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(string.Format("Error\n{0}", venta.Error.ToString()), "Venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Se cancelo la edición");
            }
            limpiardetalle();
        }

        private Boolean ValidarVenta()
        {
            Boolean validarVenta = true;
            if (txtCliente.Text == "")
            {
                MessageBox.Show("Ingrese un cliente", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCliente.Focus();
                validarVenta = false;
            }
            else if (txtEmpleado.Text == "")
            {
                MessageBox.Show("Ingrese un empleado", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmpleado.Focus();
                validarVenta = false;
            }
            else
                validarVenta = true;
            return validarVenta;


        }


        private Boolean Validar()
        {
            Boolean validar = true;
           
            if (txtidventa.Text == "")
            {
                MessageBox.Show("Ingrese el codigo de la venta", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtidventa.Focus();
                validar = false;
            }
            else if (txtidfactura.Text == "")
            {
                MessageBox.Show("Ingrese el codigo de la factura", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtidfactura.Focus();
                validar = false;
            }
            else if (txtidproducto.Text == "")
            {
                MessageBox.Show("Ingrese el codigo del producto", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtidproducto.Focus();
                validar = false;
            }
            else if (txtprecio.Text == "")
            {
                MessageBox.Show("Ingrese el precio del producto", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtprecio.Focus();
                validar = false;
            }
            else if (txtcantidad.Text == "")
            {
                MessageBox.Show("Ingrese la cantidad", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtcantidad.Focus();
                validar = false;
            }
            else if (txtdescuento.Text == "")
            {
                MessageBox.Show("Ingrese el descuento", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdescuento.Focus();
                validar = false;
            }
            else
                validar = true;
            return validar;

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void dgvVenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
