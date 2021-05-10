TITLE Fibonacci Numbers
;John Booker
;Fibonacci number calculation under 1000
;2/11/2020
;CSC 360
;Assignment 3



INCLUDE Irvine32.inc

.data

.code
main	PROC		
		mov		ebx,1		;the first fibonacci
		mov		eax,1		;this will be the next fibonacci
		mov		edx,0		;this is a place holder for the fib before eax; the previous eax
		call	WriteDec	;writes first fib number (the first 1, not writting ebx)
		call	Crlf		;clear line
		

;loop to get next and print next fib
fibloop:
		call	WriteDec	;writes fib number
		call	Crlf		;clear line

		mov		edx,eax		;put the latest fib into a holder (edx for duplicate)
		add		eax,ebx		;add the previous and current fib, to get next fib
		mov		ebx, edx	;move the duplicate to ebx, to be the second to last fib number; since eax is the last fib number

		cmp		eax, 1000	;checks if fib num is less than 1000
		jl		fibloop		;jump to fib loop
	exit
main	ENDP
END	main
