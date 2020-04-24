using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SCH_NOMINA
{
    public class Permisos_X_Usuarios
    {
        private int _idUsuario;
        private int _idTipoPerfil;
        private List<Modulo> _modulos;

        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public int IdTipoPerfil { get => _idTipoPerfil; set => _idTipoPerfil = value; }
        public List<Modulo> Modulos { get => _modulos; set => _modulos = value; }
    }
    public class Permiso
    {
        private bool _insertar;
        private bool _modificar;
        private bool _eliminar;

        public bool Insertar { get => _insertar; set => _insertar = value; }
        public bool Modificar { get => _modificar; set => _modificar = value; }
        public bool Eliminar { get => _eliminar; set => _eliminar = value; }
    }

    public class SubModulo
    {
        private int _idSubModulo;
        private string _nombreSubModulo;
        private Permiso _Permiso;

        public int IdSubModulo { get => _idSubModulo; set => _idSubModulo = value; }
        public string NombreSubModulo { get => _nombreSubModulo; set => _nombreSubModulo = value; }
        public Permiso Permiso { get => _Permiso; set => _Permiso = value; }
    }

    public class Modulo
    {
        private int _idModulo;
        private string _nombreModulo;
        private List<SubModulo> _subModulos;

        public int IdModulo { get => _idModulo; set => _idModulo = value; }
        public string NombreModulo { get => _nombreModulo; set => _nombreModulo = value; }
        public List<SubModulo> SubModulos { get => _subModulos; set => _subModulos = value; }
    }
}
