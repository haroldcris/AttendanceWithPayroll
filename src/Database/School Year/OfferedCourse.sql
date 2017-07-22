CREATE TABLE [dbo].OfferedCourse (
    [Id]			INT				IDENTITY (1, 1) NOT NULL,
	[BatchId]		INT				NOT NULL,
    [CourseCode]	NVARCHAR (20)	NOT NULL,
    [YearLevel]		TINYINT			NOT NULL,

	[Created]  DATETIME    DEFAULT getdate() NOT NULL,
    [Modified] DATETIME NOT NULL DEFAULT getdate(), 
	[CreatedBy] NVARCHAR(20) NOT NULL , 
	[ModifiedBy] NVARCHAR(20) not null, 

    CONSTRAINT [PK_CoursesOffered] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CoursesOffered_Courses] FOREIGN KEY ([CourseCode]) REFERENCES [dbo].[Course] ([CourseCode]) ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT [FK_CoursesOffered_Batch] FOREIGN KEY ([BatchId]) REFERENCES [dbo].[Batch] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);

GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CoursesOffered]
    ON [dbo].OfferedCourse([BatchId] ASC, [CourseCode] ASC, [YearLevel] ASC);

