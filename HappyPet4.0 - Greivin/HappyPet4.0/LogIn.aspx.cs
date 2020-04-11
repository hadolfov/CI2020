using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL.MANTENIMIENTO;
using DL.SCH_SEGURIDAD;

namespace HappyPet4._0
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string error = "";
            UsuarioSeguridad usuarioSeguridadBL = new UsuarioSeguridad();

            UsuariosSeguridad usuariosSeguridad = new UsuariosSeguridad();
            usuariosSeguridad.NombreUsuario = txtUsuario.Text;
            usuariosSeguridad.Contrasenna = txtContraseña.Text;
            usuariosSeguridad.IdUsuarioSeguridad = usuarioSeguridadBL.consultar_Usuario_Contrasenna(usuariosSeguridad,ref error);
            if (usuariosSeguridad.IdUsuarioSeguridad > 0)
            {
                Session["Usuario"] = usuarioSeguridadBL.consultar(usuariosSeguridad, ref error);
                Response.Redirect("WebForm1.aspx");
            }
            else
            {
                txtError.Text = error;
            }
        }
    }
}