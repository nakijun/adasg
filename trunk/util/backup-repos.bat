@echo off
set REPOS_PATH=%1
SET BACKUP_DIR=%2

echo Backup %REPOS_PATH% start >> %BACKUP_DIR%svn_backup.log
date /t >> %BACKUP_DIR%svn_backup.log
time /t >> %BACKUP_DIR%svn_backup.log

hot-backup.py %REPOS_PATH% %BACKUP_DIR% >> %BACKUP_DIR%svn_backup.log
if errorlevel 1 goto error

echo Backup %REPOS_PATH% end >> %BACKUP_DIR%svn_backup.log
date /t >> %BACKUP_DIR%svn_backup.log
time /t >> %BACKUP_DIR%svn_backup.log
echo ------------------------------------------------------------------- >> %BACKUP_DIR%svn_backup.log

exit 0

:error
echo error!!!
