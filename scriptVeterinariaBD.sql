
 CREATE DATABASE Veterinaria404850
 USE [Veterinaria404850]
GO
/****** Object:  Table [dbo].[Especies]    Script Date: 2/7/2021 23:38:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Especies](
	[idEspecie] [int] identity(1,1) NOT NULL,
	[nombreEspecie] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Especies] PRIMARY KEY CLUSTERED 
(
	[idEspecie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mascotas]    Script Date: 2/7/2021 23:38:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mascotas](
	[codigo] [int] identity(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[especie] [int] NOT NULL,
	[sexo] [int] NOT NULL,
	[fechaNacimiento] [date] NOT NULL,
 CONSTRAINT [PK_Mascotas] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Especies] ([nombreEspecie]) VALUES (N'Perro')
INSERT [dbo].[Especies] ([nombreEspecie]) VALUES (N'Roedor')
INSERT [dbo].[Especies] ([nombreEspecie]) VALUES (N'Gato')
INSERT [dbo].[Especies] ([nombreEspecie]) VALUES (N'Reptil')
INSERT [dbo].[Especies] ([nombreEspecie]) VALUES (N'Ave')
GO
INSERT [dbo].[Mascotas] ([nombre], [especie], [sexo], [fechaNacimiento]) VALUES (N'Boby', 1, 1, CAST(N'2020-10-10' AS Date))
INSERT [dbo].[Mascotas] ([nombre], [especie], [sexo], [fechaNacimiento]) VALUES (N'Michi', 3, 2, CAST(N'2020-10-01' AS Date))
GO
