using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.SCH_NOMINA;
using BLL.BD;
using DAL.BD;

namespace BLL.MANTENIMIENTO
{
    public class BLTipoPermiso
    {
        public List<viewTiposPermiso> consultar_TipoPermiso(ref string MsjError)
        {
            List<viewTiposPermiso> resultado = new List<viewTiposPermiso>();
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.sNombreTabla = "tbl_TiposPermiso";
            obj_BD_DAL.sSentencia = "SCH_NOMINA.sp_ListarTipoPermiso";
            obj_BD_BLL.Ejec_DataAdapter(ref obj_BD_DAL);
            if (obj_BD_DAL.sMsjError != string.Empty)
            {
                MsjError = obj_BD_DAL.sMsjError;
            }
            else
            {
                for (int i = 0; i <= obj_BD_DAL.DS.Tables[0].Rows.Count - 1; i++)
                {
                    viewTiposPermiso tipoPermiso = new viewTiposPermiso();
                    tipoPermiso.IdTipoPermiso = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][0]);
                    tipoPermiso.TipoPermiso = obj_BD_DAL.DS.Tables[0].Rows[i][1].ToString();
                    tipoPermiso.Estado = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][2]);

                    resultado.Add(tipoPermiso);
                }


                MsjError = string.Empty;
            }
            return resultado;
        }


        public void Insertar_TipoPermiso(TiposPermiso tiposPermiso, ref string error)
        {
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.dt_Parametros.Rows.Add("@IdTipoPermiso", 2, tiposPermiso.IdTipoPermiso);
            obj_BD_DAL.dt_Parametros.Rows.Add("@TipoPermiso", 1, tiposPermiso.TipoPermiso);
            obj_BD_DAL.dt_Parametros.Rows.Add("@IdEstado", 2, tiposPermiso.Estado);
            obj_BD_DAL.sNombreTabla = "tbl_TiposPermiso";
            obj_BD_DAL.sSentencia = "SCH_NOMINA.sp_InsertarTipoPermiso";
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

        public void Modificar_TipoPermiso(TiposPermiso tiposPermiso, ref string error)
        {
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.dt_Parametros.Rows.Add("@IdTipoPermiso", 2, tiposPermiso.IdTipoPermiso);
            obj_BD_DAL.dt_Parametros.Rows.Add("@TipoPermiso", 1, tiposPermiso.TipoPermiso);
            obj_BD_DAL.dt_Parametros.Rows.Add("@IdEstado ", 2, tiposPermiso.Estado);
            obj_BD_DAL.sNombreTabla = "tbl_TiposPermiso";
            obj_BD_DAL.sSentencia = "SCH_NOMINA.sp_ModificarTipoPermiso";
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

        public TiposPermiso consultar_TipoPermiso_Id(int idTipoPermiso, ref string error)
        {
            TiposPermiso resultado = null;
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.dt_Parametros.Rows.Add("@@IdTipoPermiso", 2, idTipoPermiso);
            obj_BD_DAL.sNombreTabla = "tbl_TiposPermiso";
            obj_BD_DAL.sSentencia = "SCH_NOMINA.sp_SelectTipoPermiso";
            obj_BD_BLL.Ejec_DataAdapter(ref obj_BD_DAL);
            if (obj_BD_DAL.sMsjError != string.Empty)
            {
                error = obj_BD_DAL.sMsjError;
            }
            else
            {
                resultado = new TiposPermiso();
                resultado.IdTipoPermiso = idTipoPermiso;
                resultado.TipoPermiso = obj_BD_DAL.DS.Tables[0].Rows[0][0].ToString();
                resultado.Estado = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[0][1]);

                error = string.Empty;
            }
            return resultado;
        }
    }
}
