using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeupBarSystem.Venta
{
    class claseVenta
    {
        private Conexion conexion;
        private int idVenta;
        private int idFactura;
        private string idCliente;
        private string idEmpleado;
        private DateTime fecha;
        private int idProducto;
        private double precio;
        private int cantidades;
        private int descuento;
        private double total;
        private MySqlException error;

        public claseVenta()
        {
            idCliente = "";
            idEmpleado = "";
            fecha = DateTime.Today;
            idProducto = 0;
            precio = 0.0;
            cantidades = 0;
            descuento = 0;
            total = 0.0;
            conexion = new Conexion();
        }
        public claseVenta(string a, string b, int c, double d, int e, int f,double t)
        {
            idCliente = a;
            idEmpleado = b;
            fecha = DateTime.Today;
            idProducto = c;
            precio = d;
            cantidades = e;
            descuento = f;
            total = t;
            conexion = new Conexion();
        }

        public double Total
        {
            get
            {
                return total;
            }
            set
            {
                total = value;
            }
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
        public string IdCliente
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

        public string IdEmpleado
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
        public double Precio
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
            if (conexion.IUD(string.Format("insert into DetalleDeVenta(idVenta,idFactura,idProducto,precio,Cantidad,Descuento ,Total) value('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", idVenta, idFactura, idProducto, precio, cantidades, descuento,total)))
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
        
        public claseVenta BucarID(string id)
        {
            claseVenta claseventa = new claseVenta();


            DataTable Tabla = conexion.consulta(string.Format("SELECT idVenta ,idFactura, idProducto, precio, Cantidad,Descuento,total FROM idDetalleDeVenta WHERE idEmpleado='{0}';", id));
            //MessageBox.Show(Convert.ToString(id));
            //empleado.usuario = "HHHH";
            //MessageBox.Show(Convert.ToString(idEmpleado = Tabla.Rows[0][0].ToString()));
            if (Tabla.Rows.Count > 0)
            {

                claseventa.idVenta = Convert.ToInt32(Tabla.Rows[0][2]);
                claseventa.idFactura = Convert.ToInt32(Tabla.Rows[0][3]);
                claseventa.idProducto = Convert.ToInt32(Tabla.Rows[0][4]);
                claseventa.precio = Convert.ToDouble(Tabla.Rows[0][5]);
                claseventa.cantidades = Convert.ToInt32(Tabla.Rows[0][6]);
                claseventa.descuento = Convert.ToInt32(Tabla.Rows[0][3]);
                claseventa.total = Convert.ToDouble(Tabla.Rows[0][7]);
                //MessageBox.Show("Si hay");

            }
            return claseventa;

        }
        

        public Boolean Eliminar()
        {

            if (conexion.IUD(string.Format("DELETE FROM DetalleDeVenta WHERE idVenta='{0}'", IdVenta)))
            {
                
            }
            else
            {
                error = conexion.Error;
            }


            if (conexion.IUD(string.Format("DELETE FROM Venta WHERE idVenta='{0}'", IdVenta)))
            {

            }
            else
            {
                error = conexion.Error;
            }

            if (conexion.IUD(string.Format("DELETE FROM factura WHERE IdFactura='{0}'", IdFactura)))
            {
               // MessageBox.Show("La venta ha sido cancelada", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
              
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

