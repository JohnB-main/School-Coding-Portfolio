from array_stack import ArrayStack  # call a class from a different file


def reverse_file(filename):
    """Overwrite given file with its contents line-by-line reversed."""
    """ switch last line and the first line """
    S = ArrayStack()

    original = open(filename)

    for line in original:
        S.push(line.rstrip('\n'))  # we will re-insert newlines when writing
    original.close()
    # now we overwrite with contents in LIFO order
    # reopening file overwrites original
    output = open(filename, 'w')

    while not S.isEmpty():
        output.write(S.pop())  # re-insert newline characters
    output.close()


if __name__ == '__main__':
    reverse_file('input1.txt')
