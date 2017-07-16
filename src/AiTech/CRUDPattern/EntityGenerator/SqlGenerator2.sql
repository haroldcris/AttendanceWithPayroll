SET NOCOUNT ON;
DECLARE @objName NVARCHAR(100);
DECLARE @parameterCount INT;
DECLARE @errMsg VARCHAR(100);
DECLARE @parameterAt VARCHAR(1);
DECLARE @connName VARCHAR(100);

DECLARE @params	    nvarchar(max);
DECLARE @paramsDeclare  nvarchar(max);
DECLARE @fields	    nvarchar(max);
DECLARE @fieldsAt	    nvarchar(max);

--//Change the following variable to the name of your connection instance
SET @params		= '';
SET @paramsDeclare	= '';
SET @fields		= '';
SET @fieldsAt		= '';

SET @connName = 'db';
SET @parameterAt = '';
SET @objName = 'MTOP_Transactions';

SELECT dbo.sysobjects.name AS ObjName,
       dbo.sysobjects.xtype AS ObjType,
       dbo.syscolumns.name AS ColName,
       dbo.syscolumns.colorder AS ColOrder,
       dbo.syscolumns.length AS ColLen,
       dbo.syscolumns.colstat AS ColKey,
       dbo.systypes.xtype
INTO #t_obj

FROM dbo.syscolumns
     INNER JOIN dbo.sysobjects ON dbo.syscolumns.id = dbo.sysobjects.id
     INNER JOIN dbo.systypes ON dbo.syscolumns.xtype = dbo.systypes.xtype
WHERE(dbo.sysobjects.name = @objName)
     AND (dbo.systypes.status <> 1)
--*ORDER BY 
    --dbo.sysobjects.name, 
    --dbo.syscolumns.colorder;

SET @parameterCount = ( SELECT COUNT(*) FROM #t_obj );


IF(@parameterCount < 1)
    SET @errMsg = 'No Parameters/Fields found for '+@objName;

IF(@errMsg IS NULL)
    BEGIN
        DECLARE @source_name NVARCHAR, @source_type VARCHAR, @col_name NVARCHAR(100), @col_order INT, @col_type VARCHAR(20), @col_len INT, @col_key INT, @col_xtype INT, @col_redef VARCHAR(20);
        DECLARE cur CURSOR
        FOR
            SELECT *
            FROM #t_obj order by ColOrder;
        OPEN cur;
	   
	   -- Perform the first fetch.
        FETCH NEXT FROM cur INTO @source_name, @source_type, @col_name, @col_order, @col_len, @col_key, @col_xtype;
        IF(@source_type = N'U')
            SET @parameterAt = '@';
  
	   -- Check @@FETCH_STATUS to see if there are any more rows to fetch.
        WHILE @@FETCH_STATUS = 0
            BEGIN
			 --print @col_xtype;

                SET @col_redef =
                (
                    SELECT CASE @col_xtype
                               WHEN 34 THEN 'Image'
                               WHEN 35 THEN 'Text'
                               WHEN 40 THEN 'Date'
						 WHEN 48 THEN 'TinyInt'
                               WHEN 52 THEN 'SmallInt'
                               WHEN 56 THEN 'Int'
                               WHEN 58 THEN 'SmallDateTime'
                               WHEN 59 THEN 'Real'
                               WHEN 60 THEN 'Money'
                               WHEN 61 THEN 'DateTime'
                               WHEN 62 THEN 'Float'
                               WHEN 99 THEN 'NText'
                               WHEN 104 THEN 'Bit'
                               WHEN 106 THEN 'Decimal'
                               WHEN 122 THEN 'SmallMoney'
                               WHEN 127 THEN 'BigInt'
                               WHEN 165 THEN 'VarBinary'
                               WHEN 167 THEN 'VarChar'
                               WHEN 173 THEN 'Binary'
                               WHEN 175 THEN 'Char'
                               WHEN 231 THEN 'NVarChar'
                               WHEN 239 THEN 'NChar'
                               ELSE '!MISSING'
                           END AS C
                ); 
   
		  --If the type is a string then output the size declaration
                IF(@col_xtype = 231)
                  OR (@col_xtype = 167)
                  OR (@col_xtype = 175)
                  OR (@col_xtype = 99)
                  OR (@col_xtype = 35)
				
				SET @paramsDeclare = CONCAT(@paramsDeclare, space(12) + 'new SqlParameter( "'+ @parameterAt + @col_name + '", SqlDbType.'+ @col_redef + ', ' + CAST(@col_len AS VARCHAR) + ') ,' + char(13))
			 ELSE
				--Write out the parameter
				SET @paramsDeclare = CONCAT(@paramsDeclare, space(12) + 'new SqlParameter( "'+ @parameterAt + @col_name + '", SqlDbType.'+ @col_redef + ') ,' + char(13))
                
			 -- This is executed as long as the previous fetch succeeds.
			 SET @fields	  = CONCAT(@fields, '['+ @col_name +'],')
			 SET @fieldsAt	  = CONCAT(@fieldsAt, '@'+ @col_name + ',')
			 
			 SET @params	  = CONCAT(@params ,'		item.'+ @col_name + ' = reader.'+@col_name+';', char(13));
               
			
			 FETCH NEXT FROM cur INTO @source_name, @source_type, @col_name, @col_order, @col_len, @col_key, @col_xtype;	 	   
	   END;
	   
	   PRINT @params

        CLOSE cur;
        DEALLOCATE cur;
END;

IF(LEN(@errMsg) > 0)
    PRINT @errMsg;

DROP TABLE #t_obj;
SET NOCOUNT ON;
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO