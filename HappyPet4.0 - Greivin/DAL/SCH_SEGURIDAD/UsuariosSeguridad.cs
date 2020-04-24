using System;
using System.Collections.Generic;
using System.Text;

namespace DL.SCH_SEGURIDAD
{
    public class UsuariosSeguridad
    {
        private int _idUsuarioSeguridad;
        private string _nombreUsuario;
        private string _contrasenna;
        private int _idTipoPerfil;
        private int _estado;

        public int IdUsuarioSeguridad { get => _idUsuarioSeguridad; set => _idUsuarioSeguridad = value; }
        public string NombreUsuario { get => _nombreUsuario; set => _nombreUsuario = value; }
        public string Contrasenna { get => _contrasenna; set => _contrasenna = value; }
        public int IdTipoPerfil { get => _idTipoPerfil; set => _idTipoPerfil = value; }
        public int Estado { get => _estado; set => _estado = value; }
    }

    public class viewUsuario
    {
        private int _idUsuarioSeguridad;
        private string _identificacion;
        private string _nombrecompleto;
        private string _nombreSucursal;
        private string _tipoPerfil;
        private string _estado;

        public int IdUsuarioSeguridad { get => _idUsuarioSeguridad; set => _idUsuarioSeguridad = value; }
        public string Identificacion { get => _identificacion; set => _identificacion = value; }
        public string Nombrecompleto { get => _nombrecompleto; set => _nombrecompleto = value; }
        public string NombreSucursal { get => _nombreSucursal; set => _nombreSucursal = value; }
        public string TipoPerfil { get => _tipoPerfil; set => _tipoPerfil = value; }
        public string Estado { get => _estado; set => _estado = value; }
    }
}
