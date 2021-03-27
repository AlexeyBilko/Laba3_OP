using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_cSharp
{
    public class MyQueue<T>
    {
        T[] array;
        int size;
        int capacity;

        int head;
        int tail;

        public int Count
        {
            get
            {
                return this.size;
            }
        }

        public MyQueue()
        {
            capacity = 10;
            array = new T[10];
            size = 0;
            head = -1;
            tail = 0;
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
                Array.Copy(array, 0, newQueue, 0, array.Length);
                array = newQueue;
                capacity *= 2;
            }
            size++;
            array[tail++ % capacity] = newElement;
        }

        public T Dequeue()
        {
            if (this.size == 0)
            {
                throw new InvalidOperationException();
            }
            size--;
            return array[++head % capacity];
        }
    }
}
