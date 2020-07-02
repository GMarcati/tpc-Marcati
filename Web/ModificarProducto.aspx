<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarProducto.aspx.cs" Inherits="Web.ModificarProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <%--    <asp:Label ID="lblID" runat="server" Text="ID:"></asp:Label>
    <asp:TextBox ID="tbxID" runat="server" ReadOnly="True"></asp:TextBox><br />--%>

    <div class="main-card mb-3 card  ">
        <div class="card-body">
            <h5 class="card-title text-center">Modificar producto</h5>
            <div class="form-group">
                <asp:Label ID="lblCodigo" runat="server" Text="Codigo:"></asp:Label>
                <asp:TextBox ID="tbxCodigo" runat="server" CssClass="form-control "></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
                <asp:TextBox ID="tbxNombre" runat="server" CssClass="form-control "></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion"></asp:Label>
                <asp:TextBox ID="tbxDescripcion" runat="server" CssClass="form-control "></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblCategoria" runat="server" Text="Categoria:"></asp:Label>
                <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Label ID="lblImagenURL" runat="server" Text="ImagenURL:"></asp:Label>
                <asp:TextBox ID="tbxImagenURL" runat="server" CssClass="form-control "></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblPrecio" runat="server" Text="Precio:"></asp:Label>
                <asp:TextBox ID="tbxPrecio" runat="server" CssClass="form-control " type="number"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblStock" runat="server" Text="Stock:"></asp:Label>
                <asp:TextBox ID="tbxStock" runat="server" CssClass="form-control" type="number"></asp:TextBox>
            </div>
            <div class="form-group text-center">
                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" CssClass="btn btn-primary" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn btn-primary" />
            </div>
        </div>
    </div>



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
