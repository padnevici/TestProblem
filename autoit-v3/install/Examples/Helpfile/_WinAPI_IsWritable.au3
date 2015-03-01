#include <WinAPIFiles.au3>

Local $aDrive = DriveGetDrive('ALL')

If IsArray($aDrive) Then
	Local $sText
	For $i = 1 To $aDrive[0]
		If _WinAPI_IsWritable($aDrive[$i]) Then
			$sText = 'Writable'
		Else
			$sText = 'Not writable'
		EndIf
		If Not @error Then
			ConsoleWrite(StringUpper($aDrive[$i]) & ' => ' & $sText & @CRLF)
		EndIf
	Next
EndIf
