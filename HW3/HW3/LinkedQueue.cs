using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    public class LinkedQueue<T> : QueueInterface<T>
    {
        private Node<T> front;
        private Node<T> rear;

        public LinkedQueue()
        {
            front = null;
            rear = null;
        }
        public T Push(T element)
        {
            if(element == null)
            {
                throw new NullReferenceException();
            }

            if (IsEmpty())
            {
                Node<T> tmp = new Node<T>(element, null);
                rear = front;
                front = tmp;
            }
            else
            {
                //General Case
                Node<T> tmp = new Node<T>(element, null);
                rear.next = tmp;
                rear = tmp; 
            }
            return element;
        }

        public T Pop()
        {
            T tmp;
            if (IsEmpty())
            {
                throw new QueueUnderflowException("The queue was empty when pop was invoked.");
            }
            else if(front == rear)
            { // one item in queue
                tmp = front.data;
                front = null;
                rear = null;
            }
            else
            {
                //General case
                tmp = front.data;
                front = null;
                rear = null;
            }

            return tmp;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException("The queue was empty when peek was invoked.");
            }
            return front.data;
        }

        public bool IsEmpty()
        {
            if(front == null && rear == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
