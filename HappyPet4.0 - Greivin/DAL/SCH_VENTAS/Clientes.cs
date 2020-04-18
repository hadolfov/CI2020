using System;
using System.Collections.Generic;
using System.Text;

namespace DL.SCH_VENTAS
{
    public class Clientes
    {
        private int _idCliente;
		private int _idTipoIdentificacion;
		private string _identificacion;
		private string _nombre;
		private string _primerApellido;
		private string _segundoApellido;
		private string _email;
		private string _telefono1;
		private string _telefono2;
		private int _estado;

		public int IdCliente { get => _idCliente; set => _idCliente = value; }
		public int IdTipoIdentificacion { get => _idTipoIdentificacion; set => _idTipoIdentificacion = value; }
		public string Identificacion { get => _identificacion; set => _identificacion = value; }
		public string Nombre { get => _nombre; set => _nombre = value; }
		public string PrimerApellido { get => _primerApellido; set => _primerApellido = value; }
		public string SegundoApellido { get => _segundoApellido; set => _segundoApellido = value; }
		public string Email { get => _email; set => _email = value; }
		public string Telefono1 { get => _telefono1; set => _telefono1 = value; }
		public string Telefono2 { get => _telefono2; set => _telefono2 = value; }
		public int Estado { get => _estado; set => _estado = value; }
	}
}
