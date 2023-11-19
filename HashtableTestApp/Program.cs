using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hashtables;

namespace HashtableTestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hashtable<int,int> hasttab = new Hashtable<int,int>(20);
            hasttab.Put(10, 5);
            hasttab.Remove(10);
        }
    }
}
