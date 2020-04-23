using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SCH_INVENTARIO
{
    public class Motivo
    {
        private int _idMotivo;
        private string _descripción;
        private int _estado;

        public int IdMotivo { get => _idMotivo; set => _idMotivo = value; }
        public string Descripción { get => _descripción; set => _descripción = value; }
        public int Estado { get => _estado; set => _estado = value; }
    }
    public class viewMotivos
    {

        private int _idMotivo;
        private string _descripción;
        private int _estado;

        public int IdMotivo { get => _idMotivo; set => _idMotivo = value; }
        public string Descripción { get => _descripción; set => _descripción = value; }
        public int Estado { get => _estado; set => _estado = value; }
    }
}
