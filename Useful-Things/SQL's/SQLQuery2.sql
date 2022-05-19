USE [(BG)-dev.DB]
GO 

SELECT DB_NAME() AS DbName, 
name AS FileName, 
size/128.0 AS CurrentSizeMB, 
size/128.0 - CAST(FILEPROPERTY(name, 'SpaceUsed') AS INT)/128.0 AS FreeSpaceMB 
FROM sys.database_files; 
-------------------------------------------------------------------------------------------

USE [(BG)-dev.DB]
GO
SELECT 
    [TYPE] = A.TYPE_DESC
    ,[FILE_Name] = A.name
    ,[FILEGROUP_NAME] = fg.name
    ,[File_Location] = A.PHYSICAL_NAME
    ,[FILESIZE_MB] = CONVERT(DECIMAL(10,2),A.SIZE/128.0)
    ,[USEDSPACE_MB] = CONVERT(DECIMAL(10,2),A.SIZE/128.0 - ((SIZE/128.0) - CAST(FILEPROPERTY(A.NAME, 'SPACEUSED') AS INT)/128.0))
    ,[FREESPACE_MB] = CONVERT(DECIMAL(10,2),A.SIZE/128.0 - CAST(FILEPROPERTY(A.NAME, 'SPACEUSED') AS INT)/128.0)
    ,[FREESPACE_%] = CONVERT(DECIMAL(10,2),((A.SIZE/128.0 - CAST(FILEPROPERTY(A.NAME, 'SPACEUSED') AS INT)/128.0)/(A.SIZE/128.0))*100)
    ,[AutoGrow] = 'By ' + CASE is_percent_growth WHEN 0 THEN CAST(growth/128 AS VARCHAR(10)) + ' MB -' 
        WHEN 1 THEN CAST(growth AS VARCHAR(10)) + '% -' ELSE '' END 
        + CASE max_size WHEN 0 THEN 'DISABLED' WHEN -1 THEN ' Unrestricted' 
            ELSE ' Restricted to ' + CAST(max_size/(128*1024) AS VARCHAR(10)) + ' GB' END 
        + CASE is_percent_growth WHEN 1 THEN ' [autogrowth by percent, BAD setting!]' ELSE '' END
FROM sys.database_files A LEFT JOIN sys.filegroups fg ON A.data_space_id = fg.data_space_id 
order by A.TYPE desc, A.NAME; 
--------------------------------------------------------------------------------------------------------------------

--Failed Backups--

SELECT  
   distinct CONVERT(CHAR(100), SERVERPROPERTY('Servername')) AS Server, 
   msdb.dbo.backupset.database_name,  
   msdb.dbo.backupset.backup_start_date,  
   msdb.dbo.backupset.backup_finish_date, 
 CAST((DATEDIFF(second,  msdb.dbo.backupset.backup_start_date,msdb.dbo.backupset.backup_finish_date)) AS varchar)+ ' secs  ' AS [Total Time] ,

   Cast(msdb.dbo.backupset.backup_size/1024/1024 AS numeric(10,2)) AS 'Backup Size(MB)',   
   msdb.dbo.backupset.name AS backupset_name
FROM   msdb.dbo.backupmediafamily  
   INNER JOIN msdb.dbo.backupset ON msdb.dbo.backupmediafamily.media_set_id = msdb.dbo.backupset.media_set_id   
--Enter your database below
and database_name = '(BG)-dev.DB'
and msdb.dbo.backupset.backup_start_date>'2013-12-31' and msdb.dbo.backupset.backup_start_date<'2014-01-27 23:59:59'
ORDER BY  
   msdb.dbo.backupset.database_name, 
   msdb.dbo.backupset.backup_start_date
--------------------------------------------------------------------------------------------------------
--failed jobs--

-- Variable Declarations 

DECLARE @PreviousDate datetime  
DECLARE @Year VARCHAR(4)   
DECLARE @Month VARCHAR(2)  
DECLARE @MonthPre VARCHAR(2)  
DECLARE @Day VARCHAR(2)  
DECLARE @DayPre VARCHAR(2)  
DECLARE @FinalDate INT  

-- Initialize Variables  
SET @PreviousDate = DATEADD(dd, -1, GETDATE()) -- Last 1 day   
SET @Year = DATEPART(yyyy, @PreviousDate)   
SELECT @MonthPre = CONVERT(VARCHAR(2), DATEPART(mm, @PreviousDate))  
SELECT @Month = RIGHT(CONVERT(VARCHAR, (@MonthPre + 1000000000)),2)  
SELECT @DayPre = CONVERT(VARCHAR(2), DATEPART(dd, @PreviousDate))  
SELECT @Day = RIGHT(CONVERT(VARCHAR, (@DayPre + 1000000000)),2)  
SET @FinalDate = CAST(@Year + @Month + @Day AS INT)  

-- Final Logic 

SELECT   j.[name],  
         s.step_name,  
         h.step_id,  
         h.step_name,  
         h.run_date,  
         h.run_time,  
         h.sql_severity,  
         h.message,   
         h.server  
FROM     msdb.dbo.sysjobhistory h  
         INNER JOIN msdb.dbo.sysjobs j  
           ON h.job_id = j.job_id  
         INNER JOIN msdb.dbo.sysjobsteps s  
           ON j.job_id = s.job_id 
           AND h.step_id = s.step_id  
WHERE    h.run_status = 0 -- Failure  
         AND h.run_date > @FinalDate  
ORDER BY h.instance_id DESC 

-------------------------------------------------------------------------------

SELECT  L.request_session_id AS SPID, 
    DB_NAME(L.resource_database_id) AS DatabaseName,
    O.Name AS LockedObjectName, 
    P.object_id AS LockedObjectId, 
    L.resource_type AS LockedResource, 
    L.request_mode AS LockType,
    ST.text AS SqlStatementText,        
    ES.login_name AS LoginName,
    ES.host_name AS HostName,
    TST.is_user_transaction as IsUserTransaction,
    AT.name as TransactionName,
    CN.auth_scheme as AuthenticationMethod
FROM    sys.dm_tran_locks L
    JOIN sys.partitions P ON P.hobt_id = L.resource_associated_entity_id
    JOIN sys.objects O ON O.object_id = P.object_id
    JOIN sys.dm_exec_sessions ES ON ES.session_id = L.request_session_id
    JOIN sys.dm_tran_session_transactions TST ON ES.session_id = TST.session_id
    JOIN sys.dm_tran_active_transactions AT ON TST.transaction_id = AT.transaction_id
    JOIN sys.dm_exec_connections CN ON CN.session_id = ES.session_id
    CROSS APPLY sys.dm_exec_sql_text(CN.most_recent_sql_handle) AS ST
WHERE   resource_database_id = db_id()
ORDER BY L.request_session_id
