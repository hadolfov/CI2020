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
    public partial class Proveedores1__1 : System.Web.UI.Page
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
                gvProveedor.SelectedIndex = -1;
            }

        }
        private void CargarGrid()
        {
            string error = "";
            blProveedores prove = new blProveedores();
            gvProveedor.DataSource = prove.consultar_Proveedor(ref error);
            gvProveedor.DataBind();
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
            txtApellido1.Text = "";
            txtApellido2.Text = "";
            txtEmail.Text = "";
            txtIdProveedor.Text = "";
            txtNombre.Text = "";
            txtNumTel2.Text = "";
            txtNumTelefono1.Text = "";
            txtIndentificacion.Text = "";

            //ddlSucursales.SelectedValue = "0";

            chkActivo.Checked = true;

            lblModalTitle.Text = "Agregar Proveedores";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalProveedores", "$('#ModalProveedores').modal();", true);
            upModal.Update();
        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            EditarTipoPerfil();
        }

        private void EditarTipoPerfil()
        {
            string error = "";
            blProveedores bLProveedoresl = new blProveedores();
            int id = Convert.ToInt32(gvProveedor.SelectedRow.Cells[1].Text);
            Proveedor newProveedor = bLProveedoresl.consultar_Proveedor_Id(id, ref error);

            if (error == "")
            {
                id = newProveedor.IdProveedor;
                ddlTipoIdientificacion.SelectedValue = newProveedor.IdTipoIdentificacion.ToString();
                txtIdProveedor.Text = id.ToString();
                txtIndentificacion.Text = newProveedor.Identificacion;
                txtNombre.Text = newProveedor.Nombre;
                txtApellido1.Text = newProveedor.Apellido1;
                txtApellido2.Text = newProveedor.Apellido2;
                txtEmail.Text = newProveedor.Email;
                txtNumTelefono1.Text = newProveedor.Telefono1;
                txtNumTel2.Text = newProveedor.Telefono2;
                chkActivo.Checked = newProveedor.Estado == 1;

                lblModalTitle.Text = "Editar Proveedor";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalProveedores", "$('#ModalProveedores').modal();", true);
                upModal.Update();
            }
            else
            {
                MostrarMensaje(error);
            }
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            lblEliminarTitle.Text = "Eliminar Tipo de Perfil";
            lblEliminarbody.Text = "Desea Eliminar el Proveedor " + txtIndentificacion.Text + "?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEliminar", "$('#ModalEliminar').modal();", true);
            UpdatePanelEliminar.Update();
        }
        protected void gvProveedor_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar" && IsPostBack)
            {
                int index = Convert.ToInt32(e.CommandArgument);
                if (gvProveedor.SelectedIndex == index)
                {
                    gvProveedor.SelectedIndex = -1;
                    btnEditar.Visible = false;
                    btnEliminar.Visible = false;
                    txtIndentificacion.Text = "";
                }
                else
                {
                    gvProveedor.SelectedIndex = index;
                    Permiso permiso = (Permiso)Session["PermisoPagina"];
                    if (permiso.Modificar)
                    {
                        btnEditar.Visible = true;
                    }
                    if (permiso.Eliminar)
                    {
                        btnEliminar.Visible = true;
                    }

                    ddlTipoIdientificacion.SelectedValue = gvProveedor.SelectedRow.Cells[1].ToString();
                    txtIndentificacion.Text = gvProveedor.SelectedRow.Cells[2].Text;
                    
                    txtNombre.Text = gvProveedor.SelectedRow.Cells[3].Text;
                    txtApellido1.Text = gvProveedor.SelectedRow.Cells[4].Text;
                    txtApellido2.Text = gvProveedor.SelectedRow.Cells[5].Text;
                    txtEmail.Text = gvProveedor.SelectedRow.Cells[6].Text;
                    txtNumTelefono1.Text = gvProveedor.SelectedRow.Cells[7].Text;
                    txtNumTel2.Text = gvProveedor.SelectedRow.Cells[8].Text;
                    if (Convert.ToString(gvProveedor.SelectedRow.Cells[9].Text) == "1")
                    {
                        chkActivo.Checked = true;
                    }
                    else
                    {
                        chkActivo.Checked = false;
                    }
                }


            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblConfirmarTitle.Text = "Guardar Proveedor";
            lblConfirmarbody.Text = "Desea Guardar el proveedor " + txtIdProveedor.Text + "?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalConfirmar", "$('#ModalConfirmar').modal();", true);
            UpdatePanelConfirmar.Update();
        }

        private void GuardarTipoPerfil()
        {
            string error = "";
            if (ValidarCampos())
            {
                blProveedores BLproveedor = new blProveedores();
                Proveedor gProveedor = new Proveedor();

                gProveedor.Estado = chkActivo.Checked ? 1 : 2;
                gProveedor.Identificacion = txtIndentificacion.Text;
                gProveedor.IdProveedor = Convert.ToInt32(txtIdProveedor.Text);
                gProveedor.IdTipoIdentificacion = Convert.ToInt32(ddlTipoIdientificacion.SelectedValue);
                gProveedor.Nombre = txtNombre.Text;
                gProveedor.Apellido1 = txtApellido1.Text;
                gProveedor.Apellido2 = txtApellido2.Text;
                gProveedor.Email = txtEmail.Text;
                gProveedor.Telefono1 = txtNumTelefono1.Text;
                gProveedor.Telefono2 = txtNumTel2.Text;


                if (txtIdProveedor.Text == "")
                {
                    BLproveedor.Insertar_Proveedor(gProveedor, ref error);
                }
                else
                {
                    gProveedor.IdProveedor = Convert.ToInt32(txtIdProveedor.Text);
                    BLproveedor.Modificar_Proveedor(gProveedor, ref error);
                }

                if (error == "")
                {
                    Response.Redirect("frm_Tipos_Perfil.aspx");

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
            if (!String.IsNullOrEmpty(txtIndentificacion.Text)
                && Convert.ToInt32(ddlTipoIdientificacion.SelectedValue) > 0
                && !String.IsNullOrEmpty(txtNombre.Text)
               && !String.IsNullOrEmpty(txtApellido1.Text)
                    && !String.IsNullOrEmpty(txtApellido2.Text)
                    && !String.IsNullOrEmpty(txtEmail.Text)
                    && !String.IsNullOrEmpty(txtNumTelefono1.Text)
                    && !String.IsNullOrEmpty(txtNumTel2.Text))
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
            EliminarProveedores();
        }

        private void EliminarProveedores()
        {
            string error = "";
            blProveedores BLproveedores = new blProveedores();
            Proveedor prove = BLproveedores.consultar_Proveedor_Id(Convert.ToInt32(txtIdProveedor.Text), ref error);
            if (error == "")
            {
                prove.Estado = 3;
                BLproveedores.Modificar_Proveedor(prove, ref error);
                if (error == "")
                {
                    Response.Redirect("Proveedores1.1.aspx");
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
            GuardarTipoPerfil();
        }




        //private void CargarCombos()
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


        //private void CargarPrueba()
        //{
        //    DataTable dt = new DataTable();
        //    DataColumn dc0 = new DataColumn("Identificacion");
        //    DataColumn dc1 = new DataColumn("Nombre Empresa/Persona");
        //    DataColumn dc2 = new DataColumn("Primer Apellido");
        //    DataColumn dc3 = new DataColumn("Segundo Apellido");
        //    DataColumn dc4 = new DataColumn("Email");
        //    DataColumn dc5 = new DataColumn("Numero Telefono 1");
        //    DataColumn dc6 = new DataColumn("Numero Telefono 2");
        //    DataColumn dc7 = new DataColumn("Estado");

        //    dt.Columns.Add(dc0);
        //    dt.Columns.Add(dc1);
        //    dt.Columns.Add(dc2);
        //    dt.Columns.Add(dc3);
        //    dt.Columns.Add(dc4);
        //    dt.Columns.Add(dc5);
        //    dt.Columns.Add(dc6);
        //    dt.Columns.Add(dc7);

        //    DataRow dr = dt.NewRow();
        //    dr["Identificacion"] = "3102415633";
        //    dr["Nombre Empresa/Persona"] = "Greencore";
        //    dr["Primer Apellido"] = "Solutions";
        //    dr["Segundo Apellido"] = "SRL";
        //    dr["Email"] = "xxx@greecore.co.cr";
        //    dr["Numero Telefono 1"] = "111-111-111";
        //    dr["Numero Telefono 2"] = "222-222-222";
        //    dr["Estado"] = "Activo";
        //    dt.Rows.Add(dr);

        //    gvCitas.DataSource = dt;
        //    gvCitas.DataBind();
        //
    }




}
