USE [master]
GO
CREATE LOGIN [ada] WITH PASSWORD=N'p@ssw0rd', DEFAULT_DATABASE=[ADA], CHECK_EXPIRATION=OFF, CHECK_POLICY=ON
GO
EXEC master..sp_addsrvrolemember @loginame = N'ada', @rolename = N'sysadmin'
GO
USE [ADA]
GO
CREATE USER [ada] FOR LOGIN [ada]
GO
USE [ADA]
GO
EXEC sp_addrolemember N'db_owner', N'ada'
GO
USE [master]
GO
CREATE USER [ada] FOR LOGIN [ada]
GO
USE [master]
GO
EXEC sp_addrolemember N'db_owner', N'ada'
GO
