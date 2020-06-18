<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Web.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <%--    <div class="card-columns" style="margin-left: 10px; margin-right: 10px;">

        <div class="container">
            <% foreach (var item in listaProducto)
                { %>

            <div class="container">

                <div class="card" style="width: 18rem;">

                    <div class="container">

                        <img src="<% = item.ImagenURL %>" class="card-img-top" alt="ImagenArticulo">
                        <div class="card-body">
                            <h6>Codigo:<% = item.Codigo %></h6>
                            <h5 class="card-title"><% = item.Nombre %> </h5>
                            <p class="card-text"><% = item.Descripcion %></p>
                            <p class="card-text">$<% = item.Precio %></p>
                            <a href="Carrito.aspx?idart=<% = item.ID.ToString() %>" class="btn btn-primary">Agregar al carrito</a>
                        </div>
                    </div>
                </div>
            </div>

            <% } %>
        </div>
    </div>--%>

    <%--    <div class="card-columns" style="margin-left: 10px; margin-right: 10px;">
        <div class="card-group">

            <div class="card" style="width: 18rem">

                <% foreach (var item in listaProducto)
                    { %>

                <div class="container">
                    <img src="<% = item.ImagenURL %>" class="card-img-top" alt="ImagenArticulo">
                    <div class="card-body">
                        <h5 class="card-title"><% = item.Nombre %> ($<% = item.Precio %>)</h5>                        
                        <p class="card-text"><small class="text-muted"><% = item.Descripcion %></small></p>
                        <a href="Carrito.aspx?idart=<% = item.ID.ToString() %>" class="btn btn-primary">Agregar al carrito</a>
                    </div>
                </div>

                <% } %>
            </div>
        </div>
    </div>

    </div>--%>


    <div class="columns" style="margin-left: 10px; margin-right: 10px;">
        <div class="card-group">


            <div class="row row-cols-1 row-cols-md-3">
                <% foreach (var item in listaProducto)
                    { %>

                <div class="container">
                    <div class="col sm">
                        <div class="card" style="width: 18rem">
                            <img src="<% = item.ImagenURL %>" class="card-img-top" alt="ImagenArticulo">
                            <div class="card-body">
                                <h5 class="card-title"><% = item.Nombre %> ($<% = item.Precio %>)</h5>
                                <p class="card-text"><small class="text-muted"><% = item.Descripcion %></small></p>
                                <a href="Carrito.aspx?idart=<% = item.ID.ToString() %>" class="btn btn-primary">Agregar al carrito</a>
                            </div>
                        </div>
                    </div>
                </div>

                <% } %>
            </div>
        </div>
    </div>


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
