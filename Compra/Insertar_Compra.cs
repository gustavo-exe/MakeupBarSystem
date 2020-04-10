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
        public Insertar_Compra()
        {
            InitializeComponent();
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

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            claseCompra compra = new claseCompra();


            compra.IdProveedor = Convert.ToInt32(txtproveedor.ToString());
            compra.NombreProducto = txtnombre.ToString();
            compra.Cantidad = Convert.ToInt32(txtcantidad.ToString());
            compra.Costo = Convert.ToInt32(txtcosto.ToString());
            compra.Descripcion = txtdescripcion.ToString();

            if (compra.Insertar())
            {
                MessageBox.Show("Registro guardado correctamente", "Compra", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(string.Format("Error\n{0}", compra.Error.ToString()), "Venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
