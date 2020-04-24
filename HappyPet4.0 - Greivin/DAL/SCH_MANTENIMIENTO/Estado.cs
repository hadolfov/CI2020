using System;
using System.Collections.Generic;
using System.Text;

namespace DL.SCH_NOMINA
{
    public class Estado
    {
        private int _idEstado;
        private string _descripcion;

        public int IdEstado { get => _idEstado; set => _idEstado = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
    }
}
