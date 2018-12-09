using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowserLib
{
    public class DatatypeInfo
    {
        public string Name { set; get; }
        public string DataTypeInfo { set; get; }
        public string shortName;
        public List<FieldInfo> fields;
        public List<PropertyInfo> properties;
        public List<MethodInfo> methods;

        public DatatypeInfo(TypeInfo t)
        {
            // get acces modifires
            string modificators = GetModificators(t);
            if (t.IsAbstract && t.IsSealed)
                modificators += "static ";
            if (t.IsAbstract && !t.IsSealed)
                modificators += "abstract ";
            if (!t.IsAbstract && t.IsSealed)
                modificators += "sealed ";
            shortName = t.Name;
            Name = modificators + GetClassType(t) + shortName;

            fields = new List<FieldInfo>();
            properties = new List<PropertyInfo>();
            methods = new List<MethodInfo>();

            GetFields(t);
            GetProperties(t);
            GetMethods(t);

            DataTypeInfo = String.Empty;
            GetAllDatatypeInfo();
        }

        private void GetFields(Type t)
        {
            var fields = t.GetFields();

            foreach (var field in fields)
            {
                this.fields.Add(new FieldInfo(field));
            }
        }

        private void GetProperties(Type t)
        {
            var properties = t.GetProperties();

            foreach (var property in properties)
            {
                this.properties.Add(new PropertyInfo(property));
            }
        }

        private void GetMethods(Type t)
        {
            var methods = t.GetMethods();

            foreach (var method in methods)
            {
                if (!method.IsSpecialName)
                {
                    this.methods.Add(new MethodInfo(method));
                }
            }
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

        private string GetClassType(Type t)
        {
            if (t.IsInterface)
                return "interface ";
            if (t.IsClass)
                return "class ";
            if (t.IsValueType)
                return "struct ";
            if (t.IsEnum)
                return "enum ";

            if (t.BaseType == typeof(MulticastDelegate))
                return "delegate ";

            else
                return "";
        }

        private void GetAllDatatypeInfo()
        {
            if (fields.Count == 0)
                DataTypeInfo += "\tNo fields.\n";
            else
            {
                DataTypeInfo += "\tFields:\n\t\t";

                foreach (FieldInfo f in fields)
                    DataTypeInfo += f.modificators + " " + f.type + " " + f.name + "\n\t\t";
            }

            if (properties.Count == 0)
                DataTypeInfo += "\n\tNo properties.\n";
            else
            {
                DataTypeInfo += "\n\tProperties:\n\t\t";

                foreach (PropertyInfo p in properties)
                    DataTypeInfo += p.type + " " + p.name + "\n\t\t";
            }

            if (methods.Count == 0)
                DataTypeInfo += "\n\tNo methods.\n";
            else
            {
                DataTypeInfo += "\n\tMethods:\n\t\t";

                foreach (MethodInfo m in methods)
                    DataTypeInfo += m.modificators + m.name + "\n\t\t";
            }
        }
    }
}
