using System;
using System.Collections.Generic;
using System.Text;

namespace DL.SCH_INVENTARIO
{
    public class Articulo
    {
		private int _idArticulo;
		private string _nombreArticulo;
		private string _descripcion;
		private bool _servicio;
		private double _precio;
		private int _cantidadStock;
		private int _cantidadMax;
		private int _cantidadMin;
		private int _estado;

		public int IdArticulo { get => _idArticulo; set => _idArticulo = value; }
		public string NombreArticulo { get => _nombreArticulo; set => _nombreArticulo = value; }
		public string Descripcion { get => _descripcion; set => _descripcion = value; }
		public bool Servicio { get => _servicio; set => _servicio = value; }
		public double Precio { get => _precio; set => _precio = value; }
		public int CantidadStock { get => _cantidadStock; set => _cantidadStock = value; }
		public int CantidadMax { get => _cantidadMax; set => _cantidadMax = value; }
		public int CantidadMin { get => _cantidadMin; set => _cantidadMin = value; }
		public int Estado { get => _estado; set => _estado = value; }
	}

}
