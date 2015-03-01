#include <GUIConstantsEx.au3>
#include <GuiListBox.au3>
#include <MsgBoxConstants.au3>

Example()

Func Example()
	Local $tRect, $idListBox

	; Create GUI
	GUICreate("List Box Get Item RectEx", 400, 296)
	$idListBox = GUICtrlCreateList("", 2, 2, 396, 296)
	GUISetState(@SW_SHOW)

	; Add strings
	_GUICtrlListBox_BeginUpdate($idListBox)
	For $iI = 1 To 9
		_GUICtrlListBox_AddString($idListBox, StringFormat("%03d : Random string", Random(1, 100, 1)))
	Next
	_GUICtrlListBox_EndUpdate($idListBox)

	; Show item rectangle
	$tRect = _GUICtrlListBox_GetItemRectEx($idListBox, 4)
	MsgBox($MB_SYSTEMMODAL, "Information", "Item 5 Rectangle: " & _
			DllStructGetData($tRect, "Left") & ", " & _
			DllStructGetData($tRect, "Top") & ", " & _
			DllStructGetData($tRect, "Right") & ", " & _
			DllStructGetData($tRect, "Bottom"))

	; Loop until the user exits.
	Do
	Until GUIGetMsg() = $GUI_EVENT_CLOSE
	GUIDelete()
EndFunc   ;==>Example
