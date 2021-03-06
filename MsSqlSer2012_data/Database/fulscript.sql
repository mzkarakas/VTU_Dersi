USE [master]
GO
/****** Object:  Database [SporSalonuDataBase]    Script Date: 15.05.2018 16:55:28 ******/
CREATE DATABASE [SporSalonuDataBase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SporSalonuDataBase', FILENAME = N'F:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\SporSalonuDataBase.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SporSalonuDataBase_log', FILENAME = N'F:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\SporSalonuDataBase_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SporSalonuDataBase] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SporSalonuDataBase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SporSalonuDataBase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SporSalonuDataBase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SporSalonuDataBase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SporSalonuDataBase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SporSalonuDataBase] SET ARITHABORT OFF 
GO
ALTER DATABASE [SporSalonuDataBase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SporSalonuDataBase] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [SporSalonuDataBase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SporSalonuDataBase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SporSalonuDataBase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SporSalonuDataBase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SporSalonuDataBase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SporSalonuDataBase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SporSalonuDataBase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SporSalonuDataBase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SporSalonuDataBase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SporSalonuDataBase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SporSalonuDataBase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SporSalonuDataBase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SporSalonuDataBase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SporSalonuDataBase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SporSalonuDataBase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SporSalonuDataBase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SporSalonuDataBase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SporSalonuDataBase] SET  MULTI_USER 
GO
ALTER DATABASE [SporSalonuDataBase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SporSalonuDataBase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SporSalonuDataBase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SporSalonuDataBase] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [SporSalonuDataBase]
GO
/****** Object:  Table [dbo].[Odemeler]    Script Date: 15.05.2018 16:55:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Odemeler](
	[OdemeID] [int] IDENTITY(1,1) NOT NULL,
	[Uye_id] [int] NULL,
	[OdemeTarihi] [nchar](20) NULL,
	[OdemeTutari] [nchar](10) NULL,
 CONSTRAINT [PK_Odemeler] PRIMARY KEY CLUSTERED 
(
	[OdemeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Satislar]    Script Date: 15.05.2018 16:55:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Satislar](
	[SatisID] [int] IDENTITY(1,1) NOT NULL,
	[Uye_id] [int] NULL,
	[UrunAdi] [nchar](20) NULL,
	[Fiyat] [nchar](10) NULL,
	[Adet] [int] NULL,
	[Tutar] [nchar](10) NULL,
 CONSTRAINT [PK_Satislar_1] PRIMARY KEY CLUSTERED 
(
	[SatisID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SporGunlugu]    Script Date: 15.05.2018 16:55:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SporGunlugu](
	[SporID] [int] IDENTITY(1,1) NOT NULL,
	[Uye_id] [int] NULL,
	[Tarih] [nchar](20) NULL,
	[GelisSaati] [nchar](10) NULL,
	[CikisSaati] [nchar](10) NULL,
	[Boy] [nchar](10) NULL,
	[Kilo] [nchar](10) NULL,
	[Gogus] [nchar](10) NULL,
	[Bel] [nchar](10) NULL,
	[Kalca] [nchar](10) NULL,
	[Baldir] [nchar](10) NULL,
	[Bilek] [nchar](10) NULL,
	[Pazu] [nchar](10) NULL,
 CONSTRAINT [PK_Satislar] PRIMARY KEY CLUSTERED 
(
	[SporID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Urunler]    Script Date: 15.05.2018 16:55:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Urunler](
	[UrunID] [int] IDENTITY(1,1) NOT NULL,
	[UrunAdi] [nchar](20) NULL,
	[Fiyat] [nchar](10) NULL,
 CONSTRAINT [PK_Urunler] PRIMARY KEY CLUSTERED 
(
	[UrunID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Uyeler]    Script Date: 15.05.2018 16:55:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Uyeler](
	[UyeID] [int] IDENTITY(1,1) NOT NULL,
	[UyeNo] [nchar](10) NOT NULL,
	[UyeAdi] [nvarchar](20) NULL,
	[UyeSoyadi] [nvarchar](20) NULL,
	[UyeCinsiyet] [nchar](20) NULL,
	[UyeDogumTarihi] [nchar](20) NULL,
	[UyeKayitTarihi] [nchar](20) NULL,
	[UyeTelefon] [nchar](20) NULL,
	[UyeMail] [nvarchar](50) NULL,
	[UyeBorcu] [nchar](10) NULL,
 CONSTRAINT [PK_Uyeler] PRIMARY KEY CLUSTERED 
(
	[UyeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Yetkililer]    Script Date: 15.05.2018 16:55:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Yetkililer](
	[YetkiliTcNo] [nchar](11) NOT NULL,
	[YetkiliAdi] [nchar](20) NULL,
	[YetkiliSoyadi] [nchar](20) NULL,
	[YetkiliTelefon] [nchar](15) NULL,
	[YetkiliMail] [nchar](30) NULL,
	[YetkiliKullaniciAdi] [nchar](20) NULL,
	[YetkiliSifre] [nchar](20) NULL,
	[YetkiliTuru] [nchar](10) NULL,
 CONSTRAINT [PK_Yetkililer] PRIMARY KEY CLUSTERED 
(
	[YetkiliTcNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Odemeler] ON 

INSERT [dbo].[Odemeler] ([OdemeID], [Uye_id], [OdemeTarihi], [OdemeTutari]) VALUES (1, 7, N'200                 ', N'15.05.2018')
INSERT [dbo].[Odemeler] ([OdemeID], [Uye_id], [OdemeTarihi], [OdemeTutari]) VALUES (2, 7, N'100                 ', N'15.05.2018')
SET IDENTITY_INSERT [dbo].[Odemeler] OFF
SET IDENTITY_INSERT [dbo].[Satislar] ON 

INSERT [dbo].[Satislar] ([SatisID], [Uye_id], [UrunAdi], [Fiyat], [Adet], [Tutar]) VALUES (40, 7, N'Aylik Tarife        ', N'100       ', 1, N'100       ')
INSERT [dbo].[Satislar] ([SatisID], [Uye_id], [UrunAdi], [Fiyat], [Adet], [Tutar]) VALUES (41, 7, N'Bisiklet            ', N'350       ', 1, N'350       ')
INSERT [dbo].[Satislar] ([SatisID], [Uye_id], [UrunAdi], [Fiyat], [Adet], [Tutar]) VALUES (42, 7, N'Bileklik            ', N'35,5      ', 1, N'35,5      ')
INSERT [dbo].[Satislar] ([SatisID], [Uye_id], [UrunAdi], [Fiyat], [Adet], [Tutar]) VALUES (43, 7, N'baskül              ', N'75,5      ', 2, N'151       ')
SET IDENTITY_INSERT [dbo].[Satislar] OFF
SET IDENTITY_INSERT [dbo].[SporGunlugu] ON 

INSERT [dbo].[SporGunlugu] ([SporID], [Uye_id], [Tarih], [GelisSaati], [CikisSaati], [Boy], [Kilo], [Gogus], [Bel], [Kalca], [Baldir], [Bilek], [Pazu]) VALUES (1020, 7, N'10.05.2018          ', NULL, N'21:50     ', N'111.11    ', N'222.22    ', N'333.33    ', N'444.44    ', N'555.55    ', N'666.66    ', N'77.77     ', N'88.88     ')
INSERT [dbo].[SporGunlugu] ([SporID], [Uye_id], [Tarih], [GelisSaati], [CikisSaati], [Boy], [Kilo], [Gogus], [Bel], [Kalca], [Baldir], [Bilek], [Pazu]) VALUES (1021, 8, N'15.05.2018          ', NULL, NULL, N'   .      ', N'   .      ', N'   .      ', N'   .      ', N'   .      ', N'   .      ', N'   .      ', N'   .      ')
INSERT [dbo].[SporGunlugu] ([SporID], [Uye_id], [Tarih], [GelisSaati], [CikisSaati], [Boy], [Kilo], [Gogus], [Bel], [Kalca], [Baldir], [Bilek], [Pazu]) VALUES (1022, 7, N'12.05.2018          ', NULL, N'21:50     ', N'111.11    ', N'222.22    ', N'333.33    ', N'444.44    ', N'555.55    ', N'666.66    ', N'77.77     ', N'88.88     ')
INSERT [dbo].[SporGunlugu] ([SporID], [Uye_id], [Tarih], [GelisSaati], [CikisSaati], [Boy], [Kilo], [Gogus], [Bel], [Kalca], [Baldir], [Bilek], [Pazu]) VALUES (1026, 7, N'15.05.2018          ', N'23:20     ', N'21:50     ', N'   .      ', N'222.22    ', N'333.33    ', N'444.44    ', N'555.55    ', N'666.66    ', N'77.77     ', N'88.88     ')
INSERT [dbo].[SporGunlugu] ([SporID], [Uye_id], [Tarih], [GelisSaati], [CikisSaati], [Boy], [Kilo], [Gogus], [Bel], [Kalca], [Baldir], [Bilek], [Pazu]) VALUES (1028, 8, N'11.05.2018          ', N'23:42     ', N'  :       ', N'   .      ', N'   .      ', N'   .      ', N'   .      ', N'   .      ', N'   .      ', N'  .       ', N'  .       ')
INSERT [dbo].[SporGunlugu] ([SporID], [Uye_id], [Tarih], [GelisSaati], [CikisSaati], [Boy], [Kilo], [Gogus], [Bel], [Kalca], [Baldir], [Bilek], [Pazu]) VALUES (1030, 7, N'13.05.2018          ', N'21:33     ', N'21:33     ', N'   .      ', N'   .      ', N'   .      ', N'   .      ', N'   .      ', N'   .      ', N'66.66     ', N'66.66     ')
INSERT [dbo].[SporGunlugu] ([SporID], [Uye_id], [Tarih], [GelisSaati], [CikisSaati], [Boy], [Kilo], [Gogus], [Bel], [Kalca], [Baldir], [Bilek], [Pazu]) VALUES (1031, 7, N'14.05.2018          ', N'22:41     ', N'21:50     ', N'111.11    ', N'222.22    ', N'333.33    ', N'444.44    ', N'555.55    ', N'666.66    ', N'77.77     ', N'88.88     ')
SET IDENTITY_INSERT [dbo].[SporGunlugu] OFF
SET IDENTITY_INSERT [dbo].[Urunler] ON 

INSERT [dbo].[Urunler] ([UrunID], [UrunAdi], [Fiyat]) VALUES (1, N'Aylik Tarife        ', N'100       ')
INSERT [dbo].[Urunler] ([UrunID], [UrunAdi], [Fiyat]) VALUES (5, N'Bisiklet            ', N'350       ')
INSERT [dbo].[Urunler] ([UrunID], [UrunAdi], [Fiyat]) VALUES (6, N'baskül              ', N'75,5      ')
INSERT [dbo].[Urunler] ([UrunID], [UrunAdi], [Fiyat]) VALUES (7, N'Bileklik            ', N'35,5      ')
INSERT [dbo].[Urunler] ([UrunID], [UrunAdi], [Fiyat]) VALUES (8, N'terlik              ', N'10        ')
SET IDENTITY_INSERT [dbo].[Urunler] OFF
SET IDENTITY_INSERT [dbo].[Uyeler] ON 

INSERT [dbo].[Uyeler] ([UyeID], [UyeNo], [UyeAdi], [UyeSoyadi], [UyeCinsiyet], [UyeDogumTarihi], [UyeKayitTarihi], [UyeTelefon], [UyeMail], [UyeBorcu]) VALUES (7, N'7         ', N'ayşe                ', N'nur                 ', N'Bayan               ', N'11.05.2018          ', N'11.05.2018          ', N'0(   )    -  -      ', N'', N'336,5     ')
INSERT [dbo].[Uyeler] ([UyeID], [UyeNo], [UyeAdi], [UyeSoyadi], [UyeCinsiyet], [UyeDogumTarihi], [UyeKayitTarihi], [UyeTelefon], [UyeMail], [UyeBorcu]) VALUES (8, N'8         ', N'ahmet               ', N'can                 ', N'Bay                 ', N'11.05.2018          ', N'11.05.2018          ', N'0(   )    -  -      ', N'', N'0         ')
SET IDENTITY_INSERT [dbo].[Uyeler] OFF
INSERT [dbo].[Yetkililer] ([YetkiliTcNo], [YetkiliAdi], [YetkiliSoyadi], [YetkiliTelefon], [YetkiliMail], [YetkiliKullaniciAdi], [YetkiliSifre], [YetkiliTuru]) VALUES (N'321        ', N'AYŞE                ', N'nur                 ', N'(405)    -  -  ', N'ayse                          ', N'aysenur             ', N'321                 ', N'Hoca      ')
INSERT [dbo].[Yetkililer] ([YetkiliTcNo], [YetkiliAdi], [YetkiliSoyadi], [YetkiliTelefon], [YetkiliMail], [YetkiliKullaniciAdi], [YetkiliSifre], [YetkiliTuru]) VALUES (N'403        ', N'dilara              ', N'yıldız              ', N'(555)    -  -  ', N'sdfsd                         ', N'dilara              ', N'111                 ', N'Sekreter  ')
INSERT [dbo].[Yetkililer] ([YetkiliTcNo], [YetkiliAdi], [YetkiliSoyadi], [YetkiliTelefon], [YetkiliMail], [YetkiliKullaniciAdi], [YetkiliSifre], [YetkiliTuru]) VALUES (N'606        ', N'ahmet               ', N'bey                 ', N'(405)    -  -  ', N'ahmet                         ', N'admin               ', N'123                 ', N'Admin     ')
ALTER TABLE [dbo].[Odemeler]  WITH CHECK ADD  CONSTRAINT [FK_Odemeler_Uyeler] FOREIGN KEY([Uye_id])
REFERENCES [dbo].[Uyeler] ([UyeID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Odemeler] CHECK CONSTRAINT [FK_Odemeler_Uyeler]
GO
ALTER TABLE [dbo].[Satislar]  WITH CHECK ADD  CONSTRAINT [FK_Satislar_Uyeler] FOREIGN KEY([Uye_id])
REFERENCES [dbo].[Uyeler] ([UyeID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Satislar] CHECK CONSTRAINT [FK_Satislar_Uyeler]
GO
ALTER TABLE [dbo].[SporGunlugu]  WITH CHECK ADD  CONSTRAINT [FK_SporGunlugu_Uyeler] FOREIGN KEY([Uye_id])
REFERENCES [dbo].[Uyeler] ([UyeID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SporGunlugu] CHECK CONSTRAINT [FK_SporGunlugu_Uyeler]
GO
USE [master]
GO
ALTER DATABASE [SporSalonuDataBase] SET  READ_WRITE 
GO
