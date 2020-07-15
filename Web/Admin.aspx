<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Web.Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1 class="display-4">Administracion</h1>
        <p class="lead">Bienvenido a la pagina de administracion.</p>
        <hr class="my-4">
        <p>Vas a poder dar de alta/modificar/eliminar productos/categorias.</p>
    </div>
    <hr />
    <br />
    <div class="jumbotron jumbotron-fluid  text-center">
        <div class="container">
            <h1 class="display-4">Ventas</h1>
            <p class="lead">Vas a poder ver las ventas.</p>
            <div class="container-md text-center" style="height: 3em;">
                <%--<a href="AltaCategoria.aspx" class="btn btn-primary mb-2 btn btn-dark">Agregar categoria</a>--%>
            </div>
        </div>
    </div>
    <%--<h3 class="text-center">Categorias</h3>--%>

    <br />
    <table class="table table-bordered ">
        <thead>
            <tr>
                <th scope="col" class="text-right">ID</th>
                <th scope="col">ID Usuario</th>
                <th scope="col">Precio Total</th>
                <th scope="col">Fecha Venta</th>
                <th scope="col" class="text-center">Accion</th>
            </tr>
        </thead>
        <tbody>

            <% foreach (var item in listaVenta)
                { %>
            <tr>

                <th scope="row" class="text-right"><% = item.ID %></th>
                <td><% = item.usuario.Nombre_Usuario %>   </td>
                <td><% = item.PrecioTotal %>   </td>
                <td><% = item.Fecha %>   </td>
                <td class="text-center">

<%--                    <a href="ModificarCategoria.aspx?idcat=<% = item.ID.ToString() %>">
                        <img src="modificar.ico" alt="Logo" style="width: 40px;">
                    </a>
                    <a href="Admin.aspx?idQuitarCat=<% = item.ID.ToString() %>">
                        <img src="eliminar.ico" alt="Logo" style="width: 40px;">
                    </a>--%>
                <a href="VerProductos.aspx?idVenta=<% = item.ID %>" class="btn btn-primary mb-2 btn btn-dark">Ver Productos</a>
            
                </td>



            </tr>


            <% } %>
        </tbody>
    </table>
    <hr />





    <div class="jumbotron jumbotron-fluid  text-center">
        <div class="container">
            <h1 class="display-4">Categorias</h1>
            <p class="lead">Vas a poder dar de alta/modificar/eliminar categorias.</p>
            <div class="container-md text-center" style="height: 3em;">
                <a href="AltaCategoria.aspx" class="btn btn-primary mb-2 btn btn-dark">Agregar categoria</a>
            </div>
        </div>
    </div>
    <%--<h3 class="text-center">Categorias</h3>--%>

    <br />
    <table class="table table-bordered ">
        <thead>
            <tr>
                <th scope="col" class="text-right">#</th>
                <th scope="col">Nombre</th>
                <th scope="col" class="text-center">Accion</th>
            </tr>
        </thead>
        <tbody>
            <% int cont = 1; %>


            <% foreach (var item in listaCategoria)
                { %>
            <tr>

                <th scope="row" class="text-right"><% = cont++ %></th>
                <td><% = item.Nombre %>   </td>
                <td class="text-center">

                    <a href="ModificarCategoria.aspx?idcat=<% = item.ID.ToString() %>">
                        <img src="modificar.ico" alt="Logo" style="width: 40px;">
                    </a>
                    <a href="Admin.aspx?idQuitarCat=<% = item.ID.ToString() %>">
                        <img src="eliminar.ico" alt="Logo" style="width: 40px;">
                    </a>
                </td>



            </tr>


            <% } %>
        </tbody>
    </table>
    <hr />
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
                <% foreach (var item in listaProducto)
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

    <hr />
     <div class="jumbotron jumbotron-fluid  text-center">
        <div class="container">
            <h1 class="display-4">Productos Eliminados</h1>
            <p class="lead">Vas a poder ver los productos eliminados.</p>
            <div class="container-md text-center" style="height: 3em;">
                <%--<a href="AltaCategoria.aspx" class="btn btn-primary mb-2 btn btn-dark">Agregar categoria</a>--%>
            </div>
        </div>
    </div>
    <%--<h3 class="text-center">Categorias</h3>--%>

    <br />
    
    <table class="table table-bordered ">
        <thead>
            <tr>
                <th scope="col" class="text-right">ID</th>
                <th scope="col">Codigo</th>
                <th scope="col">Nombre</th>
                <th scope="col">Precio</th>

            </tr>
        </thead>
        <tbody>

            <% foreach (var item in listaProductosEliminados)
                { %>
            <tr>

                <th scope="row" class="text-right"><% = item.ID %></th>
                <td><% = item.Codigo %>   </td>
                <td><% = item.Nombre %>   </td>
                <td><% = item.Precio %>   </td>

            </tr>


            <% } %>
        </tbody>
    </table>
    <hr />


   

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
