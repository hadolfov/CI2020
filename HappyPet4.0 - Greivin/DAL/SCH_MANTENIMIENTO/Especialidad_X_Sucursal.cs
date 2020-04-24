using System;
using System.Collections.Generic;
using System.Text;

namespace DL.SCH_NOMINA
{
    public class Especialidad_X_Sucursal
    {
        private int _IdEspe_X_Suc;
        private int _idSucursal;
        private int _idEspecialidad;
        private int _estado;

        public int IdEspe_X_Suc { get => _IdEspe_X_Suc; set => _IdEspe_X_Suc = value; }
        public int IdSucursal { get => _idSucursal; set => _idSucursal = value; }
        public int IdEspecialidad { get => _idEspecialidad; set => _idEspecialidad = value; }
        public int Estado { get => _estado; set => _estado = value; }
    }
}
