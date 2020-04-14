using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeupBarSystem.ServicioDeEntrega
{
    public partial class Ins_Entrega : Form
    {
        private int state;
        private claseEntrega serviciodeentrega;
        public Ins_Entrega()
        {
            InitializeComponent();
            serviciodeentrega = new claseEntrega();
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
            Men_Entrega ventana = new Men_Entrega();
            ventana.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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

        private void btnReturn_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Men_Entrega ventana = new Men_Entrega();
            ventana.Show();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (Validar() == true)
            {
                //serviciodeentrega.IdServicioEntrega = Convert.ToInt32(txtUsuario.Text);
                serviciodeentrega.NombreEmpresa = txtNombreEmpresa.Text;
                serviciodeentrega.NombreContacto = txtNombreContacto.Text;
                serviciodeentrega.Telefono = txtTelefono.Text;
                serviciodeentrega.Correo = txtCorreo.Text;

                if (serviciodeentrega.Insertar())
                {
                    MessageBox.Show("Registro guardado correctamente", "ServicioDeEntrega", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(string.Format("Error\n{0}", serviciodeentrega.Error.ToString()), "ServicioDeEntrega", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            //txtUsuario.Text = "";
            txtNombreEmpresa.Text = "";
            txtNombreContacto.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";

        }

        private Boolean Validar()
        {
            Boolean validar = true;

            if (txtNombreEmpresa.Text == "")
            {
                MessageBox.Show("Escriba el nombre de la empresa", "ServicioDeEntrega", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreEmpresa.Focus();
                validar = false;
            }
            else if (txtNombreContacto.Text == "")
            {
                MessageBox.Show("Escriba el nombre del contacto", "ServicioDeEntrega", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreContacto.Focus();
                validar = false;
            }
            else if (txtTelefono.Text == "")
            {
                MessageBox.Show("Escriba el telefono", "ServicioDeEntrega", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                validar = false;
            }
            else if (txtCorreo.Text == "")
            {
                MessageBox.Show("Escriba el correo", "ServicioDeEntrega", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreo.Focus();
                validar = false;
            }


            else
                validar = true;
            return validar;

        }
    }
}
