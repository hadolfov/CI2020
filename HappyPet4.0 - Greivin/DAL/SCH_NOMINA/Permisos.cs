using System;
using System.Collections.Generic;
using System.Text;

namespace DL.SCH_NOMINA
{
    public class Permisos
    {
        private int _idPermiso;
        private int _isUsuario;
        private int _idTipoPermiso;
        private DateTime _inicio;
        private DateTime _fin;
        private string _observacion;
        private int _estado;

        public int IdPermiso { get => _idPermiso; set => _idPermiso = value; }
        public int IsUsuario { get => _isUsuario; set => _isUsuario = value; }
        public int IdTipoPermiso { get => _idTipoPermiso; set => _idTipoPermiso = value; }
        public DateTime Inicio { get => _inicio; set => _inicio = value; }
        public DateTime Fin { get => _fin; set => _fin = value; }
        public string Observacion { get => _observacion; set => _observacion = value; }
        public int Estado { get => _estado; set => _estado = value; }
    }
}
