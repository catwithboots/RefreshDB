CREATE TABLE [dbo].[Instances] (
    [id]               INT           NOT NULL,
    [name]             VARCHAR (255) NOT NULL,
    [servername]           VARCHAR (100) NOT NULL,
	[SQLUsername]	VARCHAR (255) NULL,
	[SQLPassword]	VARCHAR (255) NULL,
    [environment_id]   INT           NOT NULL,
    CONSTRAINT [PK_Instances_ID] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Instances_Environments_id] FOREIGN KEY ([environment_id]) REFERENCES [dbo].[Environments] ([id])
);
GO

CREATE NONCLUSTERED INDEX [IX_Instances_Environment_id] ON [dbo].[Instances]
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON);
GO
