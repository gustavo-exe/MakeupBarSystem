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
    public partial class Ins_Maquillaje : Form
    {
        private int state;
        private claseMaquillaje maquillaje;
        public Ins_Maquillaje()
        {
            InitializeComponent();
            maquillaje = new claseMaquillaje();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Modulos ventana = new Modulos();
            ventana.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
            txtNombre.Text = maquillaje.nombreDelProducto;
            txtMarca.Text = maquillaje.marca;
            txtTonoNum.Text = maquillaje.tonoNumero;
            txtFechaEx.Value = maquillaje.fechaDeExpiracion;
            txtPrecio.Text = maquillaje.precioUnitario;
            txtCantidad.Text = maquillaje.cantidad;
            txtDescripcion.Text = maquillaje.descripcion;
            txtidProveedor.Text = maquillaje.proveedor.ToString();

            SendKeys.Send("{Tab}");
        }
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (Validar() == true)
            {
                maquillaje.nombreDelProducto = txtNombre.Text;
                maquillaje.marca = txtMarca.Text;
                maquillaje.tonoNumero = txtTonoNum.Text;
                maquillaje.fechaDeExpiracion =txtFechaEx.Value;
                maquillaje.precioUnitario = txtPrecio.Text;
                maquillaje.cantidad = txtCantidad.Text;
                maquillaje.descripcion = txtDescripcion.Text;
                maquillaje.proveedor =Convert.ToInt32(txtidProveedor.Text);
                if (maquillaje.Guardar())
                {
                    MessageBox.Show("Registro guardado correctamente", "Maquillaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(string.Format("Error\n{0}", maquillaje.Error.ToString()), "Maquillaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Escriba el nombre del maquillaje", "Maquillaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                validar = false;
            }
            else if (txtMarca.Text == "")
            {
                MessageBox.Show("Escriba la marca del maquillaje", "Maquillaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMarca.Focus();
                validar = false;
            }
            else if (txtTonoNum.Text == "")
            {
                MessageBox.Show("Escriba el tono o numero del maquillaje", "Maquillaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTonoNum.Focus();
                validar = false;
            }
            else if (txtFechaEx.Text == "")
            {
                MessageBox.Show("Escriba la fecha de expiracion del maquillaje", "Maquillaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFechaEx.Focus();
                validar = false;
            }
            else if (txtPrecio.Text == "")
            {
                MessageBox.Show("Escriba el precio del maquillaje", "Maquillaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecio.Focus();
                validar = false;
            }
            else if (txtCantidad.Text == "")
            {
                MessageBox.Show("Escriba la cantidad de maquillaje", "Maquillaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCantidad.Focus();
                validar = false;
            }
            else if (txtDescripcion.Text == "")
            {
                MessageBox.Show("Escriba la descripcion del maquillaje", "Maquillaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                validar = false;
            }
            else if(txtidProveedor.Text == "")
            {
                MessageBox.Show("Escriba el id del proveedor", "Maquillaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtidProveedor.Focus();
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
            txtTonoNum.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
            txtDescripcion.Text = "";
            txtidProveedor.Text = "";
        }

    }
}
