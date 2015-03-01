#include <MsgBoxConstants.au3>

; AutoItCOM 3.1.0
;
; Test File
;
; Returns processor information

Local $sMyCompName = @ComputerName

Local $oWMIservice = ObjGet("winmgmts:\\" & $sMyCompName & "\root\cimv2")

If @error Then
	MsgBox($MB_SYSTEMMODAL, "", "error getting object. Error code: " & @error)
EndIf

Local $oColProcessors = $oWMIservice.ExecQuery("Select * from Win32_Processor")

Local $iCounter = 1

For $oProcessor In $oColProcessors

	MsgBox($MB_SYSTEMMODAL, "WMI Test", "Processor " & $iCounter & @CRLF & "Id: " & $oProcessor.processorid & @CRLF & _
			"Maximum Clock Speed: " & $oProcessor.MaxClockSpeed)
	$iCounter = $iCounter + 1

Next
