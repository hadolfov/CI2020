using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.BD;
using DAL.BD;
using DL.SCH_NOMINA;

namespace BLL.MANTENIMIENTO
{
    public class BLUsuarios
    {
        public Usuarios consultar_IdUsuario(int idUsuario, ref string MsjError)
        {
            Usuarios resultado = null;
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.dt_Parametros.Rows.Add("@Id_Usuario", 2, idUsuario);
            obj_BD_DAL.sNombreTabla = "tbl_Usuarios";
            obj_BD_DAL.sSentencia = "SCH_NOMINA.sp_ConsultarUsuario_IdUSuario";
            obj_BD_BLL.Ejec_DataAdapter(ref obj_BD_DAL);
            if (obj_BD_DAL.sMsjError != string.Empty)
            {
                MsjError = obj_BD_DAL.sMsjError;
            }
            else
            {
                resultado = new Usuarios();
                resultado.IdUsuario = Convert.ToInt32( obj_BD_DAL.DS.Tables[0].Rows[0][0]);
                resultado.Identificacion = obj_BD_DAL.DS.Tables[0].Rows[0][1].ToString();
                resultado.Nombre = obj_BD_DAL.DS.Tables[0].Rows[0][2].ToString();
                resultado.PrimerApellido = obj_BD_DAL.DS.Tables[0].Rows[0][3].ToString();
                resultado.SegundoApellido = obj_BD_DAL.DS.Tables[0].Rows[0][4].ToString();
                resultado.Email = obj_BD_DAL.DS.Tables[0].Rows[0][5].ToString();
                resultado.Telefono1 = obj_BD_DAL.DS.Tables[0].Rows[0][6].ToString();
                resultado.Telefono2 = obj_BD_DAL.DS.Tables[0].Rows[0][7].ToString();
                resultado.IdSucursal = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[0][8]);
                resultado.Estado = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[0][9]);
                MsjError = string.Empty;
            }
            return resultado;
        }
    }
}
