using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeupBarSystem.Venta
{
    class claseVenta
    {
        private Conexion conexion;
        private int idVenta;
        private int idFactura;
        private int idCliente;
        private int idEmpleado;
        private DateTime fecha;
        private int idProducto;
        private float precio;
        private int cantidades;
        private int descuento;
        private MySqlException error;
        private int VentaId;

        public claseVenta()
        {
            idCliente = 0;
            idEmpleado = 0;
            fecha = DateTime.Today;
            idProducto = 0;
            precio = 0;
            cantidades = 0;
            descuento = 0;
            conexion = new Conexion();
        }
        public claseVenta(int a, int b, int c, float d, int e, int f)
        {
            idCliente = a;
            idEmpleado = b;
            fecha = DateTime.Today;
            idProducto = c;
            precio = d;
            cantidades = e;
            descuento = f;
            conexion = new Conexion();
        }
        public int IdVenta
        {
            get
            {
                return idVenta;
            }
            set
            {
                idVenta = value;
            }
        }
        public int IdFactura
        {
            get
            {
                return idFactura;
            }
            set
            {
                idFactura = value;
            }
        }
        public int IdCliente
        {
            get
            {
                return idCliente;
            }
            set
            {
                idCliente = value;
            }
        }

        public int IdEmpleado
        {
            get
            {
                return idEmpleado;
            }
            set
            {
                idEmpleado = value;
            }
        }


        public DateTime Fecha
        {
            get
            {
                return fecha;
            }
            set
            {
                fecha = value;
            }
        }
        public int IdProducto
        {
            get
            {
                return idProducto;
            }
            set
            {
                idProducto = value;
            }
        }
        public float Precio
        {
            get
            {
                return precio;
            }
            set
            {
                precio = value;
            }
        }
        public int Cantidades
        {
            get
            {
                return cantidades;
            }
            set
            {
                cantidades = value;
            }
        }
        public int Descuento
        {
            get
            {
                return descuento;
            }
            set
            {
                descuento = value;
            }
        }

        public MySqlException Error
        {
            get { return error; }
        }

        public Boolean Insertar()
        {
           
            /*Inserta datos en la tabla de detalle de venta */
            if (conexion.IUD(string.Format("insert into DetalleDeVenta(idVenta,idFactura,idProducto,precio,Cantidad,Descuento) value('{0}','{1}','{2}','{3}','{4}','{5}')", idCliente, idEmpleado, idVenta, idFactura, idProducto, precio, cantidades, descuento)))
            {
                return true;
            }
            else
            {
                error = conexion.Error;
                return false;
            }
        }

        public Boolean Venta()
        {
            /*Inserta datos en la tabla de venta */
            if (conexion.IUD(string.Format("insert into Venta(idCliente,idEmpleado) value('{0}','{1}')", idCliente, idEmpleado)))
            {
                IdVenta = Convert.ToInt32(conexion.consulta(string.Format("SELECT MAX(idVenta) from Venta")).Rows[0][0].ToString());
            }
            else
            {
                error = conexion.Error;
            }

            if (conexion.IUD(string.Format("insert into Factura(IdEmpleado,idCliente) value('{0}','{1}')", idEmpleado,idCliente)))
            {
                IdFactura = Convert.ToInt32(conexion.consulta(string.Format("SELECT MAX(IdFactura) from Factura")).Rows[0][0].ToString());
                return true;
            }
            else
            {
                //error = conexion.Error;
                return false;
            }



            /*Inserta datos en la tabla de factura */


        }
        /*
        public claseVenta BucarID(string id)
        {
            claseVenta claseventa = new claseVenta();


            DataTable Tabla = conexion.consulta(string.Format("SELECT idcliente,idEmpleado,idVenta ,idFactura, Contraseña, Rol FROM empleado WHERE idEmpleado='{0}';", id));
            //MessageBox.Show(Convert.ToString(id));
            //empleado.usuario = "HHHH";
            //MessageBox.Show(Convert.ToString(idEmpleado = Tabla.Rows[0][0].ToString()));
            if (Tabla.Rows.Count > 0)
            {

                claseventa.idCliente = Convert.ToInt32(Tabla.Rows[0][0]);
                claseventa.idEmpleado = Convert.ToInt32(Tabla.Rows[0][1]);
                claseventa.idVenta = Convert.ToInt32(Tabla.Rows[0][2]);
                claseventa.idFactura = Convert.ToInt32(Tabla.Rows[0][3]);
                claseventa.idProducto = Convert.ToInt32(Tabla.Rows[0][0]);
                claseventa.precio = Convert.ToInt32(Tabla.Rows[0][1]);
                claseventa.cantidades = Convert.ToInt32(Tabla.Rows[0][2]);
                claseventa.descuento = Convert.ToInt32(Tabla.Rows[0][3]);
                //MessageBox.Show("Si hay");

            }
            return claseventa;

        }
        */

        public Boolean Eliminar()
        {
            if (conexion.IUD(string.Format("DELETE FROM Venta WHERE idVenta='{0}'", idVenta)))
            {
                return true;
            }
            else
            {
                error = conexion.Error;
            }

            if (conexion.IUD(string.Format("DELETE FROM factura WHERE IdFactura='{0}'", idFactura)))
            {
                return true;
            }
            else
            {
                error = conexion.Error;
                return false;
            }
        }

    }
}

