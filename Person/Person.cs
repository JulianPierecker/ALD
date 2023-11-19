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
            return string.Format("{0}_{1}_{2}", Name, Geburtsort, Alter).GetHashCode() % 10;
        }
    }

}
