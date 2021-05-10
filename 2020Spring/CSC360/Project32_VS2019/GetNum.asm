TITLE Add 50 to a Number (assignment2.asm)

; This progam takes an input number from a user and adds 50, then returns the new number
; Author: John Booker
; Date 2/4/2002

INCLUDE Irvine32.inc

.data
reslbl	BYTE	"The sum is ",0		;Output string for the result
prompt BYTE "Enter a number:", 0	;prompt for getting a number from the user

.code
main	PROC		

;get num from user
	mov		edx, OFFSET prompt		;get address for the result label
	call	WriteString				;display prompt
	call	ReadDec					;get the Int, which will be put into eax	

	mov		edx, OFFSET reslbl		;get address for the result label
	call	WriteString				;display result label

	;add some numbers
	add		eax,50					;add them
	
	call	WriteDec				;display the result when positive without +
	

	exit
main	ENDP
END	main
