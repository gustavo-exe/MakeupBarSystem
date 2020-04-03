using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
