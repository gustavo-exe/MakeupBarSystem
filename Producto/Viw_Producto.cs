using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeupBarSystem.Producto
{
    public partial class Viw_Producto : Form
    {
        Conexion conexion;
        public Viw_Producto()
        {
            InitializeComponent();
            conexion = new Conexion();
        }

        private void Viw_Producto_Load(object sender, EventArgs e)
        {
            DataTable Datos = conexion.consulta(String.Format("SELECT idProducto AS 'N', CodigoDeBarra,NombreDelProducto,Precio,Cantidad  FROM Producto;"));
            dataGridView1.DataSource = Datos;
            dataGridView1.Refresh();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventas ventana = new Ventas();
            ventana.Show();
        }
    }
}
