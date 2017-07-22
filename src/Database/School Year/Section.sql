CREATE TABLE [dbo].[Section] (
    [Id]				INT IDENTITY (1, 1) NOT NULL,
    [CourseOfferedId]	INT NOT NULL,
    [SectionName]		NVARCHAR(20) NULL, 

	[Created]  DATETIME    DEFAULT getdate() NOT NULL,
    [Modified] DATETIME NOT NULL DEFAULT getdate(), 
	[CreatedBy] NVARCHAR(20) NOT NULL , 
	[ModifiedBy] NVARCHAR(20) not null, 

    CONSTRAINT [PK_Sections] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Sections_CourseOffered] FOREIGN KEY ([CourseOfferedId]) REFERENCES [dbo].OfferedCourse ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);

GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Sections]
    ON [dbo].[Section] ([CourseOfferedId] ASC, [SectionName] ASC);

