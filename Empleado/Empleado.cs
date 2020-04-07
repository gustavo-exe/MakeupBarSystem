using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        /// <summary>
        /// 
        /// METODO CON INSERT
        /// 
        /// </summary>

        public Boolean Insertar()
        {
            Boolean r = false;
            r = conexion.IUD(String.Format("INSERT INTO empleado (idEmpleado, Usuario, Contraseña, Rol) VALUE ('{0}','{1}','{2}','{3}');", idEmpleado, usuario, password, rol));
            return r;
        }

        /// <summary>
        /// 
        /// METODO CON SELECT WHERE
        /// 
        /// </summary>

        public Empleado BucarID(string id)
        {
            Empleado empleado = new Empleado();


            DataTable Tabla = conexion.consulta(string.Format("SELECT idEmpleado, Usuario, Contraseña, Rol FROM empleado WHERE idEmpleado='{0}';", id));
            //MessageBox.Show(Convert.ToString(id));
            //empleado.usuario = "HHHH";
            //MessageBox.Show(Convert.ToString(idEmpleado = Tabla.Rows[0][0].ToString()));
            if (Tabla.Rows.Count > 0)
            {
                
                empleado.idEmpleado = Tabla.Rows[0][0].ToString();
                empleado.usuario = Tabla.Rows[0][1].ToString();
                empleado.password = Tabla.Rows[0][2].ToString();
                empleado.rol = Tabla.Rows[0][3].ToString();
                //MessageBox.Show("Si hay");
                
            }
            return empleado;
        
        }

        ///<summary>
        ///L O G I N 
        /// </summary>
        /// 

        public Empleado BucarUsuario(string NameUsuario)
        {
            Empleado empleado = new Empleado();


            DataTable Tabla = conexion.consulta(string.Format("SELECT * FROM empleado WHERE Usuario='{0}';", NameUsuario));
            //MessageBox.Show(Convert.ToString(id));
            //empleado.usuario = "HHHH";
            //MessageBox.Show(Convert.ToString(idEmpleado = Tabla.Rows[0][0].ToString()));
            if (Tabla.Rows.Count > 0)
            {

                empleado.idEmpleado = Tabla.Rows[0][0].ToString();
                empleado.usuario = Tabla.Rows[0][1].ToString();
                empleado.password = Tabla.Rows[0][2].ToString();
                empleado.rol = Tabla.Rows[0][3].ToString();
                //MessageBox.Show("Si hay");

            }
            return empleado;

        }

        /// <summary>
        /// 
        /// METODO CON UPDATE
        /// 
        /// </summary>


        public void Modificar(Empleado empleado)
        {
            string id;

            id = empleado.idEmpleado;
            if (conexion.IUD(string.Format("UPDATE empleado " +
                                            "SET " +
                                            "Usuario='{0}', " +
                                            "Contraseña='{1}', " +
                                            "Rol='{2}' " +
                                            "WHERE idEmpleado='{3}';", 
                                            empleado.Usuario, empleado.Password, empleado.Rol, empleado.IdEmpleado )))
            {
                MessageBox.Show("Se actulizaron los datos de: " + Convert.ToString(id));
            }
        }

        ///<summary>
        ///
        /// METODO CON DELETE
        /// 
        /// </summary>
        public void Eliminar(Empleado empleado)
        {
            string id;

            id = empleado.idEmpleado;
            if (conexion.IUD(string.Format("DELETE FROM empleado WHERE idEmpleado='{0}';", empleado.IdEmpleado)))
            {
                MessageBox.Show("Se elimino el empleado: " + Convert.ToString(id));
            }
        }


    }
}
