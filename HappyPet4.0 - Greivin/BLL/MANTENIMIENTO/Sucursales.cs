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
                    sucursal.NombreSucursal = obj_BD_DAL.DS.Tables[0].Rows[i][1].ToString();
                    sucursal.IdEmpresa = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][2]);
                    sucursal.Estado = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][3]);
                    resultado.Add(sucursal);
                }


                MsjError = string.Empty;
            }
            return resultado;
        }

        public List<viewSucursales> consultar_Sucursales(ref string MsjError)
        {
            List<viewSucursales> resultado = new List<viewSucursales>();
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);
            obj_BD_DAL.sNombreTabla = "tbl_Sucursales";
            obj_BD_DAL.sSentencia = "SCH_MANTENIMIENTO.SP_Listar_Sucursales";
            obj_BD_BLL.Ejec_DataAdapter(ref obj_BD_DAL);
            if (obj_BD_DAL.sMsjError != string.Empty)
            {
                MsjError = obj_BD_DAL.sMsjError;
            }
            else
            {
                for (int i = 0; i <= obj_BD_DAL.DS.Tables[0].Rows.Count - 1; i++)
                {
                    viewSucursales sucursales = new viewSucursales();
                    sucursales.Idsucursal = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][0]);
                    sucursales.Nombresucursal = obj_BD_DAL.DS.Tables[0].Rows[i][1].ToString();
                    sucursales.Idempresa = obj_BD_DAL.DS.Tables[0].Rows[i][2].ToString();
                    sucursales.Estado = obj_BD_DAL.DS.Tables[0].Rows[i][3].ToString();

                    resultado.Add(sucursales);
                }


                MsjError = string.Empty;
            }
            return resultado;
        }

        public void Insertar_Sucursal(Sucursales sucursales, ref string error)
        {
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.dt_Parametros.Rows.Add("@@NombreSucursal", 1, sucursales.NombreSucursal);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@IdEmpresa", 2, sucursales.IdEmpresa);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@IdEstado", 2, sucursales.Estado);
            obj_BD_DAL.sNombreTabla = "tbl_Sucursales";
            obj_BD_DAL.sSentencia = "SCH_MANTENIMIENTO.sp_InsertarSucursales";
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

        public void Modificar_Sucursal(Sucursales sucursales, ref string error)
        {
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.dt_Parametros.Rows.Add("@@IdSucursal", 2, sucursales.IdSucursal);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@NombreSucursal", 1, sucursales.NombreSucursal);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@IdEmpresa", 2, sucursales.IdEmpresa);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@IdEstado", 2, sucursales.Estado);
            obj_BD_DAL.sNombreTabla = "tbl_Sucursales";
            obj_BD_DAL.sSentencia = "SCH_MANTENIMIENTO.sp_ModificarSucursal";
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

        public Sucursales consultar_Sucursal_Id(int idSucursal, ref string error)
        {
            Sucursales resultado = null;
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.dt_Parametros.Rows.Add("@@IDSUCURSAL", 2, idSucursal);
            obj_BD_DAL.sNombreTabla = "tbl_Sucursales";
            obj_BD_DAL.sSentencia = "SCH_MANTENIMIENTO.SP_SELECT_SUCURSAL";
            obj_BD_BLL.Ejec_DataAdapter(ref obj_BD_DAL);
            if (obj_BD_DAL.sMsjError != string.Empty)
            {
                error = obj_BD_DAL.sMsjError;
            }
            else
            {
                resultado = new Sucursales();
                resultado.IdSucursal = idSucursal;
                resultado.NombreSucursal = obj_BD_DAL.DS.Tables[0].Rows[0][0].ToString();
                resultado.IdEmpresa = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[0][1]);
                resultado.Estado = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[0][2]);

                error = string.Empty;
            }
            return resultado;
        }
    }
}

