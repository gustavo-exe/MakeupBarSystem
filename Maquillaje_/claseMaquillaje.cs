using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MakeupBarSystem.Maquillaje_
{
    class claseMaquillaje
    {
        private Conexion conexion;
        private string idCodigoDeBarra;
        private string NombreDelProducto;
        private string Marca;
        private string TonoNumero;
        private DateTime FechaDeExpiracion;
        private string PrecioUnitario;
        private string Cantidad;
        private string Descripcion;
        private int idProveedor;
        private MySqlException error;

        public claseMaquillaje()
        {
            idCodigoDeBarra = "";
            NombreDelProducto = "";
            Marca = "";
            TonoNumero = "";
            FechaDeExpiracion = DateTime.Now;
            PrecioUnitario = "";
            Cantidad = "";
            Descripcion = "";
            idProveedor = 0;
            conexion = new Conexion();
        }
        public claseMaquillaje(string c,string n,string m,string t,DateTime f,string p,string ca,string d,int pr)
        {
            idCodigoDeBarra = c;
            NombreDelProducto = n;
            Marca = m;
            TonoNumero = t;
            FechaDeExpiracion = f;
            PrecioUnitario = p;
            Cantidad = ca;
            Descripcion = d;
            idProveedor = pr;
            conexion = new Conexion();
        }

        public Boolean Guardar()
        {
            if (conexion.IUD(string.Format("INSERT INTO maquillaje (NombreDelProducto,Marca, TonoNumero, FechaDeExpiracion, PrecioUnitario, Cantidad, Descripcion, idProveedor) " +
                                            "VALUES ('{0}','{1}', '{2}', '{3}', '{4}', '{5}','{6}', {7})",
                                            NombreDelProducto, Marca,  TonoNumero, FechaDeExpiracion.ToString("yyyy-MM-dd"),PrecioUnitario,Cantidad,Descripcion,idProveedor)))
            {
                return true;
            }
            else
            {
                error = conexion.Error;
                return false;
            }
        }
        public List<claseMaquillaje> MostrarMaquillaje()
        {
            List<claseMaquillaje> maquillaje = new List<claseMaquillaje>();
            try
            {
                return maquillaje;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Boolean BuscarID(string id)
        {
            //NombreDelProducto,Marca, TonoNumero, FechaDeExpiracion, PrecioUnitario, Cantidad, Descripcion
            DataTable t1 = conexion.consulta(string.Format("SELECT * FROM makeuppruebas.maquillaje where IdCodigoDeBarra='{0}'", id));
            if (t1.Rows.Count > 0)
            {
                idCodigoDeBarra = t1.Rows[0][0].ToString();
                NombreDelProducto = t1.Rows[0][1].ToString();
                Marca = t1.Rows[0][2].ToString();
                TonoNumero = t1.Rows[0][3].ToString();
                FechaDeExpiracion = Convert.ToDateTime(t1.Rows[0][5].ToString());
                PrecioUnitario = t1.Rows[0][6].ToString();
                Cantidad = t1.Rows[0][7].ToString();
                Descripcion = t1.Rows[0][8].ToString();
                idProveedor= Convert.ToInt32(t1.Rows[0][9].ToString());

                return true;
            }
            else
            {
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
        public string nombreDelProducto
        {
            get
            {
                return NombreDelProducto;
            }
            set
            {
                NombreDelProducto = value;
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
        public string tonoNumero
        {
            get
            {
                return TonoNumero;
            }
            set
            {
                TonoNumero = value;
            }
        }
        public DateTime fechaDeExpiracion
        {
            get
            {
                return FechaDeExpiracion;
            }
            set
            {
                FechaDeExpiracion = value.Date;
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
