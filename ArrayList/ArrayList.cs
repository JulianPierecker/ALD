using System;
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

        //T this[int index] { get; set; }

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
                return;
            // Altes Array um einen Index verlängern
            Array.Resize(ref m_array, m_array.Length+1);

            // Alle Werte nach dem eingefügtem Item um 1 nach hinten verschieben (von hinten anfangend)
            for (int i = m_array.Length-2; i >= index; i--)
            {
                m_array[i+1] = m_array[i];
            }

            // Item, am gegebenen index einfügen
            // Wenn Index >= m_array.Length Exception werfen?
            m_array[index] = item;
        }
        
        public bool RemoveAt (int index) 
        {
            // Überprüfen, ob Index innerhalb des Arrays möglich ist
            if (index < 0 || index >= m_array.Length)
                return false;
            // Ab dem Index den Wert von Index+1 auf Index kopieren
            for (int i = index; i < m_array.Length-1; i++)
            {
                m_array[i] = m_array[i+1];
            }
            // Letztes Element wegschneiden
            Array.Resize(ref m_array, m_array.Length - 1);
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
