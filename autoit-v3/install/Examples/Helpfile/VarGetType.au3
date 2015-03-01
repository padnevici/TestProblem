#include <MsgBoxConstants.au3>

Local $aArray[2] = [1, "Example"]
Local $dBinary = Binary("0x00204060")
Local $bBoolean = False
Local $hFunc = ConsoleWrite
Local $pPtr = Ptr(-1)
Local $hWnd = WinGetHandle(AutoItWinGetTitle())
Local $iInt = 1
Local $fFloat = 2.0
Local $oObject = ObjCreate("Scripting.Dictionary")
Local $sString = "Some text"
Local $tStruct = DllStructCreate("wchar[256]")
Local $vKeyword = Default

MsgBox($MB_SYSTEMMODAL, "", "Variable Types" & @CRLF & "$aArray is an " & VarGetType($aArray) & " variable type." & @CRLF & _
		"$dBinary is a " & VarGetType($dBinary) & " variable type." & @CRLF & _
		"$bBoolean is a " & VarGetType($bBoolean) & " variable type." & @CRLF & _
		"$hFunc is a " & VarGetType($hFunc) & " variable type." & @CRLF & _
		"$pPtr is a " & VarGetType($pPtr) & " variable type." & @CRLF & _
		"$hWnd is a " & VarGetType($hWnd) & " variable type." & @CRLF & _
		"$iInt is an " & VarGetType($iInt) & " variable type." & @CRLF & _
		"$fFloat is a " & VarGetType($fFloat) & " variable type." & @CRLF & _
		"$oObject is a " & VarGetType($oObject) & " variable type." & @CRLF & _
		"$sString is a " & VarGetType($sString) & " variable type." & @CRLF & _
		"$tStruct is a " & VarGetType($tStruct) & " variable type." & @CRLF & _
		"$vKeyword is a " & VarGetType($vKeyword) & " variable type." & @CRLF)
