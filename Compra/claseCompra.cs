using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeupBarSystem.Compra
{
    class claseCompra
    {
        private int idCompra;
        private int idProveedor;
        private String nombreProducto;
        private int cantidad;
        private double costo;
        private String descripcion;
        private Conexion conexion;
        private MySqlException error;

        public claseCompra()
        {
            idCompra = 0;
            idProveedor = 0;
            nombreProducto = "";
            cantidad = 0;
            costo = 0.0;
            descripcion = "";
            conexion = new Conexion();
        }

        public claseCompra(int idc, int idp, string nomp, int can,double cos,string desc)
        {
            idCompra=idc;
            idProveedor = idp;
            nombreProducto = nomp;
            cantidad = can;
            costo = cos;
            descripcion = desc;
            conexion = new Conexion();
        }

        public int IdCompra
        {
            get { return idCompra; }
            set { idCompra = value; }
        }

        public int IdProveedor
        {
            get { return idProveedor; }
            set { idProveedor = value; }
        }

        public string NombreProducto
        {
            get { return nombreProducto; }
            set { nombreProducto = value; }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public double Costo
        {
            get { return costo; }
            set { costo = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public object Error { get; internal set; }

        public Boolean Insertar()
        {
            Boolean r = false;
            r = conexion.IUD(String.Format("INSERT INTO compra (IDProveedor, NombreDelProducto, Cantidad, Costo, Descripcion) VALUE ('{0}','{1}','{2}','{3}','{4}');",idProveedor,nombreProducto ,cantidad,costo,descripcion));
            return r;
        }

        /// <summary>
        /// 
        /// METODO CON SELECT WHERE
        /// 
        /// </summary>

        public claseCompra BuscarID(int id)
        {
            claseCompra compra = new claseCompra();


            DataTable Tabla = conexion.consulta(string.Format("SELECT * FROM compra WHERE IdCompra='{0}';", id));
            //MessageBox.Show(Convert.ToString(id));
            //empleado.usuario = "HHHH";
            //MessageBox.Show(Convert.ToString(idEmpleado = Tabla.Rows[0][0].ToString()));
            if (Tabla.Rows.Count > 0)
            {
                compra.idCompra = Convert.ToInt32(Tabla.Rows[0][0]);
                compra.idProveedor = Convert.ToInt32(Tabla.Rows[0][1]);
                compra.nombreProducto = Tabla.Rows[0][2].ToString();
                compra.cantidad = Convert.ToInt32(Tabla.Rows[0][3]);
                compra.costo = Convert.ToDouble(Tabla.Rows[0][4]);
                compra.descripcion = Tabla.Rows[0][5].ToString();
                //MessageBox.Show("Si hay");

            }
            return compra;

        }
        
        public void Modificar(claseCompra compra)
        {
            int id;
            id = compra.idCompra;
            if (conexion.IUD(string.Format("UPDATE compra " +
                                            "SET " +
                                            "IDProveedor='{0}', " +
                                            "NombreDelProducto='{1}', " +
                                            "Cantidad='{2}', " +
                                            "Costo='{3}', " +
                                            "Descripcion='{4}' " +
                                            "WHERE IdCompra='{5}'",
                                            compra.IdProveedor, compra.NombreProducto, compra.Cantidad,compra.Costo, compra.Descripcion,compra.IdCompra)))
            {
                MessageBox.Show("Se actulizaron los datos de: " + Convert.ToString(id));
            }
        }
        public void Eliminar(claseCompra compra)
        {
            int id;

            id = Convert.ToInt32(compra.idCompra);
            if (conexion.IUD(string.Format("DELETE FROM compra WHERE IdCompra='{0}';",compra.idCompra)))
            {
                MessageBox.Show("Se elimino la compra: " + Convert.ToString(compra.idCompra));
            }
        }

    }
}
