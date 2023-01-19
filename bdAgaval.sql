Create database PrubaAgaval
go

Use PrubaAgaval
go

-----   Punto 1
CREATE TABLE clientes (
   clienteID INT PRIMARY KEY,
   Nombre VARCHAR(255) NOT NULL
);


CREATE TABLE datos (
    id INT identity PRIMARY KEY,
    cliente INT NOT NULL,
    Variable VARCHAR(255) NOT NULL,
    Valor VARCHAR(255) NOT NULL,
    FOREIGN KEY (cliente) REFERENCES clientes(clienteId)
);


------- Punto 2
INSERT INTO clientes (ClienteId, Nombre) VALUES
    (1, 'Juan'),
    (2, 'Pepe'),
    (3, 'María'),
    (4, 'Jose'),
    (5, 'David'),
    (6, 'Jaime'),
    (7, 'Diana'),
    (8, 'Ivan'),
    (9, 'Cata');

INSERT INTO Datos (cliente, Variable, Valor) VALUES
    (1, 'Genero', 'M'),
    (2, 'Genero', 'M'),
    (3, 'Genero', 'F'),
    (4, 'Genero', 'M'),
    (5, 'Genero', 'M'),
    (6, 'Genero', 'M'),
    (7, 'Genero', 'F'),
    (8, 'Genero', 'M'),
    (9, 'Genero', 'F'),
    (1, 'Ciudad', 'Bogota'),
    (2, 'Ciudad', 'Cali'),
    (3, 'Ciudad', 'Bogota'),
    (4, 'Ciudad', 'Medellin'),
    (5, 'Ciudad', 'Medellin'),
    (6, 'Ciudad', 'Barranquilla'),
    (7, 'Ciudad', 'Cali'),
    (8, 'Ciudad', 'Bogota'),
    (9, 'Ciudad', 'Medellin'),
    (1, 'Mascota', 'Si'),
    (2, 'Mascota', 'Si'),
    (3, 'Mascota', 'Si'),
    (4, 'Mascota', 'No'),
    (5, 'Mascota', 'Si'),
    (6, 'Mascota', 'No'),
    (7, 'Mascota', 'No'),
    (8, 'Mascota', 'No'),
    (9, 'Mascota', 'Si');


------ Punto 3
SELECT c.Nombre
FROM clientes c
    JOIN Datos d1 ON c.ClienteId = d1.cliente
    JOIN Datos d2 ON c.ClienteId = d2.cliente
    JOIN Datos d3 ON c.ClienteId = d3.cliente
WHERE d1.Variable = 'Genero' AND d1.Valor = 'F'
    AND d2.Variable = 'Ciudad' AND d2.Valor = 'Bogota'
    AND d3.Variable = 'Mascota' AND d3.Valor = 'Si';


------ punto 4
SELECT d.Valor as Ciudad, COUNT(d.cliente) as Total_personas
FROM Datos d
WHERE d.Variable = 'Ciudad'
GROUP BY d.Valor;


-------- punto 5   -   revisar
SELECT d1.Valor as Genero, COUNT(CASE WHEN d2.Valor = 'Si' THEN 1 ELSE NULL END) as Cantidad_Mascotas
FROM Datos d1
JOIN Datos d2 ON d1.cliente = d2.cliente
WHERE d1.Variable = 'Genero' AND d2.Variable = 'Mascota' 
GROUP BY d1.Valor;



------- punto 6 - revisar
SELECT d1.Valor as Ciudad, AVG(CASE WHEN d2.Valor = 'Si' THEN 1 ELSE 0 END) as Promedio_Mascotas
FROM Datos d1
JOIN Datos d2 ON d1.cliente = d2.cliente
WHERE d1.Variable = 'Ciudad' AND d2.Variable = 'Mascota' 
GROUP BY d1.Valor;



----  punto 7
CREATE TABLE Auditoria (
    id INT identity PRIMARY KEY,
    Fecha DATETIME,
    Mensaje VARCHAR(100)
);


-- punto 8
INSERT INTO clientes (ClienteId, Nombre) 
VALUES (10, 'Lucas');

UPDATE clientes 
SET Nombre = 'Lucas Rodriguez' 
WHERE ClienteId = 10;

DELETE FROM clientes 
WHERE ClienteId = 10;


INSERT INTO Datos (cliente, Variable, Valor) 
VALUES (10, 'Ciudad', 'Medellin');

UPDATE Datos
SET Valor = 'Cali'
WHERE cliente = 10 AND Variable = 'Ciudad';

DELETE FROM Datos
WHERE cliente = 10 AND Variable = 'Ciudad';





-- punto 9
CREATE TRIGGER tr_Auditoria_Datos
ON Datos
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    DECLARE @mensaje VARCHAR(100)
    DECLARE @accion VARCHAR(20)
    IF EXISTS (SELECT * FROM INSERTED)
        IF EXISTS (SELECT * FROM DELETED)
            SET @accion = 'actualizado'
        ELSE
            SET @accion = 'insertado'
    ELSE
        SET @accion = 'eliminado'

    SET @mensaje = 'Se ha ' + @accion + ' un registro el día ' + CONVERT(VARCHAR(20), GETDATE(), 120)

    INSERT INTO Auditoria (Fecha, Mensaje)
    VALUES (GETDATE(), @mensaje)
END





-------------------------------------------------------------------------------------------------











CREATE TABLE usuarios(
	Id int Primary key IDENTITY(1,1) NOT NULL,
	usuario varchar(50) NULL,
	password varchar(500) NULL,
	estado int NOT NULL,
	salt varchar(500) NULL,
)


CREATE PROCEDURE lista_usuarios
AS   
select * from usuarios
GO

CREATE PROCEDURE usuario_Por_Id
@id int
AS   
select * from usuarios
where Id = @id;
GO


CREATE PROCEDURE registrar_usuario
   
    @usuario varchar(50),   
    @password nvarchar(500),
	@estado int,
	@salt nvarchar(500)
AS  
insert into usuarios(usuario, password, estado, salt) values(@usuario, @password, @estado, @salt)
GO


CREATE PROCEDURE actualizar_usuario  
	@Id int,
    @usuario varchar(50),   
    @password nvarchar(500),
	@estado int,
	@salt varchar(500)
AS  
update usuarios set usuario = @usuario, password = @password, estado = @estado, salt = @salt where Id=@Id
GO


CREATE PROCEDURE eliminar_usuario
	@Id int
AS  
delete from usuarios where Id=@Id
GO




CREATE TABLE inventario(
	Id int Primary key IDENTITY(1,1) NOT NULL,
	FechaIngreso DateTime NULL,
	Cantidad int NULL,
	ValorUnitario int NOT NULL,
	Descripcion varchar(500) NULL,
)


CREATE PROCEDURE lista_inventario
AS   
select * from inventario
GO


CREATE PROCEDURE inventario_Por_Id
@id int
AS   
select * from inventario
where Id = @id;
GO


CREATE PROCEDURE registrar_inventario
   
    @FechaIngreso DateTime,   
    @Cantidad int,
	@ValorUnitario int,
	@Descripcion varchar(500)
AS 

insert into inventario(FechaIngreso, Cantidad, ValorUnitario, Descripcion) values(@FechaIngreso, @Cantidad, @ValorUnitario, @Descripcion)
GO


CREATE PROCEDURE actualizar_inventario  
	@Id int,
    @FechaIngreso DateTime,   
    @Cantidad int,
	@ValorUnitario int,
	@Descripcion varchar(500)
AS  
update inventario set FechaIngreso = @FechaIngreso, Cantidad = @Cantidad, ValorUnitario = @ValorUnitario, Descripcion = @Descripcion where Id=@Id
GO


CREATE PROCEDURE eliminar_inventario
	@Id int
AS  
delete from inventario where Id=@Id
GO




CREATE TABLE clientes(
	Id int Primary key IDENTITY(1,1) NOT NULL,
	NombreCliente varchar(100) NULL,
	Celular int NULL,
	Direccion varchar(100) NULL
)


CREATE PROCEDURE lista_clientes
AS   
select * from clientes
GO


CREATE PROCEDURE cliente_Por_Id
@id int
AS   
select * from clientes
where Id = @id;
GO


CREATE PROCEDURE registrar_clientes
    @NombreCliente varchar(100),
    @Celular int,
    @Direccion varchar(100)
AS 

insert into clientes(NombreCliente, Celular, Direccion) values(@NombreCliente, @Celular, @Direccion)
GO


CREATE PROCEDURE actualizar_clientes  
	@Id int,
    @NombreCliente varchar(100),
    @Celular int,
    @Direccion varchar(100)
AS  
update clientes set NombreCliente = @NombreCliente, Celular = @Celular, Direccion = @Direccion where Id=@Id
GO


CREATE PROCEDURE eliminar_clientes
	@Id int
AS  
delete from clientes where Id=@Id
GO




CREATE TABLE compras(
	Id int Primary key IDENTITY(1,1) NOT NULL,
	ordenCompra varchar(500) NULL,
	fechaCompra DateTime NULL,
	valorCompra int NOT NULL,
	medioPago varchar(500) NULL
)

CREATE PROCEDURE lista_compras
AS   
select * from compras
GO


CREATE PROCEDURE compras_Por_Id
@id int
AS   
select * from compras
where Id = @id;
GO

CREATE PROCEDURE registrar_compras
	@ordenCompra varchar(500),
    @fechaCompra DateTime,   
	@valorCompra int,
    @medioPago varchar(500)
AS 

insert into compras(ordenCompra, fechaCompra, valorCompra, medioPago) values(@ordenCompra, @fechaCompra, @valorCompra, @medioPago)
GO

CREATE PROCEDURE [dbo].[id_ultimaCompra]
AS   
	select top 1 Id from compras order by id desc
GO


CREATE PROCEDURE actualizar_compras  
	@Id int,
    @ordenCompra varchar(500),
    @fechaCompra DateTime,   
	@valorCompra int,
    @medioPago varchar(500)
AS  
update compras set ordenCompra = @ordenCompra, fechaCompra = @fechaCompra, valorCompra = @valorCompra, medioPago = @medioPago where Id=@Id
GO


CREATE PROCEDURE eliminar_compras
	@Id int
AS  
delete from compras where Id=@Id
GO


CREATE TABLE Item(
	Id int Primary key IDENTITY(1,1) NOT NULL,
    ItemId int null,
	Descripcion varchar(500) NULL,
    CompraId int null,
	ClienteId int null
    FOREIGN KEY (CompraId) REFERENCES compras(Id),
	FOREIGN KEY (ClienteId) REFERENCES clientes(Id)
)


CREATE PROCEDURE lista_Item
AS   
select * from Item
GO

CREATE PROCEDURE Item_Por_Id
@id int
AS   
select * from Item
where Id = @id;
GO

CREATE PROCEDURE registrar_Item
	@ItemId int null,
    @Descripcion varchar(500) NULL,   
	@CompraId int null,
    @ClienteId int null
AS 

insert into Item(ItemId, Descripcion, CompraId, ClienteId) values(@ItemId, @Descripcion, @CompraId, @ClienteId)
GO


CREATE PROCEDURE actualizar_Item  
	@Id int,
    @ItemId int null,
    @Descripcion varchar(500) NULL,
	@CompraId int null,
    @ClienteId int null
AS  
update Item set ItemId = @ItemId, Descripcion = @Descripcion, CompraId = @CompraId, ClienteId = @ClienteId where Id=@Id
GO


CREATE PROCEDURE eliminar_Item
	@Id int
AS  
delete from Item where Id=@Id
GO






CREATE PROCEDURE [dbo].[usuario_Por_usuario]
@usuario varchar(50)
AS   
select * from usuarios
where usuario = @usuario;
GO






-- migraciones --- 
dotnet ef dbcontext scaffold "Server=DESKTOP-GAU7660\SQLEXPRESS;Database=PrubaAgaval;Trusted_Connection=True;TrustServerCertificate=true;" Microsoft.EntityFrameworkCore.SqlServer -o Migrations
















































