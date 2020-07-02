<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="Web.Registrarse1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js" integrity="sha384-OgVRvuATP1z7JjHLkuOU7Xw704+h835Lr+6QL9UvYjZE3Ipu6Tp75j7Bh/kR0JKI" crossorigin="anonymous"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Registrarse</title>


</head>
<body>
    
<%--        <script>    
            function validar() {

                var usuario = document.getElementById("tbxUsuario").value;
                var email = document.getElementById("tbxEmail").value;
                var pass = document.getElementById("tbxPassword").value;
                var passConfirmar = document.getElementById("tbxConfirmarPassword").value;
                var nombre = document.getElementById("tbxNombre").value;
                var apellido = document.getElementById("tbxApellido").value;
                var dni = document.getElementById("tbxDNI").value;
                var domicilio = document.getElementById("tbxDomicilio").value;
                var valido = true;

                if (usuario === "") {
                    $("#tbxUsuario").removedClass("is-valid");
                    $("#tbxUsuario").addClass("is-invalid");
                    valido = false;
                } else {
                    $("#tbxUsuario").removedClass("is-invalid");
                    $("#tbxUsuario").addClass("is-valid");
                }
                if (email === "") {
                    $("#tbxEmail").removedClass("is-valid");
                    $("#tbxEmail").addClass("is-invalid");
                    valido = false;
                } else {
                    $("#tbxEmail").removedClass("is-invalid");
                    $("#tbxEmail").addClass("is-valid");
                }
                if (pass === "" || pass !== passConfirmar) {
                    $("#tbxPassword").removedClass("is-valid");
                    $("#tbxPassword").addClass("is-invalid");
                    valido = false;
                } else {
                    $("#tbxPassword").removedClass("is-invalid");
                    $("#tbxPassword").addClass("is-valid");
                }
                if (passConfirmar === "" || passConfirmar !== pass) {
                    $("#tbxConfirmarPassword").removedClass("is-valid");
                    $("#tbxConfirmarPassword").addClass("is-invalid");
                    valido = false;
                } else {
                    $("#tbxConfirmarPassword").removedClass("is-invalid");
                    $("#tbxConfirmarPassword").addClass("is-valid");
                }
                if (nombre === "") {
                    $("#tbxNombre").removedClass("is-valid");
                    $("#tbxNombre").addClass("is-invalid");
                    valido = false;
                } else {
                    $("#tbxNombre").removedClass("is-invalid");
                    $("#tbxNombre").addClass("is-valid");
                }
                if (apellido === "") {
                    $("#tbxApellido").removedClass("is-valid");
                    $("#tbxApellido").addClass("is-invalid");
                    valido = false;
                } else {
                    $("#tbxApellido").removedClass("is-invalid");
                    $("#tbxApellido").addClass("is-valid");
                }
                if (dni === "") {
                    $("#tbxDNI").removedClass("is-valid");
                    $("#tbxDNI").addClass("is-invalid");
                    valido = false;
                } else {
                    $("#tbxDNI").removedClass("is-invalid");
                    $("#tbxDNI").addClass("is-valid");
                }
                if (domicilio === "") {
                    $("#tbxDomicilio").removedClass("is-valid");
                    $("#tbxDomicilio").addClass("is-invalid");
                    valido = false;
                } else {
                    $("#tbxDomicilio").removedClass("is-invalid");
                    $("#tbxDomicilio").addClass("is-valid");
                }
                if (!valido) {
                    return false;
                }

                return true;
            }

        </script>--%>


    <form id="form1" runat="server">


        <div class="container body-content ">
            <br />
            <div class="jumbotron jumbotron-fluid rounded-pill text-center">
                <div class="container">
                    <h1 class="display-4">Crear cuenta</h1>
                    <p class="lead">Ingresa tus datos para poder crear una cuenta y asi poder comprar las mejores pizzas de San Fernando!</p>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-6 ">
                    <label for="exampleInputEmail1">Usuario</label>
                    <asp:TextBox ID="tbxUsuario" class="form-control" type="text" runat="server" />
                </div>
                <div class="form-group col-md-6">
                    <label for="exampleInputEmail1">E-mail</label>
                    <asp:TextBox ID="tbxEmail" class="form-control" type="email" runat="server"  />
                    <small id="emailHelp" class="form-text text-muted">Nunca compartiremos su correo electrónico con nadie más.</small>
                </div>

            </div>

            <div class="form-row">
                <div class="form-group form-group col-md-6">
                    <label>Contraseña</label>
                    <asp:TextBox ID="tbxPassword" type="password" class="form-control" runat="server" />
                </div>
                <div class="form-group form-group col-md-6">
                    <label>Confirmar contraseña</label>
                    <asp:TextBox ID="tbxConfirmarPassword" type="password" class="form-control" runat="server" />
                    <%--<input type="password" class="form-control" id="exampleInputPassword1">--%>
                </div>

            </div>
            <div class="form-row">
                <div class="form-group form-group col-md-6">
                    <label for="exampleInputEmail1">Nombre</label>
                    <asp:TextBox ID="tbxNombre" class="form-control" type="text" runat="server" />
                </div>
                <div class="form-group form-group col-md-6">
                    <label for="exampleInputEmail1">Apellido</label>
                    <asp:TextBox ID="tbxApellido" class="form-control" type="text" runat="server" />
                </div>
            </div>

            <div class="form-row">
                <div class="form-group form-group col-md-6">
                    <label for="exampleInputEmail1">DNI</label>
                    <asp:TextBox ID="tbxDNI" class="form-control" type="number" runat="server" />
                </div>
                <div class="form-group form-group col-md-6">
                    <label for="exampleInputEmail1">Domicilio</label>
                    <asp:TextBox ID="tbxDomicilio" class="form-control" type="text" runat="server" />
                </div>

            </div>



            <asp:Button ID="btnAceptar" runat="server" Text="Registrarse" OnClick="btnAceptar_Click" CssClass="btn btn-primary" />
            <asp:Button ID="btnCancelar" runat="server" Text="Volver al login" OnClick="btnCancelar_Click" CssClass="btn btn-primary" />

            <hr />
            <footer>
                <p>&copy; <%: DateTime.Now.Year %> - Rolling Kitchen</p>
            </footer>
        </div>
    </form>
</body>
</html>
