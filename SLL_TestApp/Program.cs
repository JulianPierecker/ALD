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

            bool exists = myList.Contains(3);

            while (myList.Remove(1))
            {

            }

            Console.WriteLine(exists.ToString());
            Console.ReadLine();

        }
    }
}
