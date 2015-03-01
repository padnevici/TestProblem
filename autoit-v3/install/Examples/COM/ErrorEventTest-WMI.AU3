#include <MsgBoxConstants.au3>

; AutoIt 3.1.1.x beta
;
; COM Test File
;
; Testing Error Event handling by creating a WMI exception

Local $sMyCompName = @ComputerName

; Initialize my error handler
Global $g_nComError, $g_oMyError = ObjEvent("AutoIt.Error", "MyErrFunc")

; Open WMI
Local $oWMIservice = ObjGet("winmgmts:\\" & $sMyCompName & "\root\cimv2")

; Check is WMI opened successfully
If @error Then
	MsgBox($MB_SYSTEMMODAL, "AutoItCOM Test", "Error getting object $oWMIservice. Error code: " & @error)
	Exit
EndIf

; Try a query
Local $oColProcessors = $oWMIservice.ExecQuery("Select * from Win32_Processor")

; THIS line should deliberately fail!
Local $vItem1 = $oColProcessors.item(1)

If $g_nComError Then
	MsgBox($MB_SYSTEMMODAL, "AutoItCOM test", "Test passed: We got an error number: 0x" & Hex($g_nComError))
Else
	MsgBox($MB_SYSTEMMODAL, "AutoItCOM test", "Test failed!")
EndIf

Exit

; This is my custom error handler
Func MyErrFunc()
	Local $sHexNumber = Hex($g_oMyError.number, 8)

	MsgBox($MB_SYSTEMMODAL, "AutoItCOM Test", "We intercepted a COM Error !" & @CRLF & @CRLF & _
			"err.description is: " & @TAB & $g_oMyError.description & @CRLF & _
			"err.windescription:" & @TAB & $g_oMyError.windescription & @CRLF & _
			"err.number is: " & @TAB & $sHexNumber & @CRLF & _
			"err.lastdllerror is: " & @TAB & $g_oMyError.lastdllerror & @CRLF & _
			"err.scriptline is: " & @TAB & $g_oMyError.scriptline & @CRLF & _
			"err.source is: " & @TAB & $g_oMyError.source & @CRLF & _
			"err.helpfile is: " & @TAB & $g_oMyError.helpfile & @CRLF & _
			"err.helpcontext is: " & @TAB & $g_oMyError.helpcontext _
			)

	$g_nComError = $g_oMyError.number
EndFunc   ;==>MyErrFunc
