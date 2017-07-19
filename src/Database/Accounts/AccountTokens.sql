
CREATE TABLE [dbo].[AccountTokens](
	[Id]			[bigint] IDENTITY(1,1)	NOT NULL,
	[Username]		[nvarchar](20)			NOT NULL,
	[Token]			[nvarchar](200)			NOT NULL,
	[Expiration]	AS (DATEADD(MINUTE, 10, [Created])) ,

	[WindowsUsername]	nvarchar(50) NOT NULL,
	[MachineName]		nvarchar(75) NOT NULL,
	[IpAddress]			nvarchar(MAX) NOT NULL,
	
	[Created] [datetime]		NOT NULL DEFAULT getdate(),
	[Modified] [datetime]		NOT NULL DEFAULT getdate(),
	[CreatedBy] [nvarchar](20)	NOT NULL,
	[ModifiedBy] [nvarchar](20) NOT NULL,

	CONSTRAINT [PK_AccountToken] PRIMARY KEY CLUSTERED ([Id] ASC), 
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[AccountTokens]  ADD  CONSTRAINT [FK_AccountToken_AccountUser] FOREIGN KEY([Username])
REFERENCES [dbo].[AccountUsers] ([Username])
ON UPDATE CASCADE
ON DELETE CASCADE
GO



