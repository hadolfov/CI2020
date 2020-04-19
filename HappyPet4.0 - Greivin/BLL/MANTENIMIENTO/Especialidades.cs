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
    public class BLEspecialidades
    {
        public List<Especialidad> consultar_Especialidades_Activas(ref string MsjError)
        {
            List<Especialidad> resultado = new List<Especialidad>();
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);
            obj_BD_DAL.sNombreTabla = "tbl_Especialidades";
            obj_BD_DAL.sSentencia = "SCH_MANTENIMIENTO.sp_ConsultarEspecialidades_Activas";
            obj_BD_BLL.Ejec_DataAdapter(ref obj_BD_DAL);
            if (obj_BD_DAL.sMsjError != string.Empty)
            {
                MsjError = obj_BD_DAL.sMsjError;
            }
            else
            {
                for (int i = 0; i <= obj_BD_DAL.DS.Tables[0].Rows.Count - 1; i++)
                {
                    Especialidad especialidad = new Especialidad();
                    especialidad.IdEspecialidad = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][0]);
                    especialidad.DesEspecialidad  = obj_BD_DAL.DS.Tables[0].Rows[i][1].ToString();
                    especialidad.Estado = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][2]);
                    resultado.Add(especialidad);
                }


                MsjError = string.Empty;
            }
            return resultado;
        }
    }
}
