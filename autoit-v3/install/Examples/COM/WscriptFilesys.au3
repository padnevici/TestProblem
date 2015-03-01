#include <MsgBoxConstants.au3>

; Wscript.filesystem Example
;
; Based on AutoItCOM version 3.1.0
;
; Beta version 06-02-2005
;

Local $sFolder = @TempDir ; Folder to test the size of

Local $oFSO = ObjCreate("Scripting.FileSystemObject")

If @error Then
	MsgBox($MB_SYSTEMMODAL, "Wscript.filesystem Test", "I'm sorry, but creation of object $oFSO failed. Error code: " & @error)
	Exit
EndIf

Local $oFolder = $oFSO.GetFolder($sFolder) ; Get object to the given folder

MsgBox($MB_SYSTEMMODAL, "Wscript.filesystem Test", "Your " & $sFolder & " folder size is: " & Round($oFolder.Size / 1024) & " Kilobytes")

Exit
