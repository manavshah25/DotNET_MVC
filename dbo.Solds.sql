CREATE TABLE [dbo].[Solds] (
    [Id]    INT            IDENTITY (1, 1) NOT NULL,
    [SName] NVARCHAR (MAX) NULL,
    [SQunt] NVARCHAR (MAX) NULL,
    [SDate] DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_Solds] PRIMARY KEY CLUSTERED ([Id] ASC)
);

