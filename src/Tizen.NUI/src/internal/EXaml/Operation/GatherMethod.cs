using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.EXaml
{
    internal class GatherMethod : Operation
    {
        public GatherMethod(int typeIndex, string methodName)
        {
            this.typeIndex = typeIndex;
            this.methodName = methodName;
        }

        public void Do()
        {
            var type = GatherType.GatheredTypes[typeIndex];
            var method = type.GetRuntimeMethods().FirstOrDefault(mi => mi.Name == methodName);
            GatheredMethods.Add(method);
        }

        private int typeIndex;
        private string methodName;
        internal static List<MethodInfo> GatheredMethods = new List<MethodInfo>();
    }
}
