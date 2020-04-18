using System;
using System.Collections.Generic;
using System.Text;

namespace DL.SCH_VENTAS
{
    public class Mascotas
    {
		private int _idMascota;
		private string _nombre;
		private int _idRaza;
		private int _idCliente;
		private int _estado;

		public int IdMascota { get => _idMascota; set => _idMascota = value; }
		public string Nombre { get => _nombre; set => _nombre = value; }
		public int IdRaza { get => _idRaza; set => _idRaza = value; }
		public int IdCliente { get => _idCliente; set => _idCliente = value; }
		public int Estado { get => _estado; set => _estado = value; }
	}
	/*
     [IdMascota] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[IdRaza] [int] NULL,
	[IdCliente] [int] NULL,
	[IdEstado] [int] NULL,
     */
}
