
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/11/2018 19:27:26
-- Generated from EDMX file: C:\Users\Natella Ersther\Desktop\CarRental_BackEnd\DAL\CarRental.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CarRental];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Branches'
CREATE TABLE [dbo].[Branches] (
    [BranchID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [Latitude] decimal(10,8)  NOT NULL,
    [Longtitude] decimal(11,8)  NOT NULL
);
GO

-- Creating table 'Cars'
CREATE TABLE [dbo].[Cars] (
    [CarID] int IDENTITY(1,1) NOT NULL,
    [KM] int  NOT NULL,
    [CarPic] nvarchar(max)  NULL,
    [IsFix] bit  NOT NULL,
    [IsAvailable] bit  NOT NULL,
    [CarNum] nvarchar(max)  NOT NULL,
    [CarTypeID] int  NOT NULL,
    [BranchID] int  NOT NULL
);
GO

-- Creating table 'CarTypes'
CREATE TABLE [dbo].[CarTypes] (
    [CarTypeID] int IDENTITY(1,1) NOT NULL,
    [Brand] nvarchar(max)  NOT NULL,
    [Model] nvarchar(max)  NOT NULL,
    [PricePerDay] decimal(19,4)  NOT NULL,
    [PriceExtraPerDay] decimal(19,4)  NOT NULL,
    [Year] int  NOT NULL,
    [IsManual] bit  NOT NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [OrderID] int IDENTITY(1,1) NOT NULL,
    [StartDate] datetime  NOT NULL,
    [FinishDate] datetime  NOT NULL,
    [Returned] datetime  NULL,
    [UserID] int  NOT NULL,
    [CarID] int  NOT NULL
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

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserID] int IDENTITY(1,1) NOT NULL,
    [FullName] nvarchar(max)  NOT NULL,
    [TeudatZeut] int  NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [Birthday] datetime  NOT NULL,
    [Gender] char(1)  NOT NULL,
    [Email] nvarchar(50)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [UserTypeID] int  NOT NULL,
    [IsValidUSer] bit  NOT NULL,
    [PicPath] nvarchar(max)  NULL,
    [Phone] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UserTypes'
CREATE TABLE [dbo].[UserTypes] (
    [UserTypeID] int IDENTITY(1,1) NOT NULL,
    [TypeOfUser] nvarchar(50)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [BranchID] in table 'Branches'
ALTER TABLE [dbo].[Branches]
ADD CONSTRAINT [PK_Branches]
    PRIMARY KEY CLUSTERED ([BranchID] ASC);
GO

-- Creating primary key on [CarID] in table 'Cars'
ALTER TABLE [dbo].[Cars]
ADD CONSTRAINT [PK_Cars]
    PRIMARY KEY CLUSTERED ([CarID] ASC);
GO

-- Creating primary key on [CarTypeID] in table 'CarTypes'
ALTER TABLE [dbo].[CarTypes]
ADD CONSTRAINT [PK_CarTypes]
    PRIMARY KEY CLUSTERED ([CarTypeID] ASC);
GO

-- Creating primary key on [OrderID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([OrderID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [UserID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- Creating primary key on [UserTypeID] in table 'UserTypes'
ALTER TABLE [dbo].[UserTypes]
ADD CONSTRAINT [PK_UserTypes]
    PRIMARY KEY CLUSTERED ([UserTypeID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [BranchID] in table 'Cars'
ALTER TABLE [dbo].[Cars]
ADD CONSTRAINT [FK_Car_Branch]
    FOREIGN KEY ([BranchID])
    REFERENCES [dbo].[Branches]
        ([BranchID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Car_Branch'
CREATE INDEX [IX_FK_Car_Branch]
ON [dbo].[Cars]
    ([BranchID]);
GO

-- Creating foreign key on [CarTypeID] in table 'Cars'
ALTER TABLE [dbo].[Cars]
ADD CONSTRAINT [FK_Car_CarType]
    FOREIGN KEY ([CarTypeID])
    REFERENCES [dbo].[CarTypes]
        ([CarTypeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Car_CarType'
CREATE INDEX [IX_FK_Car_CarType]
ON [dbo].[Cars]
    ([CarTypeID]);
GO

-- Creating foreign key on [CarID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_Order_Car]
    FOREIGN KEY ([CarID])
    REFERENCES [dbo].[Cars]
        ([CarID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Order_Car'
CREATE INDEX [IX_FK_Order_Car]
ON [dbo].[Orders]
    ([CarID]);
GO

-- Creating foreign key on [UserID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_Order_User]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Order_User'
CREATE INDEX [IX_FK_Order_User]
ON [dbo].[Orders]
    ([UserID]);
GO

-- Creating foreign key on [UserTypeID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_User_UserType]
    FOREIGN KEY ([UserTypeID])
    REFERENCES [dbo].[UserTypes]
        ([UserTypeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_User_UserType'
CREATE INDEX [IX_FK_User_UserType]
ON [dbo].[Users]
    ([UserTypeID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------