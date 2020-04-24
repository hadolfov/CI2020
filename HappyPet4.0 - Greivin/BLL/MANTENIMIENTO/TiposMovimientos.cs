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
    public class blTiposMovimientos
    {
        public List<viewTipoMovimiento> consultar_TiposMovimientos(ref string MsjError)
        {
            List<viewTipoMovimiento> rTiposMovimientos = new List<viewTipoMovimiento>();
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();
            obj_BD_DAL.sMsjError = "";
            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);
            obj_BD_DAL.sNombreTabla = "tbl_TipoMovimiento";
            obj_BD_DAL.sSentencia = "SCH_INVENTARIO.SP_Listar_TiposMovimientos";
            obj_BD_BLL.Ejec_DataAdapter(ref obj_BD_DAL);
            if (obj_BD_DAL.sMsjError != string.Empty)
            {
                MsjError = obj_BD_DAL.sMsjError;
            }
            else
            {
                for (int i = 0; i <= obj_BD_DAL.DS.Tables[0].Rows.Count - 1; i++)
                {
                    viewTipoMovimiento lTiposMovimientos = new viewTipoMovimiento();
                    lTiposMovimientos.IdTipo = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][0]);
                    lTiposMovimientos.NombreTipo = obj_BD_DAL.DS.Tables[0].Rows[i][1].ToString();
                    lTiposMovimientos.Estado = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][2].ToString());


                    rTiposMovimientos.Add(lTiposMovimientos);
                }


                MsjError = string.Empty;
            }
            return rTiposMovimientos;
        }

        public void Insertar_TipoMovimiento(TipoMovimiento objTiposMovimientos, ref string error)
        {
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);


            obj_BD_DAL.dt_Parametros.Rows.Add("@@NOMBRETIPO", 1, objTiposMovimientos.NombreTipo);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@ID_ESTADO", 2, objTiposMovimientos.Estado);



            obj_BD_DAL.sNombreTabla = "tbl_TiposMovimientos";
            obj_BD_DAL.sSentencia = "SCH_INVENTARIO.SP_Inserta_Tipo_Movimiento";
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

        public void Modificar_TipoMov(TipoMovimiento objTiposMovimientos, ref string error)
        {
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.dt_Parametros.Rows.Add("@@IDTIPOMOVIMIENTO", 2, objTiposMovimientos.IdTipo);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@NOMBRETIPO", 1, objTiposMovimientos.NombreTipo);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@ID_ESTADO", 2, objTiposMovimientos.Estado);



            obj_BD_DAL.sNombreTabla = "tbl_TiposMovimientos";
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

        public TipoMovimiento consultar_Tipo_Movimiento_id(int idTipoMov, ref string error)
        {
            TipoMovimiento resultado = null;
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.dt_Parametros.Rows.Add("@@IDMOTIVO", 2, idTipoMov);
            obj_BD_DAL.sNombreTabla = "tbl_Motivo";
            obj_BD_DAL.sSentencia = "SCH_INVENTARIO.SP_SELECT_TipoMovimiento";
            obj_BD_BLL.Ejec_DataAdapter(ref obj_BD_DAL);
            if (obj_BD_DAL.sMsjError != string.Empty)
            {
                error = obj_BD_DAL.sMsjError;
            }
            else
            {
                resultado = new TipoMovimiento();

                resultado.IdTipo = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[0][0].ToString());
                resultado.NombreTipo = obj_BD_DAL.DS.Tables[0].Rows[0][1].ToString();
                resultado.Estado = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[0][2]);



                error = string.Empty;
            }
            return resultado;
        }
    }
}