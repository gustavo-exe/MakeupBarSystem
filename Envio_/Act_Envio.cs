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
    public partial class Act_Envio : Form
    {
        private int state;
        Conexion conexion;
        private ClaseEnvio envio = new ClaseEnvio();
        private int click;
        public Act_Envio()
        {
            InitializeComponent();
            conexion = new Conexion();
            click = 0;
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

        private void Act_Envio_Load(object sender, EventArgs e)
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
            txtidEnvio.Text = "";
            txtidCliente.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtidSerDeEn.Text = "";
        }

        private void CargarDatosDeLaLista()
        {
            DataTable datos = conexion.consulta(String.Format("Select idEmpleado FROM empleado;"));
            ListaEnvio.DisplayMember = "idEnvio";
            ListaEnvio.DataSource = datos;
        }


        private void ValoresParaLosText(ClaseEnvio envio)
        {
            txtidEnvio.Text = envio.IdEnvio;
            txtidCliente.Text = envio.IdCliente;
            txtDireccion.Text = envio.direccion;
            txtTelefono.Text = envio.direccion;
            txtidSerDeEn.Text = envio.IdServicioEntrega;
        }
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (click == 0)
            {
                //MessageBox.Show(Convert.ToString(Click));
                MessageBox.Show("Debes seleccionar un item de la lista.");
            }

            else
            {
                //Cambiar estado de los botones y cambiar el color de los paneles
                CambiarDeColorElPanel(panelColor2, true);
                CambiarDeColorElPanel(panelColor3, true);
                CambiarDeColorElPanel(panelColor6, true);
                btnModificar.Visible = false;
                btnEliminar.Visible = false;

            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                envio = ObetenerValoresDeLosText();

                //Llamo al metodo de modificar(UPDATE)
                envio.Modificar(envio);

                //Mostrar los botones y paneles a su estado natural
                btnModificar.Visible = true;
                btnEliminar.Visible = true;
                CambiarDeColorElPanel(panelColor2, false);
                CambiarDeColorElPanel(panelColor3, false);
                CambiarDeColorElPanel(panelColor5, false);

                //Restauro el valor de click para cuando se realiza otra seleccion la evalue
                click = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private ClaseEnvio ObetenerValoresDeLosText()
        {
            ClaseEnvio envio = new ClaseEnvio();
            envio.IdEnvio = txtidEnvio.Text;
            envio.IdCliente = txtidCliente.Text;
            envio.direccion = txtDireccion.Text;
            envio.telefono = txtTelefono.Text;
            envio.IdServicioEntrega = txtidSerDeEn.Text;

            return envio;
        }

        private void CambiarDeColorElPanel(Panel panel, Boolean estado)
        {
            if (estado == true)
                panel.BackColor = Color.Red;
            else
            {
                panel.BackColor = Color.White;
            }
        }

        private void ListaEnvio_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                //MessageBox.Show(Convert.ToString(ListaDeEmpleados.Text));

                //Llamo al metodo BUSCAR(WHERE) que esta en la clase empleado
                envio = envio.BuscarID(Convert.ToString(ListaEnvio.Text));


                ValoresParaLosText(envio);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (click == 0)
            {
                //MessageBox.Show(Convert.ToString(Click));
                MessageBox.Show("Debes seleccionar un item de la lista.");
            }

            else
            {
                //MessageBox.Show(Convert.ToString(ListaDeEmpleados.SelectedIndices.Count));
                try
                {
                    envio = ObetenerValoresDeLosText();

                    //Llamo al metodo de modificar(DELETE)
                    envio.Eliminar(envio);

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

        private void ListaDeEnvio_Click(object sender, EventArgs e)
        {
            click = 1;
        }
    }
}
