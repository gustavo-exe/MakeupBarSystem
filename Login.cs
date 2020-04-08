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
       IniciarSecion empleado = new IniciarSecion();
       Conexion conexion = new Conexion();
        public Login()
        {
            InitializeComponent();
            conexion = new Conexion();
           
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
            
            try
            {
                IniciarSecion login = empleado.BucarUsuario(txtUsuario.Text);

                if(login.Password == txtContraseña.Text)
                {
                    MessageBox.Show("Bienvenido al sistema.");

                    conexion.conectar();

                    this.Hide();
                    Modulos ventana = new Modulos();
                    ventana.Show();

                }
                else { MessageBox.Show("DATOS INCORRECTOS"); }

                // Objeto de tipo usuario que almacena el valor del usuario
                // si éste existe en la base de datos
                //Empleado empleado = empleado.BuscarUsuario(txtUserName.Text);
                // Verificar que la contraseña ingresada es igual a la almacenada
                // en la base de datos
                /* if (empleado.Password == pwbPassword.Password)
                 {
                     MessageBox.Show("Bienvenido al sistema de Reservaciones");

                     // Crear un objeto de tipo Modulos para mostrar el menú
                     this.Hide();
                     Modulos ventana = new Modulos();
                     ventana.Show();
                 }
                 else
                 {
                     MessageBox.Show("Base de datos no conectado.");
                 }*/
                


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            txtContraseña.PasswordChar ='●';
        }
    }
}
