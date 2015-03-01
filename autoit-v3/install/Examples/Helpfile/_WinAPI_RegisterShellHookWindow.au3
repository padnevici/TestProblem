#include <APISysConstants.au3>
#include <WinAPISys.au3>

Opt('TrayAutoPause', 0)

OnAutoItExitRegister('OnAutoItExit')

Global $g_hForm = GUICreate('')
GUIRegisterMsg(_WinAPI_RegisterWindowMessage('SHELLHOOK'), 'WM_SHELLHOOK')
_WinAPI_RegisterShellHookWindow($g_hForm)

While 1
	Sleep(1000)
WEnd

Func WM_SHELLHOOK($hWnd, $iMsg, $wParam, $lParam)
	#forceref $iMsg

	Switch $hWnd
		Case $g_hForm
			Switch $wParam
				Case $HSHELL_WINDOWACTIVATED
					Local $sTitle = WinGetTitle($lParam)

					If IsString($sTitle) Then
						ConsoleWrite('Activated: ' & $sTitle & @CRLF)
					EndIf
			EndSwitch
	EndSwitch
EndFunc   ;==>WM_SHELLHOOK

Func OnAutoItExit()
	_WinAPI_DeregisterShellHookWindow($g_hForm)
EndFunc   ;==>OnAutoItExit
