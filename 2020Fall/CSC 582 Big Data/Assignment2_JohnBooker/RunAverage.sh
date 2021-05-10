#! /bin/sh

hadoop fs -mkdir /user/johnb/inputRA

hadoop fs -put /home/johnb/sample.txt /user/johnb/inputRA/

hadoop jar /opt/hadoop/share/hadoop/tools/lib/hadoop-streaming-3.2.1.jar -file /home/johnb/MapperAverage.py -mapper MapperAverage.py -file /home/johnb/ReducerAverage.py -reducer ReducerAverage.py -input /user/johnb/inputRA/* -output outputRA

hadoop fs -cat outputRA/part-00000

hadoop fs -get outputRA outputRA

hadoop fs -rm -r outputRA

hadoop fs -rm -r /user/johnb/inputRA
