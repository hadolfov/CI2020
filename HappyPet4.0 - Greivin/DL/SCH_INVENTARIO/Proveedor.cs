using System;
using System.Collections.Generic;
using System.Text;

namespace DL.SCH_INVENTARIO
{
    public class Proveedor
    {
		private int _idProveedor;
		private int _idTipoIdentificacion;
		private string _identificacion;
		private string _nombre;
		private string _Apellido1;
		private string _Apellido2;
		private string _email;
		private string _telefono1;
		private string _telefono2;
		private int _estado;

		public int IdProveedor { get => _idProveedor; set => _idProveedor = value; }
		public int IdTipoIdentificacion { get => _idTipoIdentificacion; set => _idTipoIdentificacion = value; }
		public string Identificacion { get => _identificacion; set => _identificacion = value; }
		public string Nombre { get => _nombre; set => _nombre = value; }
		public string Apellido1 { get => _Apellido1; set => _Apellido1 = value; }
		public string Apellido2 { get => _Apellido2; set => _Apellido2 = value; }
		public string Email { get => _email; set => _email = value; }
		public string Telefono1 { get => _telefono1; set => _telefono1 = value; }
		public string Telefono2 { get => _telefono2; set => _telefono2 = value; }
		public int Estado { get => _estado; set => _estado = value; }
	}
}
