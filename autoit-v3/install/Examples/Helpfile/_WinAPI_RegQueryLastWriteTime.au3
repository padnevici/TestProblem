#include <APIRegConstants.au3>
#include <Date.au3>
#include <MsgBoxConstants.au3>
#include <WinAPIDiag.au3>
#include <WinAPILocale.au3>
#include <WinAPIReg.au3>

Local $hKey = _WinAPI_RegOpenKey($HKEY_LOCAL_MACHINE, 'SOFTWARE\AutoIt v3\AutoIt', $KEY_QUERY_VALUE)
If @error Then
	MsgBox(BitOR($MB_ICONERROR, $MB_SYSTEMMODAL), @extended, _WinAPI_GetErrorMessage(@extended))
	Exit
EndIf

Local $tFT = _WinAPI_RegQueryLastWriteTime($hKey)
$tFT = _Date_Time_FileTimeToLocalFileTime(DllStructGetPtr($tFT))
Local $tST = _Date_Time_FileTimeToSystemTime(DllStructGetPtr($tFT))
_WinAPI_RegCloseKey($hKey)

ConsoleWrite('Last modified at: ' & _WinAPI_GetDateFormat(0, $tST) & ' ' & _WinAPI_GetTimeFormat(0, $tST) & @CRLF)
