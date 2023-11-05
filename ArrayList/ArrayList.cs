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
            _array = new Node<T>[initArray.Length];
            for (int i = 0; i < initArray.Length; i++)
            {
                _array[i] = new Node<T>(initArray[i]);
            }
            
            m_length_puffer = initArray.Length;
        }

        int m_length_puffer = 0;
        public Node<T>[] _array;

        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < _array.Length)
                    return _array[index].Value;
                else
                    throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < _array.Length)
                    _array[index].Value = value;
                else
                    throw new IndexOutOfRangeException();
            }
        }

        
        public void Add(T item)
        {
            if (m_length_puffer >= _array.Length)
                Array.Resize<Node<T>>(ref _array, 2 * _array.Length);

            // Hinzufügen neuer Werte
            _array[m_length_puffer] = new Node<T>(item);

            m_length_puffer++;
        }

        public void InsertAt (int index, T item) 
        {
            // Überprüfen, ob Index innerhalb des Arrays möglich ist
            if (index < 0 || index >= _array.Length)
                throw new IndexOutOfRangeException();

            if (m_length_puffer >= _array.Length)
                Array.Resize<Node<T>>(ref _array, 2 * _array.Length);

            Array.Copy(_array, index, _array, index + 1, _array.Length - (index + 1));

            // Item, am gegebenen index einfügen
            _array[index] = new Node<T>(item);
        }
        
        public bool RemoveAt (int index) 
        {
            // Überprüfen, ob Index innerhalb des Arrays möglich ist
            if (index < 0 || index >= _array.Length)
                throw new IndexOutOfRangeException();

            Array.Copy(_array, index + 1, _array, index, _array.Length - (index + 1));

            return true;
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i] != null)
                {
                    // Wenn gesuchtes Item dem Item in dem Array entspricht, dann an diesem Index löschen
                    if (_array[i].Value.Equals(item))
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
            _array = new Node<T>[0];
            m_length_puffer = 0;
        }

        public int Count() => _array.Length;
        // member count

    }
}
