create database MARCATI_DB
go
Use MARCATI_DB
go
Create Table TipoUsuario(
	ID int not null primary key identity(1,1),
	Nombre varchar (50) not null
)
go
Create Table Usuarios(
	IdUsuario bigint not null primary key identity(1, 1),
	NombreUsuario varchar (50) not null unique,
	Email varchar (50) not null unique,
	Contraseña varchar (50) not null ,
	IdTipoUsuario int not null foreign key references TipoUsuario(ID),
	Estado bit not null
)
go
Create Table Categorias(
	ID int not null primary key identity(1,1),
	Nombre varchar (50) not null,
	Estado bit not null
)
go
Create Table Productos(
	ID bigint not null primary key identity(1,1),
	Codigo varchar (50) not null,
	Nombre varchar (100) not null,
	Descripcion varchar (150) not null,
	ImagenURL varchar (500) not null,
	Precio decimal not null,
	Stock bigint not null,
	IdCategoria int not null foreign key references Categorias(ID),
	Estado bit not null
)
go
Create Table Ventas(
	ID bigint not null primary key identity(1,1),
	ID_Usuario bigint not null foreign key references Usuarios(IdUsuario),
	PrecioTotal decimal not null,
	Fecha date not null

)
go
Create Table Producto_X_Venta(
	ID_Producto bigint not null foreign key references Productos(ID),
	ID_Venta bigint not null foreign key references Ventas(ID),
	primary key (ID_Producto, ID_Venta),
	Cantidad bigint,
	Precio decimal not null

)



Insert Categorias VALUES ('Pizzas', 1)
go
Insert TipoUsuario VALUES ('Admin')
go
Insert TipoUsuario VALUES ('Cliente')
go
Insert Productos VALUES ('P1','Muzzarella','Salsa de tomate + mucha muzzarella','https://img-global.cpcdn.com/recipes/75cf3c4170a22033/751x532cq70/pizza-de-muzzarella-y-aceitunas-foto-principal.jpg',300,10,1,1)
go
Insert Productos VALUES ('P2','Roquefort','Salsa de tomate + mucha muzzarella + roquefort','https://media-cdn.tripadvisor.com/media/photo-s/11/75/fa/cd/pizza-de-roquefort-en.jpg',350,15,1,1)
go
Insert Productos VALUES ('P3','Jamon y morron','Salsa de tomate + mucha muzzarella + jamon y morron','https://img-global.cpcdn.com/recipes/recipes_10857_v1393305412_foto_foto_00003081/400x400cq70/photo.jpg',380,5,1,1)
go
Create Procedure spListarProducto AS
Select P.ID, P.Codigo, P.Nombre, P.Descripcion, P.ImagenURL, P.Precio, P.Stock, C.ID AS idCategoria, C.Nombre AS Categoria , P.Estado AS EstadoProducto From Productos AS P Left Join Categorias AS C ON P.IdCategoria = C.ID Where P.Estado = 1
go
Create Procedure spAltaProducto
@Codigo varchar (50), 
@Nombre varchar (100), 
@Descripcion varchar (150), 
@ImagenURL varchar (200), 
@Precio decimal, 
@Stock bigint,
@IdCategoria int
AS Insert into Productos VALUES (@Codigo, @Nombre, @Descripcion, @ImagenURL, @Precio, @Stock, @IdCategoria, 1)
go
Create Procedure spEliminarLogico
@ID bigint
AS UPDATE Productos set Estado = 0 where ID=@ID
go
Create Procedure spModificarProducto
@Codigo varchar (50),
@Nombre varchar (100),
@Descripcion varchar (150),
@ImagenURL varchar (200),
@Precio decimal,
@Stock bigint,
@IdCategoria int,
@ID bigint
AS UPDATE Productos SET Codigo=@Codigo, Nombre=@Nombre, Descripcion=@Descripcion, ImagenURL=@ImagenURL, Precio=@Precio, Stock=@Stock ,IdCategoria=@IdCategoria  WHERE ID=@ID


--Tener en cuenta crear una vista para el registro de las ventas
Create view VW_RegistroVentas AS


Insert Categorias VALUES ('Pizzas', 1)

UPDATE Categorias SET Nombre = 'PruebaCategoria' WHERE Id=1

drop database MARCATI_DB

Select P.ID, P.Codigo, P.Nombre, P.Descripcion, P.ImagenURL, P.Precio, C.ID AS idCategoria, C.Nombre AS Categoria , P.Estado AS EstadoProducto From Productos AS P Left Join Categorias AS C ON P.IdCategoria = C.ID

UPDATE Productos set Estado = 0 where ID=1

Select ID, Nombre From Categorias

Select * From Categorias Where Estado = 1

drop database MARCATI_DB

Create Table Ventas(
	ID bigint not null primary key identity(1,1),
	IdUsuarioVenta bigint not null foreign key references Usuarios(IdUsuario),


)