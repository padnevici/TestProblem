#include <Math.au3>
#include <MsgBoxConstants.au3>

Local $i_Var = InputBox('Odd or Even', 'Enter a number:')
Local $i_Result = _MathCheckDiv($i_Var, 2)
If $i_Result = -1 Or @error = 1 Then
	MsgBox($MB_SYSTEMMODAL, '', 'You did not enter a valid number')
ElseIf $i_Result = 1 Then
	MsgBox($MB_SYSTEMMODAL, '', 'Number is odd')
ElseIf $i_Result = 2 Then
	MsgBox($MB_SYSTEMMODAL, '', 'Number is even')
Else
	MsgBox($MB_SYSTEMMODAL, '', 'Could not parse $I_Result')
EndIf
