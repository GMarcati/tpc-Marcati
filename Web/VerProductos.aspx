<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerProductos.aspx.cs" Inherits="Web.VerProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron jumbotron-fluid  text-center">
        <div class="container">
            <h1 class="display-4">Productos</h1>
            <p class="lead">Vas a poder dar de alta/modificar/eliminar productos.</p>
            <div class="container-md text-center" style="height: 3em;">
                <a href="AltaProducto.aspx" class="btn btn-primary mb-2 btn btn-dark">Agregar producto</a>
            </div>
        </div>
    </div>
    <%--    <h3 class="text-center">Productos</h3>--%>

    <br />
    <div class="columns " style="margin-left: 10px; margin-right: 10px;">

        <div class="card-deck">
            <div class="row row-cols-1 row-cols-md-3">
                <% foreach (var item in listaProducto_X_Venta)
                    { %>

                <div class="col mb-4">

                    <div class="card h-100 border-dark mb-3 text-center" style="margin-left: 10px; margin-right: 10px;">

                        <img src="<% = item.ImagenURL %>" class="card-img-top" alt="ImagenProducto">


                        <div class="card-body">
                            <h6 class="card-title">Codigo: <% = item.Codigo %></h6>

                            <h5 class="card-title"><% = item.Nombre %></h5>
                            <p class="card-text"><small class="text-muted"><% = item.Descripcion %></small></p>
                            <h6 class="card-subtitle mb-2 text-muted">$<% = item.Precio %></h6>
                            <br />
                            <h6 class="card-subtitle mb-2">Stock: <% = item.Stock %></h6>





                        </div>
                        <div class="card-footer">
                            <h6 class="card-title">Categoria: <% = item.Categoria.Nombre %></h6>
                            <a href="ModificarProducto.aspx?idprod=<% = item.ID.ToString() %>">
                                <img src="modificar.ico" alt="Logo" style="width: 40px;">
                            </a>
                            <a href="Admin.aspx?idQuitar=<% = item.ID.ToString() %>">
                                <img src="eliminar.ico" alt="Logo" style="width: 40px;">
                            </a>
                            <%--<a href="Admin.aspx?idQuitar=<% = item.ID.ToString() %>" class="btn btn-primary">Quitar</a>--%>
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
