using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensch
{
    public class Person
    {
        public string Name { get; set; }
        public string Geburtsort { get; set; }
        public int Alter { get; set; }
        public int Hashsize { get; set; }

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
            int hash = 17;
            hash = hash + Name.GetHashCode();
            hash = hash + Geburtsort.GetHashCode();
            hash = hash + Alter.GetHashCode();
            if (hash < 0)
                hash = hash * (-1);
            return hash % Hashsize;
        }
    }

}
