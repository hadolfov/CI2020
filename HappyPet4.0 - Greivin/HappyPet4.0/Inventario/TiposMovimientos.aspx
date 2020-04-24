<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TiposMovimientos.aspx.cs" Inherits="HappyPet4._0.Inventario.TiposMovimientos" %>--%>
<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TiposMovimientos.aspx.cs" Inherits="HappyPet4._0.Inventario.TiposMovimientos" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div class="row">
        <div class="container well">
            <div class="col-lg-12">
                <h3 class="page-header"><i class="fa fa-file-text-o">&nbsp</i>TiposMovimientos</h3>
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
                                    <asp:Button runat="server" ID="btnAgregar" Text="Agregar TipoMovimiento " CssClass="btn btn-success" OnClick="btnAgregar_Click" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:Button runat="server" ID="btnEditar" Text="Editar TipoMovimiento" CssClass="btn btn-warning" OnClick="btnEditar_Click" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:Button runat="server" ID="btnEliminar" Text="Eliminar TipoMovimiento" CssClass="btn btn-danger" OnClick="btnEliminar_Click" />
                                </div>

                                <div class="col-sm-12">
                                    &nbsp
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-12">
                            <asp:GridView runat="server" Style="align-content: center" CssClass="box" Width="100%" ID="gvTiposMovimientos" OnRowCommand="gvTiposMovimientos_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None" AllowSorting="True">
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


    <div class="modal fade" id="ModalTiposMovimientos" role="dialog" aria-labelledby="ModalTiposMovimientosLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" style="width: 80%">
            <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content " >
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title">
                                <asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label></h4>
                        </div>
                        <div class="modal-body">
                            <div class="row">


                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label">Id TipoMovimiento: </label>
                                        
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="txtIdTipoMovimiento" runat="server" CssClass="form-control" MaxLength="50" ReadOnly="True"></asp:TextBox>
                                            <!--<input type="text" maxlength="50" class="form-control"/>  -->
                                        </div>
                                    </div>
                                </div>
                                
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <asp:CheckBox ID="chkb_Activo" runat="server" />
                                        <asp:Label ID="Label1" runat="server" Text="Activo"></asp:Label>
                                        
                                        <!--<input type="text" maxlength="50" class="form-control"/>  -->
                                    </div>
                                </div>
                               
                                <hr />
                                <br />
                                 <div class="col-lg-6">
                                     <div class="form-group">
                                         <label class="col-sm-2 control-label">Tipo Movimientos: </label>
                                         
                                         <div class="col-sm-10">
                                             <asp:TextBox ID="txtTipoMovimiento" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                             <!-- <input type="text" maxlength="50" class="form-control"/> -->
                                         </div>
                                     </div>
                                 </div>

                                 

                                <div class="col-lg-12">&nbsp</div>
                                
                                
                                <div class="col-lg-12">&nbsp</div>
                                <div class="col-lg-6">
                                    
                                </div>
                                <div class="col-lg-12">&nbsp</div>
                                <div class="col-lg-12">&nbsp</div>
                                <div class="col-lg-12">&nbsp</div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <asp:Button ID="btnLimpiar" class="btn btn-warning" runat="server" Text="Limpiar" />
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
                            <asp:Button ID="btnEliminarConfirmacion" OnClick="btnEliminarConfirmacion_Click" class="btn btn-danger" runat="server" Text="Eliminar" />
                            <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Salir</button>
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


