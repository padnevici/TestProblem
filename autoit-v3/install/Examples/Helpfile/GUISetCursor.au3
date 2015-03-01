#include <GUIConstantsEx.au3>

Global $g_iIDC = -1, $g_iNewIDC = 0

Example()

Func Example()
	HotKeySet("{ESC}", "Increment")

	GUICreate("Press ESC to Increment", 400, 400, 0, 0)

	GUISetState(@SW_SHOW)

	While GUIGetMsg() <> $GUI_EVENT_CLOSE
		If $g_iNewIDC <> $g_iIDC Then
			$g_iIDC = $g_iNewIDC
			GUISetCursor($g_iIDC)
		EndIf
		ToolTip("GUI Cursor #" & $g_iIDC)
	WEnd

	GUIDelete()
EndFunc   ;==>Example

Func Increment()
	$g_iNewIDC = $g_iIDC + 1
	If $g_iNewIDC > 15 Then $g_iNewIDC = 0
EndFunc   ;==>Increment
