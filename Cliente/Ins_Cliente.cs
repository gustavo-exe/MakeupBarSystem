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
    public partial class Ins_Cliente : Form
    {
        private int state;
        private claseCliente cliente;
        public Ins_Cliente()
        {
            InitializeComponent();
            cliente = new claseCliente();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Cargar_Datos()
        {
            txtCliente.Text = cliente.IdCliente;
            txtNombre.Text = cliente.NombreCliente;
            txtCorreo.Text = cliente.CorreoCliente;
            txtTelefono.Text = cliente.TelefonoCliente;
            txtPerfilInstagram.Text = cliente.PerfilInstagram;
            dateFechaCumpleaños.Value = cliente.CumpleañosCliente;
            txtCiudad.Text = cliente.CiudadCliente;
            txtTonodeBase.Text = cliente.TonoDeBaseCliente;
            txtTonodePolvo.Text = cliente.TonodePolvoCliente;
            txtTipodeCutie.Text = cliente.TipodeCutie;

            SendKeys.Send("{Tab}");
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (Validar() == true)
            {
                cliente.IdCliente = txtCliente.Text;
                cliente.NombreCliente = txtNombre.Text;
                cliente.CorreoCliente = txtCorreo.Text;
                cliente.TelefonoCliente = txtTelefono.Text;
                cliente.PerfilInstagram = txtPerfilInstagram.Text;
                cliente.CumpleañosCliente = dateFechaCumpleaños.Value.Date;
                cliente.CiudadCliente = txtCiudad.Text;
                cliente.TonoDeBaseCliente = txtTonodeBase.Text;
                cliente.TonodePolvoCliente = txtTonodePolvo.Text;
                cliente.TipodeCutie = txtTipodeCutie.Text;
                if (cliente.Guardar())
                {
                    MessageBox.Show("Registro guardado correctamente", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(string.Format("Error\n{0}", cliente.Error.ToString()), "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (txtCliente.Text == "")
            {
                MessageBox.Show("Escriba el codigo del cliente", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCliente.Focus();
                validar = false;
            }
            else if (txtNombre.Text == "")
            {
                MessageBox.Show("Escriba el nombre del cliente", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                validar = false;
            }
            else if (txtCorreo.Text == "")
            {
                MessageBox.Show("Escriba el correo del cliente", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreo.Focus();
                validar = false;
            }
            else if (txtTelefono.Text == "")
            {
                MessageBox.Show("Escriba el teléfono del cliente", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                validar = false;
            }
            else if (txtCiudad.Text == "")
            {
                MessageBox.Show("Escriba la ciudad de donde proviene el cliente", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCiudad.Focus();
                validar = false;
            }
            else if (txtTonodeBase.Text == "")
            {
                MessageBox.Show("Escriba el tono de base del cliente", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTonodeBase.Focus();
                validar = false;
            }
            else if (txtTonodePolvo.Text == "")
            {
                MessageBox.Show("Escriba el tono de polvo del cliente", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTonodePolvo.Focus();
                validar = false;
            }
            else if (txtTipodeCutie.Text == "")
            {
                MessageBox.Show("Escriba el tipo de cutie del cliente", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTipodeCutie.Focus();
                validar = false;
            }
            else if (dateFechaCumpleaños.Value == DateTime.Now)
            {
                MessageBox.Show("Escriba la fecha de nacimiento del cliente", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                validar = false;
            }
            else
                validar = true;
            return validar;

        }

        private void limpiar()
        {
            txtCliente.Text = "";
            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            txtPerfilInstagram.Text = "";
            txtCiudad.Text = "";
            txtTonodeBase.Text = "";
            txtTonodePolvo.Text = "";
            txtTipodeCutie.Text = "";
            
        }

        private void dateFechaCumpleaños_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
