using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SingleLinkedList;

namespace SLL_TestCase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SingleLinkedList<string> myList = new SingleLinkedList<string>();
            
            int n = 6;

            Console.WriteLine("Hinzufügen und Kontrolle von 6 string Variablen gestartet:\n");
            for (int i = 0; i < n; i++) 
            {
                // Hinzufügen von n string-Variablen
                string str = "str" + i.ToString(); 
                myList.Add(str);

                // Gleichzeitiges überprüfen, ob strings zu myList hinzugefügt wurden
                if (myList.Contains(str))
                    Console.WriteLine($"{str} erfolgreich zu myList hinzugefügt.");
            }

            Console.WriteLine("\nTest, welcher Wert an welchem Index in myList gespeichert wurde:\n");
            for (int i = 0; i < myList.Count(); i++)
            {
                // Prüfen, an welchem Index welcher Wert der myList hinzugefügt wurde
                Console.WriteLine($"An Index: {i} wurde der Wert: {myList.FindByIndex(i)} gespeichert.");
            }

            // Test, ob z.B str3 nach Entfernen der List nichtmehr vorhanden ist
            Console.WriteLine("\nTest, ob z.B str3 nach Entfernen aus der Liste myList nichtmehr vorhanden ist:\n");
            
            string teststring = "str3";
            myList.Remove(teststring);
            if (!myList.Contains(teststring))
                Console.WriteLine($"Der String: {teststring} wurde erfolgreich entfernt.");

            Console.ReadLine();
            
        }
    }
}
