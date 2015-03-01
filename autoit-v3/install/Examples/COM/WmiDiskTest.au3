#include <MsgBoxConstants.au3>

; AutoItCOM 3.1.0
;
; Test File
;
; Use WMI to collect logical drive information

Local $oCol = ObjGet("winmgmts:")

Local $oInstance = $oCol.instancesof("Win32_LogicalDisk")

If @error Then
	MsgBox($MB_SYSTEMMODAL, "", "error getting object. Error code: " & @error)
	Exit
EndIf

Local $s = "size:" & @TAB & "driveletter:" & @CRLF

For $oDrive In $oInstance
	$s = $s & $oDrive.size & @TAB & $oDrive.deviceid & @CRLF
Next

MsgBox($MB_SYSTEMMODAL, "Drive test", "Drive information: " & @CRLF & $s)
