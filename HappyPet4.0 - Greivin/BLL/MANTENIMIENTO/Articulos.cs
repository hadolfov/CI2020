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
    public class BLArticulos
    {
        public List<viewArticulos> consultar_articulos(ref string MsjError)
        {
            List<viewArticulos> resultado = new List<viewArticulos>();
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();
            obj_BD_DAL.sMsjError = "";
            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);
            obj_BD_DAL.sNombreTabla = "tbl_Articulos";
            obj_BD_DAL.sSentencia = "SCH_INVENTARIO.SP_Listar_Articulos";
            obj_BD_BLL.Ejec_DataAdapter(ref obj_BD_DAL);
            if (obj_BD_DAL.sMsjError != string.Empty)
            {
                MsjError = obj_BD_DAL.sMsjError;
            }
            else
            {
                for (int i = 0; i <= obj_BD_DAL.DS.Tables[0].Rows.Count - 1; i++)
                {
                    viewArticulos lArticulos = new viewArticulos();
                    lArticulos.IdArticulo = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][0]);
                    lArticulos.NombreArticulo = obj_BD_DAL.DS.Tables[0].Rows[i][1].ToString();
                    lArticulos.Descripcion = obj_BD_DAL.DS.Tables[0].Rows[i][2].ToString();
                    lArticulos.Servicio = Convert.ToBoolean(obj_BD_DAL.DS.Tables[0].Rows[i][3].ToString());
                    lArticulos.Precio = Convert.ToDouble(obj_BD_DAL.DS.Tables[0].Rows[i][4].ToString());
                    lArticulos.Cantidadstock = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][5].ToString());
                    lArticulos.Cantidadmax = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][6].ToString());
                    lArticulos.Cantidadmin = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][7].ToString());
                    lArticulos.Idestado = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[i][8].ToString());

                    resultado.Add(lArticulos);
                }


                MsjError = string.Empty;
            }
            return resultado;
        }

        public void Insertar_Articulo(Articulo articulos, ref string error)
        {
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.dt_Parametros.Rows.Add("@@NOMBRE_ARTICULO", 1, articulos.NombreArticulo);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@DESCRIPCION", 1, articulos.Descripcion);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@SERVICIO", 3, articulos.Servicio);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@PRECIO", 5, articulos.Precio);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@CANTIDAD_MAX", 2, articulos.CantidadMax);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@CANTIDAD_MIN", 2, articulos.CantidadMin);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@ID_ESTADO", 2, articulos.Estado);


            obj_BD_DAL.sNombreTabla = "tbl_Articulos";
            obj_BD_DAL.sSentencia = "SCH_INVENTARIO.SP_Inserta_Articulo";
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

        public void Modificar_Articulo(Articulo articulos, ref string error)
        {
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.dt_Parametros.Rows.Add("@@NOMBRE_ARTICULO", 1, articulos.NombreArticulo);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@DESCRIPCION", 1, articulos.Descripcion);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@SERVICIO", 3, articulos.Servicio);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@PRECIO", 5, articulos.Precio);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@CANTIDAD_MAX", 2, articulos.CantidadMax);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@CANTIDAD_MIN", 2, articulos.CantidadMin);
            obj_BD_DAL.dt_Parametros.Rows.Add("@@ID_ESTADO", 2, articulos.Estado);
            obj_BD_DAL.sNombreTabla = "tbl_Articulos";
            obj_BD_DAL.sSentencia = "SCH_INVENTARIO.SP_Modificar_Articulo";
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

        public Articulo consultar_Articulos_Id(int idArticulo, ref string error)
        {
            Articulo resultado = null;
            cls_BD_BLL obj_BD_BLL = new cls_BD_BLL();
            cls_BD_DAL obj_BD_DAL = new cls_BD_DAL();

            obj_BD_BLL.CrearDTParametros(ref obj_BD_DAL);

            obj_BD_DAL.dt_Parametros.Rows.Add("@@IDARTICULO", 2, idArticulo);
            obj_BD_DAL.sNombreTabla = "tbl_TiposPerfil";
            obj_BD_DAL.sSentencia = "SCH_INVENTARIO.SP_SELECT_ARTICULO";
            obj_BD_BLL.Ejec_DataAdapter(ref obj_BD_DAL);
            if (obj_BD_DAL.sMsjError != string.Empty)
            {
                error = obj_BD_DAL.sMsjError;
            }
            else
            {
                resultado = new Articulo();
                resultado.IdArticulo = idArticulo;
                resultado.NombreArticulo = obj_BD_DAL.DS.Tables[0].Rows[0][0].ToString();
                resultado.Descripcion = obj_BD_DAL.DS.Tables[0].Rows[0][1].ToString();
                resultado.Servicio = Convert.ToBoolean(obj_BD_DAL.DS.Tables[0].Rows[0][2]);
                resultado.Precio = Convert.ToDouble(obj_BD_DAL.DS.Tables[0].Rows[0][3]);
                resultado.CantidadStock = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[0][4]);
                resultado.CantidadMin = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[0][5]);
                resultado.CantidadMax = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[0][6]);
                resultado.Estado = Convert.ToInt32(obj_BD_DAL.DS.Tables[0].Rows[0][7]);


                error = string.Empty;
            }
            return resultado;
        }
    }
}
