using System;
using BLL.BD;
using DAL.BD;
using DL.SCH_SEGURIDAD;

namespace BLL.MANTENIMIENTO
{
    public class BLUsuarioSeguridad
    {
        public int insertar(UsuariosSeguridad usuario, ref string MsjError)
        {
            int resultado = -1;
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.dt_Parametros.Rows.Add("@@NOMBREUSUARIO", 1, usuario.NombreUsuario);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@CONTRASENNA", 1, usuario.Contrasenna);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@IDTIPOPERFIL", 2, usuario.IdTipoPerfil );
            obj_BD_DAL.dt_Parametros.Rows.Add("@@ID_ESTADO", 2, 1);
            obj_BD_DAL.sNombreTabla = "tbl_UsuariosSeguridad";
            obj_BD_DAL.sSentencia = "SCH_SEGURIDAD.SP_Inserta_USUARIOSSEGURIDAD";
            obj_BD_BLL.Ejec_Scalar(ref obj_BD_DAL);
            if (obj_BD_DAL.sMsjError != string.Empty)
            {
                MsjError = obj_BD_DAL.sMsjError;
            }
            else
            {
                resultado = Convert.ToInt32(obj_BD_DAL.sValorScalar);
                MsjError = string.Empty;
            }
            return resultado;
        }

        public UsuariosSeguridad consultar(UsuariosSeguridad usuario, ref string MsjError)
        {
            UsuariosSeguridad resultado = null;
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();
            int idUsuariosSeguridad = usuario.IdUsuarioSeguridad;

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.dt_Parametros.Rows.Add("@@IDUSUARIOSEGURIDAD", 2, usuario.IdUsuarioSeguridad );
            obj_BD_DAL.sNombreTabla = "tbl_UsuariosSeguridad";
            obj_BD_DAL.sSentencia = "SCH_SEGURIDAD.SP_SELECT_USUARIOSSEGURIDAD";
            obj_BD_BLL.Ejec_DataAdapter(ref obj_BD_DAL);
            if (obj_BD_DAL.sMsjError != string.Empty)
            {
                MsjError = obj_BD_DAL.sMsjError;
            }
            else
            {
                resultado = new UsuariosSeguridad();
                resultado.IdTipoPerfil = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[0][0]);
                resultado.NombreUsuario = obj_BD_DAL.DS.Tables[0].Rows[0][1].ToString();
                resultado.Contrasenna = obj_BD_DAL.DS.Tables[0].Rows[0][2].ToString();
                resultado.Estado = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[0][3].ToString());
                resultado.IdUsuarioSeguridad = idUsuariosSeguridad;
                MsjError = string.Empty;
            }
            return resultado;
        }

        public int consultar_Usuario_Contrasenna(UsuariosSeguridad usuario, ref string MsjError)
        {
            int resultado = -1;
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.dt_Parametros.Rows.Add("@@NOMBREUSUARIO", 1, usuario.NombreUsuario);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@CONTRASENNA", 1, obj_BD_BLL.encriptar(usuario.Contrasenna));
            obj_BD_DAL.sNombreTabla = "tbl_UsuariosSeguridad";
            obj_BD_DAL.sSentencia = "SCH_SEGURIDAD.SP_Consulta_Usuario_Contrasenna";
            obj_BD_BLL.Ejec_Scalar(ref obj_BD_DAL);
            if (obj_BD_DAL.sMsjError != string.Empty)
            {
                MsjError = obj_BD_DAL.sMsjError;
            }
            else
            {
                resultado = Convert.ToInt32(obj_BD_DAL.sValorScalar);
                MsjError = string.Empty;
            }
            return resultado;
        }
    }
}
