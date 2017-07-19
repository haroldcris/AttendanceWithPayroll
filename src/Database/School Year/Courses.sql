CREATE TABLE [dbo].[Courses] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [CourseCode]  NVARCHAR (20) NOT NULL,
    [Description] NVARCHAR (50) NOT NULL,
	

	[Created]  DATETIME    DEFAULT getdate() NOT NULL,
    [Modified] DATETIME NOT NULL DEFAULT getdate(), 
	[CreatedBy] NVARCHAR(20) NOT NULL , 
	[ModifiedBy] NVARCHAR(20) not null, 
    
	CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Courses]
    ON [dbo].[Courses]([CourseCode] ASC);

