
Func PathJoin($vVar1 = "", $vVar2 = "", $vVar3 = "", $vVar4 = "", $vVar5 = "", _
              $vVar6 = "", $vVar7 = "", $vVar8 = "", $vVar9 = "", $vVar10 = "", _
              $vVar11 = "", $vVar12 = "", $vVar13 = "", $vVar14 = "", $vVar15 = "", _
              $vVar16 = "", $vVar17 = "", $vVar18 = "", $vVar19 = "")
    Local $path = ""
    For $i = 1 To @NumParams
        Local $part = Eval("vVar" & $i)
        If $part = "" Then ContinueLoop
        If $path <> "" And StringRight($path, 1) <> "\" Then
            $path &= "\"
        EndIf
        If StringLeft($part, 1) = "\" Then
            $part = StringTrimLeft($part, 1)
        EndIf
        $path &= $part
    Next
    Return $path
EndFunc

$proFilex86 = @ProgramFilesDir
$proFilex64 = StringReplace($proFilex86,' (x86)','')

$FullPath = PathJoin($proFilex86,'CaptCha69.Com','MMO69.Com','@HKVN9X.au3')

If Not FileExists($FullPath) Then
   $FullPath = PathJoin($proFilex64,'CaptCha69.Com','MMO69.Com','@HKVN9X.au3')
EndIf

ConsoleWrite($FullPath & @CRLF) 
; C:\Program Files (x86)\CaptCha69.Com\MMO69.Com\@HKVN9X.au3
; C:\Program Files\CaptCha69.Com\MMO69.Com\@HKVN9X.au3
