using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleLinkedList
{
    internal class Node<T>
    {
        public Node(T item)
        {
            m_data = item;
        }
        public Node<T> m_next { get; set; }
        public T m_data { get; set; }
    }
    public class SingleLinkedList<T>
    {
        Node<T> m_head { get; set; }
        Node<T> m_last { get; set; }
        int m_count { get; set; }

        public void Add(T item)
        {
            m_count++;
            Node<T> tmp = new Node<T>(item);
            if(m_head == null) 
            {
                m_head = tmp;
                m_last = tmp;
                return;
            }

            m_last.m_next = tmp;
            m_last = tmp;
        }

        public bool Contains(T item)
        {
            for (Node<T> i = m_head; i != null; i = i.m_next)
            {
                if (i.m_data.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public bool Remove(T item)
        {
            Node<T> previous = m_head;

            //if (m_head.m_data.Equals(item)) {m_head. }

            for (Node<T> i = m_head; i != null; i = i.m_next)
            {
                if (i.m_data.Equals(item))
                {
                    previous.m_next = i.m_next;
                    return true;
                }

                previous = i;
            }
            return false;

        }
    }
}
