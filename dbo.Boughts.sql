CREATE TABLE [dbo].[Boughts] (
    [Id]    INT            IDENTITY (1, 1) NOT NULL,
    [BName] NVARCHAR (MAX) NULL,
    [BQunt] NVARCHAR (MAX) NULL,
    [BDate] DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_Boughts] PRIMARY KEY CLUSTERED ([Id] ASC)
);

