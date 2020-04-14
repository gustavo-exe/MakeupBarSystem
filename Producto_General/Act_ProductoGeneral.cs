using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MakeupBarSystem.Producto_General;

namespace MakeupBarSystem
{
    public partial class Act_ProductoGeneral : Form
    {
        private int state;
        Conexion conexion;
        private claseProductoGeneral productoGeneral = new claseProductoGeneral();
        private int click;

        public Act_ProductoGeneral()
        {
            InitializeComponent();
            conexion = new Conexion();
            click = 0;

        }
        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Men_ProductoGeneral ventana = new Men_ProductoGeneral();
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

        private void Act_ProductoGeneral_Load(object sender, EventArgs e)
        {
            //LISTA
            CargarDatosDeLaLista();
            //TEXTBOX
            VaciarTextBox();
        }
        private void CargarDatosDeLaLista()
        {
            DataTable datos = conexion.consulta(String.Format("Select idCodigoDeBarra FROM productogeneral;"));
            ListaDeProductoGeneral.DisplayMember = "idCodigoDeBarra";
            ListaDeProductoGeneral.DataSource = datos;
        }
        private void VaciarTextBox()
        {
            txtNombre.Text = "";
            txtxMarca.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
            txtDescripcion.Text = "";
            txtidProveedor.Text = "";
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            btnInsertar.Visible = true;
            btnEliminar.Visible = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnInsertar.Visible = true;
            btnEliminar.Visible = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                productoGeneral = ObetenerValoresDeLosText();

                //Llamo al metodo de modificar(UPDATE)
                productoGeneral.Modificar(productoGeneral);

                //Mostrar los botones y paneles a su estado natural
                btnInsertar.Visible = true;
                btnEliminar.Visible = true;


                //Restauro el valor de click para cuando se realiza otra seleccion la evalue
                click = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private claseProductoGeneral ObetenerValoresDeLosText()
        {
            claseProductoGeneral productoGeneral = new claseProductoGeneral();
            productoGeneral.IdCodigoDeBarra = Convert.ToInt32(txtIdCodigoDeBarra.Text.ToString());
            productoGeneral.nombreProducto = txtNombre.Text.ToString();
            productoGeneral.marca = txtxMarca.Text.ToString();
            productoGeneral.precioUnitario = txtPrecio.Text.ToString();
            productoGeneral.cantidad = txtCantidad.Text.ToString();
            productoGeneral.descripcion = txtDescripcion.Text.ToString();
            productoGeneral.proveedor = Convert.ToInt32(txtidProveedor.Text);


            return productoGeneral;
        }

        private void ListaDeProductoGeneral_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                productoGeneral = productoGeneral.BuscarID(Convert.ToString(ListaDeProductoGeneral.Text));


                ValoresParaLosTextDesdeObejto(productoGeneral);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void ValoresParaLosTextDesdeObejto(claseProductoGeneral productoGeneral)
        {
            txtIdCodigoDeBarra.Text = productoGeneral.IdCodigoDeBarra.ToString();
            txtNombre.Text = productoGeneral.nombreProducto;
            txtxMarca.Text = productoGeneral.marca;
            txtPrecio.Text = productoGeneral.precioUnitario;
            txtCantidad.Text = productoGeneral.cantidad;
            txtDescripcion.Text = productoGeneral.descripcion;
            txtidProveedor.Text = productoGeneral.proveedor.ToString();


        }

        private void ListaDeProductoGeneral_Click(object sender, EventArgs e)
        {
            click = 1;
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
                btnInsertar.Visible = false;
                btnEliminar.Visible = false;

            }
        }
    }
}
