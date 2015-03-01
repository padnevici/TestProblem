#include <MsgBoxConstants.au3>

; Wscript.Network Example
;
; Based on AutoItCOM version 3.1.0
;
; Beta version 06-02-2005

Local $oNetwork = ObjCreate("WScript.Network")

If @error Then
	MsgBox($MB_SYSTEMMODAL, "Wscript.network Test", "I'm sorry, but creation of object $oNetwork failed. Error code: " & @error)
	Exit
EndIf

Local $oColDrives = $oNetwork.EnumNetworkDrives

If Not IsObj($oColDrives) Then
	MsgBox($MB_SYSTEMMODAL, "Wscript.network Test", "I'm sorry, but creation of object $oColDrives failed.")
	Exit
EndIf

Local $iNumDrives = $oColDrives.Count

If $iNumDrives = 0 Then
	MsgBox($MB_SYSTEMMODAL, "wscript.network", "You have currently no network drives")
Else
	For $i = 0 To $oColDrives.Count - 1 Step 2
		MsgBox($MB_SYSTEMMODAL, "Wscript.network", "Drive letter: " & $oColDrives.Item($i) & @TAB & " is mapped to: " & $oColDrives.Item($i + 1))
	Next
EndIf

Exit
