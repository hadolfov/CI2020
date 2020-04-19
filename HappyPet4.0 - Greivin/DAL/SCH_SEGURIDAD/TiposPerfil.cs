using System;
using System.Collections.Generic;
using System.Text;

namespace DL.SCH_SEGURIDAD
{
    public class TiposPerfil
    {
        private int _idTipoPerfil;
        private string _tipoPerfil;
        private int _idSucursal;
        private int _IdEspecialidad;
        private int _estado;

        public int IdTipoPerfil { get => _idTipoPerfil; set => _idTipoPerfil = value; }
        public string TipoPerfil { get => _tipoPerfil; set => _tipoPerfil = value; }
        public int IdSucursal { get => _idSucursal; set => _idSucursal = value; }
        public int IdEspecialidad { get => _IdEspecialidad; set => _IdEspecialidad = value; }
        public int Estado { get => _estado; set => _estado = value; }
    }

    public class viewTiposPerfil
    {
        private int _idTipoPerfil;
        private string _tipoPerfil;
        private string _sucursal;
        private string _especialidad;
        private string _estado;

        public int IdTipoPerfil { get => _idTipoPerfil; set => _idTipoPerfil = value; }
        public string TipoPerfil { get => _tipoPerfil; set => _tipoPerfil = value; }
        public string Sucursal { get => _sucursal; set => _sucursal = value; }
        public string Especialidad { get => _especialidad; set => _especialidad = value; }
        public string Estado { get => _estado; set => _estado = value; }
    }
}
