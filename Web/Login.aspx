﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.Login1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js" integrity="sha384-OgVRvuATP1z7JjHLkuOU7Xw704+h835Lr+6QL9UvYjZE3Ipu6Tp75j7Bh/kR0JKI" crossorigin="anonymous"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Login</title>
</head>
<body>



    <form id="form1" runat="server">
        <div class="container body-content">
            <div class="jumbotron jumbotron-fluid text-center">
                <div class="container">
                    <h1 class="display-4">Iniciar sesión</h1>
                </div>
            </div>
            <hr />
            <div class="form-group">
                <label for="exampleInputEmail1">Usuario</label>
                <asp:TextBox ID="tbxUsuario" class="form-control small" type="text" runat="server" Style="width: 500px" />
                <%--<small id="emailHelp" class="form-text text-muted">Nunca compartiremos su correo electrónico con nadie más.</small>--%>
            </div>
            <div class="form-group">
                <label for="exampleInputPassword1">Contraseña</label>
                <asp:TextBox type="password" class="form-control" ID="tbxPassword" runat="server" Style="width: 500px" />
            </div>
            <asp:Button ID="btnAceptar" runat="server" Text="Iniciar Sesion" OnClick="btnAceptar_Click" CssClass="btn btn-primary" />

            <div>
                <br />
                <asp:Label Text="¿Eres nuevo?" runat="server" />
                <asp:LinkButton ID="linkCrearCuenta" runat="server" href="Registrarse.aspx">Crear cuenta</asp:LinkButton>

            </div>
            <hr />
            <footer>
                <p>&copy; <%: DateTime.Now.Year %> - Rolling Kitchen</p>
            </footer>
        </div>
    </form>
</body>
</html>
