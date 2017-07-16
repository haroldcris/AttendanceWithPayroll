CREATE TABLE [dbo].[Location_Barangays](
    [Id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [Province] [nvarchar](50) NOT NULL,
    [Town] [nvarchar](50) NOT NULL,
    [Barangay] [nvarchar](50) NOT NULL,

    CONSTRAINT [IX_Barangays] UNIQUE NONCLUSTERED 
    (
	   [Province] ASC,
	   [Town] ASC,
	   [Barangay] ASC
    )
) ON [PRIMARY]

