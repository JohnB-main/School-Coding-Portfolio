class CircularQueue:
  """Queue implementation using circularly linked list for storage."""

  #---------------------------------------------------------------------------------
  # nested _Node class
  class _Node:

    def __init__(self, element, next):
      self._element = element
      self._next = next

  # end of _Node class
  #---------------------------------------------------------------------------------

  def __init__(self):
    """Create an empty queue."""
    self._tail = None                   # will represent tail of queue
    self._size = 0                      # number of queue elements

  def __len__(self):
    """Return the number of elements in the queue."""
    return self._size

  def is_empty(self):
    """Return True if the queue is empty."""
    return self._size == 0

  def first(self):
    """Return (but do not remove) the element at the front of the queue.
    Raise Empty exception if the queue is empty.
    """
    if self.is_empty():
      raise Exception('Queue is empty')
    head = self._tail._next
    return head._element

  def dequeue(self):
    """Remove and return the first element of the queue (i.e., FIFO).

    Raise Empty exception if the queue is empty.
    """
    if self.is_empty():
      raise Exception('Queue is empty')
    oldhead = self._tail._next
    if self._size == 1:                   # removing only element
      self._tail = None                   # queue becomes empty
    else:
      self._tail._next = oldhead._next    # bypass the old head
    self._size -= 1
    return oldhead._element

  def enqueue(self, e):
    """Add an element to the back of queue."""
    newest = self._Node(e, None)          # node will be new tail node
    if self.is_empty():
      newest._next = newest               # initialize circularly
    else:
      newest._next = self._tail._next     # new node points to head
      self._tail._next = newest           # old tail points to new node
    self._tail = newest                   # new node becomes the tail
    self._size += 1

  def rotate(self):
    """Rotate front element to the back of the queue."""
    if self._size > 0:
      self._tail = self._tail._next       # old head becomes new tail

if __name__ == '__main__':
  Q = CircularQueue()  # contents: [ ]
  Q.enqueue(7)         # contents: [7]
  Q.enqueue(8)         # contents: [7, 8]
  print(len(Q))        # contents: [7, 8];    outputs 2
  print(Q.dequeue())   # Return 7; output 7
  print(Q.is_empty())  # Return False; output False
  print(Q.dequeue())   # Return 8; output 8
  Q.enqueue(1)         # contents: [1]
  Q.enqueue(2)         # contents: [1,2]
  Q.enqueue(3)         # contents: [1,2,3]
  print(Q.first())     # Return 1; output 1
  Q.rotate()           # contents: [2,3,1]; add 1 to the back of queue
  print(Q.first())     # Return 2; output 2
  print(Q.dequeue())   # Return 2; output 2
  print(Q.dequeue())   # Return 3; output 1
  print(Q.dequeue())   # Return 1; output 1
  print(Q.is_empty())  # Return True; output True