<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Web.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

        <div class="card-columns" style="margin-left: 10px; margin-right: 10px;">

        <div class="container">
            <% foreach (var item in listaProducto)
                { %>

            <div class="container">

                <div class="card" style="width: 18rem;">

                    <div class="container">
                        
                        <img src="<% = item.ImagenURL %>" class="card-img-top" alt="ImagenArticulo">
                        <div class="card-body">
                            <h5 class="card-title"><% = item.Nombre %> (<% = item.Codigo %>)</h5>
<%--                            <p class="card-text"><% = item.Descripcion %></p>
                            <p class="card-text"><% = item.Precio %></p>
                            <a href="Carrito.aspx?idart=<% = item.ID.ToString() %>" class="btn btn-primary">Agregar al carrito</a>--%>
                        </div>
                    </div>
                </div>
            </div>

            <% } %>
        </div>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 </asp:Content>