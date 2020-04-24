using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.SCH_INVENTARIO;
using DAL.SCH_INVENTARIO;
using BLL.BD;
using DAL.BD;

namespace BLL.MANTENIMIENTO
{
    public class blMotivos
    {
        public List<viewMotivos> consultar_Motivos(ref string MsjError)
        {
            List<viewMotivos> rMotivos = new List<viewMotivos>();
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();
            obj_BD_DAL.sMsjError = "";
            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);
            obj_BD_DAL.sNombreTabla = "tbl_Motivos";
            obj_BD_DAL.sSentencia = "SCH_INVENTARIO.SP_Listar_Motivos";
            obj_BD_BLL.Ejec_DataAdapter(ref obj_BD_DAL);
            if (obj_BD_DAL.sMsjError != string.Empty)
            {
                MsjError = obj_BD_DAL.sMsjError;
            }
            else
            {
                for (int i = 0; i <= obj_BD_DAL.DS.Tables[0].Rows.Count - 1; i++)
                {
                    viewMotivos lMotivos = new viewMotivos();
                    lMotivos.IdMotivo = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][0]);
                    lMotivos.Descripción = obj_BD_DAL.DS.Tables[0].Rows[i][1].ToString();
                    lMotivos.Estado = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][2].ToString());
                   

                    rMotivos.Add(lMotivos);
                }


                MsjError = string.Empty;
            }
            return rMotivos;
        }

        public void Insertar_Motivo(Motivo objMotivos, ref string error)
        {
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            
            obj_BD_DAL.dt_Parametros.Rows.Add("@@Descripcion", 1, objMotivos.Descripción);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@Id_Estado", 2, objMotivos.Estado);
            


            obj_BD_DAL.sNombreTabla = "tbl_Motivos";
            obj_BD_DAL.sSentencia = "SCH_INVENTARIO.SP_Inserta_Motivo";
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

        public void Modificar_Articulo(Motivo objMotivos, ref string error)
        {
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.dt_Parametros.Rows.Add("@@IDMOTIVO", 2, objMotivos.IdMotivo);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@DESCRIPCION", 1, objMotivos.Descripción);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@ID_ESTADO", 2, objMotivos.Estado);



            obj_BD_DAL.sNombreTabla = "tbl_Motivos";
            obj_BD_DAL.sSentencia = "SCH_INVENTARIO.SP_Modifica_Motivo";
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
        
        public Motivo consultar_Motivo_d(int idMotivo, ref string error)
        {
            Motivo resultado = null;
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.dt_Parametros.Rows.Add("@@IDMOTIVO", 2, idMotivo);
            obj_BD_DAL.sNombreTabla = "tbl_Motivo";
            obj_BD_DAL.sSentencia = "SCH_INVENTARIO.SP_SELECT_Motivo";
            obj_BD_BLL.Ejec_DataAdapter(ref obj_BD_DAL);
            if (obj_BD_DAL.sMsjError != string.Empty)
            {
                error = obj_BD_DAL.sMsjError;
            }
            else
            {
                resultado = new Motivo();
                
                resultado.IdMotivo = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[0][0].ToString());
                resultado.Descripción = obj_BD_DAL.DS.Tables[0].Rows[0][1].ToString();
                resultado.Estado = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[0][2]);
                


                error = string.Empty;
            }
            return resultado;
        }
    }
}