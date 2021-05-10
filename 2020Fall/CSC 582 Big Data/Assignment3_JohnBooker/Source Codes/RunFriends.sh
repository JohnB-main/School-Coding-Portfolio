#! /bin/sh

hadoop fs -mkdir /user/johnb/inputFr

hadoop fs -put /home/johnb/sample.txt /user/johnb/inputFr/

hadoop jar /opt/hadoop/share/hadoop/tools/lib/hadoop-streaming-3.2.1.jar -file /home/johnb/MapperFriends.py -mapper MapperFriends.py -file /home/johnb/ReducerFriends.py -reducer ReducerFriends.py -input /user/johnb/inputFr/* -output outputFr

hadoop fs -cat outputFr/part-00000

hadoop fs -get outputFr outputFr

hadoop fs -rm -r outputFr

hadoop fs -rm -r /user/johnb/inputFr
