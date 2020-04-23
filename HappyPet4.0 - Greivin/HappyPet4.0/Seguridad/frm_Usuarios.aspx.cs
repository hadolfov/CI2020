using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.SCH_SEGURIDAD;
using BLL.MANTENIMIENTO;
using DL.SCH_SEGURIDAD;
using DL.SCH_NOMINA;

namespace HappyPet4._0.Seguridad
{
    public partial class frm_Usuarios : System.Web.UI.Page
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
                gvUsuarios.SelectedIndex = -1;
            }
        }

        private void CargarCombos()
        {
            string error = "";
            ListItem i;

            BLSucursales sucursales = new BLSucursales();
            ddlSucursales.DataTextField = "DesSucursal";
            ddlSucursales.DataValueField = "IdSucursal";
            ddlSucursales.DataSource = sucursales.consultar_Sucursales_Activas(ref error);
            ddlSucursales.DataBind();

            i = new ListItem("Seleccione una Sucursal", "0");
            ddlSucursales.Items.Insert(0, i);
        }

        private void CargarGrid()
        {
            string error = "";
            BLUsuarioSeguridad bLUsuario = new BLUsuarioSeguridad();
            gvUsuarios.DataSource = bLUsuario.consultar_usuarios(ref error);
            gvUsuarios.DataBind();
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
                SubModulo subModulo = modulo.SubModulos.First(x => x.IdSubModulo == (int)Constantes.SubModulosSeguridad.UsuariosSeguridad);
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
            LimpiarCampos();

            lblModalTitle.Text = "Agregar Usuario";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalUsuario", "$('#ModalUsuario').modal();", true);
            upModal.Update();
        }

        private void LimpiarCampos()
        {
            txtConfirmarContrasenna.Text = "";
            txtContrasenna.Text = "";
            txtEmail.Text = "";
            txtIdentificacion.Text = "";
            txtIdUsuario.Text = "";
            txtNombre.Text = "";
            txtNombreUsuario.Text = "";
            txtPrimerApellido.Text = "";
            txtSegundoApellido.Text = "";
            txtTelefono1.Text = "";
            txtTelefono2.Text = "";
            ddlSucursales.SelectedValue = "0";
            ddlTipoPerfil.SelectedValue = "0";
            chkEstado.Checked = true;
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            EditarUsuario();
        }

        private void EditarUsuario()
        {
            string error = "";

            BLUsuarioSeguridad bLUsuariosS = new BLUsuarioSeguridad();
            BLUsuarios bLUsuariosN = new BLUsuarios();
            UsuariosSeguridad usuariosSeguridad = bLUsuariosS.consultar(Convert.ToInt32(txtIdUsuario.Text), ref error);
            if (error == "")
            {
                Usuarios usuarios = bLUsuariosN.consultar_IdUsuario(Convert.ToInt32(txtIdUsuario.Text), ref error);
                if (error == "")
                {
                    txtContrasenna.Text = usuariosSeguridad.Contrasenna;
                    txtContrasenna.Visible = false;
                    txtConfirmarContrasenna.Text = usuariosSeguridad.Contrasenna;
                    txtConfirmarContrasenna.Visible = false;
                    txtEmail.Text = usuarios.Email;
                    txtIdentificacion.Text = usuarios.Identificacion;
                    txtNombre.Text = usuarios.Nombre;
                    txtNombreUsuario.Text = usuariosSeguridad.NombreUsuario;
                    txtPrimerApellido.Text = usuarios.PrimerApellido;
                    txtSegundoApellido.Text = usuarios.SegundoApellido;
                    txtTelefono1.Text = usuarios.Telefono1;
                    txtTelefono2.Text = usuarios.Telefono2;
                    ddlSucursales.SelectedValue = usuarios.IdSucursal.ToString();
                    CargarTiposPerfil(usuarios.IdSucursal);
                    ddlTipoPerfil.SelectedValue = usuariosSeguridad.IdTipoPerfil.ToString();

                    lblModalTitle.Text = "Editar Tipo de Perfil";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalUsuario", "$('#ModalUsuario').modal();", true);
                    upModal.Update();
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

        private void CargarTiposPerfil(int idSucursal)
        {
            string error = "";
            ListItem i;

            BLTipoPerfil tipo = new BLTipoPerfil();
            ddlTipoPerfil .DataTextField = "TipoPerfil";
            ddlTipoPerfil.DataValueField = "IdTipoPerfil";
            ddlTipoPerfil.DataSource = tipo.consultar_TipoPerfil_Activos_Sucursal(idSucursal, ref error);
            ddlTipoPerfil.DataBind();

            i = new ListItem("Seleccione un Tipo Perfil", "0");
            ddlTipoPerfil.Items.Insert(0, i);

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            lblEliminarTitle.Text = "Eliminar Usuario";
            lblEliminarbody.Text = "Desea eliminar el usuario identificación: " + txtIdentificacion.Text + "?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalEliminar", "$('#ModalEliminar').modal();", true);
            UpdatePanelEliminar.Update();
        }

        protected void gvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar" && IsPostBack)
            {
                int index = Convert.ToInt32(e.CommandArgument);
                if (gvUsuarios.SelectedIndex == index)
                {
                    gvUsuarios.SelectedIndex = -1;
                    btnEditar.Visible = false;
                    btnEliminar.Visible = false;
                    LimpiarCampos();
                }
                else
                {
                    gvUsuarios.SelectedIndex = index;
                    Permiso permiso = (Permiso)Session["PermisoPagina"];
                    if (permiso.Modificar)
                    {
                        btnEditar.Visible = true;
                    }
                    if (permiso.Eliminar)
                    {
                        btnEliminar.Visible = true;
                    }

                    txtIdUsuario.Text = gvUsuarios.SelectedRow.Cells[1].Text;
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblConfirmarTitle.Text = "Guardar Usuario";
            lblConfirmarbody.Text = "Desea guardar el usuario identificación " + txtIdentificacion.Text + "?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalConfirmar", "$('#ModalConfirmar').modal();", true);
            UpdatePanelConfirmar.Update();
        }

        private void GuardarTipoPerfil()
        {
            string error = "";
            if (ValidarCampos())
            {
                if (txtContrasenna.Text == txtConfirmarContrasenna.Text)
                {
                    BLUsuarioSeguridad bLUsuariosS = new BLUsuarioSeguridad();
                    BLUsuarios bLUsuariosN = new BLUsuarios();
                    UsuariosSeguridad usuariosSeguridad = new UsuariosSeguridad();
                    Usuarios usuarios = new Usuarios();

                    usuariosSeguridad.Estado = chkEstado.Checked ? 1 : 2;
                    

                    usuariosSeguridad.IdTipoPerfil = Convert.ToInt32(ddlTipoPerfil.SelectedValue);
                    usuariosSeguridad.NombreUsuario = txtNombreUsuario.Text;
                    usuariosSeguridad.Contrasenna = txtContrasenna.Text;

                    usuarios.Estado = chkEstado.Checked ? 1 : 2;
                    usuarios.Email = txtEmail.Text;
                    usuarios.Identificacion = txtIdentificacion.Text;
                    usuarios.IdSucursal = Convert.ToInt32(ddlSucursales.SelectedValue);
                    usuarios.Nombre = txtNombre.Text;
                    usuarios.PrimerApellido = txtPrimerApellido.Text;
                    usuarios.SegundoApellido = txtSegundoApellido.Text;
                    usuarios.Telefono1 = txtTelefono1.Text;
                    usuarios.Telefono2 = txtTelefono2.Text;

                    if (txtIdUsuario.Text == "")
                    {
                        usuarios.IdUsuario = bLUsuariosS.insertar(usuariosSeguridad, ref error);
                        if (error == "")
                        {
                            bLUsuariosN.insertar(usuarios, ref error);
                        }
                    }
                    else
                    {
                        usuariosSeguridad.IdUsuarioSeguridad = Convert.ToInt32(txtIdUsuario.Text);
                        bLUsuariosS.modificar(usuariosSeguridad, ref error);
                        if (error == "")
                        {
                            bLUsuariosN.modificar(usuarios, ref error);
                        }
                    }

                    if (error == "")
                    {
                        Response.Redirect("frm_Usuarios.aspx");

                    }
                    else
                    {
                        MostrarMensaje(error);
                    }
                }
                else
                {
                    MostrarMensaje("La contraseña no coincide con la confirmación");
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
            if (!String.IsNullOrEmpty(txtConfirmarContrasenna.Text)
                && !String.IsNullOrEmpty(txtContrasenna.Text)
                && !String.IsNullOrEmpty(txtEmail.Text)
                && !String.IsNullOrEmpty(txtIdentificacion.Text)
                && !String.IsNullOrEmpty(txtNombre.Text)
                && !String.IsNullOrEmpty(txtNombreUsuario.Text)
                && !String.IsNullOrEmpty(txtPrimerApellido.Text)
                && !String.IsNullOrEmpty(txtSegundoApellido.Text)
                && !String.IsNullOrEmpty(txtTelefono1.Text)
                && !String.IsNullOrEmpty(txtTelefono2.Text)
                && Convert.ToInt32(ddlSucursales.SelectedValue) > 0
                && Convert.ToInt32(ddlTipoPerfil.SelectedValue) > 0)
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
            EliminarTipoPerfil();
        }

        private void EliminarTipoPerfil()
        {
            string error = "";

            BLUsuarioSeguridad bLUsuariosS = new BLUsuarioSeguridad();
            BLUsuarios bLUsuariosN = new BLUsuarios();
            UsuariosSeguridad usuariosSeguridad = bLUsuariosS.consultar(Convert.ToInt32(txtIdUsuario.Text), ref error);
            if (error == "")
            {
                Usuarios usuarios = bLUsuariosN.consultar_IdUsuario(Convert.ToInt32(txtIdUsuario.Text), ref error);
                if (error == "")
                {
                    usuariosSeguridad.Estado = 3;
                    bLUsuariosS.modificar(usuariosSeguridad, ref error);
                    if (error == "")
                    {
                        usuarios.Estado = 3;
                        bLUsuariosN.modificar(usuarios, ref error);
                    }
                }
            }
            if (error != "")
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

        protected void ddlSucursales_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarTiposPerfil(Convert.ToInt32(ddlSucursales.SelectedValue));
            upModal.Update();
        }
    }
}