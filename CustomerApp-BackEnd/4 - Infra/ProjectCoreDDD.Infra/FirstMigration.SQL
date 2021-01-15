IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [dbo].[Classification] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Classification] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [dbo].[Gender] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Gender] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [dbo].[Region] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Region] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [dbo].[UserRole] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [IsAdmin] bit NOT NULL,
    CONSTRAINT [PK_UserRole] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [dbo].[City] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [RegionId] int NOT NULL,
    CONSTRAINT [PK_City] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_City_Region_RegionId] FOREIGN KEY ([RegionId]) REFERENCES [dbo].[Region] ([Id]) ON UPDATE CASCADE ON DELETE CASCADE
);

GO

CREATE TABLE [dbo].[UserSys] (
    [Id] int NOT NULL IDENTITY,
    [Login] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    [UserRoleId] int NOT NULL,
    CONSTRAINT [PK_UserSys] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_UserSys_UserRole_UserRoleId] FOREIGN KEY ([UserRoleId]) REFERENCES [dbo].[UserRole] ([Id]) ON UPDATE CASCADE ON DELETE CASCADE
);

GO

CREATE TABLE [dbo].[Customer] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Phone] nvarchar(max) NOT NULL,
    [LastPurchase] datetime2 NOT NULL,
    [GenderId] int NOT NULL,
    [CityId] int NOT NULL,
    [RegionId] int NOT NULL,
    [UserId] int NOT NULL,
    [ClassificationId] int NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Customer_City_CityId] FOREIGN KEY ([CityId]) REFERENCES [dbo].[City] ([Id]),
    CONSTRAINT [FK_Customer_Classification_ClassificationId] FOREIGN KEY ([ClassificationId]) REFERENCES [dbo].[Classification] ([Id]),
    CONSTRAINT [FK_Customer_Gender_GenderId] FOREIGN KEY ([GenderId]) REFERENCES [dbo].[Gender] ([Id]),
    CONSTRAINT [FK_Customer_Region_RegionId] FOREIGN KEY ([RegionId]) REFERENCES [dbo].[Region] ([Id]),
    CONSTRAINT [FK_Customer_UserSys_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[UserSys] ([Id])
);

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[dbo].[Classification]'))
    SET IDENTITY_INSERT [dbo].[Classification] ON;
INSERT INTO [dbo].[Classification] ([Id], [Name])
VALUES (1, N'VIP'),
(2, N'Regular'),
(3, N'Sporadic');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[dbo].[Classification]'))
    SET IDENTITY_INSERT [dbo].[Classification] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[dbo].[Gender]'))
    SET IDENTITY_INSERT [dbo].[Gender] ON;
INSERT INTO [dbo].[Gender] ([Id], [Name])
VALUES (1, N'Masculine'),
(2, N'Feminine');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[dbo].[Gender]'))
    SET IDENTITY_INSERT [dbo].[Gender] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[dbo].[Region]'))
    SET IDENTITY_INSERT [dbo].[Region] ON;
INSERT INTO [dbo].[Region] ([Id], [Name])
VALUES (1, N'Rio Grande do Sul'),
(2, N'São Paulo'),
(3, N'Curitiba');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[dbo].[Region]'))
    SET IDENTITY_INSERT [dbo].[Region] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'IsAdmin', N'Name') AND [object_id] = OBJECT_ID(N'[dbo].[UserRole]'))
    SET IDENTITY_INSERT [dbo].[UserRole] ON;
INSERT INTO [dbo].[UserRole] ([Id], [IsAdmin], [Name])
VALUES (1, CAST(1 AS bit), N'Administrator'),
(2, CAST(0 AS bit), N'Seller ');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'IsAdmin', N'Name') AND [object_id] = OBJECT_ID(N'[dbo].[UserRole]'))
    SET IDENTITY_INSERT [dbo].[UserRole] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'RegionId') AND [object_id] = OBJECT_ID(N'[dbo].[City]'))
    SET IDENTITY_INSERT [dbo].[City] ON;
INSERT INTO [dbo].[City] ([Id], [Name], [RegionId])
VALUES (1, N'Porto Alegre', 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'RegionId') AND [object_id] = OBJECT_ID(N'[dbo].[City]'))
    SET IDENTITY_INSERT [dbo].[City] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Email', N'Login', N'Password', N'UserRoleId') AND [object_id] = OBJECT_ID(N'[dbo].[UserSys]'))
    SET IDENTITY_INSERT [dbo].[UserSys] ON;
INSERT INTO [dbo].[UserSys] ([Id], [Email], [Login], [Password], [UserRoleId])
VALUES (1, N'admin@sellseverything.com', N'Administrator', N'0192023a7bbd73250516f069df18b500', 1),
(2, N'seller1@sellseverything.com', N'Seller1', N'1e4970ada8c054474cda889490de3421', 2),
(3, N'seller2@sellseverything.com', N'Seller2', N'c6e36755ccaf770bdfe44928358055c2', 2);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Email', N'Login', N'Password', N'UserRoleId') AND [object_id] = OBJECT_ID(N'[dbo].[UserSys]'))
    SET IDENTITY_INSERT [dbo].[UserSys] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CityId', N'ClassificationId', N'GenderId', N'LastPurchase', N'Name', N'Phone', N'RegionId', N'UserId') AND [object_id] = OBJECT_ID(N'[dbo].[Customer]'))
    SET IDENTITY_INSERT [dbo].[Customer] ON;
INSERT INTO [dbo].[Customer] ([Id], [CityId], [ClassificationId], [GenderId], [LastPurchase], [Name], [Phone], [RegionId], [UserId])
VALUES (2, 1, 1, 2, '2015-10-10T00:00:00.0000000', N'Carla', N'(53) 94569999', 1, 2),
(3, 1, 3, 2, '2013-10-12T00:00:00.0000000', N'Maria', N'(64) 94518888', 1, 2),
(4, 1, 2, 1, '2016-05-05T00:00:00.0000000', N'Douglas', N'(51) 12455555', 1, 2),
(1, 1, 1, 1, '2016-09-10T00:00:00.0000000', N'Maurício', N'(11) 95429999', 1, 3),
(5, 1, 2, 2, '2016-08-08T00:00:00.0000000', N'Marta', N'(51) 45788888', 1, 3);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CityId', N'ClassificationId', N'GenderId', N'LastPurchase', N'Name', N'Phone', N'RegionId', N'UserId') AND [object_id] = OBJECT_ID(N'[dbo].[Customer]'))
    SET IDENTITY_INSERT [dbo].[Customer] OFF;

GO

CREATE INDEX [IX_City_RegionId] ON [dbo].[City] ([RegionId]);

GO

CREATE INDEX [IX_Customer_CityId] ON [dbo].[Customer] ([CityId]);

GO

CREATE INDEX [IX_Customer_ClassificationId] ON [dbo].[Customer] ([ClassificationId]);

GO

CREATE INDEX [IX_Customer_GenderId] ON [dbo].[Customer] ([GenderId]);

GO

CREATE INDEX [IX_Customer_RegionId] ON [dbo].[Customer] ([RegionId]);

GO

CREATE INDEX [IX_Customer_UserId] ON [dbo].[Customer] ([UserId]);

GO

CREATE INDEX [IX_UserSys_UserRoleId] ON [dbo].[UserSys] ([UserRoleId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201220173741_FirstMigration', N'3.1.10');

GO

