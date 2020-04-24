using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.SCH_NOMINA;
using BLL.MANTENIMIENTO;
using DL.SCH_SEGURIDAD;

namespace HappyPet4._0.Seguridad
{
    public partial class frm_Permisos_Seguridad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPermisos();
                CargarGrid();
                btnEditar.Visible = false;
                gvTipoPerfil.SelectedIndex = -1;
            }
        }

        private void CargarGrid()
        {
            string error = "";
            BLTipoPerfil tipoPerfil = new BLTipoPerfil();
            gvTipoPerfil.DataSource = tipoPerfil.consultar_TipoPerfil(ref error);
            gvTipoPerfil.DataBind();
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
                SubModulo subModulo = modulo.SubModulos.First(x => x.IdSubModulo == (int)Constantes.SubModulosSeguridad.PermisosSeguridad);
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

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            EditarTipoPerfil();
        }

        private void EditarTipoPerfil()
        {
            string error = "";
            BLPermisosSeguridad bLpermisos = new BLPermisosSeguridad();
            List<PermisosSeguridad> permisos = bLpermisos.consultar_Permisos_Perfil(Convert.ToInt32(txtIdTipoPerfil.Text), ref error);

            if (error == "")
            {
                CargarOpcionesSeguridad(permisos);
                

                lblModalTitle.Text = "Editar Tipo de Perfil";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalTipoPerfil", "$('#ModalTipoPerfil').modal();", true);
                upModal.Update();
            }
            else
            {
                MostrarMensaje(error);
            }
        }

        private void CargarOpcionesSeguridad(List<PermisosSeguridad> permisos)
        {
            foreach (PermisosSeguridad permiso in permisos)
            {
                switch (permiso.IdSubmodulo)
                {
                    case (int)Constantes.SubModulosInventario.Productos:
                        chkVerArticulos.Checked = true;
                        chkInsertarArticulos.Checked = permiso.Insertar;
                        chkModificarArticulos.Checked = permiso.Modificar;
                        chkEliminarArticulos.Checked = permiso.Eliminar;
                        break;
                    case (int)Constantes.SubModulosInventario.MotivosMovimientos:
                        chkVerMotivos.Checked = true;
                        chkInsertarMotivos.Checked = permiso.Insertar;
                        chkModificarMotivos.Checked = permiso.Modificar;
                        chkEliminarMotivos.Checked = permiso.Eliminar;
                        break;
                    case (int)Constantes.SubModulosInventario.Proveedores:
                        chkVerProveedores.Checked = true;
                        chkInsertarProveedores.Checked = permiso.Insertar;
                        chkModificarProveedores.Checked = permiso.Modificar;
                        chkEliminarProveedores.Checked = permiso.Eliminar;
                        break;
                    case (int)Constantes.SubModulosInventario.TiposMovimientos:
                        chkVerTiposMovimientos.Checked = true;
                        chkInsertarTiposMovimientos.Checked = permiso.Insertar;
                        chkModificarTiposMovimientos.Checked = permiso.Modificar;
                        chkEliminarTiposMovimientos.Checked = permiso.Eliminar;
                        break;
                    case (int)Constantes.SubModulosInventario.IngresoListado:
                        chkVerIngreso.Checked = true;
                        chkInsertarIngreso.Checked = permiso.Insertar;
                        chkModificarIngreso.Checked = permiso.Modificar;
                        chkEliminarIngreso.Checked = permiso.Eliminar;
                        break;
                    case (int)Constantes.SubModulosInventario.DescontinuarProductos:
                        chkVerDescontinuar.Checked = true;
                        chkInsertarDescontinuar.Checked = permiso.Insertar;
                        chkModificarDescontinuar.Checked = permiso.Modificar;
                        chkEliminarDescontinuar.Checked = permiso.Eliminar;
                        break;
                    case (int)Constantes.SubModulosInventario.Transferencias:
                        chkVerTransferencias.Checked = true;
                        chkInsertarTransferencias.Checked = permiso.Insertar;
                        chkModificarTransferencias.Checked = permiso.Modificar;
                        chkEliminarTransferencias.Checked = permiso.Eliminar;
                        break;
                    case (int)Constantes.SubModulosNomina.Planilla :
                        chkVerPlanilla.Checked = true;
                        chkInsertarPlanilla.Checked = permiso.Insertar;
                        chkModificarPlanilla.Checked = permiso.Modificar;
                        chkEliminarPlanilla.Checked = permiso.Eliminar;
                        break;
                    case (int)Constantes.SubModulosNomina.Marcas:
                        chkVerMarcas.Checked = true;
                        chkInsertarMarcas.Checked = permiso.Insertar;
                        chkModificarMarcas.Checked = permiso.Modificar;
                        chkEliminarMarcas.Checked = permiso.Eliminar;
                        break;
                    case (int)Constantes.SubModulosNomina.Permisos:
                        chkVerPermisos.Checked = true;
                        chkInsertarPermisos.Checked = permiso.Insertar;
                        chkModificarPermisos.Checked = permiso.Modificar;
                        chkEliminarPermisos.Checked = permiso.Eliminar;
                        break;
                    case (int)Constantes.SubModulosNomina.TiposMarcas:
                        chkVerTipoMarcas.Checked = true;
                        chkInsertarTipoMarcas.Checked = permiso.Insertar;
                        chkModificarTipoMarcas.Checked = permiso.Modificar;
                        chkEliminarTipoMarcas.Checked = permiso.Eliminar;
                        break;
                    case (int)Constantes.SubModulosNomina.TiposPermisos:
                        chkVerTipoPermisos.Checked = true;
                        chkInsertarTipoPermisos.Checked = permiso.Insertar;
                        chkModificarTipoPermisos.Checked = permiso.Modificar;
                        chkEliminarTipoPermisos.Checked = permiso.Eliminar;
                        break;
                    case (int)Constantes.SubModulosNomina.TiposIdentificacion:
                        chkVerTipoIdentificacion.Checked = true;
                        chkInsertarTipoIdentificacion.Checked = permiso.Insertar;
                        chkModificarTipoIdentificacion.Checked = permiso.Modificar;
                        chkEliminarTipoIdentificacion.Checked = permiso.Eliminar;
                        break;
                    case (int)Constantes.SubModulosSeguridad.TiposPerfil:
                        chkVerTipoPerfil.Checked = true;
                        chkInsertarTipoPerfil.Checked = permiso.Insertar;
                        chkModificarTipoPerfil.Checked = permiso.Modificar;
                        chkEliminarTipoIdentificacion.Checked = permiso.Eliminar;
                        break;
                    case (int)Constantes.SubModulosSeguridad.PermisosSeguridad:
                        chkPermisosSeguridad.Checked = permiso.Modificar;
                        break;
                    case (int)Constantes.SubModulosSeguridad.UsuariosSeguridad:
                        chkVerUsuarioSeguridad.Checked = true;
                        chkInsertarUsuarioSeguridad.Checked = permiso.Insertar;
                        chkModificarUsuarioSeguridad.Checked = permiso.Modificar;
                        chkEliminarUsuarioSeguridad.Checked = permiso.Eliminar;
                        break;
                    case (int)Constantes.SubModulosVentas.Empresa:
                        chkVerEmpresas.Checked = true;
                        chkInsertarEmpresas.Checked = permiso.Insertar;
                        chkModificarEmpresas.Checked = permiso.Modificar;
                        chkEliminarEmpresas.Checked = permiso.Eliminar;
                        break;
                    case (int)Constantes.SubModulosVentas.SucursalesCajas:
                        chkVerSucursales.Checked = true;
                        chkInsertarSucursales.Checked = permiso.Insertar;
                        chkModificarSucursales.Checked = permiso.Modificar;
                        chkEliminarSucursales.Checked = permiso.Eliminar;
                        break;
                    case (int)Constantes.SubModulosVentas.Especialidades:
                        chkVerEspecialidades.Checked = true;
                        chkInsertarEspecialidades.Checked = permiso.Insertar;
                        chkModificarEspecialidades.Checked = permiso.Modificar;
                        chkEliminarEspecialidades.Checked = permiso.Eliminar;
                        break;
                    case (int)Constantes.SubModulosVentas.Citas:
                        chkVerCitas.Checked = true;
                        chkInsertarCitas.Checked = permiso.Insertar;
                        chkModificarCitas.Checked = permiso.Modificar;
                        chkEliminarCitas.Checked = permiso.Eliminar;
                        break;
                    case (int)Constantes.SubModulosVentas.Ventas:
                        chkVerVentas.Checked = true;
                        chkInsertarVentas.Checked = permiso.Insertar;
                        chkModificarVentas.Checked = permiso.Modificar;
                        chkEliminarVentas.Checked = permiso.Eliminar;
                        break;
                    case (int)Constantes.SubModulosVentas.ClientesMascotas:
                        chkVerCliente.Checked = true;
                        chkInsertarCliente.Checked = permiso.Insertar;
                        chkModificarCliente.Checked = permiso.Modificar;
                        chkEliminarCliente.Checked = permiso.Eliminar;
                        break;
                    case (int)Constantes.SubModulosVentas.EspecieRazas:
                        chkVerEspecie.Checked = true;
                        chkInsertarEspecie.Checked = permiso.Insertar;
                        chkModificarEspecie.Checked = permiso.Modificar;
                        chkEliminarEspecie.Checked = permiso.Eliminar;
                        break;
                }
            }
        }

        protected void gvTipoPerfil_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar" && IsPostBack)
            {
                int index = Convert.ToInt32(e.CommandArgument);
                if (gvTipoPerfil.SelectedIndex == index)
                {
                    gvTipoPerfil.SelectedIndex = -1;
                    btnEditar.Visible = false;
                    txtIdTipoPerfil.Text = "";
                }
                else
                {
                    gvTipoPerfil.SelectedIndex = index;
                    Permiso permiso = (Permiso)Session["PermisoPagina"];
                    if (permiso.Modificar)
                    {
                        btnEditar.Visible = true;
                    }

                    txtIdTipoPerfil.Text = gvTipoPerfil.SelectedRow.Cells[1].Text;
                    lblTipoPerfil.Text = gvTipoPerfil.SelectedRow.Cells[2].Text;
                }


            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblConfirmarTitle.Text = "Guardar Permisos de Seguridad";
            lblConfirmarbody.Text = "Desea Guardar los permisos del Perfil: " + lblTipoPerfil.Text + "?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalConfirmar", "$('#ModalConfirmar').modal();", true);
            UpdatePanelConfirmar.Update();
        }

        private void GuardarTipoPerfil()
        {
            string error = "";

            BLPermisosSeguridad bLPermisos = new BLPermisosSeguridad();
            List<PermisosSeguridad> permisosSeguridad = new List<PermisosSeguridad>();
            PermisosSeguridad permiso;

            #region Inventario
            if (chkVerArticulos.Checked 
                || chkInsertarArticulos.Checked
                || chkModificarArticulos.Checked
                || chkEliminarArticulos.Checked)
            {
                permiso = new PermisosSeguridad();
                permiso.IdTipoPerfil = Convert.ToInt32(txtIdTipoPerfil.Text);
                permiso.IdSubmodulo = (int)Constantes.SubModulosInventario.Productos;
                permiso.Insertar = chkInsertarArticulos.Checked;
                permiso.Modificar = chkModificarArticulos.Checked;
                permiso.Eliminar = chkEliminarArticulos.Checked;
                permisosSeguridad.Add(permiso);
            }

            if (chkVerMotivos.Checked
                || chkInsertarMotivos.Checked
                || chkModificarMotivos.Checked
                || chkEliminarMotivos.Checked)
            {
                permiso = new PermisosSeguridad();
                permiso.IdTipoPerfil = Convert.ToInt32(txtIdTipoPerfil.Text);
                permiso.IdSubmodulo = (int)Constantes.SubModulosInventario.MotivosMovimientos;
                permiso.Insertar = chkInsertarMotivos.Checked;
                permiso.Modificar = chkModificarMotivos.Checked;
                permiso.Eliminar = chkEliminarMotivos.Checked;
                permisosSeguridad.Add(permiso);
            }

            if (chkVerProveedores.Checked
                || chkInsertarProveedores.Checked
                || chkModificarProveedores.Checked
                || chkEliminarProveedores.Checked)
            {
                permiso = new PermisosSeguridad();
                permiso.IdTipoPerfil = Convert.ToInt32(txtIdTipoPerfil.Text);
                permiso.IdSubmodulo = (int)Constantes.SubModulosInventario.Proveedores;
                permiso.Insertar = chkInsertarProveedores.Checked;
                permiso.Modificar = chkModificarProveedores.Checked;
                permiso.Eliminar = chkEliminarProveedores.Checked;
                permisosSeguridad.Add(permiso);
            }

            if (chkVerTiposMovimientos.Checked
                || chkInsertarTiposMovimientos.Checked
                || chkModificarTiposMovimientos.Checked
                || chkEliminarTiposMovimientos.Checked)
            {
                permiso = new PermisosSeguridad();
                permiso.IdTipoPerfil = Convert.ToInt32(txtIdTipoPerfil.Text);
                permiso.IdSubmodulo = (int)Constantes.SubModulosInventario.TiposMovimientos;
                permiso.Insertar = chkInsertarTiposMovimientos.Checked;
                permiso.Modificar = chkModificarTiposMovimientos.Checked;
                permiso.Eliminar = chkEliminarTiposMovimientos.Checked;
                permisosSeguridad.Add(permiso);
            }

            if (chkVerIngreso.Checked
                || chkInsertarIngreso.Checked
                || chkModificarIngreso.Checked
                || chkEliminarIngreso.Checked)
            {
                permiso = new PermisosSeguridad();
                permiso.IdTipoPerfil = Convert.ToInt32(txtIdTipoPerfil.Text);
                permiso.IdSubmodulo = (int)Constantes.SubModulosInventario.IngresoListado;
                permiso.Insertar = chkInsertarIngreso.Checked;
                permiso.Modificar = chkModificarIngreso.Checked;
                permiso.Eliminar = chkEliminarIngreso.Checked;
                permisosSeguridad.Add(permiso);
            }

            if (chkVerDescontinuar.Checked
                || chkInsertarDescontinuar.Checked
                || chkModificarDescontinuar.Checked
                || chkEliminarDescontinuar.Checked)
            {
                permiso = new PermisosSeguridad();
                permiso.IdTipoPerfil = Convert.ToInt32(txtIdTipoPerfil.Text);
                permiso.IdSubmodulo = (int)Constantes.SubModulosInventario.DescontinuarProductos;
                permiso.Insertar = chkInsertarDescontinuar.Checked;
                permiso.Modificar = chkModificarDescontinuar.Checked;
                permiso.Eliminar = chkEliminarDescontinuar.Checked;
                permisosSeguridad.Add(permiso);
            }

            if (chkVerTransferencias.Checked
                || chkInsertarTransferencias.Checked
                || chkModificarTransferencias.Checked
                || chkEliminarTransferencias.Checked)
            {
                permiso = new PermisosSeguridad();
                permiso.IdTipoPerfil = Convert.ToInt32(txtIdTipoPerfil.Text);
                permiso.IdSubmodulo = (int)Constantes.SubModulosInventario.Transferencias;
                permiso.Insertar = chkInsertarTransferencias.Checked;
                permiso.Modificar = chkModificarTransferencias.Checked;
                permiso.Eliminar = chkEliminarTransferencias.Checked;
                permisosSeguridad.Add(permiso);
            }
            #endregion

            #region Nomina
            if (chkVerPlanilla.Checked
                || chkInsertarPlanilla.Checked
                || chkModificarPlanilla.Checked
                || chkEliminarPlanilla.Checked)
            {
                permiso = new PermisosSeguridad();
                permiso.IdTipoPerfil = Convert.ToInt32(txtIdTipoPerfil.Text);
                permiso.IdSubmodulo = (int)Constantes.SubModulosNomina.Planilla;
                permiso.Insertar = chkInsertarPlanilla.Checked;
                permiso.Modificar = chkModificarPlanilla.Checked;
                permiso.Eliminar = chkEliminarPlanilla.Checked;
                permisosSeguridad.Add(permiso);
            }

            if (chkVerMarcas.Checked
                || chkInsertarMarcas.Checked
                || chkModificarMarcas.Checked
                || chkEliminarMarcas.Checked)
            {
                permiso = new PermisosSeguridad();
                permiso.IdTipoPerfil = Convert.ToInt32(txtIdTipoPerfil.Text);
                permiso.IdSubmodulo = (int)Constantes.SubModulosNomina.Marcas;
                permiso.Insertar = chkInsertarMarcas.Checked;
                permiso.Modificar = chkModificarMarcas.Checked;
                permiso.Eliminar = chkEliminarMarcas.Checked;
                permisosSeguridad.Add(permiso);
            }

            if (chkVerPermisos.Checked
                || chkInsertarPermisos.Checked
                || chkModificarPermisos.Checked
                || chkEliminarPermisos.Checked)
            {
                permiso = new PermisosSeguridad();
                permiso.IdTipoPerfil = Convert.ToInt32(txtIdTipoPerfil.Text);
                permiso.IdSubmodulo = (int)Constantes.SubModulosNomina.Permisos;
                permiso.Insertar = chkInsertarPermisos.Checked;
                permiso.Modificar = chkModificarPermisos.Checked;
                permiso.Eliminar = chkEliminarPermisos.Checked;
                permisosSeguridad.Add(permiso);
            }

            if (chkVerTipoMarcas.Checked
                || chkInsertarTipoMarcas.Checked
                || chkModificarTipoMarcas.Checked
                || chkEliminarTipoMarcas.Checked)
            {
                permiso = new PermisosSeguridad();
                permiso.IdTipoPerfil = Convert.ToInt32(txtIdTipoPerfil.Text);
                permiso.IdSubmodulo = (int)Constantes.SubModulosNomina.TiposMarcas;
                permiso.Insertar = chkInsertarTipoMarcas.Checked;
                permiso.Modificar = chkModificarTipoMarcas.Checked;
                permiso.Eliminar = chkEliminarTipoMarcas.Checked;
                permisosSeguridad.Add(permiso);
            }

            if (chkVerTipoPermisos.Checked
                || chkInsertarTipoPermisos.Checked
                || chkModificarTipoPermisos.Checked
                || chkEliminarTipoPermisos.Checked)
            {
                permiso = new PermisosSeguridad();
                permiso.IdTipoPerfil = Convert.ToInt32(txtIdTipoPerfil.Text);
                permiso.IdSubmodulo = (int)Constantes.SubModulosNomina.TiposPermisos;
                permiso.Insertar = chkInsertarTipoPermisos.Checked;
                permiso.Modificar = chkModificarTipoPermisos.Checked;
                permiso.Eliminar = chkEliminarTipoPermisos.Checked;
                permisosSeguridad.Add(permiso);
            }

            if (chkVerTipoIdentificacion.Checked
                || chkInsertarTipoIdentificacion.Checked
                || chkModificarTipoIdentificacion.Checked
                || chkEliminarTipoIdentificacion.Checked)
            {
                permiso = new PermisosSeguridad();
                permiso.IdTipoPerfil = Convert.ToInt32(txtIdTipoPerfil.Text);
                permiso.IdSubmodulo = (int)Constantes.SubModulosNomina.TiposIdentificacion;
                permiso.Insertar = chkInsertarTipoIdentificacion.Checked;
                permiso.Modificar = chkModificarTipoIdentificacion.Checked;
                permiso.Eliminar = chkEliminarTipoIdentificacion.Checked;
                permisosSeguridad.Add(permiso);
            }
            #endregion

            #region Seguridad
            if (chkVerTipoPerfil.Checked
                || chkInsertarTipoPerfil.Checked
                || chkModificarTipoPerfil.Checked
                || chkEliminarTipoPerfil.Checked)
            {
                permiso = new PermisosSeguridad();
                permiso.IdTipoPerfil = Convert.ToInt32(txtIdTipoPerfil.Text);
                permiso.IdSubmodulo = (int)Constantes.SubModulosSeguridad.TiposPerfil;
                permiso.Insertar = chkInsertarTipoPerfil.Checked;
                permiso.Modificar = chkModificarTipoPerfil.Checked;
                permiso.Eliminar = chkEliminarTipoPerfil.Checked;
                permisosSeguridad.Add(permiso);
            }

            if (chkPermisosSeguridad.Checked)
            {
                permiso = new PermisosSeguridad();
                permiso.IdTipoPerfil = Convert.ToInt32(txtIdTipoPerfil.Text);
                permiso.IdSubmodulo = (int)Constantes.SubModulosSeguridad.PermisosSeguridad;
                permiso.Insertar = chkPermisosSeguridad.Checked;
                permiso.Modificar = chkPermisosSeguridad.Checked;
                permiso.Eliminar = chkPermisosSeguridad.Checked;
                permisosSeguridad.Add(permiso);
            }

            if (chkVerUsuarioSeguridad.Checked
                || chkInsertarUsuarioSeguridad.Checked
                || chkModificarUsuarioSeguridad.Checked
                || chkEliminarUsuarioSeguridad.Checked)
            {
                permiso = new PermisosSeguridad();
                permiso.IdTipoPerfil = Convert.ToInt32(txtIdTipoPerfil.Text);
                permiso.IdSubmodulo = (int)Constantes.SubModulosSeguridad.UsuariosSeguridad;
                permiso.Insertar = chkInsertarUsuarioSeguridad.Checked;
                permiso.Modificar = chkModificarUsuarioSeguridad.Checked;
                permiso.Eliminar = chkEliminarUsuarioSeguridad.Checked;
                permisosSeguridad.Add(permiso);
            }
            #endregion

            #region Ventas
            if (chkVerEmpresas.Checked
                || chkInsertarEmpresas.Checked
                || chkModificarEmpresas.Checked
                || chkEliminarEmpresas.Checked)
            {
                permiso = new PermisosSeguridad();
                permiso.IdTipoPerfil = Convert.ToInt32(txtIdTipoPerfil.Text);
                permiso.IdSubmodulo = (int)Constantes.SubModulosVentas.Empresa;
                permiso.Insertar = chkInsertarTipoPerfil.Checked;
                permiso.Modificar = chkModificarTipoPerfil.Checked;
                permiso.Eliminar = chkEliminarTipoPerfil.Checked;
                permisosSeguridad.Add(permiso);
            }

            if (chkVerSucursales.Checked
                || chkInsertarSucursales.Checked
                || chkModificarSucursales.Checked
                || chkEliminarSucursales.Checked)
            {
                permiso = new PermisosSeguridad();
                permiso.IdTipoPerfil = Convert.ToInt32(txtIdTipoPerfil.Text);
                permiso.IdSubmodulo = (int)Constantes.SubModulosVentas.SucursalesCajas;
                permiso.Insertar = chkInsertarSucursales.Checked;
                permiso.Modificar = chkModificarSucursales.Checked;
                permiso.Eliminar = chkEliminarSucursales.Checked;
                permisosSeguridad.Add(permiso);
            }

            if (chkVerEspecialidades.Checked
                || chkInsertarEspecialidades.Checked
                || chkModificarEspecialidades.Checked
                || chkEliminarEspecialidades.Checked)
            {
                permiso = new PermisosSeguridad();
                permiso.IdTipoPerfil = Convert.ToInt32(txtIdTipoPerfil.Text);
                permiso.IdSubmodulo = (int)Constantes.SubModulosVentas.Especialidades;
                permiso.Insertar = chkInsertarEspecialidades.Checked;
                permiso.Modificar = chkModificarEspecialidades.Checked;
                permiso.Eliminar = chkEliminarEspecialidades.Checked;
                permisosSeguridad.Add(permiso);
            }

            if (chkVerCitas.Checked
                || chkInsertarCitas.Checked
                || chkModificarCitas.Checked
                || chkEliminarCitas.Checked)
            {
                permiso = new PermisosSeguridad();
                permiso.IdTipoPerfil = Convert.ToInt32(txtIdTipoPerfil.Text);
                permiso.IdSubmodulo = (int)Constantes.SubModulosVentas.Citas;
                permiso.Insertar = chkInsertarCitas.Checked;
                permiso.Modificar = chkModificarCitas.Checked;
                permiso.Eliminar = chkEliminarCitas.Checked;
                permisosSeguridad.Add(permiso);
            }

            if (chkVerVentas.Checked
                || chkInsertarVentas.Checked
                || chkModificarVentas.Checked
                || chkEliminarVentas.Checked)
            {
                permiso = new PermisosSeguridad();
                permiso.IdTipoPerfil = Convert.ToInt32(txtIdTipoPerfil.Text);
                permiso.IdSubmodulo = (int)Constantes.SubModulosVentas.Ventas;
                permiso.Insertar = chkInsertarVentas.Checked;
                permiso.Modificar = chkModificarVentas.Checked;
                permiso.Eliminar = chkEliminarVentas.Checked;
                permisosSeguridad.Add(permiso);
            }

            if (chkVerCliente.Checked
                || chkInsertarCliente.Checked
                || chkModificarCliente.Checked
                || chkEliminarCliente.Checked)
            {
                permiso = new PermisosSeguridad();
                permiso.IdTipoPerfil = Convert.ToInt32(txtIdTipoPerfil.Text);
                permiso.IdSubmodulo = (int)Constantes.SubModulosVentas.ClientesMascotas;
                permiso.Insertar = chkInsertarCliente.Checked;
                permiso.Modificar = chkModificarCliente.Checked;
                permiso.Eliminar = chkEliminarCliente.Checked;
                permisosSeguridad.Add(permiso);
            }

            if (chkVerEspecie.Checked
                || chkInsertarEspecie.Checked
                || chkModificarEspecie.Checked
                || chkEliminarEspecie.Checked)
            {
                permiso = new PermisosSeguridad();
                permiso.IdTipoPerfil = Convert.ToInt32(txtIdTipoPerfil.Text);
                permiso.IdSubmodulo = (int)Constantes.SubModulosVentas.EspecieRazas;
                permiso.Insertar = chkInsertarEspecie.Checked;
                permiso.Modificar = chkModificarEspecie.Checked;
                permiso.Eliminar = chkEliminarEspecie.Checked;
                permisosSeguridad.Add(permiso);
            }
            #endregion

            bLPermisos.GuardarPermisos(permisosSeguridad, ref error);

            if (error == "")
            {
                Response.Redirect("frm_Permisos_Seguridad.aspx");

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
    }
}