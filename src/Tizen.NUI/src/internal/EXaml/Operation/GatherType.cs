using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.EXaml
{
    internal class GatherType : Operation
    {
        public GatherType(int assemblyIndex, string typeName, List<int> genericTypeIndexs = null)
        {
            this.assemblyIndex = assemblyIndex;
            this.typeName = typeName;
            this.genericTypeIndexs = genericTypeIndexs;
        }

        public void Do()
        {
            var assembly = GatherAssembly.GatheredAssemblies[assemblyIndex];
            var type = assembly.GetType(typeName);

            if (null != genericTypeIndexs)
            {
                Type[] args = new Type[genericTypeIndexs.Count];

                for (int i = 0; i < genericTypeIndexs.Count; i++)
                {
                    args[i] = GatheredTypes[genericTypeIndexs[i]];
                }

                type = type.MakeGenericType(args);
            }

            GatheredTypes.Add(type);
        }

        private int assemblyIndex;
        private string typeName;
        private List<int> genericTypeIndexs;

        internal static List<Type> GatheredTypes = new List<Type>();
    }

}
