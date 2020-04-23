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
    public class BLTipoIdentificacion
    {
        public List<viewTiposIdentificacion> consultar_TipoIdentificacion(ref string MsjError)
        {
            List<viewTiposIdentificacion> resultado = new List<viewTiposIdentificacion>();
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);
            obj_BD_DAL.sNombreTabla = "tbl_TiposIdentificacion";
            obj_BD_DAL.sSentencia = "SCH_MANTENIMIENTO.sp_TipoIdentificacion";
            obj_BD_BLL.Ejec_DataAdapter(ref obj_BD_DAL);
            if (obj_BD_DAL.sMsjError != string.Empty)
            {
                MsjError = obj_BD_DAL.sMsjError;
            }
            else
            {
                for (int i = 0; i <= obj_BD_DAL.DS.Tables[0].Rows.Count - 1; i++)
                {
                    viewTiposIdentificacion tipoIdentificacion = new viewTiposIdentificacion();
                    tipoIdentificacion.IdTipoIdentificacion = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][0]);
                    tipoIdentificacion.DesTipoIdentificacion = obj_BD_DAL.DS.Tables[0].Rows[i][1].ToString();
                    tipoIdentificacion.CodigoTipoIdentificacion = obj_BD_DAL.DS.Tables[0].Rows[i][1].ToString();
                    tipoIdentificacion.Estado = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][2]);

                    resultado.Add(tipoIdentificacion);
                }


                MsjError = string.Empty;
            }
            return resultado;
        }

        public void Insertar_TipoIdentificacion(TiposIdentificacion tiposIdentificacion, ref string error)
        {
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);


            obj_BD_DAL.dt_Parametros.Rows.Add("@TipoIdentificacion", 1, tiposIdentificacion.DesTipoIdentificacion);
            obj_BD_DAL.dt_Parametros.Rows.Add("@CodigoIdentificacion", 1, tiposIdentificacion.CodigoTipoIdentificacion);
            obj_BD_DAL.dt_Parametros.Rows.Add("@IdEstado", 2, tiposIdentificacion.Estado);
            obj_BD_DAL.sNombreTabla = "tbl_TiposIdentificacion";
            obj_BD_DAL.sSentencia = "SCH_MANTENIMIENTO.sp_insertarTipoIdentificacion";
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

        public void Modificar_TipoIdentificacion(TiposIdentificacion tiposIdentificacion, ref string error)
        {
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.dt_Parametros.Rows.Add("@IdTipoIdentificacion", 2, tiposIdentificacion.IdTipoIdentificacion);
            obj_BD_DAL.dt_Parametros.Rows.Add("@Tipoidentificacion", 1, tiposIdentificacion.DesTipoIdentificacion);
            obj_BD_DAL.dt_Parametros.Rows.Add("@CodigoTipoIdentificacion", 1, tiposIdentificacion.DesTipoIdentificacion);
            obj_BD_DAL.dt_Parametros.Rows.Add("@IdEstado ", 2, tiposIdentificacion.Estado);
            obj_BD_DAL.sNombreTabla = "tbl_TipoIdentificacion";
            obj_BD_DAL.sSentencia = "SCH_MANTENIMIENTO.sp_ModificarTipoIdentificacion";
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

        public TiposIdentificacion consultar_TipoIdentificacion_Id(int IdTipoIdentificacion, ref string error)
        {
            TiposIdentificacion resultado = null;
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.dt_Parametros.Rows.Add("@IdTipoIdentificacion", 2, IdTipoIdentificacion);
            obj_BD_DAL.sNombreTabla = "tbl_TipoIdentificacion";
            obj_BD_DAL.sSentencia = "SCH_MANTENIMIENTO.sp_ConsultarTipoIdentificacion";
            obj_BD_BLL.Ejec_DataAdapter(ref obj_BD_DAL);
            if (obj_BD_DAL.sMsjError != string.Empty)
            {
                error = obj_BD_DAL.sMsjError;
            }
            else
            {
                resultado = new TiposIdentificacion();
                resultado.IdTipoIdentificacion = IdTipoIdentificacion;
                resultado.DesTipoIdentificacion = obj_BD_DAL.DS.Tables[0].Rows[0][0].ToString();
                resultado.CodigoTipoIdentificacion = obj_BD_DAL.DS.Tables[0].Rows[0][1].ToString();
                resultado.Estado = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[0][2]);

                error = string.Empty;
            }
            return resultado;
        }


    }
}
