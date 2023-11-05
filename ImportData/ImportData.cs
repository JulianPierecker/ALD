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

namespace Import
{
    public class ImportData
    {
        public ImportData(string filename)
        {
            _filename = filename;
        }

        private SingleLinkedList<string> _sllList = new SingleLinkedList<string>();

        private ArrayList<string> _arrayList = new ArrayList<string>();

        private string _filename;

        Stopwatch timerSLL = new Stopwatch();
        Stopwatch timerArrayList = new Stopwatch();

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
            // Einlesezeit vergleichen
            timerSLL.Start();
            foreach (string s in File.ReadAllLines(Directory.GetCurrentDirectory() + "\\" + _filename))
                _sllList.Add(s);
            timerSLL.Stop();
            Console.WriteLine("Auslesezeit der SingleLinkedList Add-Methode: {0}", timerSLL.Elapsed);

            timerSLL.Reset();

            timerSLL.Start();
            _sllList.Remove("zytotoxischer");
            timerSLL.Stop();
            Console.WriteLine("Auslesezeit der SingleLinkedList Remove-Methode: {0}", timerSLL.Elapsed);


        }

        public void ReadDataFromFileToArrayList()
        {

            // Einlesezeit vergleichen
            timerArrayList.Start();
            foreach (string s in File.ReadAllLines(Directory.GetCurrentDirectory() + "\\" + _filename))
                _arrayList.Add(s);
            timerArrayList.Stop();
            Console.WriteLine("Auslesezeit der ArrayList Add-Methode: {0}", timerArrayList.Elapsed);

            _arrayList.InsertAt(2000000, "15");

            timerArrayList.Reset();

            timerArrayList.Start();
            _arrayList.Remove("zytotoxischer");
            timerArrayList.Stop();
            Console.WriteLine("Auslesezeit der ArrayList Remove-Methode: {0}", timerArrayList.Elapsed);
        }
    }
}
