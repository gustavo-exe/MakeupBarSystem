﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeupBarSystem.Venta
{
    class claseVenta
    {
        private Conexion conexion;
        private int idVenta;
        private int idFactura;
        private int idCliente;
        private int idEmpleado;
        private DateTime fecha;
        private int idProducto;
        private float precio;
        private int cantidades;
        private int descuento;
        private MySqlException error;

        public claseVenta()
        {
            idCliente = 0;
            idEmpleado = 0;
            fecha = DateTime.Today;
            idProducto = 0;
            precio = 0;
            cantidades = 0;
            descuento = 0;
            conexion = new Conexion();
        }
        public claseVenta(int a, int b, int c, float d, int e, int f)
        {
            idCliente = a;
            idEmpleado = b;
            fecha = DateTime.Today;
            idProducto = c;
            precio = d;
            cantidades = e;
            descuento = f;
            conexion = new Conexion();
        }
        public int IdVenta
        {
            get
            {
                return idVenta;
            }
        }
        public int IdFactura
        {
            get
            {
                return idFactura;
            }
        }
        public int IdCliente
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

        public int IdEmpleado
        {
            get
            {
                return idEmpleado;
            }
            set
            {
                idEmpleado = value;
            }
        }


        public DateTime Fecha
        {
            get
            {
                return fecha;
            }
            set
            {
                fecha = value;
            }
        }
        public int IdProducto
        {
            get
            {
                return idProducto;
            }
            set
            {
                IdProducto = value;
            }
        }
        public float Precio
        {
            get
            {
                return precio;
            }
            set
            {
                precio = value;
            }
        }
        public int Cantidades
        {
            get
            {
                return cantidades;
            }
            set
            {
                cantidades = value;
            }
        }
        public int Descuento
        {
            get
            {
                return descuento;
            }
            set
            {
                descuento = value;
            }
        }

        public void Venta()
        {
            /*Inserta datos en la tabla de venta */
            conexion.IUD(string.Format("insert into Venta(idCliente,idEmpleado,Fecha) value('{0}','{1}','{2}')", idCliente, idEmpleado, fecha));

            /*Inserta datos en la tabla de factura */
            conexion.IUD(string.Format("insert into factura(FechaActual,IdEmpleado,idCliente) value('{0}','{1}','{2}')", fecha, idCliente, idEmpleado));

        }
        public void Insertar()
        {
            /*Inserta datos en la tabla de detalle de venta */
            conexion.IUD(string.Format("insert into DetalleVenta(idVenta,idFactura,idProducto,precio,Cantidad,Descuento) value('{0}','{1}','{2}','{3}','{4}','{5}')", idCliente, idEmpleado, idVenta, idFactura, idProducto, precio, cantidades, descuento));


        }
    }
}