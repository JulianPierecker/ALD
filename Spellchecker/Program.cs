using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SingleLinkedList;

namespace Spellchecker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\german.dic");

            SingleLinkedList<string> myList = new SingleLinkedList<string>();

            for (int i = 3; i < lines.Length; i++) { myList.Add(lines[i]); }

            Console.WriteLine("Bitte gib einen Satz ein:");
            string[] eingabetext_seperated = Console.ReadLine().Split(' ');

            for (int i = 0; i < eingabetext_seperated.Length; i++)
            {
                if (myList.Contains(eingabetext_seperated[i]))
                {
                    Console.Write(eingabetext_seperated[i] + " ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(eingabetext_seperated[i] + " ");
                }

            }                   
                
            Console.ReadLine();
        }
    }
}
