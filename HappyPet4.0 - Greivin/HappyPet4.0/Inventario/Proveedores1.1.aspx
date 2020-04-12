<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Proveedores1.1.aspx.cs" Inherits="HappyPet4._0.Proveedores1__1" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <div class="row">
        <div class="container well">
            <div class="col-lg-12">
                <h3 class="page-header"><i class="fa fa-file-text-o"></i>Proveedores</h3>
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
                                    <asp:Button runat="server" ID="btnAgregar" Text="Agregar Proveedor" CssClass="btn btn-success" OnClick="btnAgregar_Click" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:Button runat="server" ID="btnEditar" Text="Editar Proveedor" CssClass="btn btn-warning" OnClick="btnEditar_Click" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:Button runat="server" ID="btnEliminar" Text="Eliminar Proveedor" CssClass="btn btn-danger" OnClick="btnEliminar_Click" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:Button runat="server" ID="btnAtenderCita" Text="Atender cita" CssClass="btn btn-info" OnClick="btnAtenderCita_Click" />
                                </div>
                                <div class="col-sm-12">
                                    &nbsp
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-12">
                            <asp:GridView runat="server" style="align-content:center" CssClass="box" Width="100%" ID="gvCitas" OnRowCommand="gvCitas_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None" AllowSorting="True">
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

    <div class="modal fade" id="ModalProveedores" role="dialog" aria-labelledby="ModalProveedoresLabel" aria-hidden="true">
        <div class="modal-dialog  modal-lg" style="width: 80%">
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
                                <div class="form-control">
                                    <div class="row ">

                                        <div class="col-lg-5">
                                            <label id="lblIdProveedor" class="control-label">Identificación: </label>
                                            <%--<asp:Label ID="lblIdProveedor" runat="server" Text="Id Proveedor: "></asp:Label>--%>
                                            <asp:TextBox ID="txtIdProveedor" runat="server"></asp:TextBox>
                                        </div>

                                        <div class="col-md-5">
                                            <label id="lblTipoIdentificacion" class="control-label">Identificación: </label>
                                            <asp:DropDownList runat="server" ID="ddlTipoIdientificacion">
                                                <asp:ListItem Text="Cédula Jurídica" Value="0" />
                                                <asp:ListItem Text="Cédula Física" Value="1" />
                                                <asp:ListItem Text="DIMEX" Value="2" />
                                                <asp:ListItem Text="NITE" Value="2" />
                                            </asp:DropDownList>
                                        </div>

                                        <div class="col-lg-2 text-md-right">
                                            <label id="lblActivo" class="control-label">Activo: </label>
                                            <asp:CheckBox ID="CheckBox1" runat="server" />
                                        </div>

                                    </div>

                                    <hr />
                                    <br />
                                    <div class="row">
                                        <div class="col-md-4">
                                            <label class="control-label">Nombre Empresa / Persona: </label>
                                            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4">
                                            <label class="control-label">Primer Apellido: </label>
                                            <asp:TextBox ID="txtApellido1" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4">
                                            <label class="control-label">Segundo Apellido: </label>
                                            <asp:TextBox ID="txtApellido2" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <br />
                                    <br />
                                    <br />
                                    <div class="row">
                                        <div class="col-md-4">
                                            <label class="control-label">Email: </label>
                                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4">
                                            <label class="control-label">Numero Telefono 1: </label>
                                            <asp:TextBox ID="txtNumTelefono1" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4">
                                            <label class="control-label">Numero Telefono 2: </label>
                                            <asp:TextBox ID="txtNumTel2" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-lg-12">&nbsp</div>
                                    <div class="col-lg-12">&nbsp</div>
                                    <div class="col-lg-12">&nbsp</div>
                                    
                                    <div class="modal-footer">
                            <div class="col-sm-6">
                                <asp:Button runat="server" ID="btnGuardarCita" Text="Guardar" OnClick="btnGuardarCita_Click" class="btn btn-success" data-dismiss="modal" aria-hidden="true" />
                            </div>
                            <div class="col-sm-6">
                                <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Cancelar</button>
                            </div>
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