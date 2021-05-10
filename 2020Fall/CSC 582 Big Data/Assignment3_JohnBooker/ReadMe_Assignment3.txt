INCLUDED FILES
	ReadMe_Assignment3.txt - read me for this assignment
	MapperFriends.py - mapper file
	ReducerFriends.py - reducer file 
	RunFriends.sh - shell file for auto running the hadoop program 
							will need to be altered for personal use unless file system is named like mine							
	sample.txt - sample text for input into hadoop program 
	outputFr - output files of hadoop program (dataset requirement)
	ReportScreenshot - screenshot proof of hadoop job success and output

HOW TO RUN PROGRAM IN HADOOP
	Put all the files (RunFriends.sh, MapperFriends, ReducerFriends, and sample.txt) in the same folder
	Sample.txt is your input file, so rename your actual 
		input file, or go in and change the .sh file to your file name when it has "sample.txt"
	Open Terminal
	start hadoop with start-dfs.sh 
	run the .sh file with ./RunFriends.sh
	The program will run if everything is named correctly, and
		produce an output file in a new folder called "outputFr"
	outputFr has two text files, one symbolizing success and the other with the job output
	
	** the .sh file will also create and delete folders (only folders it has added) 
		in your hadoop file system. If you want things in a certain place, you will have
		to change the .sh file. 
