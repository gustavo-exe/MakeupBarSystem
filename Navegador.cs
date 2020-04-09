using MakeupBarSystem.Cliente;
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
    public partial class Navegador : Form
    {
        private int state;
        Conexion conexion;
        private claseInstagram instagram = new claseInstagram();

        public Navegador()
        {
            InitializeComponent();
            conexion = new Conexion();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                instagram = instagram.BuscarURL(Convert.ToString(ListaPerfiles.Text));

                webBrowser1.Navigate(instagram.Url);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void Navigate(String address)
        {
            if (String.IsNullOrEmpty(address)) return;
            if (address.Equals("about:blank")) return;
            if (!address.StartsWith("http://") && !address.StartsWith("https://"))
            {
                address = "http://" + address;
            }
            try
            {
                webBrowser1.Navigate(new Uri(address));
            }
            catch (System.UriFormatException)
            {

                return;

            }

        }    

   

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.instagram.com");
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
            Administrativo ventana = new Administrativo();
            ventana.Show();
        }

        private void Navegador_Load(object sender, EventArgs e)
        {
            CargarPerfilesDeInsta();
        }

        private void CargarPerfilesDeInsta()
        {
            DataTable datos = conexion.consulta(String.Format("Select Usuario FROM instagram;"));
            ListaPerfiles.DisplayMember = "Usuario";
            ListaPerfiles.DataSource = datos;
        }

        private void ListaPerfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
