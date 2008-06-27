@ECHO OFF
CD/D %~DP0%..
SET WORKSPACE=%CD%
SET PATH=%WORKSPACE%\util;%PATH%;
SET BUILDFILE="%WORKSPACE%\util\default.build"

TITLE DevEnv Command Prompt @ %WORKSPACE%
%comspec% /k ""C:\Program Files\Microsoft Visual Studio 9.0\VC\vcvarsall.bat"" x86
:END