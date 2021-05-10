TITLE Add two numbers (AddNums.asm)

; This program adds two 32-bit integers
; Author: E. Styer
; Date 9/5/2002

INCLUDE Irvine32.inc

.data
pmt	BYTE	"Enter a number: ",0
lbl	BYTE	"The sum is ",0
.code
main	PROC
; get the first number
	mov	edx,offset pmt		; prepare to display prompt
	call	WriteString		; display prompt (addr in EDX)
	call	ReadInt			; get the first number (in EAX)
	mov	ebx,eax			; copy the number to save it

; get the second number and add them
	mov	edx,offset pmt		; prepare to display prompt
	call	WriteString		; display prompt
	call	ReadInt			; get the second number
	add	eax,ebx			; add the numbers

; display the result
	mov	edx,offset lbl		; identify the result
	call	WriteString
	call	WriteDec		; display result (value in EAX)
	call	CrLf
	exit
main	ENDP
END	main
