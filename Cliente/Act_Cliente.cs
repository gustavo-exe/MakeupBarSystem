using MySql.Data.MySqlClient;
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
    public partial class Act_Cliente : Form
    {
        private int state;
       // private claseCliente cliente;
        //private claseListaCliente clientes;
        private Conexion conexion;
        private int click;
        private claseCliente cliente = new claseCliente();
        public Act_Cliente()
        {
            InitializeComponent();
            //  cliente = new claseCliente();
            //clientes = new claseListaCliente();
            // Cargar_Datos();
            conexion = new Conexion();
            click = 0;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            //cancelar
            btnGuardar.Visible = true;
            button2.Visible = true;
            CambiarDeColorElPanele(panelColor3, false);
            CambiarDeColorElPanele(PanelColor1, false);
            CambiarDeColorElPanele(panelColor2, false);
            CambiarDeColorElPanele(panel9, false);
            CambiarDeColorElPanele(panel11, false);
            CambiarDeColorElPanele(panel12, false);
            CambiarDeColorElPanele(panel13, false);
            CambiarDeColorElPanele(panel8, false);
            CambiarDeColorElPanele(panel10, false);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //eliminar
          //  string cli;

            if (click == 0)
            {
                //MessageBox.Show(Convert.ToString(Click));
                MessageBox.Show("Debes seleccionar un item de la lista.");
            }

            else
            {
               // cli=Convert.ToString(ListaClientes.SelectedIndices.Count);
                try
                {
                    cliente = ObetenerValoresDeLosText();

                    //Llamo al metodo de modificar(DELETE)
                    cliente.Eliminar(cliente);

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

        private void CambiarDeColorElPanele(Panel panel, Boolean estado)
        {
            if (estado == true)
                panel.BackColor = Color.Red;
            else
            {
                panel.BackColor = Color.White;
            }
        }

        private claseCliente ObetenerValoresDeLosText()
        {

            claseCliente unCliente = new claseCliente();
            unCliente.IdCliente = txtcliente.Text;
            unCliente.NombreCliente = txtNombre.Text;
            unCliente.CorreoCliente = txtCorreo.Text;
            unCliente.TelefonoCliente = txtTelefono.Text;
            unCliente.PerfilInstagram = txtPerfil.Text;
            unCliente.CumpleanosCliente = dateFechaCumpleaños.Value;
            unCliente.CiudadCliente = txtCiudad.Text;
            unCliente.TonoDeBaseCliente = txtBase.Text;
            unCliente.TonodePolvoCliente = txtPolvo.Text;
            unCliente.TipodeCutie = txtCutie.Text;


            return unCliente;
        }


        /*
        private void Cargar_Datos()
        {
            string sql = "";

            sql = string.Format("SELECT * FROM cliente");
            DataTable t1 = clientes.SQL(sql);
            ListaClientes.DataSource = null;
            ListaClientes.DataSource = t1;
            ListaClientes.DisplayMember = "Nombre";
            ListaClientes.ValueMember = "idCliente";
            ListaClientes.Refresh();
        }
        */
        private void VaciarTextBox()
        {
            txtcliente.Text = "";
            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            txtPerfil.Text = "";
            dateFechaCumpleaños.Value = DateTime.Today;
            txtCiudad.Text = "";
            txtBase.Text = "";
            txtPolvo.Text = "";
            txtCutie.Text = "";

        }
        private void CargarDatosDeLaLista()
        {
            DataTable datos = conexion.consulta(String.Format("Select IdCliente FROM cliente;"));
            ListaClientes.DisplayMember = "IdCliente";
            ListaClientes.DataSource = datos;
        }

        private void ListaClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //MessageBox.Show(Convert.ToString(ListaDeEmpleados.Text));

                //Llamo al metodo BUSCAR(WHERE) que esta en la clase empleado
                cliente = cliente.BuscarID(Convert.ToString(ListaClientes.Text));


                ValoresParaLosTextDesdeObejto(cliente);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void ValoresParaLosTextDesdeObejto(claseCliente cliente)
        {
            txtcliente.Text = cliente.IdCliente.ToString();
            txtNombre.Text = cliente.NombreCliente.ToString();
            txtCorreo.Text = cliente.CorreoCliente.ToString();
            txtTelefono.Text = cliente.TelefonoCliente.ToString();
            txtPerfil.Text = cliente.PerfilInstagram.ToString();
            dateFechaCumpleaños.Value = cliente.CumpleanosCliente;
            txtCiudad.Text = cliente.CiudadCliente.ToString();
            txtBase.Text = cliente.TonoDeBaseCliente.ToString();
            txtPolvo.Text = cliente.TonodePolvoCliente.ToString();
            txtCutie.Text = cliente.TipodeCutie.ToString();

        }

        private void ListaClientes_Click(object sender, EventArgs e)
        {
            click = 1;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Act_Cliente_Load(object sender, EventArgs e)
        {
            CargarDatosDeLaLista();

            //TEXTBOX
            VaciarTextBox();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            //guardar
            try
            {
                cliente = ObetenerValoresDeLosText();

                //Llamo al metodo de modificar(UPDATE)
                cliente.Modificar(cliente);

                //Mostrar los botones y paneles a su estado natural
                button2.Visible = false;
                btnGuardar.Visible = false;
                CambiarDeColorElPanele(panelColor3, false);
                CambiarDeColorElPanele(PanelColor1, false);
                CambiarDeColorElPanele(panelColor2, false);
                CambiarDeColorElPanele(panel9, false);
                CambiarDeColorElPanele(panel11, false);
                CambiarDeColorElPanele(panel12, false);
                CambiarDeColorElPanele(panel13, false);
                CambiarDeColorElPanele(panel8, false);
                CambiarDeColorElPanele(panel10, false);

                //Restauro el valor de click para cuando se realiza otra seleccion la evalue
                click = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //modificar

            if (click == 0)
            {
                //MessageBox.Show(Convert.ToString(Click));
                MessageBox.Show("Debes seleccionar un item de la lista.");
            }

            else
            {
                //Cambiar estado de los botones y cambiar el color de los paneles

                CambiarDeColorElPanele(panelColor3, true);
                CambiarDeColorElPanele(PanelColor1, true);
                CambiarDeColorElPanele(panelColor2, true);
                CambiarDeColorElPanele(panel9, true);
                CambiarDeColorElPanele(panel11, true);
                CambiarDeColorElPanele(panel12, true);
                CambiarDeColorElPanele(panel13, true);
                CambiarDeColorElPanele(panel8, true);
                CambiarDeColorElPanele(panel10, true);
                button2.Visible = false;
                btnGuardar.Visible = false;

            }

        }
    }
}
