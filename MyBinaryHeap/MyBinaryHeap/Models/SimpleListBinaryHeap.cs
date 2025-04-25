using System.Collections;

namespace MyBinaryHeap.Models
{
    public class SimpleListBinaryHeap<T> : IEnumerable
        where T : IComparable
    {
        private List<T> items;
        public int Count => items.Count;

        public SimpleListBinaryHeap()
        {
            items = new List<T>();
        }

        public SimpleListBinaryHeap(List<T> items) : this()
        {
            this.items.AddRange(items);
            for (int i = Count; i >= 0; i--)
            {
                Sort(i);
            }
        }

        public T? Peek()
        {
            if (Count > 0)
            {
                return items[0];
            }
            return default(T);
        }

        public void Push(T item)
        {
            items.Add(item);
            int currentIndex = Count - 1;
            int parentIndex = GetParentIndex(currentIndex);

            while (currentIndex > 0 && items[currentIndex].CompareTo(items[parentIndex]) > 0)
            {
                Swap(currentIndex, parentIndex);
                currentIndex = parentIndex;
                parentIndex = GetParentIndex(currentIndex);
            }
        }

        private int GetParentIndex(int currentIndex)
        {
            return (currentIndex - 1) / 2;
        }

        private void Swap(int currentIndex, int parentIndex)
        {
            T temp = items[currentIndex];
            items[currentIndex] = items[parentIndex];
            items[parentIndex] = temp;

        }

        public T Pop()
        {
            T result = default(T);
            if (Count > 0)
            {
                int index = 0;
                result = items[index];
                items[index] = items[Count - 1];
                items.RemoveAt(Count - 1);
                Sort(index);
            }
            return result;
        }

        private void Sort(int currentIndex)
        {
            int maxIndex;
            int leftIndex;
            int rightIndex;
            while (currentIndex < Count)
            {
                maxIndex = currentIndex;
                leftIndex = currentIndex * 2 + 1;
                rightIndex = currentIndex * 2 + 2;
                if (leftIndex < Count && items[leftIndex].CompareTo(items[maxIndex]) > 0)
                {
                    maxIndex = leftIndex;
                }
                if (rightIndex < Count && items[rightIndex].CompareTo(items[maxIndex]) > 0)
                {
                    maxIndex = rightIndex;
                }
                if (currentIndex == maxIndex)
                {
                    break;
                }
                Swap(currentIndex, maxIndex);
                currentIndex = maxIndex;
            }
        }

        public IEnumerator GetEnumerator()
        {
            while (Count > 0)
            {
                yield return Pop();
            }
        }
    }
}
