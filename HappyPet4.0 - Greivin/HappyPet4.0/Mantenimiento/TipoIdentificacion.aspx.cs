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
    public partial class TipoIdentificacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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
            gvTpIdentificacion.SelectedIndex = -1;
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

        private void CargarGrid()
        {
            string error = "";
            BLTipoIdentificacion tipoIdentificacion = new BLTipoIdentificacion();
            gvTpIdentificacion.DataSource = tipoIdentificacion.consultar_TipoIdentificacion
(ref error);
            gvTpIdentificacion.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            txtidTpIdentificacion.Text = "";
            txtTpIdentificacion.Text = "";
            chkEstado.Checked = true;

            lblModalTitle.Text = "Tipo Identificacion";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalTpIdentificacion", "$('#ModalTpIdentificacion').modal();", true);
            upModal.Update();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            EditarTipoIdentificacion();
        }

        private void EditarTipoIdentificacion()
        {
            string error = "";
            BLTipoIdentificacion bLTipoIdentificacion = new BLTipoIdentificacion();
            TiposIdentificacion tipo = bLTipoIdentificacion.consultar_TipoIdentificacion_Id(Convert.ToInt32(txtidTpIdentificacion.Text), ref error);

            //TipoIdentificacion tipo = bLTipoIdentificacion.consultar_TipoIdentificacion_Id(Convert.ToInt32(txtidTpIdentificacion.Text), ref error);

            if (error == "")
            {
                txtTpIdentificacion.Text = tipo.DesTipoIdentificacion;
                txtCodIdentificacion.Text = tipo.CodigoTipoIdentificacion;
                chkEstado.Checked = tipo.Estado == 1;

                lblModalTitle.Text = "Editar Tipo Identificacion";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalIdentificacion", "$('#ModalTipoIdentificacion').modal();", true);
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
            lblEliminarTitle.Text = "Eliminar Tipo de Identificacion";
            lblEliminarbody.Text = "Desea Eliminar el Tipo de Indentificacion " + txtTpIdentificacion.Text + "?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEliminar", "$('#ModalEliminar').modal();", true);
            upModal.Update();
        }

        protected void gvTpIdentificacion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar" && IsPostBack)
            {
                int index = Convert.ToInt32(e.CommandArgument);
                if (gvTpIdentificacion.SelectedIndex == index)
                {
                    gvTpIdentificacion.SelectedIndex = -1;
                    btnEditar.Visible = false;
                    btnEliminar.Visible = false;
                    txtidTpIdentificacion.Text = "";
                }
                else
                {
                    gvTpIdentificacion.SelectedIndex = index;
                    Permiso permiso = (Permiso)Session["PermisoPagina"];
                    if (permiso.Modificar)
                    {
                        btnEditar.Visible = true;
                    }
                    if (permiso.Eliminar)
                    {
                        btnEliminar.Visible = true;
                    }
                    txtidTpIdentificacion.Text = gvTpIdentificacion.SelectedRow.Cells[1].Text;
                }
                //TableCell contactName = selectedRow.Cells[1];
                //string contact = contactName.Text;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblConfirmarTitle.Text = "Guardar Tipo de Identificacion";
            lblConfirmarbody.Text = "Desea Guardar el Tipo de Marca " + txtTpIdentificacion.Text + "?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalConfirmar", "$('#ModalConfirmar').modal();", true);
            UpdatePanelConfirmar.Update();
        }

        private void GuardarTipoIdentificacion()
        {
            string error = "";
            if (ValidarCampos())
            {
                BLTipoIdentificacion BLtipoIdentificacion = new BLTipoIdentificacion();
                TiposIdentificacion tiposIdentificacion = new TiposIdentificacion();

               tiposIdentificacion.Estado = chkEstado.Checked ? 1 : 2;
               tiposIdentificacion.DesTipoIdentificacion = txtTpIdentificacion.Text;


                if (txtidTpIdentificacion.Text == "")
                {
                    BLtipoIdentificacion.Insertar_TipoIdentificacion(tiposIdentificacion, ref error);
                }
                else
                {
                    tiposIdentificacion.IdTipoIdentificacion = Convert.ToInt32(txtidTpIdentificacion.Text);
                    BLtipoIdentificacion.Modificar_TipoIdentificacion(tiposIdentificacion, ref error);
                }

                if (error == "")
                {
                    Response.Redirect("TipoIdentificaicon.aspx");

                }
                else
                {
                    MostrarMensaje(error);
                }

            }
            else
            {
                MostrarMensaje("Debe completar todos los campos para guardar el Tipo de Identificacion");
            }
        }

        private bool ValidarCampos()
        {
            bool valido = true;
            if (!String.IsNullOrEmpty(txtTpIdentificacion.Text))

            {
                valido = true;
            }
            else
            {
                valido = false;
            }
            return valido;
        }

        private void EliminarTipoIdentificacion()
        {
            string error = "";
            BLTipoIdentificacion bLTipoIdentificacion = new BLTipoIdentificacion();
            TiposIdentificacion tipo = bLTipoIdentificacion.consultar_TipoIdentificacion_Id(Convert.ToInt32(txtidTpIdentificacion.Text), ref error);
            if (error == "")
            {
                tipo.Estado = 3;
                bLTipoIdentificacion.Modificar_TipoIdentificacion(tipo, ref error);
                if (error == "")
                {
                    Response.Redirect("TipoIdentificacion.aspx");
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
            GuardarTipoIdentificacion();
        }
    }
}