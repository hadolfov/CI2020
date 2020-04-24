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
        public List<Especialidades> consultar_Especialidades_Activas(ref string MsjError)
        {
            List<Especialidades> resultado = new List<Especialidades>();
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
                    Especialidades especialidad = new Especialidades();
                    especialidad.IdEspecialidad = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][0]);
                    especialidad.DesEspecialidad  = obj_BD_DAL.DS.Tables[0].Rows[i][1].ToString();
                    especialidad.Idsurcursal = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][2].ToString());
                    especialidad.Estado = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][3]);
                    resultado.Add(especialidad);
                }


                MsjError = string.Empty;
            }
            return resultado;
        }

        public List<viewEspecialidades> consultar_Especialidad(ref string MsjError)
        {
            List<viewEspecialidades> resultado = new List<viewEspecialidades>();
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);
            obj_BD_DAL.sNombreTabla = "tbl.Especialidad";
            obj_BD_DAL.sSentencia = "SCH_MANTENIMIENTO.SP_Listar_Especialidades";
            obj_BD_BLL.Ejec_DataAdapter(ref obj_BD_DAL);
            if (obj_BD_DAL.sMsjError != string.Empty)
            {
                MsjError = obj_BD_DAL.sMsjError;
            }
            else
            {
                for (int i = 0; i <= obj_BD_DAL.DS.Tables[0].Rows.Count - 1; i++)
                {
                    viewEspecialidades especialidades = new viewEspecialidades();
                    especialidades.IdEspecialidad = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][0]);
                    especialidades.DesEspecialidad = obj_BD_DAL.DS.Tables[0].Rows[i][1].ToString();
                    especialidades.IdSucursal = obj_BD_DAL.DS.Tables[0].Rows[i][2].ToString();
                    especialidades.Estado = obj_BD_DAL.DS.Tables[0].Rows[i][3].ToString();

                    resultado.Add(especialidades);
                }


                MsjError = string.Empty;
            }
            return resultado;
        }

        public void Insertar_Especialidad(Especialidades especialidad, ref string error)
        {
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.dt_Parametros.Rows.Add("@@DesEspecialidad", 1, especialidad.DesEspecialidad);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@IdSucursal", 2, especialidad.Idsurcursal);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@IdEstado", 2, especialidad.Estado);
            obj_BD_DAL.sNombreTabla = "tbl_Especialidad";
            obj_BD_DAL.sSentencia = "SCH_MANTENIMIENTO.sp_InsertarEspecialidad";
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

        public void Modificar_Especialidad(Especialidades especialidad, ref string error)
        {
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.dt_Parametros.Rows.Add("@@IdEspecialidad", 2, especialidad.Idsurcursal);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@desEspecialidad", 1, especialidad.DesEspecialidad);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@IdSucursal", 2, especialidad.Idsurcursal);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@IdEstado", 2, especialidad.Estado);
            obj_BD_DAL.sNombreTabla = "tbl_Especialidad";
            obj_BD_DAL.sSentencia = "SCH_MANTENIMIENTO.sp_ModificarEspecialidad";
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

        public Especialidades consultar_Especialidad_Id(int idEspecialidad, ref string error)
        {
            Especialidades resultado = null;
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.dt_Parametros.Rows.Add("@@IDESPECIALIDAD", 2, idEspecialidad);
            obj_BD_DAL.sNombreTabla = "tbl_Especialidad";
            obj_BD_DAL.sSentencia = "SCH_MANTENIMIENTO.SP_SELECT_ESPECIALIDAD";
            obj_BD_BLL.Ejec_DataAdapter(ref obj_BD_DAL);
            if (obj_BD_DAL.sMsjError != string.Empty)
            {
                error = obj_BD_DAL.sMsjError;
            }
            else
            {
                resultado = new Especialidades();
                resultado.IdEspecialidad = idEspecialidad;
                resultado.DesEspecialidad = obj_BD_DAL.DS.Tables[0].Rows[0][0].ToString();
                resultado.Idsurcursal = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[0][1]);
                resultado.Estado = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[0][2]);

                error = string.Empty;
            }
            return resultado;
        }
    }
}

