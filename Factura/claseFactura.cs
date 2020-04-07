using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace MakeupBarSystem.Factura
{
    class claseFactura
    {

        private Conexion conexion;
        private int idfactura;
        private int idcliente;
        private int idempleado;
        private DateTime fecha;


        public claseFactura()
        {
            idfactura = 0;
            idcliente = 0;
            idempleado = 0;
            fecha = DateTime.Today;
            conexion = new Conexion();
        }

        public int IdFactura
        {
            get
            {
                return idfactura;
            }
        }
        public int IdCliente
        {
            get
            {
                return idcliente;
            }
            set
            {
                idcliente = value;
            }
        }

        public int IdEmpleado
        {
            get
            {
                return idempleado;
            }
            set
            {
                idempleado = value;
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
        /*
        public claseFactura BucarID(string id)
        {
            claseFactura vistafactura = new claseFactura();


            DataTable Tabla = conexion.consulta(string.Format("SELECT IdFactura,FechaActual,IdEmpleado,idCliente FROM factura WHERE IdFactura='{0}';", id));
            //MessageBox.Show(Convert.ToString(id));
            //empleado.usuario = "HHHH";
            //MessageBox.Show(Convert.ToString(idEmpleado = Tabla.Rows[0][0].ToString()));
            if (Tabla.Rows.Count > 0)
            {

                vistafactura.idFactura = Convert.ToInt32(Tabla.Rows[0][0]);
                vistafactura.fecha = Tabla.Rows[0][1].ToString();
                vistafactura.idCliente = Tabla.Rows[0][2].ToString();
                vistafactura.idempleado = Tabla.Rows[0][3].ToString();
                //MessageBox.Show("Si hay");

            }
            return empleado;
        }
        */
    }
}
