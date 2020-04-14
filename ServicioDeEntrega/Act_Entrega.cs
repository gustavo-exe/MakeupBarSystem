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
    public partial class Act_Entrega : Form
    {
        private int state;
        private int click;
        Conexion conexion;
        private claseEntrega entrega = new claseEntrega();

        public Act_Entrega()
        {
            InitializeComponent();
            conexion = new Conexion();
            click = 0;
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

        private void Act_Servicio_Load(object sender, EventArgs e)
        {
            CargarDatosALaLista();

            VaciarTextBox();
        }

        private void VaciarTextBox()
        {
            txtCorreo.Text = "";
            txtNombreConstacto.Text = "";
            txtNombreEmpresa.Text = "";
            //txtProveedor.Text = "";
            txtTelefonoContacto.Text = "";
        }

        private void CargarDatosALaLista()
        {
            DataTable datos = conexion.consulta(String.Format("Select IdServicioEntrega FROM serviciodeentrega;"));
            ListaDeEntregas.DisplayMember = "IdServicioEntrega";
            ListaDeEntregas.DataSource = datos;
        }

        private void ValoresParaLosTextDesdeObejto(claseEntrega entrega)
        {
            txtCorreo.Text = entrega.Correo;
            txtNombreConstacto.Text = entrega.NombreContacto;
            txtNombreEmpresa.Text = entrega.NombreEmpresa;
            txtTelefonoContacto.Text = entrega.Telefono;
        }

        private void ListaDeEntregas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //MessageBox.Show(Convert.ToString(ListaDeEmpleados.Text));

                //Llamo al metodo BUSCAR(WHERE) que esta en la clase empleado
                //empleado = empleado.BucarID(Convert.ToString(ListaDeEmpleados.Text));
                entrega = entrega.BuscaID(Convert.ToInt32(ListaDeEntregas.Text));

                ValoresParaLosTextDesdeObejto(entrega);
                //click = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private claseEntrega ObetenerValoresDeLosText()
        {
            claseEntrega unaEntrega = new claseEntrega();

            //Cargue este dato porque es lo unico que me provee el id
            //y lo ncesito para actulizar.
            //Lo cargque desde aqui porque no tengo un textbox
            unaEntrega.IdServicioEntrega = Convert.ToInt32(ListaDeEntregas.Text);
            ///////////////////////////////////////////////////////////////////

            unaEntrega.Correo = txtCorreo.Text;
            unaEntrega.NombreContacto = txtNombreConstacto.Text;
            unaEntrega.NombreEmpresa = txtNombreEmpresa.Text;
            unaEntrega.Telefono = txtTelefonoContacto.Text;
            return unaEntrega;
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                entrega = ObetenerValoresDeLosText();

                //Llamo al metodo de modificar(UPDATE)
                entrega.Modificar(entrega);

                //Mostrar los botones y paneles a su estado natural
                btnModificar.Visible = true;
                btnEliminar.Visible = true;
                CambiarDeColorElPanele(panelColor1, false);
                CambiarDeColorElPanele(panelColor1, false);
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


        private void CambiarDeColorElPanele(Panel panel, Boolean estado)
        {
            if (estado == true)
                panel.BackColor = Color.Red;
            else
            {
                panel.BackColor = Color.White;
            }
        }



        private void btnInsertar_Click(object sender, EventArgs e)
        {
            click = 1;
            if (click == 0)
            {
                //MessageBox.Show(Convert.ToString(Click));
                MessageBox.Show("Debes seleccionar un item de la lista.");
            }

            else
            {
                //Cambiar estado de los botones y cambiar el color de los paneles
                CambiarDeColorElPanele(panelColor1, true);
                CambiarDeColorElPanele(panelColor1, true);
                CambiarDeColorElPanele(panelColor3, true);
                CambiarDeColorElPanele(panelColor4, true);
                //btnModificar.Visible = false;
                btnEliminar.Visible = false;

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

                try
                {
                    entrega = ObetenerValoresDeLosText();

                    //Llamo al metodo de modificar(DELETE)
                    entrega.Eliminar(entrega);

                    CargarDatosALaLista();

                    VaciarTextBox();

                    click = 0;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }


        private void ListaDeEntregas_Click(object sender, EventArgs e)
        {
            click = 1;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnModificar.Visible = true;
            btnEliminar.Visible = true;
            CambiarDeColorElPanele(panelColor1, false);
            CambiarDeColorElPanele(panelColor1, false);
            CambiarDeColorElPanele(panelColor3, false);
            CambiarDeColorElPanele(panelColor4, false);
        }
        private void CargarDatosDeLaLista()
        {
            DataTable datos = conexion.consulta(String.Format("Select IdServicioEntrega FROM serviciodeentrega;"));
            ListaDeEntregas.DisplayMember = "IdServicioEntrega";
            ListaDeEntregas.DataSource = datos;
        }


        private void Act_Entrega_Load(object sender, EventArgs e)
        {

            //LISTA
            CargarDatosDeLaLista();

            //TEXTBOX
            VaciarTextBox();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
