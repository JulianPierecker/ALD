using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    public class Node<T>
    {
        public Node(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
    }

    public class ArrayList<T>
    {
        public ArrayList(T[] initArray) 
        {
            m_array = new Node<T>[initArray.Length];
            for (int i = 0; i < initArray.Length; i++)
            {
                m_array[i] = new Node<T>(initArray[i]);
            }
            
            m_length_puffer = initArray.Length;
        }

        int m_length_puffer = 0;
        public Node<T>[] m_array;

        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < m_array.Length)
                    return m_array[index].Value;
                else
                    throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < m_array.Length)
                    m_array[index].Value = value;
                else
                    throw new IndexOutOfRangeException();
            }
        }

        public void Add(T item)
        {
            if (m_array.Length == 0)
                Array.Resize<Node<T>>(ref m_array, 1);
            else if (m_length_puffer >= m_array.Length)
                Array.Resize<Node<T>>(ref m_array, 2 * m_array.Length);

            // Hinzufügen neuer Werte
            m_array[m_length_puffer] = new Node<T>(item);

            m_length_puffer++;
        }

        public void InsertAt (int index, T item) 
        {
            // Überprüfen, ob Index innerhalb des Arrays möglich ist
            if (index < 0 || index >= m_length_puffer)
                throw new IndexOutOfRangeException();

            if (m_length_puffer >= m_array.Length)
                Array.Resize<Node<T>>(ref m_array, 2 * m_array.Length);
            
            // Items ab dem gegebenen Index um 1 nach hinten kopieren
            Array.Copy(m_array, index, m_array, index + 1, m_array.Length - (index + 1));

            // Item, am gegebenen index einfügen
            m_array[index] = new Node<T>(item);

            m_length_puffer++;
        }
        
        public bool RemoveAt (int index) 
        {
            // Überprüfen, ob Index innerhalb des Arrays möglich ist
            if (index < 0 || index >= m_array.Length)
                throw new IndexOutOfRangeException();

            // Items ab dem gegebenen Index um 1 nach vorn kopieren
            // Item, welches entfernt werden soll, wird durch das Item des Nachfolgeitems überschrieben
            Array.Copy(m_array, index + 1, m_array, index, m_array.Length - (index + 1));

            m_length_puffer--;

            if (m_length_puffer <= m_array.Length / 2)
                Array.Resize<Node<T>>(ref m_array, m_array.Length / 2);

            return true;
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < m_array.Length; i++)
            {
                if (m_array[i].Value != null)
                {
                    // Wenn gesuchtes Item dem Item in dem Array entspricht, dann an diesem Index löschen
                    if (m_array[i].Value.Equals(item))
                    {
                        RemoveAt(i);
                        return true;
                    }
                }   
            }
            return false;

        }

        public void Clear()
        {
            m_array = new Node<T>[0];
            m_length_puffer = 0;
        }

        // Gibt Anzahl der hizugefügten Items zurück, nicht die tatsächliche Länge des Arrays
        public int Count() => m_length_puffer;

    }
}
