using System;
using System.Collections.Generic;
using System.Text;

namespace DL.SCH_MANTENIMIENTO
{
    public class Sucursales
    {
        private int _idSucursal;
        private string _nombreSucursal;
        private int _idEmpresa;
        private int _estado;

        public int IdSucursal { get => _idSucursal; set => _idSucursal = value; }
        public string NombreSucursal { get => _nombreSucursal; set => _nombreSucursal = value; }
        public int IdEmpresa { get => _idEmpresa; set => _idEmpresa = value; }
        public int Estado { get => _estado; set => _estado = value; }
    }

    public class viewSucursales
    {
        private int _idsucursal;
        private string _nombresucursal;
        private string _idempresa;
        private string _estado;

        public int Idsucursal { get => _idsucursal; set => _idsucursal = value; }
        public string Nombresucursal { get => _nombresucursal; set => _nombresucursal = value; }
        public string Idempresa { get => _idempresa; set => _idempresa = value; }
        public string Estado { get => _estado; set => _estado = value; }
    }
}
