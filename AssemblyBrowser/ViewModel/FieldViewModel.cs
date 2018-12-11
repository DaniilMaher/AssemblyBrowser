using System.Reflection;

namespace AssemblyBrowser.ViewModel
{
    public class FieldViewModel
    {
        private FieldInfo field;

        public string DeclarationString
        {
            get
            {
                return field.ToString();
            }
            private set { }
        }

        public FieldViewModel(FieldInfo field)
        {
            this.field = field;
        }
    }
}
