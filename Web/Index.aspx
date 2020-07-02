<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Web.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron text-center">
        <h1 class="display-4">Hola!</h1>
        <p class="lead">Bienvenido a Rolling Kitchen, un emprendimiento familiar en el cual vendemos diferentes variedades de comidas.</p>
        <hr class="my-4">
        <p>Pizza party - Desayunos - Tortas temáticas - Pasteleria - Catering</p>
    </div>



    <div class="container">
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark" style="margin-bottom: 1em; border-radius: 25px;">

            <asp:TextBox runat="server" ID="tbxBusqueda" placeholder="Buscar productos por Nombre/Categoria" CssClass="form-control mr-sm-2" OnTextChanged="tbxBusqueda_TextChanged" />
            <button class="btn btn-outline-light my-2 my-sm-0" type="submit" id="btnBusqueda">Buscar</button>
        </nav>
    </div>



    <div class="columns " style="margin-left: 10px; margin-right: 10px;">

        <div class="card-deck">
            <div class="row row-cols-1 row-cols-md-3">
                <% foreach (var item in listaProducto)
                    { %>

                <div class="col mb-4">

                    <div class="card h-100 border-dark mb-3 text-center" style="margin-left: 10px; margin-right: 10px;">


                        <img src="<% = item.ImagenURL %>" class="card-img-top" alt="ImagenArticulo">


                        <div class="card-body">
                            <h5 class="card-title"><% = item.Nombre %></h5>
                            <p class="card-text"><small class="text-muted"><% = item.Descripcion %></small></p>
                            <h6 class="card-subtitle mb-2 text-muted">$<% = item.Precio %></h6>
                            <br />
                            <h5 class="card-subtitle mb-2">Stock: <% = item.Stock %></h5>
                        </div>
                        <div class="card-footer">
                            <a href="Carrito.aspx?idprod=<% = item.ID.ToString() %>">
                                <img src="agregarCarrito.ico" alt="Logo" style="width: 40px;">
                            </a>

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
