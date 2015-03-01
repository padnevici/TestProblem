#include <MsgBoxConstants.au3>

; Word Automation Example
;
; Based on AutoItCOM version 3.1.0
;
; Beta version 06-02-2005

Local $oWord = ObjCreate("Word.Application")

MsgBox($MB_SYSTEMMODAL, "WordTest", "Your Word Version is : " & $oWord.Version)
MsgBox($MB_SYSTEMMODAL, "WordTest", "Build: " & $oWord.Build)

$oWord.Quit ; Get rid of Word
