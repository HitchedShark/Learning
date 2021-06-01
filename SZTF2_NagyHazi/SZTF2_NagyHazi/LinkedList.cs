using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SZTF2_NagyHazi
{
    delegate void ListDisplay(BatmanArsenal arsenal, int position);
    class LinkedList<T> : IEnumerable<T> where T : IArsenal
    {
        private ListNode<T> head;

        public void Insert(T data)
        {
            ListNode<T> toInsert = new ListNode<T>();
            toInsert.data = data;
            ListNode<T> current = head;
            ListNode<T> prev = null;

            while (current != null && current.data.Value > toInsert.data.Value)
            {
                prev = current;
                current = current.next;
            }
            if (prev is null) 
            {
                toInsert.next = head;
                head = toInsert;
            }
            else 
            {
                toInsert.next = current;
                prev.next = toInsert;
            }
        }

        public void Delete(string name)
        {
            ListNode<T> current = head;
            ListNode<T> prev = null;

            while (current != null && current.data.Name != name) 
            {
                prev = current;
                current = current.next;
            }
            if (current != null) 
            {
                if (prev == null) 
                {
                    head = current.next;
                }
                else 
                {
                    prev.next = current.next;
                }
            }
            else 
            {
                throw new NoSuchItemException("There is no item with this name: "+ name);
            }
        }

        public void PrintNodes(ListDisplay method)
        {
            ListDisplay _method = method;
            ListNode<T> current = head;
            int position = 1;
            if (current== null)
            {
                throw new NoNodesToPrintException();
            }
            else
            {
                while (current != null) 
                {
                    if (current.data is BatmanArsenal a)
                    {
                        _method?.Invoke(a, position);
                    }
                    current = current.next;
                    position++;
                }
            }
            
        }

        public T Find(string name)
        {
            ListNode<T> current = head;
            while (current != null)
            {
                if (current.data.Name == name)
                {
                    return current.data;
                }
                current = current.next;
            }
            throw new NoSuchItemException("There is no item with this name: " + name);
        }

        public int Count()
        {
            ListNode<T> current = head;
            int count = 0;
            while (current != null)
            {
                count++;
                current = current.next;
            }
            return count;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new ListTraverser<T>(head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new ListTraverser<T>(head);
        }
    }
}
