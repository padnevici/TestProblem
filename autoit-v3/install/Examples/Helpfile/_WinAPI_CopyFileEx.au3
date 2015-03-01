#include <APIFilesConstants.au3>
#include <Misc.au3>
#include <WinAPIDiag.au3>
#include <WinAPIFiles.au3>

Opt('TrayAutoPause', 0)

Local $hProgressProc = DllCallbackRegister('_ProgressProc', 'dword', 'uint64;uint64;uint64;uint64;dword;dword;ptr;ptr;long_ptr')

ProgressOn('_WinAPI_CopyFileEx', 'Copying...', '', -1, -1, 2)

Local $sFile = 'D:\Test.tmp'
If Not _WinAPI_CopyFileEx($sFile, @TempDir & '\Test.tmp', 0, DllCallbackGetPtr($hProgressProc)) Then
	_WinAPI_ShowLastError('Error copying ' & $sFile)
EndIf

DllCallbackFree($hProgressProc)

ProgressOff()

Func _ProgressProc($iTotalFileSize, $iTotalBytesTransferred, $iStreamSize, $iStreamBytesTransferred, $iStreamNumber, $iCallbackReason, $hSourceFile, $hDestinationFile, $iData)
	#forceref $iStreamSize, $iStreamBytesTransferred, $iStreamNumber, $iCallbackReason, $hSourceFile, $hDestinationFile, $iData

	Local $iPercent = Round($iTotalBytesTransferred / $iTotalFileSize * 100)

	If $iPercent = 100 Then
		ProgressSet($iPercent, '', 'Complete')
	Else
		ProgressSet($iPercent)
	EndIf
	If _IsPressed('1B') Then
		Return $PROGRESS_CANCEL
	Else
		Return $PROGRESS_CONTINUE
	EndIf
EndFunc   ;==>_ProgressProc
