TITLE Add two numbers (AddNums.asm)

; This program adds two 32-bit integers
; Author: E. Styer
; Date 9/5/2002

INCLUDE Irvine32.inc

.data
v	SDWORD 5			;variable with the value five

reslbl	BYTE	"The sum is ",0		;describes the output meaning


.code
main	PROC		

	mov		eax,10		; put value in eax
	add		eax,v			; add value
	mov		edx, OFFSET reslbl		;get address fo the result label
	call WriteString		;display result label
	call	WriteInt		;display result

	exit
main	ENDP
END	main
