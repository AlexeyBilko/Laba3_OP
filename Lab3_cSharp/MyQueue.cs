using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_cSharp
{
    public class MyQueue<T>
    {
        private T[] _array;
        private int size;
        private const int defaultCapacity = 15;
        private int capacity;
        private int head;
        private int tail;

        public MyQueue()
        {
            capacity = defaultCapacity;
            this._array = new T[defaultCapacity];
            this.size = 0;
            this.head = -1;
            this.tail = 0;
        }

        public bool isEmpty()
        {
            return size == 0;
        }

        public void Enqueue(T newElement)
        {
            if (this.size == this.capacity)
            {
                T[] newQueue = new T[2 * capacity];
                Array.Copy(_array, 0, newQueue, 0, _array.Length);
                _array = newQueue;
                capacity *= 2;
            }
            size++;
            _array[tail++ % capacity] = newElement;
        }

        public T Dequeue()
        {
            if (this.size == 0)
            {
                throw new InvalidOperationException();
            }
            size--;
            return _array[++head % capacity];
        }


        public int Count
        {
            get
            {
                return this.size;
            }
        }
    }
}
