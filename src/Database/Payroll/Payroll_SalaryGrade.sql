CREATE TABLE [dbo].[Payroll_SalaryGrade]
(
	[Id]				INT NOT NULL PRIMARY KEY,
	SalaryScheduleId	int ,
	SG					int ,
	Step1				Decimal (9,3) NOT NULL DEFAULT (0),
	Step2				Decimal (9,3) NOT NULL DEFAULT (0),
	Step3				Decimal (9,3) NOT NULL DEFAULT (0),
	Step4				Decimal (9,3) NOT NULL DEFAULT (0),
	Step5				Decimal (9,3) NOT NULL DEFAULT (0),
	Step6				Decimal (9,3) NOT NULL DEFAULT (0),
	Step7				Decimal (9,3) NOT NULL DEFAULT (0),
	Step8				Decimal (9,3) NOT NULL DEFAULT (0),

	[Created]			[datetime]		NOT NULL DEFAULT getdate(),
    [Modified]			[datetime]		NOT NULL DEFAULT getdate(),
    [CreatedBy]			[nvarchar](20)	NOT NULL ,
    [ModifiedBy]		[nvarchar](20)	NOT NULL DEFAULT '', 

    CONSTRAINT [FK_Payroll_SalaryGrade_SalarySchedule] FOREIGN KEY (SalaryScheduleId) REFERENCES Payroll_SalarySchedule(Id) 
)

GO

CREATE UNIQUE INDEX [IX_Payroll_SalaryGrade_SG] ON [dbo].[Payroll_SalaryGrade] (SG)
