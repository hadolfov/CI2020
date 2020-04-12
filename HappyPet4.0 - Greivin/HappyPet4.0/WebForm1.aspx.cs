using System;
using BLL.MANTENIMIENTO;
using DL.SCH_SEGURIDAD;

namespace HappyPet4._0
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuariosSeguridad usuariosSeguridad = (UsuariosSeguridad)Session["UsuarioSeguridad"];
        }
    }
}