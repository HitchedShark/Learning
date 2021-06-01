using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SZTF2_NagyHazi
{
    class ListTraverser<T> : IEnumerator<T>
    {
        private ListNode<T> head;
        private ListNode<T> current;
        public T Current => current.data;

        object IEnumerator.Current => current.data;
        public ListTraverser(ListNode<T> head)
        {
            this.head = head;
            this.current = new ListNode<T>();
            this.current.next = head;
        }
        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {
            if (current == null)
            {
                return false;
            }
            current = current.next;
            return current != null;
        }

        public void Reset()
        {
            current = new ListNode<T>();
            current.next = head;
        }
    }
}
