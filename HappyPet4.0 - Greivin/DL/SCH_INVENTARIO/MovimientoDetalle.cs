using System;
using System.Collections.Generic;
using System.Text;

namespace DL.SCH_INVENTARIO
{
    public class MovimientoDetalle
    {
		private int _idDetalle;
		private int _idMovimiento;
		private int _idArticulo;
		private string _pedido;
		private int _cantidad;
		private double _montoTotal;
		private int _porcentajeImpuesto;
		private int _porcentajeDescuento;
		private int _cantidadBackOrder;
		private int _estado;

		public int IdDetalle { get => _idDetalle; set => _idDetalle = value; }
		public int IdMovimiento { get => _idMovimiento; set => _idMovimiento = value; }
		public int IdArticulo { get => _idArticulo; set => _idArticulo = value; }
		public string Pedido { get => _pedido; set => _pedido = value; }
		public int Cantidad { get => _cantidad; set => _cantidad = value; }
		public double MontoTotal { get => _montoTotal; set => _montoTotal = value; }
		public int PorcentajeImpuesto { get => _porcentajeImpuesto; set => _porcentajeImpuesto = value; }
		public int PorcentajeDescuento { get => _porcentajeDescuento; set => _porcentajeDescuento = value; }
		public int CantidadBackOrder { get => _cantidadBackOrder; set => _cantidadBackOrder = value; }
		public int Estado { get => _estado; set => _estado = value; }
	}
}
