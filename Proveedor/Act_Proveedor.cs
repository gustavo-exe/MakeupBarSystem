using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeupBarSystem.Proveedor
{
    public partial class Act_Proveedor : Form
    {
        private int state;
        private int click;
        Conexion conexion;
        private claseProveedor proveedor = new claseProveedor();
        public Act_Proveedor()
        {
            InitializeComponent();
            conexion = new Conexion();
            click = 0;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

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
            View_inventario ventana = new View_inventario();
            ventana.Show();
        }

        private void Act_Proveedor_Load(object sender, EventArgs e)
        {
            CargarDatosALaLista();

            VaciarTextBox();
        }

        private void VaciarTextBox()
        {
            txtCorreo.Text = "";
            txtDescripcion.Text = "";
            txtNombreConstacto.Text = "";
            txtNombreEmpresa.Text = "";
            //txtProveedor.Text = "";
            txtTelefonoContacto.Text = "";
        }

        private void CargarDatosALaLista()
        {
            DataTable datos = conexion.consulta(String.Format("Select IdProveedor FROM proveedor;"));
            ListaDeProveedores.DisplayMember = "IdProveedor";
            ListaDeProveedores.DataSource = datos;
        }

        private void ValoresParaLosTextDesdeObejto(claseProveedor proveedor)
        {
            txtCorreo.Text = proveedor.CorreoProveedor;
            txtDescripcion.Text = proveedor.DescripcionProveedor;
            txtNombreConstacto.Text = proveedor.NombreContacto;
            txtNombreEmpresa.Text = proveedor.NombreEmpresaProveedor;
            txtTelefonoContacto.Text = proveedor.TelefonoProveedor;
        }

        private void ListaDeProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //MessageBox.Show(Convert.ToString(ListaDeEmpleados.Text));

                //Llamo al metodo BUSCAR(WHERE) que esta en la clase empleado
                //empleado = empleado.BucarID(Convert.ToString(ListaDeEmpleados.Text));
                proveedor = proveedor.BucarID(Convert.ToInt32(ListaDeProveedores.Text));

                ValoresParaLosTextDesdeObejto(proveedor);
                //click = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private claseProveedor ObetenerValoresDeLosText()
        {
            claseProveedor unProveedor = new claseProveedor();

            //Cargue este dato porque es lo unico que me provee el id
            //y lo ncesito para actulizar.
            //Lo cargque desde aqui porque no tengo un textbox
            unProveedor.IdProveedor = Convert.ToInt32 (ListaDeProveedores.Text);
            ///////////////////////////////////////////////////////////////////
         
            unProveedor.CorreoProveedor = txtCorreo.Text;
            unProveedor.DescripcionProveedor = txtDescripcion.Text;
            unProveedor.NombreContacto = txtNombreConstacto.Text;
            unProveedor.NombreEmpresaProveedor = txtNombreEmpresa.Text;
            unProveedor.TelefonoProveedor = txtTelefonoContacto.Text;
            return unProveedor;
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                proveedor = ObetenerValoresDeLosText();

                //Llamo al metodo de modificar(UPDATE)
                proveedor.Modificar(proveedor);

                //Mostrar los botones y paneles a su estado natural
                btnModificar.Visible = true;
                btnEliminar.Visible = true;
                CambiarDeColorElPanele(panelColor1, false);
                CambiarDeColorElPanele(panelColor2, false);
                CambiarDeColorElPanele(panelColor3, false);
                CambiarDeColorElPanele(panelColor4, false);
                CambiarDeColorElPanele(panelColor5, false);
                

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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (click == 0)
            {
                //MessageBox.Show(Convert.ToString(Click));
                MessageBox.Show("Debes seleccionar un item de la lista.");
            }

            else
            {
                //Cambiar estado de los botones y cambiar el color de los paneles
                CambiarDeColorElPanele(panelColor1, true);
                CambiarDeColorElPanele(panelColor2, true);
                CambiarDeColorElPanele(panelColor3, true);
                CambiarDeColorElPanele(panelColor4, true);
                CambiarDeColorElPanele(panelColor5, true);
                btnModificar.Visible = false;
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
                //MessageBox.Show(Convert.ToString(ListaDeEmpleados.SelectedIndices.Count));
                try
                {
                    proveedor = ObetenerValoresDeLosText();

                    //Llamo al metodo de modificar(DELETE)
                    proveedor.Eliminar(proveedor);

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

        private void ListaDeProveedores_Click(object sender, EventArgs e)
        {
            click = 1;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnModificar.Visible = true;
            btnEliminar.Visible = true;
            CambiarDeColorElPanele(panelColor1, false);
            CambiarDeColorElPanele(panelColor2, false);
            CambiarDeColorElPanele(panelColor3, false);
            CambiarDeColorElPanele(panelColor4, false);
            CambiarDeColorElPanele(panelColor5, false);
        }
    }
}
