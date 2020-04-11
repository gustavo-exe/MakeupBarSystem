using MakeupBarSystem.MenuDelModulo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeupBarSystem.Empleado
{
    public partial class Ins_Empleado : Form
    {
        int state;
        public Ins_Empleado()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            PanelColor1.BackColor = Color.FromArgb(217, 4, 142);
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            panelColor2.BackColor = Color.FromArgb(217, 4, 142);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            panelColor3.BackColor = Color.FromArgb(217, 4, 142);
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

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.WindowState = FormWindowState.Minimized;

            
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Men_Empleado ventana = new Men_Empleado();
            ventana.Show();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (Validar() == true)
            {

                Empleado empleado = new Empleado();
                empleado.IdEmpleado = Convert.ToString(txtId.Text);
                empleado.Usuario = Convert.ToString(txtUsuario.Text);
                empleado.Password = Convert.ToString(txtContraseña.Text);
                empleado.Rol = Convert.ToString(txtRol.Text);
                if (empleado.Insertar())
                {
                    MessageBox.Show("Empleado insertado.");

                    txtId.Text = "";
                    txtUsuario.Text = "";
                    txtContraseña.Text = "";
                    txtRol.Text = "";
                }
                else
                {
                    MessageBox.Show("Error al guardar >:v");
                }
            }
        }

        private Boolean Validar()
        {
            Boolean validar = true;
            if (txtId.Text == "")
            {
                MessageBox.Show("Ingrese un  id", "Empleado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtId.Focus();
                validar = false;
            }
            else if (txtUsuario.Text == "")
            {
                MessageBox.Show("Ingrese un usuario", "Empleado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus();
                validar = false;
            }
            else if (txtContraseña.Text == "")
            {
                MessageBox.Show("Ingrese una contraseña", "Empleado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContraseña.Focus();
                validar = false;
            }
            else if (txtRol.Text == "")
            {
                MessageBox.Show("Ingrese un rol", "Empleado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRol.Focus();
                validar = false;
            }
            else
                validar = true;
            return validar;


        }


        private void panel8_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            panelcolor4.BackColor = Color.FromArgb(217, 4, 142);
        }
    }
}
