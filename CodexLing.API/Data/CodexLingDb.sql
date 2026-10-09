-- ==============================================================================
-- DDL Data Definition Language
-- Proyecto: CodexLingAPI (Basado en la estructura de ApiCQRS / PrimerEntregableBD ll)
-- ==============================================================================

CREATE DATABASE CodexLingDb;
GO

USE CodexLingDb;
GO

-- Tabla principal de Usuarios
CREATE TABLE Usuarios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    Email NVARCHAR(150) NOT NULL UNIQUE,
    ContrasenaHash NVARCHAR(255) NOT NULL,
    FechaCreacion DATETIME DEFAULT GETDATE(),
    Activo BIT DEFAULT 1
);
GO

-- Tabla para el registro de auditoría (Comandos CQRS)
CREATE TABLE AuditoriaComandos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Comando NVARCHAR(255) NOT NULL,
    DatosNuevos NVARCHAR(MAX),
    FechaEjecucion DATETIME DEFAULT GETDATE(),
    UsuarioId INT FOREIGN KEY REFERENCES Usuarios(Id)
);
GO
