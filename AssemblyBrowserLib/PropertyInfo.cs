using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowserLib
{
    public class PropertyInfo
    {
        public string name;
        public string type;

        public PropertyInfo(System.Reflection.PropertyInfo pi)
        {
            name = pi.Name;
            type = pi.PropertyType.Name;
        }
    }
}
