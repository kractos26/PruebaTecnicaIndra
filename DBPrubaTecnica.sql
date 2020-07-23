USE [CalculosIndra]
GO
/****** Object:  Table [dbo].[Calculo]    Script Date: 23/07/2020 9:39:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Calculo](
	[IdCalculo] [int] IDENTITY(1,1) NOT NULL,
	[Respuesta] [int] NULL,
	[Fecha] [datetime] NULL,
	[IdUsuario] [int] NULL,
	[Limite] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCalculo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 23/07/2020 9:39:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Calculo] ON 

INSERT [dbo].[Calculo] ([IdCalculo], [Respuesta], [Fecha], [IdUsuario], [Limite]) VALUES (1, 117743, CAST(N'2020-07-23 07:17:11.393' AS DateTime), 5, 710)
SET IDENTITY_INSERT [dbo].[Calculo] OFF
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([IdUsuario], [Nombre]) VALUES (1, N'Juliana')
INSERT [dbo].[Usuario] ([IdUsuario], [Nombre]) VALUES (2, N'Pedro')
INSERT [dbo].[Usuario] ([IdUsuario], [Nombre]) VALUES (3, N'Juan')
INSERT [dbo].[Usuario] ([IdUsuario], [Nombre]) VALUES (4, N'Lina')
INSERT [dbo].[Usuario] ([IdUsuario], [Nombre]) VALUES (5, N'juan')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
ALTER TABLE [dbo].[Calculo]  WITH CHECK ADD FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
