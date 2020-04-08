using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MakeupBarSystem.Envio_
{
    class ClaseEnvio
    {
        private Conexion conexion;
        private string idEnvio;
        private string idCliente;
        private string Direccion;
        private string Telefono;
        private string idServicioEntrega;
        private MySqlException error;

        public ClaseEnvio()
        {
            idEnvio = "";
            idCliente = "";
            Direccion = "";
            Telefono = "";
            idServicioEntrega = "";
            conexion = new Conexion();
        }

        public ClaseEnvio(string e, string c, string d, string t, string s)
        {
            idEnvio = e;
            idCliente = c;
            Direccion = d;
            Telefono = t;
            idServicioEntrega = s;
            conexion = new Conexion();
        }
        public Boolean Guardar()
        {
            if (conexion.IUD(string.Format("INSERT INTO envio (idCliente, Direccion, Telefono, idServicioDeEntrega) " +
                                           "VALUES ('{0}','{1}', '{2}', {3})", 
                                            idCliente, Direccion, Telefono, idServicioEntrega)))
            {
                return true;
            }
            else
            {
                error = conexion.Error;
                return false;
            }
        }
        public List<ClaseEnvio> MostrarEnvio()
        {
            List<ClaseEnvio> envio = new List<ClaseEnvio>();
            try
            {
                return envio;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public Boolean LlenarVenta(string idEnvio)
        {
            //idEnvio, ,idCliente, Direccion, Telefono, idServicioEntrega
            DataTable t1 = conexion.consulta(string.Format("SELECT idVenta FROM makeupbar.Venta where idEnvio='{0}'", idEnvio));
            if (t1.Rows.Count > 0)
            {
                idEnvio = t1.Rows[0][0].ToString();

                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean LlenarFactura(string idenvio)
        {
            //idEnvio, ,idCliente, Direccion, Telefono, idServicioEntrega
            DataTable t1 = conexion.consulta(string.Format("SELECT IdFactura FROM makeupbar.factura where idEnvio='{0}'", idenvio));
            if (t1.Rows.Count > 0)
            {
                idEnvio = t1.Rows[0][0].ToString();

                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean BuscarID(string id)
        {
            //idEnvio, ,idCliente, Direccion, Telefono, idServicioEntrega
            DataTable t1 = conexion.consulta(string.Format("SELECT * FROM makeuppruebas.envio where idEnvio='{0}'", id));
            if (t1.Rows.Count > 0)
            {
                idEnvio = t1.Rows[0][0].ToString();
                idCliente = t1.Rows[0][1].ToString();
                Direccion = t1.Rows[0][2].ToString();
                Telefono = t1.Rows[0][3].ToString();
                idServicioEntrega = t1.Rows[0][4].ToString();
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean Modificar()
        {
            if (conexion.IUD(string.Format("UPDATE envio SET Direccion='{0}', Telefono='{1}' WHERE idEnvio='{2}'",Direccion ,Telefono, idEnvio)))
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
            if (conexion.IUD(string.Format("DELETE FROM envio WHERE idEnvio='{0}'", idEnvio)))
            {
                return true;
            }
            else
            {
                error = conexion.Error;
                return false;
            }
        }
        public string IdEnvio
        {
            get
            {
                return idEnvio;
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
        public string direccion
        {
            get
            {
                return Direccion;
            }
            set
            {
                Direccion = value;
            }
        }
        public string telefono
        {
            get
            {
                return Telefono;
            }
            set
            {
                Telefono = value;
            }
        }
        public string IdServicioEntrega
        {
            get
            {
                return idServicioEntrega;
            }
            set
            {
                idServicioEntrega = value;
            }
        }
        public MySqlException Error
        {
            get { return error; }
        }
    }
}
