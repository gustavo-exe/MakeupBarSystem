using System;
using System.Collections.Generic;
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
        private int PrecioUnitario;
        private int Cantidad;
        private string Descripcion;
        private MySqlException error;

        public claseMaquillaje()
        {
            idCodigoDeBarra = "";
            NombreDelProducto = "";
            Marca = "";
            TonoNumero = "";
            FechaDeExpiracion = DateTime.Now;
            PrecioUnitario = 0;
            Cantidad = 0;
            Descripcion = "";
            conexion = new Conexion();
        }
        public claseMaquillaje(string c,string n,string m,string t,DateTime f,int p,int ca,string d)
        {
            idCodigoDeBarra = c;
            NombreDelProducto = n;
            Marca = m;
            TonoNumero = t;
            FechaDeExpiracion = f;
            PrecioUnitario = p;
            Cantidad = ca;
            Descripcion = d;
            conexion = new Conexion();
        }

        public Boolean Guardar()
        {
            if (conexion.IUD(string.Format("INSERT INTO Maquillaje (idCodigoDeBarra,NombreDelProducto,Marca, TonoNumero, FechaDeExpiracio, PrecioUnitario, Cantidad, Descripcion) " +
                                            "VALUES ('{0}','{1}', '{2}', '{3}', '{4}', '{5}', '{6}','{7}')",
                                            idCodigoDeBarra, NombreDelProducto, Marca,  TonoNumero, FechaDeExpiracion,PrecioUnitario,Cantidad,Descripcion)))
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
                FechaDeExpiracion = value;
            }
        }
        public int precioUnitario
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
        public int cantidad
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
        public MySqlException Error
        {
            get { return error; }
        }
    }
   
}
