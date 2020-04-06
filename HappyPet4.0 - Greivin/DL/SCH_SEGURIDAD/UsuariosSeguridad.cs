using System;
using System.Collections.Generic;
using System.Text;

namespace DL.SCH_SEGURIDAD
{
    public class UsuariosSeguridad
    {
        private int _idUsuarioSeguridad;
        private int _idUsuario;
        private string _nombreUsuario;
        private string _contrasenna;
        private int _idTipoPerfil;
        private int _estado;

        public int IdUsuarioSeguridad { get => _idUsuarioSeguridad; set => _idUsuarioSeguridad = value; }
        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public string NombreUsuario { get => _nombreUsuario; set => _nombreUsuario = value; }
        public string Contrasenna { get => _contrasenna; set => _contrasenna = value; }
        public int IdTipoPerfil { get => _idTipoPerfil; set => _idTipoPerfil = value; }
        public int Estado { get => _estado; set => _estado = value; }
    }
}
