USE PEDIDO;

SELECT * FROM Producto;

INSERT INTO Producto(nombre, precio, stockActual, stockMinimo)
VALUES
('Teclado Redragon Kumara', 45000, 15, 5),
('Mouse Logitech G203', 32000, 20, 5),
('Monitor Samsung 24"', 180000, 8, 2),
('Auriculares HyperX Cloud', 95000, 10, 3),
('Webcam Logitech C920', 85000, 4, 2);

INSERT INTO Proveedor (nombre, correo, telefono)
VALUES
('Juan Perez', 'juan@gmail.com', '1134567890'),
('Carlos Gomez', 'carlos@gmail.com', '1145678901'),
('María López', 'maria@gmail.com', '1156789012');