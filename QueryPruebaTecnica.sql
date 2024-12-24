-- Crear base de datos
CREATE DATABASE pt_RegistroFallasEquipos;
GO

-- Usar la base de datos creada
USE pt_RegistroFallasEquipos;
GO

-- Crear tabla de propietarios
CREATE TABLE Propietarios (
    IdPropietario INT IDENTITY(1,1) PRIMARY KEY,
    NombrePropietario VARCHAR(100) NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL
);
GO

-- Crear tabla de equipos
CREATE TABLE Equipos (
    IdEquipo INT IDENTITY(1,1) PRIMARY KEY,
    IdPropietario INT NOT NULL,
    NombreEquipo VARCHAR(100) NOT NULL,
    Descripcion TEXT,
    FOREIGN KEY (IdPropietario) REFERENCES Propietarios(IdPropietario)
);
GO

-- Crear tabla de fallas
CREATE TABLE Fallas (
    IdFalla INT IDENTITY(1,1) PRIMARY KEY,
    IdEquipo INT NOT NULL,
    DescripcionFalla TEXT NOT NULL,
    FechaFalla DATETIME NOT NULL,
    FOREIGN KEY (IdEquipo) REFERENCES Equipos(IdEquipo)
);
GO



-- Insertar datos en la tabla de propietarios
INSERT INTO Propietarios (NombrePropietario, Email) VALUES
('Juan Pérez', 'juan.perez@example.com'),
('Ana Gómez', 'ana.gomez@example.com');
GO

-- Insertar datos en la tabla de equipos
INSERT INTO Equipos (IdPropietario, NombreEquipo, Descripcion) VALUES
(1, 'Equipo A', 'Descripción del Equipo A'),
(2, 'Equipo B', 'Descripción del Equipo B');
GO

-- Insertar datos en la tabla de fallas
INSERT INTO Fallas (IdEquipo, DescripcionFalla, FechaFalla) VALUES
(1, 'Falla en el motor', '2024-07-31 10:00:00'),
(2, 'Falla en el sistema eléctrico', '2024-07-30 14:30:00');
GO


-- Seleccionar todos los registros de equipos con fallas con su propietario y detalles de la falla
--SELECT f.IdFalla, e.NombreEquipo, f.DescripcionFalla, f.FechaFalla, p.NombrePropietario, p.Email
--FROM Fallas f
--JOIN Equipos e ON f.IdEquipo = e.IdEquipo
--JOIN Propietarios p ON e.IdPropietario = p.IdPropietario
--GO


-- Declarar los parámetros opcionales
DECLARE @DescripcionFalla NVARCHAR(255) = NULL;
DECLARE @FechaFalla DATE = NULL;
DECLARE @NombrePropietario NVARCHAR(255) = NULL;

-- Consulta con filtros opcionales
SELECT f.IdFalla, e.NombreEquipo, f.DescripcionFalla, f.FechaFalla, p.NombrePropietario, p.Email
FROM Fallas f
JOIN Equipos e ON f.IdEquipo = e.IdEquipo
JOIN Propietarios p ON e.IdPropietario = p.IdPropietario
WHERE
    (@DescripcionFalla IS NULL OR f.DescripcionFalla LIKE '%' + @DescripcionFalla + '%') AND
    (@FechaFalla IS NULL OR CAST(f.FechaFalla AS DATE) = @FechaFalla) AND
    (@NombrePropietario IS NULL OR p.NombrePropietario LIKE '%' + @NombrePropietario + '%');
