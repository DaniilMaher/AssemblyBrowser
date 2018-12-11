using System.Collections.Generic;
using System.Reflection;

namespace AssemblyAnalyzer
{
    public class AssemblyData
    {
        private List<Namespace> namespaces;
        public string Name
        {
            get;
            private set;
        }

        public List<Namespace> Namespaces
        {
            get
            {
                return new List<Namespace>(namespaces);
            }
        }

        public AssemblyData(Assembly assembly)
        {
            namespaces = new List<Namespace>();
            Name = assembly.FullName;
            foreach (TypeInfo type in assembly.DefinedTypes)
            {
                string nsName = type.Namespace != null ? type.Namespace : "Global";
                Namespace ns = GetOrCreateAndAddNamespace(nsName);
                ns.AddType(type);
            }
        }

        private Namespace GetOrCreateAndAddNamespace(string name)
        {
            Namespace ns = namespaces.Find(n => n.Name == name);
            if (ns == null)
            {
                ns = new Namespace(name);
                namespaces.Add(ns);
            }
            return ns;
        }
    }
}
