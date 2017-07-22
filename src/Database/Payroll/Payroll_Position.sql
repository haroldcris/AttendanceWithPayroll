CREATE TABLE [dbo].[Payroll_Position]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Code]			nvarchar(20),
	[Description]	nvarchar(50),

	[Created]			   [datetime]		NOT NULL DEFAULT getdate(),
    [Modified]		   [datetime]		NOT NULL DEFAULT getdate(),
    [CreatedBy]		   [nvarchar](20)	NOT NULL ,
    [ModifiedBy]		   [nvarchar](20)	NOT NULL DEFAULT '', 
)

GO

CREATE UNIQUE INDEX [IX_Payroll_Position_Code] ON [dbo].[Payroll_Position] ([Code])
