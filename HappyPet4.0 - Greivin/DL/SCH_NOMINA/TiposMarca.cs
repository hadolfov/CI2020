using System;
using System.Collections.Generic;
using System.Text;

namespace DL.SCH_NOMINA
{
    public class TiposMarca
    {
        private int _idTipoMarca;
        private string _TipoMarca;
        private int _estado;

        public int IdTipoMarca { get => _idTipoMarca; set => _idTipoMarca = value; }
        public string TipoMarca { get => _TipoMarca; set => _TipoMarca = value; }
        public int Estado { get => _estado; set => _estado = value; }
    }
}
