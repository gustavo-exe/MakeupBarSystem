using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeupBarSystem.Proveedor
{
    class claseProveedor
    {
        private Conexion conexion;
        private string idProveedor;
        private string nombreEmpresaProveedor;
        private string nombreContacto;
        private string correoProveedor;
        private string telefonoProveedor;
        private string descripcionProveedor;
        private MySqlException error;


        public claseProveedor()
        {
            idProveedor = "";
            nombreEmpresaProveedor = "";
            nombreContacto = "";
            correoProveedor = "";
            telefonoProveedor = "";
            descripcionProveedor = "";
            conexion = new Conexion();
        }

        public claseProveedor(string ip, string np, string nc, string cp, string tp, string d)
        {
            idProveedor = "ip";
            nombreEmpresaProveedor = "np";
            nombreContacto = "nc";
            correoProveedor = "cp";
            telefonoProveedor = "tp";
            descripcionProveedor = "d";
        }

        public string IdProveedor
        {
            get
            {
                return idProveedor;
            }

        }

        public string NombreEmpresaProveedor
        {
            get
            {
                return nombreEmpresaProveedor;
            }
            set
            {
                nombreEmpresaProveedor = value;
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

        public string CorreoProveedor
        {
            get
            {
                return correoProveedor;
            }
            set
            {
                correoProveedor = value;
            }
        }

        public string TelefonoProveedor
        {
            get
            {
                return telefonoProveedor;
            }
            set
            {
                telefonoProveedor = value;
            }
        }

        public string DescripcionProveedor
        {
            get
            {
                return descripcionProveedor;
            }
            set
            {
                descripcionProveedor = value;
            }
        }

        public MySqlException Error
        {
            get { return error; }
        }

        public Boolean Insertar()
        {
            if (conexion.IUD(string.Format("INSERT INTO proveedor (IdProveedor, NombreEmpresaProveedor, NombreContacto, CorreoProveedor, TelefonoProveedor, DescripcionProveedor) VALUES ('{0}','{1}', '{2}', '{3}', '{4}', '{5}')", idProveedor, nombreEmpresaProveedor, nombreContacto, correoProveedor, telefonoProveedor, descripcionProveedor)))
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
