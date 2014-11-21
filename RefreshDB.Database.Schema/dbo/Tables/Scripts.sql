CREATE TABLE [dbo].[Scripts] (
    [id]       INT           NOT NULL,
    [name]     VARCHAR (100) NOT NULL,
    [host]     VARCHAR (100) NOT NULL,
    [Location] VARCHAR (255) NOT NULL,
    CONSTRAINT [PK_Scripts_id] PRIMARY KEY CLUSTERED ([id] ASC)
);

