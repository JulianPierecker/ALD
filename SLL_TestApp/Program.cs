using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SingleLinkedList;
using ArrayList;
using System.Collections;

namespace SLL_TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList<int> myArrayList = new ArrayList<int>(new int[1]);
            
            myArrayList.Add(1);
            myArrayList.Add(2);
            myArrayList.Add(3);
            myArrayList.Add(4);
            myArrayList.Add(5);
            myArrayList.Add(6);
            myArrayList.Add(7);
            myArrayList.Add(8);

            myArrayList.Remove(5);
   

            int cnt = myArrayList.Count();            

            Console.ReadKey();

            //SingleLinkedList<int> myList = new SingleLinkedList<int>();

            //myList.Add(5);
            //myList.Add(3);
            //myList.Add(2);
            //myList.Add(6);

            //Console.WriteLine(myList.Contains(5));

            //Console.WriteLine(myList.Remove(5));

            //Console.WriteLine(myList.IsObjectAtIndex(2,2));

            /*
            try
            {
                Console.WriteLine(myList.FindByIndex(12));
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message.ToString());
            }*/


            //Console.WriteLine(myList.Count());

            //myList.Clear();
            //Console.WriteLine(myList.Count());

            /*
            foreach (int i in myList) 
            {
                Console.WriteLine(i);
            }*/


            Console.ReadLine();

        }
    }
}
