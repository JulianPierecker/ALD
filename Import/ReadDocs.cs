using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SingleLinkedList;

namespace ReadDocs
{
    internal class Docs
    {
        public Docs(string filename)
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
            get => _list;
            set
            {
                foreach (string s in File.ReadAllLines(Directory.GetCurrentDirectory() + "\\" + _filename))
                {
                    List.Add(s);
                }
            }
        }
    }
}
