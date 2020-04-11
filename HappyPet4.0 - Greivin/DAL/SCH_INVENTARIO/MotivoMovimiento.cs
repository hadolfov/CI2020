using System;
using System.Collections.Generic;
using System.Text;

namespace DL.SCH_INVENTARIO
{
    public class MotivoMovimiento
    {
        private int _idMotivo;
        private string _descripción;
        private int _estado;

        public int IdMotivo { get => _idMotivo; set => _idMotivo = value; }
        public string Descripción { get => _descripción; set => _descripción = value; }
        public int Estado { get => _estado; set => _estado = value; }
    }
}
