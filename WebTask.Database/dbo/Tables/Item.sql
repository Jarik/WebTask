CREATE TABLE [dbo].[Item] (
    [Id]        INT              IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (MAX)   NULL,
    [CreatedBy] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED ([Id] ASC)
);

