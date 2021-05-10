#!/usr/bin/env python
import sys

# lists for holding users (users), and holding lists of all friends for each user (FriendsList)
users = []
FriendsList = []

for line in sys.stdin:
    line = line.strip()
    # split user from friends
	user, friends = line.split(',')
	# friendList is a set so we can user the intersection function later; only {} creates a dictionary
    friendList = set()
	# add all friends from input to friendList 
    for item in friends.split(" "):
        friendList.add(item)
	# add the user to the user list and friendList to the FriendsList
	# it is important to keep the order of the two lists, so their indexes match up with one another
    users.append(user)
    FriendsList.append(friendList)

# iterate through all the friends to find common friends 
# must iterate through all possible combinations to accurately find all friends for each pair of users 
# i, the first index, goes to one before the end user
for i in range(len(users) - 1):
	# j, the second index, is one larger than i and goes to the end of the list 
    for j in range(i+1, len(users)):
		# variable to define common friends from intersection (common) friends of 2 users 
        common = FriendsList[i].intersection(FriendsList[j])
		# print statement to make it look better, otherwise no friends is "set()" because of the definition
        if len(common) == 0:
            print("%s, %s %s" % (users[i], users[j], "{}"))
        else:
            print("%s, %s %s" % (users[i], users[j], common))
