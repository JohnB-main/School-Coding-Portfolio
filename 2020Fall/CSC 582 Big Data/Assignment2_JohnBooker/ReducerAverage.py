#!/usr/bin/env python
import sys
from operator import itemgetter
from collections import deque
import datetime

# calculate the SMA for the data input 
def CalculateSMA(data):
    sma = 0
	# for each num in data, extract the price 
    for num in data:
        foo, price = num.split(',')
        price = float(price)
        sma += price
    sma = sma / len(data)
    return sma

# get the time of the input data 
def GetDatetime(old):
    old, foo = old.split(',')
	# get each piece of the date 
    year, month, day = old.split('-')
	# make an actual date object from the date pieces 
    result = datetime.datetime(int(year), int(month), int(day))
    return result

# define variables
stocks = deque(maxlen=3)
curSMA = 0
# Keys used for checking to see if the company has changed
OldKey = ""
Rkey = ""
for line in sys.stdin:
    line = line.strip()    
    Rkey, Rvalue = line.split('\t', 1)
	# set key for the first time 
    if (OldKey == ""):
        OldKey = Rkey
	# new company stock 
    if (OldKey != Rkey):
		# get the date of the newest stock 
        useDate, foo = stocks[0].split(',')
		# print the company, newest stock, and SMA of stocks 
        print('%s,%s,%.2f' % (OldKey, useDate, curSMA))  # print out the result to stream
		# change oldKey to match new key, meaning to calc stocks for a new company
        OldKey = Rkey
        stocks = deque(maxlen=3) # reset queue
	# if stocks is empty, just add the value 
    if (len(stocks) == 0):
        stocks.appendleft(Rvalue)
        # print("Stocks after first", stocks)
        # print(stocks)
	# if stocks is not full or zero, insert it at correct position (left -> right = new -> old)
    elif (len(stocks) < 3):
        # tempt copy so one can iterate and change without error
        tempStocks = stocks.copy()
        for item in tempStocks:
			# safety break in case
            if(len(stocks) ==3):
                break
			# if new stock is newee than another stock 
            if (GetDatetime(Rvalue) > GetDatetime(item)):
                # print("newer less")
				# insert at older stock, old stock shifts right 
                stocks.insert(stocks.index(item), Rvalue)
                # print("newer less stocks", stocks)
                break
			# new stock is oldest record
			# safety break 
            if(len(stocks) ==3):
                break
            # print("old less")
			# put oldest stock at the end 
            stocks.append(Rvalue)
            # print("old less stocks", stocks)
    # stocks is full and one must be removed
    else:
        for item in stocks:
			# follows same process as if stocks less than 3, but this time removes oldest stock before adding a new one 
            if (GetDatetime(Rvalue) > GetDatetime(item)):
                # print("newer full")
				# define position since the stock to be replaced may not exist in the queue anymore
                position = stocks.index(item)
                # print("POS IS", position)
                stocks.pop()
                # print("stocks after pop", stocks)
                stocks.insert(position, Rvalue)
                # print("stocks after insert", stocks)
                break
            # else:
            # new is oldest record
            # print("Too Old")
    # print(stocks)
	# calculate SMA for that company
    curSMA = CalculateSMA(stocks)
useDate, foo = stocks[0].split(',')
# output the last copmany, date, and SMA 
print('%s,%s,%.2f' % (Rkey, useDate, curSMA))  # print out the result to stream

