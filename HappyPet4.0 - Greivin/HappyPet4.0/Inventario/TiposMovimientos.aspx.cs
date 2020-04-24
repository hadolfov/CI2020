using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.MANTENIMIENTO;
using DL.SCH_INVENTARIO;
using DAL.SCH_INVENTARIO;
using DAL.SCH_NOMINA;


namespace HappyPet4._0.Inventario
{
    public partial class TiposMovimientos : System.Web.UI.Page
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
                btnEditar.Visible = false;
                btnEliminar.Visible = false;
                gvTiposMovimientos.SelectedIndex = -1;

            }
        }

        //private void CargarPrueba()
        //{
        //    DataTable dt = new DataTable();
        //    DataColumn dc0 = new DataColumn("Id Articulo");
        //    DataColumn dc1 = new DataColumn("Nombre Articulo");
        //    DataColumn dc2 = new DataColumn("Descripcion");
        //    DataColumn dc3 = new DataColumn("Cantidad Maxima");
        //    DataColumn dc4 = new DataColumn("Cantidad Minima");
        //    DataColumn dc5 = new DataColumn("Cantidad Stock");
        //    DataColumn dc6 = new DataColumn("Estado");

        //    dt.Columns.Add(dc0);
        //    dt.Columns.Add(dc1);
        //    dt.Columns.Add(dc2);
        //    dt.Columns.Add(dc3);
        //    dt.Columns.Add(dc4);
        //    dt.Columns.Add(dc5);
        //    dt.Columns.Add(dc6);


        //    DataRow dr = dt.NewRow();
        //    dr["Id Articulo"] = "";
        //    dr["Nombre Articulo"] = "";
        //    dr["Descripcion"] = "";
        //    dr["Cantidad Minima"] = "";
        //    dr["Cantidad Maxima"] = "";
        //    dr["Cantidad Stock"] = "";
        //    dr["Estado"] = "Activo";
        //    dt.Rows.Add(dr);

        //    gvCitas.DataSource = dt;
        //    gvCitas.DataBind();
        //}
        private void CargarGrid()
        {
            string error = "";
            blTiposMovimientos mot = new blTiposMovimientos();
            gvTiposMovimientos.DataSource = mot.consultar_TiposMovimientos(ref error);
            gvTiposMovimientos.DataBind();
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
        protected void gvTiposMovimientos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar" && IsPostBack)
            {
                int index = Convert.ToInt32(e.CommandArgument);
                if (gvTiposMovimientos.SelectedIndex == index)
                {
                    gvTiposMovimientos.SelectedIndex = -1;
                    btnEditar.Visible = false;
                    btnEliminar.Visible = false;
                    txtTipoMovimiento.Text = "";
                }
                else
                {
                    gvTiposMovimientos.SelectedIndex = index;
                    Permiso permiso = (Permiso)Session["PermisoPagina"];
                    if (permiso.Modificar)
                    {
                        btnEditar.Visible = true;
                    }
                    if (permiso.Eliminar)
                    {
                        btnEliminar.Visible = true;
                    }

                    txtIdTipoMovimiento.Text = gvTiposMovimientos.SelectedRow.Cells[1].Text;
                    txtTipoMovimiento.Text = gvTiposMovimientos.SelectedRow.Cells[2].Text;
                    if (Convert.ToString(gvTiposMovimientos.SelectedRow.Cells[3].Text) == "1")
                    {
                        chkb_Activo.Checked = true;
                    }
                    else
                    {
                        chkb_Activo.Checked = false;
                    }
                }


            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            txtTipoMovimiento.Text = "";
            chkb_Activo.Checked = false;

            txtIdTipoMovimiento.Text = "";
            txtTipoMovimiento.Text = "";

            lblModalTitle.Text = "TiposMovimientos";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalTiposMovimientos", "$('#ModalTiposMovimientos').modal();", true);
            upModal.Update();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            lblModalTitle.Text = "Editar TiposMovimientos";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalTiposMovimientos", "$('#ModalTiposMovimientos').modal();", true);
            upModal.Update();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            lblEliminarTitle.Text = "Eliminar Motivo";
            lblEliminarbody.Text = "Desea Eliminar el Motivo?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEliminar", "$('#ModalEliminar').modal();", true);
            upModal.Update();
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblConfirmarTitle.Text = "Guardar Motivo";
            lblConfirmarbody.Text = "Desea Guardar el motivo " + txtIdTipoMovimiento.Text + "?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalConfirmar", "$('#ModalConfirmar').modal();", true);
            UpdatePanelConfirmar.Update();
        }

        private void GuardarArticulo()
        {
            string error = "";
            if (ValidarCampos())
            {
                TipoMovimiento objArticulo = new TipoMovimiento();
                blTiposMovimientos OobjMotivo = new blTiposMovimientos();
                objArticulo.NombreTipo = txtTipoMovimiento.Text;
                objArticulo.Estado = chkb_Activo.Checked ? 1 : 2;



                if (txtIdTipoMovimiento.Text == "")
                {
                    OobjMotivo.Insertar_TipoMovimiento(objArticulo, ref error);
                }
                else
                {
                    objArticulo.IdTipo = Convert.ToInt32(txtIdTipoMovimiento.Text);
                    objArticulo.Estado = chkb_Activo.Checked ? 1 : 2;
                    objArticulo.NombreTipo = txtTipoMovimiento.Text;
                    OobjMotivo.Modificar_TipoMov(objArticulo, ref error);
                }

                if (error == "")
                {
                    Response.Redirect("TiposMovimientos.aspx");

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
        private bool ValidarCampos()
        {
            bool valido = true;
            if (!String.IsNullOrEmpty(txtTipoMovimiento.Text))

            {
                valido = true;
            }
            else
            {
                valido = false;
            }
            return valido;
        }
        protected void btnGuardarConfirmacion_Click(object sender, EventArgs e)
        {
            GuardarArticulo();
        }
        protected void btnEliminarConfirmacion_Click(object sender, EventArgs e)
        {
            EliminarTipoPerfil();
        }

        private void EliminarTipoPerfil()
        {
            string error = "";
            blTiposMovimientos bLTipoPerfil = new blTiposMovimientos();
            TipoMovimiento tipo = bLTipoPerfil.consultar_Tipo_Movimiento_id(Convert.ToInt32(txtIdTipoMovimiento.Text), ref error);
            if (error == "")
            {
                tipo.Estado = 3;
                bLTipoPerfil.Modificar_TipoMov(tipo, ref error);
                if (error == "")
                {
                    Response.Redirect("TiposMovimientos.aspx");
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

        //protected void gvCitas_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "Seleccionar" && IsPostBack)
        //    {
        //        int index = Convert.ToInt32(e.CommandArgument);
        //        if (gvCitas.SelectedIndex == index)
        //        {
        //            gvCitas.SelectedIndex = -1;
        //            btnEditar.Visible = false;
        //            btnEliminar.Visible = false;
        //        }
        //        else
        //        {
        //            //gvCitas.SelectedIndex = index;
        //            //if (gvCitas.Rows[index].Cells[6].Text == "Confirmada")
        //            //{
        //            //    btnAtender.Visible = true;
        //            //}
        //            //else
        //            //{
        //            //    btnAtenderCita.Visible = false;
        //            //}
        //            btnEditar.Visible = true;
        //            btnEliminar.Visible = true;
        //        }
        //        //TableCell contactName = selectedRow.Cells[1];
        //        //string contact = contactName.Text;
        //    }
        //}

    }
}