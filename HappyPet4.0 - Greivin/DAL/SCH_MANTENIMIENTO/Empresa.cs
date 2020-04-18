using System;
using System.Collections.Generic;
using System.Text;

namespace DL.SCH_MANTENIMIENTO
{
    public class Empresa
    {
        private int _idEmpresa;
        private string _desEmpresa;
        private string _cedulaJuridica;
        private int _estado;

        public int IdEmpresa { get => _idEmpresa; set => _idEmpresa = value; }
        public string DesEmpresa { get => _desEmpresa; set => _desEmpresa = value; }
        public string CedulaJuridica { get => _cedulaJuridica; set => _cedulaJuridica = value; }
        public int Estado { get => _estado; set => _estado = value; }
    }

}
