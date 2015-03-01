#include <File.au3>
#include <MsgBoxConstants.au3>

Local $sFind = "BEFORE"
Local $sReplace = "AFTER"

Local $sFilename = "C:\_ReplaceStringInFile.test"

Local $iMsg = "Hello Test " & $sFind & " Hello Test" & @CRLF
$iMsg &= "Hello Test" & @CRLF
$iMsg &= @CRLF
$iMsg &= $sFind

FileWrite($sFilename, $iMsg)

MsgBox($MB_SYSTEMMODAL, "BEFORE", $iMsg)

Local $iRetval = _ReplaceStringInFile($sFilename, $sFind, $sReplace)
If $iRetval = -1 Then
	MsgBox($MB_SYSTEMMODAL, "ERROR", "The pattern could not be replaced in file: " & $sFilename & " Error: " & @error)
	Exit
Else
	MsgBox($MB_SYSTEMMODAL, "INFO", "Found " & $iRetval & " occurances of the pattern: " & $sFind & " in the file: " & $sFilename)
EndIf

$iMsg = FileRead($sFilename, 1000)
MsgBox($MB_SYSTEMMODAL, "AFTER", $iMsg)
FileDelete($sFilename)
