using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.SCH_SEGURIDAD;
using BLL.BD;
using DAL.BD;

namespace BLL.MANTENIMIENTO
{
    public class BLPermisosSeguridad
    {
        public List<PermisosSeguridad> consultar_Permisos_Perfil(int idTipoPerfil,ref string MsjError)
        {
            List<PermisosSeguridad> resultado = new List<PermisosSeguridad>();
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@IDTIPOPERFIL", 2, idTipoPerfil);
            obj_BD_DAL.sNombreTabla = "tbl_TipoPerfil";
            obj_BD_DAL.sSentencia = "SCH_SEGURIDAD.SP_CONSULTAR_PERMISOS_SEGURIDAD";
            obj_BD_BLL.Ejec_DataAdapter(ref obj_BD_DAL);
            if (obj_BD_DAL.sMsjError != string.Empty)
            {
                MsjError = obj_BD_DAL.sMsjError;
            }
            else
            {
                for (int i = 0; i <= obj_BD_DAL.DS.Tables[0].Rows.Count - 1; i++)
                {
                    PermisosSeguridad  permisos = new PermisosSeguridad();
                    permisos.IdPermisoSeguridad = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][0]);
                    permisos.IdTipoPerfil = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][1]);
                    permisos.IdSubmodulo = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][2]);
                    permisos.Insertar  = Convert.ToBoolean(obj_BD_DAL.DS.Tables[0].Rows[i][3]);
                    permisos.Modificar  = Convert.ToBoolean(obj_BD_DAL.DS.Tables[0].Rows[i][4]);
                    permisos.Eliminar  = Convert.ToBoolean(obj_BD_DAL.DS.Tables[0].Rows[i][5]);
                    permisos.Estado = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][6]);

                    resultado.Add(permisos);
                }


                MsjError = string.Empty;
            }
            return resultado;
        }

        public void GuardarPermisos(List<PermisosSeguridad> permisosSeguridad, ref string error)
        {
            LimpiarPermisos(permisosSeguridad[0].IdTipoPerfil, ref error);
            if (error == "")
            {
                foreach (PermisosSeguridad permiso in permisosSeguridad)
                {
                    if (error == "")
                    {
                        GuardarPermisoSeguridad(permiso, ref error);
                    }
                }
            }
        }

        private void GuardarPermisoSeguridad(PermisosSeguridad permiso, ref string error)
        {
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@IDTIPOPERFIL", 2, permiso.IdTipoPerfil);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@IDSUBMODULO", 2, permiso.IdSubmodulo);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@INSERTAR", 3, permiso.Insertar);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@MODIFICAR", 3, permiso.Modificar);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@ELIMINAR", 3, permiso.Eliminar);
            obj_BD_DAL.sNombreTabla = "tbl_PermisosSeguridad";
            obj_BD_DAL.sSentencia = "SCH_SEGURIDAD.SP_GUARDA_PERMISOSSEGURIDAD";
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

        private void LimpiarPermisos(int idTipoPerfil, ref string error)
        {

            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@IDTIPOPERFIL", 2, idTipoPerfil);
            obj_BD_DAL.sNombreTabla = "tbl_PermisosSeguridad";
            obj_BD_DAL.sSentencia = "SCH_SEGURIDAD.SP_LIMPIAR_PERMISOS_SEGURIDAD";
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
