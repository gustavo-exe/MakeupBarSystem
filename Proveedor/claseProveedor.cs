using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeupBarSystem.Proveedor
{
    class claseProveedor
    {
        private Conexion conexion;
        private int idProveedor;
        private string nombreEmpresaProveedor;
        private string nombreContacto;
        private string correoProveedor;
        private string telefonoProveedor;
        private string descripcionProveedor;
        private MySqlException error;


        public claseProveedor()
        {
            idProveedor = 0;
            nombreEmpresaProveedor = "";
            nombreContacto = "";
            correoProveedor = "";
            telefonoProveedor = "";
            descripcionProveedor = "";
            conexion = new Conexion();
        }

        public claseProveedor(int ip, string np, string nc, string cp, string tp, string d)
        {
            idProveedor = ip;
            nombreEmpresaProveedor = np;
            nombreContacto = nc;
            correoProveedor = cp;
            telefonoProveedor = tp;
            descripcionProveedor = d;
        }

        public Boolean Insertar()
        {
            if (conexion.IUD(string.Format("INSERT INTO proveedor (IdProveedor, nombreEmpresa, nombreDelContrato, telefonoContacto, correo, descripcion) VALUES ('{0}','{1}', '{2}', '{3}', '{4}', '{5}')", idProveedor, nombreEmpresaProveedor, nombreContacto, correoProveedor, telefonoProveedor, descripcionProveedor)))
            {
                return true;
            }
            else
            {
                error = conexion.Error;
                return false;
            }
        }

        public int IdProveedor
        {
            get
            {
                return idProveedor;
            }
            set
            {
                idProveedor = value;
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

        
    }
}
