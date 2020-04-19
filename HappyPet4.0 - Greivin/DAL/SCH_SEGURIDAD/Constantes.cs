using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SCH_SEGURIDAD
{
    public class Constantes
    {
        public enum Modulos
        {
            Inventario = 1,
            Nómina = 2,
            Seguridad = 3,
            Ventas = 4
        }

        public enum SubModulosInventario
        {
            Productos = 1,
            MotivosMovimientos = 2,
            Proveedores = 3,
            TiposMovimientos = 4,
            IngresoListado = 5,
            DescontinuarProductos = 6,
            ControlInventario = 7
        }

        public enum SubModulosNomina
        {
            Planilla = 8,
            Marcas = 9,
            Permisos = 10,
            TiposMarcas = 11,
            TiposPermisos = 12,
            TiposIdentificacion = 13
        }

        public enum SubModulosSeguridad
        {
            TiposPerfil = 14,
            RecuperacionContrasenna = 15,
            PermisosSeguridad = 16,
            UsuariosSeguridad = 17
        }

        public enum SubModulosVentas
        {
            Empresa = 18,
            SucursalesCajas = 19,
            Especialidades = 20,
            Citas = 21,
            Ventas = 22,
            ClientesMascotas = 23,
            EspecieRazas = 24
        }

    }
}
