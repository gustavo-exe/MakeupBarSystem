using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeupBarSystem.Cliente
{
    public class claseListaCliente
    {
        private List<claseCliente> clientes;
        private Conexion conexion;
        private DataTable tabla;
        
        public claseListaCliente()
        {
            clientes = new List<claseCliente>();
            conexion = new Conexion();
            tabla = new DataTable();
            Cargar_Datos();
        }
        public void Cargar_Datos()
        {
            conexion.conectar();
            tabla = conexion.consulta(string.Format("SELECT * FROM makeuppruebas.cliente"));
            foreach (DataRow f in tabla.Rows)
            {
                claseCliente c = new claseCliente();
                c.IdCliente = f.Field<string>(0);
                c.NombreCliente = f.Field<string>(1);
                c.CorreoCliente = f.Field<string>(2);
                c.TelefonoCliente = f.Field<string>(3);
                c.PerfilInstagram = f.Field<string>(4);
                c.CumpleaniosCliente = f.Field<DateTime>(5);
                c.CiudadCliente = f.Field<string>(6);
                c.TonoDeBaseCliente = f.Field<string>(7);
                c.TonodePolvoCliente = f.Field<string>(8);
                c.TipodeCutie = f.Field<string>(9);

                clientes.Add(c);
            }
        }
        public List<claseCliente> Clientes
        {
            get
            {
                return clientes;
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
