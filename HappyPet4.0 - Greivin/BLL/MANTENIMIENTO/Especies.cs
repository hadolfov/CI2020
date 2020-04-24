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
    public class BLEspecies
    {
        public List<Especies> consultar_Especies_Activas(ref string MsjError)
        {
            List<Especies> resultado = new List<Especies>();
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);
            obj_BD_DAL.sNombreTabla = "tbl_Especies";
            obj_BD_DAL.sSentencia = "SCH_VENTAS.sp_ConsultarEspecies_Activas";
            obj_BD_BLL.Ejec_DataAdapter(ref obj_BD_DAL);
            if (obj_BD_DAL.sMsjError != string.Empty)
            {
                MsjError = obj_BD_DAL.sMsjError;
            }
            else
            {
                for (int i = 0; i <= obj_BD_DAL.DS.Tables[0].Rows.Count - 1; i++)
                {
                    Especies especies = new Especies();
                    especies.IdEspecie = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][0]);
                    especies.DesEspecie = obj_BD_DAL.DS.Tables[0].Rows[i][1].ToString();
                    especies.Estado = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][2]);
                    resultado.Add(especies);
                }


                MsjError = string.Empty;
            }
            return resultado;
        }

        public List<viewEspecies> consultar_Especies(ref string MsjError)
        {
            List<viewEspecies> resultado = new List<viewEspecies>();
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);
            obj_BD_DAL.sNombreTabla = "tbl_Especies";
            obj_BD_DAL.sSentencia = "SCH_VENTAS.SP_Listar_Especies";
            obj_BD_BLL.Ejec_DataAdapter(ref obj_BD_DAL);
            if (obj_BD_DAL.sMsjError != string.Empty)
            {
                MsjError = obj_BD_DAL.sMsjError;
            }
            else
            {
                for (int i = 0; i <= obj_BD_DAL.DS.Tables[0].Rows.Count - 1; i++)
                {
                    viewEspecies especies = new viewEspecies();
                    especies.IdEspecie = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][0]);
                    especies.DesEspecie = obj_BD_DAL.DS.Tables[0].Rows[i][1].ToString();
                    especies.Estado = obj_BD_DAL.DS.Tables[0].Rows[i][2].ToString();

                    resultado.Add(especies);
                }


                MsjError = string.Empty;
            }
            return resultado;
        }

        public void Insertar_Especie(Especies especies, ref string error)
        {
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.dt_Parametros.Rows.Add("@desEspecie", 1, especies.DesEspecie);
            obj_BD_DAL.dt_Parametros.Rows.Add("@IdEstado", 2, especies.Estado);
            obj_BD_DAL.sNombreTabla = "tbl_Sucursales";
            obj_BD_DAL.sSentencia = "SCH_VENTAS.sp_InsertarEspecies";
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

        public void Modificar_Especie(Especies especies, ref string error)
        {
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.dt_Parametros.Rows.Add("@IdEspecie", 2, especies.IdEspecie);
            obj_BD_DAL.dt_Parametros.Rows.Add("@DesEspecie", 1, especies.DesEspecie);
            obj_BD_DAL.dt_Parametros.Rows.Add("@IdEstado", 2, especies.Estado);
            obj_BD_DAL.sNombreTabla = "tbl_Especies";
            obj_BD_DAL.sSentencia = "SCH_VENTAS.sp_ModificarEspecie";
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

        public Especies consultar_Especie_Id(int idEspecie, ref string error)
        {
            Especies resultado = null;
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.dt_Parametros.Rows.Add("@@IDESPECIE", 2, idEspecie);
            obj_BD_DAL.sNombreTabla = "tbl_Especies";
            obj_BD_DAL.sSentencia = "SCH_VENTAS.SP_SELECT_ESPECIE";
            obj_BD_BLL.Ejec_DataAdapter(ref obj_BD_DAL);
            if (obj_BD_DAL.sMsjError != string.Empty)
            {
                error = obj_BD_DAL.sMsjError;
            }
            else
            {
                resultado = new Especies();
                resultado.IdEspecie = idEspecie;
                resultado.DesEspecie = obj_BD_DAL.DS.Tables[0].Rows[0][0].ToString();
                resultado.Estado = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[0][1]);

                error = string.Empty;
            }
            return resultado;
        }
        
    }
}
