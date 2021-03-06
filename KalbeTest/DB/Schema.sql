USE [master]
GO
/****** Object:  Database [OnlineShopKalbe]    Script Date: 8/11/2021 4:42:03 PM ******/
CREATE DATABASE [OnlineShopKalbe]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OnlineShopKalbe', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\OnlineShopKalbe.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OnlineShopKalbe_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\OnlineShopKalbe_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [OnlineShopKalbe] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OnlineShopKalbe].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OnlineShopKalbe] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OnlineShopKalbe] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OnlineShopKalbe] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OnlineShopKalbe] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OnlineShopKalbe] SET ARITHABORT OFF 
GO
ALTER DATABASE [OnlineShopKalbe] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OnlineShopKalbe] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OnlineShopKalbe] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OnlineShopKalbe] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OnlineShopKalbe] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OnlineShopKalbe] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OnlineShopKalbe] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OnlineShopKalbe] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OnlineShopKalbe] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OnlineShopKalbe] SET  DISABLE_BROKER 
GO
ALTER DATABASE [OnlineShopKalbe] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OnlineShopKalbe] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OnlineShopKalbe] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OnlineShopKalbe] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OnlineShopKalbe] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OnlineShopKalbe] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OnlineShopKalbe] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OnlineShopKalbe] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [OnlineShopKalbe] SET  MULTI_USER 
GO
ALTER DATABASE [OnlineShopKalbe] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OnlineShopKalbe] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OnlineShopKalbe] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OnlineShopKalbe] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OnlineShopKalbe] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [OnlineShopKalbe] SET QUERY_STORE = OFF
GO
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
