using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.SCH_NOMINA;
using BLL.MANTENIMIENTO;
using DL.SCH_NOMINA;


namespace HappyPet4._0
{
    public partial class TipoMarca1__1 : System.Web.UI.Page
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
                gvTipoMarca.SelectedIndex = -1;
            }
        }

       
        private void CargarPermisos()
        {
            Permisos_X_Usuarios permisosUsuario = (Permisos_X_Usuarios)Session["PermisosSeguridad"];
            Modulo modulo = permisosUsuario.Modulos.First(x => x.IdModulo == (int)Constantes.Modulos.Nómina);
            if (modulo == null)
            {
                Response.Redirect("LogIn.aspx");
            }
            else
            {
                SubModulo subModulo = modulo.SubModulos.First(x => x.IdSubModulo == (int)Constantes.SubModulosNomina.TiposMarcas);
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

        private void CargarGrid()
        {
            string error = "";
            BLTipoMarca tipoMarca = new BLTipoMarca();
            gvTipoMarca.DataSource = tipoMarca.consultar_TipoMarca(ref error);
            gvTipoMarca.DataBind();
        }

        //private void CargarCombos()  /*Cargar Combo no se utiliza para esta ventana*/
        //{
        //    string error = "";
        //    ListItem i;

        //    BLSucursales sucursales = new BLSucursales();
        //    ddlSucursales.DataTextField = "DesSucursal";
        //    ddlSucursales.DataValueField = "IdSucursal";
        //    ddlSucursales.DataSource = sucursales.consultar_Sucursales_Activas(ref error);
        //    ddlSucursales.DataBind();

        //    i = new ListItem("Seleccione una Sucursal", "0");
        //    ddlSucursales.Items.Insert(0, i);
        //    //ddlSucursales.Items.Insert(0, "Seleccione una Sucursal");

        //    BLEspecialidades especialidades = new BLEspecialidades();
        //    ddlEspecialidades.DataTextField = "DesEspecialidad";
        //    ddlEspecialidades.DataValueField = "IdEspecialidad";
        //    ddlEspecialidades.DataSource = especialidades.consultar_Especialidades_Activas(ref error);
        //    ddlEspecialidades.DataBind();

        //    i = new ListItem("Seleccione una Especialidad", "0");
        //    ddlEspecialidades.Items.Insert(0, i);
        //    //ddlEspecialidades.Items.Insert(0, "Seleccione una Especialidad");
        //}


        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = "";
            txtProducto.Text = "";
            chkEstado.Checked = true;

            lblModalTitle.Text = "Marcas";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalMarcas", "$('#ModalMarcas').modal();", true);
            upModal.Update();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            EditarTipoMarca();
        }

        private void EditarTipoMarca()
        {
            string error = "";
            BLTipoMarca bLTipoMarca = new BLTipoMarca();
            TiposMarca tipo = bLTipoMarca.consultar_TipoMarca_Id(Convert.ToInt32(txtCodigo.Text), ref error);

            if (error == "")
            {
                txtProducto.Text = tipo.TipoMarca;
                chkEstado.Checked = tipo.Estado == 1;

                lblModalTitle.Text = "Editar Marcas";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalMarcas", "$('#ModalMarcas').modal();", true);
                upModal.Update();
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

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            lblEliminarTitle.Text = "Eliminar Tipo de Perfil";
            lblEliminarbody.Text = "Desea Eliminar el Tipo de Perfil " + txtProducto.Text + "?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEliminar", "$('#ModalEliminar').modal();", true);
            upModal.Update();
        }

        protected void gvTipoMarca_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar" && IsPostBack)
            {
                int index = Convert.ToInt32(e.CommandArgument);
                if (gvTipoMarca.SelectedIndex == index)
                {
                    gvTipoMarca.SelectedIndex = -1;
                    btnEditar.Visible = false;
                    btnEliminar.Visible = false;
                    txtCodigo.Text = "";
                }
                else
                {
                    gvTipoMarca.SelectedIndex = index;
                    Permiso permiso = (Permiso)Session["PermisoPagina"];
                    if (permiso.Modificar)
                    {
                        btnEditar.Visible = true;
                    }
                    if (permiso.Eliminar)
                    {
                        btnEliminar.Visible = true;
                    }
                    txtCodigo.Text = gvTipoMarca.SelectedRow.Cells[1].Text;
                }
                //TableCell contactName = selectedRow.Cells[1];
                //string contact = contactName.Text;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblConfirmarTitle.Text = "Guardar Tipo de Marca";
            lblConfirmarbody.Text = "Desea Guardar el Tipo de Marca " + txtProducto.Text + "?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalConfirmar", "$('#ModalConfirmar').modal();", true);
            UpdatePanelConfirmar.Update();
        }

        private void GuardarTipoMarca()
        {
            string error = "";
            if (ValidarCampos())
            {
                BLTipoMarca BLtipoMarca = new BLTipoMarca();
                TiposMarca tiposMarca = new TiposMarca();

                tiposMarca.Estado = chkEstado.Checked ? 1 : 2;
                tiposMarca.TipoMarca = txtProducto.Text;
                

                if (txtCodigo.Text == "")
                {
                    BLtipoMarca.Insertar_TipoMarca(tiposMarca, ref error);
                }
                else
                {
                    tiposMarca.IdTipoMarca = Convert.ToInt32(txtCodigo.Text);
                    BLtipoMarca.Modificar_TipoMarca(tiposMarca, ref error);
                }

                if (error == "")
                {
                    Response.Redirect("TipoMarca1.1.aspx");

                }
                else
                {
                    MostrarMensaje(error);
                }

            }
            else
            {
                MostrarMensaje("Debe completar todos los campos para guardar el Tipo de Marca");
            }
        }

        private bool ValidarCampos()
        {
            bool valido = true;
            if (!String.IsNullOrEmpty(txtProducto.Text))
                
            {
                valido = true;
            }
            else
            {
                valido = false;
            }
            return valido;
        }

        private void EliminarTipoMarca()
        {
            string error = "";
            BLTipoMarca bLTipoMarca = new BLTipoMarca();
            TiposMarca tipo = bLTipoMarca.consultar_TipoMarca_Id(Convert.ToInt32(txtCodigo.Text), ref error);
            if (error == "")
            {
                tipo.Estado = 3;
                bLTipoMarca.Modificar_TipoMarca(tipo, ref error);
                if (error == "")
                {
                    Response.Redirect("TipoMarca1.1.aspx");
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

        protected void btnGuardarConfirmacion_Click(object sender, EventArgs e)
        {
            GuardarTipoMarca();
        }

        protected void btnEliminarConfirmacion_Click(object sender, EventArgs e)
        {
            EliminarTipoMarca();
        }

       
    }

}