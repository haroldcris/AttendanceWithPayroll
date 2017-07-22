CREATE TABLE [dbo].[Location_Province](
    [Id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [Province] [nvarchar](50) NOT NULL,
    
    CONSTRAINT [IX_Province] UNIQUE NONCLUSTERED ([Province])
) ON [PRIMARY]