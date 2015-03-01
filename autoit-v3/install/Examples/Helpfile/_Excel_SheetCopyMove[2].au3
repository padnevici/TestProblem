#include <Excel.au3>
#include <MsgBoxConstants.au3>

; Create application object and open an example workbook
Local $oAppl = _Excel_Open()
If @error Then Exit MsgBox($MB_SYSTEMMODAL, "Excel UDF: _Excel_SheetCopyMove Example", "Error creating the Excel application object." & @CRLF & "@error = " & @error & ", @extended = " & @extended)
; Open Workbook 2
Local $oWorkbook2 = _Excel_BookOpen($oAppl, @ScriptDir & "\Extras\_Excel3.xls")
If @error Then
	MsgBox($MB_SYSTEMMODAL, "Excel UDF: _Excel_SheetCopyMove Example", "Error opening workbook '" & @ScriptDir & "\Extras\_Excel3.xls'." & @CRLF & "@error = " & @error & ", @extended = " & @extended)
	_Excel_Close($oAppl)
	Exit
EndIf
; Open Workbook 1
Local $oWorkbook1 = _Excel_BookOpen($oAppl, @ScriptDir & "\Extras\_Excel1.xls")
If @error Then
	MsgBox($MB_SYSTEMMODAL, "Excel UDF: _Excel_SheetCopyMove Example", "Error opening workbook '" & @ScriptDir & "\Extras\_Excel1.xls'." & @CRLF & "@error = " & @error & ", @extended = " & @extended)
	_Excel_Close($oAppl)
	Exit
EndIf

; *****************************************************************************
; Move sheet 2 before sheet 1. Set the name of the moved sheet
; *****************************************************************************
Local $oMovedSheet = _Excel_SheetCopyMove($oWorkbook1, 2, Default, 1, Default, False)
If @error Then Exit MsgBox($MB_SYSTEMMODAL, "Excel UDF: _Excel_SheetCopyMove Example 2", "Error moving sheet." & @CRLF & "@error = " & @error & ", @extended = " & @extended)
; Set the name of the new sheet
#forceref $oMovedSheet
$oMovedSheet.Name = "Moved sheet"
MsgBox($MB_SYSTEMMODAL, "Excel UDF: _Excel_SheetCopyMove Example 2", "Sheet 2 moved before sheet 1")
