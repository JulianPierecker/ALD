using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SingleLinkedList;

namespace Import
{
    public class ImportData
    {
        public ImportData(string filename)
        {
            _filename = filename;
        }

        private SingleLinkedList<string> _list = new SingleLinkedList<string>();

        private string _filename;

        public string Filename
        {
            get => _filename;
            set { }
        }
        public SingleLinkedList<string> List
        {
            get {return _list;}
            set { }
        }

        public void ReadDataFromFile()
        {
            foreach (string s in File.ReadAllLines(Directory.GetCurrentDirectory() + "\\" + _filename))
            {
                _list.Add(s);
            }
        }
    }
}
