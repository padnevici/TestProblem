#include <FileConstants.au3>
#include <MsgBoxConstants.au3>

Example()

Func Example()
	; Create a constant variable in Local scope of the filepath that will be read/written to.
	Local Const $sFilePath = @TempDir & "\FileOpen.txt"

	; Create a temporary file to read data from.
	If Not FileCreate($sFilePath, "This is an example of using FileOpen.") Then Return MsgBox($MB_SYSTEMMODAL, "", "An error occurred whilst writing the temporary file.")

	; Open the file for reading and store the handle to a variable.
	Local $hFileOpen = FileOpen($sFilePath, $FO_READ)
	If $hFileOpen = -1 Then
		MsgBox($MB_SYSTEMMODAL, "", "An error occurred when reading the file.")
		Return False
	EndIf

	; Read the contents of the file using the handle returned by FileOpen.
	Local $sFileRead = FileRead($hFileOpen)

	; Close the handle returned by FileOpen.
	FileClose($hFileOpen)

	; Display the contents of the file.
	MsgBox($MB_SYSTEMMODAL, "", "Contents of the file:" & @CRLF & $sFileRead)

	; Delete the temporary file.
	FileDelete($sFilePath)
EndFunc   ;==>Example

; Create a file.
Func FileCreate($sFilePath, $sString)
	Local $bReturn = True ; Create a variable to store a boolean value.
	If FileExists($sFilePath) = 0 Then $bReturn = FileWrite($sFilePath, $sString) = 1 ; If FileWrite returned 1 this will be True otherwise False.
	Return $bReturn ; Return the boolean value of either True of False, depending on the return value of FileWrite.
EndFunc   ;==>FileCreate
