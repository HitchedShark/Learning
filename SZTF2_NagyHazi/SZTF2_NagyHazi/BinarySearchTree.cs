using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SZTF2_NagyHazi
{
    class BinarySearchTree<T, K> : IEnumerable<T> where K : IComparable where T:IArsenal
    {
        class TreeNode
        {
            public T data;
            public K key;
            public TreeNode left;
            public TreeNode right;
        }

        private TreeNode root;

        public void Insert(T data, K key)
        {
            Insert(ref root, data, key);
        }

        private void Insert(ref TreeNode p, T data, K key)
        {
            if (p == null)
            {
                p = new TreeNode();
                p.data = data;
                p.key = key;
            }
            else
            {
                if (p.key.CompareTo(key) < 0)
                {
                    Insert(ref p.right, data, key);
                }
                else if (p.key.CompareTo(key) > 0)
                {
                    Insert(ref p.left, data, key);
                }
                else
                {
                    throw new ArgumentException("There is alredy an item with this key");
                }
            }
        }

        private void InOrderTraverse(LinkedList<T> list, TreeNode p)
        {
            if (p!=null)
            {
                InOrderTraverse(list, p.left);
                list.Insert(p.data);
                InOrderTraverse(list, p.right);
            }
        }

        private IEnumerable<T> Contents
        {
            get
            {
                LinkedList<T> tmp = new LinkedList<T>();
                InOrderTraverse(tmp, root);
                return tmp;
            }
            
        }
        public IEnumerator<T> GetEnumerator()
        {
            return Contents.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Contents.GetEnumerator();

        }
    }
}
