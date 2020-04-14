using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeupBarSystem.Proveedor
{
    public partial class Ins_Proveedor : Form
    {
        private int state;
        private claseProveedor proveedor;
        public Ins_Proveedor()
        {
            InitializeComponent();
            proveedor = new claseProveedor();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
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

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            View_inventario ventana = new View_inventario();
            ventana.Show();
        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void btnReturn_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            View_inventario ventana = new View_inventario();
            ventana.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button4_Click_1(object sender, EventArgs e)
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

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        /*
        private void datos()
        {
            txtProveedor.Text = Convert.ToString(proveedor.IdProveedor);
            txtNombreEmpresa.Text = proveedor.NombreEmpresaProveedor;
            txtNombreContacto.Text = proveedor.NombreContacto;
            txtTelefonoContacto.Text = proveedor.TelefonoProveedor;
            txtCorreo.Text = proveedor.CorreoProveedor;
            txtDescripcion.Text = proveedor.DescripcionProveedor;

            SendKeys.Send("{Tab}");
        }
        */
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (Validar() == true)
            {
                //proveedor.IdProveedor = Convert.ToInt32(txtProveedor.Text);
                proveedor.NombreEmpresaProveedor = txtNombreEmpresa.Text;
                proveedor.NombreContacto = txtNombreContacto.Text;
                proveedor.CorreoProveedor = txtCorreo.Text;
                proveedor.TelefonoProveedor = txtTelefonoContacto.Text;
                proveedor.DescripcionProveedor = txtDescripcion.Text;
                
                if (proveedor.Insertar())
                {
                    MessageBox.Show("Registro guardado correctamente", "Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(string.Format("Error\n{0}", proveedor.Error.ToString()), "Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Se cancelo el proceso");
            }

            limpiar();
        }

        private void limpiar()
        {
            //txtProveedor.Text = "";
            txtNombreEmpresa.Text = "";
            txtNombreContacto.Text = "";
            txtTelefonoContacto.Text = "";
            txtCorreo.Text = "";
            txtDescripcion.Text = "";

        }

        private Boolean Validar()
        {
            Boolean validar = true;
            /*if (txtProveedor.Text == "")
            {
                MessageBox.Show("Escriba el id del proveedor", "Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProveedor.Focus();
                validar = false;
            }*/
            if (txtNombreEmpresa.Text == "")
            {
                MessageBox.Show("Escriba el nombre de la empresa", "Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreEmpresa.Focus();
                validar = false;
            }
            else if (txtNombreContacto.Text == "")
            {
                MessageBox.Show("Escriba el nombre del contacto", "Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreContacto.Focus();
                validar = false;
            }
            
            else if (txtCorreo.Text == "")
            {
                MessageBox.Show("Escriba el correo", "Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreo.Focus();
                validar = false;
            }
            else if (txtTelefonoContacto.Text == "")
            {
                MessageBox.Show("Escriba el telefono del contacto", "Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefonoContacto.Focus();
                validar = false;
            }
            else if (txtDescripcion.Text == "")
            {
                MessageBox.Show("Escriba la descripcion", "Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                validar = false;
            }
            else
                validar = true;
            return validar;

        }
    }
}
