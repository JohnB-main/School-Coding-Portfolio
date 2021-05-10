from collections import deque


def CalculateSMA(data):
    sma = 0
    for num in data:
        sma += num
    sma = sma / len(data)
    return sma


print("Emter A mew Stock Value, or 'Q' to quit")
decision = input("enter a new stock value")
stocks = deque(maxlen=3)
while (decision != 'Q'):
    newS = float(decision)
    if (len(stocks) < 3):
        stocks.appendleft(newS)
        curSMA = CalculateSMA(stocks)
    else:
        stocks.pop()
        stocks.appendleft(newS)
        curSMA = CalculateSMA(stocks)
    print("Current SMA is: ", curSMA)
    print("")
    print("Emter A mew Stock Value, or 'Q' to quit")
    decision = input("enter a new stock value")