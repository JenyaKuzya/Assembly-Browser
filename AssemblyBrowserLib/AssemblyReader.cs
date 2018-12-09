using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowserLib
{
    public class AssemblyReader
    {
        public List<NamespaceInfo> Namespaces { set; get; }

        public AssemblyReader(string fileName)
        {
            Namespaces = new List<NamespaceInfo>();

            Assembly asm = Assembly.LoadFrom(fileName);

            //namespaces
            foreach (var type in asm.DefinedTypes)
            {
                if (Namespaces.Find(x => x.Name == type.Namespace) == null
                    && type.Namespace != null)
                {
                    Namespaces.Add(new NamespaceInfo(type.Namespace));
                }
            }

            //datatypes
            foreach (var ns in Namespaces)
            {
                foreach (var type in asm.DefinedTypes.Where(x => x.Namespace == ns.Name))
                {
                    ns.DataTypes.Add(new DatatypeInfo(type));
                }
            }
        }
    }
}
