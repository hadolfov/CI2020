using System;
using System.Collections.Generic;
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
            obj_BD_DAL.dt_Parametros.Rows.Add("@@CONTRASENNA", 1, obj_BD_BLL.encriptar(usuario.Contrasenna));
            obj_BD_DAL.dt_Parametros.Rows.Add("@@IDTIPOPERFIL", 2, usuario.IdTipoPerfil );
            obj_BD_DAL.dt_Parametros.Rows.Add("@@ID_ESTADO", 2, usuario.Estado);
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

        public UsuariosSeguridad consultar(int idUsuarioSeguridad, ref string MsjError)
        {
            UsuariosSeguridad resultado = null;
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.dt_Parametros.Rows.Add("@@IDUSUARIOSEGURIDAD", 2, idUsuarioSeguridad);
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
                resultado.Contrasenna = obj_BD_BLL.desencriptar(obj_BD_DAL.DS.Tables[0].Rows[0][2].ToString());
                resultado.Estado = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[0][3].ToString());
                resultado.IdUsuarioSeguridad = idUsuarioSeguridad;
                MsjError = string.Empty;
            }
            return resultado;
        }

        public List<viewUsuario> consultar_usuarios(ref string MsjError)
        {
            List<viewUsuario> resultado = new List<viewUsuario>();
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);
            obj_BD_DAL.sNombreTabla = "tbl_Usuarios";
            obj_BD_DAL.sSentencia = "SCH_SEGURIDAD.SP_CONSULTAR_USUARIOS";
            obj_BD_BLL.Ejec_DataAdapter(ref obj_BD_DAL);
            if (obj_BD_DAL.sMsjError != string.Empty)
            {
                MsjError = obj_BD_DAL.sMsjError;
            }
            else
            {
                for (int i = 0; i <= obj_BD_DAL.DS.Tables[0].Rows.Count - 1; i++)
                {
                    viewUsuario usuario = new viewUsuario();
                    usuario.IdUsuarioSeguridad = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][0]);
                    usuario.Identificacion = obj_BD_DAL.DS.Tables[0].Rows[i][1].ToString();
                    usuario.Nombrecompleto = obj_BD_DAL.DS.Tables[0].Rows[i][2].ToString();
                    usuario.NombreSucursal = obj_BD_DAL.DS.Tables[0].Rows[i][3].ToString();
                    usuario.TipoPerfil = obj_BD_DAL.DS.Tables[0].Rows[i][4].ToString();
                    usuario.Estado = obj_BD_DAL.DS.Tables[0].Rows[i][5].ToString();

                    resultado.Add(usuario);
                }


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

        public void modificar(UsuariosSeguridad usuario, ref string error)
        {
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.dt_Parametros.Rows.Add("@@NOMBREUSUARIO", 1, usuario.NombreUsuario);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@CONTRASENNA", 1, usuario.Contrasenna);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@IDTIPOPERFIL", 2, usuario.IdTipoPerfil);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@IDUSUARIOSEGURIDAD", 2, usuario.IdUsuarioSeguridad);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@ID_ESTADO", 2, usuario.Estado);
            obj_BD_DAL.sNombreTabla = "tbl_UsuariosSeguridad";
            obj_BD_DAL.sSentencia = "SCH_SEGURIDAD.SP_MODIFICA_USUARIOSSEGURIDAD";
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
