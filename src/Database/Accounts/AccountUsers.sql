
CREATE TABLE [dbo].[AccountUsers](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](200) NOT NULL,

	[Created] [datetime]		NOT NULL DEFAULT getdate(),
	[Modified] [datetime]		NOT NULL DEFAULT getdate(),
	[CreatedBy] [nvarchar](20)	NOT NULL,
	[ModifiedBy] [nvarchar](20) NOT NULL,

	CONSTRAINT [PK_AccountUser] PRIMARY KEY CLUSTERED ([Username] ASC) , 
	CONSTRAINT [IX_AccountUsername] UNIQUE NONCLUSTERED ([Id] ASC)	

) ON [PRIMARY]

GO

