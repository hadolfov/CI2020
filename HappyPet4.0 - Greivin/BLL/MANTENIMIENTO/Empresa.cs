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
    public class BLEmpresas
    {
        public List<Empresas> consultar_Empresas_Activas(ref string MsjError)
        {
            List<Empresas> resultado = new List<Empresas>();
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);
            obj_BD_DAL.sNombreTabla = "tbl_Empresas";
            obj_BD_DAL.sSentencia = "SCH_MANTENIMIENTO.sp_ConsultarEmpresas_Activas";
            obj_BD_BLL.Ejec_DataAdapter(ref obj_BD_DAL);
            if (obj_BD_DAL.sMsjError != string.Empty)
            {
                MsjError = obj_BD_DAL.sMsjError;
            }
            else
            {
                for (int i = 0; i <= obj_BD_DAL.DS.Tables[0].Rows.Count - 1; i++)
                {
                    Empresas empresa = new Empresas();
                    empresa.IdEmpresa = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][0]);
                    empresa.Nombre = obj_BD_DAL.DS.Tables[0].Rows[i][1].ToString();
                    empresa.CedulaJuridica = obj_BD_DAL.DS.Tables[0].Rows[i][2].ToString();
                    empresa.IdTipoIden = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][3]);
                    empresa.Estado = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][4]);
                    resultado.Add(empresa);
                }


                MsjError = string.Empty;
            }
            return resultado;
        }

        public List<viewEmpresas> consultar_Empresa(ref string MsjError)
        {
            List<viewEmpresas> resultado = new List<viewEmpresas>();
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);
            obj_BD_DAL.sNombreTabla = "tbl.Empresa";
            obj_BD_DAL.sSentencia = "SCH_MANTENIMIENTO.SP_Listar_Empresas";
            obj_BD_BLL.Ejec_DataAdapter(ref obj_BD_DAL);
            if (obj_BD_DAL.sMsjError != string.Empty)
            {
                MsjError = obj_BD_DAL.sMsjError;
            }
            else
            {
                for (int i = 0; i <= obj_BD_DAL.DS.Tables[0].Rows.Count - 1; i++)
                {
                    viewEmpresas empresa = new viewEmpresas();
                    empresa.IdEmpresa = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][0]);
                    empresa.Nombre = obj_BD_DAL.DS.Tables[0].Rows[i][1].ToString();
                    empresa.Cedulajuridica = obj_BD_DAL.DS.Tables[0].Rows[i][2].ToString();
                    empresa.IdTipoIden = obj_BD_DAL.DS.Tables[0].Rows[i][3].ToString();
                    empresa.Estado = obj_BD_DAL.DS.Tables[0].Rows[i][4].ToString();

                    resultado.Add(empresa);
                }


                MsjError = string.Empty;
            }
            return resultado;
        }

        public void Insertar_Empresa(Empresas empresa, ref string error)
        {
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.dt_Parametros.Rows.Add("@@Nombre", 1, empresa.Nombre);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@CedulaJuridica", 1, empresa.CedulaJuridica);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@IdTipoIdentificacion", 2, empresa.IdTipoIden);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@IdEstado", 2, empresa.Estado);
            obj_BD_DAL.sNombreTabla = "tbl_Empresa";
            obj_BD_DAL.sSentencia = "SCH_MANTENIMIENTO.SP_InsertarEmpresa";
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

        public void Modificar_Empresa(Empresas empresa, ref string error)
        {
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.dt_Parametros.Rows.Add("@@IdEmpresa", 2, empresa.IdEmpresa);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@Nombre", 1, empresa.Nombre);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@CedulaJuridica", 1, empresa.CedulaJuridica);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@IdTipoIdentificacion", 2, empresa.IdTipoIden);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@IdEstado", 2, empresa.Estado);
            obj_BD_DAL.sNombreTabla = "tbl_Empresa";
            obj_BD_DAL.sSentencia = "SCH_MANTENIMIENTO.sp_ModificarEmpresa";
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

        public Empresas consultar_Empresa_Id(int idEmpresa, ref string error)
        {
            Empresas resultado = null;
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.dt_Parametros.Rows.Add("@@IDEMPRESA", 2, idEmpresa);
            obj_BD_DAL.sNombreTabla = "tbl_Empresa";
            obj_BD_DAL.sSentencia = "SCH_MANTENIMIENTO.SP_SELECT_EMPRESA";
            obj_BD_BLL.Ejec_DataAdapter(ref obj_BD_DAL);
            if (obj_BD_DAL.sMsjError != string.Empty)
            {
                error = obj_BD_DAL.sMsjError;
            }
            else
            {
                resultado = new Empresas();
                resultado.IdEmpresa = idEmpresa;
                resultado.Nombre = obj_BD_DAL.DS.Tables[0].Rows[0][0].ToString();
                resultado.CedulaJuridica = obj_BD_DAL.DS.Tables[0].Rows[0][1].ToString();
                resultado.IdTipoIden = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[0][2]);
                resultado.Estado = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[0][3]);

                error = string.Empty;
            }
            return resultado;
        }
    }
}

