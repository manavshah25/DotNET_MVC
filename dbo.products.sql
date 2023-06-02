CREATE TABLE [dbo].[products] (
    [Id]    INT            IDENTITY (1, 1) NOT NULL,
    [PName] NVARCHAR (MAX) NULL,
    [PQunt] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_products] PRIMARY KEY CLUSTERED ([Id] ASC)
);

