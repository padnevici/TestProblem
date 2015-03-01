#include <Excel.au3>
#include <MsgBoxConstants.au3>

; Create application object and open an example workbook
Local $oAppl = _Excel_Open()
If @error Then Exit MsgBox($MB_SYSTEMMODAL, "Excel UDF: _Excel_Export Example", "Error creating the Excel application object." & @CRLF & "@error = " & @error & ", @extended = " & @extended)
Local $oWorkbook = _Excel_BookOpen($oAppl, @ScriptDir & "\Extras\_Excel1.xls", True)
If @error Then
	MsgBox($MB_SYSTEMMODAL, "Excel UDF: _Excel_Export Example", "Error opening workbook '" & @ScriptDir & "\Extras\_Excel1.xls'." & @CRLF & "@error = " & @error & ", @extended = " & @extended)
	_Excel_Close($oAppl)
	Exit
EndIf

; *****************************************************************************
; Export the whole workbook as PDF.
; *****************************************************************************
Local $sOutput = @TempDir & "\_Excel1_2.pdf"
_Excel_Export($oAppl, $oWorkbook, $sOutput)
If @error Then Exit MsgBox($MB_SYSTEMMODAL, "Excel UDF: _Excel_Export Example 2", "Error saving the workbook to '" & $sOutput & "'." & @CRLF & "@error = " & @error & ", @extended = " & @extended)
MsgBox($MB_SYSTEMMODAL, "Excel UDF: _Excel_Export Example 2", "The whole workbook was successfully exported as '" & $sOutput & "'.")
