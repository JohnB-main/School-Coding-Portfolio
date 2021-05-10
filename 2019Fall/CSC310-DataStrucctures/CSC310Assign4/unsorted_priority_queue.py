from priority_queue_base import PriorityQueueBase
from positional_list import PositionalList

class UnsortedPriorityQueue(PriorityQueueBase): # base class defines _Item
  """A min-oriented priority queue implemented with an unsorted list."""

  #----------------------------- nonpublic behavior -----------------------------
  def _find_min(self):
    """Return Position of item with minimum key."""
    if self.is_empty():               # is_empty inherited from base class
      raise Exception('Priority queue is empty')
    small = self._data.first()
    walk = self._data.after(small)
    while walk is not None:
      if walk.element() < small.element():
        small = walk
      walk = self._data.after(walk)
    return small

  #------------------------------ public behaviors ------------------------------
  def __init__(self):
    """Create a new empty Priority Queue."""
    self._data = PositionalList()

  def __len__(self):
    """Return the number of items in the priority queue."""
    return len(self._data)

  def add(self, key, value):
    """Add a key-value pair."""
    self._data.add_last(self._Item(key, value))

  def min(self):
    """Return but do not remove (k,v) tuple with minimum key.

    Raise Empty exception if empty.
    """
    p = self._find_min()
    item = p.element()
    return (item._key, item._value)

  def remove_min(self):
    """Remove and return (k,v) tuple with minimum key.

    Raise Empty exception if empty.
    """
    p = self._find_min()
    item = self._data.delete(p)
    return (item._key, item._value)

  def __iter__(self):
    """Generate iteration of the map's keys."""
    for item in self._data:
      yield item  # yield the KEY

if __name__ == '__main__':

  U = UnsortedPriorityQueue()  # Create UnsortedPriorityQueue[]
  U.add(5, '4')
  U.add(1, '5')
  U.add(3, '2')
  U.add(2, '3')
  U.add(4, '1')


  print('** Show an initial Unsorted PriorityQueue **')
  for i in U:
    print(i)

  print('\nMinimum key-value pair: ', U.min())  # Print out the item with the minimum key

  U.remove_min()

  print('\n** After running remove_min() **')
  for i in U:
    print(i)

  U.add(1, '6')

  print('\n** After adding a new element (1,6), Show a Unsorted PriorityQueue **')
  for i in U:
    print(i)