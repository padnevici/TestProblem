#include <Array.au3>

Local $aArray_Base[10] = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
_ArrayDisplay($aArray_Base, "1D - Original")

; Insert single item
Local $aArray = $aArray_Base
_ArrayInsert($aArray, 2, "Insert above 2")
_ArrayDisplay($aArray, "1D - Single item")

; Insert delimited string using range array
$aArray = $aArray_Base
Local $aRange[4] = [3, 3, 5, 9]
Local $sFill = "Insert above 3|Insert above 5|Insert above 9"
_ArrayInsert($aArray, $aRange, $sFill)
_ArrayDisplay($aArray, "1D - Delim String")

; Insert 1D array using range string
$aArray = $aArray_Base
Local $aFill[4] = ["Insert above 2", "Insert above 6.1", "Insert above 6.2", "Insert above 7"]
_ArrayInsert($aArray, "2;6;6;7", $aFill)
_ArrayDisplay($aArray, "1D - 1D array")
