#include <MsgBoxConstants.au3>
#include <WinAPI.au3>

Example()

Func Example()
	Local $hWnd, $tRect
	$hWnd = GUICreate("test")
	$tRect = _WinAPI_GetClientRect($hWnd)
	MsgBox($MB_SYSTEMMODAL, "Rect", _
			"Left..: " & DllStructGetData($tRect, "Left") & @CRLF & _
			"Right.: " & DllStructGetData($tRect, "Right") & @CRLF & _
			"Top...: " & DllStructGetData($tRect, "Top") & @CRLF & _
			"Bottom: " & DllStructGetData($tRect, "Bottom"))
EndFunc   ;==>Example
