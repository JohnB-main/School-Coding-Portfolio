from collections import deque


# function to caclulate a running average of the data
# get sum of numbers in data and return average
def CalculateSMA(data):
    sma = 0
    for num in data:
        sma += num
    sma = sma / len(data)
    return sma


# get input from user, Q quits
# input is the newest stock
print("Emter A mew Stock Value, or 'Q' to quit")
decision = input("enter a new stock value")
# queue as a stock 
stocks = deque(maxlen=3)
while (decision != 'Q'):
    newS = float(decision)
    # if stock is not full, add newest stock to the left of stocks; calculate current SMA
    if (len(stocks) < 3):
        stocks.appendleft(newS)
        curSMA = CalculateSMA(stocks)
    # if stocks is full, remove oldest; calculate SMA
    else:
        stocks.pop()
        stocks.appendleft(newS)
        curSMA = CalculateSMA(stocks)
    # print resulting SMA and ask user for next input or to quit
    print("Current SMA is: ", curSMA)
    print("")  # spacing
    print("Emter A mew Stock Value, or 'Q' to quit")
    decision = input("enter a new stock value")
