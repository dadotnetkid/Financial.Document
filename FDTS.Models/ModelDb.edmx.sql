
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/08/2019 16:51:02
-- Generated from EDMX file: D:\Software Development\Repositories\DocumentTracker\HRIS.Models\ModelDb.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DocumentTracker];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_dbo_AddressTownCities_dbo_AddressStateProvinces_StateProvinceId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AddressTownCities] DROP CONSTRAINT [FK_dbo_AddressTownCities_dbo_AddressStateProvinces_StateProvinceId];
GO
IF OBJECT_ID(N'[dbo].[FK_UserClaims_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserClaims] DROP CONSTRAINT [FK_UserClaims_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_UserLogins_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserLogins] DROP CONSTRAINT [FK_UserLogins_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersInRoles_UserRoles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersInRoles] DROP CONSTRAINT [FK_UsersInRoles_UserRoles];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersInRoles_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersInRoles] DROP CONSTRAINT [FK_UsersInRoles_Users];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AddressStateProvinces]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AddressStateProvinces];
GO
IF OBJECT_ID(N'[dbo].[AddressTownCities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AddressTownCities];
GO
IF OBJECT_ID(N'[dbo].[UserClaims]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserClaims];
GO
IF OBJECT_ID(N'[dbo].[UserLogins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserLogins];
GO
IF OBJECT_ID(N'[dbo].[UserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserRoles];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[UsersInRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsersInRoles];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AddressStateProvinces'
CREATE TABLE [dbo].[AddressStateProvinces] (
    [StateProvinceId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(250)  NOT NULL,
    [SortOrder] int  NOT NULL
);
GO

-- Creating table 'AddressTownCities'
CREATE TABLE [dbo].[AddressTownCities] (
    [TownCityId] int  NOT NULL,
    [Name] nvarchar(250)  NOT NULL,
    [StateProvinceId] int  NOT NULL,
    [SortOrder] int  NOT NULL
);
GO

-- Creating table 'UserClaims'
CREATE TABLE [dbo].[UserClaims] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] nvarchar(128)  NOT NULL,
    [ClaimType] nvarchar(max)  NULL,
    [ClaimValue] nvarchar(max)  NULL
);
GO

-- Creating table 'UserLogins'
CREATE TABLE [dbo].[UserLogins] (
    [LoginProvider] nvarchar(128)  NOT NULL,
    [ProviderKey] nvarchar(128)  NOT NULL,
    [UserId] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'UserRoles'
CREATE TABLE [dbo].[UserRoles] (
    [Id] nvarchar(128)  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Description] nvarchar(max)  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] nvarchar(128)  NOT NULL,
    [BiometricId] int  NULL,
    [Email] nvarchar(128)  NULL,
    [EmailConfirmed] bit  NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [PhoneNumber] nvarchar(25)  NULL,
    [PhoneNumberConfirmed] bit  NULL,
    [TwoFactorEnabled] bit  NULL,
    [LockoutEndDateUtc] datetime  NULL,
    [LockoutEnabled] bit  NULL,
    [AccessFailedCount] int  NULL,
    [UserName] nvarchar(50)  NULL,
    [LastUpdatedBy] nvarchar(150)  NULL,
    [LastUpdated] datetime  NULL,
    [CreatedDate] datetime  NULL,
    [FirstName] nvarchar(50)  NULL,
    [LastName] nvarchar(50)  NULL,
    [MiddleName] nvarchar(50)  NULL,
    [CivilStatus] nvarchar(12)  NULL,
    [Gender] nvarchar(6)  NULL,
    [BirthDate] datetime  NULL,
    [AddressLine2] nvarchar(500)  NULL,
    [AddressLine1] nvarchar(500)  NULL,
    [TownCityId] int  NULL,
    [Cellular] nvarchar(25)  NULL,
    [Height] decimal(5,2)  NULL,
    [Weight] decimal(5,2)  NULL,
    [Religion] nvarchar(50)  NULL,
    [Citizenship] nvarchar(50)  NULL,
    [Languages] nvarchar(max)  NULL,
    [Photo] varbinary(max)  NULL
);
GO

-- Creating table 'UsersInRoles'
CREATE TABLE [dbo].[UsersInRoles] (
    [UserRoles_Id] nvarchar(128)  NOT NULL,
    [Users_Id] nvarchar(128)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [StateProvinceId] in table 'AddressStateProvinces'
ALTER TABLE [dbo].[AddressStateProvinces]
ADD CONSTRAINT [PK_AddressStateProvinces]
    PRIMARY KEY CLUSTERED ([StateProvinceId] ASC);
GO

-- Creating primary key on [TownCityId] in table 'AddressTownCities'
ALTER TABLE [dbo].[AddressTownCities]
ADD CONSTRAINT [PK_AddressTownCities]
    PRIMARY KEY CLUSTERED ([TownCityId] ASC);
GO

-- Creating primary key on [Id] in table 'UserClaims'
ALTER TABLE [dbo].[UserClaims]
ADD CONSTRAINT [PK_UserClaims]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [LoginProvider], [ProviderKey], [UserId] in table 'UserLogins'
ALTER TABLE [dbo].[UserLogins]
ADD CONSTRAINT [PK_UserLogins]
    PRIMARY KEY CLUSTERED ([LoginProvider], [ProviderKey], [UserId] ASC);
GO

-- Creating primary key on [Id] in table 'UserRoles'
ALTER TABLE [dbo].[UserRoles]
ADD CONSTRAINT [PK_UserRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [UserRoles_Id], [Users_Id] in table 'UsersInRoles'
ALTER TABLE [dbo].[UsersInRoles]
ADD CONSTRAINT [PK_UsersInRoles]
    PRIMARY KEY CLUSTERED ([UserRoles_Id], [Users_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [StateProvinceId] in table 'AddressTownCities'
ALTER TABLE [dbo].[AddressTownCities]
ADD CONSTRAINT [FK_dbo_AddressTownCities_dbo_AddressStateProvinces_StateProvinceId]
    FOREIGN KEY ([StateProvinceId])
    REFERENCES [dbo].[AddressStateProvinces]
        ([StateProvinceId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AddressTownCities_dbo_AddressStateProvinces_StateProvinceId'
CREATE INDEX [IX_FK_dbo_AddressTownCities_dbo_AddressStateProvinces_StateProvinceId]
ON [dbo].[AddressTownCities]
    ([StateProvinceId]);
GO

-- Creating foreign key on [UserId] in table 'UserClaims'
ALTER TABLE [dbo].[UserClaims]
ADD CONSTRAINT [FK_UserClaims_Users]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserClaims_Users'
CREATE INDEX [IX_FK_UserClaims_Users]
ON [dbo].[UserClaims]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'UserLogins'
ALTER TABLE [dbo].[UserLogins]
ADD CONSTRAINT [FK_UserLogins_Users]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserLogins_Users'
CREATE INDEX [IX_FK_UserLogins_Users]
ON [dbo].[UserLogins]
    ([UserId]);
GO

-- Creating foreign key on [UserRoles_Id] in table 'UsersInRoles'
ALTER TABLE [dbo].[UsersInRoles]
ADD CONSTRAINT [FK_UsersInRoles_UserRoles]
    FOREIGN KEY ([UserRoles_Id])
    REFERENCES [dbo].[UserRoles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Users_Id] in table 'UsersInRoles'
ALTER TABLE [dbo].[UsersInRoles]
ADD CONSTRAINT [FK_UsersInRoles_Users]
    FOREIGN KEY ([Users_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersInRoles_Users'
CREATE INDEX [IX_FK_UsersInRoles_Users]
ON [dbo].[UsersInRoles]
    ([Users_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------