using System;
using System.Collections.Generic;
using System.Text;

namespace DL.SCH_MANTENIMIENTO
{
    public class TipoIdentificacion
    {
        private int _idTipoIdentificacion;
        private string _desTipoIdentificacion;
        private string _codigoTipoIdentificacion;
        private int _estado;

        public int IdTipoIdentificacion { get => _idTipoIdentificacion; set => _idTipoIdentificacion = value; }
        public string DesTipoIdentificacion { get => _desTipoIdentificacion; set => _desTipoIdentificacion = value; }
        public string CodigoTipoIdentificacion { get => _codigoTipoIdentificacion; set => _codigoTipoIdentificacion = value; }
        public int Estado { get => _estado; set => _estado = value; }
    }

}
