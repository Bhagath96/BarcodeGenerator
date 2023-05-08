USE [master]
GO
/****** Object:  Database [BarcodeGenerator]    Script Date: 12-03-2023 19:17:59 ******/
CREATE DATABASE [BarcodeGenerator]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BarcodeGenerator', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\BarcodeGenerator.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BarcodeGenerator_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\BarcodeGenerator_log.ldf' , SIZE = 204800KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [BarcodeGenerator] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BarcodeGenerator].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BarcodeGenerator] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BarcodeGenerator] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BarcodeGenerator] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BarcodeGenerator] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BarcodeGenerator] SET ARITHABORT OFF 
GO
ALTER DATABASE [BarcodeGenerator] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BarcodeGenerator] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BarcodeGenerator] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BarcodeGenerator] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BarcodeGenerator] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BarcodeGenerator] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BarcodeGenerator] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BarcodeGenerator] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BarcodeGenerator] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BarcodeGenerator] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BarcodeGenerator] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BarcodeGenerator] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BarcodeGenerator] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BarcodeGenerator] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BarcodeGenerator] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BarcodeGenerator] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BarcodeGenerator] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BarcodeGenerator] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BarcodeGenerator] SET  MULTI_USER 
GO
ALTER DATABASE [BarcodeGenerator] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BarcodeGenerator] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BarcodeGenerator] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BarcodeGenerator] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BarcodeGenerator] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BarcodeGenerator] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BarcodeGenerator] SET QUERY_STORE = ON
GO
ALTER DATABASE [BarcodeGenerator] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [BarcodeGenerator]
GO
/****** Object:  Table [dbo].[Data]    Script Date: 12-03-2023 19:17:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Data](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UIT] [nvarchar](max) NULL,
	[Article] [nvarchar](max) NULL,
	[CodeColors] [nvarchar](max) NULL,
	[ItemName] [nvarchar](max) NULL,
	[Manufacturer] [nvarchar](250) NULL,
	[CountryOfOrigin] [nvarchar](max) NULL,
	[Trademark] [nvarchar](max) NULL,
	[CORMT] [nvarchar](250) NULL,
	[CORML] [nvarchar](250) NULL,
	[SoleComposition] [nvarchar](250) NULL,
	[MFCSM] [nvarchar](max) NULL,
	[SizeAge] [nvarchar](max) NULL,
	[RussianSize] [nvarchar](max) NULL,
	[TNVED_code] [nvarchar](max) NULL,
	[EAN] [nvarchar](max) NULL,
	[Quantity] [nvarchar](max) NULL,
	[GTIN] [nvarchar](max) NULL,
	[DataMatrix] [nvarchar](max) NULL,
	[ManufacturerAddress] [nvarchar](max) NULL,
	[ExporterAddress] [nvarchar](max) NULL,
	[MFGDate] [nvarchar](max) NULL,
	[TABLENAME] [nvarchar](max) NULL,
	[PRINTDATETIME] [nvarchar](max) NULL,
	[STATUS] [bit] NULL,
	[CreatedDatetime] [date] NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[ModifiedDatetime] [date] NULL,
	[ModifiedBy] [nvarchar](500) NULL,
	[ExcelName] [nvarchar](100) NULL,
	[SheetName] [nvarchar](100) NULL,
 CONSTRAINT [PK_DATA] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRINT2]    Script Date: 12-03-2023 19:17:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRINT2](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UIT] [nvarchar](50) NULL,
	[Article] [nvarchar](50) NULL,
	[CodeColors] [nvarchar](50) NULL,
	[ItemName] [nvarchar](50) NULL,
	[Manufacturer] [nvarchar](250) NULL,
	[CountryOfOrigin] [nvarchar](50) NULL,
	[Trademark] [nvarchar](50) NULL,
	[CORMT] [nvarchar](250) NULL,
	[CORML] [nvarchar](250) NULL,
	[SoleComposition] [nvarchar](250) NULL,
	[MFCSM] [nvarchar](50) NULL,
	[SizeAge] [nvarchar](50) NULL,
	[RussianSize] [nvarchar](50) NULL,
	[TNVED_code] [nvarchar](50) NULL,
	[EAN] [nvarchar](50) NULL,
	[Quantity] [nvarchar](50) NULL,
	[GTIN] [nvarchar](50) NULL,
	[DataMatrix] [nvarchar](max) NULL,
	[ManufacturerAddress] [nvarchar](max) NULL,
	[ExporterAddress] [nvarchar](max) NULL,
	[MFGDate] [nvarchar](50) NULL,
	[TABLENAME] [nvarchar](max) NULL,
	[PRINTDATETIME] [nvarchar](max) NULL,
	[STATUS] [bit] NULL,
	[DataTableID] [int] NULL,
 CONSTRAINT [PK_PRINT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[UPDATE_All_DATABY_ID]    Script Date: 12-03-2023 19:17:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UPDATE_All_DATABY_ID] 
    -- Add the parameters for the stored procedure here
     @EAN AS nvarchar(MAX)
   
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    --SET NOCOUNT ON;    UPDATE [Data] SET Status=1, ModifiedDatetime = convert(varchar, getdate(), 120) where EAN=@EAN  
    DELETE FROM [dbo].[PRINT2]   
    insert into [dbo].[PRINT2] (DataTableID, UIT, Article, CodeColors, ItemName, Manufacturer, CountryOfOrigin, Trademark,
CORMT, CORML, SoleComposition, MFCSM, SizeAge, RussianSize, TNVED_code, EAN, Quantity, GTIN, DataMatrix, ManufacturerAddress, ExporterAddress,
MFGDate, TABLENAME, PRINTDATETIME, STATUS)       
select ID, UIT, Article, CodeColors, ItemName, Manufacturer,CountryOfOrigin, Trademark, CORMT, CORML, SoleComposition, MFCSM, SizeAge, 
RussianSize, TNVED_code, EAN, Quantity, GTIN, DataMatrix, ManufacturerAddress, ExporterAddress, MFGDate, TABLENAME, 
PRINTDATETIME, STATUS from [dbo].[Data] where EAN=@EAN and STATUS !=1 

select * from [dbo].[PRINT2]

  END
GO
/****** Object:  StoredProcedure [dbo].[UPDATEDATAByID]    Script Date: 12-03-2023 19:17:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UPDATEDATAByID] 
    -- Add the parameters for the stored procedure here
     @EAN AS nvarchar(MAX), 
     @MaxCount AS INT  
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    --SET NOCOUNT ON;    UPDATE [Data] SET Status=1, ModifiedDatetime = convert(varchar, getdate(), 120) where EAN=@EAN  
    DELETE FROM [dbo].[PRINT2]   
    insert into [dbo].[PRINT2] (DataTableID, UIT, Article, CodeColors, ItemName, Manufacturer, CountryOfOrigin, Trademark,
CORMT, CORML, SoleComposition, MFCSM, SizeAge, RussianSize, TNVED_code, EAN, Quantity, GTIN, DataMatrix, ManufacturerAddress, ExporterAddress,
MFGDate, TABLENAME, PRINTDATETIME, STATUS)       
select top (@MaxCount) ID,UIT, Article, CodeColors, ItemName, Manufacturer,CountryOfOrigin, Trademark, CORMT, CORML, SoleComposition, MFCSM, SizeAge, 
RussianSize, TNVED_code, EAN, Quantity, GTIN, DataMatrix, ManufacturerAddress, ExporterAddress, MFGDate, TABLENAME, 
PRINTDATETIME, STATUS from [dbo].[Data] where EAN=@EAN and STATUS !=1 order by ID asc  

select * from [dbo].[PRINT2]

  END
GO
USE [master]
GO
ALTER DATABASE [BarcodeGenerator] SET  READ_WRITE 
GO
