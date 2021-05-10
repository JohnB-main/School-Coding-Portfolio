INCLUDED FILES
	ReadMe_Assignment2.txt - read me for this assignment
	Assignment2RunningAverage.py - The first part of the assignment, just running average with inputs, window size 3
	MapperAverage.py - mapper file for haddop running average of window size 3
	ReducerAverage.py - reducer file 
	RunAverage.sh - shell file for auto running the hadoop program 
							will need to be altered for personal use unless file system is named like mine							
	sample.txt - sample text for input into hadoop program 
	outputRA - output file of hadoop program (dataset requirement)
	screenshots - screenshot proof of programs running successfully
	
HOW TO RUN THE INPUT RUNNING AVERAGE (PART 1 OF ASSIGNMENT)
	Run the file in a python compiler
	input the stocks one at a time, input 'Q' without the quotes to quit the program
	The program will output your Simple Running Average each time an input is made

HOW TO RUN PROGRAM IN HADOOP
	Put all the files (RunAverage.sh, MapperAverage, ReducerAverage, and sample.txt) in the same folder
	Sample.txt is your input file, so rename your actual 
		input file, or go in and change the .sh file to your file name when it has "sample.txt"
	Open Terminal
	start hadoop with start-dfs.sh 
	run the .sh file with ./RunAverage.sh
	The program will run if everything is named correctly, and
		produce an output file in a new folder called "outputRA"
	outputRA has two text files, one symbolizing success and the other with the job output
	
	** the .sh file will also create and delete folders (only folders it has added) 
		in your hadoop file system. If you want things in a certain place, you will have
		to change the .sh file. 
