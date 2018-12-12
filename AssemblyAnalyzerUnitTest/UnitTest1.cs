using Microsoft.VisualStudio.TestTools.UnitTesting;
using AssemblyAnalyzer;
using System.Collections.Generic;
using System.Reflection;

namespace AssemblyAnalyzerUnitTest
{
    [TestClass]
    public class UnitTest1
    {

        AssemblyData assemblyData;

        [TestInitialize]
        public void Initialize()
        {
            string path = @"..\..\TestDLL\Faker.dll";
            Assembly assembly = Assembly.LoadFrom(path);
            assemblyData = new AssemblyData(assembly);
        }

        [TestMethod]
        public void TestNamespaceCount()
        {
            Assert.AreEqual(assemblyData.Namespaces.Count, 3);
        }

        [TestMethod]
        public void TestNamespaceName()
        {
            Assert.IsNotNull(assemblyData.Namespaces.Find(n => n.Name == "Faker.BaseTypesValuesGenerators"));
        }
        
        [TestMethod]
        public void TestClassesCount()
        {
            Namespace ns = assemblyData.Namespaces.Find(n => n.Name == "Faker");
            Assert.AreEqual(ns.Types.Count, 7);
        }

        [TestMethod]
        public void ClassName()
        {
            Namespace ns = assemblyData.Namespaces.Find(n => n.Name == "Faker");
            Assert.IsNotNull(ns.Types.Find(t => t.Name == "GeneratorsDictionaryCreator"));
        }

        [TestMethod]
        public void TypeMethodsCount()
        {
            Namespace ns = assemblyData.Namespaces.Find(n => n.Name == "Faker");
            TypeInfo type = ns.Types.Find(t => t.Name == "Faker");
            Assert.AreEqual(new List<MethodInfo>(type.DeclaredMethods).Count, 7);
        }

        [TestMethod]
        public void TypeFieldsCount()
        {
            Namespace ns = assemblyData.Namespaces.Find(n => n.Name == "Faker");
            TypeInfo type = ns.Types.Find(t => t.Name == "Faker");
            Assert.AreEqual(new List<FieldInfo>(type.DeclaredFields).Count, 5);
        }


    }
}
