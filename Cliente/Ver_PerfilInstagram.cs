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
    public partial class Ver_PerfilInstagram : Form
    {
        private int state;
        private claseListaInstagram usuariosInstagram;
        private claseInstagram usuarioInstagram;
        public Ver_PerfilInstagram()
        {
            InitializeComponent();
            usuariosInstagram = new claseListaInstagram();
            usuarioInstagram = new claseInstagram();
            Cargar_Datos();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Men_Cliente ventana = new Men_Cliente();
            ventana.Show();
        }

     
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button4_Click_1(object sender, EventArgs e)
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

        private void Cargar_Datos()
        {
            string sql = "";

            sql = string.Format("SELECT IdCliente, Usuario, URL FROM Instagram");
            DataTable t1 = usuariosInstagram.SQL(sql);
            dgvUsuarios.DataSource = t1;
            dgvUsuarios.Refresh();

        }
        private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            usuarioInstagram.IdCliente = dgvUsuarios.CurrentRow.Cells[1].Value.ToString();
            usuarioInstagram.Usuario = dgvUsuarios.CurrentRow.Cells[2].Value.ToString();
            usuarioInstagram.Url = dgvUsuarios.CurrentRow.Cells[3].Value.ToString();
            this.DialogResult = DialogResult.OK;
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
         public claseInstagram UsuarioInstagram
        {
            get { return usuarioInstagram; }
        }

        private void mostrar(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cargar_Datos();
        }



    }
}
