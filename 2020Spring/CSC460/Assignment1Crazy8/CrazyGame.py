import random
from random import Random

deck = ["AH", "2H", "3H", "4H", "5H", "6H", "7H", "8H", "9H", "JH", "QH", "KH",
        "AS", "2S", "3S", "4S", "5S", "6S", "7S", "8S", "9S", "JS", "QS", "KS",
        "AC", "2C", "3C", "4C", "5C", "6C", "7C", "8C", "9C", "JC", "QC", "KC",
        "AD", "2D", "3D", "4D", "5D", "6D", "7D", "8D", "9D", "JD", "QD", "KD",
        ]

# print(deck.pop())             #removes top card
# random.shuffle(deck)          #shuffles  deck
hand1 = []
hand2 = []

# setup
for x in range(5):
    hand1.append(deck.pop())
for x in range(5):
    hand2.append(deck.pop())

print(hand1)
print(hand2)

top = deck[deck.__len__() - 1]
print(top)

print("Select a card to play, player 1")
played = False
while (played == False):
    choice = input("A Number for a card in your hand, D for draw")

    if (choice == "D"):
        print("You drew a ", top)
        hand1.append(deck.pop())
        played=True
        break;
    if (int(choice)):
        spot = int(choice) - 1
        card = hand1[spot]
        if(card[1]==top[1]):
            hand1.pop(spot)
            print("Your new hand is")
            print(hand1)
            played = True
        elif(card[1]!=top[1]):
            print("Card is invalid, play a different card.")


