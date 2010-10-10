Imports System.Windows.Forms
Imports System.Diagnostics
Imports System.Reflection
Imports System.IO
Imports Microsoft.Win32

<System.ComponentModel.RunInstaller(True)> _
Public Class SetupApp
    Inherits System.Configuration.Install.Installer
    Private Const INI_FILE As String = "\setup.ini"

    Private Sub Installer_AfterInstall(ByVal sender As Object, _
       ByVal e As System.Configuration.Install.InstallEventArgs) _
       Handles MyBase.AfterInstall
        '---to be executed when the application is installed---
        Dim ceAppPath As String = GetWindowsCeApplicationManager()
        If ceAppPath = String.Empty Then
            Return
        End If
        Dim iniPath As String = GetIniPath("Setup.ini")
        'iniPath = iniPath & " " & GetIniPath("Setup2.ini")
        'iniPath = iniPath & " " & GetIniPath("Setup3.ini")
        'iniPath = iniPath & " " & GetIniPath("Setup4.ini")
        'iniPath = iniPath & " " & GetIniPath("Setup5.ini")
        'iniPath = iniPath & " " & GetIniPath("Setup6.ini")
        'iniPath = iniPath & " " & GetIniPath("Setup7.ini")
        Process.Start(ceAppPath, iniPath)

    End Sub

    Private Sub Installer_AfterUninstall(ByVal sender As Object, _
      ByVal e As System.Configuration.Install.InstallEventArgs) _
      Handles MyBase.AfterUninstall
        '---to be executed when the application is uninstalled---
        Dim ceAppPath As String = GetWindowsCeApplicationManager()
        If ceAppPath = String.Empty Then
            Return
        End If
        Dim iniPath As String = GetIniPath("Setup4.ini")
        Process.Start(ceAppPath, String.Empty)
    End Sub

    Public Shared Function GetWindowsCeApplicationManager() As String
        '---check if the Windows CE Application Manager is installed---
        Dim ceAppPath As String = KeyExists()
        If ceAppPath = String.Empty Then
            MessageBox.Show("Windows CE App Manager not installed", _
                            "Setup", MessageBoxButtons.OK, _
                            MessageBoxIcon.Error)
            Return String.Empty
        Else
            Return ceAppPath
        End If
    End Function

    Public Shared Function GetIniPath(ByVal file As String) As String
        '---get the path of the .ini file---
        Return """" & _
           Path.Combine(Path.GetDirectoryName( _
           System.Reflection.Assembly. _
           GetExecutingAssembly().Location) & "\Install_ADAPpc", file) & """"
    End Function

    Private Shared Function KeyExists() As String
        '---get the path to the Windows CE App Manager from the registry---
        Dim key As RegistryKey = _
           Registry.LocalMachine.OpenSubKey( _
           "SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\CEAPPMGR.EXE")
        If key Is Nothing Then
            Return String.Empty
        Else
            Return key.GetValue(String.Empty, String.Empty)
        End If
    End Function
End Class

