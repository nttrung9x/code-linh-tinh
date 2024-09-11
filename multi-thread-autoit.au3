#include-once
#cs
	AutoIt Threads
	http://github.com/jesobreira/thread.au3
#ce

Func CreateThread($sCallback)
	Local $Handle,$Struct
	$Handle = DllCallbackRegister($sCallback, "int", "ptr")
	$Struct = DllStructCreate("Char[200];int")
	DllStructSetData($Struct, 1, 10)
	Return DllCall("kernel32.dll", "hwnd", "CreateThread", "ptr", 0, "dword", 0, "long", DllCallbackGetPtr($Handle), "ptr", DllStructGetPtr($Struct), "long", 0, "int*", 0)[0]
EndFunc

Func TerminateThread($hWnd)
	Return DllCall("kernel32.dll", "bool", "TerminateThread", "handle", $hWnd, "dword", 0)
EndFunc

$h = CreateThread("foo")

; Opens another one
CreateThread("bar")

; And opens another one, that will just close itself (as an example)
CreateThread("openandclose")

MsgBox(0, "Hey", "I am the main thread" & @CRLF & "Opened thread: " & $h)

TerminateThread($h) ; Terminates one of the threads

Exit ; this is needed, otherwise the main process won't close

Func foo($hThread)
	MsgBox(0, "Hey", "I am a sub thread")
EndFunc

Func bar($hThread)
	MsgBox(0, "Hey", "I am a sub thread (another one)")
EndFunc

Func openandclose($hThread)
	Return TerminateThread($hThread)
	MsgBox(0, "Hey", "This message will not show up")
EndFunc
