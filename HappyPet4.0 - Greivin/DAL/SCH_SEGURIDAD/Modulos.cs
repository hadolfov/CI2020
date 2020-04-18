using System;
using System.Collections.Generic;
using System.Text;

namespace DL.SCH_SEGURIDAD
{
    public class Modulos
    {
		private int _idModulos;
		private string _nombre;
		private int _estado;

		public int IdModulos { get => _idModulos; set => _idModulos = value; }
		public string Nombre { get => _nombre; set => _nombre = value; }
		public int Estado { get => _estado; set => _estado = value; }
	}
}
