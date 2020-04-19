using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DL.SCH_SEGURIDAD;
using DAL.SCH_SEGURIDAD;
using DL.SCH_NOMINA;
using BLL.MANTENIMIENTO;

namespace HappyPet4._0
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string error = "";
                UsuariosSeguridad usuarioSeg = (UsuariosSeguridad)Session["UsuarioSeguridad"];
                BLUsuarios BLUsuarios = new BLUsuarios();
                Usuarios usuarios = BLUsuarios.consultar_IdUsuario(usuarioSeg.IdUsuarioSeguridad, ref error);
                if (error == "")
                {
                    lblUsuario.Text = usuarios.Nombre + " " + usuarios.PrimerApellido + " " + usuarios.SegundoApellido;
                    Permisos_X_Usuarios permisos = (Permisos_X_Usuarios)Session["PermisosSeguridad"];
                    if (permisos == null)
                    {
                        permisos = BLUsuarios.consultar_permisos_x_usuario(usuarioSeg.IdUsuarioSeguridad, ref error);
                        Session["PermisosSeguridad"] = permisos;
                        if (error != "")
                        {
                            Response.Redirect("LogIn.aspx");
                        }
                    }
                }
                else
                {
                    Response.Redirect("LogIn.aspx");
                }
            }
            catch(Exception ex)
            {
                Response.Redirect("LogIn.aspx");
            }
        }

        protected void btnCerrarSesion_Click(object sender, ImageClickEventArgs e)
        {
            Session["UsuarioSeguridad"] = null;
            Session["PermisosSeguridad"] = null;
            Response.Redirect("LogIn.aspx");
        }
    }
}