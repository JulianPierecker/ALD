using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SingleLinkedList;
using System.Collections;
using ImportData;

namespace Spellchecker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Import data = new Import("german.dic");
            data.Fill_list();

            Console.WriteLine("Bitte gib einen Satz ein:");
            string[] input_seperated = Console.ReadLine().Split(' ');

            Console.WriteLine("\nTestergebnis:\n");

            foreach (string s in input_seperated)
            {
                if (data.List.Contains(s))
                    Console.ForegroundColor = ConsoleColor.White;
                else
                    Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(s + " ");
            }
            Console.ReadLine();
        }
    }
}
