using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public MySqlException Error
        {
            get { return error; }
        }
    }
}
