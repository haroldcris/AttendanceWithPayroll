CREATE TABLE [dbo].Employee
(
    Id					INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    PersonId			INT NOT NULL,
    PositionId			INT NOT NULL,

    [Created]			   [datetime]		NOT NULL DEFAULT getdate(),
    [Modified]		   [datetime]		NOT NULL DEFAULT getdate(),
    [CreatedBy]		   [nvarchar](20)	NOT NULL ,
    [ModifiedBy]		   [nvarchar](20)	NOT NULL DEFAULT '', 

    CONSTRAINT [FK_Employee_Person] FOREIGN KEY ([PersonId]) REFERENCES [Person]([Id]),
	CONSTRAINT [FK_Employee_Position] FOREIGN KEY (PositionId) REFERENCEs [Payroll_Position] ([Id])
)

GO

