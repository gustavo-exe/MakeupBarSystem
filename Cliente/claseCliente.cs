using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeupBarSystem.Cliente
{
    class claseCliente
    {
        private Conexion conexion;
        private string idCliente;
        private string nombreCliente;
        private string correoCliente;
        private string telefonoCliente;
        private string perfilInstagram;
        private DateTime cumpleañosCliente;
        private string ciudadCliente;
        private string tonodeBaseCliente;
        private string tonodePolvoCliente;
        private string tipodeCutieCliente;
        private MySqlException error;

        public claseCliente() 
        {
            idCliente = "";
            nombreCliente = "";
            correoCliente = "";
            telefonoCliente = "";
            perfilInstagram = "";
            cumpleañosCliente = DateTime.Today;
            ciudadCliente = "";
            tonodeBaseCliente = "";
            tonodePolvoCliente = "";
            tipodeCutieCliente = "";
            conexion = new Conexion();
        }
        
        public claseCliente(string i, string n, string c, string te, string pf, DateTime cum, string ci, string tb, string tp, string tc)
        {
            idCliente = i;
            nombreCliente = n;
            correoCliente = c;
            telefonoCliente = te;
            perfilInstagram = pf;
            cumpleañosCliente = cum;
            ciudadCliente = ci;
            tonodeBaseCliente = tb;
            tonodePolvoCliente = tp;
            tipodeCutieCliente = tc;
            conexion = new Conexion();
        }

        public Boolean Guardar()
        {
            if (conexion.IUD(string.Format("INSERT INTO cliente (IdCliente, Nombre, Correo, Telefono, PerfilInstagram, Cumpleaños, Ciudad, TonoDeBase, TonoDePolvo, TipoDeCuties) VALUES ('{0}','{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')", idCliente, nombreCliente, correoCliente, telefonoCliente, perfilInstagram, cumpleañosCliente.Date, ciudadCliente, tonodeBaseCliente,tonodePolvoCliente, tipodeCutieCliente)))
            {
                return true;
            }
            else
            {
                error = conexion.Error;
                return false;
            }
        }

        public string IdCliente
        {
            get
            {
                return idCliente;
            }
            set
            {
                idCliente = value;
            }
        }

        public string NombreCliente
        {
            get
            {
                return nombreCliente;
            }
            set
            {
                nombreCliente = value;
            }
        }

        public string CorreoCliente
        {
            get
            {
                return correoCliente;
            }
            set
            {
                correoCliente = value;
            }
        }
        public string TelefonoCliente
        {
            get
            {
                return telefonoCliente;
            }
            set
            {
                telefonoCliente = value;
            }
        }

        
        public string PerfilInstagram
        {
            get
            {
                return perfilInstagram;
            }
            set
            {
                perfilInstagram = value;
            }
        }

        public DateTime CumpleañosCliente
        {
            get
            {
                return cumpleañosCliente;
            }
            set
            {
                cumpleañosCliente = value.Date;
            }
        }

        public string CiudadCliente
        {
            get
            {
                return ciudadCliente;
            }
            set
            {
                ciudadCliente = value;
            }
        }

        public string TonoDeBaseCliente
        {
            get
            {
                return tonodeBaseCliente;
            }
            set
            {
                tonodeBaseCliente = value;
            }
        }

        public string TonodePolvoCliente
        {
            get
            {
                return tonodePolvoCliente;
            }
            set
            {
                tonodePolvoCliente = value;
            }
        }

        public string TipodeCutie
        {
            get
            {
                return tipodeCutieCliente;
            }
            set
            {
                tipodeCutieCliente = value;
            }
        }

        public MySqlException Error
        {
            get { return error; }
        }










    }
}
