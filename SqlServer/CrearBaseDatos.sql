CREATE DATABASE Pedido;

USE Pedido;

CREATE TABLE Proveedor(
	id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	nombre VARCHAR(100) NOT NULL,
	correo VARCHAR(100), 
	telefono VARCHAR(50) NOT NULL

);

CREATE TABLE Producto(
	id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	nombre VARCHAR(100) NOT NULL,
	precio DECIMAL(10,2) NOT NULL CHECK(precio > 0)
);

CREATE TABLE CabeceraCompra(
	id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	fecha DATETIME DEFAULT GETDATE(),
	idProveedor INT NOT NULL,

	FOREIGN KEY (idProveedor) REFERENCES Proveedor(id)
);

CREATE TABLE DetalleCompra(
	id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	idCabecera INT NOT NULL,
	idProducto INT NOT NULL,
	cantidad INT NOT NULL CHECK(cantidad > 0),
	precioUnitario DECIMAL(10,2) NOT NULL CHECK(precioUnitario > 0),

	FOREIGN KEY (idCabecera) REFERENCES CabeceraCompra(id),
	FOREIGN KEY(idProducto) REFERENCES Producto(id)
);

ALTER TABLE Producto
ADD
    stockActual INT NOT NULL DEFAULT 0,
    stockMinimo INT NOT NULL DEFAULT 0;

SELECT * FROM Producto