using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SingleLinkedList;
using System.Collections;
using Import;

namespace Spellchecker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Einlesen der Daten aus german.dic 
            ImportData data = new ImportData("german.dic");
            data.ReadDataFromFile();

            Console.WriteLine("Bitte gib einen Satz ein:");
            string[] input_seperated = Console.ReadLine().Split(' ');

            Console.WriteLine("\nTestergebnis:\n");

            // Überprüfen des Inhalts des eingegebenen Textes, ob in german.dic vorhanden (+ Faerbung des Textes)
            foreach (string s in input_seperated)
            {
                if (data.List.Contains(s))
                    Console.ForegroundColor = ConsoleColor.White;
                else
                    Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(s + " ");
            }
            Console.ReadKey();
        }
    }
}
