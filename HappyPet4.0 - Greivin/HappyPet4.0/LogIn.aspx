<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="HappyPet4._0.LogIn" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/Mml; charset-utf-8" />
    <title>HappyPet LogIN</title>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>

    <!--FRAMEWORK BOOTSTRAP para el estilo de la pagina-->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>

    <!-- Los iconos tipo Solid de Fontawesome-->
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.0.8/css/solid.css" />
    <script src="https://use.fontawesome.com/releases/v5.0.7/js/all.js"></script>

    <!-- Nuestro css-->
    <link rel="stylesheet" type="text/css" href="bootstrap/css/LogIn.css" />

</head>



<body>
    <div class="modal-dialog text-center">
        <div class="col-sm-8 main-section">
            <div class="modal-content">
                <div class="col-12 user-image">
                    <img src="dist/img/avatarlogin.png" />"
		
                </div>

                <form runat="server" class="col-12">

                    <div class="form-group col-12">
                        <asp:Label ID="lblUsuario" runat="server" Text="Usuario" CssClass="control-label"></asp:Label>
                        <div class="col-12">
                            <asp:TextBox ID="txtUsuario" placeholder="Usuario" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group col-12">
                        <asp:Label ID="lblContraseña" runat="server" Text="Contraseña" CssClass="control-label"></asp:Label>
                        <div class="col-12">
                            <asp:TextBox TextMode="Password" placeholder="Contraseña" ID="txtContraseña" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-grup col-12">
                        <asp:Button ID="btnIngresar" runat="server" Class="fa-fast-backward fa-sign-in" Text="Ingresar" OnClick="btnIngresar_Click" CssClass="form-control btn btn-primary" />
                    </div>

                </form>
                <div class="col-12 forgot">
                    <a href="#">Restablecer Contraseña</a>

                </div>
                <div class="col-12">
                    <asp:Label runat="server" ID="txtError" ForeColor="Red" />

                </div>
            </div>
        </div>
    </div>
</body>

</html>
