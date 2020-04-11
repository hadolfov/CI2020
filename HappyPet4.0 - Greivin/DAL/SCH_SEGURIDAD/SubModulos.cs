using System;
using System.Collections.Generic;
using System.Text;

namespace DL.SCH_SEGURIDAD
{
    public class SubModulos
    {
        private int _idSubmodulo;
        private int _idModulo;
        private string _nombre;
        private int _estado;

        public int IdSubmodulo { get => _idSubmodulo; set => _idSubmodulo = value; }
        public int IdModulo { get => _idModulo; set => _idModulo = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public int Estado { get => _estado; set => _estado = value; }
    }
}
