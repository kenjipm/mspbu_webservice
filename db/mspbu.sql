USE [mspbu]
GO
/****** Object:  Table [dbo].[stock]    Script Date: 06/24/2014 21:13:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[stock](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NULL,
	[product] [varchar](20) NULL,
	[jumlah] [float] NULL,
	[endurance] [varchar](50) NULL,
	[next_shipment] [date] NULL,
	[insert_date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[spp]    Script Date: 06/24/2014 21:13:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[spp](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NULL,
	[name] [varchar](50) NULL,
	[address] [varchar](250) NULL,
	[police_no] [varchar](12) NULL,
	[shipment_no] [varchar](50) NULL,
	[volume] [float] NULL,
	[dens_temp] [varchar](20) NULL,
	[buyer] [varchar](100) NULL,
	[product] [varchar](20) NULL,
	[print_date] [datetime] NULL,
	[verification_date] [datetime] NULL,
	[status] [varchar](32) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[spp] ON
INSERT [dbo].[spp] ([Id], [username], [name], [address], [police_no], [shipment_no], [volume], [dens_temp], [buyer], [product], [print_date], [verification_date], [status]) VALUES (1, N'asdf', N' Raja Naingnungging

', N'Jl. Kelapa Nias KM Z Kelapa Gading Sunter
Jakarta

', N' B8321AA
', N' 182973783045928649

', 20.3, N'0302/26
', N' PT Tangan Bersih

', N' Solar

', NULL, CAST(0x0000A34400C4EC73 AS DateTime), N'Sukses')
INSERT [dbo].[spp] ([Id], [username], [name], [address], [police_no], [shipment_no], [volume], [dens_temp], [buyer], [product], [print_date], [verification_date], [status]) VALUES (2, N'kenjipm', N'TESSS', N'asdf', N'pji', N'jpi', 22, NULL, NULL, NULL, NULL, NULL, N'Sukses')
INSERT [dbo].[spp] ([Id], [username], [name], [address], [police_no], [shipment_no], [volume], [dens_temp], [buyer], [product], [print_date], [verification_date], [status]) VALUES (3, N'kenjipm', N'SETT', N'dfs', N'jio', N'ji', 21, N'jip', N'n', N'j', NULL, NULL, N'Gagal')
INSERT [dbo].[spp] ([Id], [username], [name], [address], [police_no], [shipment_no], [volume], [dens_temp], [buyer], [product], [print_date], [verification_date], [status]) VALUES (4, N'kenjipm', N'TEST', N'OUNFDS', N'nfsdoa', N'nofds', 99, N'n', N'n', N'j', NULL, NULL, N'Sukses')
INSERT [dbo].[spp] ([Id], [username], [name], [address], [police_no], [shipment_no], [volume], [dens_temp], [buyer], [product], [print_date], [verification_date], [status]) VALUES (5, N'fdsa', N'onufds', N'fsdon', N'dfnsjo', N'fdso', 8, NULL, N'n', NULL, NULL, NULL, N'Sukses')
INSERT [dbo].[spp] ([Id], [username], [name], [address], [police_no], [shipment_no], [volume], [dens_temp], [buyer], [product], [print_date], [verification_date], [status]) VALUES (6, N'kenjipm', N'SETS', N'f0sdhj', N'fndsoi', N'nofds', 84, N'fdsno', N'fdsnjl', N'fs', NULL, NULL, N'Gagal')
INSERT [dbo].[spp] ([Id], [username], [name], [address], [police_no], [shipment_no], [volume], [dens_temp], [buyer], [product], [print_date], [verification_date], [status]) VALUES (7, N'kenjipm', N'ofaniwe', N'nfdsoiw', N'fdno', N'fwon', 80, N'fds', N'fsd', NULL, NULL, NULL, N'Sukses')
INSERT [dbo].[spp] ([Id], [username], [name], [address], [police_no], [shipment_no], [volume], [dens_temp], [buyer], [product], [print_date], [verification_date], [status]) VALUES (8, N'ffff', N'fsond', N'fdsno', N'fds', N'fds', 5, N'nfjskd', N'fndjs', N'fds', NULL, NULL, N'Sukses')
INSERT [dbo].[spp] ([Id], [username], [name], [address], [police_no], [shipment_no], [volume], [dens_temp], [buyer], [product], [print_date], [verification_date], [status]) VALUES (9, N'kenjipm', N'aofns', N'dsnoj', N'sfdon', N'fds', 1, N'fsd', N'wfd', N'sdf', NULL, NULL, N'Sukses')
INSERT [dbo].[spp] ([Id], [username], [name], [address], [police_no], [shipment_no], [volume], [dens_temp], [buyer], [product], [print_date], [verification_date], [status]) VALUES (10, N'jsfad', N'afdsnlk', N'fndjsl', N'fdnsl', N'fdsnl', 888, N'fdsln', N'sdnl', N'fd', NULL, NULL, N'Sukses')
INSERT [dbo].[spp] ([Id], [username], [name], [address], [police_no], [shipment_no], [volume], [dens_temp], [buyer], [product], [print_date], [verification_date], [status]) VALUES (11, N'kenjipm', N'faonu', N'fdsno', N'fdnjso', N'fnjs', 88, N'jsflkd', N'sfdjnl', N'fdsl', NULL, NULL, N'Sukses')
SET IDENTITY_INSERT [dbo].[spp] OFF
/****** Object:  Table [dbo].[login]    Script Date: 06/24/2014 21:13:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[login](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[nama_id] [varchar](50) NULL,
	[alamat] [varchar](200) NULL,
	[pemilik] [varchar](50) NULL,
	[role] [varchar](16) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[login] ON
INSERT [dbo].[login] ([Id], [username], [password], [nama_id], [alamat], [pemilik], [role]) VALUES (1, N'kenjipm', N'kenjipm', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[login] OFF
/****** Object:  Table [dbo].[dispencer]    Script Date: 06/24/2014 21:13:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[dispencer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NULL,
	[product] [varchar](20) NULL,
	[jumlah_keluar] [float] NULL,
	[waktu_keluar] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
