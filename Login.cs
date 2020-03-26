using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeupBarSystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void txtContraseña_MouseClick(object sender, MouseEventArgs e)
        {
            txtContraseña.Text = "";
            panel2.BackColor = Color.FromArgb(217, 4, 142);
        }

        private void txtUsuario_MouseClick(object sender, MouseEventArgs e)
        {
            txtUsuario.Text = "";
            panel1.BackColor = Color.FromArgb(217, 4,142);
        }

        private void txtUsuario_MouseClick_1(object sender, MouseEventArgs e)
        {
            txtUsuario.Text = "";
            panel1.BackColor = Color.FromArgb(217, 4, 142);
        }

        

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            btnIniciar.ForeColor = Color.White;

            this.Hide();
            Modulos ventana = new Modulos();
            ventana.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
