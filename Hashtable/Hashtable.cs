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

        private double _alpha = 0;
        private int _n = 0;
        private int _index = 0;
        private int _rehash_factor = 4;

        public int Rehash_factor 
        {
            get
            {
                return _rehash_factor;
            }
            set
            {
                _rehash_factor = value;
            }
        }
        

        public void Put(K key, V value)
        {
            int hc = key.GetHashCode();
            if (hc < 0)
                hc = hc * (-1);
            _index = hc % _array.Length;

            if (_array[_index] != null)
            {
                Tuple<K,V> tup = null;
                foreach (Tuple<K, V> item in _array[_index])
                {
                   if (item.Item1.Equals(key))
                   {
                        tup = new Tuple<K, V>(item.Item1, value); 
                   }
                }
                if (tup != null)
                {
                    _array[_index].Add(tup);
                    _n++;
                    CheckReHashing();
                }
                else
                {
                    tup = new Tuple<K, V>(key, value);
                    _array[_index].Add(tup);
                    _n++;
                    CheckReHashing();
                }
                    
            }
            else
            {
                _array[_index] = new SingleLinkedList<Tuple<K,V>>();
                _array[_index].Add(new Tuple<K,V>(key, value));
                _n++;
                CheckReHashing();
            }
            
        }

        public V Get(K key)
        {
            int hc = key.GetHashCode();
            if (hc < 0)
                hc = hc * (-1);
            _index = hc % _array.Length;

            if (_array[_index] != null)
            {
                foreach (Tuple<K, V> item in _array[_index])
                {
                    if (item.Item1.Equals(key))
                        return item.Item2;
                }
            }
            throw new KeyNotFoundException();
        }

        public bool Remove(K key)
        {
            int hc = key.GetHashCode();
            if (hc < 0)
                hc = hc * (-1);
            _index = hc % _array.Length;

            if (_array[_index] != null)
            {
                Tuple<K, V> tup = null;
                foreach (Tuple<K, V> item in _array[_index])
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
                    _array[_index].Remove(tup);
                    _n--;
                    CheckReHashing();
                    return true;
                }
            }
            return false;
        }

        private void CheckReHashing()
        {
            _alpha = (double) _n / _array.Length;
            
            if (_alpha > 1.5)
            {
                ReHash();
            }
                
        }
        private void ReHash()
        {
            _n = 0;
            SingleLinkedList<Tuple<K, V>>[] _arrayOld = new SingleLinkedList<Tuple<K, V>>[_array.Length];
            Array.Copy(_array, _arrayOld, _array.Length);

            _array = new SingleLinkedList<Tuple<K, V>>[_array.Length * _rehash_factor];

            for (int i = 0; i < _arrayOld.Length; i++) 
            {
                if (_arrayOld[i] != null)
                {
                    foreach(Tuple< K, V> element in _arrayOld[i])
                        Put(element.Item1, element.Item2);
                }
            }
        }
    }
}
