using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SingleLinkedList;
using ArrayList;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Hashtables;
using Mensch;

namespace Import
{
    public class ImportData
    {
        public ImportData(string filename)
        {
            _filename = filename;
        }

        private SingleLinkedList<string> _sllList = new SingleLinkedList<string>();

        private ArrayList<string> _arrayList = new ArrayList<string>(new string[0]);

        private Hashtable<string, string> _hasttable = new Hashtable<string, string>();

        private Hashtable<Person, string> _hasttable_refTest = new Hashtable<Person, string>();

        private string _filename;

        Stopwatch timerSLL = new Stopwatch();
        Stopwatch timerArrayList = new Stopwatch();
        Stopwatch timerHashtable = new Stopwatch();

        public string Filename
        {
            get => _filename;
            set { }
        }
        public SingleLinkedList<string> sllList
        {
            get { return _sllList; }
            set { }
        }

        public ArrayList<string> arrayList
        {
            get { return _arrayList; }
            set { }
        }

        public void ReadDataFromFileToSLL()
        {
            timerSLL.Start();
            foreach (string s in File.ReadAllLines(Directory.GetCurrentDirectory() + "\\" + _filename))
                _sllList.Add(s);
            timerSLL.Stop();
            Console.WriteLine("Auslesezeit der SingleLinkedList Add-Methode: {0}", timerSLL.Elapsed);

            timerArrayList.Reset();

            timerSLL.Start();
            _sllList.Remove("zytotoxisches");
            timerSLL.Stop();
            Console.WriteLine("Auslesezeit der SingleLinkedList Remove-Methode: {0}", timerSLL.Elapsed);



        }

        public void ReadDataFromFileToArrayList()
        {
            timerArrayList.Start();
            foreach (string s in File.ReadAllLines(Directory.GetCurrentDirectory() + "\\" + _filename))
                _arrayList.Add(s);
            timerArrayList.Stop();
            Console.WriteLine("Auslesezeit der ArrayList Add-Methode: {0}", timerArrayList.Elapsed);

            timerArrayList.Reset();

            timerArrayList.Start();
            _arrayList.Remove("zytotoxisches");
            timerArrayList.Stop();
            Console.WriteLine("Auslesezeit der ArrayList Remove-Methode: {0}", timerArrayList.Elapsed);
        }

        public void ReadDataFromFileToHashtable()
        {
            timerHashtable.Start();
            foreach (string s in File.ReadAllLines(Directory.GetCurrentDirectory() + "\\" + _filename))
                _hasttable.Put(s, s);
            timerHashtable.Stop();
            Console.WriteLine("Auslesezeit der Hashtable Put-Methode: {0}", timerHashtable.Elapsed);

            timerHashtable.Reset();

            timerHashtable.Start();
            _hasttable.Remove("zytotoxisches");
            timerHashtable.Stop();
            Console.WriteLine("Auslesezeit der Hashtable Remove-Methode: {0}", timerHashtable.Elapsed);
        }

        public void TestReferenceHashtable()
        {
            Person per1 = new Person("Hubert", "m", 60);
            Person per2 = new Person("Luki", "m", 43);
            per1.Hashsize = 10;
            per2.Hashsize = 10;

            _hasttable_refTest.Put(per1, "Hallo Hubert");
            _hasttable_refTest.Put(per2, "Hallo Luki");

            per1.Alter = 61;

            string value = _hasttable_refTest.Get(per1);
            if (value == "Hallo Hubert")
                Console.WriteLine("Hubert wurde gefunden, trotz Wertänderung");
            else
                Console.WriteLine("Hubert wurde nicht gefunden, aufgrund einer Wertänderung");

        }
    }
}
