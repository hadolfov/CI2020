using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.SCH_MANTENIMIENTO;
using BLL.BD;
using DAL.BD;

namespace BLL.MANTENIMIENTO
{
    public class BLTipoIdentificacion
    {
        public List<TipoIdenti> Consultar_TipoIdentificacion_Activas (ref string MsjError)
        {
            List<TipoIdenti> resultado = new List<TipoIdenti>();
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);
            obj_BD_DAL.sNombreTabla = "tbl_TipoIdentificacion";
            obj_BD_DAL.sSentencia = "SCH_MANTENIMIENTO.sp_Listar_TipoIdentificacion";
            obj_BD_BLL.Ejec_DataAdapter(ref obj_BD_DAL);
            if (obj_BD_DAL.sMsjError != string.Empty)
            {
                MsjError = obj_BD_DAL.sMsjError;
            }
            else
            {
                for (int i = 0; i <= obj_BD_DAL.DS.Tables[0].Rows.Count - 1; i++)
                {
                    TipoIdenti tipoidentificacion = new TipoIdenti();
                    tipoidentificacion.IdTipoIdentificacion = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][0]);
                    tipoidentificacion.TipoIdentificacion = obj_BD_DAL.DS.Tables[0].Rows[i][1].ToString();
                    tipoidentificacion.CodigoTipoIdentificacion = obj_BD_DAL.DS.Tables[0].Rows[i][2].ToString();
                    tipoidentificacion.Estado = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][3]);
                    resultado.Add(tipoidentificacion);
                }


                MsjError = string.Empty;
            }
            return resultado;
        }
    }
}

