<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="frm_VentaProducto.aspx.cs" Inherits="HappyPet4._0.Ventas.frm_VentaProducto" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="row">
        <div class="container well">
            <div class="col-lg-12">
                <h3 class="page-header"><i class="fa fa-shopping-cart"></i>Venta de Productos</h3>
            </div>
            <div class="form-group">
                <div class="col-sm-12">
                    <h4 class="col-sm-8 control-label">Cliente: </h4>
                </div>
                <div class="col-sm-12">
                    <div class="col-sm-3">
                        <label class="control-label">Identificación:</label>
                    </div>
                    <div class="col-sm-4">
                        <asp:TextBox class="form-control" runat="server" ID="txtIdentificacionCliente" />
                    </div>
                    <div class="col-sm-2">
                        <asp:ImageButton runat="server" ID="btnBuscarCliente" ToolTip="Buscar Cliente" ImageUrl="~/Imagenes/buscar.png" OnClick="btnBuscarCliente_Click" />
                        <asp:ImageButton runat="server" ID="btnClienteNuevo" ToolTip="Añadir Cliente" ImageUrl="~/Imagenes/anadir.png" OnClick="btnClienteNuevo_Click" />
                    </div>
                    <div class="col-sm-3">&nbsp</div>
                </div>
                <div class="col-sm-12">
                    <div class="col-sm-3">
                        <label class="control-label">Nombre:</label>
                    </div>
                    <div class="col-sm-6">
                        <asp:TextBox runat="server" class="form-control" ID="txtNombreCliente" />
                    </div>
                    <div class="col-sm-3">&nbsp</div>
                </div>
                <div class="col-sm-12">&nbsp</div>
                <div class="col-sm-12">
                    <div class="col-sm-3">
                        <label class="control-label">Caja:</label>
                    </div>
                    <div class="col-sm-3">
                        <asp:DropDownList runat="server" class="form-control" ID="ddlCajas" />
                    </div>
                    <div class="col-sm-6">&nbsp</div>
                </div>
                <div class="col-sm-12">&nbsp</div>
                <div class="col-sm-12">
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:Button runat="server" ID="btnAgregarProducto" Text="Agregar Producto" CssClass="btn btn-success" OnClick="btnAgregarProducto_Click" />
                        </div>
                        <div class="col-sm-3">
                            <asp:Button runat="server" ID="btnEditarProducto" Text="Editar Producto" CssClass="btn btn-warning" OnClick="btnEditarProducto_Click" />
                        </div>
                        <div class="col-sm-3">
                            &nbsp
                        </div>
                        <div class="col-sm-3">
                            <asp:Button runat="server" ID="btnEliminarProductos" Text="Eliminar Producto" CssClass="btn btn-danger" OnClick="btnEliminarProductos_Click" />
                        </div>
                        <div class="col-sm-12">
                            &nbsp
                        </div>
                        <div class="col-sm-12">
                            <asp:GridView runat="server" CssClass="box" Width="100%" ID="gvProductos" OnRowCommand="gvProductos_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None" AllowSorting="True">
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
                        <div class="col-sm-12">&nbsp</div>
                        <div class="col-sm-12">&nbsp</div>
                        <div class="col-sm-6">
                            &nbsp
                        </div>
                        <div class="col-sm-3">
                            <label class="control-label">Subtotal:</label>
                        </div>
                        <div class="col-sm-3">
                            <asp:TextBox runat="server" class="form-control" ReadOnly="true" ID="txtSubtotal" />
                        </div>
                        <div class="col-sm-6">
                            &nbsp
                        </div>
                        <div class="col-sm-3">
                            <label class="control-label">Descuento:</label>
                        </div>
                        <div class="col-sm-3">
                            <asp:TextBox runat="server" class="form-control" ReadOnly="true" ID="txtTotalDescuento" />
                        </div>
                        <div class="col-sm-6">
                            &nbsp
                        </div>
                        <div class="col-sm-3">
                            <label class="control-label">Impuesto:</label>
                        </div>
                        <div class="col-sm-3">
                            <asp:TextBox runat="server" class="form-control" ReadOnly="true" ID="txtTotalImpuesto" />
                        </div>
                        <div class="col-sm-6">
                            &nbsp
                        </div>
                        <div class="col-sm-6">
                            <hr style="border-top: 2px solid">
                        </div>
                        <div class="col-sm-6">
                            &nbsp
                        </div>
                        <div class="col-sm-3">
                            <label class="control-label">Total:</label>
                        </div>
                        <div class="col-sm-3">
                            <asp:TextBox runat="server" class="form-control" ReadOnly="true" ID="txtTotal" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="ModalProductos" role="dialog" aria-labelledby="ModalProductosLabel" aria-hidden="true">
        <div class="modal-dialog">
            <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title">
                                <asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label></h4>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="form-group">
                                    <div class="col-sm-12">
                                        <asp:Label runat="server" Text="Producto:" />
                                    </div>
                                    <div class="col-sm-12">
                                        <div class="col-sm-6">
                                            <asp:Label runat="server" Text="Código:" />
                                        </div>
                                        <div class="col-sm-4">
                                            <asp:TextBox CssClass="form-control" TextMode="Number" runat="server" ID="txtCodigo" />
                                        </div>
                                        <div class="col-sm-2">
                                            <asp:ImageButton runat="server" ID="btnBuscarProducto" ToolTip="Buscar Producto" ImageUrl="~/Imagenes/buscar.png" OnClick="btnBuscarProducto_Click" />
                                        </div>
                                    </div>
                                    <div class="col-sm-12">
                                        <div class="col-sm-6">
                                            <asp:Label runat="server" Text="Descripción:" />
                                        </div>
                                        <div class="col-sm-6">
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtDescripcion" />
                                        </div>
                                    </div>
                                    <div class="col-sm-12">
                                        <div class="col-sm-6">
                                            <asp:Label runat="server" Text="Cantidad:" />
                                        </div>
                                        <div class="col-sm-6">
                                            <asp:TextBox CssClass="form-control" OnTextChanged="txtCantidad_TextChanged" Text="0" TextMode="Number" runat="server" ID="txtCantidad" />
                                        </div>
                                    </div>
                                    <div class="col-sm-12">
                                        <div class="col-sm-6">
                                            <asp:Label runat="server" Text="Precio:" />
                                        </div>
                                        <div class="col-sm-6">
                                            <asp:TextBox CssClass="form-control" TextMode="Number" Text="0" OnTextChanged="txtPrecio_TextChanged" runat="server" ID="txtPrecio" />
                                        </div>
                                    </div>
                                    <div class="col-sm-12">
                                        <div class="col-sm-6">
                                            <asp:Label runat="server" Text="Porcentaje de Impuesto:" />
                                        </div>
                                        <div class="col-sm-6">
                                            <asp:TextBox CssClass="form-control" TextMode="Number" OnTextChanged="txtImpuesto_TextChanged" Text="0" runat="server" ID="txtImpuesto" />
                                        </div>
                                    </div>
                                    <div class="col-sm-12">
                                        <div class="col-sm-6">
                                            <asp:Label runat="server" Text="Porcentaje de Descuento:" />
                                        </div>
                                        <div class="col-sm-6">
                                            <asp:TextBox CssClass="form-control" TextMode="Number" OnTextChanged="txtDescuento_TextChanged" Text="0" runat="server" ID="txtDescuento" />
                                        </div>
                                    </div>
                                    <div class="col-sm-12">
                                        <div class="col-sm-6">
                                            <asp:Label runat="server" Text="Subtotal:" />
                                        </div>
                                        <div class="col-sm-6">
                                            <asp:TextBox CssClass="form-control" TextMode="Number" ReadOnly="true" runat="server" ID="txtSubtotalLinea" />
                                        </div>
                                    </div>
                                    <div class="col-sm-12">
                                        <div class="col-sm-6">
                                            <asp:Label runat="server" Text="TotalDescuento:" />
                                        </div>
                                        <div class="col-sm-6">
                                            <asp:TextBox CssClass="form-control" TextMode="Number" ReadOnly="true" runat="server" ID="txtTotalDescuentoLinea" />
                                        </div>
                                    </div>
                                    <div class="col-sm-12">
                                        <div class="col-sm-6">
                                            <asp:Label runat="server" Text="TotalImpuesto:" />
                                        </div>
                                        <div class="col-sm-6">
                                            <asp:TextBox CssClass="form-control" TextMode="Number" ReadOnly="true" runat="server" ID="txtTotalImpuestoLinea" />
                                        </div>
                                    </div>
                                    <div class="col-sm-12">
                                        <div class="col-sm-6">
                                            <asp:Label runat="server" Text="TotalLinea:" />
                                        </div>
                                        <div class="col-sm-6">
                                            <asp:TextBox CssClass="form-control" TextMode="Number" ReadOnly="true" runat="server" ID="txtTotalLinea" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <div class="col-sm-6">
                                <asp:Button runat="server" ID="btnGuardarProducto" Text="Guardar" OnClick="btnGuardarProducto_Click" class="btn btn-success" data-dismiss="modal" aria-hidden="true" />
                            </div>
                            <div class="col-sm-6">
                                <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Cancelar</button>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <div class="modal fade" id="ModalEliminar" role="dialog" aria-labelledby="ModalEliminarLabel" aria-hidden="true">
        <div class="modal-dialog">
            <asp:UpdatePanel ID="UpdatePanelEliminar" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title">
                                <asp:Label ID="lblEliminarTitle" runat="server" Text=""></asp:Label></h4>
                        </div>
                        <div class="modal-body">
                            <asp:Label ID="lblEliminarbody" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="modal-footer">
                            <button class="btn btn-danger" data-dismiss="modal" aria-hidden="true">Eliminar</button>
                            <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Salir</button>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
