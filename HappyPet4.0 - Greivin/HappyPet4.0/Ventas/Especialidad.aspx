<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Especialidad.aspx.cs" Inherits="HappyPet4._0.Ventas.Especialidad" %>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div class="row">
        <div class="container well">
            <div class="col-lg-12">
                <h3 class="page-header"><i class="fa fa-file-text-o">&nbsp</i>Especialidad</h3>
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
                                    <asp:Button runat="server" ID="btnAgregar" Text="Agregar Especialidad " CssClass="btn btn-success" OnClick="btnAgregar_Click" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:Button runat="server" ID="btnEditar" Text="Editar Especialidad " CssClass="btn btn-warning" OnClick="btnEditar_Click" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:Button runat="server" ID="btnEliminar" Text="Eliminar Especialidad" CssClass="btn btn-danger" OnClick="btnEliminar_Click" />
                                </div>

                                <div class="col-sm-12">
                                    &nbsp
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-12">
                            <asp:GridView runat="server" Style="align-content: center" CssClass="box" Width="100%" ID="gvEspecialidad" OnRowCommand="gvEspecialidad_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None" AllowSorting="True">
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


        <div class="modal fade" id="ModalEspecialidad" role="dialog" aria-labelledby="ModalEspecialidadLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg ">
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
                                <div class="col-md-8">
                                    <div class="form-group">
                                    <label class="col-sm-2 control-label">Id Especialidad: </label>
                                     <div class="col-sm-10">
                                     <asp:TextBox ID="txtIdEspecialidad" runat="server" CssClass="form-control" MaxLength="50" ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <asp:CheckBox ID="chkEstado" runat="server" />
                                            <asp:Label ID="Label1" runat="server" Text="Activo"></asp:Label>
                                            <!--<input type="text" maxlength="50" class="form-control"/>  -->
                                            </div>
                                    </div>
                                <br />
                                <br />
                                <hr />
                                     <div class="col-lg-6">
                                     <div class="form-group">
                                         <label class="col-sm-4 control-label">Especialidad : </label>
                                         
                                            <div class="col-sm-10">
                                             <asp:TextBox ID="txtEspecialidad" placeholder="Especialidad" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                         </div>
                                     </div>
                                 </div>

                                 <div class="col-lg-6">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label">ID Sucursal: </label>
                                        
                                        <div class="col-sm-10">
                                            <asp:DropDownList ID="ddlSucursal" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                    
                                            <div class="col-lg-12">&nbsp</div>
                                            <div class="col-lg-12">&nbsp</div>
                                            <div class="col-lg-12">&nbsp</div>
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

