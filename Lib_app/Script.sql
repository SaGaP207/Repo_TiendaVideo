/*CREATE DATABASE db_tienda_video_juegos;
GO
USE db_tienda_video_juegos;


CREATE TABLE [Sucursales]
(
  [Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
  [Nombre] VARCHAR(100) NOT NULL, 
  [Direccion] VARCHAR(100) NOT NULL,
  [Ciudad] VARCHAR(50) NOT NULL,
  [Telefono] VARCHAR(20) NOT NULL,	
  [Estado] BIT NOT NULL DEFAULT 0,	
);

INSERT INTO [Sucursales] ([Nombre], [Direccion], [Ciudad], [Telefono], [Estado])
VALUES ('Sucursal Centro', 'Calle 50 # 45-20', 'Medellín', '6044445566', 1);

CREATE TABLE [Cargos]
(
  [Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
  [Nombre_Cargo] NVARCHAR(200) NOT NULL,
  [Descripcion] NVARCHAR(MAX) NULL,
  [Salario] DECIMAL(12,2) NOT NULL
);

INSERT INTO [Cargos] ([Nombre_Cargo], [Descripcion], [Salario])
VALUES ('Administrador', 'Encargado de la gestión de la tienda', 2500000.00);


CREATE TABLE [Empleados]
(
  [Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
  [Nombre] NVARCHAR(200)  NOT NULL,
  [Cedula] VARCHAR(20) NOT NULL UNIQUE,
  [Direccion] VARCHAR(200) NOT NULL,
  [Sucursal] INT NOT NULL REFERENCES [Sucursales](Id),
  [Cargo] INT NOT NULL REFERENCES [Cargos](Id),
   
);

INSERT INTO [Empleados] ([Nombre], [Cedula], [Direccion], [Sucursal], [Cargo])
VALUES ('Carlos Gómez', '1017123456', 'Carrera 70 # 32-15', 1, 1);


CREATE TABLE [Clientes]
(
  [Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
  [Nombre] VARCHAR(100) NOT NULL,
  [Cedula] VARCHAR(20) UNIQUE NOT NULL,
  [Direccion] VARCHAR(100) NOT NULL,
  [Ciudad] VARCHAR(50) NOT NULL
);

INSERT INTO [Clientes] ([Nombre], [Cedula], [Direccion], [Ciudad])
VALUES ('María Rodríguez', '1020987654', 'Calle 10 # 40-50', 'Medellín');


CREATE TABLE [Ventas]
(
  [Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
  [Cliente] INT NOT NULL REFERENCES [Clientes](Id),
  [Empleado] INT NOT NULL REFERENCES [Empleados](Id),
  [Fecha_Venta] SMALLDATETIME NOT NULL,
  [Total] DECIMAL(12, 2) NOT NULL
 );

 INSERT INTO [Ventas] ([Cliente], [Empleado], [Fecha_Venta], [Total])
VALUES (1, 1, GETDATE(), 250000.00);


CREATE TABLE [Metodo_Pagos]
(
  [Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
  [Venta] INT NOT NULL REFERENCES [Ventas](Id),
  [Tipo_Pago] VARCHAR(50) NOT NULL,
  [Descripcion] VARCHAR(MAX) NULL
);

INSERT INTO [Metodo_Pagos] ([Venta], [Tipo_Pago], [Descripcion])
VALUES (1, 'Tarjeta de Crédito', 'Pago procesado por Datafono');


CREATE TABLE [Inventarios]
(
  [Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
  [Sucursal] INT NOT NULL REFERENCES [Sucursales](Id),
  [Cantidad] INT NOT NULL,
  [Stock_Minimo] INT NOT NULL DEFAULT 0,
  [Fecha_Actualizacion] SMALLDATETIME NOT NULL	
);

INSERT INTO [Inventarios] ([Sucursal], [Cantidad], [Stock_Minimo], [Fecha_Actualizacion])
VALUES (1, 50, 5, GETDATE());

CREATE TABLE [Provedores]
(
  [Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
  [Nit] VARCHAR(20) NOT NULL UNIQUE,
  [Nombre_Empresa] VARCHAR(100) NOT NULL,
  [Telefono] VARCHAR(20) NOT NULL,
  [Correo] VARCHAR(100) UNIQUE NOT NULL,	
);

INSERT INTO [Provedores] ([Nit], [Nombre_Empresa], [Telefono], [Correo])
VALUES ('900123456-1', 'Distribuidora Gaming Colombia', '6013334455', 'contacto@gamingcolombia.com');


CREATE TABLE [Pedidos]
(
  [Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
  [Provedor] INT NOT NULL REFERENCES [Provedores](Id),
  [Empleado] INT NOT NULL REFERENCES [Empleados](Id),
  [Fecha_Pedido] SMALLDATETIME NOT NULL,
  [Estado]  BIT NOT NULL DEFAULT 0,
  [Total] DECIMAL(12, 2) NOT NULL	
);

INSERT INTO [Pedidos] ([Provedor], [Empleado], [Fecha_Pedido], [Estado], [Total])
VALUES (1, 1, GETDATE(), 1, 1500000.00);

CREATE TABLE [Categorias]
(
  [Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
  [Nombre] VARCHAR(100) NOT NULL,
  [Descripcion] VARCHAR(MAX) NULL,
  [Estado] BIT NOT NULL DEFAULT 0,
  [Fecha_Creacion] SMALLDATETIME NOT NULL
 );

 INSERT INTO [Categorias] ([Nombre], [Descripcion], [Estado], [Fecha_Creacion])
VALUES ('Acción', 'Juegos de acción y aventura', 1, GETDATE());

CREATE TABLE [Videojuegos]
(
  [Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
  [Categoria] INT NOT NULL REFERENCES [Categorias](Id),
  [Inventario] INT NOT NULL REFERENCES [Inventarios](Id),
  [Nombre] VARCHAR(100) NOT NULL,
  [Precio] DECIMAL(12, 2) NOT NULL,
  [Estado] BIT NOT NULL DEFAULT 0,
);

INSERT INTO [Videojuegos] ([Categoria], [Inventario], [Nombre], [Precio], [Estado])
VALUES (1, 1, 'The Legend of Zelda: Tears of the Kingdom', 250000.00, 1);


CREATE TABLE [Detalle_Ventas]
(
  [Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
  [Venta] INT NOT NULL REFERENCES [Ventas](Id),
  [Videojuego] INT NOT NULL REFERENCES [Videojuegos](Id),
  [Cantidad] INT NOT NULL,
  [Precio_Unitario] DECIMAL(12, 2) NOT NULL,
  [Subtotal] DECIMAL(12, 2) NOT NULL
);

INSERT INTO [Detalle_Ventas] ([Venta], [Videojuego], [Cantidad], [Precio_Unitario], [Subtotal])
VALUES (1, 1, 1, 250000.00, 250000.00);


CREATE TABLE [Detalle_Pedidos]
(
  [Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
  [Pedido] INT NOT NULL REFERENCES [Pedidos](Id),
  [Videojuego] INT NOT NULL REFERENCES [Videojuegos](Id),
  [Cantidad] INT NOT NULL,
  [Precio_Compra] DECIMAL(12, 2) NOT NULL,
  [Subtotal] DECIMAL(12, 2) NOT NULL
);

INSERT INTO [Detalle_Pedidos] ([Pedido], [Videojuego], [Cantidad], [Precio_Compra], [Subtotal])
VALUES (1, 1, 10, 150000.00, 1500000.00);

CREATE TABLE [Plataformas]
(
  [Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
  [Nombre] VARCHAR(100) NOT NULL,
  [Fabricante] VARCHAR(100) NOT NULL,
  [Tipo_plataforma] VARCHAR(100) NOT NULL,
  [Estado] BIT NOT NULL DEFAULT 0
);

INSERT INTO [Plataformas] ([Nombre], [Fabricante], [Tipo_plataforma], [Estado])
VALUES ('Nintendo Switch', 'Nintendo', 'Consola', 1);


CREATE TABLE [VJ_Plataformas]
(
  [Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
  [Videojuego] INT NOT NULL REFERENCES [Videojuegos](Id),
  [Plataforma] INT NOT NULL REFERENCES [Plataformas](Id),
  [Fecha_Lanzamiento] SMALLDATETIME NOT NULL,
  [Precio_Plataforma] DECIMAL(12, 2) NOT NULL
 );

 INSERT INTO [VJ_Plataformas] ([Videojuego], [Plataforma], [Fecha_Lanzamiento], [Precio_Plataforma])
VALUES (1, 1, '2023-05-12', 250000.00);


CREATE TABLE [Resenas]
(
  [Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
  [Cliente] INT NOT NULL REFERENCES [Clientes](Id),
  [Videojuego] INT NOT NULL REFERENCES [Videojuegos](Id),
  [Puntuacion]DECIMAL(3,1)NOT NULL,
  [Comentario] VARCHAR(MAX) NULL,
  [Fecha_Reseña] SMALLDATETIME NOT NULL
);

INSERT INTO [Resenas] ([Cliente], [Videojuego], [Puntuacion], [Comentario], [Fecha_Reseña])
VALUES (1, 1, 5.0, 'Excelente juego, muy recomendado.', GETDATE());


CREATE TABLE [Promociones]
(
  [Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
  [Nombre] VARCHAR(100) NOT NULL,
  [Descripcion] VARCHAR(MAX) NULL,
  [Porcentaje_Desc] DECIMAL(5, 2) NOT NULL DEFAULT 0.00,
  [Fecha_Inicio] SMALLDATETIME NOT NULL,
  [Fecha_Fin] SMALLDATETIME NOT NULL
);

INSERT INTO [Promociones] ([Nombre], [Descripcion], [Porcentaje_Desc], [Fecha_Inicio], [Fecha_Fin])
VALUES ('Gran Descuento Gaming', 'Descuento especial de temporada', 10.00, GETDATE(), DATEADD(day, 30, GETDATE()));


CREATE TABLE [VJ_Promociones]
(
  [Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
  [Vj_Plataforma] INT NOT NULL REFERENCES [VJ_Plataformas](Id),
  [Promocion] INT NOT NULL REFERENCES [Promociones](Id),
  [Precio_Promocion] DECIMAL(18, 2) NOT NULL
);

INSERT INTO [VJ_Promociones] ([Vj_Plataforma], [Promocion], [Precio_Promocion])
VALUES (1, 1, 225000.00);


CREATE TABLE [Desarrolladores]
(
  [Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
  [Nombre] VARCHAR(100) NOT NULL,
  [Nit] VARCHAR(20) UNIQUE NOT NULL,
  [Pais] VARCHAR(50) NOT NULL,
  [Sitio_Web] VARCHAR(100) NOT NULL
);

INSERT INTO [Desarrolladores] ([Nombre], [Nit], [Pais], [Sitio_Web])
VALUES ('Nintendo EPD', '800999888-2', 'Japón', 'https://www.nintendo.com');


CREATE TABLE [Desarr_Videoj]
(
  [Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
  [Videojuego] INT NOT NULL REFERENCES [Videojuegos](Id),
  [Desarrollador] INT NOT NULL REFERENCES [Desarrolladores](Id),
  [Fecha_Lanzamiento] SMALLDATETIME NOT NULL,
  [Clasif_Edad] VARCHAR(10) NOT NULL
);

INSERT INTO [Desarr_Videoj] ([Videojuego], [Desarrollador], [Fecha_Lanzamiento], [Clasif_Edad])
VALUES (1, 1, '2023-05-12', 'E10+');