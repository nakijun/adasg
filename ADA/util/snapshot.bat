@echo off

if "%WORKSPACE%" == "" call %~DP0%_DevEnv.bat NO

sqlcmd -i "%WORKSPACE%\Schema\%COMPUTERNAME%\StartSnapshotAgent.sql"
if errorlevel 1 goto error

start sqlmonitor

goto end

:error
echo error!!!

:end