USE [OnlineShopKalbe]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 8/11/2021 4:42:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[intCustomerId] [int] IDENTITY(1,1) NOT NULL,
	[txtCustomerName] [varchar](max) NULL,
	[txtCustAddress] [varchar](max) NULL,
	[bitGender] [bit] NULL,
	[dtmBirthDate] [date] NULL,
	[dtminserted] [datetime] NULL,
 CONSTRAINT [PK_Penjualan] PRIMARY KEY CLUSTERED 
(
	[intCustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Penjualan]    Script Date: 8/11/2021 4:42:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Penjualan](
	[intSalesOrderID] [int] IDENTITY(1,1) NOT NULL,
	[intCustomerID] [int] NULL,
	[intProductID] [int] NULL,
	[dtSalesOrder] [datetime] NULL,
	[intQty] [int] NULL,
 CONSTRAINT [PK_Penjualan1] PRIMARY KEY CLUSTERED 
(
	[intSalesOrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produk]    Script Date: 8/11/2021 4:42:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produk](
	[intProductId] [int] IDENTITY(1,1) NOT NULL,
	[txtProductCode] [varchar](50) NOT NULL,
	[txtProductName] [varchar](50) NULL,
	[intQuantity] [int] NULL,
	[decPrice] [decimal](18, 0) NULL,
	[dtinserted] [datetime] NULL,
 CONSTRAINT [PK_Produk] PRIMARY KEY CLUSTERED 
(
	[intProductId] ASC,
	[txtProductCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([intCustomerId], [txtCustomerName], [txtCustAddress], [bitGender], [dtmBirthDate], [dtminserted]) VALUES (1, N'asitah', N'cijantung1', 0, CAST(N'2021-08-04' AS Date), CAST(N'2021-08-11T16:38:33.870' AS DateTime))
INSERT [dbo].[Customer] ([intCustomerId], [txtCustomerName], [txtCustAddress], [bitGender], [dtmBirthDate], [dtminserted]) VALUES (2, N'devi', N'alal', 0, NULL, CAST(N'2021-08-11T15:53:18.990' AS DateTime))
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[Penjualan] ON 

INSERT [dbo].[Penjualan] ([intSalesOrderID], [intCustomerID], [intProductID], [dtSalesOrder], [intQty]) VALUES (1, 2, 1, CAST(N'2021-08-11T00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Penjualan] OFF
SET IDENTITY_INSERT [dbo].[Produk] ON 

INSERT [dbo].[Produk] ([intProductId], [txtProductCode], [txtProductName], [intQuantity], [decPrice], [dtinserted]) VALUES (1, N'KN95', N'Masker KN 95', 100, NULL, NULL)
INSERT [dbo].[Produk] ([intProductId], [txtProductCode], [txtProductName], [intQuantity], [decPrice], [dtinserted]) VALUES (2, N'KN97', N'Masker KN 97', 20, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Produk] OFF
USE [master]
GO
ALTER DATABASE [OnlineShopKalbe] SET  READ_WRITE 
GO
