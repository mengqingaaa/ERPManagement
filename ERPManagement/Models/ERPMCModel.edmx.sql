
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/12/2014 15:01:03
-- Generated from EDMX file: D:\Document_x64\Documents\Visual Studio 2013\Projects\ERPManagement\ERPManagement\Models\ERPMCModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ERPManagement];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CustomerCustomizedRDLC]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomizedRDLCSet] DROP CONSTRAINT [FK_CustomerCustomizedRDLC];
GO
IF OBJECT_ID(N'[dbo].[FK_ModifiedRDLCCustomizedRDLC_ModifiedRDLC]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ModifiedRDLCCustomizedRDLC] DROP CONSTRAINT [FK_ModifiedRDLCCustomizedRDLC_ModifiedRDLC];
GO
IF OBJECT_ID(N'[dbo].[FK_ModifiedRDLCCustomizedRDLC_CustomizedRDLC]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ModifiedRDLCCustomizedRDLC] DROP CONSTRAINT [FK_ModifiedRDLCCustomizedRDLC_CustomizedRDLC];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CustomerSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CustomerSet];
GO
IF OBJECT_ID(N'[dbo].[CustomizedRDLCSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CustomizedRDLCSet];
GO
IF OBJECT_ID(N'[dbo].[FuncMenuSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FuncMenuSet];
GO
IF OBJECT_ID(N'[dbo].[AdminMenuSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdminMenuSet];
GO
IF OBJECT_ID(N'[dbo].[ModifiedRDLCSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ModifiedRDLCSet];
GO
IF OBJECT_ID(N'[dbo].[SqlExecutionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SqlExecutionSet];
GO
IF OBJECT_ID(N'[dbo].[LogSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LogSet];
GO
IF OBJECT_ID(N'[dbo].[ModifiedRDLCCustomizedRDLC]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ModifiedRDLCCustomizedRDLC];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CustomerSet'
CREATE TABLE [dbo].[CustomerSet] (
    [CustomoerId] int IDENTITY(1,1) NOT NULL,
    [Code] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Version] nvarchar(max)  NOT NULL,
    [SIerManaged] int  NOT NULL,
    [DBServerName] nvarchar(max)  NOT NULL,
    [DBLoginName] nvarchar(max)  NOT NULL,
    [DBLoginPassword] nvarchar(max)  NOT NULL,
    [DBBizName] nvarchar(max)  NOT NULL,
    [DBSysname] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CustomizedRDLCSet'
CREATE TABLE [dbo].[CustomizedRDLCSet] (
    [CustomizedRDLCId] int IDENTITY(1,1) NOT NULL,
    [PrintId] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Version] nvarchar(max)  NOT NULL,
    [CustomoerId] int  NOT NULL
);
GO

-- Creating table 'FuncMenuSet'
CREATE TABLE [dbo].[FuncMenuSet] (
    [FuncMenuId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [UrlSection] nvarchar(max)  NOT NULL,
    [ParentId] int  NOT NULL,
    [Order] int  NOT NULL
);
GO

-- Creating table 'AdminMenuSet'
CREATE TABLE [dbo].[AdminMenuSet] (
    [AdminMenuId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [ParentId] int  NOT NULL,
    [Order] int  NOT NULL
);
GO

-- Creating table 'ModifiedRDLCSet'
CREATE TABLE [dbo].[ModifiedRDLCSet] (
    [ModifiedRDLCId] int IDENTITY(1,1) NOT NULL,
    [PrintId] nvarchar(max)  NOT NULL,
    [Version] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SqlExecutionSet'
CREATE TABLE [dbo].[SqlExecutionSet] (
    [SqlExecutionId] int IDENTITY(1,1) NOT NULL,
    [CustomerId] int  NOT NULL,
    [DBType] int  NOT NULL,
    [CreatedTime] datetime  NOT NULL,
    [ExecutedTime] datetime  NULL,
    [UploadFileName] nvarchar(max)  NOT NULL,
    [SavedFileName] nvarchar(max)  NOT NULL,
    [ScriptFilePath] nvarchar(max)  NOT NULL,
    [BackupFileName] nvarchar(max)  NULL,
    [BackupFilePath] nvarchar(max)  NULL,
    [LogId] nvarchar(max)  NULL,
    [LogFileName] nvarchar(max)  NULL,
    [LogFilePath] nvarchar(max)  NULL
);
GO

-- Creating table 'LogSet'
CREATE TABLE [dbo].[LogSet] (
    [LogId] int IDENTITY(1,1) NOT NULL,
    [Type] int  NOT NULL,
    [RelatedId] nvarchar(max)  NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [CreatedTime] datetime  NULL
);
GO

-- Creating table 'ModifiedRDLCCustomizedRDLC'
CREATE TABLE [dbo].[ModifiedRDLCCustomizedRDLC] (
    [ModifiedRDLC_ModifiedRDLCId] int  NOT NULL,
    [CustomizedRDLC_CustomizedRDLCId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CustomoerId] in table 'CustomerSet'
ALTER TABLE [dbo].[CustomerSet]
ADD CONSTRAINT [PK_CustomerSet]
    PRIMARY KEY CLUSTERED ([CustomoerId] ASC);
GO

-- Creating primary key on [CustomizedRDLCId] in table 'CustomizedRDLCSet'
ALTER TABLE [dbo].[CustomizedRDLCSet]
ADD CONSTRAINT [PK_CustomizedRDLCSet]
    PRIMARY KEY CLUSTERED ([CustomizedRDLCId] ASC);
GO

-- Creating primary key on [FuncMenuId] in table 'FuncMenuSet'
ALTER TABLE [dbo].[FuncMenuSet]
ADD CONSTRAINT [PK_FuncMenuSet]
    PRIMARY KEY CLUSTERED ([FuncMenuId] ASC);
GO

-- Creating primary key on [AdminMenuId] in table 'AdminMenuSet'
ALTER TABLE [dbo].[AdminMenuSet]
ADD CONSTRAINT [PK_AdminMenuSet]
    PRIMARY KEY CLUSTERED ([AdminMenuId] ASC);
GO

-- Creating primary key on [ModifiedRDLCId] in table 'ModifiedRDLCSet'
ALTER TABLE [dbo].[ModifiedRDLCSet]
ADD CONSTRAINT [PK_ModifiedRDLCSet]
    PRIMARY KEY CLUSTERED ([ModifiedRDLCId] ASC);
GO

-- Creating primary key on [SqlExecutionId] in table 'SqlExecutionSet'
ALTER TABLE [dbo].[SqlExecutionSet]
ADD CONSTRAINT [PK_SqlExecutionSet]
    PRIMARY KEY CLUSTERED ([SqlExecutionId] ASC);
GO

-- Creating primary key on [LogId] in table 'LogSet'
ALTER TABLE [dbo].[LogSet]
ADD CONSTRAINT [PK_LogSet]
    PRIMARY KEY CLUSTERED ([LogId] ASC);
GO

-- Creating primary key on [ModifiedRDLC_ModifiedRDLCId], [CustomizedRDLC_CustomizedRDLCId] in table 'ModifiedRDLCCustomizedRDLC'
ALTER TABLE [dbo].[ModifiedRDLCCustomizedRDLC]
ADD CONSTRAINT [PK_ModifiedRDLCCustomizedRDLC]
    PRIMARY KEY CLUSTERED ([ModifiedRDLC_ModifiedRDLCId], [CustomizedRDLC_CustomizedRDLCId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CustomoerId] in table 'CustomizedRDLCSet'
ALTER TABLE [dbo].[CustomizedRDLCSet]
ADD CONSTRAINT [FK_CustomerCustomizedRDLC]
    FOREIGN KEY ([CustomoerId])
    REFERENCES [dbo].[CustomerSet]
        ([CustomoerId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerCustomizedRDLC'
CREATE INDEX [IX_FK_CustomerCustomizedRDLC]
ON [dbo].[CustomizedRDLCSet]
    ([CustomoerId]);
GO

-- Creating foreign key on [ModifiedRDLC_ModifiedRDLCId] in table 'ModifiedRDLCCustomizedRDLC'
ALTER TABLE [dbo].[ModifiedRDLCCustomizedRDLC]
ADD CONSTRAINT [FK_ModifiedRDLCCustomizedRDLC_ModifiedRDLC]
    FOREIGN KEY ([ModifiedRDLC_ModifiedRDLCId])
    REFERENCES [dbo].[ModifiedRDLCSet]
        ([ModifiedRDLCId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [CustomizedRDLC_CustomizedRDLCId] in table 'ModifiedRDLCCustomizedRDLC'
ALTER TABLE [dbo].[ModifiedRDLCCustomizedRDLC]
ADD CONSTRAINT [FK_ModifiedRDLCCustomizedRDLC_CustomizedRDLC]
    FOREIGN KEY ([CustomizedRDLC_CustomizedRDLCId])
    REFERENCES [dbo].[CustomizedRDLCSet]
        ([CustomizedRDLCId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ModifiedRDLCCustomizedRDLC_CustomizedRDLC'
CREATE INDEX [IX_FK_ModifiedRDLCCustomizedRDLC_CustomizedRDLC]
ON [dbo].[ModifiedRDLCCustomizedRDLC]
    ([CustomizedRDLC_CustomizedRDLCId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------