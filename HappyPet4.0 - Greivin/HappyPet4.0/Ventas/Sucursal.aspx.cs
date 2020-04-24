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
    public partial class Sucursal : System.Web.UI.Page
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
                gvSucursales.SelectedIndex = -1;
            }
        }

        private void CargarCombos()
        {
            string error = "";
            ListItem i;

            BLEmpresas empresa = new BLEmpresas();
            ddlIdEmpresa.DataTextField = "Nombre";
            ddlIdEmpresa.DataValueField = "IdEmpresa";
            ddlIdEmpresa.DataSource = empresa.consultar_Empresas_Activas(ref error);
            ddlIdEmpresa.DataBind();

            i = new ListItem("Seleccione una Empresa", "0");
            ddlIdEmpresa.Items.Insert(0, i);
            //ddlSucursales.Items.Insert(0, "Seleccione una Sucursal");
        }

        private void CargarGrid()
        {
            string error = "";
            BLSucursales sucursales = new BLSucursales();
            gvSucursales.DataSource = sucursales.consultar_Sucursales(ref error);
            gvSucursales.DataBind();
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
            txtIdSucursal.Text = "";
            txtNombre.Text = "";
            ddlIdEmpresa.SelectedValue = "0";
            chkEstado.Checked = true;

            lblModalTitle.Text = "Agregar Sucursal";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalSucursal", "$('#ModalSucursal').modal();", true);
            upModal.Update();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            EditarSucursal();
        }

        private void EditarSucursal()
        {
            string error = "";
            BLSucursales bLSucursales = new BLSucursales();
            Sucursales sucursales = bLSucursales.consultar_Sucursal_Id(Convert.ToInt32(txtIdSucursal.Text), ref error);

            if (error == "")
            {
                txtNombre.Text = sucursales.NombreSucursal;
                ddlIdEmpresa.SelectedValue = sucursales.IdEmpresa.ToString();
                chkEstado.Checked = sucursales.Estado == 1;

                lblModalTitle.Text = "Editar Sucursal";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalSucursal", "$('#ModalSucursal').modal();", true);
                upModal.Update();
            }
            else
            {
                MostrarMensaje(error);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            lblEliminarTitle.Text = "Eliminar Sucursal";
            lblEliminarbody.Text = "Desea Eliminar la Sucursal " + txtIdSucursal.Text + "?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEliminar", "$('#ModalEliminar').modal();", true);
            UpdatePanelEliminar.Update();
        }

        protected void gvSucursales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar" && IsPostBack)
            {
                int index = Convert.ToInt32(e.CommandArgument);
                if (gvSucursales.SelectedIndex == index)
                {
                    gvSucursales.SelectedIndex = -1;
                    btnEditar.Visible = false;
                    btnEliminar.Visible = false;
                    txtIdSucursal.Text = "";
                }
                else
                {
                    gvSucursales.SelectedIndex = index;
                    Permiso permiso = (Permiso)Session["PermisoPagina"];
                    if (permiso.Modificar)
                    {
                        btnEditar.Visible = true;
                    }
                    if (permiso.Eliminar)
                    {
                        btnEliminar.Visible = true;
                    }

                    txtIdSucursal.Text = gvSucursales.SelectedRow.Cells[1].Text;
                }


            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblConfirmarTitle.Text = "Guardar Sucursal";
            lblConfirmarbody.Text = "Desea Guardar la Sucursal " + txtNombre.Text + "?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalConfirmar", "$('#ModalConfirmar').modal();", true);
            UpdatePanelConfirmar.Update();
        }

        private void GuardarSucursal()
        {
            string error = "";
            if (ValidarCampos())
            {
                BLSucursales bLSucursales = new BLSucursales();
                Sucursales sucursales = new Sucursales();

                sucursales.Estado = chkEstado.Checked ? 1 : 2;
                sucursales.NombreSucursal = txtNombre.Text;
                sucursales.IdEmpresa = Convert.ToInt32(ddlIdEmpresa.SelectedValue);


                if (txtIdSucursal.Text == "")
                {
                    bLSucursales.Insertar_Sucursal(sucursales, ref error);
                }
                else
                {
                    sucursales.IdSucursal = Convert.ToInt32(txtIdSucursal.Text);
                    bLSucursales.Modificar_Sucursal(sucursales, ref error);
                }

                if (error == "")
                {
                    Response.Redirect("Sucursal.aspx");

                }
                else
                {
                    MostrarMensaje(error);
                }

            }
            else
            {
                MostrarMensaje("Debe completar todos los campos para guardar la Sucursal");
            }
        }

        private bool ValidarCampos()
        {
            bool valido = true;
            if (!String.IsNullOrEmpty(txtNombre.Text)
                && Convert.ToInt32(ddlIdEmpresa.SelectedValue) > 0)
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
            EliminarSucursal();
        }

        private void EliminarSucursal()
        {
            string error = "";
            BLSucursales bLSucursales = new BLSucursales();
            Sucursales tipo = bLSucursales.consultar_Sucursal_Id(Convert.ToInt32(txtIdSucursal.Text), ref error);
            if (error == "")
            {
                tipo.Estado = 3;
                bLSucursales.Modificar_Sucursal(tipo, ref error);
                if (error == "")
                {
                    Response.Redirect("Sucursal.aspx");
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
            GuardarSucursal();
        }
    }
}
