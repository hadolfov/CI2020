using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.SCH_SEGURIDAD;
using BLL.MANTENIMIENTO;
using DL.SCH_SEGURIDAD;
using DL.SCH_MANTENIMIENTO;
using DL.SCH_VENTAS;

namespace HappyPet4._0.Ventas
{
    public partial class Raza : System.Web.UI.Page
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
                gvRazas.SelectedIndex = -1;
            }
        }

        private void CargarCombos()
        {
            string error = "";
            ListItem i;

            BLEspecies razas = new BLEspecies();
            ddlIdEspecie.DataTextField = "DesEspecie";
            ddlIdEspecie.DataValueField = "IdEspecie";
            ddlIdEspecie.DataSource = razas.consultar_Especies_Activas(ref error);
            ddlIdEspecie.DataBind();

            i = new ListItem("Seleccione una Especie", "0");
            ddlIdEspecie.Items.Insert(0, i);
            //ddlSucursales.Items.Insert(0, "Seleccione una Sucursal");
        }

        private void CargarGrid()
        {
            string error = "";
            BLRazas razas = new BLRazas();
            gvRazas.DataSource = razas.consultar_Razas(ref error);
            gvRazas.DataBind();
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
            txtIdRaza.Text = "";
            txtNombre.Text = "";
            ddlIdEspecie.SelectedValue = "0";
            chkEstado.Checked = true;

            lblModalTitle.Text = "Agregar Raza";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalRaza", "$('#ModalRaza').modal();", true);
            upModal.Update();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            EditarRaza();
        }

        private void EditarRaza()
        {
            string error = "";
            BLRazas bLRazas = new BLRazas();
            Razas razas = bLRazas.consultar_Raza_Id(Convert.ToInt32(txtIdRaza.Text), ref error);

            if (error == "")
            {
                txtNombre.Text = razas.DesRaza;
                ddlIdEspecie.SelectedValue = razas.IdEspecie.ToString();
                chkEstado.Checked = razas.Estado == 1;

                lblModalTitle.Text = "Editar Raza";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalRaza", "$('#ModalRaza').modal();", true);
                upModal.Update();
            }
            else
            {
                MostrarMensaje(error);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            lblEliminarTitle.Text = "Eliminar Raza";
            lblEliminarbody.Text = "Desea Eliminar la Raza " + txtIdRaza.Text + "?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEliminar", "$('#ModalEliminar').modal();", true);
            UpdatePanelEliminar.Update();
        }

        protected void gvRazas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar" && IsPostBack)
            {
                int index = Convert.ToInt32(e.CommandArgument);
                if (gvRazas.SelectedIndex == index)
                {
                    gvRazas.SelectedIndex = -1;
                    btnEditar.Visible = false;
                    btnEliminar.Visible = false;
                    txtIdRaza.Text = "";
                }
                else
                {
                    gvRazas.SelectedIndex = index;
                    Permiso permiso = (Permiso)Session["PermisoPagina"];
                    if (permiso.Modificar)
                    {
                        btnEditar.Visible = true;
                    }
                    if (permiso.Eliminar)
                    {
                        btnEliminar.Visible = true;
                    }

                    txtIdRaza.Text = gvRazas.SelectedRow.Cells[1].Text;
                }


            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblConfirmarTitle.Text = "Guardar Raza";
            lblConfirmarbody.Text = "Desea Guardar la Raza " + txtNombre.Text + "?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalConfirmar", "$('#ModalConfirmar').modal();", true);
            UpdatePanelConfirmar.Update();
        }

        private void GuardarRaza()
        {
            string error = "";
            if (ValidarCampos())
            {
                BLRazas bLRazas = new BLRazas();
                Razas razas = new Razas();

                razas.Estado = chkEstado.Checked ? 1 : 2;
                razas.DesRaza = txtNombre.Text;
                razas.IdEspecie = Convert.ToInt32(ddlIdEspecie.SelectedValue);


                if (txtIdRaza.Text == "")
                {
                    bLRazas.Insertar_Raza(razas, ref error);
                }
                else
                {
                    razas.IdRaza = Convert.ToInt32(txtIdRaza.Text);
                    bLRazas.Modificar_Raza(razas, ref error);
                }

                if (error == "")
                {
                    Response.Redirect("Raza.aspx");

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
                && Convert.ToInt32(ddlIdEspecie.SelectedValue) > 0)
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
            EliminarRaza();
        }

        private void EliminarRaza()
        {
            string error = "";
            BLRazas blRazas = new BLRazas();
            Razas razas = blRazas.consultar_Raza_Id(Convert.ToInt32(txtIdRaza.Text), ref error);
            if (error == "")
            {
                razas.Estado = 3;
                blRazas.Modificar_Raza(razas, ref error);
                if (error == "")
                {
                    Response.Redirect("Raza.aspx");
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
            GuardarRaza();
        }
    }
}
