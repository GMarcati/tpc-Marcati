drop database MARCATI_DB
go
create database MARCATI_DB
go
Use MARCATI_DB
go
--Creacion de tablas
Create Table TipoUsuario(
	ID int not null primary key identity(1,1),
	Nombre varchar (50) not null
)
go
Create Table Usuarios(
	IdUsuario bigint not null primary key identity(1, 1),
	NombreUsuario varchar (50) not null unique,
	Email varchar (50) not null unique,
	Contraseña VARBINARY (500) not null,
	Nombre varchar (50) not null,
	Apellido varchar (50) not null,
	DNI bigint not null unique,
	Domicilio varchar (150) not null,
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
	Fecha datetime not null,
	Estado bit not null

)
go
Create Table Producto_X_Venta(
	ID_Producto bigint not null foreign key references Productos(ID),
	ID_Venta bigint not null foreign key references Ventas(ID),
	primary key (ID_Producto, ID_Venta),
	Cantidad bigint not null,
	Precio decimal not null

)
go

--Se insertan datos
Insert Categorias VALUES ('Pizzas', 1)
go
Insert Categorias VALUES ('Empanadas', 1)
go
Insert Categorias VALUES ('Tortas', 1)
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
Insert Productos VALUES ('T1','Torta de chocolate','Mucho chocolate','https://i.ytimg.com/vi/H7uMpjzyaTU/maxresdefault.jpg',480,20,3,1)
go
Insert Productos VALUES ('T2','Torta de ricota','La mejor torta de ricota de san fernando','https://elgourmet.s3.amazonaws.com/recetas/cover/a8cd5e8668fb9b483471db6c5d2957ad_3_3_photo.png',280,16,3,1)
go
Insert Productos VALUES ('T3','Torta de naranja','Bizcochuelo de naranja y apta para celiacos','https://elgourmet.s3.amazonaws.com/recetas/cover/c960ea058d91b03fe387f7e517fb9a47_3_3_photo.png',580,13,3,1)
go
--Se create SP para listar los productos activos
Create Procedure spListarProducto AS
Select P.ID, P.Codigo, P.Nombre, P.Descripcion, P.ImagenURL, P.Precio, P.Stock, C.ID AS idCategoria, C.Nombre AS Categoria , P.Estado AS EstadoProducto From Productos AS P Left Join Categorias AS C ON P.IdCategoria = C.ID Where P.Estado = 1
go
--Se create SP para dar de alta un producto
Create Procedure spAltaProducto
@Codigo varchar (50), 
@Nombre varchar (100), 
@Descripcion varchar (150), 
@ImagenURL varchar (200), 
@Precio decimal, 
@Stock bigint,
@IdCategoria int
AS
BEGIN
Insert into Productos VALUES (@Codigo, @Nombre, @Descripcion, @ImagenURL, @Precio, @Stock, @IdCategoria, 1)
END
go
--Se create SP para eliminacion logica de un producto
Create Procedure spEliminarLogico
@ID bigint
AS 
BEGIN
UPDATE Productos set Estado = 0 where ID=@ID
END
go
--Se create SP para modificar producto
Create Procedure spModificarProducto
@Codigo varchar (50),
@Nombre varchar (100),
@Descripcion varchar (150),
@ImagenURL varchar (200),
@Precio decimal,
@Stock bigint,
@IdCategoria int,
@ID bigint
AS 
BEGIN
UPDATE Productos SET Codigo=@Codigo, Nombre=@Nombre, Descripcion=@Descripcion, ImagenURL=@ImagenURL, Precio=@Precio, Stock=@Stock ,IdCategoria=@IdCategoria  WHERE ID=@ID
END
go
--Se create SP para registrar usuarios
Create Procedure spRegistroUsuario
	@NombreUsuario varchar (50),
	@Email varchar (50),
	@Contraseña varchar (MAX),
	@Nombre varchar (50),
	@Apellido varchar (50),
	@DNI bigint,
	@Domicilio varchar (150)
AS 
BEGIN
Insert into Usuarios VALUES (@NombreUsuario, @Email, ENCRYPTBYPASSPHRASE('password', @Contraseña), @Nombre, @Apellido, @DNI, @Domicilio, 2, 1)
END
go
--Inserta usuario cliente prueba
exec spRegistroUsuario 'clienteprueba','clienteprueba@gmail.com','clienteprueba','clienteprueba','clienteprueba',40230535,'clienteprueba 4675'
go
--Inserta usuario admin
Insert into Usuarios (NombreUsuario, Email, Contraseña, Nombre, Apellido, DNI, Domicilio, IdTipoUsuario, Estado ) VALUES ('admin','email@prueba.com',ENCRYPTBYPASSPHRASE('password', 'admin'),'admin','admin', 40353632 ,'admin 321',1,1) 
go
--Se create SP para listar usuarios
Create Procedure spListaUsuario 
AS
BEGIN
Select U.IdUsuario, U.NombreUsuario, U.Email, CONVERT(VARCHAR(MAX), DECRYPTBYPASSPHRASE('password', U.Contraseña)) AS Constraseña,U.Nombre, U.Apellido, U.DNI, U.Domicilio, TU.ID AS idTipoUsuario, TU.Nombre AS TipoUsuario  From Usuarios AS U Left Join TipoUsuario AS TU ON TU.ID= U.IdTipoUsuario Where U.Estado = 1
END
go
--Se crea vista para tener un registro de los productos eliminados
Create view VW_ProductosEliminados AS
Select P.Codigo, P.Nombre, P.Precio, C.Nombre AS Categoria from Productos AS P
Inner Join Categorias AS C ON P.IdCategoria = C.ID
Where P.Estado = 0
go
--Se create SP para dar de alta una venta
Create Procedure spAltaVenta
@ID_Usuario bigint,
@PrecioTotal decimal,
@Fecha datetime
AS Insert into Ventas VALUES (@ID_Usuario,@PrecioTotal,GETDATE(),1)
go
--Se create SP para ingresar datos en la tapa Producto__X_Venta
Create Procedure spAltaProducto_X_Venta
@ID_Producto bigint,
@ID_Venta bigint,
@Cantidad bigint,
@Precio decimal
AS Insert into Producto_X_Venta VALUES (@ID_Producto,@ID_Venta,@Cantidad,@Precio)

Select ID,ID_Usuario,PrecioTotal,Fecha From Ventas Where Estado = 1


--Ver productoXventa
--select * from Producto_X_Venta


--Inserta usuario admin
--Insert into Usuarios (NombreUsuario, Email, Contraseña, Nombre, Apellido, DNI, Domicilio, IdTipoUsuario, Estado ) VALUES ('admin','email@prueba.com',ENCRYPTBYPASSPHRASE('password', 'admin'),'Gonzalo','Marcati', 40353632 ,'ambrosoni 321',1,1) 

--Comparar contraseña encriptada vs contraseñareal
--select Contraseña AS ContraseñaEncriptada,CONVERT(VARCHAR(MAX), DECRYPTBYPASSPHRASE('password', Contraseña)) AS ContraseñaReal from Usuarios

--Registro de ventas
--Select U.NombreUsuario, P.Nombre, V.ID, V.Fecha, PXV.Cantidad, PXV.Precio AS Precio_X_Cantidad, P.Precio AS PrecioProducto from Ventas AS V
--Inner Join Producto_X_Venta AS PXV ON V.ID = PXV.ID_Venta
--Inner Join Productos AS P ON PXV.ID_Producto = P.ID
--Inner Join Usuarios AS U ON V.ID_Usuario = U.IdUsuario


