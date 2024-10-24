USE GamesAsArt;
GO

DROP INDEX IF EXISTS [IX_GameTag_TagId] ON [GameTag]
GO

DROP INDEX IF EXISTS [IX_Image_GameId] ON [Image]
GO

DROP INDEX IF EXISTS [IX_Video_GameId] ON [Video]
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Game]') AND type in (N'U'))
    CREATE TABLE [Game] (
        [Id] INT PRIMARY KEY IDENTITY (1, 1),
        [Name] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [Release] datetime2 NOT NULL,
        [AverageScore] int NOT NULL
    );
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Image]') AND type in (N'U'))
    CREATE TABLE [Image] (
        [Id] INT PRIMARY KEY IDENTITY (1, 1),
        [Url] nvarchar(max) NOT NULL,
        [GameId] int NOT NULL,
        FOREIGN KEY ([GameId]) REFERENCES [Game] ([Id]) ON DELETE CASCADE
    );
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Video]') AND type in (N'U'))
    CREATE TABLE [Video] (
        [Id] INT PRIMARY KEY IDENTITY (1, 1),
        [Url] nvarchar(max) NOT NULL,
        [GameId] int NOT NULL,
        FOREIGN KEY ([GameId]) REFERENCES [Game] ([Id]) ON DELETE CASCADE
    );
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tag]') AND type in (N'U'))
    CREATE TABLE [Tag] (
        [Id] INT PRIMARY KEY IDENTITY (1, 1),
        [Name] nvarchar(max) NOT NULL
    );
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GameTag]') AND type in (N'U'))
    CREATE TABLE [GameTag] (
        [GameId] int NOT NULL,
        [TagId] int NOT NULL,
        PRIMARY KEY ([GameId], [TagId]),
        FOREIGN KEY ([GameId]) REFERENCES [Game] ([Id]) ON DELETE CASCADE,
        FOREIGN KEY ([TagId]) REFERENCES [Tag] ([Id]) ON DELETE CASCADE
    );
GO

CREATE INDEX [IX_GameTag_TagId] ON [GameTag] ([TagId]);
CREATE INDEX [IX_Image_GameId] ON [Image] ([GameId]);
CREATE INDEX [IX_Video_GameId] ON [Video] ([GameId]);