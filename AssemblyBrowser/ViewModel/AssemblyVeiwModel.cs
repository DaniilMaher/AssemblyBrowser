using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace AssemblyBrowser.ViewModel
{
    class AssemblyVeiwModel
    {
        public string Name
        {
            get;
            private set;
        }

        public AssemblyVeiwModel()
        {
            Assembly assembly = Assembly.LoadFrom("E:/Tracer.dll");
            Name = assembly.FullName;
         
        }
    }
}
