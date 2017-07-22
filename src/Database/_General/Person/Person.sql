CREATE TABLE [dbo].Person
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),

	[Lastname]		   nvarchar(50) NOT NULL,	
	[Firstname]		   nvarchar(50) NOT NULL,	
	[MiddleName]	   nvarchar(50) DEFAULT '' NOT NULL,	
	[MiddleInitial]			   nvarchar(5) DEFAULT '' NOT NULL,	
	[NameExtension]	   nvarchar(10) NOT NULL DEFAULT '',	

	[Gender]		   nvarchar(10) NOT NULL,
	[BirthDate]		   date NOT NULL DEFAULT '19200101',

	[Street]		   nvarchar(100)	NOT NULL DEFAULT '',
	[Barangay]		   nvarchar(50)	NOT NULL,
	[Town]			   nvarchar(50)	NOT NULL,
	[Province]		   nvarchar(50)	NOT NULL,

	[Created]			[datetime]		NOT NULL DEFAULT getdate(),
	[Modified]			[datetime]		NOT NULL DEFAULT getdate(),
	[CreatedBy]			[nvarchar](20)	NOT NULL ,
	[ModifiedBy]		[nvarchar](20)	NOT NULL DEFAULT ''
)

GO

