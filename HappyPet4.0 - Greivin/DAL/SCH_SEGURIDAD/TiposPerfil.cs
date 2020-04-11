using System;
using System.Collections.Generic;
using System.Text;

namespace DL.SCH_SEGURIDAD
{
    public class TiposPerfil
    {
        private int _idTipoPerfil;
        private string _tipoPerfil;
        private int _estado;

        public int IdTipoPerfil { get => _idTipoPerfil; set => _idTipoPerfil = value; }
        public string TipoPerfil { get => _tipoPerfil; set => _tipoPerfil = value; }
        public int Estado { get => _estado; set => _estado = value; }
    }
}
