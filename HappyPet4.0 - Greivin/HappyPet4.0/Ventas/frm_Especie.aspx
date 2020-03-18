<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="frm_Especie.aspx.cs" Inherits="HappyPet4._0.Ventas.frm_Especie" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="col-lg-12">
        <div class="col-sm-10">&nbsp</div>
        <div class="col-sm-2">
            <asp:Button runat="server" class="btn btn-success" Text="+ Agregar Especie" ID="btnAgregarEspecie" OnClick="btnAgregarEspecie_Click" />
        </div>
        <div class="form-group">
            <label class="col-sm-2 control-label">Especies: </label>
            <div class="col-sm-10">&nbsp</div>
            <div class="col-sm-12">
                <asp:GridView runat="server" CssClass="box" Width="100%" ID="gvEspecies" />
            </div>
        </div>
    </div>
    <div class="col-lg-12">&nbsp</div>
    <div class="col-lg-12">&nbsp</div>
    <div class="col-lg-12">&nbsp</div>
    <div class="col-lg-12" id="seccionEspecie">
        <div class="col-sm-10">
            <div class="form-group">
                <div class="input-group">
                    <div class="input-group-addon">
                        <i class="fa fa-clock-o"></i>
                    </div>
                    <asp:TextBox runat="server" class="form-control" ID="txtNombreEspecie" />
                </div>
            </div>
        </div>
        <div class="col-sm-2">&nbsp</div>
        <div class="col-sm-12">
            <label class="col-sm-9 control-label">Razas: </label>
            <div class="col-sm-3">
                <asp:Button runat="server" class="btn btn-success" Text="+ Agregar Raza" ID="btnAgregarRaza" OnClick="btnAgregarRaza_Click" />
            </div>
            <div class="col-sm-12">
                <asp:GridView runat="server" CssClass="box" Width="100%" ID="gvRazas" />
            </div>
        </div>
    </div>
</asp:Content>
