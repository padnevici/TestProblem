#include <Constants.au3>

; WMI example to enumerate services

Local $oWMI = ObjGet("winmgmts://" & @ComputerName)

Local $s = ""
For $oItem In $oWMI.ExecQuery("select * from win32_service")
	$s = $s & $oItem.name & @TAB
Next

MsgBox($MB_SYSTEMMODAL, "", "Services on this computer: " & @CRLF & $s)
