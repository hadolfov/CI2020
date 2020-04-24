using System;
using System.Collections.Generic;
using System.Text;

namespace DL.SCH_INVENTARIO
{
    public class TipoMovimiento
    {
        private int _idTipo;
        private string _nombreTipo;
        private int _estado;

        public int IdTipo { get => _idTipo; set => _idTipo = value; }
        public string NombreTipo { get => _nombreTipo; set => _nombreTipo = value; }
        public int Estado { get => _estado; set => _estado = value; }

    }
    public class viewTipoMovimiento
    {
        private int _idTipo;
        private string _nombreTipo;
        private int _estado;

        public int IdTipo { get => _idTipo; set => _idTipo = value; }
        public string NombreTipo { get => _nombreTipo; set => _nombreTipo = value; }
        public int Estado { get => _estado; set => _estado = value; }
    }

}
