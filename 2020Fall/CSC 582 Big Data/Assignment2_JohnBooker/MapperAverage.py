#!/usr/bin/env python
import sys

# for each line fed, strip it, extract the key (company), date, and value (stock price)
for line in sys.stdin:
	line = line.strip()
	key, date, value = line.split(',')
	# combine date and price to make the correct output value
	value = date + ',' + value
	# special print for Mapper output
	print("%s\t%s" % (key, value))
