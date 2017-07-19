CREATE TABLE [dbo].[Batch] (
    [Id]			INT IDENTITY (1, 1) NOT NULL,
    [BatchName]		NVARCHAR (10) NOT NULL,
    [Semester]		NVARCHAR (20) NOT NULL,
    
	[Created]		DATETIME    DEFAULT getdate() NOT NULL,
    [CreatedBy]		NVARCHAR(20) NOT NULL , 
    [Modified]		DATETIME NOT NULL DEFAULT getdate(), 
    [ModifiedBy]	NVARCHAR(20) NOT NULL , 
    
	CONSTRAINT [PK_Batch] PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Batch]
    ON [dbo].[Batch]([BatchName] ASC, [Semester] ASC);

