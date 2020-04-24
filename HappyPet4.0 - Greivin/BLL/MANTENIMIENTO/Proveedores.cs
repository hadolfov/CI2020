using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.SCH_INVENTARIO;
using BLL.BD;
using DAL.BD;

namespace BLL.MANTENIMIENTO
{
    public class blProveedores
    {
        public List<viewProveedor> consultar_Proveedor(ref string MsjError)
        {
            List<viewProveedor> resultado = new List<viewProveedor>();
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);
            obj_BD_DAL.sNombreTabla = "tbl_proveedor";
            obj_BD_DAL.sSentencia = "SCH_INVENTARIO.SP_Listar_Proveedor";
            obj_BD_BLL.Ejec_DataAdapter(ref obj_BD_DAL);
            if (obj_BD_DAL.sMsjError != string.Empty)
            {
                MsjError = obj_BD_DAL.sMsjError;
            }
            else
            {
                for (int i = 0; i <= obj_BD_DAL.DS.Tables[0].Rows.Count - 1; i++)
                {
                    viewProveedor vProveedor = new viewProveedor();
                    vProveedor.IdTipoIdentificacion = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][0].ToString());
                    vProveedor.Identificacion = obj_BD_DAL.DS.Tables[0].Rows[i][1].ToString();
                    vProveedor.Estado = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][2].ToString());
                    vProveedor.Nombre = obj_BD_DAL.DS.Tables[0].Rows[i][3].ToString();
                    vProveedor.Apellido1 = obj_BD_DAL.DS.Tables[0].Rows[i][4].ToString();
                    vProveedor.Apellido2 = obj_BD_DAL.DS.Tables[0].Rows[i][5].ToString();
                    vProveedor.Email = obj_BD_DAL.DS.Tables[0].Rows[i][6].ToString();
                    vProveedor.Telefono1 = obj_BD_DAL.DS.Tables[0].Rows[i][7].ToString();
                    vProveedor.Telefono2 = obj_BD_DAL.DS.Tables[0].Rows[i][8].ToString();
                   

                    resultado.Add(vProveedor);
                }


                MsjError = string.Empty;
            }
            return resultado;
        }

        public void Insertar_Proveedor(Proveedor tProveedor, ref string error)
        {
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.dt_Parametros.Rows.Add("@@TIPODENTIFICACION", 2, tProveedor.IdTipoIdentificacion);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@IDentificacion", 1, tProveedor.Identificacion);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@NOMBRE", 1, tProveedor.Nombre);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@APELLIDO", 1, tProveedor.Apellido1);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@APELLIDO2", 1, tProveedor.Apellido2);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@EMAIL", 1, tProveedor.Email);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@TELEFONO1", 1, tProveedor.Telefono1);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@TELEFONO2", 1, tProveedor.Telefono2);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@IDESTADO", 2, tProveedor.Estado);

            obj_BD_DAL.sNombreTabla = "tbl_proveedor";
            obj_BD_DAL.sSentencia = "SCH_INVENTARIO.SP_Inserta_Proveedor";
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

        public void Modificar_Proveedor(Proveedor mProveedor, ref string error)
        {
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.dt_Parametros.Rows.Add("@@TIPODENTIFICACION", 2, mProveedor.IdTipoIdentificacion);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@IDentificacion", 1, mProveedor.Identificacion);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@NOMBRE", 1, mProveedor.Nombre);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@APELLIDO", 1, mProveedor.Apellido1);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@APELLIDO2", 1, mProveedor.Apellido2);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@EMAIL", 1, mProveedor.Email);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@TELEFONO1", 1, mProveedor.Telefono1);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@TELEFONO2", 1, mProveedor.Telefono2);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@IDESTADO", 2, mProveedor.Estado); ;
            obj_BD_DAL.sNombreTabla = "tbl_TiposPerfil";
            obj_BD_DAL.sSentencia = "SCH_INVENTARIO.SP_Modifica_Proveedor";
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

        public Proveedor consultar_Proveedor_Id(int idProveedor, ref string error)
        {
            Proveedor resultado = null;
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.dt_Parametros.Rows.Add("@@IDPROVEEDOR", 2, idProveedor);
            obj_BD_DAL.sNombreTabla = "tbl_proveedor";
            obj_BD_DAL.sSentencia = "SCH_INVENTARIO.SP_SELECT_Proveedor";
            obj_BD_BLL.Ejec_DataAdapter(ref obj_BD_DAL);
            if (obj_BD_DAL.sMsjError != string.Empty)
            {
                error = obj_BD_DAL.sMsjError;
            }
            else
            {
                resultado = new Proveedor();
                resultado.IdTipoIdentificacion = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[0][0].ToString());
                resultado.Identificacion = obj_BD_DAL.DS.Tables[0].Rows[0][1].ToString();
                resultado.Nombre = obj_BD_DAL.DS.Tables[0].Rows[0][2].ToString();
                resultado.Apellido1 = obj_BD_DAL.DS.Tables[0].Rows[0][3].ToString();
                resultado.Apellido2 = obj_BD_DAL.DS.Tables[0].Rows[0][4].ToString();
                resultado.Email = obj_BD_DAL.DS.Tables[0].Rows[0][5].ToString();
                resultado.Telefono1 = obj_BD_DAL.DS.Tables[0].Rows[0][6].ToString();
                resultado.Telefono2 = obj_BD_DAL.DS.Tables[0].Rows[0][7].ToString();
                resultado.Estado = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[0][8].ToString());
                resultado.IdProveedor = idProveedor;

                error = string.Empty;
            }
            return resultado;
        }

        //public List<TiposPerfil> consultar_TipoPerfil_Activos_Sucursal(int idSucursal, ref string error)
        //{
        //    List<TiposPerfil> resultado = new List<TiposPerfil>();
        //    cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
        //    cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

        //    obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);
        //    obj_BD_DAL.dt_Parametros.Rows.Add("@@IDSUCURSAL", 2, idSucursal);
        //    obj_BD_DAL.sNombreTabla = "tbl_Sucursales";
        //    obj_BD_DAL.sSentencia = "SCH_MANTENIMIENTO.sp_ConsultarTipoPerfil_Activos_Sucursal";
        //    obj_BD_BLL.Ejec_DataAdapter(ref obj_BD_DAL);
        //    if (obj_BD_DAL.sMsjError != string.Empty)
        //    {
        //        error = obj_BD_DAL.sMsjError;
        //    }
        //    else
        //    {
        //        for (int i = 0; i <= obj_BD_DAL.DS.Tables[0].Rows.Count - 1; i++)
        //        {
        //            Proveedor vProveedor = new Proveedor();
        //            vProveedor.IdTipoIdentificacion = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][0].ToString());
        //            vProveedor.Identificacion = obj_BD_DAL.DS.Tables[0].Rows[i][1].ToString();
        //            vProveedor.Nombre = obj_BD_DAL.DS.Tables[0].Rows[i][2].ToString();
        //            vProveedor.Apellido1 = obj_BD_DAL.DS.Tables[0].Rows[i][3].ToString();
        //            vProveedor.Apellido2 = obj_BD_DAL.DS.Tables[0].Rows[i][4].ToString();
        //            vProveedor.Email = obj_BD_DAL.DS.Tables[0].Rows[i][5].ToString();
        //            vProveedor.Telefono1 = obj_BD_DAL.DS.Tables[0].Rows[i][6].ToString();
        //            vProveedor.Telefono2 = obj_BD_DAL.DS.Tables[0].Rows[i][7].ToString();
        //            vProveedor.Estado = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][8].ToString());
        //            resultado.Add(vProveedor);
        //        }


        //        error = string.Empty;
        //    }
        //    return resultado;
        //}
    }
}