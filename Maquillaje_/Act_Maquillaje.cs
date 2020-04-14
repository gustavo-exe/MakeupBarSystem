using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MakeupBarSystem.Maquillaje_;

namespace MakeupBarSystem.Maquillaje
{
    public partial class Act_Maquillaje : Form
    {
        private int state;
        Conexion conexion;
        private claseMaquillaje maquillaje = new claseMaquillaje();
        private int click;

        public Act_Maquillaje()
        {
            InitializeComponent();
            conexion = new Conexion();
            click = 0;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Men_Maquillaje ventana = new Men_Maquillaje();
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

        private void btnInsertar_Click(object sender, EventArgs e)
        {

        }

        private void Act_Maquillaje_Load(object sender, EventArgs e)
        {

            CargarDatosDeLaLista();
            VaciarTextBox();

        }
        private void CargarDatosDeLaLista()
        {
            DataTable datos = conexion.consulta(String.Format("Select idCodigoDeBarra FROM maquillaje;"));
            ListaMaquillaje.DisplayMember = "idCodigoDeBarra";
            ListaMaquillaje.DataSource = datos;
        }
        private void VaciarTextBox()
        {
            //txtCodigoDeBarra.Text = "";
            txtCantidad.Text = "";
            txtDescripcion.Text = "";
            
            txtMarca.Text = "";
            txtNombre.Text = "";
            txtNumero.Text = "";
            txtPrecio.Text = "";
            txtProvedor.Text = "";
        }

        private void ValoresParaLosTextDesdeObejto(claseMaquillaje maquillaje)
        {
            txtCantidad.Text = maquillaje.cantidad;
            txtDescripcion.Text = maquillaje.descripcion;
            
            txtNumero.Text = maquillaje.tonoNumero;
            txtMarca.Text = maquillaje.marca;
            txtNombre.Text = maquillaje.nombreDelProducto;
            txtPrecio.Text = maquillaje.precioUnitario;
            txtProvedor.Text = maquillaje.proveedor.ToString();
        }

        private void ListaMaquillaje_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                maquillaje = maquillaje.BuscarID(Convert.ToInt32(ListaMaquillaje.Text));


                ValoresParaLosTextDesdeObejto(maquillaje);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private claseMaquillaje ObtenerValoresDeLosText()
        {
            claseMaquillaje unMaquillaje = new claseMaquillaje();

            unMaquillaje.IdCodigoDeBarra = Convert.ToInt32(ListaMaquillaje.Text);
            unMaquillaje.cantidad = txtCantidad.Text;
            unMaquillaje.descripcion = txtDescripcion.Text;
         
            unMaquillaje.marca = txtMarca.Text;
            unMaquillaje.nombreDelProducto = txtNombre.Text;
            unMaquillaje.tonoNumero = txtNumero.Text;
            unMaquillaje.precioUnitario = txtPrecio.Text;
            unMaquillaje.proveedor = Convert.ToInt32(txtProvedor.Text);

            return unMaquillaje;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                maquillaje = ObtenerValoresDeLosText();

                //Llamo al metodo de modificar(UPDATE)
                maquillaje.Modificar(maquillaje);

                //Mostrar los botones y paneles a su estado natural
                btnModificar.Visible = true;
                btnEliminar.Visible = true;

                CambiarDeColorElPanele(panel10, false);

                CambiarDeColorElPanele(panel12, false);
                CambiarDeColorElPanele(panel13, false);
                CambiarDeColorElPanele(panel14, false);
                CambiarDeColorElPanele(panel15, false);


                CambiarDeColorElPanele(panel8, false);
               
                CambiarDeColorElPanele(panel6, false);
                CambiarDeColorElPanele(panel9, false);


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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

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


                CambiarDeColorElPanele(panel10, true);
               
                CambiarDeColorElPanele(panel12, true);
                CambiarDeColorElPanele(panel13, true);
                CambiarDeColorElPanele(panel14, true);
                CambiarDeColorElPanele(panel15, true);



                CambiarDeColorElPanele(panel8, true);

                CambiarDeColorElPanele(panel6, true);
                CambiarDeColorElPanele(panel9, true);

                btnModificar.Visible = false;
                btnEliminar.Visible = false;

            }
        }

        private void ListaMaquillaje_Click(object sender, EventArgs e)
        {
            click = 1;
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
                    maquillaje = ObtenerValoresDeLosText();

                    //Llamo al metodo de modificar(DELETE)
                    maquillaje.Eliminar(maquillaje);

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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnModificar.Visible = true;
            btnEliminar.Visible = true;

            CambiarDeColorElPanele(panel10, false);

            CambiarDeColorElPanele(panel12, false);
            CambiarDeColorElPanele(panel13, false);
            CambiarDeColorElPanele(panel14, false);
            CambiarDeColorElPanele(panel15, false);


            CambiarDeColorElPanele(panel8, false);
            
            CambiarDeColorElPanele(panel6, false);
            CambiarDeColorElPanele(panel9, false);
        }
    }
}
