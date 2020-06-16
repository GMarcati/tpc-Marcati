create database MARCATI_DB
go
Use MARCATI_DB
go
Create Table TipoUsuario(
	ID int not null primary key identity(1,1),
	Nombre varchar (50) not null,
	Estado int not null
)
go
Create Table Usuarios(
	IdUsuario bigint not null primary key identity(1, 1),
	NombreUsuario varchar (50) not null unique,
	Contraseña varchar (50) not null ,
	IdTipoUsuario int not null foreign key references TipoUsuario(ID),
	Estado int not null
)
go
Create Table Categorias(
	ID int not null primary key identity(1,1),
	Nombre varchar (50) not null,
	Estado int not null
)
go
Create Table Productos(
	ID int not null primary key identity(1,1),
	Codigo varchar (50) not null,
	Nombre varchar (100) not null,
	Descripcion varchar (150) not null,
	ImagenURL varchar (200) not null,
	Precio decimal not null,
	IdCategoria int not null foreign key references Categorias(ID),
	Estado int not null
)
go
Create Table Usuario_x_Producto(
	IDUsuario bigint not null foreign key references Usuarios(IdUsuario),
	IDProducto int not null foreign key references Productos(ID)
)
go
Insert Categorias VALUES ('Pizzas', 1)
go
Insert TipoUsuario VALUES ('Admin', 1)
go
Insert TipoUsuario VALUES ('Comprador', 1)
go
Insert Productos VALUES ('P1','Muzzarella','Salsa de tomate + mucha muzzarella','https://img-global.cpcdn.com/recipes/75cf3c4170a22033/751x532cq70/pizza-de-muzzarella-y-aceitunas-foto-principal.jpg',300,1,1)
go
Insert Productos VALUES ('P2','Roquefort','Salsa de tomate + mucha muzzarella + roquefort','https://media-cdn.tripadvisor.com/media/photo-s/11/75/fa/cd/pizza-de-roquefort-en.jpg',350,1,1)
go
Insert Productos VALUES ('P3','Jamon y morron','Salsa de tomate + mucha muzzarella + jamon y morron','https://img-global.cpcdn.com/recipes/recipes_10857_v1393305412_foto_foto_00003081/400x400cq70/photo.jpg',380,1,1)
go

