using ArrayList;
using SingleLinkedList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Mensch;

namespace Hashtables
{
    public class Hashtable<K,V>
    {
        public Hashtable(int length = 1) 
        {
            _array = new SingleLinkedList<Tuple<K, V>>[length];  
        }

        private SingleLinkedList<Tuple<K, V>>[] _array;
        private SingleLinkedList<Tuple<K, V>>[] _arrayCopy;

        float alpha;
        int n = 0;
        int index = 0;

        public void Put(K key, V value)
        {
            index = key.GetHashCode();

            if (_array[index] != null)
            {
                Tuple<K,V> tup = null;
                foreach (Tuple<K, V> item in _array[index])
                {
                   if (item.Item1.Equals(key))
                   {
                        tup = new Tuple<K, V>(item.Item1, value); 
                   }
                   else
                   {
                        tup = null;
                   } 
                }
                if (tup != null)
                    _array[index].Add(tup);
            }
            else
            {
                _array[index] = new SingleLinkedList<Tuple<K,V>>();
                _array[index].Add(new Tuple<K,V>(key, value));
            }
            n++;
            CheckReHashing();
        }

        public V Get(K key)
        {
            index = key.GetHashCode();

            if (_array[index] != null)
            {
                foreach (Tuple<K, V> item in _array[index])
                {
                    if (item.Item1.Equals(key))
                        return item.Item2;
                }
            }
            throw new KeyNotFoundException();
        }

        public bool Remove(K key)
        {
            int index = key.GetHashCode();

            if (_array[index] != null)
            {
                Tuple<K, V> tup = null;
                foreach (Tuple<K, V> item in _array[index])
                {
                    if (item.Item1.Equals(key))
                    {
                        tup = item;
                    }
                    else
                    {
                        tup = null;
                    }
                }
                if (tup != null)
                {
                    _array[index].Remove(tup);
                    n--;
                    CheckReHashing();
                    return true;
                }
            }
            return false;
        }

        private void CheckReHashing()
        {
            alpha = n / _array.Count();
            
            if (alpha > 1.5)
            {
                Array.Resize(ref _array, _array.Count() * 2);
                Array.Copy((SingleLinkedList<Tuple<K, V>>[])_array.Clone(), _array, _array.Count() * 2);
            }
                
        }
    }
}
