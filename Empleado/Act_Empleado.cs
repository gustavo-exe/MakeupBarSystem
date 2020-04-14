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
    public partial class Act_Empleado : Form
    {
        private int state;
        Conexion conexion;
        private Empleado empleado = new Empleado();
        //Bariable que me ayuda a saber si el usuario selecciona un elemento
        private int click;
        public Act_Empleado()
        {
            InitializeComponent();
            conexion = new Conexion();
            click = 0;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Men_Empleado ventana = new Men_Empleado();
            ventana.Show();
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

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        /// <summary>
        /// 
        /// F U N C I O N E S
        /// 
        /// </summary>



        private void Act_Empleado_Load(object sender, EventArgs e)
        {
            ///<summary>
            ///Al entrar al formulario de una sola vez inicio mi lista 
            ///y vacios los text.
            /// </summary>

            //LISTA
            CargarDatosDeLaLista();

            //TEXTBOX
            VaciarTextBox();

        }
        private void VaciarTextBox()
        {
            txtId.Text = "";
            txtUsuario.Text = "";
            txtContraseña.Text = "";
            txtRol.Text = "";
        }
        private void CargarDatosDeLaLista()
        {
            DataTable datos = conexion.consulta(String.Format("Select idEmpleado FROM empleado;"));
            ListaDeEmpleados.DisplayMember = "idEmpleado";
            ListaDeEmpleados.DataSource = datos;
        }

        private void ValoresParaLosTextDesdeObejto(Empleado empleado)
        {
            txtId.Text = empleado.IdEmpleado.ToString();
            txtUsuario.Text = empleado.Usuario;
            txtContraseña.Text = empleado.Password;
            txtRol.Text = empleado.Rol;
        }

        private void ListaDeEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
          
                try
                {
                    //MessageBox.Show(Convert.ToString(ListaDeEmpleados.Text));

                    //Llamo al metodo BUSCAR(WHERE) que esta en la clase empleado
                    empleado = empleado.BucarID(Convert.ToString(ListaDeEmpleados.Text));


                    ValoresParaLosTextDesdeObejto(empleado);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
           
                try
                {
                    empleado = ObetenerValoresDeLosText();

                    //Llamo al metodo de modificar(UPDATE)
                    empleado.Modificar(empleado);

                    //Mostrar los botones y paneles a su estado natural
                    btnModificar.Visible = true;
                    btnEliminar.Visible = true;
                    CambiarDeColorElPanele(panelColor2, false);
                    CambiarDeColorElPanele(panelColor3, false);
                    CambiarDeColorElPanele(panelColor4, false);

                    //Restauro el valor de click para cuando se realiza otra seleccion la evalue
                    click = 0;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (click == 0 )
            {
                //MessageBox.Show(Convert.ToString(Click));
                MessageBox.Show("Debes seleccionar un item de la lista.");
            }
                
            else
            {
                //MessageBox.Show(Convert.ToString(ListaDeEmpleados.SelectedIndices.Count));
                try
                {
                    empleado = ObetenerValoresDeLosText();

                    //Llamo al metodo de modificar(DELETE)
                    empleado.Eliminar(empleado);

                    CargarDatosDeLaLista();

                    VaciarTextBox();

                    click = 0;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        private Empleado ObetenerValoresDeLosText()
        {
            Empleado unEmpleado = new Empleado();
            unEmpleado.IdEmpleado = txtId.Text;
            unEmpleado.Usuario = txtUsuario.Text;
            unEmpleado.Password = txtContraseña.Text;
            unEmpleado.Rol = txtRol.Text;

            return unEmpleado;
        } 
        
        
        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            ///<summary>
            ///Este es un boton que funciona para dar entrada a la modificacion
            ///</summary>
            //Bloquear el textbox
            //Yo lo hice desde las propiedades
            //Para que el valor no cambie
            //txtId.ReadOnly = true;

            //MessageBox.Show(Convert.ToString(click));

            if (click == 0)
            {
                //MessageBox.Show(Convert.ToString(Click));
                MessageBox.Show("Debes seleccionar un item de la lista.");
            }

            else
            {
                //Cambiar estado de los botones y cambiar el color de los paneles
                CambiarDeColorElPanele(panelColor2, true);
                CambiarDeColorElPanele(panelColor3, true);
                CambiarDeColorElPanele(panelColor4, true);
                btnModificar.Visible = false;
                btnEliminar.Visible = false;

            }
               
        }

        private void CambiarDeColorElPanele(Panel panel, Boolean estado)
        {
            if (estado == true)
                panel.BackColor = Color.Red;
            else
            {
                panel.BackColor = Color.White;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            ///<summary>
            ///Devolviendo los botones a su estado natural
            /// </summary>
            btnModificar.Visible = true;
            btnEliminar.Visible = true;
            CambiarDeColorElPanele(panelColor2, false);
            CambiarDeColorElPanele(panelColor3, false);
            CambiarDeColorElPanele(panelColor4, false);
        }



        /// <summary>
        /// Evento que cambia el estado de click
        /// </summary>

        private void ListaDeEmpleados_Click(object sender, EventArgs e)
        {
            click = 1;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
