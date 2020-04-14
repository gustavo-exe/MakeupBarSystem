using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MakeupBarSystem.Maquillaje_
{
    class claseMaquillaje
    {

        private Conexion conexion;
        private int idCodigoDeBarra;
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
            idCodigoDeBarra = 0;
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
        public claseMaquillaje(int c, string n, string m, string t, DateTime f, string p, string ca, string d, int pr)
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
                                            NombreDelProducto, Marca, TonoNumero, FechaDeExpiracion.ToString("yyyy-MM-dd"), PrecioUnitario, Cantidad, Descripcion, idProveedor)))
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

        public claseMaquillaje BuscarID(int id)
        {

            claseMaquillaje maquillaje = new claseMaquillaje();
            //NombreDelProducto,Marca, TonoNumero, FechaDeExpiracion, PrecioUnitario, Cantidad, Descripcion
            DataTable t1 = conexion.consulta(string.Format("SELECT * FROM maquillaje where idCodigoDeBarra={0}", id));
            if (t1.Rows.Count > 0)
            {
                maquillaje.idCodigoDeBarra = Convert.ToInt32(t1.Rows[0][0].ToString());
                maquillaje.NombreDelProducto = t1.Rows[0][1].ToString();
                maquillaje.Marca = t1.Rows[0][2].ToString();
                maquillaje.TonoNumero = t1.Rows[0][3].ToString();
                maquillaje.FechaDeExpiracion = Convert.ToDateTime(t1.Rows[0][4].ToString());
                maquillaje.PrecioUnitario = t1.Rows[0][5].ToString();
                maquillaje.Cantidad = t1.Rows[0][6].ToString();
                maquillaje.Descripcion = t1.Rows[0][7].ToString();
                maquillaje.idProveedor = Convert.ToInt32(t1.Rows[0][8].ToString());
            }
            return maquillaje;

        }

        public void Eliminar(claseMaquillaje maquillaje)
        {
            int id;
            id = maquillaje.idCodigoDeBarra;
            if (conexion.IUD(string.Format("DELETE FROM maquillaje WHERE idCodigoDeBarra={0}", idCodigoDeBarra)))
            {
                MessageBox.Show("Se elimino el envio: " + Convert.ToString(id));
            }

        }

        public void Modificar(claseMaquillaje maquillaje)
        {
            int id;
            id = maquillaje.idCodigoDeBarra;

            //MessageBox.Show(Convert.ToString(maquillaje.idCodigoDeBarra));
            if (conexion.IUD(string.Format("UPDATE maquillaje SET NombreDelProducto='{0}'" +
                                                           ",Marca='{1}'" +
                                                           ",TonoNumero='{2}'" +
                                                           
                                                           ",PrecioUnitario='{3}'" +
                                                           ",Cantidad='{4}'" +
                                                           ",Descripcion='{5}'" +
                                                           ",idProveedor={6} " +
                                                           "WHERE idCodigoDeBarra={7}",
                                                           maquillaje.NombreDelProducto, maquillaje.Marca, maquillaje.TonoNumero, maquillaje.PrecioUnitario, maquillaje.Cantidad,
                                                           maquillaje.Descripcion, maquillaje.idProveedor,
                                                           maquillaje.idCodigoDeBarra
                                                           )))
            {
                MessageBox.Show("Se actulizaron los datos de: " + Convert.ToString(id));
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
