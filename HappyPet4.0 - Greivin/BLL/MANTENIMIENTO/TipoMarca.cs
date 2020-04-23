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
    public class BLTipoMarca
    {
        public List<viewTiposMarca> consultar_TipoMarca(ref string MsjError)
        {
            List<viewTiposMarca> resultado = new List<viewTiposMarca>();
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);
            
            obj_BD_DAL.sNombreTabla = "tbl_TiposMarca";
            obj_BD_DAL.sSentencia = "SCH_NOMINA.sp_ListarTipoMarca";
            obj_BD_BLL.Ejec_DataAdapter(ref obj_BD_DAL);
            if (obj_BD_DAL.sMsjError != string.Empty)
            {
                MsjError = obj_BD_DAL.sMsjError;
            }
            else
            {
                for (int i = 0; i <= obj_BD_DAL.DS.Tables[0].Rows.Count - 1; i++)
                {
                    viewTiposMarca tipoMarca = new viewTiposMarca();
                    tipoMarca.IdTipoMarca = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][0]);
                    tipoMarca.TipoMarca = obj_BD_DAL.DS.Tables[0].Rows[i][1].ToString();
                    tipoMarca.Estado = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][2]);

                    resultado.Add(tipoMarca);
                }


                MsjError = string.Empty;
            }
            return resultado;
        }


        public void Insertar_TipoMarca(TiposMarca tiposMarca, ref string error)
        {
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.dt_Parametros.Rows.Add("@IdTipoMarca", 2, tiposMarca.IdTipoMarca);
            obj_BD_DAL.dt_Parametros.Rows.Add("@TipoMarca", 1, tiposMarca.TipoMarca);
            obj_BD_DAL.dt_Parametros.Rows.Add("@IdEstado", 2, tiposMarca.Estado);
            obj_BD_DAL.sNombreTabla = "tbl_TiposMarca";
            obj_BD_DAL.sSentencia = "SCH_NOMINA.sp_InsertarTipoMarca";
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

        public void Modificar_TipoMarca(TiposMarca tiposMarca, ref string error)
        {
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.dt_Parametros.Rows.Add("@IdTipoMarca", 2, tiposMarca.IdTipoMarca);
            obj_BD_DAL.dt_Parametros.Rows.Add("@TipoMarca", 1, tiposMarca.TipoMarca);
            obj_BD_DAL.dt_Parametros.Rows.Add("@IdEstado ", 2, tiposMarca.Estado);
            obj_BD_DAL.sNombreTabla = "tbl_TiposMarca";
            obj_BD_DAL.sSentencia = "SCH_NOMINA.sp_ModificarTipoMarca";
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

        public TiposMarca consultar_TipoMarca_Id(int idTipoMarca, ref string error)
        {
            TiposMarca resultado = null;
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.dt_Parametros.Rows.Add("@IdTipoMarca", 2, idTipoMarca);
            obj_BD_DAL.sNombreTabla = "tbl_TiposMarca";
            obj_BD_DAL.sSentencia = "SCH_NOMINA.sp_ConsultarTipoMarca";
            obj_BD_BLL.Ejec_DataAdapter(ref obj_BD_DAL);
            if (obj_BD_DAL.sMsjError != string.Empty)
            {
                error = obj_BD_DAL.sMsjError;
            }
            else
            {
                resultado = new TiposMarca();
                resultado.IdTipoMarca = idTipoMarca;
                resultado.TipoMarca = obj_BD_DAL.DS.Tables[0].Rows[0][0].ToString();
                resultado.Estado = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[0][1]);

                error = string.Empty;
            }
            return resultado;
        }
    }

   
}
