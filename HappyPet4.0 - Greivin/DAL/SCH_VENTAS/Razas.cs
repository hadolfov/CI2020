using System;
using System.Collections.Generic;
using System.Text;

namespace DL.SCH_VENTAS
{
    public class Razas
    {
		private int _idRaza;
		private int _idEspecie;
		private string _desRaza;
		private int _estado;

		public int IdRaza { get => _idRaza; set => _idRaza = value; }
		public int IdEspecie { get => _idEspecie; set => _idEspecie = value; }
		public string DesRaza { get => _desRaza; set => _desRaza = value; }
		public int Estado { get => _estado; set => _estado = value; }
	}

}
