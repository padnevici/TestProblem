#include <MsgBoxConstants.au3>

; AutoIt 3.1.1.x beta version
;
; COM Test File
;
; Error Event test using Winnt ADSI
;
; This will cause an ErrorEvent on most computers.

; Initialize my Error function
Local $oErrObj = ObjEvent("AutoIt.Error", "MyErrFunc")

; Open Winnt object on local machine, this might take a few seconds time.
Local $oContainer = ObjGet("WinNT://" & @ComputerName)
If @error Then
	MsgBox($MB_SYSTEMMODAL, "AutoItCOM Test", "Failed to open WinNT://. Error code: " & Hex(@error, 8))
	Exit
EndIf

Local $sUser = "CBrooke"
Local $oUser = $oContainer.Create("User", $sUser)

; This will only succeed on computers where local user passwords are allowed to be empty.
$oUser.SetInfo()

; The line below should throw an Error after a short timeout,
; because "domain" and "MyGroup" do not exist.

Local $oGroup = ObjGet("WinNT://domain/MyGroup, group")

If @error Then
	MsgBox($MB_SYSTEMMODAL, "", "error opening object $oGroup, error code: " & @error)
	Exit
Else
	$oGroup.Add($oUser.ADsPath)
	$oGroup.SetInfo()
EndIf

Exit

; ----------------

Func MyErrFunc($oErrobj)
	Local $sHexnum = Hex($oErrobj.number, 8)

	MsgBox($MB_SYSTEMMODAL, "", "We intercepted a COM Error!!" & @CRLF & @CRLF & _
			"err.description is: " & $oErrobj.description & @CRLF & _
			"err.windescription is: " & $oErrobj.windescription & @CRLF & _
			"err.lastdllerror is: " & $oErrobj.lastdllerror & @CRLF & _
			"err.scriptline is: " & $oErrobj.scriptline & @CRLF & _
			"err.number is: " & $sHexnum & @CRLF & _
			"err.source is: " & $oErrobj.source & @CRLF & _
			"err.helpfile is: " & $oErrobj.helpfile & @CRLF & _
			"err.helpcontext is: " & $oErrobj.helpcontext _
			)
EndFunc   ;==>MyErrFunc
