# -*- coding: utf-8 -*-
"""
John Booker
2/6/2020
Assignment2
Crazy 8 Server

Example code from class
	Created on Thu Aug 30 13:14:47 2018
	TCP Uppercase Echo server
"""

from socket import *
import threading
import random
from random import Random

# variable for client broadcast
player1 = socket
player2 = socket
p1score = 0
p2score = 0
pile = []
# current top card
top = ""
# hands of each kept by server
hand1 = []
hand2 = []
# player count
Pamount = 0

# variable for base deck for resets and deck to play with
base = ["AH", "2H", "3H", "4H", "5H", "6H", "7H", "8H", "9H", "TH", "JH", "QH", "KH",
        "AS", "2S", "3S", "4S", "5S", "6S", "7S", "8S", "9S", "TH", "JS", "QS", "KS",
        "AC", "2C", "3C", "4C", "5C", "6C", "7C", "8C", "9C", "TH", "JC", "QC", "KC",
        "AD", "2D", "3D", "4D", "5D", "6D", "7D", "8D", "9D", "TH", "JD", "QD", "KD"
        ]

deck = ["AH", "2H", "3H", "4H", "5H", "6H", "7H", "8H", "9H", "TH", "JH", "QH", "KH",
        "AS", "2S", "3S", "4S", "5S", "6S", "7S", "8S", "9S", "TS", "JS", "QS", "KS",
        "AC", "2C", "3C", "4C", "5C", "6C", "7C", "8C", "9C", "TC", "JC", "QC", "KC",
        "AD", "2D", "3D", "4D", "5D", "6D", "7D", "8D", "9D", "TD", "JD", "QD", "KD"
        ]

# variable to tell server to exit
keepRunning = True


# define a function to handle a single client
def client(clientSocket):
    # global variables used for sending and determining
    global player1
    global player2
    global p1score
    global p2score
    global hand1
    global hand2
    global deck
    global Pamount
    global top
    global pile
    hand = []

    while True:
        # set the players (player 1 is always first, then player 2)
        if (Pamount == 1):
            player1 = clientSocket
        if (Pamount == 2):
            player2 = clientSocket
            Pamount += 1
            newGame()

        # which client just played/sent data, and the hand associated with it
        if clientSocket == player1:
            hand = hand1
        elif clientSocket == player2:
            hand = hand2
        # get message from client
        message = clientSocket.recv(3).decode()
        # empty - Assume the client has disconnected
        if len(message) == 0:
            return

        # player played an 8
        if (message[0] == "8"):
            played = message[0:2]
            wanted = "8" + message[2]
            # check if card is in hand
            # not in hand means a replay and invalid
            if (hand.count(played) == 0):
                clientSocket.send("NOO".encode())
                print("INVALID MOVE AS: ", played)
            # valid move
            else:
                # update top
                top = wanted
                # update pile
                pile.append(played)
                # remove the played card from the player's hand
                hand.remove(played)

                # update global
                if player1 == clientSocket:
                    hand1 = hand
                if player2 == clientSocket:
                    hand2 = hand

                # send the message to both clients, to update their top cards and hands
                broadcast(message)

                """winning check"""
                # check if the round has been won
                if (checkWon()):
                    # player would have won
                    clientSocket.send("WON".encode())
                    # calculate scores and send win and loss to corresponding players
                    if player1 == clientSocket:
                        p1score += calcScore(hand2)
                        player2.send("LOS".encode())
                    if player2 == clientSocket:
                        p1score += calcScore(hand1)
                        player1.send("LOS".encode())

                # check is someone has reached 100, then gameover
                if (gameOver()):
                    # the player who ended the game will have won
                    clientSocket.send("WWW".encode())
                    # other player lost
                    if player1 == clientSocket:
                        player2.send("LLL".encode())
                    if player2 == clientSocket:
                        player1.send("LLL".encode())
                    break

                # tell the other player it is their turn, if the round isn't over and the game isn't won
                if ((not checkWon()) & (not gameOver())):
                    if (player1 == clientSocket):
                        hand1 = hand
                        player2.send("TUR".encode())
                    if player2 == clientSocket:
                        hand2 = hand
                        player1.send("TUR".encode())

                # if the game is not over and the round was won, send scores to each player and start a new game
                if (not gameOver()) & (checkWon()):
                    player1.send(("S" + str(p1score).zfill(2)).encode())
                    player2.send(("S" + str(p2score).zfill(2)).encode())
                    # new game/round
                    newGame()
                """end winning check"""

                # tell the other player it is their turn
                if ((not checkWon()) & (not gameOver())):
                    if (player1 == clientSocket):
                        hand1 = hand
                        player2.send("TUR".encode())
                    if player2 == clientSocket:
                        hand2 = hand
                        player1.send("TUR".encode())

        # the player played a card that isn't an eight
        elif (message[0] == "P"):
            played = message[1:3]
            # check if the card is in the player's hand, cheating
            if (hand.count(played) == 0):
                clientSocket.send("NOO".encode())
                print("INVALID MOVE AS: ", played)
            # if the suit or number matches
            elif ((top[1] == played[1]) | (top[0] == played[0])):
                # update top
                top = played
                # update pile
                pile.append(played)
                # remove the played card from the player's hand
                hand.remove(played)
                # send the message to both clients, to update their top cards and hands
                broadcast("T" + played)

                # update global
                if player1 == clientSocket:
                    hand1 = hand
                if player2 == clientSocket:
                    hand2 = hand

                """winning check"""
                # check if the round has been won
                if (checkWon()):
                    # player would have won
                    clientSocket.send("WON".encode())
                    # calculate scores and send win and loss to corresponsind players
                    if player1 == clientSocket:
                        p1score += calcScore(hand2)
                        player2.send("LOS".encode())
                    if player2 == clientSocket:
                        hand2 = hand
                        p1score += calcScore(hand1)
                        player1.send("LOS".encode())

                # check is someone has reached 100, then gameover
                if (gameOver()):
                    # the player who ended the game will have won
                    clientSocket.send("WWW".encode())
                    if player1 == clientSocket:
                        player2.send("LLL".encode())
                    if player2 == clientSocket:
                        player1.send("LLL".encode())
                    break

                # tell the other player it is their turn, if the round isnt over and the game isn't won
                if ((not checkWon()) & (not gameOver())):
                    if (player1 == clientSocket):
                        hand1 = hand
                        player2.send("TUR".encode())
                    if player2 == clientSocket:
                        hand2 = hand
                        player1.send("TUR".encode())

                # if the game is not over and the round was won, send scores to each player and start a new game
                if (not gameOver()) & (checkWon()):
                    player1.send(("S" + str(p1score).zfill(2)).encode())
                    player2.send(("S" + str(p2score).zfill(2)).encode())
                    # new game/round
                    newGame()
                """end winning check"""


        # player asked to draw a card
        elif (message == "DRA"):
            # card from top of deck
            card = deck.pop()
            # add to local hand
            hand.append(card)

            # check to see if the deck is empty; if empty, refill it with everything but the top card of the discard pile
            if (len(deck) == 0):
                print("DECK OUT OF CARDS")
                # remove top card from pile
                print("top is", top)
                pile.remove(top)
                # copy the rest of the pile into the deck
                print("pile is", pile)
                print("deck is", deck)
                deck = pile[:]
                # clear the pile
                pile.clear()
                # shuffle the deck
                random.shuffle(deck)
                print("shuffled deck is:", deck)
                # put back the top card into the pile again
                pile.append(top)
                print("top is", top)
                print("pile is", pile)

            # send to player who asked for it
            clientSocket.send(("D" + card).encode())
            # update server global hands
            if player1 == clientSocket:
                hand1 = hand
            if player2 == clientSocket:
                hand2 = hand

            # same player's turn again
            clientSocket.send("TUR".encode())

    # debugging output
    # print("message is: ", message)


# function to handle the main server socket accept loop
def listenLoop(serverPort):
    # create the socket
    serverSocket = socket(AF_INET, SOCK_STREAM)
    serverSocket.bind(('', serverPort))

    # start the keyboard input thread
    # be ready for clients
    serverSocket.listen(1)

    print('The server is ready to receive')
    while keepRunning:
        global Pamount
        # get a connection from a client
        connectionSocket, addr = serverSocket.accept()

        # start up a thread for that client
        Pamount += 1
        # differentiate the clients
        if (Pamount == 1):
            cl1 = threading.Thread(target=client, args=(connectionSocket,), daemon=True)
            cl1.start()


        elif (Pamount == 2):
            cl2 = threading.Thread(target=client, args=(connectionSocket,), daemon=True)
            cl2.start()


# sending something to both players
def broadcast(toall):
    player1.send(toall.encode())
    player2.send(toall.encode())


# check if a round was won
def checkWon():
    global hand1
    global hand2
    if (len(hand1) == 0) | (len(hand2) == 0):
        return True
    return False


# calculate the score of a hand and return it
def calcScore(hand):
    score = 0
    for card in hand:
        value = card[0]
        if value == "A":
            score += 1
        elif value == "2":
            score += 2
        elif value == "3":
            score += 3
        elif value == "4":
            score += 4
        elif value == "5":
            score += 5
        elif value == "6":
            score += 6
        elif value == "7":
            score += 7
        elif value == "8":
            score += 50
        elif value == "9":
            score += 9
        elif value == "T":
            score += 10
        elif value == "J":
            score += 10
        elif value == "Q":
            score += 10
        elif value == "K":
            score += 10
    return score


# check if game is over; someone made 100 or more score
def gameOver():
    global p1score
    global p2score
    return ((p1score >= 100) | (p2score >= 100))


# new game setup
def newGame():
    # reset all the values
    global player2
    global player1
    global hand1
    global hand2
    global deck
    global Pamount
    global top
    global base
    global pile

    # clear hands
    hand1.clear()
    hand2.clear()
    # reset the deck
    deck = base[:]
    top = ""
    pile = []

    # shuffle the deck
    random.shuffle(deck)
    # deal cards to players
    for x in range(7):
        card = deck.pop()
        hand1.append(card)
        # card the player drew
        player1.send(("D" + card).encode())
    for x in range(7):
        card = deck.pop()
        hand2.append(card)
        player2.send(("D" + card).encode())

    # print(hand1)		#hand checking
    # print(hand2)		#hand checking

    # reshuffle the deck as long as the top card flipped over would be an 8
    while (deck[len(deck) - 1][0] == "8"):
        random.shuffle(deck)
    # current top card
    top = deck.pop()
    # creating play pile
    pile.append(top)
    # send top to both
    broadcast("T" + top)
    # player1 starts game with their turn
    player1.send("TUR".encode())


# serverPort = 7000, should be a safe port to use
serverPort = 7000

# create the main socket listener thread with the port number
sthread = threading.Thread(target=listenLoop, args=(serverPort,), daemon=True)
sthread.start()

# wait for input (this includes control-C)

input('Type anything to exit\n')

# exit (other threads stop since they are daemon threads)
