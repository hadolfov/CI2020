using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.SCH_SEGURIDAD;
using BLL.MANTENIMIENTO;
using DL.SCH_SEGURIDAD;

namespace HappyPet4._0.Seguridad
{
    public partial class frm_Permisos_Seguridad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPermisos();
                CargarGrid();
                btnEditar.Visible = false;
                gvTipoPerfil.SelectedIndex = -1;
            }
        }

        private void CargarGrid()
        {
            string error = "";
            BLTipoPerfil tipoPerfil = new BLTipoPerfil();
            gvTipoPerfil.DataSource = tipoPerfil.consultar_TipoPerfil(ref error);
            gvTipoPerfil.DataBind();
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
                SubModulo subModulo = modulo.SubModulos.First(x => x.IdSubModulo == (int)Constantes.SubModulosSeguridad.PermisosSeguridad);
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

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            EditarTipoPerfil();
        }

        private void EditarTipoPerfil()
        {
            string error = "";
            BLTipoPerfil bLTipoPerfil = new BLTipoPerfil();
            TiposPerfil tipo = bLTipoPerfil.consultar_TipoPerfil_Id(Convert.ToInt32(txtIdTipoPerfil.Text), ref error);

            if (error == "")
            {
                lblTipoPerfil.Text = tipo.TipoPerfil;
                

                lblModalTitle.Text = "Editar Tipo de Perfil";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalTipoPerfil", "$('#ModalTipoPerfil').modal();", true);
                upModal.Update();
            }
            else
            {
                MostrarMensaje(error);
            }
        }

        protected void gvTipoPerfil_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar" && IsPostBack)
            {
                int index = Convert.ToInt32(e.CommandArgument);
                if (gvTipoPerfil.SelectedIndex == index)
                {
                    gvTipoPerfil.SelectedIndex = -1;
                    btnEditar.Visible = false;
                    txtIdTipoPerfil.Text = "";
                }
                else
                {
                    gvTipoPerfil.SelectedIndex = index;
                    Permiso permiso = (Permiso)Session["PermisoPagina"];
                    if (permiso.Modificar)
                    {
                        btnEditar.Visible = true;
                    }

                    txtIdTipoPerfil.Text = gvTipoPerfil.SelectedRow.Cells[1].Text;
                }


            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblConfirmarTitle.Text = "Guardar Permisos de Seguridad";
            lblConfirmarbody.Text = "Desea Guardar el Tipo de Perfil " + lblTipoPerfil.Text + "?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalConfirmar", "$('#ModalConfirmar').modal();", true);
            UpdatePanelConfirmar.Update();
        }

        private void GuardarTipoPerfil()
        {
            string error = "";
            if (true)
            {
                BLTipoPerfil BLtipoPerfil = new BLTipoPerfil();
                TiposPerfil tiposPerfil = new TiposPerfil();

                //tiposPerfil.Estado = chkEstado.Checked ? 1 : 2;
                //tiposPerfil.TipoPerfil = txtTipoPerfil.Text;
                //tiposPerfil.IdSucursal = Convert.ToInt32(ddlSucursales.SelectedValue);
                //tiposPerfil.IdEspecialidad = Convert.ToInt32(ddlEspecialidades.SelectedValue);

                if (txtIdTipoPerfil.Text == "")
                {
                    BLtipoPerfil.Insertar_TipoPerfil(tiposPerfil, ref error);
                }
                else
                {
                    tiposPerfil.IdTipoPerfil = Convert.ToInt32(txtIdTipoPerfil.Text);
                    BLtipoPerfil.Modificar_TipoPerfil(tiposPerfil, ref error);
                }

                if (error == "")
                {
                    Response.Redirect("frm_Tipos_Perfil.aspx");

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