using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using BLL.MANTENIMIENTO;
using DL.SCH_INVENTARIO;
using DAL.SCH_NOMINA;


namespace HappyPet4._0
{
    public partial class Articulos1__1 : System.Web.UI.Page
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
                gvCitas.SelectedIndex = -1;
                
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
            BLArticulos art = new BLArticulos();
            gvCitas.DataSource = art.consultar_articulos(ref error);
            gvCitas.DataBind();
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
        protected void gvCitas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar" && IsPostBack)
            {
                int index = Convert.ToInt32(e.CommandArgument);
                if (gvCitas.SelectedIndex == index)
                {
                    gvCitas.SelectedIndex = -1;
                    btnEditar.Visible = false;
                    btnEliminar.Visible = false;
                    txtProducto.Text = "";
                }
                else
                {
                    gvCitas.SelectedIndex = index;
                    Permiso permiso = (Permiso)Session["PermisoPagina"];
                    if (permiso.Modificar)
                    {
                        btnEditar.Visible = true;
                    }
                    if (permiso.Eliminar)
                    {
                        btnEliminar.Visible = true;
                    }
                    txtCodigo.Text = gvCitas.SelectedRow.Cells[1].Text;
                    txtProducto.Text = gvCitas.SelectedRow.Cells[2].Text;
                    txtDescripcion.Text = gvCitas.SelectedRow.Cells[3].Text;
                    if (gvCitas.SelectedRow.Cells[4].Text=="true")
                    {
                        chkb_Servicio.Checked = true;
                    }
                    else
                    {
                        chkb_Servicio.Checked = false;
                    } 
                    txtPecioArt.Text = gvCitas.SelectedRow.Cells[5].Text;
                    txtCantDisponible.Text = gvCitas.SelectedRow.Cells[6].Text;
                    txtCantMaximo.Text = gvCitas.SelectedRow.Cells[7].Text;
                    txtCantMinimo.Text = gvCitas.SelectedRow.Cells[8].Text;
                    if (Convert.ToString(gvCitas.SelectedRow.Cells[9].Text) == "1")
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
            txtCodigo.Text = "";
            chkb_Activo.Checked = false;
            chkb_Servicio.Checked = false;
            txtProducto.Text = "";
            txtDescripcion.Text = "";
            txtCantMinimo.Text = "";
            txtCantMaximo.Text = "";
            txtPecioArt.Text = "";
            txtCantDisponible.Text = "";


            lblModalTitle.Text = "Articulos";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalArticulos", "$('#ModalArticulos').modal();", true);
            upModal.Update();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            lblModalTitle.Text = "Editar Articulos";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalArticulos", "$('#ModalArticulos').modal();", true);
            upModal.Update();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            lblEliminarTitle.Text = "Eliminar Articulo";
            lblEliminarbody.Text = "Desea Eliminar el Articulo?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEliminar", "$('#ModalEliminar').modal();", true);
            upModal.Update();
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblConfirmarTitle.Text = "Guardar Tipo de Perfil";
            lblConfirmarbody.Text = "Desea Guardar el Tipo de Perfil " + txtProducto.Text + "?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalConfirmar", "$('#ModalConfirmar').modal();", true);
            UpdatePanelConfirmar.Update();
        }

        private void GuardarArticulo()
        {
            string error = "";
            if (ValidarCampos())
            {
                Articulo objArticulo = new Articulo();
                BLArticulos bLArticulos = new BLArticulos();
                objArticulo.NombreArticulo = txtProducto.Text;
                objArticulo.Descripcion = txtDescripcion.Text;
                objArticulo.Precio = Convert.ToDouble(txtPecioArt.Text);
                objArticulo.Servicio = chkb_Servicio.Checked ? true : false;
                objArticulo.Estado = chkb_Activo.Checked ? 1 : 2;
                objArticulo.CantidadMin = Convert.ToInt32(txtCantMinimo.Text);
                objArticulo.CantidadMax = Convert.ToInt32(txtCantMaximo.Text);
                objArticulo.CantidadStock = Convert.ToInt32(txtCantDisponible.Text);
                
                
                if (txtCodigo.Text == "")
                {
                  bLArticulos.Insertar_Articulo (objArticulo, ref error);
                }
                else
                {
                    objArticulo.IdArticulo = Convert.ToInt32(txtCodigo.Text);
                    bLArticulos.Modificar_Articulo(objArticulo, ref error);
                }

                if (error == "")
                {
                    Response.Redirect("Articulos1.1.aspx");

                }
                else
                {
                    MostrarMensaje(error);
                }

            }
            else
            {
                MostrarMensaje("Debe completar todos los campos para guardar el Articulo");
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
            if (!String.IsNullOrEmpty(txtProducto.Text)
                && (!String.IsNullOrEmpty(txtDescripcion.Text))
                && (!String.IsNullOrEmpty(txtPecioArt.Text))
                && (!String.IsNullOrEmpty(txtCantMaximo.Text))
                && (!String.IsNullOrEmpty(txtCantMinimo.Text))
                && (!String.IsNullOrEmpty(txtCantDisponible.Text))
               )
                
            {
                valido = true;
                valido = ValidarCantidad();
            }
            else
            {
                valido = false;
            }
            return valido;
        }
        private bool ValidarCantidad()
        {
            bool valido = true;
            if (Convert.ToInt32(txtCantMinimo.Text)>0
                && (Convert.ToInt32(txtCantDisponible.Text) > 0
                && (Convert.ToInt32(txtPecioArt.Text) > 0
                && (Convert.ToInt32(txtCantDisponible.Text) > Convert.ToInt32(txtCantMinimo.Text))
                && (Convert.ToInt32(txtCantDisponible.Text) < Convert.ToInt32(txtCantMaximo.Text))
                && (Convert.ToInt32(txtCantMinimo.Text) < (Convert.ToInt32(txtCantMaximo.Text))))))

            {
                valido = true;
            }
            else
            {
                MostrarMensaje("Valores no permitidos en precio o cantidades de Articulos");
                valido = false;
            }
            return valido;
        }
        protected void btnGuardarConfirmacion_Click(object sender, EventArgs e)
        {
            GuardarArticulo();
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