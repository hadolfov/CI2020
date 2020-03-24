<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="Productos.aspx.cs" Inherits="HappyPet4._0.Proveedores" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    <!--<link href="bootstrap/css/LogIn.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" />
    <div class="row">-->
    <div class="container well">
          <div class="col-lg-12">
            <h3 class="page-header"><i class="fa fa-file-text-o"></i> Productos</h3>
          </div>


        
        <div class="row">
          <div class="col-lg-6">
            <div class="form-group">
                <label class="col-sm-2 control-label">Producto</label>
                    <div class="col-sm-10">
                      <asp:TextBox ID="txtProducto" runat="server"  CssClass="form-control" MaxLength="50"></asp:TextBox>
                     <!-- <input type="text" maxlength="50" class="form-control"/> -->
                    </div>
            </div>
          </div>
            <div class="col-lg-6">
            <div class="form-group">
                <label class="col-sm-2 control-label">Código</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtCodigo" runat="server"  CssClass="form-control" MaxLength="50"></asp:TextBox>
                      <!--<input type="text" maxlength="50" class="form-control"/>  -->
                    </div>
            </div>
          </div>
            <div class="col-lg-12">&nbsp</div>
            <div class="col-lg-6">
            <div class="form-group">
                <label class="col-sm-2 control-label">Cantidad Mínima</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtCantMinimo" TextMode="Number" runat="server"  CssClass="form-control" MaxLength="9999" ></asp:TextBox>
                    </div>
            </div>
          </div>
            <div class="col-lg-6">
            <div class="form-group">
                <label class="col-sm-2 control-label">Cantidad Máxima</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtCantMaximo" TextMode="Number" runat="server"  CssClass="form-control" MaxLength="9999" ></asp:TextBox>
                      <!--<input type="number" max="9999" min="0" class="form-control"/> -->
                    </div>
            </div>
          </div>
            <div class="col-lg-12">&nbsp</div>
            <div class="col-lg-6">
            <div class="form-group">
                <label class="col-sm-2 control-label">Precio Articulo</label>
                    <div class="col-sm-10">
                      <asp:TextBox ID="txtPecioArt" TextMode="Number" runat="server"  CssClass="form-control" MaxLength="10000000" ></asp:TextBox>
                      <!-- <input type="number" max="10000000" min="0"  class="form-control"/> -->
                    </div>
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
                 <asp:Button ID="btnGuardar" class="btn btn-success" runat="server" Text="Guardar" />
               <!-- <button type="button" class="btn btn-success">Guardar</button> -->
            </div>
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
