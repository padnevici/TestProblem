#include <GUIConstantsEx.au3>
#include <Misc.au3>

Example()

Func Example()
	Local $hGUI, $aCoords[4]

	$hGUI = GUICreate("Mouse Trap Example", 392, 323)

	GUISetState(@SW_SHOW)

	While 1
		$aCoords = WinGetPos($hGUI)
		_MouseTrap($aCoords[0], $aCoords[1], $aCoords[0] + $aCoords[2], $aCoords[1] + $aCoords[3])
		Switch GUIGetMsg()
			Case $GUI_EVENT_CLOSE
				ExitLoop
			Case Else
				;;;
		EndSwitch
	WEnd
	_MouseTrap()
	Exit
EndFunc   ;==>Example
