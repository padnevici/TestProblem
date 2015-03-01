#include <GDIPlus.au3>
#include <GUIConstantsEx.au3>
#include <ScreenCapture.au3>
#include <WindowsConstants.au3>

Global $g_idMemo, $g_aEncoder, $g_hImage

Example()

Func Example()
	Local $hBitmap

	; Create GUI
	GUICreate("GDI+", 600, 400)
	$g_idMemo = GUICtrlCreateEdit("", 2, 2, 596, 396, $WS_VSCROLL)
	GUICtrlSetFont($g_idMemo, 9, 400, 0, "Courier New")
	GUISetState(@SW_SHOW)

	; Initialize GDI+ library
	_GDIPlus_Startup()

	; Create an image to use for paramater lists
	$hBitmap = _ScreenCapture_Capture("", 0, 0, 1, 1)
	$g_hImage = _GDIPlus_BitmapCreateFromHBITMAP($hBitmap)

	; Show encoder parameters
	$g_aEncoder = _GDIPlus_Encoders()
	ShowEncoder("Encoder")

	; Show decoder parameters
	$g_aEncoder = _GDIPlus_Decoders()
	ShowEncoder("Decoder")

	; Clean up resources
	_GDIPlus_ImageDispose($g_hImage)
	_WinAPI_DeleteObject($hBitmap)

	; Shut down GDI+ library
	_GDIPlus_Shutdown()

	; Loop until the user exits.
	Do
	Until GUIGetMsg() = $GUI_EVENT_CLOSE
EndFunc   ;==>Example

; Write a line to the memo control
Func MemoWrite($sMessage = '')
	GUICtrlSetData($g_idMemo, $sMessage & @CRLF, 1)
EndFunc   ;==>MemoWrite

; Show encoder information
Func ShowEncoder($sTitle)
	Local $iI, $iJ, $iK, $sCLSID, $tData, $tParam, $tParams, $iParamSize = _GDIPlus_ParamSize()

	For $iI = 1 To $g_aEncoder[0][0]
		$sCLSID = _GDIPlus_EncodersGetCLSID($g_aEncoder[$iI][5])
		MemoWrite("Image " & $sTitle & " " & $iI)
		MemoWrite("  Codec GUID ............: " & $g_aEncoder[$iI][1])
		MemoWrite("  File format GUID ......: " & $g_aEncoder[$iI][2])
		MemoWrite("  Codec name ............: " & $g_aEncoder[$iI][3])
		MemoWrite("  Codec Dll file name ...: " & $g_aEncoder[$iI][4])
		MemoWrite("  Codec file format .....: " & $g_aEncoder[$iI][5])
		MemoWrite("  File name extensions ..: " & $g_aEncoder[$iI][6])
		MemoWrite("  Mime type .............: " & $g_aEncoder[$iI][7])
		MemoWrite("  Flags .................: 0x" & Hex($g_aEncoder[$iI][8]))
		MemoWrite("  Version ...............: " & $g_aEncoder[$iI][9])
		MemoWrite("  Signature count .......: " & $g_aEncoder[$iI][10])
		MemoWrite("  Signature size ........: " & $g_aEncoder[$iI][11])
		MemoWrite("  Signature pattern ptr .: 0x" & Hex($g_aEncoder[$iI][12]))
		MemoWrite("  Signature mask ptr ....: 0x" & Hex($g_aEncoder[$iI][13]))
		MemoWrite("  Paramater list size ...: " & _GDIPlus_EncodersGetParamListSize($g_hImage, $sCLSID))
		MemoWrite()

		$tParams = _GDIPlus_EncodersGetParamList($g_hImage, $sCLSID)
		If @error Then ContinueLoop

		For $iJ = 0 To DllStructGetData($tParams, "Count") - 1
			MemoWrite("  Image " & $sTitle & " Parameter " & $iJ)
			$tParam = DllStructCreate($tagGDIPENCODERPARAM, DllStructGetPtr($tParams, "GUID") + ($iJ * $iParamSize))
			MemoWrite("    Parameter GUID ......: " & _WinAPI_StringFromGUID(DllStructGetPtr($tParam, "GUID")))
			MemoWrite("    Number of values ....: " & DllStructGetData($tParam, "NumberOfValues"))
			MemoWrite("    Parameter type.......: " & DllStructGetData($tParam, "Type"))
			MemoWrite("    Parameter pointer ...: 0x" & Hex(DllStructGetData($tParam, "Values")))
			Switch DllStructGetData($tParam, "Type")
				Case 4
					$tData = DllStructCreate("int Data[" & DllStructGetData($tParam, "NumberOfValues") & "]", DllStructGetData($tParam, "Values"))
					For $iK = 1 To DllStructGetData($tParam, "NumberOfValues")
						MemoWrite("      Value .............: " & DllStructGetData($tData, 1, $iK))
					Next
				Case 6
					$tData = DllStructCreate("int Low;int High", DllStructGetData($tParam, "Values"))
					MemoWrite("      Low range .........: " & DllStructGetData($tData, "Low"))
					MemoWrite("      High range ........: " & DllStructGetData($tData, "High"))
			EndSwitch
			MemoWrite()
		Next
	Next
EndFunc   ;==>ShowEncoder
