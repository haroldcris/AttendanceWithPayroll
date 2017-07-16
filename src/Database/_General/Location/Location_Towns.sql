CREATE TABLE [Location_Towns] (
    [Id]			int			 PRIMARY KEY IDENTITY(1,1)   NOT NULL,
    [ProvinceId]	int			 NOT NULL,
    [Town]		nvarchar(50)	 NULL,
    [ZipCode]		nvarchar(5),		 

    --CONSTRAINT [IX_Town] UNIQUE NONCLUSTERED (ProvinceId, Town), 
    CONSTRAINT [FK_Location_Towns_Province] FOREIGN KEY ([ProvinceId]) REFERENCES [Location_Provinces]([Id])
);
