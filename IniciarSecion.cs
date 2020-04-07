using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeupBarSystem
{
    class IniciarSecion
    {
        private string idEmpleado;
        private string usuario;
        private string password;
        private string rol;
        private Conexion conexion;

        public IniciarSecion()
        {
            idEmpleado = "";
            usuario = "";
            password = "";
            rol = "";
            conexion = new Conexion();
        }

        public IniciarSecion(string id, string user, string pass, string puesto)
        {
            id = idEmpleado;
            user = usuario;
            pass = password;
            puesto = rol;
            conexion = new Conexion();
        }

        public string IdEmpleado
        {
            get { return idEmpleado; }
            set { idEmpleado = value; }
        }

        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Rol
        {
            get { return rol; }
            set { rol = value; }
        }
   
        ///<summary>
        ///L O G I N 
        /// </summary>
        /// 

        public IniciarSecion BucarUsuario(string NameUsuario)
        {
            IniciarSecion empleado = new IniciarSecion();


            DataTable Tabla = conexion.consulta(string.Format("SELECT * FROM empleado WHERE Usuario='{0}';", NameUsuario));
         
            if (Tabla.Rows.Count > 0)
            {

                empleado.idEmpleado = Tabla.Rows[0][0].ToString();
                empleado.usuario = Tabla.Rows[0][1].ToString();
                empleado.password = Tabla.Rows[0][2].ToString();
                empleado.rol = Tabla.Rows[0][3].ToString();
            

            }
            return empleado;

        }
    }
}
