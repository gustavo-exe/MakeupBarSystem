using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeupBarSystem.Venta
{
    public partial class Viw_Venta : Form
    {

        Conexion conexion;
        private int state;
        public Viw_Venta()
        {
            InitializeComponent();
            conexion = new Conexion();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Men_Venta ventana = new Men_Venta();
            ventana.Show();
        }

        private void Viw_Venta_Load(object sender, EventArgs e)
        {
            DataTable Datos = conexion.consulta(String.Format("SELECT idVenta, nombreEmpresa, nombreDelContrato, telefonoContacto, correo, descripcion FROM DetalleDeVenta ;"));
            VerVenta.DataSource = Datos;
            VerVenta.Refresh();
        }
    }
}
