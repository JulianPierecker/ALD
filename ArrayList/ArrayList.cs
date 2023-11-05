﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    public class ArrayList<T>
    {
        public ArrayList(int length = 1) 
        { 
            m_array = new T[length];
        }

        private T[] m_array;
        public T[] array => m_array;

        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < m_array.Length)
                    return m_array[index];
                else
                    throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < m_array.Length)
                    m_array[index] = value;
                else
                    throw new IndexOutOfRangeException();
            }
        }

        int m_length_puffer = 0;
        public void Add(T item)
        {
            if (m_length_puffer >= m_array.Length)
                Array.Resize(ref m_array, 2*m_array.Length);
            
            // Hinzufügen neuer Werte
            m_array[m_length_puffer] = item;
            m_length_puffer++;
        }

        public void InsertAt (int index, T item) 
        {
            // Überprüfen, ob Index innerhalb des Arrays möglich ist
            if (index < 0 || index >= m_array.Length)
                throw new IndexOutOfRangeException();

            // Array um einen Index verlängern, wenn letzter Eintrag ungleich default(T) ist
            if (!m_array[m_array.Length-1].Equals(default(T)))
                Array.Resize(ref m_array, m_array.Length+1);

            // Alle Werte nach dem eingefügtem Item um 1 nach hinten verschieben (von hinten anfangend)
            for (int i = m_array.Length-2; i >= index; i--)
            {
                m_array[i+1] = m_array[i];
            }

            // Item, am gegebenen index einfügen
            m_array[index] = item;
        }
        
        public bool RemoveAt (int index) 
        {
            // Überprüfen, ob Index innerhalb des Arrays möglich ist
            if (index < 0 || index >= m_array.Length)
                throw new IndexOutOfRangeException();

            int cnt_default = 0;
            int cnt_default_max = 0;
            for (int i = 0; i < m_array.Length; i++)
            {
                // Wert am Index auf default(T) setzen (Wert löschen)
                if (i == index)
                    m_array[i] = default(T);
                // Überprüfen, wieviele Elemente default(T) als Wert besitzen
                if (m_array[i].Equals(default(T)))
                    cnt_default++;
                else
                    // Letzten Index merken, welcher Wert enthält, der ungleich default(T) ist
                    cnt_default_max = i;
            }

            // Wenn mehr als die Hälfte des Arrays default(T) entspricht, dann Array verkleinern
            if (cnt_default > (int)(m_array.Length / 2))
                Array.Resize(ref m_array, cnt_default_max+1);

            return true;
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < m_array.Length; i++)
            {
                // Wenn gesuchtes Item dem Item in dem Array entspricht, dann an diesem Index löschen
                if (m_array[i].Equals(item)) 
                {
                    RemoveAt(i);
                    return true;
                }
            }
            return false;

        }

        public void Clear()
        {
            for (int i = 0; i < m_array.Length; i++)
                m_array[i] = default(T);
        }

        public int Count() => m_array.Length;

    }
}
