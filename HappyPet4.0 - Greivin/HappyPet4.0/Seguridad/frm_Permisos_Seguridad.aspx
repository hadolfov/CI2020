<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_Permisos_Seguridad.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="HappyPet4._0.Seguridad.frm_Permisos_Seguridad" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div class="row">
        <div class="container well">
            <div class="col-lg-12">
                <h3 class="page-header"><i class="fa fa-file-text-o">&nbsp</i>Tipos de Perfil</h3>
            </div>

            <div class="col-lg-12">
                <div class="col-lg-12">&nbsp</div>
                <div class="col-lg-12">&nbsp</div>
                <div class="col-lg-12">
                    <div class="form-group">
                        <label class="col-sm-2 control-label"></label>
                        <div class="col-sm-10">
                            <div class="row">
                                <div class="col-sm-3">
                                    <asp:Button runat="server" ID="btnEditar" Text="Editar Permisos" CssClass="btn btn-warning" OnClick="btnEditar_Click" />
                                </div>
                                <div class="col-sm-9">
                                    &nbsp
                                </div>
                                <div class="col-sm-12">
                                    &nbsp
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-12">
                            <asp:GridView runat="server" Style="align-content: center" CssClass="box" Width="100%" ID="gvTipoPerfil" OnRowCommand="gvTipoPerfil_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None" AllowSorting="True">
                                <AlternatingRowStyle BackColor="White" BorderColor="#999999" BorderStyle="Solid" />
                                <Columns>
                                    <asp:ButtonField ButtonType="Image" HeaderText="Acción" CommandName="Seleccionar" ImageUrl="~/Imagenes/share.png" />
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#3C8DBC" BorderStyle="Solid" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div class="modal fade" id="ModalTipoPerfil" role="dialog" aria-labelledby="ModalTipoPerfilLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" style="width: 80%">
            <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content" >
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title">
                                <asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label></h4>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-sm-12" >
                                    <asp:TextBox Id="txtIdTipoPerfil" runat="server" Visible ="false" />
                                    <asp:label Id="lblTipoPerfil" runat="server" Font-Bold="true" />
                                </div>
                                <div class="col-sm-12" >&nbsp</div>
                                <label class="col-sm-12 control-label">Inventario </label>
                                <div class="col-sm-12" ><hr /></div>
                                <label class="col-sm-12 control-label">Artículos </label>
                                <div class="col-sm-3" >
                                    <label>Ver</label>
                                    <asp:CheckBox runat="server" ID="chkVerArticulos" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Insertar</label>
                                    <asp:CheckBox runat="server" ID="chkInsertarArticulos" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Modificar</label>
                                    <asp:CheckBox runat="server" ID="chkModificarArticulos" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Eliminar</label>
                                    <asp:CheckBox runat="server" ID="chkEliminarArticulos" />
                                </div>
                                <div class="col-sm-12" ><hr /></div>
                                <label class="col-sm-12 control-label">Motivos de Movimientos </label>
                                <div class="col-sm-3" >
                                    <label>Ver</label>
                                    <asp:CheckBox runat="server" ID="chkVerMotivos" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Insertar</label>
                                    <asp:CheckBox runat="server" ID="chkInsertarMotivos" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Modificar</label>
                                    <asp:CheckBox runat="server" ID="chkModificarMotivos" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Eliminar</label>
                                    <asp:CheckBox runat="server" ID="chkEliminarMotivos" />
                                </div>
                                <div class="col-sm-12" ><hr /></div>
                                <label class="col-sm-12 control-label">Proveedores</label>
                                <div class="col-sm-3" >
                                    <label>Ver</label>
                                    <asp:CheckBox runat="server" ID="chkVerProveedores" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Insertar</label>
                                    <asp:CheckBox runat="server" ID="chkInsertarProveedores" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Modificar</label>
                                    <asp:CheckBox runat="server" ID="chkModificarProveedores" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Eliminar</label>
                                    <asp:CheckBox runat="server" ID="chkEliminarProveedores" />
                                </div>
                                <div class="col-sm-12" ><hr /></div>
                                <label class="col-sm-12 control-label">Tipos Movimientos</label>
                                <div class="col-sm-3" >
                                    <label>Ver</label>
                                    <asp:CheckBox runat="server" ID="chkVerTiposMovimientos" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Insertar</label>
                                    <asp:CheckBox runat="server" ID="chkInsertarTiposMovimientos" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Modificar</label>
                                    <asp:CheckBox runat="server" ID="chkModificarTiposMovimientos" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Eliminar</label>
                                    <asp:CheckBox runat="server" ID="chkEliminarTiposMovimientos" />
                                </div>
                                <div class="col-sm-12" ><hr /></div>
                                <label class="col-sm-12 control-label">Ingreso y Listados</label>
                                <div class="col-sm-3" >
                                    <label>Ver</label>
                                    <asp:CheckBox runat="server" ID="chkVerIngreso" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Insertar</label>
                                    <asp:CheckBox runat="server" ID="chkInsertarIngreso" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Modificar</label>
                                    <asp:CheckBox runat="server" ID="chkModificarIngreso" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Eliminar</label>
                                    <asp:CheckBox runat="server" ID="chkEliminarIngreso" />
                                </div>
                                <div class="col-sm-12" ><hr /></div>
                                <label class="col-sm-12 control-label">Descontinuar Productos</label>
                                <div class="col-sm-3" >
                                    <label>Ver</label>
                                    <asp:CheckBox runat="server" ID="chkVerDescontinuar" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Insertar</label>
                                    <asp:CheckBox runat="server" ID="chkInsertarDescontinuar" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Modificar</label>
                                    <asp:CheckBox runat="server" ID="chkModificarDescontinuar" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Eliminar</label>
                                    <asp:CheckBox runat="server" ID="chkEliminarDescontinuar" />
                                </div>
                                <div class="col-sm-12" ><hr /></div>
                                <label class="col-sm-12 control-label">Transferencias de Inventario</label>
                                <div class="col-sm-3" >
                                    <label>Ver</label>
                                    <asp:CheckBox runat="server" ID="chkVerTransferencias" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Insertar</label>
                                    <asp:CheckBox runat="server" ID="chkInsertarTransferencias" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Modificar</label>
                                    <asp:CheckBox runat="server" ID="chkModificarTransferencias" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Eliminar</label>
                                    <asp:CheckBox runat="server" ID="chkEliminarTransferencias" />
                                </div>
                                <div class="col-sm-12" ><hr /></div>
                                <div class="col-sm-12" >&nbsp</div>
                                <label class="col-sm-12 control-label">Nómina </label>
                                <div class="col-sm-12" ><hr /></div>
                                <label class="col-sm-12 control-label">Planilla </label>
                                <div class="col-sm-3" >
                                    <label>Ver</label>
                                    <asp:CheckBox runat="server" ID="chkVerPlanilla" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Insertar</label>
                                    <asp:CheckBox runat="server" ID="chkInsertarPlanilla" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Modificar</label>
                                    <asp:CheckBox runat="server" ID="chkModificarPlanilla" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Eliminar</label>
                                    <asp:CheckBox runat="server" ID="chkEliminarPlanilla" />
                                </div>
                                <div class="col-sm-12" ><hr /></div>
                                <label class="col-sm-12 control-label">Marcas </label>
                                <div class="col-sm-3" >
                                    <label>Ver</label>
                                    <asp:CheckBox runat="server" ID="chkVerMarcas" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Insertar</label>
                                    <asp:CheckBox runat="server" ID="chkInsertarMarcas" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Modificar</label>
                                    <asp:CheckBox runat="server" ID="chkModificarMarcas" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Eliminar</label>
                                    <asp:CheckBox runat="server" ID="chkEliminarMarcas" />
                                </div>
                                <div class="col-sm-12" ><hr /></div>
                                <label class="col-sm-12 control-label">Permisos</label>
                                <div class="col-sm-3" >
                                    <label>Ver</label>
                                    <asp:CheckBox runat="server" ID="chkVerPermisos" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Insertar</label>
                                    <asp:CheckBox runat="server" ID="chkInsertarPermisos" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Modificar</label>
                                    <asp:CheckBox runat="server" ID="chkModificarPermisos" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Eliminar</label>
                                    <asp:CheckBox runat="server" ID="chkEliminarPermisos" />
                                </div>
                                <div class="col-sm-12" ><hr /></div>
                                <label class="col-sm-12 control-label">Tipos Marcas</label>
                                <div class="col-sm-3" >
                                    <label>Ver</label>
                                    <asp:CheckBox runat="server" ID="chkVerTipoMarcas" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Insertar</label>
                                    <asp:CheckBox runat="server" ID="chkInsertarTipoMarcas" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Modificar</label>
                                    <asp:CheckBox runat="server" ID="chkModificarTipoMarcas" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Eliminar</label>
                                    <asp:CheckBox runat="server" ID="chkEliminarTipoMarcas" />
                                </div>
                                <div class="col-sm-12" ><hr /></div>
                                <label class="col-sm-12 control-label">Tipos Permisos</label>
                                <div class="col-sm-3" >
                                    <label>Ver</label>
                                    <asp:CheckBox runat="server" ID="chkVerTipoPermisos" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Insertar</label>
                                    <asp:CheckBox runat="server" ID="chkInsertarTipoPermisos" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Modificar</label>
                                    <asp:CheckBox runat="server" ID="chkModificarTipoPermisos" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Eliminar</label>
                                    <asp:CheckBox runat="server" ID="chkEliminarTipoPermisos" />
                                </div>
                                <div class="col-sm-12" ><hr /></div>
                                <label class="col-sm-12 control-label">Tipos Identificación</label>
                                <div class="col-sm-3" >
                                    <label>Ver</label>
                                    <asp:CheckBox runat="server" ID="chkVerTipoIdentificacion" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Insertar</label>
                                    <asp:CheckBox runat="server" ID="chkInsertarTipoIdentificacion" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Modificar</label>
                                    <asp:CheckBox runat="server" ID="chkModificarTipoIdentificacion" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Eliminar</label>
                                    <asp:CheckBox runat="server" ID="chkEliminarTipoIdentificacion" />
                                </div>
                                <div class="col-sm-12" ><hr /></div>
                                <div class="col-sm-12" >&nbsp</div>
                                <label class="col-sm-12 control-label">Seguridad </label>
                                <div class="col-sm-12" ><hr /></div>
                                <label class="col-sm-12 control-label">Tipo Perfil </label>
                                <div class="col-sm-3" >
                                    <label>Ver</label>
                                    <asp:CheckBox runat="server" ID="chkVerTipoPerfil" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Insertar</label>
                                    <asp:CheckBox runat="server" ID="chkInsertarTipoPerfil" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Modificar</label>
                                    <asp:CheckBox runat="server" ID="chkModificarTipoPerfil" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Eliminar</label>
                                    <asp:CheckBox runat="server" ID="chkEliminarTipoPerfil" />
                                </div>
                                <div class="col-sm-12" ><hr /></div>
                                <label class="col-sm-12 control-label">Permisos Seguridad</label>
                                <div class="col-sm-3" >
                                    <label class="control-label">Asignar</label>
                                    <asp:CheckBox runat="server" ID="chkPermisosSeguridad" />
                                </div>
                                <div class="col-sm-3" >
                                    &nbsp
                                </div>
                                <div class="col-sm-3" >
                                    &nbsp
                                </div>
                                <div class="col-sm-3" >
                                    &nbsp
                                </div>
                                <div class="col-sm-12" ><hr /></div>
                                <label class="col-sm-12 control-label">Usuario Seguridad</label>
                                <div class="col-sm-3" >
                                    <label>Ver</label>
                                    <asp:CheckBox runat="server" ID="chkVerUsuarioSeguridad" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Insertar</label>
                                    <asp:CheckBox runat="server" ID="chkInsertarUsuarioSeguridad" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Modificar</label>
                                    <asp:CheckBox runat="server" ID="chkModificarUsuarioSeguridad" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Eliminar</label>
                                    <asp:CheckBox runat="server" ID="chkEliminarUsuarioSeguridad" />
                                </div>
                                 <div class="col-sm-12" ><hr /></div>
                                <div class="col-sm-12" >&nbsp</div>
                                <label class="col-sm-12 control-label">Ventas </label>
                                <div class="col-sm-12" ><hr /></div>
                                <label class="col-sm-12 control-label">Empresas </label>
                                <div class="col-sm-3" >
                                    <label>Ver</label>
                                    <asp:CheckBox runat="server" ID="chkVerEmpresas" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Insertar</label>
                                    <asp:CheckBox runat="server" ID="chkInsertarEmpresas" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Modificar</label>
                                    <asp:CheckBox runat="server" ID="chkModificarEmpresas" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Eliminar</label>
                                    <asp:CheckBox runat="server" ID="chkEliminarEmpresas" />
                                </div>
                                <div class="col-sm-12" ><hr /></div>
                                <label class="col-sm-12 control-label">Sucursales y Cajas</label>
                                <div class="col-sm-3" >
                                    <label>Ver</label>
                                    <asp:CheckBox runat="server" ID="chkVerSucursales" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Insertar</label>
                                    <asp:CheckBox runat="server" ID="chkInsertarSucursales" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Modificar</label>
                                    <asp:CheckBox runat="server" ID="chkModificarSucursales" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Eliminar</label>
                                    <asp:CheckBox runat="server" ID="chkEliminarSucursales" />
                                </div>
                                <div class="col-sm-12" ><hr /></div>
                                <label class="col-sm-12 control-label">Especialidades</label>
                                <div class="col-sm-3" >
                                    <label>Ver</label>
                                    <asp:CheckBox runat="server" ID="chkVerEspecialidades" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Insertar</label>
                                    <asp:CheckBox runat="server" ID="chkInsertarEspecialidades" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Modificar</label>
                                    <asp:CheckBox runat="server" ID="chkModificarEspecialidades" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Eliminar</label>
                                    <asp:CheckBox runat="server" ID="chkEliminarEspecialidades" />
                                </div>
                                <div class="col-sm-12" ><hr /></div>
                                <label class="col-sm-12 control-label">Citas</label>
                                <div class="col-sm-3" >
                                    <label>Ver</label>
                                    <asp:CheckBox runat="server" ID="chkVerCitas" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Insertar</label>
                                    <asp:CheckBox runat="server" ID="chkInsertarCitas" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Modificar</label>
                                    <asp:CheckBox runat="server" ID="chkModificarCitas" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Eliminar</label>
                                    <asp:CheckBox runat="server" ID="chkEliminarCitas" />
                                </div>
                                <div class="col-sm-12" ><hr /></div>
                                <label class="col-sm-12 control-label">Ventas</label>
                                <div class="col-sm-3" >
                                    <label>Ver</label>
                                    <asp:CheckBox runat="server" ID="chkVerVentas" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Insertar</label>
                                    <asp:CheckBox runat="server" ID="chkInsertarVentas" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Modificar</label>
                                    <asp:CheckBox runat="server" ID="chkModificarVentas" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Eliminar</label>
                                    <asp:CheckBox runat="server" ID="chkEliminarVentas" />
                                </div>
                                <div class="col-sm-12" ><hr /></div>
                                <label class="col-sm-12 control-label">Cliente y MAscotas</label>
                                <div class="col-sm-3" >
                                    <label>Ver</label>
                                    <asp:CheckBox runat="server" ID="chkVerCliente" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Insertar</label>
                                    <asp:CheckBox runat="server" ID="chkInsertarCliente" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Modificar</label>
                                    <asp:CheckBox runat="server" ID="chkModificarCliente" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Eliminar</label>
                                    <asp:CheckBox runat="server" ID="chkEliminarCliente" />
                                </div>
                                <div class="col-sm-12" ><hr /></div>
                                <label class="col-sm-12 control-label">Especie y Razas</label>
                                <div class="col-sm-3" >
                                    <label>Ver</label>
                                    <asp:CheckBox runat="server" ID="chkVerEspecie" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Insertar</label>
                                    <asp:CheckBox runat="server" ID="chkInsertarEspecie" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Modificar</label>
                                    <asp:CheckBox runat="server" ID="chkModificarEspecie" />
                                </div>
                                <div class="col-sm-3" >
                                    <label>Eliminar</label>
                                    <asp:CheckBox runat="server" ID="chkEliminarEspecie" />
                                </div>
                                <div class="col-sm-12" ><hr /></div>
                                <div class="col-sm-12" >&nbsp</div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <asp:Button ID="btnCancelar"  data-dismiss="modal" class="btn btn-danger" runat="server" Text="Cancelar" />
                                        <!--<button type="button" class="btn btn-warning">Limpiar</button>-->
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <asp:Button ID="btnGuardar" OnClick="btnGuardar_Click" class="btn btn-success" runat="server" Text="Guardar" />
                                        <!-- <button type="button" class="btn btn-success">Guardar</button> -->
                                    </div>
                                </div>


                            </div>
                        </div>
                    </div>

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <div class="modal fade" id="ModalConfirmar" role="dialog" aria-labelledby="ModalConfirmarLabel" aria-hidden="true">
        <div class="modal-dialog">
            <asp:UpdatePanel ID="UpdatePanelConfirmar" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title">
                                <asp:Label ID="lblConfirmarTitle" runat="server" Text=""></asp:Label></h4>
                        </div>
                        <div class="modal-body">
                            <asp:Label ID="lblConfirmarbody" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnGuardarConfirmacion" OnClick="btnGuardarConfirmacion_Click" class="btn btn-success" runat="server" Text="Guardar" />
                            <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Salir</button>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>


</asp:Content>
