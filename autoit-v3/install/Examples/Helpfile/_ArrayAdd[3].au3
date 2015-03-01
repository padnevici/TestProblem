#include <Array.au3>
#include <MsgBoxConstants.au3>

Local $aArray_Base[2] = ["Org Item 0", "Org item 1"]
Local $aArray
Local $sFill = ""
For $i = 1 To 5
	$sFill &= $i + 1 & "|" ; Note added as number datatype here
Next
$sFill = StringTrimRight($sFill, 1)
MsgBox($MB_SYSTEMMODAL, "Delimited string to add", $sFill)

; Add items by delimited string
$aArray = $aArray_Base
_ArrayAdd($aArray, $sFill)
_ArrayDisplay($aArray, "Converted to string")
; But converted to string datatype here
MsgBox($MB_SYSTEMMODAL, "Result", "Data:" & @TAB & $aArray[6] & @CRLF & "Datatype:" & @TAB & VarGetType($aArray[6]))

; Add items by delimited string
$aArray = $aArray_Base
; Now force datatype to be retained
Local $hDataType = Number
_ArrayAdd($aArray, $sFill, Default, Default, Default, $hDataType)
_ArrayDisplay($aArray, "Forced to number")
; And datatype is retained
MsgBox($MB_SYSTEMMODAL, "Result", "Data:" & @TAB & $aArray[6] & @CRLF & "Datatype:" & @TAB & VarGetType($aArray[6]))
