using System;
using System.Collections.Generic;
using System.Text;

namespace DL.SCH_NOMINA
{
    public class Especialidad
    {
        private int _idEspecialidad;
        private string _desEspecialidad;
        private int _estado;

        public int IdEspecialidad { get => _idEspecialidad; set => _idEspecialidad = value; }
        public string DesEspecialidad { get => _desEspecialidad; set => _desEspecialidad = value; }
        public int Estado { get => _estado; set => _estado = value; }
    }
}
