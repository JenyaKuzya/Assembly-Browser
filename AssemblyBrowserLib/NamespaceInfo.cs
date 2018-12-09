using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowserLib
{
    public class NamespaceInfo
    {
        public string Name { set; get; }

        public List<DatatypeInfo> DataTypes { set; get; }

        public NamespaceInfo(string name)
        {
            Name = name;
            DataTypes = new List<DatatypeInfo>();
        }
    }
}
