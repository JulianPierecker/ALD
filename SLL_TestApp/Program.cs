using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SingleLinkedList;

namespace SLL_TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SingleLinkedList<int> myList = new SingleLinkedList<int>();
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);
            myList.Add(5);

            bool exists = myList.Contains(6);

            Console.WriteLine(exists.ToString());
            Console.ReadLine();

        }
    }
}
