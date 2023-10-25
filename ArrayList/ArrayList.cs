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
        public ArrayList(int length) 
        { 
            m_array = new T[length];
        }

        private T[] m_array;
        public T[] array => m_array;

        int m_length_puffer;
        public void Add(T item)
        {
            m_length_puffer++;
            if (m_length_puffer > m_array.Length)
                Array.Resize(ref m_array, m_array.Length);
            
            // Hinzufügen neuer Werte
            m_array[m_length_puffer] = item;
        }

        public void InsertAt (int index, T item) 
        {
            
            for (int i = index; i < m_array.Length; i++)
            {
                m_array[i+1] = m_array[i];
            }
            m_array[index] = item;
        }

        public bool RemoveAt (int index) 
        { 
            
        }

    }
}