#!/usr/bin/env python
import sys

# for each line fed, strip it, extract the key (user), and friends; then print ourput for mapper
for line in sys.stdin:
    line = line.strip()
    key, friends = line.split(",")
    print("%s,%s" % (key, friends)) # do not add spaces or that will mess with the splitting in the Reducer

# TESTING, Kept for future referece/use
# test = "101,102 103 104 105 106"
# test = test.strip()
# print(test)
# test2 = "102,101 106"
# key, friends = test.split(",")
# # key2, friends2 = test2.split(",")
# print(key)
# print(friends)
#
# friendList = set()
# # friendList2 = set()
# for item in friends.split(" "):
#     friendList.add(item)
# print(friendList)
# print(len(friendList))
#
# for item in friends2.split(" "):
#     friendList2.add(item)
# print(friendList2)
#
# users = []
# users.append(key)
# users.append(key2)
# listFriendslist = []
# listFriendslist.append(friendList)
# listFriendslist.append(friendList2)
#
# for i in range(len(users) - 1):
#     j = i + 1
#     # print(users[i], ", ", users[j], " ", listFriendslist[i].intersection(listFriendslist[j]))
#     print("%s, %s %s" % (users[i], users[j], listFriendslist[i].intersection(listFriendslist[j])))
