using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if (conexion.IUD(string.Format("INSERT INTO proveedor ( nombreEmpresa, nombreDelContrato, telefonoContacto, correo, descripcion) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');", nombreEmpresaProveedor, nombreContacto, correoProveedor, telefonoProveedor, descripcionProveedor)))
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
            { idProveedor= value; }
           

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

        public claseProveedor BucarID(int id)
        {
            claseProveedor proveedor = new claseProveedor();

            

            DataTable Tabla = conexion.consulta(string.Format("SELECT nombreEmpresa, nombreDelContrato, telefonoContacto, correo, descripcion FROM proveedor WHERE IdProveedor = {0};",id));

            if (Tabla.Rows.Count > 0)
            {
                

                proveedor.nombreEmpresaProveedor = Tabla.Rows[0][0].ToString();
                proveedor.nombreContacto = Tabla.Rows[0][1].ToString();
                proveedor.correoProveedor = Tabla.Rows[0][2].ToString();
                proveedor.telefonoProveedor = Tabla.Rows[0][3].ToString();
                proveedor.descripcionProveedor = Tabla.Rows[0][4].ToString();

            }
            return proveedor;

        }


       
        public void Modificar(claseProveedor proveedor)
        {
            int id;

            id = proveedor.idProveedor;

            //
            if (conexion.IUD(string.Format("UPDATE proveedor " +
                                            "SET " +
                                            "nombreEmpresa='{0}', " +
                                            "nombreDelContrato='{1}', " +
                                            "telefonoContacto='{2}'," +
                                            "correo='{3}', " +
                                            "descripcion ='{4}' " +
                                            "WHERE IdProveedor={5};",
                                            proveedor.NombreEmpresaProveedor, proveedor.nombreContacto, proveedor.TelefonoProveedor, proveedor.correoProveedor, proveedor.descripcionProveedor, proveedor.IdProveedor)))
            {
                MessageBox.Show("Se actulizaron los datos de: " + (id));
            }
        }


        public void Eliminar(claseProveedor proveedor)
        {
            int id;

            id = proveedor.idProveedor;
            if (conexion.IUD(string.Format("DELETE FROM proveedor WHERE IdProveedor={0};", proveedor.idProveedor)))
            {
                MessageBox.Show("Se elimino el proveedor: " + Convert.ToString(id));
            }
        }


        public MySqlException Error
        {
            get { return error; }
        }
        
    }
}
