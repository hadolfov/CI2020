<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Movimientos de Inventario.aspx.cs" Inherits="HappyPet4._0.Ingreso_Ordenes_de_Compra" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container well ">
            <div class="col-lg-12 text-left">
                <h3 class="page-header"><i class="fa fa-file-text-o"></i>Movimientos de Inventario</h3>
            </div>
            <hr />
            <br />
            <div class="row ">
                <div class="col-6 col-md-4">
                    <asp:Label ID="lblIdMovimiento" runat="server" Text="Id Movimiento: "></asp:Label>
                    <asp:TextBox ID="txtIdMovimiento" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-4 text-lg-right">
                    <asp:CheckBox ID="chmEstado" runat="server" />
                    <asp:Label ID="lblEstado" runat="server" Text="Aprobado"></asp:Label>
                </div>
            </div>
            <hr />
            <br />
            <div class="row">
                <div class="col-6 col-md-4">
                    <asp:DropDownList runat="server" ID="ddlIdDestinatario" Height="30px">
                        <asp:ListItem Text="Seleccionar ID " Value="0" />
                        <asp:ListItem Text="Id Cliente  " Value="1" />
                        <asp:ListItem Text="Id Proveedor " Value="2" />
                    </asp:DropDownList>
                    <asp:TextBox ID="txtIdDestinatario" Font-Names="Id Destinatario" runat="server">ID</asp:TextBox>
                    <br />
                    <asp:TextBox ID="txtNombreIdDestinatario" runat="server" Width="268px">Nombre</asp:TextBox>
                </div>
                <div class="col-md-4 text-right">
                    <label class="control-label">Fecha: </label>
                    <asp:TextBox runat="server" ID="txtFecha" />
                    <asp:ImageButton runat="server" ID="ImageButton1" OnClick="btnCalendar_Click" ImageUrl="dist/img/iconocalendario.png" Height="22px" Width="26px" />
                    <asp:Calendar runat="server" ID="calFechaCitas" class="form-control text-right" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="159px" NextPrevFormat="FullMonth" Width="84%" OnSelectionChanged="calFechaCitas_SelectionChanged">
                        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                        <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                        <TodayDayStyle BackColor="#CCCCCC" />
                    </asp:Calendar>
                </div>
            </div>
            <hr />
            <br />
            <div class="row">
                <div class="col">
                    <asp:DropDownList runat="server" ID="ddlMovimiento">
                        <asp:ListItem Text="Seleccionar Movimiento " Value="0" />
                        <asp:ListItem Text="EM:Entrada de Mercaderia  " Value="1" />
                        <asp:ListItem Text="SM: Salida de Mercaderia " Value="2" />
                        <asp:ListItem Text="TR: Transferencia de Mercaderia " Value="3" />
                    </asp:DropDownList>
                </div>
                <div class="col">
                    <asp:DropDownList runat="server" ID="ddlSucusalOrigen">
                        <asp:ListItem Text="Seleccionar Sucursal Origen " Value="0" />
                        <asp:ListItem Text="01  " Value="1" />
                        <asp:ListItem Text="02" Value="2" />
                    </asp:DropDownList>
                </div>
                <div class="col">
                    <asp:DropDownList runat="server" ID="ddlSucursalDestino">
                        <asp:ListItem Text="Seleccionar Sucursal Destino " Value="0" />
                        <asp:ListItem Text="01  " Value="1" />
                        <asp:ListItem Text="02" Value="2" />
                    </asp:DropDownList>
                </div>
                <div class="col">
                    <asp:DropDownList runat="server" ID="ddlMotivo">
                        <asp:ListItem Text="Seleccionar Motivo " Value="0" />
                        <asp:ListItem Text="Mercaderia Danada  " Value="1" />
                        <asp:ListItem Text="Descontinuado " Value="2" />
                        <asp:ListItem Text="Cambio de Precio" Value="3" />
                        <asp:ListItem Text="Traslado de Sucursal" Value="4" />
                        <asp:ListItem Text="Ingreso de Mercaderia" Value="5" />
                    </asp:DropDownList>
                </div>
            </div>
            <hr />
            <br />
            <div class="row">
                <div class="col-6 col-md-4">
                    <asp:Label ID="Label1" runat="server" Text="Codigo:"></asp:Label>
                    &nbsp;&nbsp;
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </div>
                <hr />
            <br />
                <div class="col-12 col-md-8 text-left">
                    <asp:Label ID="Label2" runat="server" Text="Descripcion"></asp:Label>
                    &nbsp;&nbsp;
                    <asp:TextBox ID="TextBox2" runat="server" Width="672px"></asp:TextBox>
                </div>
                <hr />
            <br />
                <div class="w-100"></div>
                <hr />
            <br />
                <div class="col-6 col-md-4">
                    <asp:Label ID="Label3" runat="server" Text="Cantidad"></asp:Label>
                    &nbsp;&nbsp &nbsp;&nbsp;
                     <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </div>
                <div class="col">
                    <asp:Label ID="Label4" runat="server" Text="Impuesto:"></asp:Label>
                    &nbsp;&nbsp;
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </div>
                <hr />
            <br />
                <div class="w-100"></div>
                <hr />
            <br />
                <div class="col-6 col-md-4">
                    <asp:Label ID="Label5" runat="server" Text="Descuento:"></asp:Label>
                    &nbsp;&nbsp;
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </div>
                <hr />
            <br />
                <div class="col">
                    <asp:Label ID="Label6" runat="server" Text="Precio:"></asp:Label>
                    &nbsp;&nbsp;
                    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                </div>
            </div>
            <hr />
            <br />
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
         <hr />
         <br />

          <div class="row">
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
                            <asp:Button ID="btnGuardar" class="btn btn-success" runat="server" Text="Guardar" />
                            <!-- <button type="button" class="btn btn-success">Guardar</button> -->
                        </div>
                    </div>
                </div>


        </div>
    <!-- javascripts -->
<%--        <script src="js/jquery.js"></script>
        <script src="js/bootstrap.min.js"></script>
        <!-- nice scroll -->
        <script src="js/jquery.scrollTo.min.js"></script>
        <script src="js/jquery.nicescroll.js" type="text/javascript"></script>

        <!-- jquery ui -->
        <script src="js/jquery-ui-1.9.2.custom.min.js"></script>

        <!--custom checkbox & radio-->
        <script type="text/javascript" src="js/ga.js"></script>
        <!--custom switch-->
        <script src="js/bootstrap-switch.js"></script>
        <!--custom tagsinput-->
        <script src="js/jquery.tagsinput.js"></script>

        <!-- colorpicker -->

        <!-- bootstrap-wysiwyg -->
        <script src="js/jquery.hotkeys.js"></script>
        <script src="js/bootstrap-wysiwyg.js"></script>
        <script src="js/bootstrap-wysiwyg-custom.js"></script>
        <script src="js/moment.js"></script>
        <script src="js/bootstrap-colorpicker.js"></script>
        <script src="js/daterangepicker.js"></script>
        <script src="js/bootstrap-datepicker.js"></script>
        <!-- ck editor -->
        <script type="text/javascript" src="assets/ckeditor/ckeditor.js"></script>
        <!-- custom form component script for this page-->
        <script src="js/form-component.js"></script>
        <!-- custome script for all page -->
        <script src="js/scripts.js"></script>

            <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
        <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" />
        <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"></script>
        <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js"></script>--%>
    
        
</asp:Content>
