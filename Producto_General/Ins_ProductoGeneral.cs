using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeupBarSystem.Producto_General
{
    public partial class Ins_ProductoGeneral : Form
    {   
        private int state;
        private claseProductoGeneral productoGeneral;
        public Ins_ProductoGeneral()
        {
            InitializeComponent();
            productoGeneral = new claseProductoGeneral();
        }


        private void btnReturn_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Men_ProductoGeneral ventana = new Men_ProductoGeneral();
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


        private void Cargar_Datos()
        {
            txtNombre.Text = productoGeneral.nombreProducto;
            txtMarca.Text = productoGeneral.marca;
            txtPrecio.Text = productoGeneral.precioUnitario;
            txtCantidad.Text = productoGeneral.cantidad;
            txtDescripcion.Text = productoGeneral.descripcion;
            SendKeys.Send("{Tab}");
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (Validar() == true)
            {
                productoGeneral.nombreProducto = txtNombre.Text;
                productoGeneral.marca = txtMarca.Text;
                productoGeneral.precioUnitario = txtPrecio.Text;
                productoGeneral.cantidad = txtCantidad.Text;
                productoGeneral.descripcion = txtDescripcion.Text;
                if (productoGeneral.Guardar())
                {
                    MessageBox.Show("Registro guardado correctamente", "Producto General", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(string.Format("Error\n{0}", productoGeneral.Error.ToString()), "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Se cancelo la edición");
            }
            limpiar();

        }

        private Boolean Validar()
        {
            Boolean validar = true;
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Escriba el nombre del Producto General", "Producto General", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                validar = false;
            }
            else if (txtMarca.Text == "")
            {
                MessageBox.Show("Escriba la marca del Producto General", "Producto General", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMarca.Focus();
                validar = false;
            }
            else if (txtPrecio.Text == "")
            {
                MessageBox.Show("Escriba el precio del Producto General", "Producto General", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecio.Focus();
                validar = false;
            }
            else if (txtCantidad.Text == "")
            {
                MessageBox.Show("Escriba la cantidad de Producto General", "Producto General", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCantidad.Focus();
                validar = false;
            }
            else if (txtDescripcion.Text == "")
            {
                MessageBox.Show("Escriba la descripcion del Producto General", "Producto General", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                validar = false;
            }
            else
                validar = true;
            return validar;

        }

        private void limpiar()
        {
            txtNombre.Text = "";
            txtMarca.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
            txtDescripcion.Text = "";
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

