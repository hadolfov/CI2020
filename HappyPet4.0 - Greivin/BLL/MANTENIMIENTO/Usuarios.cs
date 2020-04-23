using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.BD;
using DAL.BD;
using DAL.SCH_SEGURIDAD;
using DL.SCH_NOMINA;
//Prueba de modificacion de dato de Maluco

namespace BLL.MANTENIMIENTO
{
    public class BLUsuarios
    {
        public Usuarios consultar_IdUsuario(int idUsuario, ref string MsjError)
        {
            Usuarios resultado = null;
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.dt_Parametros.Rows.Add("@Id_Usuario", 2, idUsuario);
            obj_BD_DAL.sNombreTabla = "tbl_Usuarios";
            obj_BD_DAL.sSentencia = "SCH_NOMINA.sp_ConsultarUsuario_IdUSuario";
            obj_BD_BLL.Ejec_DataAdapter(ref obj_BD_DAL);
            if (obj_BD_DAL.sMsjError != string.Empty)
            {
                MsjError = obj_BD_DAL.sMsjError;
            }
            else
            {
                resultado = new Usuarios();
                resultado.IdUsuario = Convert.ToInt32( obj_BD_DAL.DS.Tables[0].Rows[0][0]);
                resultado.Identificacion = obj_BD_DAL.DS.Tables[0].Rows[0][1].ToString();
                resultado.Nombre = obj_BD_DAL.DS.Tables[0].Rows[0][2].ToString();
                resultado.PrimerApellido = obj_BD_DAL.DS.Tables[0].Rows[0][3].ToString();
                resultado.SegundoApellido = obj_BD_DAL.DS.Tables[0].Rows[0][4].ToString();
                resultado.Email = obj_BD_DAL.DS.Tables[0].Rows[0][5].ToString();
                resultado.Telefono1 = obj_BD_DAL.DS.Tables[0].Rows[0][6].ToString();
                resultado.Telefono2 = obj_BD_DAL.DS.Tables[0].Rows[0][7].ToString();
                resultado.IdSucursal = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[0][8]);
                resultado.Estado = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[0][9]);
                MsjError = string.Empty;
            }
            return resultado;
        }

        public Permisos_X_Usuarios consultar_permisos_x_usuario(int idUsuario, ref string MsjError)
        {
            Permisos_X_Usuarios resultado = null;
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.dt_Parametros.Rows.Add("@IdUsuario", 2, idUsuario);
            obj_BD_DAL.sNombreTabla = "vw_Permisos_X_Usuarios";
            obj_BD_DAL.sSentencia = "SCH_SEGURIDAD.SP_ConsultaPermisos_X_Usuario";
            obj_BD_BLL.Ejec_DataAdapter(ref obj_BD_DAL);
            if (obj_BD_DAL.sMsjError != string.Empty)
            {
                MsjError = obj_BD_DAL.sMsjError;
            }
            else
            {
                resultado = new Permisos_X_Usuarios();
                resultado.IdUsuario = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[0][0]);
                resultado.IdTipoPerfil = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[0][1]);
                resultado.Modulos = new List<Modulo>();
                Modulo modulo = new Modulo();
                modulo.IdModulo = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[0][2]);
                modulo.NombreModulo = obj_BD_DAL.DS.Tables[0].Rows[0][3].ToString();
                modulo.SubModulos = new List<SubModulo>();
                SubModulo subModulo;

                for (int i = 0; i < obj_BD_DAL.DS.Tables[0].Rows.Count - 1; i++)
                {
                    if (Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][2]) != modulo.IdModulo)
                    {
                        resultado.Modulos.Add(modulo);

                        modulo = new Modulo();
                        modulo.IdModulo = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][2]);
                        modulo.NombreModulo = obj_BD_DAL.DS.Tables[0].Rows[i][3].ToString();
                        modulo.SubModulos = new List<SubModulo>();
                    }

                    subModulo = new SubModulo();
                    subModulo.IdSubModulo = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][4]);
                    subModulo.NombreSubModulo = obj_BD_DAL.DS.Tables[0].Rows[i][5].ToString();
                    subModulo.Permiso = new Permiso();
                    subModulo.Permiso.Insertar = Convert.ToBoolean(obj_BD_DAL.DS.Tables[0].Rows[i][6]);
                    subModulo.Permiso.Modificar = Convert.ToBoolean(obj_BD_DAL.DS.Tables[0].Rows[i][7]);
                    subModulo.Permiso.Eliminar = Convert.ToBoolean(obj_BD_DAL.DS.Tables[0].Rows[i][8]);

                    modulo.SubModulos.Add(subModulo);
                }
                resultado.Modulos.Add(modulo);
                MsjError = string.Empty;
            }
            return resultado;
        }

        public void insertar(Usuarios usuario, ref string error)
        {
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.dt_Parametros.Rows.Add("@Id_Usuario", 2, usuario.IdUsuario);
            obj_BD_DAL.dt_Parametros.Rows.Add("@Identificacion", 1, usuario.Identificacion);
            obj_BD_DAL.dt_Parametros.Rows.Add("@Nombre", 1, usuario.Nombre);
            obj_BD_DAL.dt_Parametros.Rows.Add("@PrimerApellido", 1, usuario.PrimerApellido);
            obj_BD_DAL.dt_Parametros.Rows.Add("@SegundoApellido", 1, usuario.SegundoApellido);
            obj_BD_DAL.dt_Parametros.Rows.Add("@email", 1, usuario.Email);
            obj_BD_DAL.dt_Parametros.Rows.Add("@Telefono1", 1, usuario.Telefono1);
            obj_BD_DAL.dt_Parametros.Rows.Add("@Telefono2", 1, usuario.Telefono2);
            obj_BD_DAL.dt_Parametros.Rows.Add("@IdSucursal", 2, usuario.IdSucursal);
            obj_BD_DAL.dt_Parametros.Rows.Add("@IdEstado", 2, usuario.Estado);
 
            obj_BD_DAL.sNombreTabla = "tbl_Usuarios";
            obj_BD_DAL.sSentencia = "SCH_NOMINA.sp_InsertarUsuario";
            obj_BD_BLL.Ejec_NonQuery(ref obj_BD_DAL);
            if (obj_BD_DAL.sMsjError != string.Empty)
            {
                error = obj_BD_DAL.sMsjError;
            }
            else
            {
                error = string.Empty;
            }

        }

        public void modificar(Usuarios usuario, ref string error)
        {
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.dt_Parametros.Rows.Add("@Id_Usuario", 2, usuario.IdUsuario);
            obj_BD_DAL.dt_Parametros.Rows.Add("@Identificacion", 1, usuario.Identificacion);
            obj_BD_DAL.dt_Parametros.Rows.Add("@Nombre", 1, usuario.Nombre);
            obj_BD_DAL.dt_Parametros.Rows.Add("@PrimerApellido", 1, usuario.PrimerApellido);
            obj_BD_DAL.dt_Parametros.Rows.Add("@SegundoApellido", 1, usuario.SegundoApellido);
            obj_BD_DAL.dt_Parametros.Rows.Add("@email", 1, usuario.Email);
            obj_BD_DAL.dt_Parametros.Rows.Add("@Telefono1", 1, usuario.Telefono1);
            obj_BD_DAL.dt_Parametros.Rows.Add("@Telefono2", 1, usuario.Telefono2);
            obj_BD_DAL.dt_Parametros.Rows.Add("@IdSucursal", 2, usuario.IdSucursal);
            obj_BD_DAL.dt_Parametros.Rows.Add("@IdEstado", 2, usuario.Estado);

            obj_BD_DAL.sNombreTabla = "tbl_Usuarios";
            obj_BD_DAL.sSentencia = "SCH_NOMINA.sp_ModificarUsuario";
            obj_BD_BLL.Ejec_NonQuery(ref obj_BD_DAL);
            if (obj_BD_DAL.sMsjError != string.Empty)
            {
                error = obj_BD_DAL.sMsjError;
            }
            else
            {
                error = string.Empty;
            }
        }
    }
}
