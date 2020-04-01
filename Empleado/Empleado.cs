using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeupBarSystem.Empleado
{
    class Empleado
    {
        private string idEmpleado;
        private string usuario;
        private string password;
        private string rol;
        private Conexion conexion;

        public Empleado()
        {
            idEmpleado = "";
            usuario = "";
            password = "";
            rol = "";
            conexion = new Conexion();
        }

        public Empleado(string id, string user, string pass, string puesto)
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

        public Boolean Insertar()
        {
            Boolean r = false;
            r = conexion.IUD(String.Format("INSERT INTO empleado (idEmpleado, Usuario, Contraseña, Rol) VALUE ('{0}','{1}','{2}','{3}');", idEmpleado, usuario, password, rol));
            return r;
        }

    }
}
