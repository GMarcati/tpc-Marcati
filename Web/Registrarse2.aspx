<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registrarse2.aspx.cs" Inherits="Web.Registrarse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron jumbotron-fluid">
        <div class="container">
            <h1 class="display-4">Crear cuenta</h1>
            <p class="lead">Ingresa tus datos para poder crear una cuenta y asi poder comprar las mejores pizzas de San Fernando!</p>
        </div>
    </div>
    <div class="form-group">
        <label for="exampleInputEmail1">Usuario</label>
        <asp:TextBox ID="tbxUsuario" class="form-control" type="text" runat="server" style="width:500px"/>
    </div>
    <div class="form-group">
        <label for="exampleInputEmail1">E-mail</label>
        <asp:TextBox ID="tbxEmail" class="form-control" type="email" runat="server" style="width:500px" />
        <small id="emailHelp" class="form-text text-muted">Nunca compartiremos su correo electrónico con nadie más.</small>
    </div>
    <div class="form-group">
        <label>Contraseña</label>
        <asp:TextBox ID="tbxPassword" type="password" class="form-control"  runat="server" style="width:500px"  />
     </div>
    <div class="form-group">
        <label>Confirmar contraseña</label>
        <asp:TextBox ID="tbxConfirmarPassword" type="password" class="form-control"  runat="server" style="width:500px"/>
        <%--<input type="password" class="form-control" id="exampleInputPassword1">--%>
    </div>
        <div class="form-group">
        <label for="exampleInputEmail1">Nombre</label>
        <asp:TextBox ID="tbxNombre" class="form-control" type="text" runat="server" style="width:500px"/>
    </div>
        <div class="form-group">
        <label for="exampleInputEmail1">Apellido</label>
        <asp:TextBox ID="tbxApellido" class="form-control" type="text" runat="server" style="width:500px"/>
    </div>
        <div class="form-group">
        <label for="exampleInputEmail1">DNI</label>
        <asp:TextBox ID="tbxDNI" class="form-control" type="number" runat="server" style="width:500px"/>
    </div>
        <div class="form-group">
        <label for="exampleInputEmail1">Domicilio</label>
        <asp:TextBox ID="tbxDomicilio" class="form-control" type="text" runat="server" style="width:500px"/>
    </div>
    <asp:Button ID="btnAceptar" runat="server" Text="Registrarse" OnClick="btnAceptar_Click" CssClass="btn btn-primary" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
