using System;
using System.Collections.Generic;
using System.Text;

namespace DL.SCH_MANTENIMIENTO
{
    public class Especialidades
    {
        private int _idEspecialidad;
        private string _desEspecialidad;
        private int _idsurcursal;
        private int _estado;

        public int IdEspecialidad { get => _idEspecialidad; set => _idEspecialidad = value; }
        public string DesEspecialidad { get => _desEspecialidad; set => _desEspecialidad = value; }
        public int Idsurcursal { get => _idsurcursal; set => _idsurcursal = value; }
        public int Estado { get => _estado; set => _estado = value; }
    }

    public class viewEspecialidades
    {
        private int _idEspecialidad;
        private string _desEspecialidad;
        private string _idSucursal;
        private string _estado;

        public int IdEspecialidad { get => _idEspecialidad; set => _idEspecialidad = value; }
        public string DesEspecialidad { get => _desEspecialidad; set => _desEspecialidad = value; }
        public string IdSucursal { get => _idSucursal; set => _idSucursal = value; }
        public string Estado { get => _estado; set => _estado = value; }
    }
}
