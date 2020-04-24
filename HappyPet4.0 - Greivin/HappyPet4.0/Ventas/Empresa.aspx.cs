using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.SCH_SEGURIDAD;
using BLL.MANTENIMIENTO;
using DL.SCH_SEGURIDAD;
using DL.SCH_MANTENIMIENTO;


namespace HappyPet4._0.Ventas
{
    public partial class Empresa : System.Web.UI.Page
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
                gvEmpresas.SelectedIndex = -1;
            }
        }

        private void CargarCombos()
        {
            string error = "";
            ListItem i;

            BLTipoIdentificacion tipoidentificacion = new BLTipoIdentificacion();
            ddlTipoIdentificacion.DataTextField = "TipoIdentificacion";
            ddlTipoIdentificacion.DataValueField = "IdTipoIdentificacion";
            ddlTipoIdentificacion.DataSource = tipoidentificacion.Consultar_TipoIdentificacion_Activas(ref error);
            ddlTipoIdentificacion.DataBind();

            i = new ListItem("Seleccione un Tipo de Identificacion", "0");
            ddlTipoIdentificacion.Items.Insert(0, i);
            //ddlSucursales.Items.Insert(0, "Seleccione una Sucursal");

        }

        private void CargarGrid()
        {
            string error = "";
            BLEmpresas empresas = new BLEmpresas();
            gvEmpresas.DataSource = empresas.consultar_Empresa(ref error);
            gvEmpresas.DataBind();
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
                SubModulo subModulo = modulo.SubModulos.First(x => x.IdSubModulo == (int)Constantes.SubModulosSeguridad.TiposPerfil);
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
            txtIdEmpresa.Text = "";
            txtCedula.Text = "";
            txtNombre.Text = "";
            ddlTipoIdentificacion.SelectedValue = "0";
            chkEstado.Checked = true;

            lblModalTitle.Text = "Agregar Empresa";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEmpresa", "$('#ModalEmpresa').modal();", true);
            upModal.Update();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            EditarEmpresa();
        }

        private void EditarEmpresa()
        {
            string error = "";
            BLEmpresas bLEmpresa = new BLEmpresas();
            Empresas empresas = bLEmpresa.consultar_Empresa_Id(Convert.ToInt32(txtIdEmpresa.Text), ref error);

            if (error == "")
            {
                txtNombre.Text = empresas.Nombre.ToString();
                txtCedula.Text = empresas.CedulaJuridica.ToString();
                ddlTipoIdentificacion.SelectedValue = empresas.IdTipoIden.ToString();
                chkEstado.Checked = empresas.Estado == 1;

                lblModalTitle.Text = "Editar Empresa";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEmpresa", "$('#ModalEmpresa').modal();", true);
                upModal.Update();
            }
            else
            {
                MostrarMensaje(error);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            lblEliminarTitle.Text = "Eliminar Empresa";
            lblEliminarbody.Text = "Desea Eliminar Empresa " + txtIdEmpresa.Text + "?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEliminar", "$('#ModalEliminar').modal();", true);
            UpdatePanelEliminar.Update();
        }

        protected void gvEmpresas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar" && IsPostBack)
            {
                int index = Convert.ToInt32(e.CommandArgument);
                if (gvEmpresas.SelectedIndex == index)
                {
                    gvEmpresas.SelectedIndex = -1;
                    btnEditar.Visible = false;
                    btnEliminar.Visible = false;
                    txtIdEmpresa.Text = "";

                }
                else
                {
                    gvEmpresas.SelectedIndex = index;
                    Permiso permiso = (Permiso)Session["PermisoPagina"];
                    if (permiso.Modificar)
                    {
                        btnEditar.Visible = true;
                    }
                    if (permiso.Eliminar)
                    {
                        btnEliminar.Visible = true;
                    }

                    txtIdEmpresa.Text = gvEmpresas.SelectedRow.Cells[1].Text;
                }


            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblConfirmarTitle.Text = "Guardar Empresa";
            lblConfirmarbody.Text = "Desea Guardar la empresa " + txtNombre.Text + "?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalConfirmar", "$('#ModalConfirmar').modal();", true);
            UpdatePanelConfirmar.Update();
        }

        private void GuardarEmpresa()
        {
            string error = "";
            if (ValidarCampos())
            {
                BLEmpresas BLempresa = new BLEmpresas();
                Empresas empresa = new Empresas();

                empresa.Estado = chkEstado.Checked ? 1 : 2;
                empresa.Nombre = txtNombre.Text;
                empresa.CedulaJuridica = txtCedula.Text;
                empresa.IdTipoIden = Convert.ToInt32(ddlTipoIdentificacion.SelectedValue);

                if (txtIdEmpresa.Text == "")
                {
                    BLempresa.Insertar_Empresa(empresa, ref error);
                }
                else
                {
                    empresa.IdEmpresa = Convert.ToInt32(txtIdEmpresa.Text);
                    BLempresa.Modificar_Empresa(empresa, ref error);
                }

                if (error == "")
                {
                    Response.Redirect("Empresa.aspx");

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
            if (!String.IsNullOrEmpty(txtCedula.Text)
                && !String.IsNullOrEmpty(txtNombre.Text)
                && Convert.ToInt32(ddlTipoIdentificacion.SelectedValue) > 0)
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
            EliminarEmpresa();
        }

        private void EliminarEmpresa()
        {
            string error = "";
            BLEmpresas blEmpresa = new BLEmpresas();
            Empresas tipo = blEmpresa.consultar_Empresa_Id(Convert.ToInt32(txtIdEmpresa.Text), ref error);
            if (error == "")
            {
                tipo.Estado = 3;
                blEmpresa.Modificar_Empresa(tipo, ref error);
                if (error == "")
                {
                    Response.Redirect("Empresa.aspx");
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
            GuardarEmpresa();
        }

    }
}
