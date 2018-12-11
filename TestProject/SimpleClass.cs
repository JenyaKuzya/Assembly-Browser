using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    class SimpleClass
    {
        private string Name;

        public int ID;

        public string SomeInfo
        {
            get;
            set;
        }

        public override string ToString()
        {
            return Name + SomeInfo;
        }

        public string GetName()
        {
            return Name;
        }

        public SimpleClass(string info)
        {
            Name = info;
        }
    }
}
