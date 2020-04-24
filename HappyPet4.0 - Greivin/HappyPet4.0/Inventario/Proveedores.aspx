<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="HappyPet4._0.Proveedores1" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container well">
        <div class="col-lg-12">
            <h3 class="page-header"><i class="fa fa-file-text-o"></i>Proveedores</h3>
        </div>
        <hr />
        <br />
        <div class="row ">

            <div class="col-lg-5">
                <label ID="lblIdProveedor" class="control-label">Identificación: </label>
                <%--<asp:Label ID="lblIdProveedor" runat="server" Text="Id Proveedor: "></asp:Label>--%>
                <asp:TextBox ID="txtIdProveedor" runat="server"></asp:TextBox>
            </div>

            <div class="col-md-5">
                <label ID="lblTipoIdentificacion" class="control-label">Identificación: </label>
                <asp:DropDownList runat="server" ID="ddlTipoIdientificacion">
                    <asp:ListItem Text="Cédula Jurídica" Value="0" />
                    <asp:ListItem Text="Cédula Física" Value="1" />
                    <asp:ListItem Text="DIMEX" Value="2" />
                    <asp:ListItem Text="NITE" Value="2" />
                </asp:DropDownList>
            </div>

            <div class="col-lg-2 text-md-right">
                <label ID="lblActivo" class="control-label">Activo: </label>
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

        <!-- javascripts -->
        <script src="js/jquery.js"></script>
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

        
    </div>



</asp:Content>
