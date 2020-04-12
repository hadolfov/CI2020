<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="frm_Citas.aspx.cs" Inherits="HappyPet4._0.Ventas.frm_Citas" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="row">
        <div class="container well">
            <div class="col-lg-12">
                <h3 class="page-header"><i class="fa fa-calendar"></i>Citas</h3>
            </div>
            <div class="col-lg-12">
                 <div class="col-lg-4">
                    <div class="form-group">
                        <label class="col-sm-4 control-label">Especialidad: </label>
                        <div class="col-sm-6">
                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlEspecialidad">
                                <asp:ListItem Text="Seleccionar..." Value="0" />
                                <asp:ListItem Text="Estética" Value="1" />
                                <asp:ListItem Text="Veterinaria" Value="2" />
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>

                 <div class="col-lg-4">
                    <div class="form-group">
                        <label class="col-sm-4 control-label">Especialista: </label>
                        <div class="col-sm-6">
                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlEspecialista">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="form-group">
                        <label class="col-sm-2 control-label">Fecha: </label>
                        <div class="col-sm-10">
                            <div class="form-group">
                                <div class="input-group">
                                    <div class="row">
                                        <div class="col-sm-9">
                                            <asp:TextBox runat="server" ReadOnly="true" class="form-control" ID="txtFecha" />
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:ImageButton runat="server" class="form-control" ID="btnCalendar" OnClick="btnCalendar_Click" ImageUrl="~/Imagenes/calendario.png" BorderStyle="None" />
                                        </div>
                                        <div class="col-sm-12">
                                            <asp:Calendar runat="server" ID="calFechaCitas" class="form-control" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="100%" OnSelectionChanged="calFechaCitas_SelectionChanged">
                                                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                                <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                                                <OtherMonthDayStyle ForeColor="#999999" />
                                                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                                <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                                                <TodayDayStyle BackColor="#CCCCCC" />
                                            </asp:Calendar>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
              
                <div class="col-lg-12">&nbsp</div>
                <div class="col-lg-12">&nbsp</div>
                <div class="col-lg-12">
                    <div class="form-group">
                        <label class="col-sm-2 control-label">Agenda: </label>
                        <div class="col-sm-10">
                            <div class="row">
                                <div class="col-sm-3">
                                    <asp:Button runat="server" ID="btnAgregarCita" Text="Agregar cita" CssClass="btn btn-success" OnClick="btnAgregarCita_Click" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:Button runat="server" ID="btnEditarCita" Text="Editar cita" CssClass="btn btn-warning" OnClick="btnEditarCita_Click" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:Button runat="server" ID="btnEliminarCita" Text="Eliminar cita" CssClass="btn btn-danger" OnClick="btnEliminarCita_Click" />
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
                            <asp:GridView runat="server" CssClass="box" Width="100%" ID="gvCitas" OnRowCommand="gvCitas_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None" AllowSorting="True">
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

    <div class="modal fade" id="ModalAgendar" role="dialog" aria-labelledby="ModalAgendarLabel" aria-hidden="true">
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
                                        <asp:Label runat="server" Text="Cliente:" />
                                    </div>
                                    <div class="col-sm-12">
                                        <div class="col-sm-6">
                                            <asp:Label runat="server" Text="Identificación:" />
                                        </div>
                                        <div class="col-sm-4">
                                            <asp:TextBox CssClass="form-control" runat="server" ID="txtIdentificacionCliente" />
                                        </div>
                                        <div class="col-sm-2">
                                            <asp:ImageButton runat="server" ID="btnBuscarCliente" ToolTip="Buscar Cliente" ImageUrl="~/Imagenes/buscar.png" OnClick="btnBuscarCliente_Click" />
                                            <asp:ImageButton runat="server" ID="btnClienteNuevo" ToolTip="Añadir Cliente" ImageUrl="~/Imagenes/anadir.png" OnClick="btnClienteNuevo_Click" />
                                        </div>
                                    </div>
                                    <div class="col-sm-12">
                                        <div class="col-sm-6">
                                            <asp:Label runat="server" Text="Nombre:" />
                                        </div>
                                        <div class="col-sm-6">
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtNombreCliente" />
                                        </div>
                                    </div>
                                    <div class="col-sm-12">&nbsp</div>
                                    <div class="col-sm-12">
                                        <asp:Label runat="server" Text="Mascota:" />
                                    </div>
                                    <div class="col-sm-12">
                                        <div class="col-sm-6">
                                            <asp:Label runat="server" Text="Mascota:" />
                                        </div>
                                        <div class="col-sm-4">
                                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlMascotaCita" />
                                        </div>
                                        <div class="col-sm-2">
                                            <asp:ImageButton runat="server" ID="btnMascotaNueva" ToolTip="Añadir Mascota" ImageUrl="~/Imagenes/anadir.png" OnClick="btnMascotaNueva_Click" />
                                        </div>
                                    </div>
                                    <div class="col-sm-12">&nbsp</div>
                                    <div class="col-sm-12">
                                        <asp:Label runat="server" Text="Cita:" />
                                    </div>
                                    <div class="col-sm-12">
                                        <div class="col-sm-6">
                                            <asp:Label runat="server" Text="Especialidad:" />
                                        </div>
                                        <div class="col-sm-6">
                                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlEspecialidadCita" />
                                        </div>
                                    </div>
                                    <div class="col-sm-12">
                                        <div class="col-sm-6">
                                            <asp:Label runat="server" Text="Especialista:" />
                                        </div>
                                        <div class="col-sm-6">
                                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlEspecialistaCita" />
                                        </div>
                                    </div>
                                    <div class="col-sm-12">
                                        <div class="col-sm-6">
                                            <asp:Label runat="server" Text="Fecha:" />
                                        </div>
                                        <div class="col-sm-6">
                                            <asp:Calendar runat="server" ID="calAgendarCita" class="form-control" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="100%" OnSelectionChanged="calAgendarCita_SelectionChanged" OnVisibleMonthChanged="calAgendarCita_VisibleMonthChanged">
                                                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                                <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                                                <OtherMonthDayStyle ForeColor="#999999" />
                                                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                                <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                                                <TodayDayStyle BackColor="#CCCCCC" />
                                            </asp:Calendar>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <asp:Label runat="server" Text="HoraInicio:" />
                                        <asp:TextBox runat="server" CssClass="form-control" ID="txtHoraInicio" TextMode="Time" />
                                    </div>
                                    <div class="col-sm-6">
                                        <asp:Label runat="server" Text="HoraFinal:" />
                                        <asp:TextBox runat="server" CssClass="form-control" ID="txtHoraFinal" TextMode="Time" />
                                    </div>
                                    <div class="col-sm-6">
                                        <asp:Label runat="server" Text="Estado:" />
                                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlEstadoCita" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <div class="col-sm-6">
                                <asp:Button runat="server" ID="btnGuardarCita" Text="Guardar" OnClick="btnGuardarCita_Click" class="btn btn-success" data-dismiss="modal" aria-hidden="true" />
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


