using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.SCH_VENTAS;
using BLL.BD;
using DAL.BD;

namespace BLL.MANTENIMIENTO
{
    public class BLRazas
    {
        public List<Razas> consultar_Razas_Activas(ref string MsjError)
        {
            List<Razas> resultado = new List<Razas>();
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);
            obj_BD_DAL.sNombreTabla = "tbl_Razas";
            obj_BD_DAL.sSentencia = "SCH_VENTAS.sp_ConsultarRazas_Activas";
            obj_BD_BLL.Ejec_DataAdapter(ref obj_BD_DAL);
            if (obj_BD_DAL.sMsjError != string.Empty)
            {
                MsjError = obj_BD_DAL.sMsjError;
            }
            else
            {
                for (int i = 0; i <= obj_BD_DAL.DS.Tables[0].Rows.Count - 1; i++)
                {
                    Razas razas = new Razas();
                    razas.IdRaza = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][0]);
                    razas.DesRaza = obj_BD_DAL.DS.Tables[0].Rows[i][1].ToString();
                    razas.IdEspecie = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][2]);
                    razas.Estado = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][3]);
                    resultado.Add(razas);
                }


                MsjError = string.Empty;
            }
            return resultado;
        }

        public List<viewRazas> consultar_Razas(ref string MsjError)
        {
            List<viewRazas> resultado = new List<viewRazas>();
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);
            obj_BD_DAL.sNombreTabla = "tbl_Razas";
            obj_BD_DAL.sSentencia = "SCH_VENTAS.SP_Listar_Razas";
            obj_BD_BLL.Ejec_DataAdapter(ref obj_BD_DAL);
            if (obj_BD_DAL.sMsjError != string.Empty)
            {
                MsjError = obj_BD_DAL.sMsjError;
            }
            else
            {
                for (int i = 0; i <= obj_BD_DAL.DS.Tables[0].Rows.Count - 1; i++)
                {
                    viewRazas razas = new viewRazas();
                    razas.IdRaza = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][0]);
                    razas.DesRaza = obj_BD_DAL.DS.Tables[0].Rows[i][1].ToString();
                    razas.Estado = obj_BD_DAL.DS.Tables[0].Rows[i][2].ToString();

                    resultado.Add(razas);
                }


                MsjError = string.Empty;
            }
            return resultado;
        }

        public void Insertar_Raza(Razas razas, ref string error)
        {
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.dt_Parametros.Rows.Add("@desRaza", 1, razas.DesRaza);
            obj_BD_DAL.dt_Parametros.Rows.Add("@IdEspecie", 2, razas.IdEspecie);
            obj_BD_DAL.dt_Parametros.Rows.Add("@IdEstado", 2, razas.Estado);
            obj_BD_DAL.sNombreTabla = "tbl_Razas";
            obj_BD_DAL.sSentencia = "SCH_VENTAS.sp_InsertarRaza";
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

        public void Modificar_Raza(Razas razas, ref string error)
        {
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.dt_Parametros.Rows.Add("@IdRaza", 2, razas.IdRaza);
            obj_BD_DAL.dt_Parametros.Rows.Add("@DesRaza", 1, razas.DesRaza);
            obj_BD_DAL.dt_Parametros.Rows.Add("@IdEspecie", 2, razas.IdEspecie);
            obj_BD_DAL.dt_Parametros.Rows.Add("@IdEstado", 2, razas.Estado);
            obj_BD_DAL.sNombreTabla = "tbl_Razas";
            obj_BD_DAL.sSentencia = "SCH_vENTAS.sp_ModificarRaza";
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

        public Razas consultar_Raza_Id(int idRaza, ref string error)
        {
            Razas resultado = null;
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.dt_Parametros.Rows.Add("@@IDRAZA", 2, idRaza);
            obj_BD_DAL.sNombreTabla = "tbl_Razas";
            obj_BD_DAL.sSentencia = "SCH_VENTAS.SP_SELECT_RAZA";
            obj_BD_BLL.Ejec_DataAdapter(ref obj_BD_DAL);
            if (obj_BD_DAL.sMsjError != string.Empty)
            {
                error = obj_BD_DAL.sMsjError;
            }
            else
            {
                resultado = new Razas();
                resultado.IdRaza = idRaza;
                resultado.DesRaza = obj_BD_DAL.DS.Tables[0].Rows[0][0].ToString();
                resultado.IdEspecie = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[0][1]);
                resultado.Estado = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[0][2]);

                error = string.Empty;
            }
            return resultado;
        }
    }
}
