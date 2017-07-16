/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

/*
:r .\_General\Location\Seeder\Province.sql
:r .\_General\Location\Seeder\Towns.sql
:r .\_General\Location\Seeder\Barangays.sql
*/

---- Add Initial User
/*
IF NOT EXISTS (SELECT * FROM AccountUsers where username = 'mtop')
    INSERT INTO [dbo].[AccountUsers]
           ([Username]
           ,[Password]
           ,[CreatedBy]
           ,[ModifiedBy])
     VALUES
           ('mtop'
           , 'dbaBXl65nOLddFGWn9Q6rg=='
           , 'sql'
           , 'sql')
GO
*/

