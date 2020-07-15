<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerProductos.aspx.cs" Inherits="Web.VerProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron jumbotron-fluid  text-center">
        <div class="container">
            <h1 class="display-4">Prepara los siguientes productos:</h1>
        </div>
    </div>


    <br />

    <table class="table table-bordered ">
        <thead>
            <tr>
                <th scope="col" class="text-right">#</th>
                <th scope="col">idVenta</th>
                <th scope="col">Producto</th>
                <th scope="col">Cantidad</th>
            </tr>
        </thead>
        <tbody>
            <% int cont = 1; %>


            <% foreach (var item in listaProducto_X_Venta)
                { %>

            <% if (Convert.ToInt32(Request.QueryString["idVenta"]) == item.venta.ID)
                { %>
            <tr>

                <th scope="row" class="text-right"><% = cont++ %></th>
                <td><% = item.venta.ID %>   </td>
                <td><% = item.producto.Nombre %>   </td>
                <td><% = item.Cantidad %>   </td>

            </tr>
             <% } %>

            <% } %>
        </tbody>
    </table>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
