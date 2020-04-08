using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MakeupBarSystem.Envio_;

namespace MakeupBarSystem.Envio
{
    public partial class Ins_Envio : Form
    {
        private int state;
        private ClaseEnvio envio;
        public Ins_Envio()
        {
            InitializeComponent();
            envio = new ClaseEnvio();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Men_Envio ventana = new Men_Envio();
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
            txtIdCliente.Text = envio.IdCliente;
            txtDireccion.Text = envio.direccion;
            txtTelefono.Text = envio.telefono;
            txtIdServicioDeEntrega.Text = envio.IdServicioEntrega;
            SendKeys.Send("{Tab}");
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (Validar() == true)
            {
                envio.IdCliente = txtIdCliente.Text;
                envio.direccion = txtDireccion.Text;
                envio.telefono = txtTelefono.Text;
                envio.IdServicioEntrega = txtIdServicioDeEntrega.Text;
                if (envio.Guardar())
                {
                    MessageBox.Show("Registro guardado correctamente", "Envio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(string.Format("Error\n{0}", envio.Error.ToString()), "Envio", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (txtIdCliente.Text == "")
            {
                MessageBox.Show("Escriba el codigo del Envio", "Envio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIdCliente.Focus();
                validar = false;
            }
            else if (txtDireccion.Text == "")
            {
                MessageBox.Show("Escriba la direccion del Envio", "Envio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDireccion.Focus();
                validar = false;
            }
            else if (txtTelefono.Text == "")
            {
                MessageBox.Show("Escriba el teléfono del cliente", "Envio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                validar = false;
            }
            else if (txtIdServicioDeEntrega.Text == "")
            {
                MessageBox.Show("Escriba el codigo de Servicio de Entrega", "Envio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIdServicioDeEntrega.Focus();
                validar = false;
            }
            else
                validar = true;
            return validar;
        }
        private void limpiar()
        {
            txtIdCliente.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtIdServicioDeEntrega.Text = "";

        }

    }

    
}
