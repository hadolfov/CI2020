using System;
using System.Collections.Generic;
using System.Text;

namespace DL.SCH_MANTENIMIENTO
{
    public class Caja
    {
		private int _idcaja;
		private string desCaja;
		private int _idSucursal;
		private int _estado;

		public int Idcaja { get => _idcaja; set => _idcaja = value; }
		public string DesCaja { get => desCaja; set => desCaja = value; }
		public int IdSucursal { get => _idSucursal; set => _idSucursal = value; }
		public int Estado { get => _estado; set => _estado = value; }
	}
	/*
     [IdCaja] [int] IDENTITY(1,1) NOT NULL,
	[desCaja] [nvarchar](100) NULL,
	[IdSucursal] [int] NULL,
	[IdUsuarioSeguridad] [int] NULL,
	[UsuarioCreacion] [int] NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioModificacion] [int] NULL,
	[FechaModificacion] [datetime] NULL,
	[IdEstado] [int] NULL,
     */
}
