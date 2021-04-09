using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.EXaml
{
    internal class GatherTypes : Operation
    {
        public GatherTypes(int assemblyIndex, string typeName)
        {
            this.assemblyIndex = assemblyIndex;
            this.typeName = typeName;
        }

        public void Do()
        {
            var assembly = GatherAssemblies.GatheredAssemblies[assemblyIndex];
            GatheredTypes.Add(assembly.GetType(typeName));
        }

        private int assemblyIndex;
        private string typeName;
        internal static List<Type> GatheredTypes = new List<Type>();
    }

}
