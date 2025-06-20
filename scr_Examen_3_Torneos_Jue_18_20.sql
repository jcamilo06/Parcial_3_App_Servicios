CREATE DATABASE [DBTorneo]
GO
USE [DBTorneo]
GO
/****** Object:  Table [dbo].[AdministradorITM]    Script Date: 4/20/2025 1:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdministradorITM](
	[idAministradorITM] [int] NOT NULL,
	[Documento] [varchar](20) NOT NULL,
	[NombreCompleto] [varchar](80) NOT NULL,
	[Usuario] [varchar](20) NOT NULL,
	[Clave] [varchar](50) NOT NULL,
 CONSTRAINT [PK_AdministradorITM] PRIMARY KEY CLUSTERED 
(
	[idAministradorITM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Torneos]    Script Date: 4/20/2025 1:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Torneos](
	[idTorneos] [int] IDENTITY(1,1) NOT NULL,
	[idAdministradorITM] [int] NOT NULL,
	[TipoTorneo] [varchar](30) NOT NULL,
	[NombreTorneo] [varchar](30) NOT NULL,
	[NombreEquipo] [varchar](30) NOT NULL,
	[ValorInscripcion] [int] NOT NULL,
	[FechaTorneo] [date] NOT NULL,
	[Integrantes] [varchar](500) NOT NULL,
 CONSTRAINT [PK_Torneos] PRIMARY KEY CLUSTERED 
(
	[idTorneos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Torneos]  WITH CHECK ADD  CONSTRAINT [FK_Torneos_AdministradorITM] FOREIGN KEY([idAdministradorITM])
REFERENCES [dbo].[AdministradorITM] ([idAministradorITM])
GO
ALTER TABLE [dbo].[Torneos] CHECK CONSTRAINT [FK_Torneos_AdministradorITM]
GO

INSERT INTO [AdministradorITM]
VALUES
	(1, '1025999', 'Manuela Estrada', 'M4nu0113', '123*'),
	(2, '1010505', 'Camilo Duarte', 'Juank06', '123*'),
	(3, '1020123', 'Karina Hoyos', 'Kar1n1s', '123*')

SELECT * FROM [AdministradorITM]

INSERT INTO [Torneos] ([idAdministradorITM], [TipoTorneo], [NombreTorneo], [NombreEquipo], [ValorInscripcion], [FechaTorneo], [Integrantes])
VALUES
	(1, 'futbol', 'preliminares nacional', 'futbros', 300000, GETDATE(), 'Juan, Maria, Pedro, Julia'),
	(2, 'baloncesto', 'amistoso intercolegiado', 'rusterballers', 450000, '2020-08-06', 'Antonio, Stiven, Jerson, Santiago'),
	(1, 'programación', 'programando ando', 'tryOntech', 50000, '2021-05-08', 'Fernanda, Camila, Juan, Carolina'),
	(3, 'tenis', 'tenis y no de mesa', 'raqueteros', 800000, GETDATE(), 'Luis, Lucia, Mariano, Maria'),
	(3, 'tenis', 'antenis', 'zandilla', 700000, GETDATE(), 'Evelyn, Diego, Andres, Mariano')

SELECT * FROM [Torneos]
