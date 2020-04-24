using System;
using System.Collections.Generic;
using System.Text;

namespace DL.SCH_NOMINA
{
    public class DiasLibres
    {
        private int _idDiaLibre;
        private int _idHorario;
        private int _idDia;
        private int _estado;

        public int IdDiaLibre { get => _idDiaLibre; set => _idDiaLibre = value; }
        public int IdHorario { get => _idHorario; set => _idHorario = value; }
        public int IdDia { get => _idDia; set => _idDia = value; }
        public int Estado { get => _estado; set => _estado = value; }
    }

}
