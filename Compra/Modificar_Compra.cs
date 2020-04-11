using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeupBarSystem.Compra
{
    public partial class Modificar_Compra : Form
    {
        private Conexion conexion;
        private int click;
        private claseCompra compra = new claseCompra();

        public Modificar_Compra()
        {
            InitializeComponent();
            conexion = new Conexion();
            click = 0;
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu_Compra ventana = new Menu_Compra();
            ventana.Show();
        }

        private void CargarDatosDeLaLista()
        {
            DataTable datos = conexion.consulta(String.Format("Select IdCompra FROM compra;"));
            ListaDeCompras.DisplayMember = "IdCompra";
            ListaDeCompras.DataSource = datos;
        }
        private void ValoresParaLosTextDesdeObjeto(claseCompra compra)
        {
            txtproveedor.Text = compra.IdProveedor.ToString();
            txtnombre.Text = compra.NombreProducto.ToString();
            txtcantidad.Text = compra.Cantidad.ToString();
            txtcosto.Text = compra.Costo.ToString();
            txtdescripcion.Text = compra.Descripcion.ToString();

        }

        private void ListaDeVentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //MessageBox.Show(Convert.ToString(ListaDeEmpleados.Text));

                //Llamo al metodo BUSCAR(WHERE) que esta en la clase empleado
                compra = compra.BuscarID(Convert.ToString(ListaDeCompras.Text));


                ValoresParaLosTextDesdeObjeto(compra);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void ListaDeVentas_Click(object sender, EventArgs e)
        {
            click = 1;
        }

        private void Modificar_Compra_Load(object sender, EventArgs e)
        {
            CargarDatosDeLaLista();

            //TEXTBOX
            VaciarTextBox();
        }


        private void VaciarTextBox()
        {
            txtproveedor.Text = "";
            txtnombre.Text = "";
            txtcantidad.Text = "";
            txtcosto.Text = "";
            txtdescripcion.Text = "";
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

        private claseCompra ObetenerValoresDeLosText()
        {

            claseCompra unacompra = new claseCompra();
            unacompra.IdProveedor = Convert.ToInt32(txtproveedor.Text);
            unacompra.NombreProducto = txtnombre.Text;
            unacompra.Cantidad = Convert.ToInt32(txtcantidad.Text);
            unacompra.Costo = Convert.ToInt32(txtcosto.Text);
            unacompra.Descripcion = txtdescripcion.Text;


            return unacompra;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            //guardar

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Cancelar
            btnModificar.Visible = true;
            btnEliminar.Visible = true;
            CambiarDeColorElPanele(panelColor3, false);
            CambiarDeColorElPanele(PanelColor1, false);
            CambiarDeColorElPanele(panelColor2, false);
            CambiarDeColorElPanele(panel9, false);
            CambiarDeColorElPanele(panel11, false);
            CambiarDeColorElPanele(panel12, false);
            CambiarDeColorElPanele(panel10, false);

        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            //eliminar
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
                    compra = ObetenerValoresDeLosText();

                    //Llamo al metodo de modificar(DELETE)
                    compra.Eliminar(compra);

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

                CambiarDeColorElPanele(panel10, true);
                btnCancelar.Visible = false;
                btnguardar.Visible = false;

            }
        }
    }
}
