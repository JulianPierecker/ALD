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
            _arrayList = new ArrayList<SingleLinkedList<Tuple<K,V>>>(_initArray);  
        }

        private SingleLinkedList<Tuple<K, V>>[] _initArray = new SingleLinkedList<Tuple<K, V>>[800000];
        private ArrayList<SingleLinkedList<Tuple<K, V>>> _arrayList;

        float alpha;
        
        int m = 0;
        int n = 0;

        public void Put(K key, V value)
        {
            int index = key.GetHashCode() % 800000;

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
            n++;
            CheckReHashing();
        }

        public V Get(K key)
        {
            int index = key.GetHashCode();

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

        public bool Remove(K key)
        {
            int index = key.GetHashCode();

            if (_arrayList[index] != null)
            {
                Tuple<K, V> tup = null;
                foreach (Tuple<K, V> item in _arrayList[index])
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
                    _arrayList[index].Remove(tup);
                    n--;
                    CheckReHashing();
                    return true;
                }
            }
            return false;
        }

        private int GetIndexFromKey()
        { 
            return GetHashCode() % _arrayList.Count(); 
        }

        private void CheckReHashing()
        {
            m = _arrayList.Count();
            alpha = n / m;
            
            if (alpha > 1.5)
            {
                //Array.Resize<ArrayList<SingleLinkedList<Tuple<K, V>>>>(ref _arrayList, m * 2);
            }
        }
    }
}
