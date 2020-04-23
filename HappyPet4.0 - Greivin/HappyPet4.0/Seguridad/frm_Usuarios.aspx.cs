using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.SCH_NOMINA;
using BLL.MANTENIMIENTO;
using DL.SCH_SEGURIDAD;

namespace HappyPet4._0.Seguridad
{
    public partial class frm_Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPermisos();
                Permiso permiso = (Permiso)Session["PermisoPagina"];
                if (permiso.Insertar)
                {
                    btnAgregar.Visible = true;
                }
                else
                {
                    btnAgregar.Visible = false;
                }
                CargarGrid();
                CargarCombos();
                btnEditar.Visible = false;
                btnEliminar.Visible = false;
                gvUsuarios.SelectedIndex = -1;
            }
        }

        private void CargarCombos()
        {
            string error = "";
            ListItem i;

            BLSucursales sucursales = new BLSucursales();
            ddlSucursales.DataTextField = "DesSucursal";
            ddlSucursales.DataValueField = "IdSucursal";
            ddlSucursales.DataSource = sucursales.consultar_Sucursales_Activas(ref error);
            ddlSucursales.DataBind();

            i = new ListItem("Seleccione una Sucursal", "0");
            ddlSucursales.Items.Insert(0, i);
        }

        private void CargarGrid()
        {
            string error = "";
            BLUsuarioSeguridad bLUsuario = new BLUsuarioSeguridad();
            gvUsuarios.DataSource = bLUsuario.consultar_usuarios(ref error);
            gvUsuarios.DataBind();
        }

        private void CargarPermisos()
        {
            Permisos_X_Usuarios permisosUsuario = (Permisos_X_Usuarios)Session["PermisosSeguridad"];
            Modulo modulo = permisosUsuario.Modulos.First(x => x.IdModulo == (int)Constantes.Modulos.Seguridad);
            if (modulo == null)
            {
                Response.Redirect("LogIn.aspx");
            }
            else
            {
                SubModulo subModulo = modulo.SubModulos.First(x => x.IdSubModulo == (int)Constantes.SubModulosSeguridad.UsuariosSeguridad);
                if (subModulo == null)
                {
                    Response.Redirect("LogIn.aspx");
                }
                else
                {
                    Session["PermisoPagina"] = subModulo.Permiso;
                }
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            txtIdUsuario.Text = "";
            ddlSucursales.SelectedValue = "0";
            chkEstado.Checked = true;

            lblModalTitle.Text = "Agregar Usuario";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalUsuario", "$('#ModalUsuario').modal();", true);
            upModal.Update();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            EditarTipoPerfil();
        }

        private void EditarTipoPerfil()
        {
            string error = "";
            BLTipoPerfil bLTipoPerfil = new BLTipoPerfil();
            TiposPerfil tipo = bLTipoPerfil.consultar_TipoPerfil_Id(Convert.ToInt32(txtIdUsuario.Text), ref error);

            if (error == "")
            {
                ddlSucursales.SelectedValue = tipo.IdSucursal.ToString();
                chkEstado.Checked = tipo.Estado == 1;

                lblModalTitle.Text = "Editar Tipo de Perfil";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalTipoPerfil", "$('#ModalTipoPerfil').modal();", true);
                upModal.Update();
            }
            else
            {
                MostrarMensaje(error);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            lblEliminarTitle.Text = "Eliminar Usuario";
            lblEliminarbody.Text = "Desea eliminar el usuario identificación: " + txtIdentificacion.Text + "?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEliminar", "$('#ModalEliminar').modal();", true);
            UpdatePanelEliminar.Update();
        }

        protected void gvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar" && IsPostBack)
            {
                int index = Convert.ToInt32(e.CommandArgument);
                if (gvUsuarios.SelectedIndex == index)
                {
                    gvUsuarios.SelectedIndex = -1;
                    btnEditar.Visible = false;
                    btnEliminar.Visible = false;
                    txtIdUsuario.Text = "";
                }
                else
                {
                    gvUsuarios.SelectedIndex = index;
                    Permiso permiso = (Permiso)Session["PermisoPagina"];
                    if (permiso.Modificar)
                    {
                        btnEditar.Visible = true;
                    }
                    if (permiso.Eliminar)
                    {
                        btnEliminar.Visible = true;
                    }

                    txtIdUsuario.Text = gvUsuarios.SelectedRow.Cells[1].Text;
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblConfirmarTitle.Text = "Guardar Usuario";
            lblConfirmarbody.Text = "Desea guardar el usuario identificación " + txtIdentificacion.Text + "?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalConfirmar", "$('#ModalConfirmar').modal();", true);
            UpdatePanelConfirmar.Update();
        }

        private void GuardarTipoPerfil()
        {
            string error = "";
            if (ValidarCampos())
            {
                BLTipoPerfil BLtipoPerfil = new BLTipoPerfil();
                TiposPerfil tiposPerfil = new TiposPerfil();

                tiposPerfil.Estado = chkEstado.Checked ? 1 : 2;
                tiposPerfil.IdSucursal = Convert.ToInt32(ddlSucursales.SelectedValue);

                if (txtIdUsuario.Text == "")
                {
                    BLtipoPerfil.Insertar_TipoPerfil(tiposPerfil, ref error);
                }
                else
                {
                    tiposPerfil.IdTipoPerfil = Convert.ToInt32(txtIdUsuario.Text);
                    BLtipoPerfil.Modificar_TipoPerfil(tiposPerfil, ref error);
                }

                if (error == "")
                {
                    Response.Redirect("frm_Usuarios.aspx");

                }
                else
                {
                    MostrarMensaje(error);
                }

            }
            else
            {
                MostrarMensaje("Debe completar todos los campos para guardar el Tipo de Perfil");
            }
        }

        private bool ValidarCampos()
        {
            bool valido = true;
            if (!String.IsNullOrEmpty(txtIdUsuario.Text)
                && Convert.ToInt32(ddlSucursales.SelectedValue) > 0
                && Convert.ToInt32(ddlTipoPerfil.SelectedValue) > 0)
            {
                valido = true;
            }
            else
            {
                valido = false;
            }
            return valido;
        }

        protected void btnEliminarConfirmacion_Click(object sender, EventArgs e)
        {
            EliminarTipoPerfil();
        }

        private void EliminarTipoPerfil()
        {
            string error = "";
            BLTipoPerfil bLTipoPerfil = new BLTipoPerfil();
            TiposPerfil tipo = bLTipoPerfil.consultar_TipoPerfil_Id(Convert.ToInt32(txtIdUsuario.Text), ref error);
            if (error == "")
            {
                tipo.Estado = 3;
                bLTipoPerfil.Modificar_TipoPerfil(tipo, ref error);
                if (error == "")
                {
                    Response.Redirect("frm_Usuarios.aspx");
                }
                else
                {
                    MostrarMensaje(error);
                }
            }
            else
            {
                MostrarMensaje(error);
            }
        }

        protected void MostrarMensaje(string msj)
        {
            string script = "alert('" + msj + "');";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
        }

        protected void btnGuardarConfirmacion_Click(object sender, EventArgs e)
        {
            GuardarTipoPerfil();
        }
    }
}