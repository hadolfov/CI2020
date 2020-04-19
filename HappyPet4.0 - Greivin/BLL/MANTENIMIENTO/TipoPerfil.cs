using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.SCH_SEGURIDAD;
using BLL.BD;
using DAL.BD;


namespace BLL.MANTENIMIENTO
{
    public class BLTipoPerfil
    {
        public List<viewTiposPerfil> consultar_TipoPerfil( ref string MsjError)
        {
            List<viewTiposPerfil> resultado = new List<viewTiposPerfil>();
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);
            obj_BD_DAL.sNombreTabla = "tbl_TipoPerfil";
            obj_BD_DAL.sSentencia = "SCH_SEGURIDAD.SP_CONSULTAR_TIPOSPERFIL";
            obj_BD_BLL.Ejec_DataAdapter(ref obj_BD_DAL);
            if (obj_BD_DAL.sMsjError != string.Empty)
            {
                MsjError = obj_BD_DAL.sMsjError;
            }
            else
            {
                for (int i = 0; i <= obj_BD_DAL.DS.Tables[0].Rows.Count -1; i++)
                {
                    viewTiposPerfil tipoPerfil = new viewTiposPerfil();
                    tipoPerfil.IdTipoPerfil = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][0]);
                    tipoPerfil.TipoPerfil = obj_BD_DAL.DS.Tables[0].Rows[i][1].ToString();
                    tipoPerfil.Sucursal = obj_BD_DAL.DS.Tables[0].Rows[i][2].ToString();
                    tipoPerfil.Especialidad = obj_BD_DAL.DS.Tables[0].Rows[i][3].ToString();
                    tipoPerfil.Estado = obj_BD_DAL.DS.Tables[0].Rows[i][4].ToString();

                    resultado.Add(tipoPerfil);
                }
                
                
                MsjError = string.Empty;
            }
            return resultado;
        }

        public void Insertar_TipoPerfil(TiposPerfil tiposPerfil, ref string error)
        {
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.dt_Parametros.Rows.Add("@@TIPOPERFIL", 1, tiposPerfil.TipoPerfil);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@IDSUCURSAL", 2, tiposPerfil.IdSucursal);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@IDESPECIALIDAD", 2, tiposPerfil.IdEspecialidad );
            obj_BD_DAL.dt_Parametros.Rows.Add("@@ID_ESTADO", 2, tiposPerfil.Estado);
            obj_BD_DAL.sNombreTabla = "tbl_TiposPerfil";
            obj_BD_DAL.sSentencia = "SCH_SEGURIDAD.SP_Inserta_TIPOSPERFIL";
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

        public void Modificar_TipoPerfil(TiposPerfil tiposPerfil, ref string error)
        {
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.dt_Parametros.Rows.Add("@@IDTIPOPERFIL", 2, tiposPerfil.IdTipoPerfil);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@TIPOPERFIL", 1, tiposPerfil.TipoPerfil);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@IDSUCURSAL", 2, tiposPerfil.IdSucursal);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@IDESPECIALIDAD", 2, tiposPerfil.IdEspecialidad);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@ID_ESTADO", 2, tiposPerfil.Estado);
            obj_BD_DAL.sNombreTabla = "tbl_TiposPerfil";
            obj_BD_DAL.sSentencia = "SCH_SEGURIDAD.SP_MODIFICA_TIPOSPERFIL";
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

        public TiposPerfil consultar_TipoPerfil_Id(int idTipoPerfil, ref string error)
        {
            TiposPerfil resultado = null;
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.dt_Parametros.Rows.Add("@@IDTIPOPERFIL", 2, idTipoPerfil);
            obj_BD_DAL.sNombreTabla = "tbl_TiposPerfil";
            obj_BD_DAL.sSentencia = "SCH_SEGURIDAD.SP_SELECT_TIPOSPERFIL";
            obj_BD_BLL.Ejec_DataAdapter(ref obj_BD_DAL);
            if (obj_BD_DAL.sMsjError != string.Empty)
            {
                error = obj_BD_DAL.sMsjError;
            }
            else
            {
                resultado = new TiposPerfil();
                resultado.IdTipoPerfil = idTipoPerfil;
                resultado.TipoPerfil = obj_BD_DAL.DS.Tables[0].Rows[0][0].ToString();
                resultado.IdSucursal = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[0][1]);
                resultado.IdEspecialidad = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[0][2]);
                resultado.Estado = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[0][3]);

                error = string.Empty;
            }
            return resultado;
        }
    }
}
