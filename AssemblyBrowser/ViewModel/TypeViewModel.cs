using System.Collections.Generic;
using System.Reflection;

namespace AssemblyBrowser.ViewModel
{
    public class TypeViewModel
    {
        private TypeInfo type;

        public string DeclarationString 
        {
            get
            {
                string declaration = "";
                if (type.IsInterface)
                {
                    declaration += "interface";
                }
                else if (type.IsClass)
                {
                    if (type.IsAbstract)
                    {
                        declaration += "abstract";
                    }
                    declaration += "class";
                }
                declaration += " " + type.Name;
                return declaration;
            }
            private set { }
        }
        
        public IEnumerable<FieldViewModel> Fields
        {
            get
            {
                foreach (FieldInfo field in type.DeclaredFields)
                {
                    yield return new FieldViewModel(field);
                }
            }
        }

        public IEnumerable<PropertyViewModel> Properties
        {
            get
            {
                foreach (PropertyInfo property in type.DeclaredProperties)
                {
                    yield return new PropertyViewModel(property);
                }
            }
        }

        public IEnumerable<MethodViewModel> Methods
        {
            get
            {
                foreach (MethodInfo method in type.DeclaredMethods)
                {
                    yield return new MethodViewModel(method);
                }
            }
        }

        public TypeViewModel(TypeInfo type)
        {
            this.type = type;
        }
    }
}
