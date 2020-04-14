using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeupBarSystem.Compra
{
    public partial class Insertar_Compra : Form

    {
        private claseCompra compra;
        Conexion conexion;

        public Insertar_Compra()
        {
            InitializeComponent();
            compra = new claseCompra();
            conexion = new Conexion();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu_Compra ventana = new Menu_Compra();
            ventana.Show();
        }

        private void limpiar()
        {
            txtproveedor.Text = "";
            txtnombre.Text = "";
            txtcantidad.Text = "";
            txtcosto.Text = "";
            txtdescripcion.Text = "";
        }


        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (Validar() == true)
            {

                compra.IdProveedor = Convert.ToInt32(txtproveedor.Text);
                compra.NombreProducto = txtnombre.Text;
                compra.Cantidad = Convert.ToInt32(txtcantidad.Text);
                compra.Costo = Convert.ToDouble(txtcosto.Text);
                compra.Descripcion = txtdescripcion.Text;

                if (compra.Insertar())
                {
                    MessageBox.Show("Registro guardado correctamente", "Compra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(string.Format("Error\n{0}", compra.Error.ToString()), "Compra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            limpiar();
        }

        private Boolean Validar()
        {
            Boolean validar = true;

            if (txtproveedor.Text == "")
            {
                MessageBox.Show("Ingrese el codigo del proveedor", "Compra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtproveedor.Focus();
                validar = false;
            }
            else if (txtnombre.Text == "")
            {
                MessageBox.Show("Ingrese el nombre del producto", "Compra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtnombre.Focus();
                validar = false;
            }
            else if (txtcantidad.Text == "")
            {
                MessageBox.Show("Ingrese la cantidad", "Compra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtcantidad.Focus();
                validar = false;
            }
            else if (txtcosto.Text == "")
            {
                MessageBox.Show("Ingrese el costo", "Compra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtcosto.Focus();
                validar = false;
            }
            else if (txtcantidad.Text == "")
            {
                MessageBox.Show("Ingrese la cantidad", "Compra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtcantidad.Focus();
                validar = false;
            }
            else if (txtdescripcion.Text == "")
            {
                MessageBox.Show("Ingresela descripcion", "Compra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdescripcion.Focus();
                validar = false;
            }
            else
                validar = true;
            return validar;

        }

    }
}
