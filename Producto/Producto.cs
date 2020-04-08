using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeupBarSystem.Producto
{
    class Producto
    {

        private int idProducto;
        private int codigoDeBarra;
        private string nombreDelProducto;
        private float precio;
        private int cantidad;
        private Conexion conexion;
        public Producto()
        {
            idProducto = 0;
            codigoDeBarra = 0;
            nombreDelProducto = "";
            precio = 0;
            cantidad = 0;
            conexion = new Conexion();
        }
        public Producto( int id, int barra, string Nombre, float pre, int cant)
        {
            idProducto = id;
            codigoDeBarra = barra;
            nombreDelProducto = Nombre;
            precio = pre;
            cantidad = cant;
            conexion = new Conexion();
        }

        public int IdProducto
        {
            get { return idProducto; }
        }

        public int CodigoDeBarra
        {
            get {return codigoDeBarra;}
            set { codigoDeBarra = value; }
        }

        public string NombreProducto
        {
            get { return nombreDelProducto; }
            set { nombreDelProducto = value; }
        }

        public float Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
    }
}
