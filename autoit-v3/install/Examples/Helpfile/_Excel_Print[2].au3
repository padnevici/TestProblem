#include <Excel.au3>
#include <MsgBoxConstants.au3>

; Create application object and open an example workbook
Local $oAppl = _Excel_Open()
If @error Then Exit MsgBox($MB_SYSTEMMODAL, "Excel UDF: _Excel_Print Example", "Error creating the Excel application object." & @CRLF & "@error = " & @error & ", @extended = " & @extended)
Local $oWorkbook = _Excel_BookOpen($oAppl, @ScriptDir & "\Extras\_Excel4.xls", True)
If @error Then
	MsgBox($MB_SYSTEMMODAL, "Excel UDF: _Excel_Print Example", "Error opening workbook '" & @ScriptDir & "\Extras\_Excel4.xls'." & @CRLF & "@error = " & @error & ", @extended = " & @extended)
	_Excel_Close($oAppl)
	Exit
EndIf

; *****************************************************************************
; Print the active worksheet to the default printer.
; *****************************************************************************
_Excel_Print($oAppl, $oAppl.ActiveSheet)
If @error Then Exit MsgBox($MB_SYSTEMMODAL, "Excel UDF: _Excel_Print Example 2", "Error printing worksheet." & @CRLF & "@error = " & @error & ", @extended = " & @extended)
MsgBox($MB_SYSTEMMODAL, "Excel UDF: _Excel_Print Example 2", "Active Worksheet successfully printed.")
