using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DL.SCH_SEGURIDAD;
using DL.SCH_NOMINA;
using BLL.MANTENIMIENTO;

namespace HappyPet4._0
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string error = "";
            UsuariosSeguridad usuarioSeg = (UsuariosSeguridad)Session["UsuarioSeguridad"];
            BLUsuarios BLUsuarios = new BLUsuarios();
            Usuarios usuarios = BLUsuarios.consultar_IdUsuario(usuarioSeg.IdUsuarioSeguridad, ref error);
            if (error == "")
            {
                lblUsuario.Text = usuarios.Nombre + " " + usuarios.PrimerApellido + " " + usuarios.SegundoApellido;
            }
            else
            {
                Response.Redirect("LogIn.aspx");
            }
        }
    }
}