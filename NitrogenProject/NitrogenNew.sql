USE [master]
GO
/****** Object:  Database [NitrogenNew]    Script Date: 19.10.2015 г. 15:01:09 ч. ******/
CREATE DATABASE [NitrogenNew]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NitrogenNew', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\NitrogenNew.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'NitrogenNew_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\NitrogenNew_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [NitrogenNew] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NitrogenNew].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NitrogenNew] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NitrogenNew] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NitrogenNew] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NitrogenNew] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NitrogenNew] SET ARITHABORT OFF 
GO
ALTER DATABASE [NitrogenNew] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NitrogenNew] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NitrogenNew] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NitrogenNew] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NitrogenNew] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NitrogenNew] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NitrogenNew] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NitrogenNew] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NitrogenNew] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NitrogenNew] SET  DISABLE_BROKER 
GO
ALTER DATABASE [NitrogenNew] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NitrogenNew] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NitrogenNew] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NitrogenNew] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NitrogenNew] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NitrogenNew] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NitrogenNew] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NitrogenNew] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [NitrogenNew] SET  MULTI_USER 
GO
ALTER DATABASE [NitrogenNew] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NitrogenNew] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NitrogenNew] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NitrogenNew] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [NitrogenNew] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'NitrogenNew', N'ON'
GO
USE [NitrogenNew]
GO
/****** Object:  Table [dbo].[Places]    Script Date: 19.10.2015 г. 15:01:09 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Places](
	[PlaceId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Places] PRIMARY KEY CLUSTERED 
(
	[PlaceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 19.10.2015 г. 15:01:09 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Places]    Script Date: 19.10.2015 г. 15:01:09 ч. ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Places] ON [dbo].[Places]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Products]    Script Date: 19.10.2015 г. 15:01:09 ч. ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Products] ON [dbo].[Products]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [NitrogenNew] SET  READ_WRITE 
GO
