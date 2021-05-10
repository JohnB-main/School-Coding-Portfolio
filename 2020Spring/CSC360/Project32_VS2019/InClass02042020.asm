TITLE 



INCLUDE Irvine32.inc

.data
a1		DWORD	3, 5, 7, 9, 11, 13, 15
space	BYTE	" "

.code
main	PROC		

;loop example

		mov ebx, 0

iloop:
		mov ecx, 0

oloop:
		mov		eax,ebx
		call	WriteInt
		mov		edx, OFFSET space
		call	WriteString
		mov		eax,ecx
		call	WriteInt
		call	CrLf

;end inner loop
		inc		ecx
		cmp		ecx, 4
		jl		iloop

;end outter loop
		inc		ebx
		cmp		ebx,3
		jl		oloop




	exit
main	ENDP
END	main
