using System;
using System.Collections.Generic;
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
        private int PrecioUnitario;
        private int Cantidad;
        private string Descripcion;
        private MySqlException error;

        public claseProductoGeneral()
        {
            idCodigoDeBarra = "";
            NombreProducto = "";
            Marca = "";
            PrecioUnitario = 0;
            Cantidad = 0;
            Descripcion = "";
            conexion = new Conexion();
        }
        public claseProductoGeneral(string c,string n,string m,int p,int ca,string d)
        {
            idCodigoDeBarra = c;
            NombreProducto = n;
            Marca = m;
            PrecioUnitario = p;
            Cantidad = ca;
            Descripcion = d;
            conexion = new Conexion();
        }

        public Boolean Guardar()
        {
            if (conexion.IUD(string.Format("INSERT INTO ProductoGeneral (idCodigoDeBarra,NombreProducto,Marca,PrecioUnitario,Cantidad,Descripcion) " +
                "                           VALUES ('{0}','{1}', '{2}', '{3}', '{4}','5')",
                                            idCodigoDeBarra, NombreProducto, Marca,PrecioUnitario, Cantidad,Descripcion)))
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
