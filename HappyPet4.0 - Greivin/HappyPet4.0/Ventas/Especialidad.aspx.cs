using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.SCH_SEGURIDAD;
using BLL.MANTENIMIENTO;
using DL.SCH_MANTENIMIENTO;


namespace HappyPet4._0.Ventas
{
    public partial class Especialidad : System.Web.UI.Page
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
                gvEspecialidad.SelectedIndex = -1;
            }
        }

        private void CargarCombos()
        {
            string error = "";
            ListItem i;

            BLSucursales sucursales = new BLSucursales();
            ddlSucursal.DataTextField = "NombreSucursal";
            ddlSucursal.DataValueField = "IdSucursal";
            ddlSucursal.DataSource = sucursales.consultar_Sucursales_Activas(ref error);
            ddlSucursal.DataBind();

            i = new ListItem("Seleccione una Sucursal", "0");
            ddlSucursal.Items.Insert(0, i);
            //ddlSucursales.Items.Insert(0, "Seleccione una Sucursal");

        }

        private void CargarGrid()
        {
            string error = "";
            BLEspecialidades especialidades = new BLEspecialidades();
            gvEspecialidad.DataSource = especialidades.consultar_Especialidad(ref error);
            gvEspecialidad.DataBind();
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
            txtIdEspecialidad.Text = "";
            txtEspecialidad.Text = "";
            ddlSucursal.SelectedValue = "0";
            chkEstado.Checked = true;

            lblModalTitle.Text = "Agregar Especialidad";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEspecialidad", "$('#ModalEspecialidad').modal();", true);
            upModal.Update();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            EditarEspecialidad();
        }

        private void EditarEspecialidad()
        {
            string error = "";
            BLEspecialidades bLEspecialidades = new BLEspecialidades();
            Especialidades especialidades = bLEspecialidades.consultar_Especialidad_Id(Convert.ToInt32(txtIdEspecialidad.Text), ref error);

            if (error == "")
            {
                txtEspecialidad.Text = especialidades.DesEspecialidad.ToString();
                ddlSucursal.SelectedValue = especialidades.Idsurcursal.ToString();
                chkEstado.Checked = especialidades.Estado == 1;

                lblModalTitle.Text = "Editar Especialidad";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEspecialidad", "$('#ModalEspecialidad').modal();", true);
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
            lblEliminarbody.Text = "Desea Eliminar Empresa " + txtIdEspecialidad.Text + "?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEliminar", "$('#ModalEliminar').modal();", true);
            UpdatePanelEliminar.Update();
        }

        protected void gvEspecialidad_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar" && IsPostBack)
            {
                int index = Convert.ToInt32(e.CommandArgument);
                if (gvEspecialidad.SelectedIndex == index)
                {
                    gvEspecialidad.SelectedIndex = -1;
                    btnEditar.Visible = false;
                    btnEliminar.Visible = false;
                    txtIdEspecialidad.Text = "";

                }
                else
                {
                    gvEspecialidad.SelectedIndex = index;
                    Permiso permiso = (Permiso)Session["PermisoPagina"];
                    if (permiso.Modificar)
                    {
                        btnEditar.Visible = true;
                    }
                    if (permiso.Eliminar)
                    {
                        btnEliminar.Visible = true;
                    }

                    txtIdEspecialidad.Text = gvEspecialidad.SelectedRow.Cells[1].Text;
                }


            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblConfirmarTitle.Text = "Guardar Especialidad";
            lblConfirmarbody.Text = "Desea Guardar la Especialidad " + txtEspecialidad.Text + "?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalConfirmar", "$('#ModalConfirmar').modal();", true);
            UpdatePanelConfirmar.Update();
        }

        private void GuardarEspecialidad()
        {
            string error = "";
            if (ValidarCampos())
            {
                BLEspecialidades bLEspecialidades = new BLEspecialidades();
                Especialidades especialidades = new Especialidades();

                especialidades.Estado = chkEstado.Checked ? 1 : 2;
                especialidades.DesEspecialidad = txtEspecialidad.Text;
                especialidades.Idsurcursal = Convert.ToInt32(ddlSucursal.SelectedValue);

                if (txtIdEspecialidad.Text == "")
                {
                    bLEspecialidades.Insertar_Especialidad(especialidades, ref error);
                }
                else
                {
                    especialidades.IdEspecialidad = Convert.ToInt32(txtIdEspecialidad.Text);
                    bLEspecialidades.Modificar_Especialidad(especialidades, ref error);
                }

                if (error == "")
                {
                    Response.Redirect("Especialidad.aspx");

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
            if (!String.IsNullOrEmpty(txtEspecialidad.Text)
                && Convert.ToInt32(ddlSucursal.SelectedValue) > 0)
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
            EliminarEspecialidad();
        }

        private void EliminarEspecialidad()
        {
            string error = "";
            BLEspecialidades bLEspecialidades = new BLEspecialidades();
            Especialidades especialidades = bLEspecialidades.consultar_Especialidad_Id(Convert.ToInt32(txtIdEspecialidad.Text), ref error);
            if (error == "")
            {
                especialidades.Estado = 3;
                bLEspecialidades.Modificar_Especialidad(especialidades, ref error);
                if (error == "")
                {
                    Response.Redirect("Especialidad.aspx");
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
            GuardarEspecialidad();
        }

    }
}
