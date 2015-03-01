#include <MsgBoxConstants.au3>
#include <WinAPI.au3>
#include <WinAPIDlg.au3>

Local Const $sTitle = 'Message'
Local Const $sText = 'This is a simple message box with a custom icon.'

Local $tMBP = DllStructCreate($tagMSGBOXPARAMS & ';wchar[' & (StringLen($sTitle) + 1) & '];wchar[' & (StringLen($sText) + 1) & ']')
DllStructSetData($tMBP, 'Size', DllStructGetPtr($tMBP, 11) - DllStructGetPtr($tMBP))
DllStructSetData($tMBP, 'hOwner', 0)
DllStructSetData($tMBP, 'hInstance', _WinAPI_GetModuleHandle(@SystemDir & '\shell32.dll'))
DllStructSetData($tMBP, 'Text', DllStructGetPtr($tMBP, 12))
DllStructSetData($tMBP, 'Caption', DllStructGetPtr($tMBP, 11))
DllStructSetData($tMBP, 'Style', BitOR($MB_OKCANCEL, $MB_USERICON))
DllStructSetData($tMBP, 'Icon', 239)
DllStructSetData($tMBP, 'ContextHelpId', 0)
DllStructSetData($tMBP, 'MsgBoxCallback', 0)
DllStructSetData($tMBP, 'LanguageId', 0)
DllStructSetData($tMBP, 11, $sTitle)
DllStructSetData($tMBP, 12, $sText)

Local $iResult = _WinAPI_MessageBoxIndirect($tMBP)

ConsoleWrite('Return: ' & $iResult & @CRLF)
