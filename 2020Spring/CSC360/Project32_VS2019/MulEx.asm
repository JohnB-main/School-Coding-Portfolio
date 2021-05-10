TITLE Add two numbers (AddNums.asm)

; This program adds two 32-bit integers
; Author: E. Styer
; Date 9/5/2002

INCLUDE Irvine32.inc

.data

.code
main	PROC		
	mov		eax,5
	mov		ebx,6
	imul	ebx
	exit
main	ENDP
END	main
