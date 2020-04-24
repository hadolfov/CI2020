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
    public partial class Especie : System.Web.UI.Page
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
                //CargarCombos();
                btnEditar.Visible = false;
                btnEliminar.Visible = false;
                gvEspecies.SelectedIndex = -1;
            }
        }
        private void CargarGrid()
        {
            string error = "";
            BLEspecies especies = new BLEspecies();
            gvEspecies.DataSource = especies.consultar_Especies(ref error);
            gvEspecies.DataBind();
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
            txtIdEspecie.Text = "";
            txtNombre.Text = "";
            chkEstado.Checked = true;

            lblModalTitle.Text = "Agregar Especie";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEspecie", "$('#ModalEspecie').modal();", true);
            upModal.Update();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            EditarEspecie();
        }

        private void EditarEspecie()
        {
            string error = "";
            BLEspecies bLEspecies = new BLEspecies();
            Especies especies = bLEspecies.consultar_Especie_Id(Convert.ToInt32(txtIdEspecie.Text), ref error);

            if (error == "")
            {
                txtNombre.Text = especies.DesEspecie;
                chkEstado.Checked = especies.Estado == 1;

                lblModalTitle.Text = "Editar Especie";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEspecie", "$('#ModalEspecie').modal();", true);
                upModal.Update();
            }
            else
            {
                MostrarMensaje(error);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            lblEliminarTitle.Text = "Eliminar Especie";
            lblEliminarbody.Text = "Desea Eliminar la Especie " + txtIdEspecie.Text + "?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEliminar", "$('#ModalEliminar').modal();", true);
            UpdatePanelEliminar.Update();
        }

        protected void gvEspecies_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar" && IsPostBack)
            {
                int index = Convert.ToInt32(e.CommandArgument);
                if (gvEspecies.SelectedIndex == index)
                {
                    gvEspecies.SelectedIndex = -1;
                    btnEditar.Visible = false;
                    btnEliminar.Visible = false;
                    txtIdEspecie.Text = "";
                }
                else
                {
                    gvEspecies.SelectedIndex = index;
                    Permiso permiso = (Permiso)Session["PermisoPagina"];
                    if (permiso.Modificar)
                    {
                        btnEditar.Visible = true;
                    }
                    if (permiso.Eliminar)
                    {
                        btnEliminar.Visible = true;
                    }

                    txtIdEspecie.Text = gvEspecies.SelectedRow.Cells[1].Text;
                }


            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblConfirmarTitle.Text = "Guardar Especie";
            lblConfirmarbody.Text = "Desea Guardar la Especie " + txtNombre.Text + "?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalConfirmar", "$('#ModalConfirmar').modal();", true);
            UpdatePanelConfirmar.Update();
        }

        private void GuardarEspecie()
        {
            string error = "";
            if (ValidarCampos())
            {
                BLEspecies bLEspecies = new BLEspecies();
                Especies especies = new Especies();

                especies.Estado = chkEstado.Checked ? 1 : 2;
                especies.DesEspecie = txtNombre.Text;


                if (txtIdEspecie.Text == "")
                {
                    bLEspecies.Insertar_Especie(especies, ref error);
                }
                else
                {
                    especies.IdEspecie = Convert.ToInt32(txtIdEspecie.Text);
                    bLEspecies.Modificar_Especie(especies, ref error);
                }

                if (error == "")
                {
                    Response.Redirect("Especie.aspx");

                }
                else
                {
                    MostrarMensaje(error);
                }

            }
            else
            {
                MostrarMensaje("Debe completar todos los campos para guardar la Especie");
            }
        }

        private bool ValidarCampos()
        {
            bool valido = true;
            if (!String.IsNullOrEmpty(txtNombre.Text))
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
            EliminarEspecie();
        }

        private void EliminarEspecie()
        {
            string error = "";
            BLEspecies blEspecies = new BLEspecies();
            Especies especies = blEspecies.consultar_Especie_Id(Convert.ToInt32(txtIdEspecie.Text), ref error);
            if (error == "")
            {
                especies.Estado = 3;
                blEspecies.Modificar_Especie(especies, ref error);
                if (error == "")
                {
                    Response.Redirect("Especie.aspx");
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
            GuardarEspecie();
        }
    }
}
