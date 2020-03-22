<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site1.Master" CodeBehind="frmPermisosyVac.aspx.cs" Inherits="HappyPet4._0.frmPermisosyVac" %>



<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.15.1/moment.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.7/js/bootstrap.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.7.14/js/bootstrap-datetimepicker.min.js"></script>

<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.7/css/bootstrap.min.css">
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.7.14/css/bootstrap-datetimepicker.min.css">

    <div class="container well">
        <div class="col-lg-12">
            <h3 class="page-header"><i class="fa fa-file-text-o"></i>Permisos y Vacaciones</h3>
            <div class="row">
                <label">Solicitar Permiso</label>
            <div>
                <br />
                <div class="col-sm-8">
            <label >Tipo Permiso: </label>
                    <asp:DropDownList CssClass="form-control" runat="server" ID="ddlTipoPermiso">
                        <asp:ListItem Text="Seleccionar..." Value="0" />
                        <asp:ListItem Text="Vacaciones" Value="1" />
                        <asp:ListItem Text="Permiso" Value="2" />
                        <asp:ListItem Text="Permiso" Value="3" />
                    </asp:DropDownList>
                </div>
                </div>
            </div>
             <br />
                <div class="col-lg-4">
                    <div class="form-group">
                        <label class="col-sm-2 control-label">Fecha Inicio:</label>
                        <div class="col-sm-9">
                            <asp:TextBox runat="server" class="col-md-8" ID="txtFechaInic" />
                        </div>
                        <div class="col-sm-3">
                            <asp:ImageButton runat="server" class="form-control" ID="ImageButtonCalInic" OnClick="btnCalendarInic_Click" ImageUrl="~/Imagenes/calendario.png" BorderStyle="None" />
                        </div>
                        <div class="col-sm-12">
                            <asp:Calendar runat="server" ID="calendarInic" class="form-control" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="100%" OnSelectionChanged="CalendarInic_SelectionChanged">
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
                   
                    <div class="col-lg-4">
                    <div class="form-group">
                        <label class="col-sm-2 control-label">Fecha Fin:</label>
                        <div class="col-sm-9">
                            <asp:TextBox runat="server" class="col-md-8" ID="txtFechaFin" />
                        </div>
                        <div class="col-sm-3">
                            <asp:ImageButton runat="server" class="form-control" ID="ImageButtonCalFin" OnClick="btnCalendarFin_Click" ImageUrl="~/Imagenes/calendario.png" BorderStyle="None" />
                        </div>
                        <div class="col-sm-12">
                            <asp:Calendar runat="server" ID="CalendarFin" class="form-control" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="100%" OnSelectionChanged="CalendarFin_SelectionChanged">
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
        <div class="col-lg-4">
                    <div class="form-group">
                        <div class="col-sm-9">
       <asp:Button CssClass="btn-success" ID="btnEnviarSolPermiso" runat="server" Text="Solicitar Permiso" />
        
                   </div>
                        </div>
            </div>
                        
                        </div>


        </div>
         

</asp:Content>

