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
            timerSLL.Start();

            foreach (string s in File.ReadAllLines(Directory.GetCurrentDirectory() + "\\" + _filename))
                _sllList.Add(s);

            timerSLL.Stop();
            Console.WriteLine("Auslesezeit der SingleLinkedList: {0}", timerSLL.Elapsed);
        }

        public void ReadDataFromFileToArrayList()
        {
            timerArrayList.Start();

            foreach (string s in File.ReadAllLines(Directory.GetCurrentDirectory() + "\\" + _filename))
                _arrayList.Add(s);

            timerArrayList.Stop();
            Console.WriteLine("Auslesezeit der ArrayList: {0}", timerArrayList.Elapsed);
        }
    }
}
