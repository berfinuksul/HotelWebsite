
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/08/2022 15:43:12
-- Generated from EDMX file: C:\Users\Lenovo\Desktop\Projeler\Web-MVC\HotelWebsite\HotelWebsite\Models\Hotel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Hotel];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_MusteriHesabi_MusteriKayit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MusteriHesabi] DROP CONSTRAINT [FK_MusteriHesabi_MusteriKayit];
GO
IF OBJECT_ID(N'[dbo].[FK_MusteriHesabi_Odalar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MusteriHesabi] DROP CONSTRAINT [FK_MusteriHesabi_Odalar];
GO
IF OBJECT_ID(N'[dbo].[FK_Odalar_Servisler]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Odalar] DROP CONSTRAINT [FK_Odalar_Servisler];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[MusteriHesabi]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MusteriHesabi];
GO
IF OBJECT_ID(N'[dbo].[MusteriKayit]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MusteriKayit];
GO
IF OBJECT_ID(N'[dbo].[Odalar]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Odalar];
GO
IF OBJECT_ID(N'[dbo].[Servisler]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Servisler];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'MusteriHesabis'
CREATE TABLE [dbo].[MusteriHesabis] (
    [islemNo] int IDENTITY(1,1) NOT NULL,
    [sonHesap] varchar(50)  NULL,
    [girisTarihi] varchar(50)  NULL,
    [cikisTarihi] varchar(50)  NULL,
    [kisiSayisi] int  NULL,
    [odaNo] int  NULL,
    [musteriNo] int  NULL
);
GO

-- Creating table 'MusteriKayits'
CREATE TABLE [dbo].[MusteriKayits] (
    [musteriNo] int IDENTITY(1,1) NOT NULL,
    [ad] varchar(50)  NULL,
    [soyad] varchar(50)  NULL,
    [cinsiyet] char(5)  NULL,
    [adres] varchar(50)  NULL,
    [telefon] char(20)  NULL
);
GO

-- Creating table 'Odalars'
CREATE TABLE [dbo].[Odalars] (
    [odaNo] int IDENTITY(1,1) NOT NULL,
    [odaFiyat] decimal(19,4)  NULL,
    [yatakSayisi] int  NULL,
    [odaTuru] varchar(50)  NULL,
    [servisNo] int  NULL
);
GO

-- Creating table 'Servislers'
CREATE TABLE [dbo].[Servislers] (
    [servisNo] int IDENTITY(1,1) NOT NULL,
    [ad] varchar(50)  NULL,
    [ucret] decimal(19,4)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [islemNo] in table 'MusteriHesabis'
ALTER TABLE [dbo].[MusteriHesabis]
ADD CONSTRAINT [PK_MusteriHesabis]
    PRIMARY KEY CLUSTERED ([islemNo] ASC);
GO

-- Creating primary key on [musteriNo] in table 'MusteriKayits'
ALTER TABLE [dbo].[MusteriKayits]
ADD CONSTRAINT [PK_MusteriKayits]
    PRIMARY KEY CLUSTERED ([musteriNo] ASC);
GO

-- Creating primary key on [odaNo] in table 'Odalars'
ALTER TABLE [dbo].[Odalars]
ADD CONSTRAINT [PK_Odalars]
    PRIMARY KEY CLUSTERED ([odaNo] ASC);
GO

-- Creating primary key on [servisNo] in table 'Servislers'
ALTER TABLE [dbo].[Servislers]
ADD CONSTRAINT [PK_Servislers]
    PRIMARY KEY CLUSTERED ([servisNo] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [musteriNo] in table 'MusteriHesabis'
ALTER TABLE [dbo].[MusteriHesabis]
ADD CONSTRAINT [FK_MusteriHesabi_MusteriKayit]
    FOREIGN KEY ([musteriNo])
    REFERENCES [dbo].[MusteriKayits]
        ([musteriNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MusteriHesabi_MusteriKayit'
CREATE INDEX [IX_FK_MusteriHesabi_MusteriKayit]
ON [dbo].[MusteriHesabis]
    ([musteriNo]);
GO

-- Creating foreign key on [odaNo] in table 'MusteriHesabis'
ALTER TABLE [dbo].[MusteriHesabis]
ADD CONSTRAINT [FK_MusteriHesabi_Odalar]
    FOREIGN KEY ([odaNo])
    REFERENCES [dbo].[Odalars]
        ([odaNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MusteriHesabi_Odalar'
CREATE INDEX [IX_FK_MusteriHesabi_Odalar]
ON [dbo].[MusteriHesabis]
    ([odaNo]);
GO

-- Creating foreign key on [servisNo] in table 'Odalars'
ALTER TABLE [dbo].[Odalars]
ADD CONSTRAINT [FK_Odalar_Servisler]
    FOREIGN KEY ([servisNo])
    REFERENCES [dbo].[Servislers]
        ([servisNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Odalar_Servisler'
CREATE INDEX [IX_FK_Odalar_Servisler]
ON [dbo].[Odalars]
    ([servisNo]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------