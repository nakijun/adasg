USE msdb ;
GO

EXEC dbo.sp_start_job N'WIN2003-ADA-Symbol-1' ;
GO

EXEC dbo.sp_start_job N'WIN2003-ADA-Schedule-2' ;
GO

EXEC dbo.sp_start_job N'WIN2003-ADA-Communicator-3' ;
GO