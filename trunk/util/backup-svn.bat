@echo off
set REPOS_PATH=C:\SVN\SAAC
SET BACKUP_DIR=D:\Project\Backup\

start call backup-repos.bat %REPOS_PATH% %BACKUP_DIR%
