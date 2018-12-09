using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace AssemblyAnalyzer
{
    public class AssembyDataLoader
    {

        public static AssemblyData LoadAssemblyData(string path)
        {
            Assembly assembly = Assembly.LoadFrom(path);
            return new AssemblyData(assembly);
        }
        
    }
}
