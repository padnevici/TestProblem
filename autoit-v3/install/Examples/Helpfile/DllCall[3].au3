#include <MsgBoxConstants.au3>

; Show the Windows PickIconDlg.
Local $sFileName = @SystemDir & '\shell32.dll'

; Create a structure to store the icon index
Local $tIcon = DllStructCreate("int")
Local $tString = DllStructCreate("wchar[260]")
Local $iStructsize = DllStructGetSize($tString) / 2
DllStructSetData($tString, 1, $sFileName)

; Run the PickIconDlg - '62' is the ordinal value for this function
DllCall("shell32.dll", "none", 62, _
		"hwnd", 0, _
		"ptr", DllStructGetPtr($tString), _
		"int", $iStructsize, _
		"ptr", DllStructGetPtr($tIcon))

$sFileName = DllStructGetData($tString, 1)
Local $iIconIndex = DllStructGetData($tIcon, 1)

; Show the new filename and icon index
MsgBox($MB_SYSTEMMODAL, "Info", "Last selected file: " & $sFileName & @CRLF & "Icon-Index: " & $iIconIndex)
