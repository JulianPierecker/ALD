using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hashtable;

namespace HashtableTestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hashtable<int, int> hasttab = new Hashtable<int,int>(1);
            hasttab.Put(10, 5);
            var test = hasttab.Get(10);
            hasttab.Remove(10);
            hasttab.Put(8, 6);
            int test1 = 10;
        }
    }
}
