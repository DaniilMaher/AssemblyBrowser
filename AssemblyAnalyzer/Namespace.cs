using System.Collections.Generic;
using System.Reflection;

namespace AssemblyAnalyzer
{
    public class Namespace
    {
        private List<TypeInfo> types;

        public List<TypeInfo> Types
        {
            get
            {
                return new List<TypeInfo>(types);
            }
        }

        public string Name
        {
            get;
            private set;
        }

        public void AddType(TypeInfo type)
        {
            types.Add(type);
        }

        public Namespace(string name)
        {
            types = new List<TypeInfo>();
            Name = name;
        }
    }
}
