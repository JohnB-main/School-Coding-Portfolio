# -*- coding: utf-8 -*-
"""
John Booker
2/6/2020
Assignment2
Crazy 8 Client

Example code from class
    Created on Thu Aug 30 13:00:56 2018
    TCP Client Program
"""

from socket import *

# get the ip address for the server
serverName = input('Enter server address or domain name: ')
#serverName = "157.89.73.48"
serverPort = 7000

clientSocket = socket(AF_INET, SOCK_STREAM)
clientSocket.connect((serverName, serverPort))

# global variables
hand = []
top = ""
playing = ""


# print the hand of the player with indexes
def printHand():
    global hand
    for i in range(hand.__len__()):
        print("%3d" % (i), end='')
    print()
    for item in hand:
        print("%3s" % (item), end='')
    print()


# loop for sending/listening
while True:
    print()  # spacing
    # get message from server
    # only receive 3 since that is what my code lengths are based on
    sr = clientSocket.recv(3).decode()  # sr for server response

    # draw a card
    if (sr[0] == "D"):
        # card is in 'D3C' format, so only need last two characters
        hand.append(sr[1:3])
        sr = ""
        print("YOU DREW A CARD, YOUR HAND IS:")
        printHand()

    # your turn to play
    elif ((sr == "TUR") | (sr == "NOO")):
        print("IT IS YOUR TURN...")
        if (sr == "NOO"):
            print("INVALID MOVE, TRY AGAIN")
        # show hand
        print("YOUR HAND IS:")
        printHand()
        # show top card
        print("TOP CARD:", top)
        # get choice from player
        choice = input(
            "Play a card by picking its corresponding number from your hand, or type 'draw' to draw a card, or 'QUIT' to quit").upper()
        # player quits
        if (choice == "QUIT"):
            break

        # player draws
        if (choice == "DRAW"):
            clientSocket.send("DRA".encode())

        # player doesn't draw, so player plays a card
        if choice != "DRAW":
            # card at chosen index
            playing = hand[int(choice)]
            suit = ""
            sr = ""
            # player must pick suit, is playing an eight
            if (playing[0] == "8"):
                # while loop in case incorrect input
                while (suit == ""):
                    suit = input(
                        "Pick your suit; type 'D' for diamond, 'C' for clubs, 'S' for spades, and 'H' for hearts")
                    # capitalize the input character
                    suit = suit.upper()
                    if ((suit == "D") | (suit == "C") | (suit == "S") | (suit == "H")):
                        clientSocket.send((playing + suit).encode())
                    else:
                        suit = ""
            else:
                clientSocket.send(("P" + playing).encode())

    # top card has changed
    elif (sr[0] == "T"):
        # change top
        top = sr[1:3]
        print("TOP CARD: ", top)
        # if the card played was yours, remove it from your hand
        if (hand.__contains__(top) > 0):
            hand.remove(top)
            print("YOU PLAYED A CARD, YOUR HAND IS NOW:")
            printHand()
        # reset sr
        sr = ""

    # an 8 was played
    # code is '8(actual suit)(desired suit)
    elif (sr[0] == "8"):
        # new top card
        top = "8" + sr[2]
        # if the card played was yours, remove it from your hand
        if (hand.__contains__(sr[0:2])):
            hand.remove(sr[0:2])
            print("YOU PLAYED A CARD, YOUR HAND IS NOW:")
            printHand()
        sr = ""

    # round lost
    elif (sr == "LOS"):
        print()
        print("YOU LOST THE ROUND... STARTING NEXT ROUND")
        hand.clear()
        sr = ""

    # round won
    elif (sr == "WON"):
        print()
        print("YOU WON THE ROUND!!! ... STARTING NEXT ROUND")
        hand.clear()
        sr = ""

    # score to be read
    elif sr[0] == "S":
        print("********** YOUR SCORE IS", sr[1:3], "**********")

    # game lost
    elif (sr == "LLL"):
        print()
        print("YOU LOST THE GAME... GAMEOVER")
        break

    # game won
    elif (sr == "WWW"):
        print()
        print("CONGRATS, YOU WON THE GAME!!!")
        break

# user quit, close the socket
clientSocket.close()
