using System;
using System.Collections.Generic;
using System.Text;

namespace DL.SCH_INVENTARIO
{
    public class MovimientoInventario
    {
		private int _idMovimiento;
		private int _idProveedor;
		private int _idCliente;
		private int _idSucursalEntrada;
		private int _idSucursalSalida;
		private int _idUsuarioAutorizaEntrada;
		private int _idUsuarioAutorizaSalida;
		private int _idTipo;
		private int _idMotivo;
		private int _estado;

		public int IdMovimiento { get => _idMovimiento; set => _idMovimiento = value; }
		public int IdProveedor { get => _idProveedor; set => _idProveedor = value; }
		public int IdCliente { get => _idCliente; set => _idCliente = value; }
		public int IdSucursalEntrada { get => _idSucursalEntrada; set => _idSucursalEntrada = value; }
		public int IdSucursalSalida { get => _idSucursalSalida; set => _idSucursalSalida = value; }
		public int IdUsuarioAutorizaEntrada { get => _idUsuarioAutorizaEntrada; set => _idUsuarioAutorizaEntrada = value; }
		public int IdUsuarioAutorizaSalida { get => _idUsuarioAutorizaSalida; set => _idUsuarioAutorizaSalida = value; }
		public int IdTipo { get => _idTipo; set => _idTipo = value; }
		public int IdMotivo { get => _idMotivo; set => _idMotivo = value; }
		public int Estado { get => _estado; set => _estado = value; }
	}
}
