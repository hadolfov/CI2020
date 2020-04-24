using System;
using System.Collections.Generic;
using System.Text;

namespace DL.SCH_VENTAS
{
    public class Razas
    {
		private int _idRaza;
        private string _desRaza;
        private int _idEspecie;
		private int _estado;

        public int IdRaza { get => _idRaza; set => _idRaza = value; }
        public string DesRaza { get => _desRaza; set => _desRaza = value; }
        public int IdEspecie { get => _idEspecie; set => _idEspecie = value; }
        public int Estado { get => _estado; set => _estado = value; }
    }

    public class viewRazas
    {
        private int _idRaza;
        private string _desRaza;
        private string _idEspecie;
        private string _estado;

        public int IdRaza { get => _idRaza; set => _idRaza = value; }
        public string DesRaza { get => _desRaza; set => _desRaza = value; }
        public string IdEspecie { get => _idEspecie; set => _idEspecie = value; }
        public string Estado { get => _estado; set => _estado = value; }
    }

}
