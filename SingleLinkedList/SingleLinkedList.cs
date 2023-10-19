﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleLinkedList
{
    public class Node<T>
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
        public SingleLinkedList() 
        { 
            m_count = 0;
        }
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

            //  Referenz von vorherigem Node auf akutelles Node wird gesetzt: N1 --> N2
            m_last.m_next = tmp;   
            //  Das aktuelle Node wird auf m_last Node gesetzt
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

            // Wenn zu löschendes Node dem m_head Node entspricht --> setze nächstes Node als m_head Node
            if (previous.m_data.Equals(item))
            {
                m_head = m_head.m_next;
            }

            for (Node<T> i = m_head; i != null; i = i.m_next)
            {
                if (i.m_data.Equals(item))
                {
                    // Referenz des aktuellen Nodes, welcher auf nächsten Node zeigt, dem vorherigen Node übergeben 
                    previous.m_next = i.m_next;
                    return true;
                }
                previous = i;
            }
            
            return false;

        }

        public bool IsObjectAtIndex(T value, int index)
        {
            int cnt = 0;
            for (Node<T> i = m_head; i != null; i = i.m_next)
            {
                if (cnt == index && i.m_data.Equals(value))
                {
                    return true;
                }
                cnt++;
            }
            return false;
        }

        public Node<T> FindByIndex(int index)
        {
            int cnt = 0;
            for (Node<T> i = m_head; i != null; i = i.m_next)
            {
                if (cnt == index)
                {
                    return i;
                }
                cnt++;
            }
            // ToDo: Abfangen, falls Index nicht vorhanden
            return null;
        }

        public int Count()
        {
            return m_count;
        }

        public void Clear()
        {
            if (m_head != null)
            {
                m_head = null;
                m_last = null;
                m_count = 0;
            }
        }
    }
}
