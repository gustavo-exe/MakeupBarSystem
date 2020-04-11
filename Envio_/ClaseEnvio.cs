using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        public ClaseEnvio BuscarID(string id)
        {
            ClaseEnvio envio = new ClaseEnvio();
            //idEnvio, ,idCliente, Direccion, Telefono, idServicioEntrega
            DataTable t1 = conexion.consulta(string.Format("SELECT * FROM makeupbar.envio where idEnvio='{0}'", id));
            if (t1.Rows.Count > 0)
            {
                idEnvio = t1.Rows[0][0].ToString();
                idCliente = t1.Rows[0][1].ToString();
                Direccion = t1.Rows[0][2].ToString();
                Telefono = t1.Rows[0][3].ToString();
                idServicioEntrega = t1.Rows[0][4].ToString();
            }
            return envio;

        }
        public void Modificar(ClaseEnvio envio)
        {
            string id;
            id = envio.idEnvio;

            if (conexion.IUD(string.Format("UPDATE envio SET Direccion='{0}'" +
                                                           ", Telefono='{1}'" +
                                                           ",idCliente='{2}'" +
                                                           ",idServicioEntrega='{3}'  " +
                                                           "WHERE idEnvio='{4}'",
                                                           envio.Direccion ,envio.Telefono,envio.idCliente,envio.idServicioEntrega, envio.idEnvio)))
            {
                MessageBox.Show("Se actulizaron los datos de: " + Convert.ToString(id));
            }

        }
        public void Eliminar(ClaseEnvio envio)
        {
            string id;
            id = envio.IdEnvio;
            if (conexion.IUD(string.Format("DELETE FROM envio WHERE idEnvio='{0}'", idEnvio)))
            {
                MessageBox.Show("Se elimino el envio: " + Convert.ToString(id));
            }
           
        }
        public string IdEnvio
        {
            get
            {
                return idEnvio;
            }
            set
            {
                idEnvio = value;
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
