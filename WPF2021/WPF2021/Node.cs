using System;
using System.Collections.Generic;
using System.Text;

namespace WPF2021
{
    class Node<T>
    {
        T info;
        Node<T> next;

        public Node(T info, Node<T> next)
        {
            this.info = info;
            this.next = next;
        }
        public Node(T info)
        {
            this.info = info;
            this.next = null;
        }
        public void SetInfo(T info)
        {
            this.info = info;
        }
        public void SetNext(Node<T> next)
        {
            this.next = next;
        }
        public T GetInfo()
        {
            return this.info;
        }
        
        public Node<T> GetNext()
        {
            return this.next;
        }
    }
}
