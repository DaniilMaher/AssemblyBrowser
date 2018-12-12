using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using AssemblyAnalyzer;
using Microsoft.Win32;
using System.Reflection;

namespace AssemblyBrowser.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        List<Namespace> namespaces;

        public List<NamespaceViewModel> Namespaces
        {
            get
            {
                List<NamespaceViewModel> namespaceViewModels = new List<NamespaceViewModel>();
                foreach (Namespace ns in namespaces)
                {
                    namespaceViewModels.Add(new NamespaceViewModel(ns));
                }
                return namespaceViewModels;
            }
        }

        public Command OpenAssemblyCommand { get; set; }

        public MainViewModel()
        {
            namespaces = new List<Namespace>();
            OpenAssemblyCommand = new Command(OpenAssembly);
        }

        public void OpenAssembly(object param)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "DLL Library|*.dll|Executable file|*.exe";
            if (dialog.ShowDialog().Value)
            {                
                Assembly assembly = Assembly.LoadFrom(dialog.FileName);
                AssemblyData assemblyData = new AssemblyData(assembly);
                namespaces = assemblyData.Namespaces;
                OnPropertyChanged(nameof(Namespaces));
            }
        }
    }
}
