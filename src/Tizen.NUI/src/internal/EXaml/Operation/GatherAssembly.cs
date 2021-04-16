using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.EXaml
{
    internal class GatherAssembly : Operation
    {
        public GatherAssembly(string assemblyName)
        {
            this.assemblyName = assemblyName;
        }

        public void Do()
        {
            Assembly assembly = null;
            foreach (var name in AssemblyNameList)
            {
                if (name.FullName.StartsWith(assemblyName))
                {
                    assembly = Assembly.Load(name);
                    GatheredAssemblies.Add(assembly);
                    break;
                }
            }
        }

        private static List<AssemblyName> assemblyNameList;
        private static List<AssemblyName> AssemblyNameList
        {
            get
            {
                if (null == assemblyNameList)
                {
                    assemblyNameList = new List<AssemblyName>();
                    assemblyNameList.Add(EXamlExtensions.MainAssembly.GetName());

                    var assemblyNames = EXamlExtensions.MainAssembly.GetReferencedAssemblies();

                    foreach (var name in assemblyNames)
                    {
                        assemblyNameList.Add(name);
                    }
                }

                return assemblyNameList;
            }
        }

        private string assemblyName;
        internal static List<Assembly> GatheredAssemblies = new List<Assembly>();
    }
}
