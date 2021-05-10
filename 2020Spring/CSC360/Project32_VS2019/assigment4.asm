TITLE Subroutines Assignment
;John Booker
;Procedures/subroutines practice
;2/18/2020
;CSC 360
;Assignment 4



INCLUDE Irvine32.inc

.data
askNum	BYTE	"Enter a positive, non-zero number: ",0

.code

;sub to get a number from the user
getNum	PROC
	mov		edx,OFFSET askNum	; get the address of the user prompt
	call	WriteString			; display the prompt
	call	ReadInt				; get the number
	ret
getNum	ENDP

;sub to get a number from the user
printNums	PROC
topN:
	call	WriteInt	;write the current value of count (eax)
	call	Crlf		;start next line
	inc		eax			;increase counter in eax
	cmp		eax,ecx		;compare eax to ecx
	jle		topN		;do again if eax is < or == to ecx
	ret
printNums	ENDP

main	PROC			
	;call sub to get num from user
	call	getNum		;getnum's result return in eax
	mov		ecx,eax		;save the n number in a different register	
	mov		eax,1		;set up a counter for the print subroutine 
	INVOKE printNums	
	exit
main	ENDP
END	main
