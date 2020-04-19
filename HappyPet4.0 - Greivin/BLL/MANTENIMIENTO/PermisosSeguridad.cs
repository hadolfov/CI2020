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
        public List<PermisosSeguridad> consultar_Permisos_Perfil(ref string MsjError)
        {
            List<PermisosSeguridad> resultado = new List<PermisosSeguridad>();
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);
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
                    viewTiposPerfil tipoPerfil = new viewTiposPerfil();
                    tipoPerfil.IdTipoPerfil = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][0]);
                    tipoPerfil.TipoPerfil = obj_BD_DAL.DS.Tables[0].Rows[i][1].ToString();
                    tipoPerfil.Sucursal = obj_BD_DAL.DS.Tables[0].Rows[i][2].ToString();
                    tipoPerfil.Especialidad = obj_BD_DAL.DS.Tables[0].Rows[i][3].ToString();
                    tipoPerfil.Estado = obj_BD_DAL.DS.Tables[0].Rows[i][4].ToString();

                    resultado.Add(tipoPerfil);
                }


                MsjError = string.Empty;
            }
            return resultado;
        }
    }
}
