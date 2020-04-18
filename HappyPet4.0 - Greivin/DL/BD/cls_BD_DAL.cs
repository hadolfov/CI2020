using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL.BD
{
    public class cls_BD_DAL
    {
        private SqlDataAdapter _sql_DA;
        private DataSet _DS;
        private SqlConnection _sql_CNX;
        private SqlCommand _sql_CMD;

        private string _sConexion;
        private string _sMsjError;
        private string _sSentencia, _sNombreTabla;

        private DataTable _dt_Parametros;

        public DataTable dt_Parametros
        {
            get
            {
                return _dt_Parametros;
            }

            set
            {
                _dt_Parametros = value;
            }
        }


        public string sConexion
        {
            get
            {
                return _sConexion;
            }

            set
            {
                _sConexion = value;
            }
        }

        public SqlConnection sql_CNX
        {
            get
            {
                return _sql_CNX;
            }

            set
            {
                _sql_CNX = value;
            }
        }

        public string sMsjError
        {
            get
            {
                return _sMsjError;
            }

            set
            {
                _sMsjError = value;
            }
        }

        public string sSentencia
        {
            get
            {
                return _sSentencia;
            }

            set
            {
                _sSentencia = value;
            }
        }


        public string sNombreTabla
        {
            get
            {
                return _sNombreTabla;
            }

            set
            {
                _sNombreTabla = value;
            }
        }

        public SqlDataAdapter sql_DA
        {
            get
            {
                return _sql_DA;
            }

            set
            {
                _sql_DA = value;
            }
        }

        public DataSet DS
        {
            get
            {
                return _DS;
            }

            set
            {
                _DS = value;
            }
        }

        public SqlCommand Sql_CMD
        {
            get
            {
                return _sql_CMD;
            }

            set
            {
                _sql_CMD = value;
            }
        }

        public string sValorScalar { get; set; }
    }
}
