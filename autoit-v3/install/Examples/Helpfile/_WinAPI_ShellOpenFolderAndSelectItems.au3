#include <File.au3>
#include <WinAPIShellEx.au3>

Local $sPath
If @AutoItX64 Then
	$sPath = RegRead('HKLM\SOFTWARE\Wow6432Node\AutoIt v3\AutoIt', 'InstallDir')
Else
	$sPath = RegRead('HKLM\SOFTWARE\AutoIt v3\AutoIt', 'InstallDir')
EndIf

Local $aList = _FileListToArray($sPath, '*.exe', 1)

If IsArray($aList) Then
	_WinAPI_ShellOpenFolderAndSelectItems($sPath, $aList, 1)
EndIf
