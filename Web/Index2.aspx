<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index2.aspx.cs" Inherits="Web.Index2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Rolling Kitchen</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js" integrity="sha384-OgVRvuATP1z7JjHLkuOU7Xw704+h835Lr+6QL9UvYjZE3Ipu6Tp75j7Bh/kR0JKI" crossorigin="anonymous"></script>
</head>
<body>
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark" style="margin-bottom: 1em;">
        <div class="container">



            <a class="navbar-brand" href="Index.aspx"><%--Rolling Kitchen--%>
                <img src="Rolling.png" alt="Logo" style="width: 100px;">
            </a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse " id="navbarSupportedContent">

                <ul class="navbar-nav ml-auto ">
                    <li>
                        <a class="navbar-brand" href="Carrito.aspx">
                            <img src="carrito.ico" alt="Logo" style="width: 40px;">
                        </a>

                    </li>
                </ul>


            </div>
        </div>

    </nav>


    <form id="form1" runat="server">
        <div class="container body-content">
            <div class="jumbotron text-center rounded-pill">
                <h1 class="display-4">Hola <% = name %>!</h1>
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

            <div class="text-center" style="height: 50px;">
                <asp:Button Text="Administrar productos" runat="server" ID="btnAdmin" OnClick="btnAdmin_Click" CssClass="btn btn-outline-danger " AutoPostBack="true"/>

            </div>
            <%--<a href="Admin.aspx" class="btn btn-outline-success">Administrar productos</a>--%>

            <div class="columns " style="margin-left: 10px; margin-right: 10px;">

                <div class="card-deck ">
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
            <hr />
            <footer>
                <p>&copy; <%: DateTime.Now.Year %> - Rolling Kitchen</p>
            </footer>
        </div>

    </form>
</body>
</html>
