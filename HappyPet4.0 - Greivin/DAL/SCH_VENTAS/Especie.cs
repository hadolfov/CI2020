﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DL.SCH_VENTAS
{
    public class Especies
    {
        private int _idEspecie;
        private string _desEspecie;
        private int _estado;

        public int IdEspecie { get => _idEspecie; set => _idEspecie = value; }
        public string DesEspecie { get => _desEspecie; set => _desEspecie = value; }
        public int Estado { get => _estado; set => _estado = value; }
    }

    public class viewEspecies
    {
        private int _idEspecie;
        private string _desEspecie;
        private string _estado;

        public int IdEspecie { get => _idEspecie; set => _idEspecie = value; }
        public string DesEspecie { get => _desEspecie; set => _desEspecie = value; }
        public string Estado { get => _estado; set => _estado = value; }
    }
}
