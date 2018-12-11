using System.Collections.Generic;
using AssemblyAnalyzer;
using System.Reflection;

namespace AssemblyBrowser.ViewModel
{
    public class NamespaceViewModel
    {
        private Namespace ns;

        public string DeclarationString
        {
            get
            {
                return "namespace " + ns.Name;
            }
            private set { }
        }

        public IEnumerable<TypeViewModel> Types
        {
            get
            {
                foreach (TypeInfo type in ns.Types)
                {
                    yield return new TypeViewModel(type);
                }
            }
            private set { }
        }

        public NamespaceViewModel(Namespace ns)
        {
            this.ns = ns;
        }
    }
}
