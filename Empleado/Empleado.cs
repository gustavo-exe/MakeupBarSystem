using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeupBarSystem.Empleado
{
    class Empleado
    {
        private int idEmpleado;
        private string usuario;
        private string password;
        private string rol;

        public Empleado()
        {
            idEmpleado = 0;
            usuario = "";
            password = "";
            rol = "";
        }

        public Empleado(int id, string user, string pass, string puesto)
        {
            id = idEmpleado;
            user = usuario;
            pass = password;
            puesto = rol;
        }

        public int IdEmpleado
        {
            get { return idEmpleado; }
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



    }
}
