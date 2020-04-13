using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace MakeupBarSystem.Producto_General
{
    class claseProductoGeneral
    {
        private Conexion conexion;
        private string idCodigoDeBarra;
        private string NombreProducto;
        private string Marca;
        private string PrecioUnitario;
        private string Cantidad;
        private string Descripcion;
        private int idProveedor;
        private MySqlException error;

        public claseProductoGeneral()
        {
            idCodigoDeBarra = "";
            NombreProducto = "";
            Marca = "";
            PrecioUnitario = "";
            Cantidad = "";
            Descripcion = "";
            idProveedor = 0;
            conexion = new Conexion();
        }
        public claseProductoGeneral(string c,string n,string m,string p,string ca,string d,int pr)
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
                                           NombreProducto, Marca,PrecioUnitario, Cantidad,Descripcion,idProveedor)))
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

        public Boolean BuscarID(string id)
        {
            //NombreProducto,Marca,PrecioUnitario,Cantidad,Descripcion
            DataTable t1 = conexion.consulta(string.Format("SELECT * FROM makeupbar.productogeneral where idCodigoDeBarra='{0}'", id));
            if (t1.Rows.Count > 0)
            {
                idCodigoDeBarra = t1.Rows[0][0].ToString();
                NombreProducto = t1.Rows[0][1].ToString();
                Marca = t1.Rows[0][2].ToString();
                PrecioUnitario = t1.Rows[0][3].ToString();
                Cantidad = t1.Rows[0][4].ToString();
                Descripcion = t1.Rows[0][5].ToString();
                idProveedor = Convert.ToInt32(t1.Rows[0][6].ToString());
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean Modificar()
        {
            if (conexion.IUD(string.Format("UPDATE envio SET NombreProducto='{0}'" +
                                                             ", Marca='{1}'" +
                                                             ", PrecioUnitario='{2}'" +
                                                             ", Cantidad='{3}'" +
                                                             ", Descripcion='{4}'" +
                                                             ", idProveedor='{5}'  WHERE idCodigoDeBarra='{6}'", NombreProducto, Marca,
                                                                                                                PrecioUnitario,Cantidad, 
                                                                                                                Descripcion, idProveedor
                                                                                                                ,idCodigoDeBarra)))
            {
                return true;
            }
            else
            {
                error = conexion.Error;
                return false;
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
        public string IdCodigoDeBarra
        {
            get
            {
                return idCodigoDeBarra;
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
