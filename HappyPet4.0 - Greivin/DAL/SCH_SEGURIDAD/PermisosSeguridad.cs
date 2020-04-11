using System;
using System.Collections.Generic;
using System.Text;

namespace DL.SCH_SEGURIDAD
{
    public class PermisosSeguridad
    {
		private int _idPermisoSeguridad;
		private int _idTipoPerfil;
		private int _idSubmodulo;
		private bool _insertar;
		private bool _modificar;
		private bool _eliminar;
		private int _estado;

		public int IdPermisoSeguridad { get => _idPermisoSeguridad; set => _idPermisoSeguridad = value; }
		public int IdTipoPerfil { get => _idTipoPerfil; set => _idTipoPerfil = value; }
		public int IdSubmodulo { get => _idSubmodulo; set => _idSubmodulo = value; }
		public bool Insertar { get => _insertar; set => _insertar = value; }
		public bool Modificar { get => _modificar; set => _modificar = value; }
		public bool Eliminar { get => _eliminar; set => _eliminar = value; }
		public int Estado { get => _estado; set => _estado = value; }
	}
}
