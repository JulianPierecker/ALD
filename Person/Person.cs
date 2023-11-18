using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hashtable;

namespace Mensch
{
    public class Person
    {
        public string Name { get; set; }
        public string Geburtsort { get; set; }
        public int Alter { get; set; }

        Hashtable<int, int> hasttab = new Hashtable<int, int>(1);

        public Person(string name, string geschlecht, int alter)
        {
            Name = name;
            Geburtsort = geschlecht;
            Alter = alter;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Alter: {Geburtsort}, Geschlecht: {Alter}";
        }

        public override int GetHashCode()
        {
            int result = (Name != null) ? Name.GetHashCode() : 0;
            result = (result * 397) ^ (Geburtsort != null ? Geburtsort.GetHashCode() : 0);
            result = (result * 397) ^ Alter; // Link both values using bitwise XOR
            return result;
        }
    }

}
