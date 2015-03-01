#include <Debug.au3>
#include <FTPEx.au3>

_DebugSetup(StringTrimRight(@ScriptName, 4) & ' example', True)

Local $sServer = 'ftp.mozilla.org'
Local $sUsername = ''
Local $sPass = ''

Local $hOpen = _FTP_Open('MyFTP Control')
Local $pCallback = _FTP_SetStatusCallback($hOpen, 'FTPStatusCallbackHandler')

Local $hConn = _FTP_Connect($hOpen, $sServer, $sUsername, $sPass, 0, $INTERNET_DEFAULT_FTP_PORT, $INTERNET_SERVICE_FTP, 0, $pCallback)

Local $iFtpc = _FTP_Close($hConn)
Local $iFtpo = _FTP_Close($hOpen)

Func FTPStatusCallbackHandler($hInternet, $iContent, $iInternetStatus, $pvStatusInformation , $iStatusInformationLength)
	#forceref $hInternet, $iContent
	If $iInternetStatus = $INTERNET_STATUS_REQUEST_SENT Or $iInternetStatus = $INTERNET_STATUS_RESPONSE_RECEIVED Then
		Local $iSize, $iBytesRead
		$iSize = DllStructCreate('dword')
		_WinAPI_ReadProcessMemory(_WinAPI_GetCurrentProcess(), $pvStatusInformation , DllStructGetPtr($iSize), $iStatusInformationLength, $iBytesRead)
		_DebugOut(_FTP_DecodeInternetStatus($iInternetStatus) & ' | Size = ' & DllStructGetData($iSize, 1) & ' Bytes    Bytes read = ' & $iBytesRead)
	Else
		_DebugOut(_FTP_DecodeInternetStatus($iInternetStatus))
	EndIf
EndFunc   ;==>FTPStatusCallbackHandler
