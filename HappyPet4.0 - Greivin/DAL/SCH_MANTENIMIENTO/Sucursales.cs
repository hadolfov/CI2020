using System;
using System.Collections.Generic;
using System.Text;

namespace DL.SCH_MANTENIMIENTO
{
    public class Sucursales
    {
        private int _idSucursal;
        private string _desSucursal;
        private int _idEmpresa;
        private int _estado;

        public int IdSucursal { get => _idSucursal; set => _idSucursal = value; }
        public string DesSucursal { get => _desSucursal; set => _desSucursal = value; }
        public int IdEmpresa { get => _idEmpresa; set => _idEmpresa = value; }
        public int Estado { get => _estado; set => _estado = value; }
    }
}
