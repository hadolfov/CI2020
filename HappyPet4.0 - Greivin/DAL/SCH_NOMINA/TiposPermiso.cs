using System;
using System.Collections.Generic;
using System.Text;

namespace DL.SCH_NOMINA
{
    public class TiposPermiso
    {
        private int _idTipoPermiso;
        private string _TipoPermiso;
        private int _estado;

        public int IdTipoPermiso { get => _idTipoPermiso; set => _idTipoPermiso = value; }
        public string TipoPermiso { get => _TipoPermiso; set => _TipoPermiso = value; }
        public int Estado { get => _estado; set => _estado = value; }
    }
}
