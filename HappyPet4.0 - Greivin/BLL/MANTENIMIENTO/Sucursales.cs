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
    public class BLSucursales
    {
        public List<Sucursales> consultar_Sucursales_Activas(ref string MsjError)
        {
            List<Sucursales> resultado = new List<Sucursales>();
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);
            obj_BD_DAL.sNombreTabla = "tbl_Sucursales";
            obj_BD_DAL.sSentencia = "SCH_MANTENIMIENTO.sp_ConsultarSucursales_Activas";
            obj_BD_BLL.Ejec_DataAdapter(ref obj_BD_DAL);
            if (obj_BD_DAL.sMsjError != string.Empty)
            {
                MsjError = obj_BD_DAL.sMsjError;
            }
            else
            {
                for (int i = 0; i <= obj_BD_DAL.DS.Tables[0].Rows.Count - 1; i++)
                {
                    Sucursales sucursal = new Sucursales();
                    sucursal.IdSucursal = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][0]);
                    sucursal.DesSucursal = obj_BD_DAL.DS.Tables[0].Rows[i][1].ToString();
                    sucursal.IdEmpresa = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][2]);
                    sucursal.Estado = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][3]);
                    resultado.Add(sucursal);
                }


                MsjError = string.Empty;
            }
            return resultado;
        }
    }
}
