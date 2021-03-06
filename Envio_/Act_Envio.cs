﻿using System;
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
            DataTable datos = conexion.consulta(String.Format("Select idEnvio FROM Envio;"));
            ListaEnvio.DisplayMember = "idEnvio";
            ListaEnvio.DataSource = datos;
        }


        private void ValoresParaLosText(ClaseEnvio envio)
        {
            
            txtidEnvio.Text = envio.IdEnvio.ToString();
            txtidCliente.Text = envio.IdCliente;
            txtDireccion.Text = envio.direccion;
            txtTelefono.Text = envio.telefono;
            txtidSerDeEn.Text = envio.IdServicioEntrega.ToString();
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

                btnModificar.Visible = false;
                btnEliminar.Visible = false;

            }
        }

        private ClaseEnvio ObetenerValoresDeLosText()
        {
            ClaseEnvio envio = new ClaseEnvio();
            envio.IdEnvio = Convert.ToInt32(txtidEnvio.Text.ToString());
            envio.IdCliente = txtidCliente.Text.ToString();
            envio.direccion = txtDireccion.Text.ToString();
            envio.telefono = txtTelefono.Text.ToString();
            envio.IdServicioEntrega = Convert.ToInt32(txtidSerDeEn.Text.ToString());

            return envio;
        }


        private void ListaEnvio_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                //MessageBox.Show(Convert.ToString(ListaDeEnvio.Text));

                //Llamo al metodo BUSCAR(WHERE) que esta en la clase Envio
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


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Act_Envio_Load_1(object sender, EventArgs e)
        {
            //LISTA
            CargarDatosDeLaLista();
            //TEXTBOX
            VaciarTextBox();

        }

        private void ListaEnvio_Click(object sender, EventArgs e)
        {
            click = 1;
        }



        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            try
            {
                envio = ObetenerValoresDeLosText();

                //Llamo al metodo de modificar(UPDATE)
                envio.Modificar(envio);

                //Mostrar los botones y paneles a su estado natural
                btnModificar.Visible = true;
                btnEliminar.Visible = true;


                //Restauro el valor de click para cuando se realiza otra seleccion la evalue
                click = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ///<summary>
            ///Devolviendo los botones a su estado natural
            /// </summary>
            btnModificar.Visible = true;
            btnEliminar.Visible = true;
        }
    }
    
}
