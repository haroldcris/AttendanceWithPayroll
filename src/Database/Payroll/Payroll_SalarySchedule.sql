CREATE TABLE [dbo].[Payroll_SalarySchedule]
(
	[Id]			INT NOT NULL PRIMARY KEY,
	Description		NVARCHAR(50),
	Effectivity		DATE NOT NULL DEFAULT ('19200101'),

	[Created]			   [datetime]		NOT NULL DEFAULT getdate(),
    [Modified]		   [datetime]		NOT NULL DEFAULT getdate(),
    [CreatedBy]		   [nvarchar](20)	NOT NULL ,
    [ModifiedBy]		   [nvarchar](20)	NOT NULL DEFAULT '', 
)

GO

CREATE UNIQUE INDEX [IX_Payroll_SalarySchedule_Effectivity] ON [dbo].[Payroll_SalarySchedule] (Effectivity)
