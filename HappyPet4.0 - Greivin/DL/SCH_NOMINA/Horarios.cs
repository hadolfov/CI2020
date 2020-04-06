using System;
using System.Collections.Generic;
using System.Text;

namespace DL.SCH_NOMINA
{
    public class Horarios
    {
        private int _horario;
        private int _idUsuario;
        private int _estado;
        private TimeSpan _horaEntrada;
        private TimeSpan _horaSalida;

        public int Horario { get => _horario; set => _horario = value; }
        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public int Estado { get => _estado; set => _estado = value; }
        public TimeSpan HoraEntrada { get => _horaEntrada; set => _horaEntrada = value; }
        public TimeSpan HoraSalida { get => _horaSalida; set => _horaSalida = value; }
    }
}
