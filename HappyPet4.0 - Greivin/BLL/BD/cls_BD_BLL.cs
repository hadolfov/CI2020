using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DAL.BD;

namespace BLL.BD
{
    public class cls_BD_BLL
    {
        public void CrearDTParametros(ref cls_BD_DAL obj_param)
        {
            obj_param.dt_Parametros = new DataTable("Parametros");

            DataColumn dc_Nombre = new DataColumn("Nombre", typeof(string));
            DataColumn dc_TipoDato = new DataColumn("Tipo", typeof(byte));
            DataColumn dc_Valor = new DataColumn("Valor", typeof(string));

            obj_param.dt_Parametros.Columns.Add(dc_Nombre);
            obj_param.dt_Parametros.Columns.Add(dc_TipoDato);
            obj_param.dt_Parametros.Columns.Add(dc_Valor);
        }

        public void AbrirConexion(ref cls_BD_DAL obj_BD_DAL)
        {
            try
            {

                obj_BD_DAL.sql_CNX.Open();

                obj_BD_DAL.sMsjError = string.Empty;
            }
            catch (Exception ex)
            {
                obj_BD_DAL.sConexion = string.Empty;
                obj_BD_DAL.sql_CNX = null;
                obj_BD_DAL.sMsjError = ex.Message;
            }
        }

        private string desencriptar(string appconexion)
        {
            byte[] desenc = Convert.FromBase64String(appconexion);

            return System.Text.Encoding.Unicode.GetString(desenc);
        }

        public string encriptar(string appconexion)
        {
            byte[] desenc = System.Text.Encoding.Unicode.GetBytes(appconexion);//Convert.FromBase64String(appconexion);

            return Convert.ToBase64String(desenc);
        }

        public void Ejec_DataAdapter(ref cls_BD_DAL obj_BD_DAL)
        {
            try
            {
                traerConexion(ref obj_BD_DAL);

                if (obj_BD_DAL.sql_CNX != null)
                {
                    if (obj_BD_DAL.sql_CNX.State == ConnectionState.Closed)
                    {
                        obj_BD_DAL.sql_CNX.Open();

                        obj_BD_DAL.sql_DA = new SqlDataAdapter(obj_BD_DAL.sSentencia, obj_BD_DAL.sql_CNX);
                        obj_BD_DAL.sql_DA.SelectCommand.CommandType = CommandType.StoredProcedure;

                        if (obj_BD_DAL.dt_Parametros != null)
                        {
                            SqlDbType sqlType = SqlDbType.VarChar;
                            foreach (DataRow dr in obj_BD_DAL.dt_Parametros.Rows)
                            {
                                switch (dr["Tipo"].ToString())
                                {
                                    case "1":
                                        sqlType = SqlDbType.NVarChar;
                                        break;
                                    case "2":
                                        sqlType = SqlDbType.Int;
                                        break;
                                    default:
                                        break;
                                }

                                obj_BD_DAL.sql_DA.SelectCommand.Parameters.Add(dr["Nombre"].ToString(), sqlType).Value = dr["Valor"].ToString();
                            }
                        }

                        obj_BD_DAL.DS = new DataSet();
                        obj_BD_DAL.sql_DA.Fill(obj_BD_DAL.DS, obj_BD_DAL.sNombreTabla);

                    }

                    obj_BD_DAL.sql_CNX.Dispose();
                }

                obj_BD_DAL.sMsjError = string.Empty;
            }
            catch (SqlException ex)
            {
                obj_BD_DAL.sMsjError = ex.Message;
            }
            finally
            {
                if (obj_BD_DAL.sql_CNX != null)
                {
                    if (obj_BD_DAL.sql_CNX.State == ConnectionState.Open)
                    {
                        obj_BD_DAL.sql_CNX.Close();
                    }

                    obj_BD_DAL.sql_CNX.Dispose();
                }
            }
        }

        public void Ejec_DataAdapter_T_Estados(ref cls_BD_DAL obj_BD_DAL)
        {
            try
            {
                traerConexion(ref obj_BD_DAL);

                if (obj_BD_DAL.sql_CNX != null)
                {
                    if (obj_BD_DAL.sql_CNX.State == ConnectionState.Closed)
                    {
                        obj_BD_DAL.sql_CNX.Open();

                        obj_BD_DAL.sSentencia = "dbo.sp_Listar_T_Estados";
                        obj_BD_DAL.sql_DA = new SqlDataAdapter(obj_BD_DAL.sSentencia, obj_BD_DAL.sql_CNX);
                        obj_BD_DAL.sql_DA.SelectCommand.CommandType = CommandType.StoredProcedure;
                        obj_BD_DAL.DS = new DataSet();
                        obj_BD_DAL.sql_DA.Fill(obj_BD_DAL.DS, obj_BD_DAL.sNombreTabla);

                    }

                    obj_BD_DAL.sql_CNX.Dispose();
                }

                obj_BD_DAL.sMsjError = string.Empty;
            }
            catch (SqlException ex)
            {
                obj_BD_DAL.sMsjError = ex.Message;
            }
            finally
            {
                if (obj_BD_DAL.sql_CNX != null)
                {
                    if (obj_BD_DAL.sql_CNX.State == ConnectionState.Open)
                    {
                        obj_BD_DAL.sql_CNX.Close();
                    }

                    obj_BD_DAL.sql_CNX.Dispose();
                }
            }
        }

        private void traerConexion(ref cls_BD_DAL obj_BD_DAL)
        {
            try
            {
                obj_BD_DAL.sConexion = ConfigurationManager.ConnectionStrings["CNX_SQL_AUT"].ToString();
                obj_BD_DAL.sql_CNX = new SqlConnection(obj_BD_DAL.sConexion);

                obj_BD_DAL.sMsjError = string.Empty;
            }
            catch (Exception ex)
            {
                obj_BD_DAL.sMsjError = ex.Message;
                obj_BD_DAL.sConexion = string.Empty;
                obj_BD_DAL.sql_CNX = null;
            }
        }

        public void Ejec_NonQuery(ref cls_BD_DAL obj_BD_DAL)
        {
            try
            {
                traerConexion(ref obj_BD_DAL);

                if (obj_BD_DAL.sql_CNX != null)
                {
                    if (obj_BD_DAL.sql_CNX.State == ConnectionState.Closed)
                    {
                        obj_BD_DAL.sql_CNX.Open();

                        obj_BD_DAL.Sql_CMD = new SqlCommand(obj_BD_DAL.sSentencia, obj_BD_DAL.sql_CNX);
                        obj_BD_DAL.Sql_CMD.CommandType = CommandType.StoredProcedure;

                        if (obj_BD_DAL.dt_Parametros != null)
                        {
                            SqlDbType sqlType = SqlDbType.VarChar;
                            foreach (DataRow dr in obj_BD_DAL.dt_Parametros.Rows)
                            {
                                switch (dr["Tipo"].ToString())
                                {
                                    case "1":
                                        sqlType = SqlDbType.NVarChar;
                                        break;
                                    case "2":
                                        sqlType = SqlDbType.Int;
                                        break;
                                    default:
                                        break;
                                }

                                obj_BD_DAL.Sql_CMD.Parameters.Add(dr["Nombre"].ToString(), sqlType).Value = dr["Valor"].ToString();
                            }
                        }

                        obj_BD_DAL.Sql_CMD.ExecuteNonQuery();
                        //obj_BD_DAL.DS = new DataSet();
                        //obj_BD_DAL.sql_DA.Fill(obj_BD_DAL.DS, obj_BD_DAL.sNombreTabla);

                    }

                    obj_BD_DAL.sql_CNX.Dispose();
                }

                obj_BD_DAL.sMsjError = string.Empty;
            }
            catch (SqlException ex)
            {
                obj_BD_DAL.sMsjError = ex.Message;
            }
            finally
            {
                if (obj_BD_DAL.sql_CNX != null)
                {
                    if (obj_BD_DAL.sql_CNX.State == ConnectionState.Open)
                    {
                        obj_BD_DAL.sql_CNX.Close();
                    }

                    obj_BD_DAL.sql_CNX.Dispose();
                }
            }
        }

        public void Ejec_Scalar(ref cls_BD_DAL obj_BD_DAL)
        {
            try
            {
                obj_BD_DAL.sql_CNX = new SqlConnection(ConfigurationManager.ConnectionStrings["CNX_SQL_AUT"].ToString());

                if (obj_BD_DAL.sql_CNX.State == ConnectionState.Closed)
                {
                    obj_BD_DAL.sql_CNX.Open();
                }

                obj_BD_DAL.Sql_CMD = new SqlCommand(obj_BD_DAL.sSentencia, obj_BD_DAL.sql_CNX);



                if ((obj_BD_DAL.dt_Parametros != null) && (obj_BD_DAL.dt_Parametros.Rows.Count >= 1))
                {
                    SqlDbType DBType = SqlDbType.VarChar;

                    foreach (DataRow DR in obj_BD_DAL.dt_Parametros.Rows)
                    {
                        switch (DR[1].ToString())
                        {
                            case "1":
                                DBType = SqlDbType.NVarChar;
                                break;
                            case "2":
                                DBType = SqlDbType.Int;
                                break;
                            default:
                                break;
                        }

                        obj_BD_DAL.Sql_CMD.Parameters.Add(DR[0].ToString(), DBType).Value = DR[2].ToString();
                    }
                }


                obj_BD_DAL.Sql_CMD.CommandType = CommandType.StoredProcedure;

                obj_BD_DAL.DS = new DataSet();

                obj_BD_DAL.sValorScalar = obj_BD_DAL.Sql_CMD.ExecuteScalar().ToString();

                obj_BD_DAL.sMsjError = string.Empty;
            }
            catch (SqlException ex)
            {
                obj_BD_DAL.sMsjError = ex.Message.ToString();
                obj_BD_DAL.sValorScalar = "-1";
                obj_BD_DAL.DS = new DataSet();
            }
            finally
            {
                if (obj_BD_DAL.sql_CNX != null)
                {
                    if (obj_BD_DAL.sql_CNX.State == ConnectionState.Open)
                    {
                        obj_BD_DAL.sql_CNX.Close();
                    }

                    obj_BD_DAL.sql_CNX.Dispose();
                }
            }
        }

    }
}
