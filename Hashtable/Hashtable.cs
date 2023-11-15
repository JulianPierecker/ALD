using ArrayList;
using SingleLinkedList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashtable
{
    public class Hashtable<K,V>
    {
        private SingleLinkedList<Tuple<K,V>> _initArray;
        private ArrayList<SingleLinkedList<Tuple<K,V>>> _arrayList;
        public Hashtable() 
        {
            _arrayList = new ArrayList<SingleLinkedList<Tuple<K,V>>>(new SingleLinkedList<Tuple<K, V>>[_initArray.Count()]);
        }

        int randn = 0;

        void Put(K key, V value)
        {
            randn = GetHashCode();
            int index = randn % _arrayList.Count();

            if (_arrayList[index] != null)
            {
                Tuple<K,V> tup = null;
                foreach (Tuple<K, V> item in _arrayList[index])
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
                    _arrayList[index].Add(tup);
            }
            else
            {
                _arrayList.InsertAt(index, new SingleLinkedList<Tuple<K,V>>());
                _arrayList[index].Add(new Tuple<K,V>(key, value));
            }
        }

        V Get(K key)
        {
            randn = GetHashCode();
            int index = randn % _arrayList.Count();

            if (_arrayList[index] != null)
            {
                foreach (Tuple<K, V> item in _arrayList[index])
                {
                    if (item.Item1.Equals(key))
                        return item.Item2;
                }
            }
            throw new KeyNotFoundException();
        }

        bool Remove(K key)
        {

        }




        string value;
        string key;
     
    }
}
