<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site1.Master" CodeBehind="frmMarcas.aspx.cs" Inherits="HappyPet4._0.frmMarcas" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container well">
        <div class="col-lg-12">
            <h3 class="page-header"><i class="fa fa-file-text-o"></i> Marcas</h3>
           
        
        <div class="row">
              <div class="col-lg-6">
                <div class="form-group">
                <label class="col-sm-2 control-label">Registrar Marca</label>
                    
                </div>
            </div>
        </div>
            <asp:Label ID="Label2" runat="server" class="col-sm-2 control-label" Text="Marcar "></asp:Label>
                            <br />
            <asp:Button ID="btnMarcar" CssClass="btn-success" runat="server" Text="Marcar" />
            <asp:Button ID="btnmVerMarca" CssClass="btn-facebook" runat="server" Text="Ver mis Marcas" />
           </div>
        </div>


</asp:Content>