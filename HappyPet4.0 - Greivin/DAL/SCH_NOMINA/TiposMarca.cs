using System;
using System.Collections.Generic;
using System.Text;

namespace DL.SCH_NOMINA
{
    public class TiposMarca
    {
        private int _idTipoMarca;
        private string _tipoMarca;
        private int _estado;

        public int IdTipoMarca { get => _idTipoMarca; set => _idTipoMarca = value; }
        public string TipoMarca { get => _tipoMarca; set => _tipoMarca = value; }
        public int Estado { get => _estado; set => _estado = value; }
    }

    public class viewTiposMarca
    {
        private int _idTipoMarca;
        private string _tipoMarca;
        private int _estado;

        public int IdTipoMarca { get => _idTipoMarca; set => _idTipoMarca = value; }
        public string TipoMarca { get => _tipoMarca; set => _tipoMarca = value; }
        public int Estado { get => _estado; set => _estado = value; }

    }
        
        
}
