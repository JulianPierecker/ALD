﻿using System;
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
            myList.Add(5);
            myList.Add(3);
            myList.Add(2);
            myList.Add(6);

            //Console.WriteLine(myList.Contains(5));
            
            //Console.WriteLine(myList.Remove(5));
            
            //Console.WriteLine(myList.IsObjectAtIndex(2,2));
            
            //Console.WriteLine(myList.FindByIndex(3).m_data);
            
            //Console.WriteLine(myList.Count());
            
            //myList.Clear();
            //Console.WriteLine(myList.Count());
            
            Console.ReadLine();

        }
    }
}
