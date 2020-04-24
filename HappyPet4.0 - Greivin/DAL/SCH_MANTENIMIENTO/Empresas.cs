using System;
using System.Collections.Generic;
using System.Text;

namespace DL.SCH_MANTENIMIENTO
{
    public class Empresas
    {
        private int _idEmpresa;
        private string _Nombre;
        private string _cedulaJuridica;
        private int idTipoIden;
        private int _estado;

        public int IdEmpresa { get => _idEmpresa; set => _idEmpresa = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string CedulaJuridica { get => _cedulaJuridica; set => _cedulaJuridica = value; }
        public int IdTipoIden { get => idTipoIden; set => idTipoIden = value; }
        public int Estado { get => _estado; set => _estado = value; }
    }

    public class viewEmpresas
    {
        private int _idEmpresa;
        private string _Nombre;
        private string _cedulajuridica;
        private string _idTipoIden;
        private string _estado;

        public int IdEmpresa { get => _idEmpresa; set => _idEmpresa = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Cedulajuridica { get => _cedulajuridica; set => _cedulajuridica = value; }
        public string IdTipoIden { get => _idTipoIden; set => _idTipoIden = value; }
        public string Estado { get => _estado; set => _estado = value; }
    }

}
