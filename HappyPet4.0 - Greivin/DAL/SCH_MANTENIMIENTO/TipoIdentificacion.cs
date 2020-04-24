using System;
using System.Collections.Generic;
using System.Text;

namespace DL.SCH_MANTENIMIENTO
{
    public class TipoIdenti
    {
        private int _idTipoIdentificacion;
        private string _tipoIdentificacion;
        private string _codigoTipoIdentificacion;
        private int _estado;

        public int IdTipoIdentificacion { get => _idTipoIdentificacion; set => _idTipoIdentificacion = value; }
        public string TipoIdentificacion { get => _tipoIdentificacion; set => _tipoIdentificacion = value; }
        public string CodigoTipoIdentificacion { get => _codigoTipoIdentificacion; set => _codigoTipoIdentificacion = value; }
        public int Estado { get => _estado; set => _estado = value; }
    }

}
