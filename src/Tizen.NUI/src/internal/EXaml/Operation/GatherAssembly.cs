/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
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
