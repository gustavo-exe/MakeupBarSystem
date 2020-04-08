using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeupBarSystem.Cliente
{
    public class claseListaInstagram
    {
        private List<claseInstagram> usuarios;
        private Conexion conexion;
        private DataTable tabla;
        private MySqlException error;
        public claseListaInstagram()
        {
            usuarios = new List<claseInstagram>();
            conexion = new Conexion();
            tabla = new DataTable();
            Cargar_Datos();
        }
        public void Cargar_Datos()
        {
            conexion.conectar();
            tabla = conexion.consulta(string.Format("SELECT * FROM makeuppruebas.instagram"));
            foreach (DataRow f in tabla.Rows)
            {
                claseInstagram i = new claseInstagram();
                i.IdCliente = f.Field<string>(1);
                i.Usuario = f.Field<string>(2);
                i.Url = f.Field<string>(3);
                usuarios.Add(i);
            }
        }
        public List<claseInstagram> ListaUsuarios
        {
            get
            {
                return ListaUsuarios;
            }
        }
        public DataTable Tabla
        {
            get { return tabla; }
        }
        public DataTable SQL(string sql)
        {
            DataTable t = conexion.consulta(sql);
            return t;
        }
    }
}
