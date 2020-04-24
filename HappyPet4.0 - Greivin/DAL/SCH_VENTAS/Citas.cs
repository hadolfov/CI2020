using System;
using System.Collections.Generic;
using System.Text;

namespace DL.SCH_VENTAS
{
    public class Citas
    {
		private int _idCita;
		private int _idMascota;
		private string _observacion;
		private DateTime _ingreso;
		private DateTime _salida;
		private double _peso;
		private double _alto;
		private double _largo;
		private int _estado;

		public int IdCita { get => _idCita; set => _idCita = value; }
		public int IdMascota { get => _idMascota; set => _idMascota = value; }
		public string Observacion { get => _observacion; set => _observacion = value; }
		public DateTime Ingreso { get => _ingreso; set => _ingreso = value; }
		public DateTime Salida { get => _salida; set => _salida = value; }
		public double Peso { get => _peso; set => _peso = value; }
		public double Alto { get => _alto; set => _alto = value; }
		public double Largo { get => _largo; set => _largo = value; }
		public int Estado { get => _estado; set => _estado = value; }
	}
	/*
     [IdCita] [int] IDENTITY(1,1) NOT NULL,
	[IdMascota] [int] NOT NULL,
	[Observacion] [nvarchar](500) NULL,
	[Ingreso] [datetime] NOT NULL,
	[Salida] [datetime] NOT NULL,
	[Peso] [float] NULL,
	[Largo] [float] NULL,
	[Alto] [float] NULL,
	[IdEstado] [int] NOT NULL,*/
}
