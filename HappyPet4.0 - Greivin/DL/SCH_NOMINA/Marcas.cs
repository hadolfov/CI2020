using System;
using System.Collections.Generic;
using System.Text;

namespace DL.SCH_NOMINA
{
    public class Marcas
    {
        private int _idMarca;
        private int _idUsuario;
        private int _fechaRegistro;
        private int _idTipoMarca;

        public int IdMarca { get => _idMarca; set => _idMarca = value; }
        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public int FechaRegistro { get => _fechaRegistro; set => _fechaRegistro = value; }
        public int IdTipoMarca { get => _idTipoMarca; set => _idTipoMarca = value; }
    }
}
