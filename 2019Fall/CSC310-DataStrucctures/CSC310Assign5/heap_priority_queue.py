list = []
from priority_queue_base import PriorityQueueBase


# Classes from in Class examples
class HeapPriorityQueue(PriorityQueueBase):  # base class defines _Item
    """A min-oriented priority queue implemented with a binary heap."""

    # ------------------------------ nonpublic behaviors ------------------------------
    def _parent(self, j):
        return (j - 1) // 2

    def _left(self, j):
        return 2 * j + 1

    def _right(self, j):
        return 2 * j + 2

    def _has_left(self, j):
        return self._left(j) < len(self._data)  # index beyond end of list?

    def _has_right(self, j):
        return self._right(j) < len(self._data)  # index beyond end of list?

    def _swap(self, i, j):
        """Swap the elements at indices i and j of array."""
        self._data[i], self._data[j] = self._data[j], self._data[i]

    # Change sign to greater than
    def _upheap(self, j):
        parent = self._parent(j)
        if j > 0 and self._data[j] > self._data[parent]:
            self._swap(j, parent)
            self._upheap(parent)  # recur at position of parent

    # Change sign to greater than
    def _downheap(self, j):
        if self._has_left(j):
            left = self._left(j)
            small_child = left  # although right may be smaller
            if self._has_right(j):
                right = self._right(j)
                if self._data[right] > self._data[left]:
                    small_child = right
            if self._data[small_child] > self._data[j]:
                self._swap(j, small_child)
                self._downheap(small_child)  # recur at position of small child

    # ------------------------------ public behaviors ------------------------------
    def __init__(self):
        """Create a new empty Priority Queue."""
        self._data = []

    def __len__(self):
        """Return the number of items in the priority queue."""
        return len(self._data)

    def add(self, key, value):
        """Add a key-value pair to the priority queue."""
        self._data.append(self._Item(key, value))
        self._upheap(len(self._data) - 1)  # upheap newly added position

    def min(self):
        """Return but do not remove (k,v) tuple with minimum key.

        Raise Empty exception if empty.
        """
        if self.is_empty():
            raise Exception('Priority queue is empty.')
        item = self._data[0]
        return (item._key, item._value)

    def remove_max(self):
        """Remove and return (k,v) tuple with minimum key.

        Raise Empty exception if empty.
        """
        if self.is_empty():
            raise Exception('Priority queue is empty.')
        self._swap(0, len(self._data) - 1)  # put minimum item at the end
        item = self._data.pop()  # and remove it from the list;
        self._downheap(0)  # then fix new root
        return (item._key, item._value)

    def __iter__(self):
        """Generate iteration of the map's keys."""
        for item in self._data:
            yield item  # yield the KEY

    def InPlaceHeapSort(self, sorted, a, b):
        if a >= b:
            return
        pivot = sorted[b]
        left = a
        right = b - 1
        while left <= right:
            while left <= right and sorted[left] < pivot:
                left += 1
            while left <= right and pivot < sorted[right]:
                right -= 1
            if left <= right:
                sorted[left], sorted[right] = sorted[right], sorted[left]
                left, right = left + 1, right - 1
        sorted[left], sorted[b] = sorted[b], sorted[left]

        # recursive calls
        self.InPlaceHeapSort(sorted, a, left - 1)
        self.InPlaceHeapSort(sorted, left + 1, b)


############################################# QUESTION 1 #############################################
print("Question 1:")
if __name__ == '__main__':
    H = HeapPriorityQueue()  # Create HeapPriorityQueue[]
    H.add(9, '9')
    H.add(7, '7')
    H.add(5, '5')
    H.add(2, '2')
    H.add(6, '6')
    H.add(4, '4')

    for i in range(len(H)):
        item = H._data[i]
        list.append(item._key)
    print("Keys Before In Place Sort:")
    print(list)
    print("Keys After In Place Sort:")
    H.InPlaceHeapSort(list, 0, list.__len__() - 1)
    print(list)
    print()
    print('** Print Using Remove_Max **')
    for i in range(len(H)):
        print(H.remove_max())

############################################# QUESTION 2 #############################################
    print()
    print()
    print("Question 2:")

