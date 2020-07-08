<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="Web.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="d-flex justify-content-end " style="nav-down: auto">
        <div class="d-flex justify-content-end ">
            <button type="button" class="btn btn-danger  badge-pill">
                Mi carrito de compra <span class="badge badge-light">(<% = carrito.listaItem.Count() %>)  </span>
                <span class="sr-only">Cantidad producto carrito</span>
            </button>
        </div>
    </div>


    <br />
    <div class="container ">
        <div class="row">
            <div class="col">
                <table class="table table-bordered text-center">
                    <tr>
                        <td>Nombre</td>
                        <td>Precio</td>
                        <td>Cantidad</td>
                        <td>Accion</td>

                    </tr>
                    <%foreach (var prod in carrito.listaItem)
                        {
                    %>
                    <tr>
                        <td><% = prod.Producto.Nombre %></td>
                        <td>$ <% = prod.Producto.Precio %></td>
                        <td>
                            <a href="Carrito.aspx?idCantRest=<% =prod.Producto.ID.ToString() %>" class="btn btn-dark">-</a>
                            <%=prod.Cantidad %>
                            <a href="Carrito.aspx?idCantSum=<% =prod.Producto.ID.ToString() %>" class="btn btn-dark">+</a>


                            <%--<input type="number" name="name" value="<% = prod.Producto.Stock %>" min="1" max="<% = prod.Producto.Stock %>"  class="text-center" id="txtCant"/>--%>

                        </td>
                        <td>

                            <a href="Carrito.aspx?idQuitar=<% = prod.Producto.ID.ToString() %>" class="btn btn-outline-danger">Eliminar</a></td>
                    </tr>

                    <% } %>
                </table>

            </div>
        </div>
    </div>


    <footer>
        <div class="d-flex justify-content-end">
            Total: $                
                <% = carrito.SubTotal() %>
        </div>

        <div class="d-flex justify-content-end">
            <a href="Carrito.aspx?idComprar=<% = carrito.ID%>" class="btn btn-outline-success">Realizar pedido</a>
        </div>

        


    </footer>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
