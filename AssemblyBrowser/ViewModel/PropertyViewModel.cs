using System.Reflection;

namespace AssemblyBrowser.ViewModel
{
    public class PropertyViewModel
    {
        private PropertyInfo property;

        public string DeclarationString
        {
            get
            {
                return property.ToString();
            }
            private set { }
        }

        public PropertyViewModel(PropertyInfo property)
        {
            this.property = property;
        }
    }
}
