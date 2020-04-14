using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace MakeupBarSystem.Producto_General
{
    class claseProductoGeneral
    {
        private Conexion conexion;
        private int idCodigoDeBarra;
        private string NombreProducto;
        private string Marca;
        private string PrecioUnitario;
        private string Cantidad;
        private string Descripcion;
        private int idProveedor;
        private MySqlException error;

        public claseProductoGeneral()
        {
            idCodigoDeBarra = 0;
            NombreProducto = "";
            Marca = "";
            PrecioUnitario = "";
            Cantidad = "";
            Descripcion = "";
            idProveedor = 0;
            conexion = new Conexion();
        }

        public claseProductoGeneral(int c, string n, string m, string p, string ca, string d, int pr)
        {
            idCodigoDeBarra = c;
            NombreProducto = n;
            Marca = m;
            PrecioUnitario = p;
            Cantidad = ca;
            Descripcion = d;
            idProveedor = pr;
            conexion = new Conexion();
        }

        public Boolean Guardar()
        {
            if (conexion.IUD(string.Format("INSERT INTO productogeneral (NombreProducto,Marca,PrecioUnitario,Cantidad,Descripcion,idProveedor) " +
                                           "VALUES ('{0}','{1}', '{2}', '{3}', '{4}',{5})",
                                           NombreProducto, Marca, PrecioUnitario, Cantidad, Descripcion, idProveedor)))
            {
                return true;
            }
            else
            {
                error = conexion.Error;
                return false;
            }
        }

        public List<claseProductoGeneral> MostrarProductoGeneral()
        {
            List<claseProductoGeneral> productoGeneral = new List<claseProductoGeneral>();
            try
            {


                return productoGeneral;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public claseProductoGeneral BuscarID(string id)
        {
            claseProductoGeneral productoGeneral = new claseProductoGeneral();
            //NombreProducto,Marca,PrecioUnitario,Cantidad,Descripcion
            DataTable t1 = conexion.consulta(string.Format("SELECT * FROM makeupbar.productogeneral where idCodigoDeBarra={0}", id));
            if (t1.Rows.Count > 0)
            {
                productoGeneral.idCodigoDeBarra = Convert.ToInt32(t1.Rows[0][0].ToString());
                productoGeneral.NombreProducto = t1.Rows[0][1].ToString();
                productoGeneral.Marca = t1.Rows[0][2].ToString();
                productoGeneral.PrecioUnitario = t1.Rows[0][3].ToString();
                productoGeneral.Cantidad = t1.Rows[0][4].ToString();
                productoGeneral.Descripcion = t1.Rows[0][5].ToString();
                productoGeneral.idProveedor = Convert.ToInt32(t1.Rows[0][6].ToString());

            }
            return productoGeneral;
        }

        public void Modificar(claseProductoGeneral productoGeneral)
        {
            int id;
            id = productoGeneral.idCodigoDeBarra;
            if (conexion.IUD(string.Format("UPDATE productogeneral SET NombreProducto='{0}'" +
                                                             ", Marca='{1}'" +
                                                             ", PrecioUnitario='{2}'" +
                                                             ", Cantidad='{3}'" +
                                                             ", Descripcion='{4}'" +
                                                             ", idProveedor={5}  " +
                                                             "WHERE idCodigoDeBarra={6}", productoGeneral.NombreProducto, productoGeneral.Marca,
                                                                                          productoGeneral.PrecioUnitario, productoGeneral.Cantidad,
                                                                                          productoGeneral.Descripcion, productoGeneral.idProveedor,
                                                                                          productoGeneral.idCodigoDeBarra)))
            {
                MessageBox.Show("Se actulizaron los datos de: " + Convert.ToString(id));
            }

        }

        public Boolean Eliminar()
        {
            if (conexion.IUD(string.Format("DELETE FROM envio WHERE idCodigoDeBarra='{0}'", idCodigoDeBarra)))
            {
                return true;
            }
            else
            {
                error = conexion.Error;
                return false;
            }
        }
        public int IdCodigoDeBarra
        {
            get
            {
                return idCodigoDeBarra;
            }
            set
            {
                idCodigoDeBarra = value;
            }
        }
        public string nombreProducto
        {
            get
            {
                return NombreProducto;
            }
            set
            {
                NombreProducto = value;
            }
        }
        public string marca
        {
            get
            {
                return Marca;
            }
            set
            {
                Marca = value;
            }
        }
        public string precioUnitario
        {
            get
            {
                return PrecioUnitario;
            }
            set
            {
                PrecioUnitario = value;
            }
        }
        public string cantidad
        {
            get
            {
                return Cantidad;
            }
            set
            {
                Cantidad = value;
            }
        }
        public string descripcion
        {
            get
            {
                return Descripcion;
            }
            set
            {
                Descripcion = value;
            }
        }

        public int proveedor
        {
            get
            {
                return idProveedor;
            }
            set
            {
                idProveedor = value;
            }
        }
        public MySqlException Error
        {
            get { return error; }
        }

    }
}
