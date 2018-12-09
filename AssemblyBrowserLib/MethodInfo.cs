using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace AssemblyBrowserLib
{
    public class MethodInfo
    {
        public string name;
        public string modificators;

        public MethodInfo(System.Reflection.MethodInfo mi)
        {
            name = mi.Name;

            // get acces modifires
            modificators = GetModificators(mi.GetType()) + mi.ToString();
            if (mi.IsAbstract && !mi.DeclaringType.IsInterface)
                modificators += "abstract ";
            if (mi.GetCustomAttribute(typeof(AsyncStateMachineAttribute)) != null)
                modificators += "async ";
            if ((mi.MethodImplementationFlags & MethodImplAttributes.InternalCall) != 0)
                modificators += "extern ";
            if (!mi.Equals(mi.GetBaseDefinition()))
                modificators += "overriden ";
            if (mi.IsVirtual && mi.IsFinal)
                modificators += "sealed ";
            if (mi.IsStatic)
                modificators += "static ";
            if (mi.IsVirtual && !mi.IsFinal && mi.Equals(mi.GetBaseDefinition()) && !mi.DeclaringType.IsInterface)
                modificators += "virtual ";
        }

        private string GetModificators(Type t)
        {
            if (t.IsNestedPrivate)
                return "private ";
            if (t.IsNotPublic)
                return "private ";

            if (t.IsNestedFamily)
                return "protected ";
            if (t.IsNestedFamANDAssem)
                return "protected private ";
            if (t.IsNestedAssembly)
                return "internal ";
            if (t.IsNestedFamORAssem)
                return "protected internal ";

            if (t.IsNestedPublic || t.IsPublic)
                return "public ";
            else
                return "public ";
        }
    }
}
