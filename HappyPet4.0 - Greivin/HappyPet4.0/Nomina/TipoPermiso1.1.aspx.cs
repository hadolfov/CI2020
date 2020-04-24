using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.SCH_NOMINA;
using BLL.MANTENIMIENTO;
using DL.SCH_NOMINA;
using System.Data;

namespace HappyPet4._0
{
    public partial class TipoPermiso1__1 : System.Web.UI.Page
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
                //CargarCombos(); /*Cargar Combo no se utiliza para esta ventana*/
                btnEditar.Visible = false;
                btnEliminar.Visible = false;
                gvPermiso.SelectedIndex = -1;
            }
        }

        //private void CargarPrueba()
        //{
        //    DataTable dt = new DataTable();
        //    DataColumn dc0 = new DataColumn("Id Permiso");
        //    DataColumn dc1 = new DataColumn("Nombre del Permiso");
        //    DataColumn dc2 = new DataColumn("Estado");


        //    dt.Columns.Add(dc0);
        //    dt.Columns.Add(dc1);
        //    dt.Columns.Add(dc2);


        //    DataRow dr = dt.NewRow();
        //    dr["Id Permiso"] = "1";
        //    dr["Nombre del Permiso"] = "Vacaciones";
        //    dr["Estado"] = "Activo";
        //    dt.Rows.Add(dr);

        //    gvPermiso.DataSource = dt;
        //    gvPermiso.DataBind();
        //}

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
                SubModulo subModulo = modulo.SubModulos.First(x => x.IdSubModulo == (int)Constantes.SubModulosNomina.TiposPermisos);
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
            BLTipoPermiso tipoPermiso = new BLTipoPermiso();
            gvPermiso.DataSource = tipoPermiso.consultar_TipoPermiso(ref error);
            gvPermiso.DataBind();
        }


        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = "";
            txtProducto.Text = "";
            chkEstado.Checked = true;

            lblModalTitle.Text = "Permisos";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalPermisos", "$('#ModalPermisos').modal();", true);
            upModal.Update();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            EditarTipoPermiso();
        }

        private void EditarTipoPermiso()
        {
            string error = "";
            BLTipoPermiso bLTipoPermiso = new BLTipoPermiso();
            TiposPermiso tipo = bLTipoPermiso.consultar_TipoPermiso_Id(Convert.ToInt32(txtCodigo.Text), ref error);

            if (error == "")
            {
                txtProducto.Text = tipo.TipoPermiso;
                chkEstado.Checked = tipo.Estado == 1;

                lblModalTitle.Text = "Editar Permiso";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalPermiso", "$('#ModalPermsio').modal();", true);
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
            lblEliminarTitle.Text = "Eliminar Tipo de Permiso";
            lblEliminarbody.Text = "Desea Eliminar el siguiente Permiso" + txtProducto + "?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEliminar", "$('#ModalEliminar').modal();", true);
            upModal.Update();
        }

        protected void gvPermiso_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar" && IsPostBack)
            {
                int index = Convert.ToInt32(e.CommandArgument);
                if (gvPermiso.SelectedIndex == index)
                {
                    gvPermiso.SelectedIndex = -1;
                    btnEditar.Visible = false;
                    btnEliminar.Visible = false;
                    txtCodigo.Text = ""; 
                }
                else
                {
                    gvPermiso.SelectedIndex = index;
                    Permiso permiso = (Permiso)Session["PermisoPagina"];
                    if (permiso.Modificar)
                    {
                        btnEditar.Visible = true;
                    }
                    if (permiso.Eliminar)
                    {
                        btnEliminar.Visible = true;
                    }
                    txtCodigo.Text = gvPermiso.SelectedRow.Cells[1].Text;
                }
                //TableCell contactName = selectedRow.Cells[1];
                //string contact = contactName.Text;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblConfirmarTitle.Text = "Guardar Tipo de Permiso";
            lblConfirmarbody.Text = "Desea Guardar el Tipo de Permiso " + txtProducto.Text + "?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalConfirmar", "$('#ModalConfirmar').modal();", true);
            UpdatePanelConfirmar.Update();
        }

        private void GuardarTipoPermiso()
        {
            string error = "";
            if (ValidarCampos())
            {
                BLTipoPermiso BLtipoPermiso = new BLTipoPermiso();
                TiposPermiso tiposPermiso = new TiposPermiso();

                tiposPermiso.IdTipoPermiso = Convert.ToInt32(txtCodigo.Text);
                tiposPermiso.Estado= chkEstado.Checked ? 1 : 2;
                tiposPermiso.TipoPermiso = txtProducto.Text;


                if (txtCodigo.Text == "")
                {
                    BLtipoPermiso.Insertar_TipoPermiso(tiposPermiso, ref error);
                }
                else
                {
                    tiposPermiso.IdTipoPermiso = Convert.ToInt32(txtCodigo.Text);
                    BLtipoPermiso.Modificar_TipoPermiso(tiposPermiso, ref error);
                }

                if (error == "")
                {
                    Response.Redirect("TipoPermiso1.1.aspx");

                }
                else
                {
                    MostrarMensaje(error);
                }

            }
            else
            {
                MostrarMensaje("Debe completar todos los campos para guardar el Tipo de Permiso");
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


        private void EliminarTipoPermiso()
        {
            string error = "";
            BLTipoPermiso bLTipoPermiso = new BLTipoPermiso();
            TiposPermiso tipo = bLTipoPermiso.consultar_TipoPermiso_Id(Convert.ToInt32(txtCodigo.Text), ref error);
            if (error == "")
            {
                tipo.Estado = 3;
                bLTipoPermiso.Modificar_TipoPermiso(tipo, ref error);
                if (error == "")
                {
                    Response.Redirect("TipoPermiso1.1.aspx");
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
            GuardarTipoPermiso();
        }

        protected void btnEliminarConfirmacion_Click(object sender, EventArgs e)
        {
            EliminarTipoPermiso();
        }


    }
}