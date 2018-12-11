using System.Reflection;

namespace AssemblyBrowser.ViewModel
{
    public class MethodViewModel
    {
        private MethodInfo method;
        private string accessAttribute;

        public string DeclarationString
        {
            get
            {
                string declaration = accessAttribute;
                declaration += " " + method.ToString();
                return declaration;
            }
            private set { }
        }

        public MethodViewModel(MethodInfo method)
        {
            this.method = method;
            accessAttribute = AccessAttributeString(method);
        }

        private static string AccessAttributeString(MethodInfo method)
        {
            MethodAttributes attributes = method.Attributes;
            switch (attributes)
            {
                case MethodAttributes.Public: return "public";
                case MethodAttributes.Private: return "private";
                case MethodAttributes.Assembly: return "internal";
                case MethodAttributes.Family: return "protected";
                case MethodAttributes.FamANDAssem: return "private protected";
                case MethodAttributes.FamORAssem: return "protected internal";
                default: return "";
            }
        }
    }
}
