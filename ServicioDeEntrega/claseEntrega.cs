using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeupBarSystem.ServicioDeEntrega
{
    class claseEntrega
    {
        private Conexion conexion;
        private int idServicioEntrega;
        private string nombreEmpresa;
        private string nombreContacto;
        private string telefono;
        private string correo;
        private MySqlException error;

        public claseEntrega()
        {
            idServicioEntrega = 0;
            nombreEmpresa = "";
            nombreContacto = "";
            telefono = "";
            correo = "";
            conexion = new Conexion();
        }

        public claseEntrega(int se, string ne, string nc, string t, string c)
        {
            idServicioEntrega = se;
            nombreEmpresa = ne;
            nombreContacto = nc;
            telefono = t;
            correo = c;
        }

        public Boolean Insertar()
        {
            if (conexion.IUD(string.Format("INSERT INTO serviciodeentrega (IdServicioEntrega, nombreEmpresa, nombreContrato, telefono, correo) VALUES ('{0}','{1}', '{2}', '{3}', '{4}')", idServicioEntrega, nombreEmpresa, nombreContacto, telefono, correo)))
            {
                return true;
            }
            else
            {
                error = conexion.Error;
                return false;
            }
        }

        public int IdServicioEntrega
        {
            get
            {
                return idServicioEntrega;
            }
            set
            { idServicioEntrega = value; }


        }

        public string NombreEmpresa
        {
            get
            {
                return nombreEmpresa;
            }
            set
            {
                nombreEmpresa = value;
            }
        }

        public string NombreContacto
        {
            get
            {
                return nombreContacto;
            }
            set
            {
                nombreContacto = value;
            }
        }

        public string Telefono
        {
            get
            {
                return telefono;
            }
            set
            {
                telefono = value;
            }
        }

        public string Correo
        {
            get
            {
                return correo;
            }
            set
            {
                correo = value;
            }
        }

        public claseEntrega BuscaID(int id)
        {
            claseEntrega entrega = new claseEntrega();

            DataTable Tabla = conexion.consulta(string.Format("SELECT nombreEmpresa, nombreContrato, telefono, correo FROM serviciodeentrega WHERE IdServicioEntrega = {0};", id));

            if (Tabla.Rows.Count > 0)
            {
                entrega.nombreEmpresa = Tabla.Rows[0][0].ToString();
                entrega.nombreContacto = Tabla.Rows[0][1].ToString();
                entrega.telefono = Tabla.Rows[0][2].ToString();
                entrega.correo = Tabla.Rows[0][3].ToString();
            }
            return entrega;

        }



        public void Modificar(claseEntrega entrega)
        {
            int id;
            id = entrega.idServicioEntrega;
            if (conexion.IUD(string.Format("UPDATE serviciodeentrega" +
                                          "SET " +
                                          "nombreEmpresa='{0}', " +
                                          "nombreDelContrato='{1}', " +
                                          "telefono='{2}'," +
                                          "correo='{3}' " +
                                          "WHERE IdServicioEntrega = {4};",
                                           entrega.NombreEmpresa, entrega.nombreContacto, entrega.Telefono, entrega.correo, entrega.IdServicioEntrega)))
            {
                MessageBox.Show("Se actulizaron los datos de: " + (id));
            }
        }


        public void Eliminar(claseEntrega entrega)
        {
            int id;

            id = entrega.idServicioEntrega;
            if (conexion.IUD(string.Format("DELETE FROM serviciodeentrega WHERE IdServicioEntrega={0};", entrega.idServicioEntrega)))
            {
                MessageBox.Show("Se elimino el servicio: " + Convert.ToString(id));
            }
        }


        public MySqlException Error
        {
            get { return error; }
        }
    }
}
