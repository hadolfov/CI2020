<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="frmPlanilla.aspx.cs" Inherits="HappyPet4._0.frmPlanilla" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container well">
        <div class="col-lg-12">
            <h3 class="page-header"><i class="fa fa-file-text-o"></i> Planilla</h3>
           
        
        <div class="row">
              <div class="col-lg-6">
                <div class="form-group">
                <label class="col-sm-2 control-label">Empleado</label>
                    
                    <div class="col-sm-10">
                      <asp:TextBox ID="txtConEmpleado" runat="server"  CssClass="form-control" MaxLength="50"></asp:TextBox>
                        <asp:Button ID="btnBuscarEmpleado" class="btn btn-success" runat="server" Text="Buscar Empleado" />
                        <hr />
                    </div>
                    <div class="col-lg-12">
                    <h3 class="page-header"><i class="fa fa-file-text-o"></i>Datos Empleado</h3>
                        </div>
                    <div>
                            
                            <asp:Label ID="Label2" runat="server" class="col-sm-4 control-label" Text="Nombre"></asp:Label>
                            <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server"></asp:TextBox>
                            <br />
                            <asp:Label ID="Label3" runat="server" class="col-sm-4 control-label" Text="Primer Apellido"></asp:Label>
                            <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server"></asp:TextBox>
                            <br />
                            <asp:Label ID="Label4" runat="server" class="col-sm-4 control-label" Text="Segundo Apellido"></asp:Label>
                            <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" ></asp:TextBox>
                            <br />
                        <asp:Label ID="Label1" runat="server" class="col-sm-4 control-label" Text="Email"></asp:Label>
                            <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control" ></asp:TextBox>
                            <br />
                        <asp:Label ID="Label6" runat="server" class="col-sm-4 control-label" Text="Telefono Principal"></asp:Label>
                            <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control" ></asp:TextBox>
                        <asp:Label ID="Label7" runat="server" class="col-sm-4 control-label" Text="Telefono Secundario"></asp:Label>
                            <asp:TextBox ID="TextBox8" runat="server" CssClass="form-control" ></asp:TextBox>
                            <br />
                          <asp:Button ID="btnActInfo" class="btn btn-success" runat="server" Text="Guardar informacion" />

                            <br />
                        </div>
                    <div class="col-lg-12">
                    <h3 class="page-header"><i class="fa fa-file-text-o"></i> Consulta y pago Planilla</h3>
                    </div>
                    <div>
                            <asp:Label ID="Label5" runat="server" Text="Total Pago Planilla" class="col-sm-8 control-label" ></asp:Label>
                         <div class="col-sm-12">
                            <asp:GridView runat="server" CssClass="box" Width="100%" ID="gvPlanilla" BackColor="LightGoldenrodYellow"  BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" AllowSorting="True">
                                <AlternatingRowStyle BackColor="PaleGoldenrod" BorderColor="#999999" BorderStyle="Solid" />
                                <Columns>
                                    <asp:ButtonField ButtonType="Image" HeaderText="Acción" CommandName="Seleccionar" ImageUrl="~/Imagenes/share.png" />

                                </Columns>
                                <FooterStyle BackColor="Tan" />
                                <HeaderStyle BackColor="Tan" BorderStyle="Solid" Font-Bold="True" />
                                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                <SortedAscendingCellStyle BackColor="#FAFAE7" />
                                <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                                <SortedDescendingCellStyle BackColor="#E1DB9C" />
                                <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                            </asp:GridView>
                        </div>
                        <asp:Button ID="Button1" class="btn btn-success" runat="server" Text="Pagar Planilla" />
                    </div>
    </div>
                </div>
              </div>
             </div>
        </div>
  
</asp:Content>
