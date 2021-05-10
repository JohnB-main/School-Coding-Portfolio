from stack import Stack


def baseConverter(decNumber, base):
    digits = "0123456789ABCDEF"

    remstack = Stack()

    while decNumber > 0:
        rem = decNumber % base
        remstack.push(digits[rem])
        decNumber = int(decNumber / base)

    newString = ""
    while not remstack.isEmpty():
        newString += remstack.pop()

    return newString


if __name__ == '__main__':
    print(baseConverter(25, 2))
    print(baseConverter(25, 16))
