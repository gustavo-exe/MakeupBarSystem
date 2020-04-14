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

        public claseProveedor BucarID(string id)
        {
            claseProveedor proveedor = new claseProveedor();


            DataTable Tabla = conexion.consulta(string.Format("SELECT nombreEmpresa, nombreDelContrato, telefonoContacto, correo, descripcion FROM proveedor WHERE idEmpleado='{0}';", id));

            if (Tabla.Rows.Count > 0)
            {

                proveedor.nombreEmpresaProveedor = Tabla.Rows[0][1].ToString();
                proveedor.nombreContacto = Tabla.Rows[0][2].ToString();
                proveedor.correoProveedor = Tabla.Rows[0][3].ToString();
                proveedor.telefonoProveedor = Tabla.Rows[0][4].ToString();
                proveedor.descripcionProveedor = Tabla.Rows[0][5].ToString();

            }
            return proveedor;

        }


        public claseProveedor BuscarProveedor(string nameProveedor)
        {
            claseProveedor claseProveedor = new claseProveedor();
            DataTable Tabla = conexion.consulta(string.Format("SELECT * FROM proveedor WHERE nombreDelContrato='{0}';", nameProveedor));
            if (Tabla.Rows.Count > 0)
            {

                //claseProveedor.idProveedor = Tabla.Rows[0][0];
                claseProveedor.nombreEmpresaProveedor = Tabla.Rows[0][1].ToString();
                claseProveedor.nombreContacto = Tabla.Rows[0][2].ToString();
                claseProveedor.telefonoProveedor = Tabla.Rows[0][3].ToString();
                claseProveedor.correoProveedor = Tabla.Rows[0][4].ToString();
                claseProveedor.descripcionProveedor = Tabla.Rows[0][5].ToString();

            }
            return claseProveedor;
        }

        /*public void Modificar(claseProveedor proveedor)
        {
            string id;

            id = proveedor.nombreEmpresaProveedor;
            if (conexion.IUD(string.Format("UPDATE proveedor " +
                                            "SET " +
                                            "nombre Empresa='{0}', " +
                                            "nombre Contacto='{1}', " +
                                            "telefono Proveedor='{2}' " +
                                            "correo Proveedor='{3}' " +
                                            "descripcion Proveedor='{4}' " +
                                            "WHERE IdProveedor='{5}';",
                                            proveedor.NombreEmpresaProveedor, proveedor.nombreContacto, proveedor.TelefonoProveedor, proveedor.corr, proveedor.descripcionProveedor, proveedor.IdProveedor)))
            {
                MessageBox.Show("Se actulizaron los datos de: " + (id));
            }
        }*/

        public MySqlException Error
        {
            get { return error; }
        }

        
    }
}
