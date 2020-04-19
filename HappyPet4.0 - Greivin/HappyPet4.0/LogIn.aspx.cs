using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.MANTENIMIENTO;
using DL.SCH_SEGURIDAD;

namespace HappyPet4._0
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["UsuarioSeguridad"] = null;
            Session["PermisosSeguridad"] = null;
            Session["PermisoPagina"] = null;
            txtUsuario.Focus();
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string error = "";
            BLUsuarioSeguridad usuarioSeguridadBL = new BLUsuarioSeguridad();

            UsuariosSeguridad usuariosSeguridad = new UsuariosSeguridad();
            usuariosSeguridad.NombreUsuario = txtUsuario.Text;
            usuariosSeguridad.Contrasenna = txtContraseña.Text;
            usuariosSeguridad.IdUsuarioSeguridad = usuarioSeguridadBL.consultar_Usuario_Contrasenna(usuariosSeguridad,ref error);
            if (usuariosSeguridad.IdUsuarioSeguridad > 0)
            {
                Session["UsuarioSeguridad"] = usuarioSeguridadBL.consultar(usuariosSeguridad, ref error);
                Session["PermisosSeguridad"] = null;
                Response.Redirect("WebForm1.aspx");
            }
            else
            {
                txtError.Text = error;
            }
        }
    }
}